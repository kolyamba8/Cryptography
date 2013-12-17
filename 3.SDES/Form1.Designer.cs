namespace DES
{
    partial class DESForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.bEncode = new System.Windows.Forms.Button();
            this.bDecode = new System.Windows.Forms.Button();
            this.tKey = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tFile = new System.Windows.Forms.TextBox();
            this.bBrowse = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.tIV = new System.Windows.Forms.TextBox();
            this.bReset = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bEncode
            // 
            this.bEncode.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bEncode.Location = new System.Drawing.Point(310, 29);
            this.bEncode.Name = "bEncode";
            this.bEncode.Size = new System.Drawing.Size(75, 25);
            this.bEncode.TabIndex = 1;
            this.bEncode.Text = "Encode";
            this.bEncode.UseVisualStyleBackColor = true;
            this.bEncode.Click += new System.EventHandler(this.bEncode_Click);
            // 
            // bDecode
            // 
            this.bDecode.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bDecode.Location = new System.Drawing.Point(310, 71);
            this.bDecode.Name = "bDecode";
            this.bDecode.Size = new System.Drawing.Size(75, 25);
            this.bDecode.TabIndex = 2;
            this.bDecode.Text = "Decode";
            this.bDecode.UseVisualStyleBackColor = true;
            this.bDecode.Click += new System.EventHandler(this.bDecode_Click);
            // 
            // tKey
            // 
            this.tKey.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tKey.Location = new System.Drawing.Point(103, 29);
            this.tKey.MaxLength = 10;
            this.tKey.Name = "tKey";
            this.tKey.Size = new System.Drawing.Size(168, 25);
            this.tKey.TabIndex = 5;
            this.tKey.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tKey_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(31, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "key:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(31, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "File:";
            // 
            // tFile
            // 
            this.tFile.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tFile.Location = new System.Drawing.Point(103, 71);
            this.tFile.Name = "tFile";
            this.tFile.ReadOnly = true;
            this.tFile.Size = new System.Drawing.Size(168, 25);
            this.tFile.TabIndex = 12;
            // 
            // bBrowse
            // 
            this.bBrowse.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bBrowse.Location = new System.Drawing.Point(310, 116);
            this.bBrowse.Name = "bBrowse";
            this.bBrowse.Size = new System.Drawing.Size(75, 25);
            this.bBrowse.TabIndex = 13;
            this.bBrowse.Text = "Browse";
            this.bBrowse.UseVisualStyleBackColor = true;
            this.bBrowse.Click += new System.EventHandler(this.bBrowse_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 17);
            this.label6.TabIndex = 14;
            this.label6.Text = "Initial Vector:";
            // 
            // tIV
            // 
            this.tIV.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tIV.Location = new System.Drawing.Point(103, 117);
            this.tIV.MaxLength = 8;
            this.tIV.Name = "tIV";
            this.tIV.Size = new System.Drawing.Size(168, 25);
            this.tIV.TabIndex = 15;
            this.tIV.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tIV_KeyUp);
            // 
            // bReset
            // 
            this.bReset.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bReset.Location = new System.Drawing.Point(310, 158);
            this.bReset.Name = "bReset";
            this.bReset.Size = new System.Drawing.Size(75, 25);
            this.bReset.TabIndex = 16;
            this.bReset.Text = "Reset";
            this.bReset.UseVisualStyleBackColor = true;
            this.bReset.Click += new System.EventHandler(this.bReset_Click);
            // 
            // DESForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 211);
            this.Controls.Add(this.bReset);
            this.Controls.Add(this.tIV);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.bBrowse);
            this.Controls.Add(this.tFile);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tKey);
            this.Controls.Add(this.bDecode);
            this.Controls.Add(this.bEncode);
            this.Name = "DESForm";
            this.Text = "SDES";
            this.Load += new System.EventHandler(this.DESForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bEncode;
        private System.Windows.Forms.Button bDecode;
        private System.Windows.Forms.TextBox tKey;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tFile;
        private System.Windows.Forms.Button bBrowse;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tIV;
        private System.Windows.Forms.Button bReset;
    }
}

