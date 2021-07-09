
namespace doannhom
{
    partial class FrmGhepBan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbbBan1 = new System.Windows.Forms.ComboBox();
            this.cbbBan2 = new System.Windows.Forms.ComboBox();
            this.cbbBanTrong = new System.Windows.Forms.ComboBox();
            this.btnGopBan = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cbbNV = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ghép từ bàn";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(228, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "và bàn";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Vào bàn";
            // 
            // cbbBan1
            // 
            this.cbbBan1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbBan1.FormattingEnabled = true;
            this.cbbBan1.Location = new System.Drawing.Point(101, 34);
            this.cbbBan1.Name = "cbbBan1";
            this.cbbBan1.Size = new System.Drawing.Size(121, 21);
            this.cbbBan1.TabIndex = 3;
            this.cbbBan1.SelectedIndexChanged += new System.EventHandler(this.cbbBan1_SelectedIndexChanged);
            // 
            // cbbBan2
            // 
            this.cbbBan2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbBan2.FormattingEnabled = true;
            this.cbbBan2.Location = new System.Drawing.Point(274, 34);
            this.cbbBan2.Name = "cbbBan2";
            this.cbbBan2.Size = new System.Drawing.Size(121, 21);
            this.cbbBan2.TabIndex = 4;
            // 
            // cbbBanTrong
            // 
            this.cbbBanTrong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbBanTrong.FormattingEnabled = true;
            this.cbbBanTrong.Location = new System.Drawing.Point(101, 90);
            this.cbbBanTrong.Name = "cbbBanTrong";
            this.cbbBanTrong.Size = new System.Drawing.Size(294, 21);
            this.cbbBanTrong.TabIndex = 5;
            // 
            // btnGopBan
            // 
            this.btnGopBan.Location = new System.Drawing.Point(179, 179);
            this.btnGopBan.Name = "btnGopBan";
            this.btnGopBan.Size = new System.Drawing.Size(75, 23);
            this.btnGopBan.TabIndex = 6;
            this.btnGopBan.Text = "Gộp";
            this.btnGopBan.UseVisualStyleBackColor = true;
            this.btnGopBan.Click += new System.EventHandler(this.btnGopBan_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "NV gộp";
            // 
            // cbbNV
            // 
            this.cbbNV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbNV.FormattingEnabled = true;
            this.cbbNV.Location = new System.Drawing.Point(101, 127);
            this.cbbNV.Name = "cbbNV";
            this.cbbNV.Size = new System.Drawing.Size(294, 21);
            this.cbbNV.TabIndex = 8;
            // 
            // FrmGhepBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 229);
            this.Controls.Add(this.cbbNV);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnGopBan);
            this.Controls.Add(this.cbbBanTrong);
            this.Controls.Add(this.cbbBan2);
            this.Controls.Add(this.cbbBan1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmGhepBan";
            this.Text = "FrmGhepBan";
            this.Load += new System.EventHandler(this.FrmGhepBan_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbbBan1;
        private System.Windows.Forms.ComboBox cbbBan2;
        private System.Windows.Forms.ComboBox cbbBanTrong;
        private System.Windows.Forms.Button btnGopBan;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbbNV;
    }
}