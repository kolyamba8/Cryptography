using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Des
{
    public partial class Form1 : Form
    {
        string EncodedData, DecodedData;
        byte[] fileData;
        public Form1()
        {
            InitializeComponent();
        }

        private void button_choose_file_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text files (*.txt)|*.txt";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                BinaryReader sR = new BinaryReader(File.Open(ofd.FileName, FileMode.Open), Encoding.ASCII);
                int i = 0;
                while (sR.PeekChar() != -1)
                {
                    i++;
                  sR.ReadByte();

                }
                sR.Close();
                BinaryReader sR2 = new BinaryReader(File.Open(ofd.FileName, FileMode.Open), Encoding.ASCII);
                fileData = sR2.ReadBytes(i);

                sR2.Close();
            }

            textBox1.Text = ofd.FileName.Split('\\')[ofd.FileName.Split('\\').Length-1];

            textBox2.Enabled = true;
            
           
        }

        private void button_encode_Click(object sender, EventArgs e)
        {
            DES.Setkey(textBox2.Text);
            EncodedData = "";
            byte[] copyF = new byte[fileData.Length];
            fileData.CopyTo(copyF, 0);

            if (fileData.Length % 8 != 0 || fileData.Length < 8)
            {
                int o = fileData.Length;
                while (o % 8 != 0) o++;
                fileData = new byte[o];
                copyF.CopyTo(fileData, 0);
            }

            int part = fileData.Length / 8;

            for (int i = 0; i < part; i++)
            {
                byte[] b_part = new byte[8];
                for (int j = 0; j < 8; j++)
                    b_part[j] = fileData[i * 8 + j];

                    EncodedData += DES.Encryprion(b_part);                   
            }
            

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text files (*.txt)|*.txt";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                BinaryWriter STG = new BinaryWriter(File.Open(sfd.FileName, FileMode.Create));

                byte[] unicodeBytes = Encoding.Unicode.GetBytes(EncodedData);
                byte[] asciiBytes = Encoding.Convert(Encoding.Unicode, Encoding.Default, unicodeBytes);

                for(int i = 0; i < asciiBytes.Length; i++)
                    STG.Write(asciiBytes[i]);
                STG.Close();
            }
        }

        private void button_decode_Click(object sender, EventArgs e)
        {
            DES.Setkey(textBox2.Text);
            DecodedData = "";
            byte[] copyF = new byte[fileData.Length];
            fileData.CopyTo(copyF, 0);

            if (fileData.Length % 8 != 0 || fileData.Length < 8)
            {
                int o = fileData.Length;
                while (o % 8 != 0) o++;
                fileData = new byte[o];
                copyF.CopyTo(fileData, 0);
            }

            int part = fileData.Length / 8;
            for (int i = 0; i < part; i++)
            {
                byte[] b_part = new byte[8];
                for (int j = 0; j < 8; j++)
                    b_part[j] = fileData[i * 8 + j];
                DecodedData += DES.Decryption(b_part);  
            }
           

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text files (*.txt)|*.txt";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sW = new StreamWriter(sfd.FileName);
                sW.Write(DecodedData);
                sW.Close();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.Length == 8)
            {
                button_decode.Enabled = true;
                button_encode.Enabled = true;
            }
            else
            {
                button_decode.Enabled = false;
                button_encode.Enabled = false;
            }

        }
    }
}
