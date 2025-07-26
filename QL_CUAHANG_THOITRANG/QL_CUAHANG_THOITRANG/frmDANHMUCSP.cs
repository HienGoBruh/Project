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
    public partial class frmDANHMUCSP : Form
    {
        public frmDANHMUCSP()
        {
            InitializeComponent();
        }
        
        private void frmDANHMUCSP_Load(object sender, EventArgs e)
        {
            HamXuLy.connect();
            txtTIMKIEM.Text = "Nhập tên Danh Mục";
            showDM();
            pnlDM.Enabled = false;
        }

        private void showDM()
        {
            DataTable dtDM = new DataTable();
            HamXuLy.connect();
            dtDM.Clear();
            String sqlDANHMUC = "select * From DANHMUCSP";
            if (HamXuLy.TruyVan(sqlDANHMUC, dtDM))
            {
                luoiDM.DataSource = dtDM;
                //Trang trí lưới
                luoiDM.Columns[0].HeaderText = "ID DANH MỤC";
                luoiDM.Columns[0].Width = 100;
                luoiDM.Columns[1].HeaderText = "TÊN DANH MỤC";
                luoiDM.Columns[1].Width = 200;
                
                luoiDM.EnableHeadersVisualStyles = false;
                luoiDM.ColumnHeadersDefaultCellStyle.BackColor = Color.Cyan;
            }
        }
        private void HUY()
        {
            pnlDM.Enabled = false;
            btnSUA.Enabled = true;
            btnXOA.Enabled = true;
            btnTHEM.Enabled = true;
            txtIDDM.ResetText();
            txtTENDM.ResetText();

            pnlDM.Enabled = false;
        }

        private void btnHUY_Click(object sender, EventArgs e)
        {
            HUY();
        }

        private void btnTHEM_Click(object sender, EventArgs e)
        {
            btnSUA.Enabled = false;
            btnXOA.Enabled = false;

            txtIDDM.ResetText();
            txtTENDM.ResetText();
            pnlDM.Enabled = true;
            txtIDDM.Enabled = false;
            txtIDDM.Text = HamXuLy.TaoIDMoi("DANHMUCSP", "IDDM", "DM"); //Tên bảng, ID, tiền tố
            txtTENDM.Focus();
        }

        private void btnSUA_Click(object sender, EventArgs e)
        {
            pnlDM.Enabled = true;
            btnSUA.Enabled = true;
            btnXOA.Enabled = false;
            btnTHEM.Enabled = false;
            txtIDDM.Enabled = false;
            if (txtIDDM.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn gì để sửa");
                HUY();
            }
        }

        private void luoiDM_Click(object sender, EventArgs e)
        {
            txtIDDM.Text = luoiDM.CurrentRow.Cells["IDDM"].Value.ToString();
            txtTENDM.Text = luoiDM.CurrentRow.Cells["TENDM"].Value.ToString();
            
        }

        private void btnXOA_Click(object sender, EventArgs e)
        {
            if (txtIDDM.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn gì để xóa", "Thông báo");
            }
            else
            {
                HamXuLy.connect();
                //Truy vấn sql
                String sqlDelete = "DELETE FROM DANHMUCSP WHERE IDDM = '" + txtIDDM.Text + "'";
                if (MessageBox.Show("Bạn có muốn xóa không ?", "XÁC NHẬN XÓA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        HamXuLy.RunSQL(sqlDelete);
                        MessageBox.Show("Xóa Thành Công");
                        showDM();

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
                if (txtTENDM.Text == "")
                {
                    MessageBox.Show("Không được để trống Tên Danh Mục", "Thông báo");
                    txtTENDM.Focus();
                }
                else
                {
                    try
                    {
                        HamXuLy.connect();
                        //Xử lý đưa dữ liệu trên combo box về MACL thay vì TENCL
                        string sqlThem = "INSERT DANHMUCSP (IDDM, TENDM) VALUES ('" + txtIDDM.Text + "', N'" + txtTENDM.Text + "')";
                        HamXuLy.RunSQL(sqlThem);
                        MessageBox.Show("Thêm Thành Công");
                        showDM();

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
                    string sqlSua = "UPDATE DANHMUCSP SET " +
                    "TENDM = '" + txtTENDM.Text + "' " +
                    "WHERE IDDM = '" + txtIDDM.Text + "'";

                    HamXuLy.RunSQL(sqlSua);

                    MessageBox.Show("Sửa Thành Công");
                    showDM();
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

        private void btnHUY_BackgroundImageChanged(object sender, EventArgs e)
        {

        }

        

        private void btnRESET_Click(object sender, EventArgs e)
        {
            showDM();
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
                string sqlTIM = "SELECT * FROM DANHMUCSP WHERE TENDM LIKE N'%" + txtTIMKIEM.Text + "%'";
                if (HamXuLy.TruyVan(sqlTIM, dtTIM))
                {

                    if (dtTIM.Rows.Count > 0)
                    {
                        luoiDM.DataSource = dtTIM;

                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy Danh mục nào có tên " + txtTIMKIEM.Text);
                }
            }
        }

        private void txtTIMKIEM_Enter(object sender, EventArgs e)
        {
            if (txtTIMKIEM.Text == "Nhập tên Danh Mục")
            {
                txtTIMKIEM.Text = "";
                txtTIMKIEM.ForeColor = Color.Black;
            }
        }

        private void txtTIMKIEM_Leave(object sender, EventArgs e)
        {
            if (txtTIMKIEM.Text == "")
            {
                txtTIMKIEM.Text = "Nhập tên Danh Mục";
                txtTIMKIEM.ForeColor = Color.Gray;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

    }
}
