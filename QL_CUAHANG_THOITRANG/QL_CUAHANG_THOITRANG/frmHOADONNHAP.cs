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
    public partial class frmHOADONNHAP : Form
    {
        public string tonggoc;
        public frmHOADONNHAP()
        {
            InitializeComponent();
        }
        private void showHDN()
        {
            DataTable dtHDN = new DataTable();
            HamXuLy.connect();
            dtHDN.Clear();
            String sqlHDN = "select * From HOADONNHAP";
            if (HamXuLy.TruyVan(sqlHDN, dtHDN))
            {
                luoiHDN.DataSource = dtHDN;
                //Trang trí lưới
                luoiHDN.Columns[0].HeaderText = "MÃ HÓA ĐƠN";
                luoiHDN.Columns[0].Width = 100;
                luoiHDN.Columns[1].HeaderText = "NHÂN VIÊN";
                luoiHDN.Columns[1].Width = 150;
                luoiHDN.Columns[2].HeaderText = "KHÁCH HÀNG";
                luoiHDN.Columns[2].Width = 150;
                luoiHDN.Columns[3].HeaderText = "NGÀY LẬP";
                luoiHDN.Columns[3].Width = 100;
                luoiHDN.Columns[4].HeaderText = "TRẠNG THÁI";
                luoiHDN.Columns[4].Width = 100;
                luoiHDN.Columns[5].HeaderText = "TỔNG TIỀN";
                luoiHDN.Columns[5].Width = 100;

                luoiHDN.EnableHeadersVisualStyles = false;
                luoiHDN.ColumnHeadersDefaultCellStyle.BackColor = Color.Cyan;
            }
        }
        
        private void frmHOADONNHAP_Load(object sender, EventArgs e)
        {
            showHDN();
            pnlHDN.Enabled = false;
            string SqlFillCombo1 = "Select * From NHANVIEN";
            string SqlFillCombo2 = "Select * From NHACUNGCAP";
            HamXuLy.FillCombo(SqlFillCombo1, cmbNV, "IDNV", "HOTEN");
            HamXuLy.FillCombo(SqlFillCombo2, cmbNCC, "IDNCC", "TENNCC");
            txtTIMKIEM.Text = "Nhập tên Nhà cung cấp";
            
        }

        private void luoiHDN_Click(object sender, EventArgs e)
        {
            txtMAHDN.Text = luoiHDN.CurrentRow.Cells["IDHDN"].Value.ToString();
            txtTONGTIEN.Text = luoiHDN.CurrentRow.Cells["TONGTIEN"].Value.ToString();
            txtTRANGTHAI.Text = luoiHDN.CurrentRow.Cells["TRANGTHAI"].Value.ToString();
            dtpNGLAP.Text = luoiHDN.CurrentRow.Cells["NGAYLAP"].Value.ToString();
            //Xử lý cho combobox
            String MANV, MANCC, sql1, sql2;
            //Combo NV
            HamXuLy.connect();
            MANV = luoiHDN.CurrentRow.Cells["IDNV"].Value.ToString();
            sql1 = "Select HOTEN From NHANVIEN where IDNV ='" + MANV + "'";
            cmbNV.Text = HamXuLy.GetFieldValues(sql1);
            //Combo NCC
            MANCC = luoiHDN.CurrentRow.Cells["IDNCC"].Value.ToString();
            sql2 = "Select TENNCC From NHACUNGCAP where IDNCC ='" + MANCC + "'";
            cmbNCC.Text = HamXuLy.GetFieldValues(sql2);
        }

        private void HUY()
        {
            pnlHDN.Enabled = false;
            btnSUA.Enabled = true;
            btnXOA.Enabled = true;
            btnTHEM.Enabled = true;
            txtMAHDN.ResetText();
            txtTONGTIEN.ResetText();
            txtTRANGTHAI.ResetText();
            dtpNGLAP.Value = DateTime.Now;

        }

        private void btnTHEM_Click(object sender, EventArgs e)
        {
            btnSUA.Enabled = false;
            btnXOA.Enabled = false;

            txtMAHDN.ResetText();
            txtTONGTIEN.ResetText();
            txtTRANGTHAI.ResetText();
            dtpNGLAP.Value = DateTime.Now;

            pnlHDN.Enabled = true;
            txtMAHDN.Enabled = false;
            txtTONGTIEN.Enabled = false;
            txtTONGTIEN.Text = "0";
            txtMAHDN.Text = HamXuLy.TaoIDMoi("HOADONNHAP", "IDHDN", "HDN");
            cmbNV.Focus();
        }

        private void btnHUY_Click(object sender, EventArgs e)
        {
            HUY();
        }

        private void btnXOA_Click(object sender, EventArgs e)
        {
            if (txtMAHDN.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn gì để xóa", "Thông báo");
            }
            else
            {
                HamXuLy.connect();
                //Truy vấn sql
                String sqlDelete = "DELETE FROM HOADONNHAP WHERE IDHDN = '" + txtMAHDN.Text + "'";
                string sqlDelCTHDN = "DELETE FROM CHITIETHDN WHERE IDHDN = '" + txtMAHDN.Text + "'";
                if (MessageBox.Show("Bạn có muốn xóa không ?", "XÁC NHẬN XÓA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        HamXuLy.RunSQL(sqlDelCTHDN);
                        HamXuLy.RunSQL(sqlDelete);
                        MessageBox.Show("Xóa Thành Công");
                        showHDN();

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
            pnlHDN.Enabled = true;
            btnSUA.Enabled = true;
            btnXOA.Enabled = false;
            btnTHEM.Enabled = false;
            txtMAHDN.Enabled = false;
            txtTONGTIEN.Enabled = false;
            
            tonggoc = txtTONGTIEN.Text;
            if (txtMAHDN.Text == "")
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
                else if (cmbNCC.Text == "")
                {
                    MessageBox.Show("Không được để trống Nhà cung cấp", "Thông báo");
                    cmbNCC.Focus();
                }
                else if (txtTRANGTHAI.Text == "")
                {
                    MessageBox.Show("Không được để trống Trạng thái", "Thông báo");
                    txtTRANGTHAI.Focus();
                }
                else
                {
                    try
                    {
                        HamXuLy.connect();
                        //Xử lý đưa dữ liệu trên combo box về MACL thay vì TENCL
                        string sqlThem = "INSERT HOADONNHAP (IDHDN, IDNV, IDNCC, NGAYLAP, TRANGTHAI, TONGTIEN) VALUES ('" + txtMAHDN.Text + "', '" + cmbNV.SelectedValue.ToString() + "', '" + cmbNCC.SelectedValue.ToString() + "', '" + dtpNGLAP.Text + "', N'" + txtTRANGTHAI.Text + "', '" + txtTONGTIEN.Text + "')";
                        HamXuLy.RunSQL(sqlThem);
                        MessageBox.Show("Thêm Thành Công");
                        showHDN();
                        HamXuLy.mahdban = txtMAHDN.Text;
                        
                        HUY();
                        HamXuLy.disconnect();
                        frmTHEMCTHDN frmTCTHDN = new frmTHEMCTHDN();
                        frmTCTHDN.Show();

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
                    string sqlSua = "UPDATE HOADONNHAP SET " +
                    "IDNV = '" + cmbNV.SelectedValue.ToString() + "', " +
                    "IDNCC = '" + cmbNCC.SelectedValue.ToString() + "', " +
                    "NGAYLAP = '" + dtpNGLAP.Text + "', " +
                    "TRANGTHAI = N'" + txtTRANGTHAI.Text + "', " +
                    "TONGTIEN = '" + txtTONGTIEN.Text + "' " +
                    "WHERE IDHDN = '" + txtMAHDN.Text + "'";

                    HamXuLy.RunSQL(sqlSua);

                    MessageBox.Show("Sửa Thành Công");
                    showHDN();
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

        private void btnCTHD_Click(object sender, EventArgs e)
        {
            if (txtMAHDN.Text == "")
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn để xem chi tiết");
            }
            else
            {
                HamXuLy.MAHD = txtMAHDN.Text;
                frmCHITIETHDN frmCTHDN = new frmCHITIETHDN();
                frmCTHDN.Show();
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
                string sqlTIM = "SELECT HDN.* " +
                                "FROM HOADONNHAP HDN " +
                                "JOIN NHACUNGCAP NCC ON HDN.IDNCC = NCC.IDNCC " +
                                "WHERE NCC.TENNCC LIKE N'%" + txtTIMKIEM.Text + "%'";
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
            showHDN();
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
