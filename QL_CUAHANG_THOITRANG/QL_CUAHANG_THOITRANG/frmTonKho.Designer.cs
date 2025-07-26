namespace QL_CUAHANG_THOITRANG
{
    partial class frmTonKho
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
            this.txtTK = new System.Windows.Forms.TextBox();
            this.btnTK = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.dgvTK = new System.Windows.Forms.DataGridView();
            this.pnlTK = new System.Windows.Forms.Panel();
            this.cboSP = new System.Windows.Forms.ComboBox();
            this.cboMau = new System.Windows.Forms.ComboBox();
            this.cboSize = new System.Windows.Forms.ComboBox();
            this.txtMaTonKho = new System.Windows.Forms.TextBox();
            this.txtSL = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRESET = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTK)).BeginInit();
            this.pnlTK.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTK
            // 
            this.txtTK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTK.Location = new System.Drawing.Point(152, 15);
            this.txtTK.Name = "txtTK";
            this.txtTK.Size = new System.Drawing.Size(271, 27);
            this.txtTK.TabIndex = 14;
            this.txtTK.Enter += new System.EventHandler(this.txtTK_Enter);
            this.txtTK.Leave += new System.EventHandler(this.txtTK_Leave);
            // 
            // btnTK
            // 
            this.btnTK.BackColor = System.Drawing.Color.Gainsboro;
            this.btnTK.Font = new System.Drawing.Font("Montserrat Medium", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTK.Location = new System.Drawing.Point(435, 9);
            this.btnTK.Name = "btnTK";
            this.btnTK.Size = new System.Drawing.Size(100, 33);
            this.btnTK.TabIndex = 13;
            this.btnTK.Text = "Tìm kiếm";
            this.btnTK.UseVisualStyleBackColor = false;
            this.btnTK.Click += new System.EventHandler(this.btnTK_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.Color.Gainsboro;
            this.btnLuu.Font = new System.Drawing.Font("Montserrat Medium", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.Image = global::QL_CUAHANG_THOITRANG.Properties.Resources._181;
            this.btnLuu.Location = new System.Drawing.Point(521, 349);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 43);
            this.btnLuu.TabIndex = 7;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.BackColor = System.Drawing.Color.Gainsboro;
            this.btnHuy.Font = new System.Drawing.Font("Montserrat Medium", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuy.Image = global::QL_CUAHANG_THOITRANG.Properties.Resources._192;
            this.btnHuy.Location = new System.Drawing.Point(609, 349);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(75, 43);
            this.btnHuy.TabIndex = 8;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = false;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.Gainsboro;
            this.btnThoat.Font = new System.Drawing.Font("Montserrat Medium", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Location = new System.Drawing.Point(697, 349);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 43);
            this.btnThoat.TabIndex = 9;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.Gainsboro;
            this.btnXoa.Font = new System.Drawing.Font("Montserrat Medium", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Image = global::QL_CUAHANG_THOITRANG.Properties.Resources._16;
            this.btnXoa.Location = new System.Drawing.Point(194, 349);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 43);
            this.btnXoa.TabIndex = 10;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.Gainsboro;
            this.btnSua.Font = new System.Drawing.Font("Montserrat Medium", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.Image = global::QL_CUAHANG_THOITRANG.Properties.Resources._18;
            this.btnSua.Location = new System.Drawing.Point(105, 349);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 43);
            this.btnSua.TabIndex = 11;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.Gainsboro;
            this.btnThem.Font = new System.Drawing.Font("Montserrat Medium", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Image = global::QL_CUAHANG_THOITRANG.Properties.Resources._15;
            this.btnThem.Location = new System.Drawing.Point(16, 349);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 43);
            this.btnThem.TabIndex = 12;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // dgvTK
            // 
            this.dgvTK.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvTK.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvTK.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTK.Location = new System.Drawing.Point(16, 147);
            this.dgvTK.Name = "dgvTK";
            this.dgvTK.Size = new System.Drawing.Size(782, 176);
            this.dgvTK.TabIndex = 6;
            this.dgvTK.Click += new System.EventHandler(this.dgvTK_Click);
            // 
            // pnlTK
            // 
            this.pnlTK.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlTK.Controls.Add(this.cboSP);
            this.pnlTK.Controls.Add(this.cboMau);
            this.pnlTK.Controls.Add(this.cboSize);
            this.pnlTK.Controls.Add(this.txtMaTonKho);
            this.pnlTK.Controls.Add(this.txtSL);
            this.pnlTK.Controls.Add(this.label5);
            this.pnlTK.Controls.Add(this.label4);
            this.pnlTK.Controls.Add(this.label3);
            this.pnlTK.Controls.Add(this.label2);
            this.pnlTK.Controls.Add(this.label1);
            this.pnlTK.Enabled = false;
            this.pnlTK.Location = new System.Drawing.Point(16, 54);
            this.pnlTK.Name = "pnlTK";
            this.pnlTK.Size = new System.Drawing.Size(781, 87);
            this.pnlTK.TabIndex = 5;
            // 
            // cboSP
            // 
            this.cboSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSP.FormattingEnabled = true;
            this.cboSP.Location = new System.Drawing.Point(173, 47);
            this.cboSP.Name = "cboSP";
            this.cboSP.Size = new System.Drawing.Size(176, 28);
            this.cboSP.TabIndex = 2;
            // 
            // cboMau
            // 
            this.cboMau.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMau.FormattingEnabled = true;
            this.cboMau.Location = new System.Drawing.Point(419, 48);
            this.cboMau.Name = "cboMau";
            this.cboMau.Size = new System.Drawing.Size(121, 28);
            this.cboMau.TabIndex = 2;
            // 
            // cboSize
            // 
            this.cboSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSize.FormattingEnabled = true;
            this.cboSize.Location = new System.Drawing.Point(419, 15);
            this.cboSize.Name = "cboSize";
            this.cboSize.Size = new System.Drawing.Size(121, 28);
            this.cboSize.TabIndex = 2;
            // 
            // txtMaTonKho
            // 
            this.txtMaTonKho.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaTonKho.Location = new System.Drawing.Point(173, 14);
            this.txtMaTonKho.Name = "txtMaTonKho";
            this.txtMaTonKho.Size = new System.Drawing.Size(100, 27);
            this.txtMaTonKho.TabIndex = 1;
            // 
            // txtSL
            // 
            this.txtSL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSL.Location = new System.Drawing.Point(665, 16);
            this.txtSL.Name = "txtSL";
            this.txtSL.Size = new System.Drawing.Size(100, 27);
            this.txtSL.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Montserrat Medium", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(561, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 24);
            this.label5.TabIndex = 0;
            this.label5.Text = "Số lượng:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Montserrat Medium", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(366, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 24);
            this.label4.TabIndex = 0;
            this.label4.Text = "Màu:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Montserrat Medium", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(366, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 24);
            this.label3.TabIndex = 0;
            this.label3.Text = "Size:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Montserrat Medium", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tên sản phẩm:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Montserrat Medium", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã tồn kho:";
            // 
            // btnRESET
            // 
            this.btnRESET.BackColor = System.Drawing.Color.Gainsboro;
            this.btnRESET.Font = new System.Drawing.Font("Montserrat Medium", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRESET.Location = new System.Drawing.Point(551, 9);
            this.btnRESET.Name = "btnRESET";
            this.btnRESET.Size = new System.Drawing.Size(117, 34);
            this.btnRESET.TabIndex = 15;
            this.btnRESET.Text = "RESET";
            this.btnRESET.UseVisualStyleBackColor = false;
            this.btnRESET.Click += new System.EventHandler(this.btnRESET_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::QL_CUAHANG_THOITRANG.Properties.Resources._333;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(827, 421);
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // frmTonKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 415);
            this.Controls.Add(this.btnRESET);
            this.Controls.Add(this.txtTK);
            this.Controls.Add(this.btnTK);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.dgvTK);
            this.Controls.Add(this.pnlTK);
            this.Controls.Add(this.pictureBox1);
            this.Name = "frmTonKho";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmTonKho";
            this.Load += new System.EventHandler(this.frmTonKho_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTK)).EndInit();
            this.pnlTK.ResumeLayout(false);
            this.pnlTK.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTK;
        private System.Windows.Forms.Button btnTK;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.DataGridView dgvTK;
        private System.Windows.Forms.Panel pnlTK;
        private System.Windows.Forms.ComboBox cboSP;
        private System.Windows.Forms.ComboBox cboMau;
        private System.Windows.Forms.ComboBox cboSize;
        private System.Windows.Forms.TextBox txtMaTonKho;
        private System.Windows.Forms.TextBox txtSL;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRESET;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}