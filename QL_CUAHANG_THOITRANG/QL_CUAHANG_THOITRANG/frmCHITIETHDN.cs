using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QL_CUAHANG_THOITRANG
{
    public partial class frmCHITIETHDN : Form
    {
        public frmCHITIETHDN()
        {
            InitializeComponent();
        }
        String sqlHDN;
        private void showCTHDB()
        {
            DataTable dtHDN = new DataTable();
            HamXuLy.connect();
            dtHDN.Clear();
            
            if (HamXuLy.MAHD == "")
            {
                sqlHDN = "select * From CHITIETHDN";
            }
            else
            {
                sqlHDN = "select * From CHITIETHDN Where IDHDN = '" + HamXuLy.MAHD + "'";
            }
            if (HamXuLy.TruyVan(sqlHDN, dtHDN))
            {
                luoiHDN.DataSource = dtHDN;
                //Trang trí lưới
                luoiHDN.Columns[0].HeaderText = "ID CHI TIẾT";
                luoiHDN.Columns[0].Width = 100;
                luoiHDN.Columns[1].HeaderText = "HÓA ĐƠN";
                luoiHDN.Columns[1].Width = 100;
                luoiHDN.Columns[2].HeaderText = "SẢN PHẨM";
                luoiHDN.Columns[2].Width = 100;
                luoiHDN.Columns[3].HeaderText = "SL";
                luoiHDN.Columns[3].Width = 70;
                luoiHDN.Columns[4].HeaderText = "SIZE";
                luoiHDN.Columns[4].Width = 70;
                luoiHDN.Columns[5].HeaderText = "MAU";
                luoiHDN.Columns[5].Width = 70;
                luoiHDN.Columns[6].HeaderText = "ĐƠN GIÁ";
                luoiHDN.Columns[6].Width = 100;
                luoiHDN.EnableHeadersVisualStyles = false;
                luoiHDN.ColumnHeadersDefaultCellStyle.BackColor = Color.Cyan;
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
        private void frmCHITIETHDN_Load(object sender, EventArgs e)
        {
            pnlHDN.Enabled = false;
            txtTIMKIEM.Text = "Nhập tên Nhà cung cấp";
            showCTHDB();
            string SqlFillCombo1 = "Select * From SANPHAM";
            string SqlFillCombo2 = "Select * From SIZE";
            string SqlFillCombo3 = "Select * From MAU";
            string SqlFillCombo4 = "Select * From HOADONNHAP";
            HamXuLy.FillCombo(SqlFillCombo1, cmbSP, "IDSP", "TENSP");
            HamXuLy.FillCombo(SqlFillCombo2, cmbSIZE, "IDSIZE", "TENSIZE");
            HamXuLy.FillCombo(SqlFillCombo3, cmbMAU, "IDMAU", "TENMAU");
            HamXuLy.FillCombo(SqlFillCombo4, cmbHDN, "IDHDN", "IDHDN");
            cmbSP.SelectedIndexChanged += cmbSP_SelectedIndexChanged;
            if (txtDONGIA.Text == "" || txtDONGIA.Text == null)
            {
                string sqlTV1 = "Select DGNHAP From SANPHAM Where TENSP = '" + cmbSP.Text + "'";
                txtDONGIA.Text = HamXuLy.GetFieldValues(sqlTV1);
            }
        }
        private void HUY()
        {
            pnlHDN.Enabled = false;
            txtIDCT.ResetText();
            txtSL.Text = "1";
            btnTHEM.Enabled = true;
            btnXOA.Enabled = true;
            btnSUA.Enabled = true;
        }
        private void tinhtong()
        {
            try
            {
                // Tạo câu lệnh SQL để truy xuất các chi tiết hóa đơn theo mã hóa đơn hiện tại
                string sqlTrV1 = string.Format("SELECT SOLUONG, DONGIA FROM CHITIETHDN WHERE IDHDN = '{0}'", cmbHDN.Text);

                DataTable dtCT = new DataTable();

                // Thực hiện truy vấn
                if (HamXuLy.TruyVan(sqlTrV1, dtCT))
                {
                    double tong = 0;

                    // Duyệt qua từng dòng dữ liệu để tính tổng tiền
                    foreach (DataRow row in dtCT.Rows)
                    {
                        int soLuong = Convert.ToInt32(row["SOLUONG"]);
                        double donGia = Convert.ToDouble(row["DONGIA"]);

                        tong += soLuong * donGia;
                    }
                    string sqlGG = "Select GIAMGIA From HOADONBAN Where IDHDB = '" + cmbHDN.Text + "'";
                    DataTable dtGG = new DataTable();

                    // Thực hiện truy vấn
                    if (HamXuLy.TruyVan(sqlGG, dtGG))
                    {
                        foreach (DataRow row in dtGG.Rows)
                        {
                            HamXuLy.giamgia = Convert.ToInt32(row["GIAMGIA"]);

                        }
                    }
                    
                    // Lưu tổng tiền vào biến tĩnh
                    HamXuLy.tongtien = tong;
                    string sqlSua = "UPDATE HOADONNHAP SET " +
                    "TONGTIEN = '" + HamXuLy.tongtien + "' " +
                    "WHERE IDHDN = '" + cmbHDN.Text + "'";

                    HamXuLy.RunSQL(sqlSua);

                    MessageBox.Show("Đã cập nhật lại tổng tiền cho Hóa đơn có mã: " + cmbHDN.SelectedValue.ToString());
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

            }
        }
        private void btnHUY_Click(object sender, EventArgs e)
        {
            HUY();
        }

        private void luoiHDN_Click(object sender, EventArgs e)
        {
            txtIDCT.Text = luoiHDN.CurrentRow.Cells["IDCTHDN"].Value.ToString();
            txtSL.Text = luoiHDN.CurrentRow.Cells["SOLUONG"].Value.ToString();
            txtDONGIA.Text = luoiHDN.CurrentRow.Cells["DONGIA"].Value.ToString();
            //Xử lý cho combobox
            String MAHD, MASP, MASZ, MAMAU, sql1, sql2, sql3, sql4;
            //Combo HDB
            HamXuLy.connect();
            MAHD = luoiHDN.CurrentRow.Cells["IDHDN"].Value.ToString();
            sql1 = "Select IDHDN From HOADONNHAP where IDHDN ='" + MAHD + "'";
            cmbHDN.Text = HamXuLy.GetFieldValues(sql1);
            //Combo SP
            MASP = luoiHDN.CurrentRow.Cells["IDSP"].Value.ToString();
            sql2 = "Select TENSP From SANPHAM where IDSP ='" + MASP + "'";
            cmbSP.Text = HamXuLy.GetFieldValues(sql2);
            //Combo SIZE
            MASZ = luoiHDN.CurrentRow.Cells["IDSIZE"].Value.ToString();
            sql3 = "Select TENSIZE From SIZE where IDSIZE ='" + MASZ + "'";
            cmbSIZE.Text = HamXuLy.GetFieldValues(sql3);
            //Combo MAU
            MAMAU = luoiHDN.CurrentRow.Cells["IDMAU"].Value.ToString();
            sql4 = "Select TENMAU From MAU where IDMAU ='" + MAMAU + "'";
            cmbMAU.Text = HamXuLy.GetFieldValues(sql4);

            string sqlNCC =
                "SELECT NCC.TENNCC " +
                "FROM HOADONNHAP HDN " +
                "JOIN NHACUNGCAP NCC ON HDN.IDNCC = NCC.IDNCC " +
                "WHERE HDN.IDHDN = '" + cmbHDN.Text + "'";
            txtNCC.Text = HamXuLy.GetFieldValues(sqlNCC);
        }

        private void btnTHEM_Click(object sender, EventArgs e)
        {
            pnlHDN.Enabled = true;
            txtIDCT.Enabled = false;
            cmbHDN.Enabled = true;
            txtDONGIA.Enabled = false;
            btnSUA.Enabled = false;
            btnXOA.Enabled = false;
            txtNCC.Enabled = false;
            txtIDCT.Text = HamXuLy.TaoIDMoi("CHITIETHDN", "IDCTHDN", "CTHDN");
        }

        private void btnXOA_Click(object sender, EventArgs e)
        {
            if (txtIDCT.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn gì để xóa", "Thông báo");
            }
            else
            {
                HamXuLy.connect(); // Gọi hàm kết nối

                string idHDB = cmbHDN.SelectedValue.ToString();
                string sql = "SELECT IDCTHDN FROM CHITIETHDN WHERE IDHDN = @IDHDN";

                try
                {
                    // Tạo SqlDataAdapter
                    SqlDataAdapter da = new SqlDataAdapter();
                    SqlCommand cmd = new SqlCommand(sql, HamXuLy.conn);
                    cmd.Parameters.AddWithValue("@IDHDN", idHDB);
                    da.SelectCommand = cmd;

                    // Đổ dữ liệu vào DataTable
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    int soDong = dt.Rows.Count;

                    if (soDong == 1)
                    {
                        MessageBox.Show("Cần ít nhất 1 chi tiết HD Tồn tại", "Không xóa được");
                    }
                    else if (soDong >= 2)
                    {
                        string sqlDelCTHDB = "DELETE FROM CHITIETHDN WHERE IDCTHDN = '" + txtIDCT.Text + "'";
                        if (MessageBox.Show("Bạn có muốn xóa không ?", "XÁC NHẬN XÓA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            try
                            {

                                HamXuLy.RunSQL(sqlDelCTHDB);
                                MessageBox.Show("Xóa Thành Công");
                                tinhtong();
                                showCTHDB();
                                HUY();

                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Lỗi Khi Xóa");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi truy vấn chi tiết hóa đơn: " + ex.Message, "Lỗi");
                }
                finally
                {
                    HamXuLy.disconnect();
                }


            }
        }

        private void btnSUA_Click(object sender, EventArgs e)
        {
            pnlHDN.Enabled = true;
            btnTHEM.Enabled = false;
            btnXOA.Enabled = false;
            txtIDCT.Enabled = false;
            txtDONGIA.Enabled = false;
            cmbHDN.Enabled = false;
            txtNCC.Enabled = false;
            if (txtIDCT.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn gì để sửa");
                HUY();
            }
        }

        private void btnLUU_Click(object sender, EventArgs e)
        {
            //Lưu thêm
            if (btnTHEM.Enabled == true && btnSUA.Enabled == false)
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
                        string maHDB = cmbHDN.Text;
                        string maSP = cmbSP.SelectedValue.ToString();

                        if (HamXuLy.ExistsChiTietHDB(maHDB, maSP))
                        {
                            string sltxt = "";
                            DataTable dtCT = new DataTable();
                            string sqlSL = "Select SOLUONG From CHITIETHDN Where IDHDN = '" + cmbHDN.Text + "' AND IDSP = '" + cmbSP.SelectedValue.ToString() + "'";
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
                            "WHERE IDHDN = '" + cmbHDN.Text + "' AND IDSP = '" + cmbSP.SelectedValue.ToString() + "'";

                            HamXuLy.RunSQL(sqlSua);
                            MessageBox.Show("Đã Cập nhật số lượng SP cho CTHDB có Mã: " + cmbHDN.Text);
                            tinhtong();
                            showCTHDB();
                            HUY();
                            return;
                        }
                        string sqlThem = "INSERT CHITIETHDN (IDCTHDN, IDHDN, IDSP, SOLUONG, IDSIZE, IDMAU, DONGIA) VALUES ('" + txtIDCT.Text + "', '" + cmbHDN.Text + "', '" + cmbSP.SelectedValue.ToString() + "', '" + txtSL.Text + "', '" + cmbSIZE.SelectedValue.ToString() + "', '" + cmbMAU.SelectedValue.ToString() + "', '" + txtDONGIA.Text + "')";
                        HamXuLy.RunSQL(sqlThem);
                        MessageBox.Show("Thêm Thành Công");
                        tinhtong();
                        showCTHDB();
                        HUY();


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            //Lưu sửa
            else if (btnTHEM.Enabled == false && btnSUA.Enabled == true)
            {
                try
                {

                    HamXuLy.connect();
                    string sqlSua = "UPDATE CHITIETHDN SET " +
                    "IDSP = '" + cmbSP.SelectedValue.ToString() + "', " +
                    "SOLUONG = '" + txtSL.Text + "', " +
                    "IDSIZE = '" + cmbSIZE.SelectedValue.ToString() + "', " +
                    "IDMAU = '" + cmbMAU.SelectedValue.ToString() + "', " +
                    "DONGIA = '" + txtDONGIA.Text + "' " +
                    "WHERE IDCTHDN = '" + txtIDCT.Text + "'";

                    HamXuLy.RunSQL(sqlSua);

                    MessageBox.Show("Sửa Thành Công");
                    showCTHDB();
                    tinhtong();
                    HUY();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo");
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn thao tác để lưu");
            }
        }

        private void btnTIM_Click(object sender, EventArgs e)
        {
            DataTable dtTIM = new DataTable();
            if (txtTIMKIEM.Text == "")
            {
                MessageBox.Show("Không được để trống nội dung tìm kiếm");
            }
            else
            {
                
                string sqlTIM =
                    "SELECT CTHDN.* " +
                    "FROM CHITIETHDN CTHDN " +
                    "JOIN HOADONNHAP HDN ON CTHDN.IDHDN = HDN.IDHDN " +
                    "JOIN NHACUNGCAP NCC ON HDN.IDNCC = NCC.IDNCC " +
                    "WHERE NCC.TENNCC LIKE N'%" + txtTIMKIEM.Text.Trim() + "%'";
                if (HamXuLy.TruyVan(sqlTIM, dtTIM))
                {

                    if (dtTIM.Rows.Count > 0)
                    {
                        luoiHDN.DataSource = dtTIM;

                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy Hóa đơn nào của Khách Hàng tên " + txtTIMKIEM.Text);
                }
            }
        }

        private void btnRESET_Click(object sender, EventArgs e)
        {
            showCTHDB();
        }

        private void txtTIMKIEM_Leave(object sender, EventArgs e)
        {
            if (txtTIMKIEM.Text == "")
            {
                txtTIMKIEM.Text = "Nhập tên Nhà cung cấp";
                txtTIMKIEM.ForeColor = Color.Gray;
            }
        }

        private void txtTIMKIEM_Enter(object sender, EventArgs e)
        {
            if (txtTIMKIEM.Text == "Nhập tên Nhà cung cấp")
            {
                txtTIMKIEM.Text = "";
                txtTIMKIEM.ForeColor = Color.Black;
            }
        }

    }
}
