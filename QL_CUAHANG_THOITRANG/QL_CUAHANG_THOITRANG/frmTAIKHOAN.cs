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
    public partial class frmTAIKHOAN : Form
    {
        public frmTAIKHOAN()
        {
            InitializeComponent();
        }
        private void showUSER()
        {
            DataTable dtUSER = new DataTable();
            HamXuLy.connect();

            String sqlTAIKHOAN = "select * From TAIKHOAN";
            dtUSER.Clear();
            if (HamXuLy.TruyVan(sqlTAIKHOAN, dtUSER))
            {
                luoiUSER.DataSource = dtUSER;
                //Trang trí lưới
                luoiUSER.Columns[0].HeaderText = "ID TÀI KHOẢN";
                luoiUSER.Columns[0].Width = 100;
                luoiUSER.Columns[1].HeaderText = "HỌ TÊN";
                luoiUSER.Columns[1].Width = 150;
                luoiUSER.Columns[2].HeaderText = "TÊN ĐĂNG NHẬP";
                luoiUSER.Columns[2].Width = 100;
                luoiUSER.Columns[3].HeaderText = "MẬT KHẨU";
                luoiUSER.Columns[3].Width = 100;
                luoiUSER.Columns[4].HeaderText = "NHÓM";
                luoiUSER.Columns[4].Width = 150;
                

                luoiUSER.EnableHeadersVisualStyles = false;
                luoiUSER.ColumnHeadersDefaultCellStyle.BackColor = Color.Cyan;
            }
        }
        private void panel(bool dieuKien)
        {
            if (dieuKien)
            {
                txtIDUSER.Enabled = true;
                txtHOTEN.Enabled = true;
                txtTENDN.Enabled = true;
                txtMK.Enabled = true;
                txtNHOM.Enabled = true;
            }
            else
            {
                txtIDUSER.Enabled = false;
                txtHOTEN.Enabled = false;
                txtTENDN.Enabled = false;
                txtMK.Enabled = false;
                txtNHOM.Enabled = false;
            }
        }
        private void frmTAIKHOAN_Load(object sender, EventArgs e)
        {
            HamXuLy.connect();
            showUSER();
            txtTIMKIEM.Text = "Nhập họ tên chủ tài khoản";
            panel(false);
            txtMK.PasswordChar = '*';
            ckbHIENMK.Enabled = true;
        }

        private void luoiUSER_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 3 && e.Value != null)
            {
                e.Value = "******";
                e.FormattingApplied = true;
            }
        }
        private void HUY()
        {
            
            btnSUA.Enabled = true;
            btnXOA.Enabled = true;
            btnTHEM.Enabled = true;
            txtIDUSER.ResetText();
            txtHOTEN.ResetText();
            txtTENDN.ResetText();
            txtMK.ResetText();
            txtNHOM.ResetText();
            panel(false);
            ckbHIENMK.Enabled = true;
        }
        private void btnHUY_Click(object sender, EventArgs e)
        {
            HUY();
        }

        private void btnTHEM_Click(object sender, EventArgs e)
        {
            btnSUA.Enabled = false;
            btnXOA.Enabled = false;

            txtIDUSER.ResetText();
            txtHOTEN.ResetText();
            txtTENDN.ResetText();
            txtMK.ResetText();
            txtNHOM.ResetText();
            panel(true);
            txtIDUSER.Enabled = false;
            txtIDUSER.Text = HamXuLy.TaoIDMoi("TAIKHOAN", "IDUSER", "U");
            txtHOTEN.Focus();
        }

        private void luoiUSER_Click(object sender, EventArgs e)
        {
            txtIDUSER.Text = luoiUSER.CurrentRow.Cells["IDUSER"].Value.ToString();
            txtHOTEN.Text = luoiUSER.CurrentRow.Cells["HOTEN"].Value.ToString();
            txtTENDN.Text = luoiUSER.CurrentRow.Cells["TENDN"].Value.ToString();
            txtMK.Text = luoiUSER.CurrentRow.Cells["MATKHAU"].Value.ToString();
            txtNHOM.Text = luoiUSER.CurrentRow.Cells["NHOM"].Value.ToString();
        }

        private void ckbHIENMK_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbHIENMK.Checked == true)
            {
                txtMK.PasswordChar = '\0';
            }
            else
            {
                txtMK.PasswordChar = '*';
            }
        }

        private void btnXOA_Click(object sender, EventArgs e)
        {
            if (txtIDUSER.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn gì để xóa", "Thông báo");
            }
            else
            {
                HamXuLy.connect();
                //Truy vấn sql
                String sqlDelete = "DELETE FROM TAIKHOAN WHERE IDUSER = '" + txtIDUSER.Text + "'";
                if (MessageBox.Show("Bạn có muốn xóa không ?", "XÁC NHẬN XÓA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        HamXuLy.RunSQL(sqlDelete);
                        MessageBox.Show("Xóa Thành Công");
                        showUSER();

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
            panel(true);
            btnSUA.Enabled = true;
            btnXOA.Enabled = false;
            btnTHEM.Enabled = false;
            txtIDUSER.Enabled = false;
            if (txtIDUSER.Text == "")
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
                if (txtHOTEN.Text == "")
                {
                    MessageBox.Show("Không được để trống Họ tên", "Thông báo");
                    txtHOTEN.Focus();
                }
                else if (txtTENDN.Text == "")
                {
                    MessageBox.Show("Không được để trống Tên đăng nhập", "Thông báo");
                    txtTENDN.Focus();
                }
                else if (txtMK.Text == "")
                {
                    MessageBox.Show("Không được để trống Mật khẩu", "Thông báo");
                    txtMK.Focus();
                }
                else if (txtNHOM.Text == "")
                {
                    MessageBox.Show("Không được để trống Nhóm", "Thông báo");
                    txtNHOM.Focus();
                }
                else
                {
                    try
                    {
                        HamXuLy.connect();
                        //Xử lý đưa dữ liệu trên combo box về MACL thay vì TENCL

                        string sqlThem = "INSERT TAIKHOAN (IDUSER, HOTEN, TENDN, MATKHAU, NHOM) VALUES ('" + txtIDUSER.Text + "', N'" + txtHOTEN.Text + "', N'" + txtTENDN.Text + "', N'" + txtMK.Text + "', '" + txtNHOM.Text + "')";
                        HamXuLy.RunSQL(sqlThem);
                        MessageBox.Show("Thêm Thành Công");
                        showUSER();

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
                    string sqlSua = "UPDATE TAIKHOAN SET " +
                    "HOTEN = N'" + txtHOTEN.Text + "', " +
                    "TENDN = N'" + txtTENDN.Text + "', " +
                    "MATKHAU = '" + txtMK.Text + "', " +
                    "NHOM = '" + txtNHOM.Text + "' " +
                    "WHERE IDUSER = '" + txtIDUSER.Text + "'";

                    HamXuLy.RunSQL(sqlSua);

                    MessageBox.Show("Sửa Thành Công");
                    showUSER();
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
                HamXuLy.connect();
                string sqlTIM = "SELECT * FROM TAIKHOAN WHERE HOTEN LIKE N'%" + txtTIMKIEM.Text + "%'";
                if (HamXuLy.TruyVan(sqlTIM, dtTIM))
                {

                    if (dtTIM.Rows.Count > 0)
                    {
                        luoiUSER.DataSource = dtTIM;

                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy Tài khoản nào của người dùng tên " + txtTIMKIEM.Text);
                }
            }
        }

        private void btnRESET_Click(object sender, EventArgs e)
        {
            showUSER();
        }

        private void txtTIMKIEM_Enter(object sender, EventArgs e)
        {
            if (txtTIMKIEM.Text == "Nhập họ tên chủ tài khoản")
            {
                txtTIMKIEM.Text = "";
                txtTIMKIEM.ForeColor = Color.Black;
            }
        }

        private void txtTIMKIEM_Leave(object sender, EventArgs e)
        {
            if (txtTIMKIEM.Text == "")
            {
                txtTIMKIEM.Text = "Nhập họ tên chủ tài khoản";
                txtTIMKIEM.ForeColor = Color.Gray;
            }
        }


    }
}
