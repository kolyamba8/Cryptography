using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace mp3
{
    public partial class Form1 : Form
    {
        private PicForHide pic;
        string format;

        public Form1()
        {
            InitializeComponent();
        }

        private void button_open_picture_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = ".//";
            openFileDialog1.Filter = "All files (*.*)|*.*";
            openFileDialog1.RestoreDirectory = false;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pic = new PicForHide(openFileDialog1.FileName);
                    format = Path.GetExtension(openFileDialog1.FileName);
					format = format.Split('.')[1];
                    pictureBox1.Image = pic.Image;
                    pictureBox1.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                    pic.Clear();
                    pictureBox1.Hide();
                    
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                pic.Encode(richTextBox1.Text);
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.InitialDirectory = ".//";

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {              
                        pic.Save(saveFileDialog1.FileName + "." + format);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Could not save file. Original error: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = ".//";
            openFileDialog1.Filter = "All files (*.*)|*.*";
            openFileDialog1.RestoreDirectory = false;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pic = new PicForHide(openFileDialog1.FileName);
                    pictureBox1.Image = pic.Image;
                    pictureBox1.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                    pic.Clear();
                    pictureBox1.Hide();
                }

                richTextBox2.Text = pic.Decode();
            }


        }
    }
}
