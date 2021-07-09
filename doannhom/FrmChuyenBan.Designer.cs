
namespace doannhom
{
    partial class FrmChuyenBan
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
            this.cbbBanconguoi = new System.Windows.Forms.ComboBox();
            this.cbbBantrong = new System.Windows.Forms.ComboBox();
            this.btnChuyen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chuyển từ bàn";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Chuyển đến bàn";
            // 
            // cbbBanconguoi
            // 
            this.cbbBanconguoi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbBanconguoi.Location = new System.Drawing.Point(119, 34);
            this.cbbBanconguoi.Name = "cbbBanconguoi";
            this.cbbBanconguoi.Size = new System.Drawing.Size(121, 21);
            this.cbbBanconguoi.TabIndex = 2;
            this.cbbBanconguoi.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // cbbBantrong
            // 
            this.cbbBantrong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbBantrong.FormattingEnabled = true;
            this.cbbBantrong.Location = new System.Drawing.Point(119, 80);
            this.cbbBantrong.Name = "cbbBantrong";
            this.cbbBantrong.Size = new System.Drawing.Size(121, 21);
            this.cbbBantrong.TabIndex = 3;
            // 
            // btnChuyen
            // 
            this.btnChuyen.Location = new System.Drawing.Point(119, 118);
            this.btnChuyen.Name = "btnChuyen";
            this.btnChuyen.Size = new System.Drawing.Size(75, 23);
            this.btnChuyen.TabIndex = 4;
            this.btnChuyen.Text = "Chuyển";
            this.btnChuyen.UseVisualStyleBackColor = true;
            this.btnChuyen.Click += new System.EventHandler(this.btnChuyen_Click);
            // 
            // FrmChuyenBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 165);
            this.Controls.Add(this.btnChuyen);
            this.Controls.Add(this.cbbBantrong);
            this.Controls.Add(this.cbbBanconguoi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmChuyenBan";
            this.Text = "FrmChuyenBan";
            this.Load += new System.EventHandler(this.FrmChuyenBan_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbbBanconguoi;
        private System.Windows.Forms.ComboBox cbbBantrong;
        private System.Windows.Forms.Button btnChuyen;
    }
}