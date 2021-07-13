
namespace doannhom
{
    partial class FrmTachBan
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
            this.clbMonAn = new System.Windows.Forms.CheckedListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbbBanTach = new System.Windows.Forms.ComboBox();
            this.cbbNVTach = new System.Windows.Forms.ComboBox();
            this.cbbBanDen = new System.Windows.Forms.ComboBox();
            this.btnTach = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chọn bàn cần tách";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nhân viên tách";
            // 
            // clbMonAn
            // 
            this.clbMonAn.FormattingEnabled = true;
            this.clbMonAn.Location = new System.Drawing.Point(15, 143);
            this.clbMonAn.Name = "clbMonAn";
            this.clbMonAn.Size = new System.Drawing.Size(342, 214);
            this.clbMonAn.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Chọn bàn tách";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Danh sách món ăn bàn";
            // 
            // cbbBanTach
            // 
            this.cbbBanTach.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbBanTach.FormattingEnabled = true;
            this.cbbBanTach.Location = new System.Drawing.Point(129, 30);
            this.cbbBanTach.Name = "cbbBanTach";
            this.cbbBanTach.Size = new System.Drawing.Size(225, 21);
            this.cbbBanTach.TabIndex = 5;
            this.cbbBanTach.DropDownClosed += new System.EventHandler(this.cbbBanTach_SelectedValueChanged);
            // 
            // cbbNVTach
            // 
            this.cbbNVTach.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbNVTach.FormattingEnabled = true;
            this.cbbNVTach.Location = new System.Drawing.Point(129, 60);
            this.cbbNVTach.Name = "cbbNVTach";
            this.cbbNVTach.Size = new System.Drawing.Size(225, 21);
            this.cbbNVTach.TabIndex = 6;
            // 
            // cbbBanDen
            // 
            this.cbbBanDen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbBanDen.FormattingEnabled = true;
            this.cbbBanDen.Location = new System.Drawing.Point(129, 87);
            this.cbbBanDen.Name = "cbbBanDen";
            this.cbbBanDen.Size = new System.Drawing.Size(225, 21);
            this.cbbBanDen.TabIndex = 7;
            this.cbbBanDen.SelectedIndexChanged += new System.EventHandler(this.cbbBanDen_SelectedIndexChanged);
            // 
            // btnTach
            // 
            this.btnTach.Location = new System.Drawing.Point(145, 364);
            this.btnTach.Name = "btnTach";
            this.btnTach.Size = new System.Drawing.Size(75, 23);
            this.btnTach.TabIndex = 8;
            this.btnTach.Text = "Chuyển";
            this.btnTach.UseVisualStyleBackColor = true;
            this.btnTach.Click += new System.EventHandler(this.btnTach_Click);
            // 
            // FrmTachBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 398);
            this.Controls.Add(this.btnTach);
            this.Controls.Add(this.cbbBanDen);
            this.Controls.Add(this.cbbNVTach);
            this.Controls.Add(this.cbbBanTach);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.clbMonAn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmTachBan";
            this.Text = "Frm Tach Ban";
            this.Load += new System.EventHandler(this.FrmTachBan_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox clbMonAn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbbBanTach;
        private System.Windows.Forms.ComboBox cbbNVTach;
        private System.Windows.Forms.ComboBox cbbBanDen;
        private System.Windows.Forms.Button btnTach;
    }
}