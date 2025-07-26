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
    public partial class frmTHEMCTHDN : Form
    {
        public int tam = 0;
        public frmTHEMCTHDN()
        {
            InitializeComponent();
        }
        private void showTHEMCTHDB()
        {
            DataTable dtTHDN = new DataTable();
            HamXuLy.connect();
            dtTHDN.Clear();
            String sqlTHDN = "select * From CHITIETHDN";
            if (HamXuLy.TruyVan(sqlTHDN, dtTHDN))
            {
                luoiTHEMCTHDN.DataSource = dtTHDN;
                //Trang trí lưới
                luoiTHEMCTHDN.Columns[0].HeaderText = "ID CHI TIẾT";
                luoiTHEMCTHDN.Columns[0].Width = 100;
                luoiTHEMCTHDN.Columns[1].HeaderText = "HÓA ĐƠN";
                luoiTHEMCTHDN.Columns[1].Width = 100;
                luoiTHEMCTHDN.Columns[2].HeaderText = "SẢN PHẨM";
                luoiTHEMCTHDN.Columns[2].Width = 100;
                luoiTHEMCTHDN.Columns[3].HeaderText = "SL";
                luoiTHEMCTHDN.Columns[3].Width = 70;
                luoiTHEMCTHDN.Columns[4].HeaderText = "SIZE";
                luoiTHEMCTHDN.Columns[4].Width = 70;
                luoiTHEMCTHDN.Columns[5].HeaderText = "MAU";
                luoiTHEMCTHDN.Columns[5].Width = 70;
                luoiTHEMCTHDN.Columns[6].HeaderText = "ĐƠN GIÁ";
                luoiTHEMCTHDN.Columns[6].Width = 100;
                luoiTHEMCTHDN.EnableHeadersVisualStyles = false;
                luoiTHEMCTHDN.ColumnHeadersDefaultCellStyle.BackColor = Color.Cyan;
            }
        }
        private void cmbSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSP.SelectedValue != null)
            {
                string mahang = cmbSP.SelectedValue.ToString();
                string sqlDG = "SELECT DGNHAP FROM SANPHAM WHERE IDSP = '" + mahang + "'";
                string dongia = HamXuLy.GetFieldValues(sqlDG);
                txtDONGIA.Text = dongia;

            }
        }

        private void btnLUU_Click(object sender, EventArgs e)
        {
            if (cmbSP.Text == "")
            {
                MessageBox.Show("Không được để trống Sản phẩm", "Thông báo");
                cmbSP.Focus();
            }
            else if (txtSL.Text == "")
            {
                txtSL.Text = "1";
            }
            else if (cmbSIZE.Text == "")
            {
                MessageBox.Show("Không được để trống Size", "Thông báo");
                cmbSIZE.Focus();
            }
            else if (cmbMAU.Text == "")
            {
                MessageBox.Show("Không được để trống Màu", "Thông báo");
                cmbMAU.Focus();
            }
            else
            {
                try
                {
                    HamXuLy.connect();
                    string maHDN = txtHDN.Text.Trim();
                    string maSP = cmbSP.SelectedValue.ToString();

                    if (HamXuLy.ExistsChiTietHDN(maHDN, maSP))
                    {
                        string sltxt = "";
                        DataTable dtCT = new DataTable();
                        string sqlSL = "Select SOLUONG From CHITIETHDN Where IDHDN = '" + txtHDN.Text + "' AND IDSP = '" + cmbSP.SelectedValue.ToString() + "'";
                        if (HamXuLy.TruyVan(sqlSL, dtCT) && dtCT.Rows.Count > 0)
                        {
                            DataRow row = dtCT.Rows[0];
                            sltxt = row["SOLUONG"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy chi tiết để cập nhật.", "Thông báo");
                            return;
                        }

                        int currentQty;
                        if (!int.TryParse(sltxt, out currentQty))
                        {
                            MessageBox.Show("Dữ liệu SOLUONG hiện tại không hợp lệ.", "Thông báo");
                            return;
                        }
                        int addQty;
                        if (!int.TryParse(txtSL.Text.Trim(), out addQty))
                        {
                            MessageBox.Show("Số lượng nhập không hợp lệ.", "Thông báo");
                            return;
                        }

                        int updatedQty = currentQty + addQty;
                        sltxt = updatedQty.ToString();

                        string sqlSua = "UPDATE CHITIETHDN SET " +
                        "SOLUONG = '" + sltxt + "' " +
                        "WHERE IDHDN = '" + txtHDN.Text + "' AND IDSP = '" + cmbSP.SelectedValue.ToString() + "'";

                        HamXuLy.RunSQL(sqlSua);
                        MessageBox.Show("Đã Cập nhật số lượng SP cho CTHDB có Mã: " + txtHDN.Text);
                        showTHEMCTHDB();
                        return;
                    }
                    string sqlThem = "INSERT CHITIETHDN (IDCTHDN, IDHDN, IDSP, SOLUONG, IDSIZE, IDMAU, DONGIA) VALUES ('" + txtIDCT.Text + "', '" + txtHDN.Text + "', '" + cmbSP.SelectedValue.ToString() + "', '" + txtSL.Text + "', '" + cmbSIZE.SelectedValue.ToString() + "', '" + cmbMAU.SelectedValue.ToString() + "', '" + txtDONGIA.Text + "')";
                    HamXuLy.RunSQL(sqlThem);
                    MessageBox.Show("Thêm Thành Công");
                    showTHEMCTHDB();
                    HamXuLy.disconnect();
                    txtIDCT.Text = HamXuLy.TaoIDMoi("CHITIETHDN", "IDCTHDN", "CTHDN");
                    txtSL.Text = "1";
                    tam++;
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnEND_Click(object sender, EventArgs e)
        {
            if (tam == 0)
            {
                MessageBox.Show("Phải có ít nhất 1 Chi Tiết hóa đơn được lưu !");
                cmbSP.Focus();
            }
            else
            {
                try
                {
                    HamXuLy.connect();

                    // Tạo câu lệnh SQL để truy xuất các chi tiết hóa đơn theo mã hóa đơn hiện tại
                    string sql = string.Format("SELECT SOLUONG, DONGIA FROM CHITIETHDN WHERE IDHDN = '{0}'", HamXuLy.mahdban);

                    DataTable dtChiTiet = new DataTable();

                    // Thực hiện truy vấn
                    if (HamXuLy.TruyVan(sql, dtChiTiet))
                    {
                        double tong = 0;

                        // Duyệt qua từng dòng dữ liệu để tính tổng tiền
                        foreach (DataRow row in dtChiTiet.Rows)
                        {
                            int soLuong = Convert.ToInt32(row["SOLUONG"]);
                            double donGia = Convert.ToDouble(row["DONGIA"]);

                            tong += soLuong * donGia;
                        }
                        
                        // Lưu tổng tiền vào biến tĩnh
                        HamXuLy.tongtien = tong;
                        string sqlSua = "UPDATE HOADONNHAP SET " +
                        "TONGTIEN = '" + HamXuLy.tongtien + "' " +
                        "WHERE IDHDN = '" + HamXuLy.mahdban + "'";

                        HamXuLy.RunSQL(sqlSua);

                        MessageBox.Show("Đã cập nhật lại tổng tiền cho Hóa đơn có mã: " + txtHDN.Text);
                        MessageBox.Show("Tổng tiền hóa đơn là: " + HamXuLy.tongtien.ToString("N0") + " VNĐ", "Thông báo");
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy chi tiết hóa đơn!", "Thông báo");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi");
                }
                finally
                {
                    HamXuLy.disconnect();
                    this.Close();
                }
            }
        }

        private void frmTHEMCTHDN_Load(object sender, EventArgs e)
        {
            txtHDN.Text = HamXuLy.mahdban;
            txtIDCT.Text = HamXuLy.TaoIDMoi("CHITIETHDN", "IDCTHDN", "CTHDN");
            txtSL.Text = "1";
            txtHDN.Enabled = false;
            txtIDCT.Enabled = false;
            txtDONGIA.Enabled = false;
            showTHEMCTHDB();
            string SqlFillCombo1 = "Select * From SANPHAM";
            string SqlFillCombo2 = "Select * From SIZE";
            string SqlFillCombo3 = "Select * From MAU";
            HamXuLy.FillCombo(SqlFillCombo1, cmbSP, "IDSP", "TENSP");
            HamXuLy.FillCombo(SqlFillCombo2, cmbSIZE, "IDSIZE", "TENSIZE");
            HamXuLy.FillCombo(SqlFillCombo3, cmbMAU, "IDMAU", "TENMAU");
            cmbSP.SelectedIndexChanged += cmbSP_SelectedIndexChanged;
            if (txtDONGIA.Text == "" || txtDONGIA.Text == null)
            {
                string sqlTV1 = "Select DGNHAP From SANPHAM Where TENSP = '" + cmbSP.Text + "'";
                txtDONGIA.Text = HamXuLy.GetFieldValues(sqlTV1);
            }
        }
    }
}
