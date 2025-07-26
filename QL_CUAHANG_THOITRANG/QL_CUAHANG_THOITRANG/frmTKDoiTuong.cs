using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_CUAHANG_THOITRANG
{
    public partial class frmTKDoiTuong : Form
    {
        public frmTKDoiTuong()
        {
            InitializeComponent();
        }

        private void frmTKDoiTuong_Load(object sender, EventArgs e)
        {
            HamXuLy.connect();
            cboDT.Items.Add("Khách hàng");
            cboDT.Items.Add("Nhà cung cấp");
            cboDT.Items.Add("Nhân viên");

            dgvTKDT.EnableHeadersVisualStyles = false;
            dgvTKDT.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 120, 215);
            dgvTKDT.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvTKDT.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            dgvTKDT.DefaultCellStyle.Font = new Font("Segoe UI", 12);
            dgvTKDT.DefaultCellStyle.BackColor = Color.White;
            dgvTKDT.DefaultCellStyle.ForeColor = Color.Black;
            dgvTKDT.DefaultCellStyle.SelectionBackColor = Color.FromArgb(220, 240, 255);
            dgvTKDT.DefaultCellStyle.SelectionForeColor = Color.Black;

            dgvTKDT.GridColor = Color.LightGray;
            dgvTKDT.RowTemplate.Height = 30;
            dgvTKDT.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvTKDT.ColumnHeadersHeight = 35;
            dgvTKDT.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTKDT.MultiSelect = false;
            dgvTKDT.ReadOnly = true;

            dgvTKDT.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvTKDT.BackgroundColor = Color.WhiteSmoke;
        }

        private void btnTKDT_Click(object sender, EventArgs e)
        {
            if (cboDT.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn loại đối tượng cần tìm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tuKhoa = txtTKDT.Text.Trim();
            string query = "";
            SqlParameter[] parameters = null;

            if (cboDT.SelectedItem.ToString() == "Khách hàng")
            {
                if (string.IsNullOrEmpty(tuKhoa))
                    query = "SELECT * FROM KHACHHANG";
                else
                {
                    query = "SELECT * FROM KHACHHANG WHERE HOTEN LIKE @SearchTerm";
                    parameters = new SqlParameter[] 
                    { 
                        new SqlParameter("@SearchTerm", "%" + tuKhoa + "%") 
                    };
                }
            }
            else if (cboDT.SelectedItem.ToString() == "Nhà cung cấp")
            {
                if (string.IsNullOrEmpty(tuKhoa))
                    query = "SELECT * FROM NHACUNGCAP";
                else
                {
                    query = "SELECT * FROM NHACUNGCAP WHERE TENNCC LIKE @SearchTerm";
                    parameters = new SqlParameter[] 
                    { 
                        new SqlParameter("@SearchTerm", "%" + tuKhoa + "%") 
                    };
                }
            }
            else if (cboDT.SelectedItem.ToString() == "Nhân viên")
            {
                if (string.IsNullOrEmpty(tuKhoa))
                    query = "SELECT * FROM NHANVIEN";
                else
                {
                    query = "SELECT * FROM NHANVIEN WHERE HOTEN LIKE @SearchTerm";
                    parameters = new SqlParameter[] 
                    {
                        new SqlParameter("@SearchTerm", "%" + tuKhoa + "%") 
                    };
                }
            }

            DataTable dt = HamXuLy.TimKiem(query, parameters);

            if (dt != null && dt.Rows.Count > 0)
            {
                dgvTKDT.DataSource = dt;
                dgvTKDT.Refresh();
            }
            else
            {
                MessageBox.Show("Không tìm thấy dữ liệu phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvTKDT.DataSource = null;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
