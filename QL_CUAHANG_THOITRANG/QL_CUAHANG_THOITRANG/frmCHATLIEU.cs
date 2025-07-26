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
    public partial class frmCHATLIEU : Form
    {
        DataTable dtCL = new DataTable();
        public frmCHATLIEU()
        {
            InitializeComponent();
        }
        private void showCL()
        {
            
            HamXuLy.connect();
            string sqlCHATLIEU = "select * From CHATLIEU";
            dtCL.Clear();
            if (HamXuLy.TruyVan(sqlCHATLIEU, dtCL))
            {
                
                luoiCL.DataSource = dtCL;
                //Trang trí lưới
                luoiCL.Columns[0].HeaderText = "MÃ CHẤT LIỆU";
                luoiCL.Columns[0].Width = 100;
                luoiCL.Columns[1].HeaderText = "TÊN CHẤT LIỆU";
                luoiCL.Columns[1].Width = 200;
                luoiCL.Columns[2].HeaderText = "MÔ TẢ";
                luoiCL.Columns[2].Width = 200;

                luoiCL.EnableHeadersVisualStyles = false;
                luoiCL.ColumnHeadersDefaultCellStyle.BackColor = Color.Cyan;
            }
            
        }
        private void frmCHATLIEU_Load(object sender, EventArgs e)
        {
            HamXuLy.connect();
            txtTIMKIEM.Text = "Nhập tên Chất liệu"; 
            showCL();
            pnlCL.Enabled = false;
        }

        private void luoiCL_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void luoiCL_Click(object sender, EventArgs e)
        {
            txtMACL.Text = luoiCL.CurrentRow.Cells["IDCL"].Value.ToString();
            txtTENCL.Text = luoiCL.CurrentRow.Cells["TENCL"].Value.ToString();
            txtMOTA.Text = luoiCL.CurrentRow.Cells["MOTA"].Value.ToString();
        }

        private void HUY()
        {
            pnlCL.Enabled = false;
            btnSUA.Enabled = true;
            btnXOA.Enabled = true;
            btnTHEM.Enabled = true;
            txtMACL.ResetText();
            txtTENCL.ResetText();
            txtMOTA.ResetText();
            pnlCL.Enabled = false;
        }

        private void btnHUY_Click(object sender, EventArgs e)
        {
            HUY();
        }

        private void btnTHEM_Click(object sender, EventArgs e)
        {
            btnSUA.Enabled = false;
            btnXOA.Enabled = false;
            txtMACL.ResetText();
            txtTENCL.ResetText();
            txtMOTA.ResetText();
            pnlCL.Enabled = true;
            txtMACL.Enabled = false;
            txtTENCL.Focus();
            txtMACL.Text = HamXuLy.TaoIDMoi("CHATLIEU", "IDCL", "CL"); //Tên bảng, ID, tiền tố
        }

        private void btnSUA_Click(object sender, EventArgs e)
        {
            pnlCL.Enabled = true;
            btnSUA.Enabled = true;
            btnXOA.Enabled = false;
            btnTHEM.Enabled = false;
            txtMACL.Enabled = false;
            if (txtMACL.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn gì để sửa");
                HUY();
            }
        }

        private void btnXOA_Click(object sender, EventArgs e)
        {
            if (txtMACL.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn gì để xóa", "Thông báo");
            }
            else
            {
                HamXuLy.connect();
                //Truy vấn sql
                String sqlDelete = "DELETE FROM CHATLIEU WHERE IDCL = '" + txtMACL.Text + "'";
                if (MessageBox.Show("Bạn có muốn xóa không ?", "XÁC NHẬN XÓA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        HamXuLy.RunSQL(sqlDelete);
                        MessageBox.Show("Xóa Thành Công");
                        showCL();

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
                if (txtTENCL.Text == "")
                {
                    MessageBox.Show("Không được để trống Tên Chất Liệu", "Thông báo");
                    txtTENCL.Focus();
                }
                else
                {
                    try
                    {
                        HamXuLy.connect();
                        //Xử lý đưa dữ liệu trên combo box về MACL thay vì TENCL
                        string sqlThem = "INSERT CHATLIEU (IDCL, TENCL, MOTA) VALUES ('" + txtMACL.Text + "', N'" + txtTENCL.Text + "', N'" + txtMOTA.Text + "')";
                        HamXuLy.RunSQL(sqlThem);
                        MessageBox.Show("Thêm Thành Công");
                        showCL();

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
                    string sqlSua = "UPDATE CHATLIEU SET " +
                    "TENCL = '" + txtTENCL.Text + "', " +
                    "MOTA = '" + txtMOTA.Text + "' " +
                    "WHERE IDCL = '" + txtMACL.Text + "'";

                    HamXuLy.RunSQL(sqlSua);

                    MessageBox.Show("Sửa Thành Công");
                    showCL();
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
                string sqlTIM = "SELECT * FROM CHATLIEU WHERE TENCL LIKE N'%" + txtTIMKIEM.Text + "%'";
                if (HamXuLy.TruyVan(sqlTIM, dtTIM))
                {

                    if (dtTIM.Rows.Count > 0)
                    {
                        luoiCL.DataSource = dtTIM;
                        
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy Chất liệu nào có tên " + txtTIMKIEM.Text);
                }
            }
            
        }

        private void btnRESET_Click(object sender, EventArgs e)
        {
            
            showCL();
        }

        private void txtTIMKIEM_Enter(object sender, EventArgs e)
        {
            if (txtTIMKIEM.Text == "Nhập tên Chất liệu")
            {
                txtTIMKIEM.Text = "";
                txtTIMKIEM.ForeColor = Color.Black;
            }
        }

        private void txtTIMKIEM_Leave(object sender, EventArgs e)
        {
            if (txtTIMKIEM.Text == "")
            {
                txtTIMKIEM.Text = "Nhập tên Chất liệu"; 
                txtTIMKIEM.ForeColor = Color.Gray; 
            }
        }

    }
}
