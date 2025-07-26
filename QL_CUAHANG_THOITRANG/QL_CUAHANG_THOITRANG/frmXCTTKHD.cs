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
    public partial class frmXCTTKHD : Form
    {
        public frmXCTTKHD()
        {
            InitializeComponent();
        }

        public string MaHDN { get; set; }
        public string MaHDB { get; set; }

        public bool tkHDN = false;
        public bool tkHDB = false;

        private void frmXCTTKHD_Load(object sender, EventArgs e)
        {
            HamXuLy.connect();

            pnlHDN.Enabled = false;
            showHD();
            string SqlFillCombo1 = "Select * From SANPHAM";
            string SqlFillCombo2 = "Select * From SIZE";
            string SqlFillCombo3 = "Select * From MAU";
            string SqlFillCombo4 = "Select * From HOADONNHAP";
            HamXuLy.FillCombo(SqlFillCombo1, cmbSP, "IDSP", "TENSP");
            HamXuLy.FillCombo(SqlFillCombo2, cmbSIZE, "IDSIZE", "TENSIZE");
            HamXuLy.FillCombo(SqlFillCombo3, cmbMAU, "IDMAU", "TENMAU");
            HamXuLy.FillCombo(SqlFillCombo4, cmbHD, "IDHDN", "IDHDN");

            //======================================

            if (txtDONGIA.Text == "" || txtDONGIA.Text == null)
            {
                string sqlTV1 = "Select DGNHAP From SANPHAM Where TENSP = '" + cmbSP.Text + "'";
                txtDONGIA.Text = HamXuLy.GetFieldValues(sqlTV1);
            }

            //======================================

            if (string.IsNullOrEmpty(MaHDB))
            {
                lblKH.Visible = false;
                txtKH.Visible = false;
            }
            else
            {
                lblNCC.Visible = false;
                txtNCC.Visible = false;
            }

            //======================================

            if (!string.IsNullOrEmpty(MaHDN))
            {
                string sql = "SELECT IDHDN FROM HOADONNHAP WHERE IDHDN = '" + MaHDN + "'";
                HamXuLy.FillCombo(sql, cmbHD, "IDHDN", "IDHDN");
                showHD();
            }
            else if (!string.IsNullOrEmpty(MaHDB))
            {
                string sql = "SELECT IDHDN FROM HOADONNHAP WHERE IDHDN = '" + MaHDB + "'";
                HamXuLy.FillCombo(sql, cmbHD, "IDHDN", "IDHDN");
                showHD();
            }
            else
            {
                MessageBox.Show("Không có mã hóa đơn được chọn.", "Thông báo");
            }

        }

        public void LoadDataFromTK(DataTable dt)
        {
            luoiHD.DataSource = dt;
            if (!string.IsNullOrEmpty(MaHDB))
            {
                tkHDB = true;
            }
            else
            {
                tkHDN = true;
            }
        }

        private void showHD()
        {
            DataTable dt = new DataTable();
            HamXuLy.connect();
            dt.Clear();

            string sql = "";

            if (!string.IsNullOrEmpty(MaHDB))
            {
                sql = "SELECT * FROM CHITIETHDB WHERE IDHDB = '" + MaHDB + "'";
            }
            else if (!string.IsNullOrEmpty(MaHDN))
            {
                sql = "SELECT * FROM CHITIETHDN WHERE IDHDN = '" + MaHDN + "'";
            }

            if (!string.IsNullOrEmpty(sql) && HamXuLy.TruyVan(sql, dt))
            {
                luoiHD.DataSource = dt;

                // Trang trí lưới
                luoiHD.Columns[0].HeaderText = "ID CHI TIẾT";
                luoiHD.Columns[0].Width = 100;
                luoiHD.Columns[1].HeaderText = "HÓA ĐƠN";
                luoiHD.Columns[1].Width = 100;
                luoiHD.Columns[2].HeaderText = "SẢN PHẨM";
                luoiHD.Columns[2].Width = 100;
                luoiHD.Columns[3].HeaderText = "SL";
                luoiHD.Columns[3].Width = 70;
                luoiHD.Columns[4].HeaderText = "SIZE";
                luoiHD.Columns[4].Width = 70;
                luoiHD.Columns[5].HeaderText = "MAU";
                luoiHD.Columns[5].Width = 70;
                luoiHD.Columns[6].HeaderText = "ĐƠN GIÁ";
                luoiHD.Columns[6].Width = 100;

                luoiHD.EnableHeadersVisualStyles = false;
                luoiHD.ColumnHeadersDefaultCellStyle.BackColor = Color.Cyan;
            }
        }

        private void luoiHD_Click(object sender, EventArgs e)
        {
            string idHD = luoiHD.Columns[1].Name;

            txtSL.Text = luoiHD.CurrentRow.Cells["SOLUONG"].Value.ToString();
            txtDONGIA.Text = luoiHD.CurrentRow.Cells["DONGIA"].Value.ToString();
            //Xử lý cho combobox
            String MAHD, MASP, MASZ, MAMAU, sql1, sql2, sql3, sql4;
            //Combo HDB
            HamXuLy.connect();
            //Combo SP
            MASP = luoiHD.CurrentRow.Cells["IDSP"].Value.ToString();
            sql2 = "Select TENSP From SANPHAM where IDSP ='" + MASP + "'";
            cmbSP.Text = HamXuLy.GetFieldValues(sql2);
            //Combo SIZE
            MASZ = luoiHD.CurrentRow.Cells["IDSIZE"].Value.ToString();
            sql3 = "Select TENSIZE From SIZE where IDSIZE ='" + MASZ + "'";
            cmbSIZE.Text = HamXuLy.GetFieldValues(sql3);
            //Combo MAU
            MAMAU = luoiHD.CurrentRow.Cells["IDMAU"].Value.ToString();
            sql4 = "Select TENMAU From MAU where IDMAU ='" + MAMAU + "'";
            cmbMAU.Text = HamXuLy.GetFieldValues(sql4);
            //Hóa đơn bán
            if (idHD == "IDHDB")
            {
            txtIDCT.Text = luoiHD.CurrentRow.Cells["IDCTHDB"].Value.ToString();
            //=====================
            MAHD = luoiHD.CurrentRow.Cells["IDHDB"].Value.ToString();
            sql1 = "Select IDHDB From HOADONBAN where IDHDB ='" + MAHD + "'";
            cmbHD.Text = HamXuLy.GetFieldValues(sql1);
            //=====================
            string sqlKH =
                "SELECT KH.HOTEN " +
                "FROM HOADONBAN HDB " +
                "JOIN KHACHHANG KH ON HDB.IDKH = KH.IDKH " +
                "WHERE HDB.IDHDB = '" + cmbHD.Text + "'";
            txtKH.Text = HamXuLy.GetFieldValues(sqlKH);
            }
            //Hóa đơn nhập
            else if (idHD == "IDHDN")
            {
            txtIDCT.Text = luoiHD.CurrentRow.Cells["IDCTHDN"].Value.ToString();
            //=====================
            MAHD = luoiHD.CurrentRow.Cells["IDHDN"].Value.ToString();
            sql1 = "Select IDHDN From HOADONNHAP where IDHDN ='" + MAHD + "'";
            cmbHD.Text = HamXuLy.GetFieldValues(sql1);
            //=====================
            string sqlNCC =
                "SELECT NCC.TENNCC " +
                "FROM HOADONNHAP HDN " +
                "JOIN NHACUNGCAP NCC ON HDN.IDNCC = NCC.IDNCC " +
                "WHERE HDN.IDHDN = '" + cmbHD.Text + "'";
            txtNCC.Text = HamXuLy.GetFieldValues(sqlNCC);
            }
        }

    }
}
