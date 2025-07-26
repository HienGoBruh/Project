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
    public partial class frmKHACHHANG : Form
    {
        public frmKHACHHANG()
        {
            InitializeComponent();
        }

        private void showKH()
        {
            DataTable dtKH = new DataTable();
            HamXuLy.connect();

            String sqlKHACHHANG = "select * From KHACHHANG";
            dtKH.Clear();
            if (HamXuLy.TruyVan(sqlKHACHHANG, dtKH))
            {
                luoiKH.DataSource = dtKH;
                //Trang trí lưới
                luoiKH.Columns[0].HeaderText = "MÃ KHÁCH HÀNG";
                luoiKH.Columns[0].Width = 100;
                luoiKH.Columns[1].HeaderText = "HỌ TÊN";
                luoiKH.Columns[1].Width = 150;
                luoiKH.Columns[2].HeaderText = "GIỚI TÍNH";
                luoiKH.Columns[2].Width = 100;
                luoiKH.Columns[3].HeaderText = "NĂM SINH";
                luoiKH.Columns[3].Width = 100;
                luoiKH.Columns[4].HeaderText = "EMAIL";
                luoiKH.Columns[4].Width = 150;
                luoiKH.Columns[5].HeaderText = "SỐ ĐIỆN THOẠI";
                luoiKH.Columns[5].Width = 100;
                luoiKH.Columns[6].HeaderText = "ĐỊA CHỈ";
                luoiKH.Columns[6].Width = 200;

                luoiKH.EnableHeadersVisualStyles = false;
                luoiKH.ColumnHeadersDefaultCellStyle.BackColor = Color.Cyan;
            }
        }

        private void frmKHACHHANG_Load(object sender, EventArgs e)
        {
            HamXuLy.connect();
            txtTIMKIEM.Text = "Nhập tên Khách hàng";
            showKH();
            pnlKH.Enabled = false;
        }
        private void HUY()
        {
            pnlKH.Enabled = false;
            btnSUA.Enabled = true;
            btnXOA.Enabled = true;
            btnTHEM.Enabled = true;
            txtMAKH.ResetText();
            txtHOTEN.ResetText();
            txtGIOITINH.ResetText();
            txtNAMSINH.ResetText();
            txtEMAIL.ResetText();
            txtDIENTHOAI.ResetText();
            txtDIACHI.ResetText();
            pnlKH.Enabled = false;
        }

        private void btnHUY_Click(object sender, EventArgs e)
        {
            HUY();
        }

        private void btnTHEM_Click(object sender, EventArgs e)
        {
            btnSUA.Enabled = false;
            btnXOA.Enabled = false;

            txtMAKH.ResetText();
            txtHOTEN.ResetText();
            txtGIOITINH.ResetText();
            txtNAMSINH.ResetText();
            txtEMAIL.ResetText();
            txtDIENTHOAI.ResetText();
            txtDIACHI.ResetText();
            pnlKH.Enabled = true;
            txtMAKH.Enabled = false;
            txtMAKH.Text = HamXuLy.TaoIDMoi("KHACHHANG", "IDKH", "KH");
            txtHOTEN.Focus();
        }

        private void btnSUA_Click(object sender, EventArgs e)
        {
            pnlKH.Enabled = true;
            btnSUA.Enabled = true;
            btnXOA.Enabled = false;
            btnTHEM.Enabled = false;
            txtMAKH.Enabled = false;
            if (txtMAKH.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn gì để sửa");
                HUY();
            }
        }

        private void luoiKH_Click(object sender, EventArgs e)
        {
            txtMAKH.Text = luoiKH.CurrentRow.Cells["IDKH"].Value.ToString();
            txtHOTEN.Text = luoiKH.CurrentRow.Cells["HOTEN"].Value.ToString();
            txtGIOITINH.Text = luoiKH.CurrentRow.Cells["GIOITINH"].Value.ToString();
            txtNAMSINH.Text = luoiKH.CurrentRow.Cells["NAMSINH"].Value.ToString();
            txtEMAIL.Text = luoiKH.CurrentRow.Cells["EMAIL"].Value.ToString();
            txtDIENTHOAI.Text = luoiKH.CurrentRow.Cells["SDT"].Value.ToString();
            txtDIACHI.Text = luoiKH.CurrentRow.Cells["DIACHI"].Value.ToString();
        }

        private void btnXOA_Click(object sender, EventArgs e)
        {
            if (txtMAKH.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn gì để xóa", "Thông báo");
            }
            else
            {
                HamXuLy.connect();
                //Truy vấn sql
                String sqlDelete = "DELETE FROM KHACHHANG WHERE IDKH = '" + txtMAKH.Text + "'";
                if (MessageBox.Show("Bạn có muốn xóa không ?", "XÁC NHẬN XÓA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        HamXuLy.RunSQL(sqlDelete);
                        MessageBox.Show("Xóa Thành Công");
                        showKH();

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

        private void btnLUU_Click(object sender, EventArgs e)
        {
            if (btnTHEM.Enabled == true && btnSUA.Enabled == false)
            {
                if (txtHOTEN.Text == "")
                {
                    MessageBox.Show("Không được để trống Họ tên", "Thông báo");
                    txtHOTEN.Focus();
                }
                else if (txtGIOITINH.Text == "")
                {
                    MessageBox.Show("Không được để trống Giới tính", "Thông báo");
                    txtGIOITINH.Focus();
                }
                else if (txtNAMSINH.Text == "")
                {
                    MessageBox.Show("Không được để trống Năm sinh", "Thông báo");
                    txtNAMSINH.Focus();
                }
                else if (txtDIENTHOAI.Text == "")
                {
                    MessageBox.Show("Không được để trống Điện thoại", "Thông báo");
                    txtDIENTHOAI.Focus();
                }
                else if (txtEMAIL.Text == "")
                {
                    MessageBox.Show("Không được để trống Email", "Thông báo");
                    txtEMAIL.Focus();
                }
                else if (txtDIACHI.Text == "")
                {
                    MessageBox.Show("Không được để trống Địa chỉ", "Thông báo");
                    txtDIACHI.Focus();
                }
                else
                {
                    try
                    {
                        HamXuLy.connect();
                        //Xử lý đưa dữ liệu trên combo box về MACL thay vì TENCL

                        string sqlThem = "INSERT KHACHHANG (IDKH, HOTEN, GIOITINH, NAMSINH, EMAIL, SDT, DIACHI) VALUES ('" + txtMAKH.Text + "', N'" + txtHOTEN.Text + "', N'" + txtGIOITINH.Text + "', N'" + txtNAMSINH.Text + "', '" + txtEMAIL.Text + "', '" + txtDIENTHOAI.Text + "', N'" + txtDIACHI.Text + "')";
                        HamXuLy.RunSQL(sqlThem);
                        MessageBox.Show("Thêm Thành Công");
                        showKH();

                        HUY();
                        HamXuLy.disconnect();

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
                    string sqlSua = "UPDATE KHACHHANG SET " +
                    "HOTEN = N'" + txtHOTEN.Text + "', " +
                    "GIOITINH = N'" + txtGIOITINH.Text + "', " +
                    "NAMSINH = '" + txtNAMSINH.Text + "', " +
                    "EMAIL = '" + txtEMAIL.Text + "', " +
                    "SDT = '" + txtDIENTHOAI.Text + "', " +
                    "DIACHI = N'" + txtDIACHI.Text + "' " +
                    "WHERE IDKH = '" + txtMAKH.Text + "'";

                    HamXuLy.RunSQL(sqlSua);

                    MessageBox.Show("Sửa Thành Công");
                    showKH();
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
                string sqlTIM = "SELECT * FROM KHACHHANG WHERE HOTEN LIKE N'%" + txtTIMKIEM.Text + "%'";
                if (HamXuLy.TruyVan(sqlTIM, dtTIM))
                {

                    if (dtTIM.Rows.Count > 0)
                    {
                        luoiKH.DataSource = dtTIM;

                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy Khách hàng nào có tên " + txtTIMKIEM.Text);
                }
            }
        }

        private void btnRESET_Click(object sender, EventArgs e)
        {
            showKH();
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
