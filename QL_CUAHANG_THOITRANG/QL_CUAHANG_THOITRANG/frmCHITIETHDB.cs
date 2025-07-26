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
    public partial class frmCHITIETHDB : Form
    {
        public frmCHITIETHDB()
        {
            InitializeComponent();
        }
        String sqlHDB;
        private void showCTHDB()
        {
            DataTable dtHDB = new DataTable();
            HamXuLy.connect();
            dtHDB.Clear();
            if (HamXuLy.MAHD == "")
            {
                sqlHDB = "select * From CHITIETHDB";
            }
            else
            {
                sqlHDB = "select * From CHITIETHDB Where IDHDB = '"+HamXuLy.MAHD+"'";
            }
            
            if (HamXuLy.TruyVan(sqlHDB, dtHDB))
            {
                luoiHDB.DataSource = dtHDB;
                //Trang trí lưới
                luoiHDB.Columns[0].HeaderText = "ID CHI TIẾT";
                luoiHDB.Columns[0].Width = 100;
                luoiHDB.Columns[1].HeaderText = "HÓA ĐƠN";
                luoiHDB.Columns[1].Width = 100;
                luoiHDB.Columns[2].HeaderText = "SẢN PHẨM";
                luoiHDB.Columns[2].Width = 100;
                luoiHDB.Columns[3].HeaderText = "SL";
                luoiHDB.Columns[3].Width = 70;
                luoiHDB.Columns[4].HeaderText = "SIZE";
                luoiHDB.Columns[4].Width = 70;
                luoiHDB.Columns[5].HeaderText = "MAU";
                luoiHDB.Columns[5].Width = 70;
                luoiHDB.Columns[6].HeaderText = "ĐƠN GIÁ";
                luoiHDB.Columns[6].Width = 100;
                luoiHDB.EnableHeadersVisualStyles = false;
                luoiHDB.ColumnHeadersDefaultCellStyle.BackColor = Color.Cyan;
            }
        }

        private void cmbSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSP.SelectedValue != null)
            {
                string mahang = cmbSP.SelectedValue.ToString();
                string sqlDG = "SELECT DGBAN FROM SANPHAM WHERE IDSP = '" + mahang + "'";
                string dongia = HamXuLy.GetFieldValues(sqlDG);
                txtDONGIA.Text = dongia;

            }
        }

        private void frmCHITIETHDB_Load(object sender, EventArgs e)
        {
            pnlHDB.Enabled = false;
            txtTIMKIEM.Text = "Nhập tên Khách hàng";
            showCTHDB();
            string SqlFillCombo1 = "Select * From SANPHAM";
            string SqlFillCombo2 = "Select * From SIZE";
            string SqlFillCombo3 = "Select * From MAU";
            string SqlFillCombo4 = "Select * From HOADONBAN";
            HamXuLy.FillCombo(SqlFillCombo1, cmbSP, "IDSP", "TENSP");
            HamXuLy.FillCombo(SqlFillCombo2, cmbSIZE, "IDSIZE", "TENSIZE");
            HamXuLy.FillCombo(SqlFillCombo3, cmbMAU, "IDMAU", "TENMAU");
            HamXuLy.FillCombo(SqlFillCombo4, cmbHDB, "IDHDB", "IDHDB");
            cmbSP.SelectedIndexChanged += cmbSP_SelectedIndexChanged;
            if (txtDONGIA.Text == "" || txtDONGIA.Text == null)
            {
                string sqlTV1 = "Select DGBAN From SANPHAM Where TENSP = '" + cmbSP.Text + "'";
                txtDONGIA.Text = HamXuLy.GetFieldValues(sqlTV1);
            }
        }
        private void HUY()
        {
            pnlHDB.Enabled = false;
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
                string sqlTrV1 = string.Format("SELECT SOLUONG, DONGIA FROM CHITIETHDB WHERE IDHDB = '{0}'", cmbHDB.Text);

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
                    string sqlGG = "Select GIAMGIA From HOADONBAN Where IDHDB = '" + cmbHDB.Text + "'";
                    DataTable dtGG = new DataTable();

                    // Thực hiện truy vấn
                    if (HamXuLy.TruyVan(sqlGG, dtGG))
                    {
                        foreach (DataRow row in dtGG.Rows)
                        {
                            HamXuLy.giamgia = Convert.ToInt32(row["GIAMGIA"]);

                        }
                    }
                    tong = tong - HamXuLy.giamgia;
                    // Lưu tổng tiền vào biến tĩnh
                    HamXuLy.tongtien = tong;
                    string sqlSua = "UPDATE HOADONBAN SET " +
                    "TONGTIEN = '" + HamXuLy.tongtien + "' " +
                    "WHERE IDHDB = '" + cmbHDB.Text + "'";

                    HamXuLy.RunSQL(sqlSua);

                    MessageBox.Show("Đã cập nhật lại tổng tiền cho Hóa đơn có mã: " + cmbHDB.SelectedValue.ToString());
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

        private void btnTHEM_Click(object sender, EventArgs e)
        {
            pnlHDB.Enabled = true;
            txtIDCT.Enabled = false;
            cmbHDB.Enabled = true;
            txtDONGIA.Enabled = false;
            btnSUA.Enabled = false;
            btnXOA.Enabled = false;
            txtKH.Enabled = false;
            txtIDCT.Text = HamXuLy.TaoIDMoi("CHITIETHDB", "IDCTHDB", "CTHDB");
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

                string idHDB = cmbHDB.SelectedValue.ToString();
                string sql = "SELECT IDCTHDB FROM CHITIETHDB WHERE IDHDB = @IDHDB";

                try
                {
                    // Tạo SqlDataAdapter
                    SqlDataAdapter da = new SqlDataAdapter();
                    SqlCommand cmd = new SqlCommand(sql, HamXuLy.conn);
                    cmd.Parameters.AddWithValue("@IDHDB", idHDB);
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
                        string sqlDelCTHDB = "DELETE FROM CHITIETHDB WHERE IDCTHDB = '" + txtIDCT.Text + "'";
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

        private void luoiHDB_Click(object sender, EventArgs e)
        {
            txtIDCT.Text = luoiHDB.CurrentRow.Cells["IDCTHDB"].Value.ToString();
            txtSL.Text = luoiHDB.CurrentRow.Cells["SOLUONG"].Value.ToString();
            txtDONGIA.Text = luoiHDB.CurrentRow.Cells["DONGIA"].Value.ToString();
            //Xử lý cho combobox
            String MAHD, MASP, MASZ, MAMAU, sql1, sql2, sql3, sql4;
            //Combo HDB
            HamXuLy.connect();
            MAHD = luoiHDB.CurrentRow.Cells["IDHDB"].Value.ToString();
            sql1 = "Select IDHDB From HOADONBAN where IDHDB ='" + MAHD + "'";
            cmbHDB.Text = HamXuLy.GetFieldValues(sql1);
            //Combo SP
            MASP = luoiHDB.CurrentRow.Cells["IDSP"].Value.ToString();
            sql2 = "Select TENSP From SANPHAM where IDSP ='" + MASP + "'";
            cmbSP.Text = HamXuLy.GetFieldValues(sql2);
            //Combo SIZE
            MASZ = luoiHDB.CurrentRow.Cells["IDSIZE"].Value.ToString();
            sql3 = "Select TENSIZE From SIZE where IDSIZE ='" + MASZ + "'";
            cmbSIZE.Text = HamXuLy.GetFieldValues(sql3);
            //Combo MAU
            MAMAU = luoiHDB.CurrentRow.Cells["IDMAU"].Value.ToString();
            sql4 = "Select TENMAU From MAU where IDMAU ='" + MAMAU + "'";
            cmbMAU.Text = HamXuLy.GetFieldValues(sql4);

            string sqlKH =
                "SELECT KH.HOTEN " +
                "FROM HOADONBAN HDB " +
                "JOIN KHACHHANG KH ON HDB.IDKH = KH.IDKH " +
                "WHERE HDB.IDHDB = '" + cmbHDB.Text + "'";
            txtKH.Text = HamXuLy.GetFieldValues(sqlKH);
        }

        private void btnSUA_Click(object sender, EventArgs e)
        {
            pnlHDB.Enabled = true;
            btnTHEM.Enabled = false;
            btnXOA.Enabled = false;
            txtIDCT.Enabled = false;
            txtDONGIA.Enabled = false;
            cmbHDB.Enabled = false;
            txtKH.Enabled = false;
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
                        string maHDB = cmbHDB.Text;
                        string maSP = cmbSP.SelectedValue.ToString();

                        if (HamXuLy.ExistsChiTietHDB(maHDB, maSP))
                        {
                            string sltxt = "";
                            DataTable dtCT = new DataTable();
                            string sqlSL = "Select SOLUONG From CHITIETHDB Where IDHDB = '" + cmbHDB.Text + "' AND IDSP = '" + cmbSP.SelectedValue.ToString() + "'";
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

                            string sqlSua = "UPDATE CHITIETHDB SET " +
                            "SOLUONG = '" + sltxt + "' " +
                            "WHERE IDHDB = '" + cmbHDB.Text + "' AND IDSP = '" + cmbSP.SelectedValue.ToString() + "'";

                            HamXuLy.RunSQL(sqlSua);
                            MessageBox.Show("Đã Cập nhật số lượng SP cho CTHDB có Mã: " + cmbHDB.Text);
                            tinhtong();
                            showCTHDB();
                            HUY();
                            return;
                        }
                        string sqlThem = "INSERT CHITIETHDB (IDCTHDB, IDHDB, IDSP, SOLUONG, IDSIZE, IDMAU, DONGIA) VALUES ('" + txtIDCT.Text + "', '" + cmbHDB.Text + "', '" + cmbSP.SelectedValue.ToString() + "', '" + txtSL.Text + "', '" + cmbSIZE.SelectedValue.ToString() + "', '" + cmbMAU.SelectedValue.ToString() + "', '" + txtDONGIA.Text + "')";
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
                    string sqlSua = "UPDATE CHITIETHDB SET " +
                    "IDSP = '" + cmbSP.SelectedValue.ToString() + "', " +
                    "SOLUONG = '" + txtSL.Text + "', " +
                    "IDSIZE = '" + cmbSIZE.SelectedValue.ToString() + "', " +
                    "IDMAU = '" + cmbMAU.SelectedValue.ToString() + "', " +
                    "DONGIA = '" + txtDONGIA.Text + "' " +
                    "WHERE IDCTHDB = '" + txtIDCT.Text + "'";

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
                    "SELECT CTHDB.* " +
                    "FROM CHITIETHDB CTHDB " +
                    "JOIN HOADONBAN HDB ON CTHDB.IDHDB = HDB.IDHDB " +
                    "JOIN KHACHHANG KH ON HDB.IDKH = KH.IDKH " +
                    "WHERE KH.HOTEN LIKE N'%" + txtTIMKIEM.Text + "%'";
                if (HamXuLy.TruyVan(sqlTIM, dtTIM))
                {

                    if (dtTIM.Rows.Count > 0)
                    {
                        luoiHDB.DataSource = dtTIM;

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

        private void txtTIMKIEM_Enter(object sender, EventArgs e)
        {
            if (txtTIMKIEM.Text == "Nhập tên Khách hàng")
            {
                txtTIMKIEM.Text = "";
                txtTIMKIEM.ForeColor = Color.Black;
            }
        }

        private void txtTIMKIEM_Leave(object sender, EventArgs e)
        {
            if (txtTIMKIEM.Text == "")
            {
                txtTIMKIEM.Text = "Nhập tên Khách hàng";
                txtTIMKIEM.ForeColor = Color.Gray;
            }
        }

    }//Class
}
