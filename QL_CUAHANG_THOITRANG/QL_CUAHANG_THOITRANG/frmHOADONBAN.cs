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
    public partial class frmHOADONBAN : Form
    {
        public string ggiagoc;
        public string tonggoc;
        
        public frmHOADONBAN()
        {
            InitializeComponent();
        }
        private void showHDB()
        {
            DataTable dtHDB = new DataTable();
            HamXuLy.connect();
            dtHDB.Clear();
            String sqlHDB = "select * From HOADONBAN";
            if (HamXuLy.TruyVan(sqlHDB, dtHDB))
            {
                luoiHDB.DataSource = dtHDB;
                //Trang trí lưới
                luoiHDB.Columns[0].HeaderText = "MÃ HÓA ĐƠN";
                luoiHDB.Columns[0].Width = 100;
                luoiHDB.Columns[1].HeaderText = "NHÂN VIÊN";
                luoiHDB.Columns[1].Width = 150;
                luoiHDB.Columns[2].HeaderText = "KHÁCH HÀNG";
                luoiHDB.Columns[2].Width = 150;
                luoiHDB.Columns[3].HeaderText = "NGÀY LẬP";
                luoiHDB.Columns[3].Width = 100;
                luoiHDB.Columns[4].HeaderText = "GIẢM GIÁ";
                luoiHDB.Columns[4].Width = 100;
                luoiHDB.Columns[5].HeaderText = "TỔNG TIỀN";
                luoiHDB.Columns[5].Width = 100;
                
                luoiHDB.EnableHeadersVisualStyles = false;
                luoiHDB.ColumnHeadersDefaultCellStyle.BackColor = Color.Cyan;
            }
        }
        private void tongtien()
        {
            double temp;
            if (txtGIAMGIA.Text == "" || txtGIAMGIA.Text == null)
            {
                txtGIAMGIA.Text = "0";
                
            }
            else
            {
                if (!double.TryParse(txtGIAMGIA.Text, out temp))
                {
                    MessageBox.Show("Lỗi giá trị. Vui lòng nhập số.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtGIAMGIA.Text = ggiagoc;
                    txtGIAMGIA.Focus();
                }
            }
            
            double tong = 0;
            if (btnTHEM.Enabled == false && btnSUA.Enabled == true)
            {
                if (txtGIAMGIA.Text != "" || txtGIAMGIA.Text != "0")
                {
                    if (txtGIAMGIA.Text == ggiagoc)
                    {
                        txtTONGTIEN.Text = tonggoc;
                    }
                    else
                    {
                        tong = (double.Parse(tonggoc) + double.Parse(ggiagoc)) - double.Parse(txtGIAMGIA.Text);
                        txtTONGTIEN.Text = tong.ToString();
                    }
                    
                }
                else if (txtGIAMGIA.Text == "" || txtGIAMGIA.Text == "0")
                {
                    txtTONGTIEN.Text = tonggoc;
                }
                if (txtGIAMGIA.Text != "" || txtGIAMGIA.Text != "0")
                {
                    if ((double.Parse(tonggoc) - double.Parse(txtGIAMGIA.Text)) < 0)
                    {

                        txtGIAMGIA.Text = ggiagoc;
                        txtTONGTIEN.Text = tonggoc;
                        MessageBox.Show("Giảm giá không thể lớn hơn Tổng Tiền");
                    }
                }
                
            }
        }
        private void frmHOADONBAN_Load(object sender, EventArgs e)
        {
            showHDB();
            pnlHDB.Enabled = false;
            string SqlFillCombo1 = "Select * From NHANVIEN";
            string SqlFillCombo2 = "Select * From KHACHHANG";
            HamXuLy.FillCombo(SqlFillCombo1, cmbNV, "IDNV", "HOTEN");
            HamXuLy.FillCombo(SqlFillCombo2, cmbKH, "IDKH", "HOTEN");
            txtTIMKIEM.Text = "Nhập tên Khách hàng";
            txtGIAMGIA.TextChanged += (s, ev) => tongtien();
        }

        private void luoiHDB_Click(object sender, EventArgs e)
        {
            txtMAHDB.Text = luoiHDB.CurrentRow.Cells["IDHDB"].Value.ToString();
            txtTONGTIEN.Text = luoiHDB.CurrentRow.Cells["TONGTIEN"].Value.ToString();
            txtGIAMGIA.Text = luoiHDB.CurrentRow.Cells["GIAMGIA"].Value.ToString();
            dtpNGLAP.Text = luoiHDB.CurrentRow.Cells["NGAYLAP"].Value.ToString();
            //Xử lý cho combobox
            String MANV, MAKH, sql1, sql2;
            //Combo NV
            HamXuLy.connect();
            MANV = luoiHDB.CurrentRow.Cells["IDNV"].Value.ToString();
            sql1 = "Select HOTEN From NHANVIEN where IDNV ='" + MANV + "'";
            cmbNV.Text = HamXuLy.GetFieldValues(sql1);
            //Combo KH
            MAKH = luoiHDB.CurrentRow.Cells["IDKH"].Value.ToString();
            sql2 = "Select HOTEN From KHACHHANG where IDKH ='" + MAKH + "'";
            cmbKH.Text = HamXuLy.GetFieldValues(sql2);
        }

        private void HUY()
        {
            pnlHDB.Enabled = false;
            btnSUA.Enabled = true;
            btnXOA.Enabled = true;
            btnTHEM.Enabled = true;
            txtMAHDB.ResetText();
            txtTONGTIEN.ResetText();
            txtGIAMGIA.ResetText();
            dtpNGLAP.Value = DateTime.Now;
            
        }

        private void btnHUY_Click(object sender, EventArgs e)
        {
            HUY();
        }

        private void btnTHEM_Click(object sender, EventArgs e)
        {
            btnSUA.Enabled = false;
            btnXOA.Enabled = false;

            txtMAHDB.ResetText();
            txtTONGTIEN.ResetText();
            txtGIAMGIA.ResetText();
            dtpNGLAP.Value = DateTime.Now;
            
            pnlHDB.Enabled = true;
            txtMAHDB.Enabled = false;
            txtTONGTIEN.Enabled = false;
            txtGIAMGIA.Text = "0";
            txtMAHDB.Text = HamXuLy.TaoIDMoi("HOADONBAN", "IDHDB", "HDB");
            cmbNV.Focus();
        }

        private void btnXOA_Click(object sender, EventArgs e)
        {
            if (txtMAHDB.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn gì để xóa", "Thông báo");
            }
            else
            {
                HamXuLy.connect();
                //Truy vấn sql
                String sqlDelete = "DELETE FROM HOADONBAN WHERE IDHDB = '" + txtMAHDB.Text + "'";
                string sqlDelCTHDB = "DELETE FROM CHITIETHDB WHERE IDHDB = '" + txtMAHDB.Text + "'";
                if (MessageBox.Show("Bạn có muốn xóa không ?", "XÁC NHẬN XÓA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        HamXuLy.RunSQL(sqlDelCTHDB);
                        HamXuLy.RunSQL(sqlDelete);
                        MessageBox.Show("Xóa Thành Công");
                        showHDB();

                        HUY();
                        HamXuLy.disconnect();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Lỗi Khi Xóa");
                    }
                }
            }
        }

        private void btnSUA_Click(object sender, EventArgs e)
        {
            pnlHDB.Enabled = true;
            btnSUA.Enabled = true;
            btnXOA.Enabled = false;
            btnTHEM.Enabled = false;
            txtMAHDB.Enabled = false;
            txtTONGTIEN.Enabled = false;
            ggiagoc = txtGIAMGIA.Text;
            tonggoc = txtTONGTIEN.Text;
            if (txtMAHDB.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn gì để sửa");
                HUY();
            }
        }

        private void btnLUU_Click(object sender, EventArgs e)
        {
            //Lưu Thêm
            if (btnTHEM.Enabled == true && btnSUA.Enabled == false)
            {
                if (cmbNV.Text == "")
                {
                    MessageBox.Show("Không được để trống Nhân viên", "Thông báo");
                    cmbNV.Focus();
                }
                else if (cmbKH.Text == "")
                {
                    MessageBox.Show("Không được để trống Khách hàng", "Thông báo");
                    cmbKH.Focus();
                }
                else
                {
                    try
                    {
                        HamXuLy.connect();
                        //Xử lý đưa dữ liệu trên combo box về MACL thay vì TENCL
                        string sqlThem = "INSERT HOADONBAN (IDHDB, IDNV, IDKH, NGAYLAP, GIAMGIA, TONGTIEN) VALUES ('" + txtMAHDB.Text + "', '" + cmbNV.SelectedValue.ToString() + "', '" + cmbKH.SelectedValue.ToString() + "', '" + dtpNGLAP.Text + "', '" + txtGIAMGIA.Text + "', '" + HamXuLy.tongtien + "')";
                        HamXuLy.RunSQL(sqlThem);
                        MessageBox.Show("Thêm Thành Công");
                        showHDB();
                        HamXuLy.mahdban = txtMAHDB.Text;
                        HamXuLy.giamgia = double.Parse(txtGIAMGIA.Text);
                        HUY();
                        HamXuLy.disconnect();
                        frmTHEMCTHDB frmTCTHDB = new frmTHEMCTHDB();
                        frmTCTHDB.Show();

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
                    string sqlSua = "UPDATE HOADONBAN SET " +
                    "IDNV = '" + cmbNV.SelectedValue.ToString() + "', " +
                    "IDKH = '" + cmbKH.SelectedValue.ToString() + "', " +
                    "NGAYLAP = '" + dtpNGLAP.Text + "', " +
                    "GIAMGIA = '" + txtGIAMGIA.Text + "', " +
                    "TONGTIEN = '" + txtTONGTIEN.Text + "' " +
                    "WHERE IDHDB = '" + txtMAHDB.Text + "'";

                    HamXuLy.RunSQL(sqlSua);

                    MessageBox.Show("Sửa Thành Công");
                    showHDB();
                    HUY();
                    HamXuLy.disconnect();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Thông báo");
                }
            }
            //Không chọn gì để lưu
            else
            {
                MessageBox.Show("Không có tùy chọn để lưu");
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
                string sqlTIM = "SELECT HDB.* " +
                                "FROM HOADONBAN HDB " +
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
            showHDB();
        }

        private void btnCTHD_Click(object sender, EventArgs e)
        {
            
            if (txtMAHDB.Text == "")
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn để xem chi tiết");
            }
            else
            {
                HamXuLy.MAHD = txtMAHDB.Text;
                frmCHITIETHDB frmCTHDB = new frmCHITIETHDB();
                frmCTHDB.Show();
            }
            
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
    }
}
