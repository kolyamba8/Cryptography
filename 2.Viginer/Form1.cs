using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _2.Viginer
{
    public partial class Form1 : Form
    {
        Viginer Vg = new Viginer(Alphabet.Everything);
        public Form1()
        {
            InitializeComponent();
        }

        //encode button
        private void b_encode_Click(object sender, EventArgs e)
        {
            rtb_cipher.Text = Vg.getEncryption(rtb_clear.Text,tb_key.Text);//output
        }

        private void b_decode_Click(object sender, EventArgs e)
        {
            rtb_clear.Text = Vg.getDecryption(rtb_cipher.Text, tb_key.Text);//output
        }

    }
}
