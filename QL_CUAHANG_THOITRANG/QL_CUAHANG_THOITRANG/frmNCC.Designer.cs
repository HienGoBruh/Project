namespace QL_CUAHANG_THOITRANG
{
    partial class frmNCC
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
            this.btnTK = new System.Windows.Forms.Button();
            this.txtTK = new System.Windows.Forms.TextBox();
            this.pnlNcc = new System.Windows.Forms.Panel();
            this.txtMaNcc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDiaChiNcc = new System.Windows.Forms.TextBox();
            this.txtSDTNCC = new System.Windows.Forms.TextBox();
            this.txtTenNcc = new System.Windows.Forms.TextBox();
            this.txtEmailNcc = new System.Windows.Forms.TextBox();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.dgvNcc = new System.Windows.Forms.DataGridView();
            this.btnRESET = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlNcc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNcc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTK
            // 
            this.btnTK.BackColor = System.Drawing.Color.Gainsboro;
            this.btnTK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTK.Image = global::QL_CUAHANG_THOITRANG.Properties.Resources.tim4;
            this.btnTK.Location = new System.Drawing.Point(497, 15);
            this.btnTK.Name = "btnTK";
            this.btnTK.Size = new System.Drawing.Size(66, 31);
            this.btnTK.TabIndex = 16;
            this.btnTK.UseVisualStyleBackColor = false;
            this.btnTK.Click += new System.EventHandler(this.btnTK_Click);
            // 
            // txtTK
            // 
            this.txtTK.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTK.Location = new System.Drawing.Point(33, 17);
            this.txtTK.Name = "txtTK";
            this.txtTK.Size = new System.Drawing.Size(361, 27);
            this.txtTK.TabIndex = 15;
            this.txtTK.Enter += new System.EventHandler(this.txtTK_Enter);
            this.txtTK.Leave += new System.EventHandler(this.txtTK_Leave);
            // 
            // pnlNcc
            // 
            this.pnlNcc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlNcc.Controls.Add(this.txtMaNcc);
            this.pnlNcc.Controls.Add(this.label1);
            this.pnlNcc.Controls.Add(this.label2);
            this.pnlNcc.Controls.Add(this.label3);
            this.pnlNcc.Controls.Add(this.label4);
            this.pnlNcc.Controls.Add(this.label5);
            this.pnlNcc.Controls.Add(this.txtDiaChiNcc);
            this.pnlNcc.Controls.Add(this.txtSDTNCC);
            this.pnlNcc.Controls.Add(this.txtTenNcc);
            this.pnlNcc.Controls.Add(this.txtEmailNcc);
            this.pnlNcc.Enabled = false;
            this.pnlNcc.Location = new System.Drawing.Point(32, 57);
            this.pnlNcc.Name = "pnlNcc";
            this.pnlNcc.Size = new System.Drawing.Size(638, 146);
            this.pnlNcc.TabIndex = 14;
            // 
            // txtMaNcc
            // 
            this.txtMaNcc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaNcc.Location = new System.Drawing.Point(199, 20);
            this.txtMaNcc.Name = "txtMaNcc";
            this.txtMaNcc.Size = new System.Drawing.Size(100, 27);
            this.txtMaNcc.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã nhà cung cấp:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tên nhà cung cấp:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Địa chỉ :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(360, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "SDT:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(360, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "Email:";
            // 
            // txtDiaChiNcc
            // 
            this.txtDiaChiNcc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiaChiNcc.Location = new System.Drawing.Point(111, 98);
            this.txtDiaChiNcc.Name = "txtDiaChiNcc";
            this.txtDiaChiNcc.Size = new System.Drawing.Size(510, 27);
            this.txtDiaChiNcc.TabIndex = 1;
            // 
            // txtSDTNCC
            // 
            this.txtSDTNCC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSDTNCC.Location = new System.Drawing.Point(437, 18);
            this.txtSDTNCC.Name = "txtSDTNCC";
            this.txtSDTNCC.Size = new System.Drawing.Size(184, 27);
            this.txtSDTNCC.TabIndex = 1;
            // 
            // txtTenNcc
            // 
            this.txtTenNcc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenNcc.Location = new System.Drawing.Point(200, 56);
            this.txtTenNcc.Name = "txtTenNcc";
            this.txtTenNcc.Size = new System.Drawing.Size(156, 27);
            this.txtTenNcc.TabIndex = 1;
            // 
            // txtEmailNcc
            // 
            this.txtEmailNcc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmailNcc.Location = new System.Drawing.Point(437, 57);
            this.txtEmailNcc.Name = "txtEmailNcc";
            this.txtEmailNcc.Size = new System.Drawing.Size(184, 27);
            this.txtEmailNcc.TabIndex = 1;
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.Color.Gainsboro;
            this.btnLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.Image = global::QL_CUAHANG_THOITRANG.Properties.Resources._181;
            this.btnLuu.Location = new System.Drawing.Point(381, 408);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 43);
            this.btnLuu.TabIndex = 8;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.BackColor = System.Drawing.Color.Gainsboro;
            this.btnHuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuy.Image = global::QL_CUAHANG_THOITRANG.Properties.Resources._192;
            this.btnHuy.Location = new System.Drawing.Point(477, 408);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(75, 43);
            this.btnHuy.TabIndex = 9;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = false;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.Gainsboro;
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Location = new System.Drawing.Point(572, 409);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(97, 43);
            this.btnThoat.TabIndex = 10;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.Gainsboro;
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Image = global::QL_CUAHANG_THOITRANG.Properties.Resources._16;
            this.btnXoa.Location = new System.Drawing.Point(220, 408);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 43);
            this.btnXoa.TabIndex = 11;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.Gainsboro;
            this.btnSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.Image = global::QL_CUAHANG_THOITRANG.Properties.Resources._18;
            this.btnSua.Location = new System.Drawing.Point(127, 408);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 43);
            this.btnSua.TabIndex = 12;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.Gainsboro;
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Image = global::QL_CUAHANG_THOITRANG.Properties.Resources._15;
            this.btnThem.Location = new System.Drawing.Point(32, 408);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 43);
            this.btnThem.TabIndex = 13;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // dgvNcc
            // 
            this.dgvNcc.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvNcc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvNcc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNcc.Location = new System.Drawing.Point(32, 209);
            this.dgvNcc.Name = "dgvNcc";
            this.dgvNcc.Size = new System.Drawing.Size(637, 193);
            this.dgvNcc.TabIndex = 7;
            this.dgvNcc.Click += new System.EventHandler(this.dgvNcc_Click);
            // 
            // btnRESET
            // 
            this.btnRESET.BackColor = System.Drawing.Color.Gainsboro;
            this.btnRESET.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRESET.Image = global::QL_CUAHANG_THOITRANG.Properties.Resources.reset;
            this.btnRESET.Location = new System.Drawing.Point(572, 14);
            this.btnRESET.Name = "btnRESET";
            this.btnRESET.Size = new System.Drawing.Size(73, 32);
            this.btnRESET.TabIndex = 17;
            this.btnRESET.UseVisualStyleBackColor = false;
            this.btnRESET.Click += new System.EventHandler(this.btnRESET_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::QL_CUAHANG_THOITRANG.Properties.Resources._333;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(775, 473);
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // frmNCC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 465);
            this.Controls.Add(this.btnRESET);
            this.Controls.Add(this.btnTK);
            this.Controls.Add(this.txtTK);
            this.Controls.Add(this.pnlNcc);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.dgvNcc);
            this.Controls.Add(this.pictureBox1);
            this.Name = "frmNCC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmNCC";
            this.Load += new System.EventHandler(this.frmNCC_Load);
            this.pnlNcc.ResumeLayout(false);
            this.pnlNcc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNcc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTK;
        private System.Windows.Forms.TextBox txtTK;
        private System.Windows.Forms.Panel pnlNcc;
        private System.Windows.Forms.TextBox txtMaNcc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDiaChiNcc;
        private System.Windows.Forms.TextBox txtSDTNCC;
        private System.Windows.Forms.TextBox txtTenNcc;
        private System.Windows.Forms.TextBox txtEmailNcc;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.DataGridView dgvNcc;
        private System.Windows.Forms.Button btnRESET;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}