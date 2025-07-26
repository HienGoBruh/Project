namespace QL_CUAHANG_THOITRANG
{
    partial class frmMain
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
            this.Menuhethong = new System.Windows.Forms.MenuStrip();
            this.mnHT = new System.Windows.Forms.ToolStripMenuItem();
            this.mnQLTK = new System.Windows.Forms.ToolStripMenuItem();
            this.mnQLCN = new System.Windows.Forms.ToolStripMenuItem();
            this.mnPhanQuyen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnQL = new System.Windows.Forms.ToolStripMenuItem();
            this.mnQLDM = new System.Windows.Forms.ToolStripMenuItem();
            this.mnQLChatlieu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnQLSanPham = new System.Windows.Forms.ToolStripMenuItem();
            this.mnQLKhachhang = new System.Windows.Forms.ToolStripMenuItem();
            this.mnQLNhanvien = new System.Windows.Forms.ToolStripMenuItem();
            this.mnQLSize = new System.Windows.Forms.ToolStripMenuItem();
            this.mnQLMau = new System.Windows.Forms.ToolStripMenuItem();
            this.mnQLHoaDon = new System.Windows.Forms.ToolStripMenuItem();
            this.mnHDB = new System.Windows.Forms.ToolStripMenuItem();
            this.mnHDN = new System.Windows.Forms.ToolStripMenuItem();
            this.mnNCC = new System.Windows.Forms.ToolStripMenuItem();
            this.mnQLTONKHO = new System.Windows.Forms.ToolStripMenuItem();
            this.mnTK = new System.Windows.Forms.ToolStripMenuItem();
            this.mnTKKH = new System.Windows.Forms.ToolStripMenuItem();
            this.mnTKNCC = new System.Windows.Forms.ToolStripMenuItem();
            this.mnTKNV = new System.Windows.Forms.ToolStripMenuItem();
            this.mnTKHD = new System.Windows.Forms.ToolStripMenuItem();
            this.mnTKSP = new System.Windows.Forms.ToolStripMenuItem();
            this.mnTKCL = new System.Windows.Forms.ToolStripMenuItem();
            this.mnTKDM = new System.Windows.Forms.ToolStripMenuItem();
            this.mnBC = new System.Windows.Forms.ToolStripMenuItem();
            this.mnBCDT = new System.Windows.Forms.ToolStripMenuItem();
            this.mnBCDT_NGAY = new System.Windows.Forms.ToolStripMenuItem();
            this.mnBCDT_NV = new System.Windows.Forms.ToolStripMenuItem();
            this.mnBCDT_DMSP = new System.Windows.Forms.ToolStripMenuItem();
            this.mnBCDT_SP = new System.Windows.Forms.ToolStripMenuItem();
            this.mnBCLN = new System.Windows.Forms.ToolStripMenuItem();
            this.mnBCLN_SP = new System.Windows.Forms.ToolStripMenuItem();
            this.mnBCLN_NGAY = new System.Windows.Forms.ToolStripMenuItem();
            this.mnBCTK = new System.Windows.Forms.ToolStripMenuItem();
            this.mnBCNHAP = new System.Windows.Forms.ToolStripMenuItem();
            this.mnTG = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.mnHDB_KH = new System.Windows.Forms.ToolStripMenuItem();
            this.Menuhethong.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Menuhethong
            // 
            this.Menuhethong.BackColor = System.Drawing.Color.Gainsboro;
            this.Menuhethong.Dock = System.Windows.Forms.DockStyle.Left;
            this.Menuhethong.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnHT,
            this.mnQL,
            this.mnTK,
            this.mnBC,
            this.mnTG});
            this.Menuhethong.Location = new System.Drawing.Point(0, 0);
            this.Menuhethong.Name = "Menuhethong";
            this.Menuhethong.Size = new System.Drawing.Size(98, 372);
            this.Menuhethong.TabIndex = 1;
            // 
            // mnHT
            // 
            this.mnHT.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnQLTK,
            this.mnQLCN,
            this.mnPhanQuyen});
            this.mnHT.Enabled = false;
            this.mnHT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnHT.Name = "mnHT";
            this.mnHT.Padding = new System.Windows.Forms.Padding(4, 50, 4, 0);
            this.mnHT.Size = new System.Drawing.Size(85, 69);
            this.mnHT.Text = "Hệ Thống";
            // 
            // mnQLTK
            // 
            this.mnQLTK.Enabled = false;
            this.mnQLTK.Name = "mnQLTK";
            this.mnQLTK.Padding = new System.Windows.Forms.Padding(0, 20, 0, 1);
            this.mnQLTK.Size = new System.Drawing.Size(166, 41);
            this.mnQLTK.Text = "QL Tài Khoản";
            this.mnQLTK.Click += new System.EventHandler(this.mnThemTK_Click);
            // 
            // mnQLCN
            // 
            this.mnQLCN.Enabled = false;
            this.mnQLCN.Name = "mnQLCN";
            this.mnQLCN.Padding = new System.Windows.Forms.Padding(0, 20, 0, 1);
            this.mnQLCN.Size = new System.Drawing.Size(166, 41);
            this.mnQLCN.Text = "QL Chức Năng";
            this.mnQLCN.Click += new System.EventHandler(this.mnQLCN_Click);
            // 
            // mnPhanQuyen
            // 
            this.mnPhanQuyen.Enabled = false;
            this.mnPhanQuyen.Name = "mnPhanQuyen";
            this.mnPhanQuyen.Padding = new System.Windows.Forms.Padding(0, 20, 0, 1);
            this.mnPhanQuyen.Size = new System.Drawing.Size(166, 41);
            this.mnPhanQuyen.Text = "Phân Quyền";
            this.mnPhanQuyen.Click += new System.EventHandler(this.mnPhanQuyen_Click);
            // 
            // mnQL
            // 
            this.mnQL.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnQLDM,
            this.mnQLChatlieu,
            this.mnQLSanPham,
            this.mnQLKhachhang,
            this.mnQLNhanvien,
            this.mnQLSize,
            this.mnQLMau,
            this.mnQLHoaDon,
            this.mnNCC,
            this.mnQLTONKHO});
            this.mnQL.Enabled = false;
            this.mnQL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnQL.Name = "mnQL";
            this.mnQL.Padding = new System.Windows.Forms.Padding(4, 50, 4, 0);
            this.mnQL.Size = new System.Drawing.Size(85, 69);
            this.mnQL.Text = "Quản Lý";
            // 
            // mnQLDM
            // 
            this.mnQLDM.Enabled = false;
            this.mnQLDM.Name = "mnQLDM";
            this.mnQLDM.Padding = new System.Windows.Forms.Padding(0, 10, 0, 1);
            this.mnQLDM.Size = new System.Drawing.Size(166, 31);
            this.mnQLDM.Text = "Danh Mục";
            this.mnQLDM.Click += new System.EventHandler(this.mnQLDM_Click);
            // 
            // mnQLChatlieu
            // 
            this.mnQLChatlieu.Enabled = false;
            this.mnQLChatlieu.Name = "mnQLChatlieu";
            this.mnQLChatlieu.Padding = new System.Windows.Forms.Padding(0, 10, 0, 1);
            this.mnQLChatlieu.Size = new System.Drawing.Size(166, 31);
            this.mnQLChatlieu.Text = "Chất Liệu";
            this.mnQLChatlieu.Click += new System.EventHandler(this.mnQLChatlieu_Click);
            // 
            // mnQLSanPham
            // 
            this.mnQLSanPham.Enabled = false;
            this.mnQLSanPham.Name = "mnQLSanPham";
            this.mnQLSanPham.Padding = new System.Windows.Forms.Padding(0, 10, 0, 1);
            this.mnQLSanPham.Size = new System.Drawing.Size(166, 31);
            this.mnQLSanPham.Text = "Sản Phẩm";
            this.mnQLSanPham.Click += new System.EventHandler(this.mnQLSanPham_Click);
            // 
            // mnQLKhachhang
            // 
            this.mnQLKhachhang.Enabled = false;
            this.mnQLKhachhang.Name = "mnQLKhachhang";
            this.mnQLKhachhang.Padding = new System.Windows.Forms.Padding(0, 10, 0, 1);
            this.mnQLKhachhang.Size = new System.Drawing.Size(166, 31);
            this.mnQLKhachhang.Text = "Khách Hàng";
            this.mnQLKhachhang.Click += new System.EventHandler(this.mnQLKhachhang_Click);
            // 
            // mnQLNhanvien
            // 
            this.mnQLNhanvien.Enabled = false;
            this.mnQLNhanvien.Name = "mnQLNhanvien";
            this.mnQLNhanvien.Padding = new System.Windows.Forms.Padding(0, 10, 0, 1);
            this.mnQLNhanvien.Size = new System.Drawing.Size(166, 31);
            this.mnQLNhanvien.Text = "Nhân Viên";
            this.mnQLNhanvien.Click += new System.EventHandler(this.mnQLNhanvien_Click);
            // 
            // mnQLSize
            // 
            this.mnQLSize.Enabled = false;
            this.mnQLSize.Name = "mnQLSize";
            this.mnQLSize.Padding = new System.Windows.Forms.Padding(0, 10, 0, 1);
            this.mnQLSize.Size = new System.Drawing.Size(166, 31);
            this.mnQLSize.Text = "Size";
            this.mnQLSize.Click += new System.EventHandler(this.mnQLSize_Click);
            // 
            // mnQLMau
            // 
            this.mnQLMau.Enabled = false;
            this.mnQLMau.Name = "mnQLMau";
            this.mnQLMau.Padding = new System.Windows.Forms.Padding(0, 10, 0, 1);
            this.mnQLMau.Size = new System.Drawing.Size(166, 31);
            this.mnQLMau.Text = "Màu";
            this.mnQLMau.Click += new System.EventHandler(this.mnQLMau_Click);
            // 
            // mnQLHoaDon
            // 
            this.mnQLHoaDon.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnHDB,
            this.mnHDN});
            this.mnQLHoaDon.Enabled = false;
            this.mnQLHoaDon.Name = "mnQLHoaDon";
            this.mnQLHoaDon.Padding = new System.Windows.Forms.Padding(0, 10, 0, 1);
            this.mnQLHoaDon.Size = new System.Drawing.Size(166, 31);
            this.mnQLHoaDon.Text = "Hóa Đơn";
            // 
            // mnHDB
            // 
            this.mnHDB.Name = "mnHDB";
            this.mnHDB.Size = new System.Drawing.Size(168, 22);
            this.mnHDB.Text = "Hóa Đơn Bán";
            this.mnHDB.Click += new System.EventHandler(this.mnHDB_Click);
            // 
            // mnHDN
            // 
            this.mnHDN.Name = "mnHDN";
            this.mnHDN.Size = new System.Drawing.Size(168, 22);
            this.mnHDN.Text = "Hóa Đơn Nhập";
            this.mnHDN.Click += new System.EventHandler(this.mnHDN_Click);
            // 
            // mnNCC
            // 
            this.mnNCC.Enabled = false;
            this.mnNCC.Name = "mnNCC";
            this.mnNCC.Padding = new System.Windows.Forms.Padding(0, 10, 0, 1);
            this.mnNCC.Size = new System.Drawing.Size(166, 31);
            this.mnNCC.Text = "Nhà Cung Cấp";
            this.mnNCC.Click += new System.EventHandler(this.mnNCC_Click);
            // 
            // mnQLTONKHO
            // 
            this.mnQLTONKHO.Enabled = false;
            this.mnQLTONKHO.Name = "mnQLTONKHO";
            this.mnQLTONKHO.Padding = new System.Windows.Forms.Padding(0, 10, 0, 1);
            this.mnQLTONKHO.Size = new System.Drawing.Size(166, 31);
            this.mnQLTONKHO.Text = "Tồn Kho";
            this.mnQLTONKHO.Click += new System.EventHandler(this.mnQLTONKHO_Click);
            // 
            // mnTK
            // 
            this.mnTK.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnTKKH,
            this.mnTKNCC,
            this.mnTKNV,
            this.mnTKHD,
            this.mnTKSP,
            this.mnTKCL,
            this.mnTKDM});
            this.mnTK.Enabled = false;
            this.mnTK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnTK.Name = "mnTK";
            this.mnTK.Padding = new System.Windows.Forms.Padding(4, 50, 4, 0);
            this.mnTK.Size = new System.Drawing.Size(85, 69);
            this.mnTK.Text = "Tìm Kiếm";
            // 
            // mnTKKH
            // 
            this.mnTKKH.Name = "mnTKKH";
            this.mnTKKH.Padding = new System.Windows.Forms.Padding(0, 20, 0, 1);
            this.mnTKKH.Size = new System.Drawing.Size(166, 41);
            this.mnTKKH.Text = "Khách Hàng";
            this.mnTKKH.Click += new System.EventHandler(this.mnTKKH_Click);
            // 
            // mnTKNCC
            // 
            this.mnTKNCC.Name = "mnTKNCC";
            this.mnTKNCC.Padding = new System.Windows.Forms.Padding(0, 20, 0, 1);
            this.mnTKNCC.Size = new System.Drawing.Size(166, 41);
            this.mnTKNCC.Text = "Nhà Cung Cấp";
            this.mnTKNCC.Click += new System.EventHandler(this.mnTKNCC_Click);
            // 
            // mnTKNV
            // 
            this.mnTKNV.Name = "mnTKNV";
            this.mnTKNV.Padding = new System.Windows.Forms.Padding(0, 20, 0, 1);
            this.mnTKNV.Size = new System.Drawing.Size(166, 41);
            this.mnTKNV.Text = "Nhân Viên";
            this.mnTKNV.Click += new System.EventHandler(this.mnTKNV_Click);
            // 
            // mnTKHD
            // 
            this.mnTKHD.Name = "mnTKHD";
            this.mnTKHD.Padding = new System.Windows.Forms.Padding(0, 20, 0, 1);
            this.mnTKHD.Size = new System.Drawing.Size(166, 41);
            this.mnTKHD.Text = "Hóa Đơn";
            this.mnTKHD.Click += new System.EventHandler(this.mnTKHD_Click);
            // 
            // mnTKSP
            // 
            this.mnTKSP.Name = "mnTKSP";
            this.mnTKSP.Padding = new System.Windows.Forms.Padding(0, 20, 0, 1);
            this.mnTKSP.Size = new System.Drawing.Size(166, 41);
            this.mnTKSP.Text = "Sản Phẩm";
            this.mnTKSP.Click += new System.EventHandler(this.mnTKSP_Click);
            // 
            // mnTKCL
            // 
            this.mnTKCL.Name = "mnTKCL";
            this.mnTKCL.Padding = new System.Windows.Forms.Padding(0, 20, 0, 1);
            this.mnTKCL.Size = new System.Drawing.Size(166, 41);
            this.mnTKCL.Text = "Chất Liệu";
            this.mnTKCL.Click += new System.EventHandler(this.mnTKCL_Click);
            // 
            // mnTKDM
            // 
            this.mnTKDM.Name = "mnTKDM";
            this.mnTKDM.Padding = new System.Windows.Forms.Padding(0, 20, 0, 1);
            this.mnTKDM.Size = new System.Drawing.Size(166, 41);
            this.mnTKDM.Text = "Danh Mục";
            this.mnTKDM.Click += new System.EventHandler(this.mnTKDM_Click);
            // 
            // mnBC
            // 
            this.mnBC.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnBCDT,
            this.mnBCLN,
            this.mnBCTK,
            this.mnBCNHAP,
            this.mnHDB_KH});
            this.mnBC.Enabled = false;
            this.mnBC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnBC.Name = "mnBC";
            this.mnBC.Padding = new System.Windows.Forms.Padding(4, 50, 4, 0);
            this.mnBC.Size = new System.Drawing.Size(85, 69);
            this.mnBC.Text = "Báo Cáo";
            // 
            // mnBCDT
            // 
            this.mnBCDT.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnBCDT_NGAY,
            this.mnBCDT_NV,
            this.mnBCDT_DMSP,
            this.mnBCDT_SP});
            this.mnBCDT.Name = "mnBCDT";
            this.mnBCDT.Padding = new System.Windows.Forms.Padding(0, 20, 0, 1);
            this.mnBCDT.Size = new System.Drawing.Size(159, 41);
            this.mnBCDT.Text = "Doanh Thu";
            // 
            // mnBCDT_NGAY
            // 
            this.mnBCDT_NGAY.Name = "mnBCDT_NGAY";
            this.mnBCDT_NGAY.Size = new System.Drawing.Size(240, 22);
            this.mnBCDT_NGAY.Text = "Theo ngày";
            this.mnBCDT_NGAY.Click += new System.EventHandler(this.mnBCDT_NGAY_Click);
            // 
            // mnBCDT_NV
            // 
            this.mnBCDT_NV.Name = "mnBCDT_NV";
            this.mnBCDT_NV.Size = new System.Drawing.Size(240, 22);
            this.mnBCDT_NV.Text = "Theo nhân viên";
            this.mnBCDT_NV.Click += new System.EventHandler(this.mnBCDT_NV_Click);
            // 
            // mnBCDT_DMSP
            // 
            this.mnBCDT_DMSP.Name = "mnBCDT_DMSP";
            this.mnBCDT_DMSP.Size = new System.Drawing.Size(240, 22);
            this.mnBCDT_DMSP.Text = "Theo danh mục sản phẩm";
            this.mnBCDT_DMSP.Click += new System.EventHandler(this.mnBCDT_DMSP_Click);
            // 
            // mnBCDT_SP
            // 
            this.mnBCDT_SP.Name = "mnBCDT_SP";
            this.mnBCDT_SP.Size = new System.Drawing.Size(240, 22);
            this.mnBCDT_SP.Text = "Theo sản phẩm";
            this.mnBCDT_SP.Click += new System.EventHandler(this.mnBCDT_SP_Click);
            // 
            // mnBCLN
            // 
            this.mnBCLN.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnBCLN_SP,
            this.mnBCLN_NGAY});
            this.mnBCLN.Name = "mnBCLN";
            this.mnBCLN.Padding = new System.Windows.Forms.Padding(0, 20, 0, 1);
            this.mnBCLN.Size = new System.Drawing.Size(159, 41);
            this.mnBCLN.Text = "Lợi Nhuận";
            // 
            // mnBCLN_SP
            // 
            this.mnBCLN_SP.Name = "mnBCLN_SP";
            this.mnBCLN_SP.Size = new System.Drawing.Size(173, 22);
            this.mnBCLN_SP.Text = "Theo sản phẩm";
            this.mnBCLN_SP.Click += new System.EventHandler(this.mnBCLN_SP_Click);
            // 
            // mnBCLN_NGAY
            // 
            this.mnBCLN_NGAY.Name = "mnBCLN_NGAY";
            this.mnBCLN_NGAY.Size = new System.Drawing.Size(173, 22);
            this.mnBCLN_NGAY.Text = "Theo Ngày";
            this.mnBCLN_NGAY.Click += new System.EventHandler(this.mnBCLN_NGAY_Click);
            // 
            // mnBCTK
            // 
            this.mnBCTK.Name = "mnBCTK";
            this.mnBCTK.Padding = new System.Windows.Forms.Padding(0, 20, 0, 1);
            this.mnBCTK.Size = new System.Drawing.Size(159, 41);
            this.mnBCTK.Text = "Tồn Kho";
            this.mnBCTK.Click += new System.EventHandler(this.mnBCTK_Click);
            // 
            // mnBCNHAP
            // 
            this.mnBCNHAP.Name = "mnBCNHAP";
            this.mnBCNHAP.Padding = new System.Windows.Forms.Padding(0, 20, 0, 1);
            this.mnBCNHAP.Size = new System.Drawing.Size(159, 41);
            this.mnBCNHAP.Text = "Nhập Hàng";
            this.mnBCNHAP.Click += new System.EventHandler(this.mnBCNHAP_Click);
            // 
            // mnTG
            // 
            this.mnTG.Enabled = false;
            this.mnTG.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnTG.Name = "mnTG";
            this.mnTG.Padding = new System.Windows.Forms.Padding(4, 50, 4, 0);
            this.mnTG.Size = new System.Drawing.Size(85, 69);
            this.mnTG.Text = "Trợ Giúp";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::QL_CUAHANG_THOITRANG.Properties.Resources._2148870794;
            this.pictureBox1.Location = new System.Drawing.Point(89, -81);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1500, 844);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // mnHDB_KH
            // 
            this.mnHDB_KH.Name = "mnHDB_KH";
            this.mnHDB_KH.Size = new System.Drawing.Size(159, 22);
            this.mnHDB_KH.Text = "Hóa Đơn Bán";
            this.mnHDB_KH.Click += new System.EventHandler(this.mnHDB_KH_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 372);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Menuhethong);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMain";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Menuhethong.ResumeLayout(false);
            this.Menuhethong.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip Menuhethong;
        private System.Windows.Forms.ToolStripMenuItem mnHT;
        private System.Windows.Forms.ToolStripMenuItem mnQLTK;
        private System.Windows.Forms.ToolStripMenuItem mnQL;
        private System.Windows.Forms.ToolStripMenuItem mnQLChatlieu;
        private System.Windows.Forms.ToolStripMenuItem mnQLSanPham;
        private System.Windows.Forms.ToolStripMenuItem mnQLKhachhang;
        private System.Windows.Forms.ToolStripMenuItem mnQLNhanvien;
        private System.Windows.Forms.ToolStripMenuItem mnQLHoaDon;
        private System.Windows.Forms.ToolStripMenuItem mnTK;
        private System.Windows.Forms.ToolStripMenuItem mnTKKH;
        private System.Windows.Forms.ToolStripMenuItem mnTKHD;
        private System.Windows.Forms.ToolStripMenuItem mnTKSP;
        private System.Windows.Forms.ToolStripMenuItem mnBC;
        private System.Windows.Forms.ToolStripMenuItem mnBCDT;
        private System.Windows.Forms.ToolStripMenuItem mnBCTK;
        private System.Windows.Forms.ToolStripMenuItem mnBCLN;
        private System.Windows.Forms.ToolStripMenuItem mnTG;
        private System.Windows.Forms.ToolStripMenuItem mnQLSize;
        private System.Windows.Forms.ToolStripMenuItem mnQLMau;
        private System.Windows.Forms.ToolStripMenuItem mnQLDM;
        private System.Windows.Forms.ToolStripMenuItem mnHDB;
        private System.Windows.Forms.ToolStripMenuItem mnHDN;
        private System.Windows.Forms.ToolStripMenuItem mnPhanQuyen;
        private System.Windows.Forms.ToolStripMenuItem mnQLCN;
        private System.Windows.Forms.ToolStripMenuItem mnNCC;
        private System.Windows.Forms.ToolStripMenuItem mnBCNHAP;
        private System.Windows.Forms.ToolStripMenuItem mnQLTONKHO;
        private System.Windows.Forms.ToolStripMenuItem mnTKNCC;
        private System.Windows.Forms.ToolStripMenuItem mnTKNV;
        private System.Windows.Forms.ToolStripMenuItem mnTKCL;
        private System.Windows.Forms.ToolStripMenuItem mnTKDM;
        private System.Windows.Forms.ToolStripMenuItem mnBCDT_NGAY;
        private System.Windows.Forms.ToolStripMenuItem mnBCDT_NV;
        private System.Windows.Forms.ToolStripMenuItem mnBCDT_DMSP;
        private System.Windows.Forms.ToolStripMenuItem mnBCDT_SP;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem mnBCLN_SP;
        private System.Windows.Forms.ToolStripMenuItem mnBCLN_NGAY;
        private System.Windows.Forms.ToolStripMenuItem mnHDB_KH;
    }
}