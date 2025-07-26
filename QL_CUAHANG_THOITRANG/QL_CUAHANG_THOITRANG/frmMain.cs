using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_CUAHANG_THOITRANG
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        //Menu chính
        public ToolStripMenuItem _mnHethong
        {
            get { return mnHT; }
            set { mnHT = value; }
        }
        public ToolStripMenuItem _mnQuanly
        {
            get { return mnQL; }
            set { mnQL = value; }
        }
        public ToolStripMenuItem _mnTimkiem
        {
            get { return mnTK; }
            set { mnTK = value; }
        }
        public ToolStripMenuItem _mnBaocao
        {
            get { return mnBC; }
            set { mnBC = value; }
        }
        public ToolStripMenuItem _mnTrogiup
        {
            get { return mnTG; }
            set { mnTG = value; }
        }
        //Menu Con
        //Menu Hệ thống
        public ToolStripMenuItem _mnQLTK
        {
            get { return mnQLTK; }
            set { mnQLTK = value; }
        }
        public ToolStripMenuItem _mnQLCN
        {
            get { return mnQLCN; }
            set { mnQLCN = value; }
        }
        public ToolStripMenuItem _mnPhanQuyen
        {
            get { return mnPhanQuyen; }
            set { mnPhanQuyen = value; }
        }
        //Menu Quản lý
        public ToolStripMenuItem _mnQLDM
        {
            get { return mnQLDM; }
            set { mnQLDM = value; }
        }
        public ToolStripMenuItem _mnQLCL
        {
            get { return mnQLChatlieu; }
            set { mnQLChatlieu = value; }
        }
        public ToolStripMenuItem _mnQLSP
        {
            get { return mnQLSanPham; }
            set { mnQLSanPham = value; }
        }
        public ToolStripMenuItem _mnQLNV
        {
            get { return mnQLNhanvien; }
            set { mnQLNhanvien = value; }
        }
        public ToolStripMenuItem _mnQLKH
        {
            get { return mnQLKhachhang; }
            set { mnQLKhachhang = value; }
        }
        public ToolStripMenuItem _mnQLHD
        {
            get { return mnQLHoaDon; }
            set { mnQLHoaDon = value; }
        }
        public ToolStripMenuItem _mnQLSize
        {
            get { return mnQLSize; }
            set { mnQLSize = value; }
        }
        public ToolStripMenuItem _mnQLMau
        {
            get { return mnQLMau; }
            set { mnQLMau = value; }
        }
        public ToolStripMenuItem _mnQLNCC
        {
            get { return mnNCC; }
            set { mnNCC = value; }
        }
        public ToolStripMenuItem _mnQLTONKHO
        {
            get { return mnQLTONKHO; }
            set { mnQLTONKHO = value; }
        }
        //Menu Tìm kiếm
        //TK Đối TƯợng
        public ToolStripMenuItem _mnTKKH
        {
            get { return mnTKKH; }
            set { mnTKKH = value; }
        }
        public ToolStripMenuItem _mnTKNCC
        {
            get { return mnTKNCC; }
            set { mnTKNCC = value; }
        }
        public ToolStripMenuItem _mnTKNV
        {
            get { return mnTKNV; }
            set { mnTKNV = value; }
        }
        //Tìm Kiếm hóa đơn
        public ToolStripMenuItem _mnTKHD
        {
            get { return mnTKHD; }
            set { mnTKHD = value; }
        }
        //Tìm kiếm Sp
        public ToolStripMenuItem _mnTKCL
        {
            get { return mnTKCL; }
            set { mnTKCL = value; }
        }
        public ToolStripMenuItem _mnTKSP
        {
            get { return mnTKSP; }
            set { mnTKSP = value; }
        }
        public ToolStripMenuItem _mnTKDM
        {
            get { return mnTKDM; }
            set { mnTKDM = value; }
        }
        //Menu Báo cáo
        public ToolStripMenuItem _mnBCDoanhThu
        {
            get { return mnBCDT; }
            set { mnBCDT = value; }
        }
        public ToolStripMenuItem _mnBCTonKho
        {
            get { return mnBCTK; }
            set { mnBCTK = value; }
        }
        public ToolStripMenuItem _mnBCLoiN
        {
            get { return mnBCLN; }
            set { mnBCLN = value; }
        }
        public ToolStripMenuItem _mnBCNhap
        {
            get { return mnBCNHAP; }
            set { mnBCNHAP = value; }
        }
        //Click
        private void mnQLChatlieu_Click(object sender, EventArgs e)
        {
            frmCHATLIEU frmCL = new frmCHATLIEU();
            frmCL.Show();
        }

        private void mnQLSanPham_Click(object sender, EventArgs e)
        {
            frmSANPHAM frmSP = new frmSANPHAM();
            frmSP.Show();
        }

        private void mnQLKhachhang_Click(object sender, EventArgs e)
        {
            frmKHACHHANG frmKH = new frmKHACHHANG();
            frmKH.Show();
        }

        private void mnQLNhanvien_Click(object sender, EventArgs e)
        {
            frmNHANVIEN frmNV = new frmNHANVIEN();
            frmNV.Show();
        }

        private void mnQLSize_Click(object sender, EventArgs e)
        {
            frmSIZE frmSZ = new frmSIZE();
            frmSZ.Show();
        }

        private void mnQLMau_Click(object sender, EventArgs e)
        {
            frmMAU frmMAU = new frmMAU();
            frmMAU.Show();
        }

        private void mnQLDM_Click(object sender, EventArgs e)
        {
            frmDANHMUCSP frmDM = new frmDANHMUCSP();
            frmDM.Show();
        }

        private void mnHDB_Click(object sender, EventArgs e)
        {
            frmHOADONBAN frmHDB = new frmHOADONBAN();
            frmHDB.Show();
        }

        private void mnThemTK_Click(object sender, EventArgs e)
        {
            frmTAIKHOAN frmTAIK = new frmTAIKHOAN();
            frmTAIK.Show();
        }

        private void mnPhanQuyen_Click(object sender, EventArgs e)
        {
            frmPHANQUYEN frmPQ = new frmPHANQUYEN();
            frmPQ.Show();
        }

        private void mnQLCN_Click(object sender, EventArgs e)
        {
            frmChucNang frmCN = new frmChucNang();
            frmCN.Show();
        }

        private void mnHDN_Click(object sender, EventArgs e)
        {
            frmHOADONNHAP frmHDN = new frmHOADONNHAP();
            frmHDN.Show();
        }

        private void mnNCC_Click(object sender, EventArgs e)
        {
            frmNCC fNCC = new frmNCC();
            fNCC.Show();
        }

        private void mnQLTONKHO_Click(object sender, EventArgs e)
        {
            frmTonKho frmTON = new frmTonKho();
            frmTON.Show();
        }
        private void mnTKKH_Click(object sender, EventArgs e)
        {
            frmTKDoiTuong frmTKKH = new frmTKDoiTuong();
            frmTKKH.Show();
        }
        private void mnTKNCC_Click(object sender, EventArgs e)
        {
            frmTKDoiTuong frmTKNCC = new frmTKDoiTuong();
            frmTKNCC.Show();
        }

        private void mnTKNV_Click(object sender, EventArgs e)
        {
            frmTKDoiTuong frmTKNV = new frmTKDoiTuong();
            frmTKNV.Show();
        }

        private void mnTKSP_Click(object sender, EventArgs e)
        {
            frmTKSP fTKSP = new frmTKSP();
            fTKSP.Show();
        }

        private void mnTKCL_Click(object sender, EventArgs e)
        {
            frmTKSP fTKCL = new frmTKSP();
            fTKCL.Show();
        }

        private void mnTKDM_Click(object sender, EventArgs e)
        {
            frmTKSP fTKDM = new frmTKSP();
            fTKDM.Show();
        }

        private void mnTKHD_Click(object sender, EventArgs e)
        {
            frmTKHD fTKHD = new frmTKHD();
            fTKHD.Show();
        }

        private void mnBCDT_NGAY_Click(object sender, EventArgs e)
        {
            frmRPT_DOANHTHU_NGAY RPTNGAY = new frmRPT_DOANHTHU_NGAY();
            RPTNGAY.Show();
        }

        private void mnBCDT_NV_Click(object sender, EventArgs e)
        {
            frmRPT_DOANHTHU_THEONV RPTNV = new frmRPT_DOANHTHU_THEONV();
            RPTNV.Show();
        }

        private void mnBCDT_DMSP_Click(object sender, EventArgs e)
        {
            frmRPT_DOANHTHU_THEODM RPTDM = new frmRPT_DOANHTHU_THEODM();
            RPTDM.Show();
        }

        private void mnBCDT_SP_Click(object sender, EventArgs e)
        {
            frmRPT_DOANHTHU_THEOSP RPTSP = new frmRPT_DOANHTHU_THEOSP();
            RPTSP.Show();
        }

        private void mnBCLN_SP_Click(object sender, EventArgs e)
        {
            frmRPT_LOINHUAN_SP LNSP = new frmRPT_LOINHUAN_SP();
            LNSP.Show();
        }

        private void mnBCLN_NGAY_Click(object sender, EventArgs e)
        {
            frmRPT_LOINHUAN_NGAY LNNGAY = new frmRPT_LOINHUAN_NGAY();
            LNNGAY.Show();
        }

        private void mnBCNHAP_Click(object sender, EventArgs e)
        {
            frmRPT_NHAPHANG NHAP = new frmRPT_NHAPHANG();
            NHAP.Show();
        }

        private void mnBCTK_Click(object sender, EventArgs e)
        {
            frmRPT_TONKHO TONKHO = new frmRPT_TONKHO();
            TONKHO.Show();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void mnHDB_KH_Click(object sender, EventArgs e)
        {
            frmRPT_HOADONBAN_KH HDB = new frmRPT_HOADONBAN_KH();
            HDB.Show();
        }
   
        
    }
}
