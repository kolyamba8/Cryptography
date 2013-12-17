using System;
using System.IO;
using System.Windows.Forms;

namespace DES
{
    public partial class DESForm : Form
    {
        private string defaultEncodedFileName;
        private string defaultDecodedFileName;
        private static int maxKeyLen = 10;
        private static int maxMessageLen = 8;
        private static int maxCodeLen = 8;
        private static int maxIVLen = 8;

        public DESForm()
        {
            InitializeComponent();
            defaultEncodedFileName = "encodedFile.txt";
            defaultDecodedFileName = "decodedFile.txt";
        }

        //загрузка формы
        private void DESForm_Load(object sender, EventArgs e)
        {
            Check_Status();
        }

        //кнопка кодирования
        private void bEncode_Click(object sender, EventArgs e)
        {
            //проверка на корректность
            if (!Must_Be_1_OR_0("Encode"))
            {
                return;
            }

            //проверка на длину имени файла
            else if (tFile.TextLength != 0)
            {
                byte initVector = Des.Convert_String_To_Byte(tIV.Text);
                string finputname=tFile.Text;
                FileStream fin = new FileStream(finputname, FileMode.Open);
                if (!fin.CanRead)
                {
                    MessageBox.Show("Cannot open the file!", "Error");
                    fin.Close();
                    return;
                }
                if (fin.Length == 0)//проверка на длину содержимого файла
                {
                    MessageBox.Show("Cannot encode empty file!", "Error");
                    fin.Close();
                    return;
                }
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.Title = "Choose the directory to save the encoded file";
                dlg.Filter = "Text Document(*.txt)|*.txt|All Files(*.*)|*.*";
                string flagfname = Path.GetFileNameWithoutExtension(finputname);
                dlg.FileName = "encoded"+flagfname+".txt";
                while (dlg.ShowDialog() != DialogResult.OK)
                {
                    MessageBox.Show("Choose the directory to save the encoded file");
                }
                string filename = dlg.FileName;

                FileStream fout = new FileStream(filename, FileMode.Create);
                if (!fout.CanWrite)
                {
                    MessageBox.Show("Cannot create file!", "Error");
                    fin.Close();
                    fout.Close();
                    return;
                }

                Des.Generate_Key(tKey.Text, ref Des.key1, ref Des.key2);
                byte messageBlock = 0;
                int temp = 0;
                byte result = initVector;
                while ((temp = fin.ReadByte()) != -1)
                {
                    messageBlock = (byte)temp;
                    messageBlock ^= result;
                    result = Des.Single_Block_Encode(messageBlock);
                    fout.WriteByte(result);
                }

                MessageBox.Show("The file has been encoded sucessfully!", "Congratulations");
                fout.Close();
                fin.Close();
             

            }
        }


        //кнопка декодирования
        private void bDecode_Click(object sender, EventArgs e)
        {
            //проверка
            if (!Must_Be_1_OR_0("Decode"))
            {
                return;
            }

            //тоже самое
            else if (tFile.TextLength != 0)
            {
                byte initVector = Des.Convert_String_To_Byte(tIV.Text);
                string finputname = tFile.Text;
                FileStream fin = new FileStream(finputname, FileMode.Open);
                if (!fin.CanRead)
                {
                    MessageBox.Show("Cannot open the file!", "Error");
                    fin.Close();
                    return;
                }
                if (fin.Length == 0)
                {
                    MessageBox.Show("Cannot decode empty file!", "Error");
                    fin.Close();
                    return;
                } 
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.Title = "Choose the directory to save the decoded file";
                dlg.Filter = "Text Document(*.txt)|*.txt|All Files(*.*)|*.*";
                string flagfname = Path.GetFileNameWithoutExtension(finputname);
                dlg.FileName = "decoded"+flagfname+".txt";
                while (dlg.ShowDialog() != DialogResult.OK)
                {
                    MessageBox.Show("Choose the directory to save the decoded file");
                }
                string filename = dlg.FileName;

                FileStream fout = new FileStream(filename, FileMode.Create);
                if (!fout.CanWrite)
                {
                    MessageBox.Show("Cannot create file!", "Error");
                    fin.Close();
                    fout.Close();
                    return;
                }

                Des.Generate_Key(tKey.Text, ref Des.key1, ref Des.key2);
                byte codeBlock = 0;
                int temp = 0;
                byte result = 0;
                byte prevCodeBlock = initVector;
                while ((temp = fin.ReadByte()) != -1)
                {
                    codeBlock = (byte)temp;
                    result = Des.Single_Block_Decode(codeBlock);
                    result ^= prevCodeBlock;
                    fout.WriteByte(result);
                    prevCodeBlock = codeBlock;
                }

                MessageBox.Show("The file has been encoded sucessfully!", "Congratulations");
                fout.Close();
                fin.Close();
            }
        }


        //проверка статуса для блокировки и разблокировки кнопок
        private void Check_Status()
        {

            if ((tKey.TextLength == maxKeyLen && tFile.TextLength != 0&&tIV.Text.Length==maxIVLen))
                bEncode.Enabled = true;
            else
                bEncode.Enabled = false;
            if ((tKey.TextLength == maxKeyLen && tFile.TextLength != 0 && tIV.Text.Length == maxIVLen))
                bDecode.Enabled = true;
            else
                bDecode.Enabled = false;

        }

        //выбор файла
        private void bBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title="Choose the file you want to encode/decode";
            dlg.Filter = "Text Document(*.txt)|*.txt|All Files(*.*)|*.*";
            if(dlg.ShowDialog()==DialogResult.OK)
            {
                string totalInputName = dlg.FileName;
                tFile.Text = totalInputName;
                Check_Status();
            }

        }

        private void tMessage_KeyUp(object sender, KeyEventArgs e)
        {
            Check_Status();
        }

        private void tKey_KeyUp(object sender, KeyEventArgs e)
        {
            Check_Status();
        }

        private void tCode_KeyUp(object sender, KeyEventArgs e)
        {
            Check_Status();
        }

        private void tIV_KeyUp(object sender, KeyEventArgs e)
        {
            Check_Status();
        }

        private void bReset_Click(object sender, EventArgs e)
        {
            tKey.Text = "";
            tIV.Text = "";
            tFile.Text = "";
            Check_Status();

        }




        //проверка на корректность ключа и вектора
        private bool Must_Be_1_OR_0(string input)
        {
            for (int i = 0; i < tKey.TextLength; i++)
            {
                if (tKey.Text[i] != '0' && tKey.Text[i] != '1')
                {
                    MessageBox.Show("You must only enter 0 or 1 in the key textbox!", "Error");
                    return false;
                }
            }

            if (input == "Encode")
            {
                    for (int i = 0; i < tIV.Text.Length; i++)
                    {
                        if (tIV.Text[i] != '0' && tIV.Text[i] != '1')
                        {
                            MessageBox.Show("You must only enter 0 or 1 in the initial vector textbox!", "Error");
                            return false;
                        }
                    }
            }
            if (input == "Decode")
            {

                    for (int i = 0; i < tIV.Text.Length; i++)
                    {
                        if (tIV.Text[i] != '0' && tIV.Text[i] != '1')
                        {
                            MessageBox.Show("You must only enter 0 or 1 in the initial vector textbox!", "Error");
                            return false;
                        }
                    }

                
            }

            return true;
        }

        

        

        

        

        

        

        



    }
}
