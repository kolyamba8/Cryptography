using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace mp3
{
    class PicForHide
    {
        const int startR = 50, startG = 70, startB = 90;
        const int endR = 60, endG = 80, endB = 100;
        private Bitmap picBitmap;

        public Bitmap Image {get { return picBitmap; }}

        public Boolean Status
        {
            get
            {
                if (picBitmap != null) 
                    return true;
                else
                    return false;
            }
        }

        public PicForHide(string picturePath)
        {
                picBitmap = new Bitmap(picturePath,true);      
        }

        public void Clear()
        {
            picBitmap = null;
        }

        public void Encode(string message)
        {

            if (picBitmap.Size.Height * picBitmap.Size.Width / 8 < message.Length)
            {
                throw new Exception(String.Format("Message size is too high for this image. (You have:{0} symbols, Maximum: {1} symbols)", message.Length, picBitmap.Size.Height * picBitmap.Size.Width / 8));
            }

            byte[] text = System.Text.Encoding.UTF8.GetBytes(message);
            byte[] symb = new byte[1];
            
            BitArray letter;
            int x = 0, y = 0;

            picBitmap.SetPixel(x, y, Color.FromArgb(startR, startG, startB));
            x++;

            foreach (byte b in text)
            {
                symb[0] = b;
                letter = new BitArray(symb);

                for (int i = 0; i < 8; i++)
                {
                    //тру - нечет, фолс - чет
                    if (letter[i] == true)
                    {
                        int green = picBitmap.GetPixel(x, y).G;
                        if(green % 2 == 0)
                            picBitmap.SetPixel(x, y, Color.FromArgb(picBitmap.GetPixel(x, y).R, picBitmap.GetPixel(x, y).G + 1, picBitmap.GetPixel(x, y).B));
                    }
                    if (letter[i] == false)
                    {
                        int green = picBitmap.GetPixel(x, y).G;
                        if (green % 2 != 0)
                            picBitmap.SetPixel(x, y, Color.FromArgb(picBitmap.GetPixel(x, y).R, picBitmap.GetPixel(x, y).G - 1, picBitmap.GetPixel(x, y).B));
                    }

                    if (x == picBitmap.Size.Width-1)
                    {
                        y++;
                        x = 0;
                    }
                    else
                        x++;
                }

            }

            picBitmap.SetPixel(x, y, Color.FromArgb(endR,endG,endB));
        }


        public string Decode()
        {
            String message = "";
            if(CheckPic())
            {
                int x = 1, y = 0,i = 0, j = 0;
                BitArray letter = new BitArray(8);
                Byte[] text = new byte[MessageLenght()/8];

                while(!CheckEnd(picBitmap.GetPixel(x, y)))
                {
                    if (picBitmap.GetPixel(x, y).G % 2 != 0)
                        letter[i] = true;
                    if (picBitmap.GetPixel(x, y).G % 2 == 0)
                        letter[i] = false;
                    i++;

                    if (x == picBitmap.Size.Width-1)
                    {
                        y++;
                        x = 0;
                    }
                    else
                        x++;

                    if (i == 8)
                    {
                        letter.CopyTo(text,j);
                        letter = new BitArray(8);
                        i = 0;
                        j++;
                    }
                }

                message = System.Text.Encoding.UTF8.GetString(text);
            }

            return message;

        }
        public void Save(string Path)
        {
            picBitmap.Save(Path, System.Drawing.Imaging.ImageFormat.Bmp);
        }

        private bool CheckEnd(Color Pixel)
        {
            if (Pixel.R == endR && Pixel.G == endG && Pixel.B == endB)
                return true;
            else
                return false;
        }

        private bool CheckPic()
        {
            if (picBitmap.GetPixel(0, 0).R == startR && picBitmap.GetPixel(0, 0).G == startG && picBitmap.GetPixel(0, 0).B == startB)
                return true;
            else
                return false;
        }

        private int MessageLenght()
        {
            int x = 1, y = 0;
            int i = 0;
            if (CheckPic())
            {
                while (!CheckEnd(picBitmap.GetPixel(x, y)))
                {
                    i++;

                    if (x == picBitmap.Size.Width-1)
                    {
                        y++;
                        x = 0;
                    }
                    else
                        x++;
                }
            }

            return i;
        }
    }
}
