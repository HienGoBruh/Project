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
    public partial class frmSIZE : Form
    {
        public frmSIZE()
        {
            InitializeComponent();
        }

        private void showSIZE()
        {
            DataTable dtSIZE = new DataTable();
            HamXuLy.connect();

            String sqlSIZE = "select * From SIZE";
            dtSIZE.Clear();
            if (HamXuLy.TruyVan(sqlSIZE, dtSIZE))
            {
                luoiSIZE.DataSource = dtSIZE;
                //Trang trí lưới
                luoiSIZE.Columns[0].HeaderText = "MÃ SIZE";
                luoiSIZE.Columns[0].Width = 80;
                luoiSIZE.Columns[1].HeaderText = "TÊN SIZE";
                luoiSIZE.Columns[1].Width = 100;
                luoiSIZE.Columns[2].HeaderText = "MÔ TẢ";
                luoiSIZE.Columns[2].Width = 150;

                luoiSIZE.EnableHeadersVisualStyles = false;
                luoiSIZE.ColumnHeadersDefaultCellStyle.BackColor = Color.Cyan;
            }
        }

        private void frmSIZE_Load(object sender, EventArgs e)
        {
            txtTIMKIEM.Text = "Nhập tên Size";
            showSIZE();
            pnlSIZE.Enabled = false;
        }

        private void luoiSIZE_Click(object sender, EventArgs e)
        {
            txtMASIZE.Text = luoiSIZE.CurrentRow.Cells["IDSIZE"].Value.ToString();
            txtTENSIZE.Text = luoiSIZE.CurrentRow.Cells["TENSIZE"].Value.ToString();
            txtMOTAS.Text = luoiSIZE.CurrentRow.Cells["MOTA"].Value.ToString();
        }
        private void HUY()
        {
            btnSUA.Enabled = true;
            btnXOA.Enabled = true;
            btnTHEM.Enabled = true;
            txtMASIZE.ResetText();
            txtTENSIZE.ResetText();
            txtMOTAS.ResetText();
            pnlSIZE.Enabled = false;
        }
        private void btnHUY_Click(object sender, EventArgs e)
        {
            HUY();
        }

        private void btnTHEM_Click(object sender, EventArgs e)
        {
            btnSUA.Enabled = false;
            btnXOA.Enabled = false;
            txtMASIZE.ResetText();
            txtTENSIZE.ResetText();
            txtMOTAS.ResetText();
            pnlSIZE.Enabled = true;
            txtMASIZE.Enabled = false;
            txtMASIZE.Text = HamXuLy.TaoIDMoi("SIZE", "IDSIZE", "SZ");
            txtTENSIZE.Focus();
        }

        private void btnXOA_Click(object sender, EventArgs e)
        {
            if (txtMASIZE.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn gì để xóa", "Thông báo");
            }
            else
            {
                HamXuLy.connect();
                //Truy vấn sql
                String sqlDelete = "DELETE FROM SIZE WHERE IDSIZE = '" + txtMASIZE.Text + "'";
                if (MessageBox.Show("Bạn có muốn xóa không ?", "XÁC NHẬN XÓA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        HamXuLy.RunSQL(sqlDelete);
                        MessageBox.Show("Xóa Thành Công");
                        showSIZE();

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
            pnlSIZE.Enabled = true;
            btnXOA.Enabled = false;
            btnTHEM.Enabled = false;
            txtMASIZE.Enabled = false;

            if (txtMASIZE.Text == "")
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
                if (txtTENSIZE.Text == "")
                {
                    MessageBox.Show("Không được để trống tên màu", "Thông báo");
                    txtTENSIZE.Focus();
                }
                else
                {
                    try
                    {
                        HamXuLy.connect();
                        //Xử lý đưa dữ liệu trên combo box về MACL thay vì TENCL

                        string sqlThem = "INSERT SIZE (IDSIZE, TENSIZE, MOTA) VALUES ('" + txtMASIZE.Text + "', N'" + txtTENSIZE.Text + "', N'" + txtMOTAS.Text + "')";
                        HamXuLy.RunSQL(sqlThem);
                        MessageBox.Show("Thêm Thành Công");
                        showSIZE();

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
                    string sqlSua = "UPDATE SIZE SET " +
                    "IDSIZE = '" + txtMASIZE.Text + "', " +
                    "TENSIZE = '" + txtTENSIZE.Text + "', " +
                    "MOTA = '" + txtMOTAS.Text + "' " +
                    "WHERE IDSIZE = '" + txtMASIZE.Text + "'";

                    HamXuLy.RunSQL(sqlSua);

                    MessageBox.Show("Sửa Thành Công");
                    showSIZE();
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
                string sqlTIM = "SELECT * FROM SIZE WHERE TENSIZE LIKE N'%" + txtTIMKIEM.Text + "%'";
                if (HamXuLy.TruyVan(sqlTIM, dtTIM))
                {

                    if (dtTIM.Rows.Count > 0)
                    {
                        luoiSIZE.DataSource = dtTIM;

                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy Size nào có tên " + txtTIMKIEM.Text);
                }
            }
        }

        private void btnRESET_Click(object sender, EventArgs e)
        {
            showSIZE();
        }

        private void txtTIMKIEM_Enter(object sender, EventArgs e)
        {
            if (txtTIMKIEM.Text == "Nhập tên Size")
            {
                txtTIMKIEM.Text = "";
                txtTIMKIEM.ForeColor = Color.Black;
            }
        }

        private void txtTIMKIEM_Leave(object sender, EventArgs e)
        {
            if (txtTIMKIEM.Text == "")
            {
                txtTIMKIEM.Text = "Nhập tên Size";
                txtTIMKIEM.ForeColor = Color.Gray;
            }
        }


    }
}
