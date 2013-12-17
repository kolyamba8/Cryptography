namespace _2.Viginer
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.rtb_clear = new System.Windows.Forms.RichTextBox();
            this.rtb_cipher = new System.Windows.Forms.RichTextBox();
            this.b_encode = new System.Windows.Forms.Button();
            this.b_decode = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_key = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // rtb_clear
            // 
            this.rtb_clear.Location = new System.Drawing.Point(16, 51);
            this.rtb_clear.Name = "rtb_clear";
            this.rtb_clear.Size = new System.Drawing.Size(241, 146);
            this.rtb_clear.TabIndex = 0;
            this.rtb_clear.Text = "";
            // 
            // rtb_cipher
            // 
            this.rtb_cipher.Location = new System.Drawing.Point(455, 51);
            this.rtb_cipher.Name = "rtb_cipher";
            this.rtb_cipher.Size = new System.Drawing.Size(241, 146);
            this.rtb_cipher.TabIndex = 3;
            this.rtb_cipher.Text = "";
            // 
            // b_encode
            // 
            this.b_encode.Location = new System.Drawing.Point(290, 122);
            this.b_encode.Name = "b_encode";
            this.b_encode.Size = new System.Drawing.Size(132, 23);
            this.b_encode.TabIndex = 2;
            this.b_encode.Text = "Encode ->";
            this.b_encode.UseVisualStyleBackColor = true;
            this.b_encode.Click += new System.EventHandler(this.b_encode_Click);
            // 
            // b_decode
            // 
            this.b_decode.Location = new System.Drawing.Point(290, 162);
            this.b_decode.Name = "b_decode";
            this.b_decode.Size = new System.Drawing.Size(132, 23);
            this.b_decode.TabIndex = 4;
            this.b_decode.Text = "<- Decode";
            this.b_decode.UseVisualStyleBackColor = true;
            this.b_decode.Click += new System.EventHandler(this.b_decode_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(83, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "Clear Text";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(526, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 24);
            this.label2.TabIndex = 5;
            this.label2.Text = "Cipher Text";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(338, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Key";
            // 
            // tb_key
            // 
            this.tb_key.Location = new System.Drawing.Point(290, 74);
            this.tb_key.Name = "tb_key";
            this.tb_key.Size = new System.Drawing.Size(132, 20);
            this.tb_key.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(729, 223);
            this.Controls.Add(this.tb_key);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.b_decode);
            this.Controls.Add(this.b_encode);
            this.Controls.Add(this.rtb_cipher);
            this.Controls.Add(this.rtb_clear);
            this.MaximumSize = new System.Drawing.Size(745, 262);
            this.MinimumSize = new System.Drawing.Size(745, 262);
            this.Name = "Form1";
            this.Text = "2. Viginer Cipher";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtb_clear;
        private System.Windows.Forms.RichTextBox rtb_cipher;
        private System.Windows.Forms.Button b_encode;
        private System.Windows.Forms.Button b_decode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_key;
    }
}

