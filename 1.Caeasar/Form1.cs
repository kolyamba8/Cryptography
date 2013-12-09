using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _1.Caesar
{
    public partial class Form1 : Form
    {
        Caesar cr = new Caesar(Alphabet.Everything);
        public Form1()
        {
            InitializeComponent();
        }

        //encode button
        private void b_encode_Click(object sender, EventArgs e)
        {
            rtb_cipher.Text = cr.getEncryption(rtb_clear.Text,(int)nud_shift.Value);//output
        }

        private void b_decode_Click(object sender, EventArgs e)
        {
            rtb_clear.Text = cr.getDecryption(rtb_cipher.Text, (int)nud_shift.Value);//output
        }

    }
}
