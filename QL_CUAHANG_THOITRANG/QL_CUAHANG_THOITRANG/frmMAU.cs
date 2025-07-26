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
    public partial class frmMAU : Form
    {
        public frmMAU()
        {
            InitializeComponent();
        }

        private void showMAU()
        {
            DataTable dtMAU = new DataTable();
            HamXuLy.connect();

            String sqlMAU = "select * From MAU";
            dtMAU.Clear();
            if (HamXuLy.TruyVan(sqlMAU, dtMAU))
            {
                luoiMAU.DataSource = dtMAU;
                //Trang trí lưới
                luoiMAU.Columns[0].HeaderText = "MÃ MÀU";
                luoiMAU.Columns[0].Width = 100;
                luoiMAU.Columns[1].HeaderText = "TÊN MÀU";
                luoiMAU.Columns[1].Width = 150;
                luoiMAU.Columns[2].HeaderText = "MÔ TẢ";
                luoiMAU.Columns[2].Width = 190;

                luoiMAU.EnableHeadersVisualStyles = false;
                luoiMAU.ColumnHeadersDefaultCellStyle.BackColor = Color.Cyan;
            }
        }

        private void frmMAU_Load(object sender, EventArgs e)
        {
            txtTIMKIEM.Text = "Nhập tên Màu";
            showMAU();
            pnlMAU.Enabled = false;
        }
        private void HUY()
        {
            btnSUA.Enabled = true;
            btnXOA.Enabled = true;
            btnTHEM.Enabled = true;
            txtMAMAU.ResetText();
            txtTENMAU.ResetText();
            txtMOTAM.ResetText();   
            pnlMAU.Enabled = false;
        }
        private void btnHUY_Click(object sender, EventArgs e)
        {
            HUY();
        }

        private void luoiMAU_Click(object sender, EventArgs e)
        {
            txtMAMAU.Text = luoiMAU.CurrentRow.Cells["IDMAU"].Value.ToString();
            txtTENMAU.Text = luoiMAU.CurrentRow.Cells["TENMAU"].Value.ToString();
            txtMOTAM.Text = luoiMAU.CurrentRow.Cells["MOTA"].Value.ToString();
        }

        private void btnTHEM_Click(object sender, EventArgs e)
        {
            btnSUA.Enabled = false;
            btnXOA.Enabled = false;
            txtMAMAU.ResetText();
            txtTENMAU.ResetText();
            txtMOTAM.ResetText();
            pnlMAU.Enabled = true;
            txtMAMAU.Enabled = false;
            txtMAMAU.Text = HamXuLy.TaoIDMoi("MAU", "IDMAU", "M");
            txtTENMAU.Focus();
            
        }

        private void btnSUA_Click(object sender, EventArgs e)
        {
            pnlMAU.Enabled = true;
            btnXOA.Enabled = false;
            btnTHEM.Enabled = false;
            txtMAMAU.Enabled = false;

            if (txtMAMAU.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn gì để sửa");
                HUY();
            }
        }

        private void btnXOA_Click(object sender, EventArgs e)
        {
            if (txtMAMAU.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn gì để xóa", "Thông báo");
            }
            else
            {
                HamXuLy.connect();
                //Truy vấn sql
                String sqlDelete = "DELETE FROM MAU WHERE IDMAU = '" + txtMAMAU.Text + "'";
                if (MessageBox.Show("Bạn có muốn xóa không ?", "XÁC NHẬN XÓA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        HamXuLy.RunSQL(sqlDelete);
                        MessageBox.Show("Xóa Thành Công");
                        showMAU();

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
            //Lưu Thêm
            
            if (btnTHEM.Enabled == true && btnSUA.Enabled == false)
            {
                if (txtTENMAU.Text == "")
                {
                    MessageBox.Show("Không được để trống tên màu", "Thông báo");
                    txtTENMAU.Focus();
                }
                else
                {
                    try
                        {
                            HamXuLy.connect();
                            //Xử lý đưa dữ liệu trên combo box về MACL thay vì TENCL

                            string sqlThem = "INSERT MAU (IDMAU, TENMAU, MOTA) VALUES ('" + txtMAMAU.Text + "', N'" + txtTENMAU.Text + "', N'" + txtMOTAM.Text + "')";
                            HamXuLy.RunSQL(sqlThem);
                            MessageBox.Show("Thêm Thành Công");
                            showMAU();

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
                        string sqlSua = "UPDATE MAU SET " +
                        "IDMAU = '" + txtMAMAU.Text + "', " +
                        "TENMAU = '" + txtTENMAU.Text + "', " +
                        "MOTA = '" + txtMOTAM.Text + "' " +
                        "WHERE IDMAU = '" + txtMAMAU.Text + "'";

                        HamXuLy.RunSQL(sqlSua);

                        MessageBox.Show("Sửa Thành Công");
                        showMAU();
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
                string sqlTIM = "SELECT * FROM MAU WHERE TENMAU LIKE N'%" + txtTIMKIEM.Text + "%'";
                if (HamXuLy.TruyVan(sqlTIM, dtTIM))
                {

                    if (dtTIM.Rows.Count > 0)
                    {
                        luoiMAU.DataSource = dtTIM;

                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy Màu nào có tên " + txtTIMKIEM.Text);
                }
            }
        }

        private void btnRESET_Click(object sender, EventArgs e)
        {
            showMAU();
        }

        private void txtTIMKIEM_Enter(object sender, EventArgs e)
        {
            if (txtTIMKIEM.Text == "Nhập tên Màu")
            {
                txtTIMKIEM.Text = "";
                txtTIMKIEM.ForeColor = Color.Black;
            }
        }

        private void txtTIMKIEM_Leave(object sender, EventArgs e)
        {
            if (txtTIMKIEM.Text == "")
            {
                txtTIMKIEM.Text = "Nhập tên Màu";
                txtTIMKIEM.ForeColor = Color.Gray;
            }
        }

    }
}
