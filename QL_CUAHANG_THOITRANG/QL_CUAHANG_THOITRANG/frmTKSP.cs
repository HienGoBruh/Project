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
    public partial class frmTKSP : Form
    {
        public frmTKSP()
        {
            InitializeComponent();
        }

        private void frmTKSP_Load(object sender, EventArgs e)
        {
            HamXuLy.connect();
            cboMuc.Items.Add("Sản phẩm");
            cboMuc.Items.Add("Chất liệu");
            cboMuc.Items.Add("Danh mục");

            dgvTKMuc.EnableHeadersVisualStyles = false;
            dgvTKMuc.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 120, 215);
            dgvTKMuc.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvTKMuc.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            dgvTKMuc.DefaultCellStyle.Font = new Font("Segoe UI", 12);
            dgvTKMuc.DefaultCellStyle.BackColor = Color.White;
            dgvTKMuc.DefaultCellStyle.ForeColor = Color.Black;
            dgvTKMuc.DefaultCellStyle.SelectionBackColor = Color.FromArgb(220, 240, 255);
            dgvTKMuc.DefaultCellStyle.SelectionForeColor = Color.Black;

            dgvTKMuc.GridColor = Color.LightGray;
            dgvTKMuc.RowTemplate.Height = 30;
            dgvTKMuc.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvTKMuc.ColumnHeadersHeight = 35;
            dgvTKMuc.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTKMuc.MultiSelect = false;
            dgvTKMuc.ReadOnly = true;

            dgvTKMuc.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvTKMuc.BackgroundColor = Color.WhiteSmoke;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnTKMuc_Click(object sender, EventArgs e)
        {
            if (cboMuc.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn mục cần tìm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tuKhoa = txtTKMuc.Text.Trim();
            string query = "";
            SqlParameter[] parameters = null;

            if (cboMuc.SelectedItem.ToString() == "Sản phẩm")
            {
                if (string.IsNullOrEmpty(tuKhoa))
                    query = "SELECT * FROM SANPHAM";
                else
                {
                    query = "SELECT * FROM SANPHAM WHERE TENSP LIKE @SearchTerm";
                    parameters = new SqlParameter[] 
                    { 
                        new SqlParameter("@SearchTerm", "%" + tuKhoa + "%") 
                    };
                }
            }
            else if (cboMuc.SelectedItem.ToString() == "Chất liệu")
            {
                if (string.IsNullOrEmpty(tuKhoa))
                    query = "SELECT * FROM CHATLIEU";
                else
                {
                    query = "SELECT * FROM CHATLIEU WHERE TENCL LIKE @SearchTerm";
                    parameters = new SqlParameter[] 
                    { 
                        new SqlParameter("@SearchTerm", "%" + tuKhoa + "%") 
                    };
                }
            }
            else if (cboMuc.SelectedItem.ToString() == "Danh mục")
            {
                if (string.IsNullOrEmpty(tuKhoa))
                    query = "SELECT * FROM DANHMUCSP";
                else
                {
                    query = "SELECT * FROM DANHMUCSP WHERE TENDM LIKE @SearchTerm";
                    parameters = new SqlParameter[] 
                    {
                        new SqlParameter("@SearchTerm", "%" + tuKhoa + "%") 
                    };
                }
            }

            DataTable dt = HamXuLy.TimKiem(query, parameters);

            if (dt != null && dt.Rows.Count > 0)
            {
                dgvTKMuc.DataSource = dt;
                dgvTKMuc.Refresh();
            }
            else
            {
                MessageBox.Show("Không tìm thấy dữ liệu phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvTKMuc.DataSource = null;
            }
        }
    }
}