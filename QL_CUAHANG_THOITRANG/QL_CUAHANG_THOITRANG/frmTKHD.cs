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
    public partial class frmTKHD : Form
    {
        public frmTKHD()
        {
            InitializeComponent();
        }

        private void frmTKHD_Load(object sender, EventArgs e)
        {
            HamXuLy.connect();
            cboTK.Items.Add("Hóa đơn nhập");
            cboTK.Items.Add("Hóa đơn bán");

            dgvTK.EnableHeadersVisualStyles = false;
            dgvTK.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 120, 215);
            dgvTK.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvTK.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            dgvTK.DefaultCellStyle.Font = new Font("Segoe UI", 12);
            dgvTK.DefaultCellStyle.BackColor = Color.White;
            dgvTK.DefaultCellStyle.ForeColor = Color.Black;
            dgvTK.DefaultCellStyle.SelectionBackColor = Color.FromArgb(220, 240, 255);
            dgvTK.DefaultCellStyle.SelectionForeColor = Color.Black;

            dgvTK.GridColor = Color.LightGray;
            dgvTK.RowTemplate.Height = 30;
            dgvTK.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvTK.ColumnHeadersHeight = 35;
            dgvTK.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTK.MultiSelect = false;
            dgvTK.ReadOnly = true;

            dgvTK.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvTK.BackgroundColor = Color.WhiteSmoke;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTK_Click(object sender, EventArgs e)
        {
            if (cboTK.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn hóa đơn cần tìm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tuKhoa = txtTK.Text.Trim();
            string query = "";
            SqlParameter[] parameters = null;

            if (cboTK.SelectedItem.ToString() == "Hóa đơn bán")
            {
                if (string.IsNullOrEmpty(tuKhoa))
                    query = "SELECT * FROM HOADONBAN";
                else
                {
                    query = "SELECT * FROM HOADONBAN hdb JOIN KHACHHANG kh ON hdb.IDKH = kh.IDKH WHERE kh.HOTEN LIKE @SearchTerm";
                    parameters = new SqlParameter[] 
                    { 
                        new SqlParameter("@SearchTerm", "%" + tuKhoa + "%") 
                    };
                }
            }
            else if (cboTK.SelectedItem.ToString() == "Hóa đơn nhập")
            {
                if (string.IsNullOrEmpty(tuKhoa))
                    query = "SELECT * FROM HOADONNHAP";
                else
                {
                    query = "SELECT * FROM HOADONNHAP hdn JOIN NHACUNGCAP ncc ON hdn.IDNCC = ncc.IDNCC WHERE ncc.TENNCC LIKE @SearchTerm";
                    parameters = new SqlParameter[] 
                    { 
                        new SqlParameter("@SearchTerm", "%" + tuKhoa + "%") 
                    };
                }
            }

            DataTable dt = HamXuLy.TimKiem(query, parameters);

            if (dt != null && dt.Rows.Count > 0)
            {
                dgvTK.DataSource = dt;
                dgvTK.Refresh();
            }
            else
            {
                MessageBox.Show("Không tìm thấy dữ liệu phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvTK.DataSource = null;
            }
        }

        private void btnCT_Click(object sender, EventArgs e)
        {
            if (cboTK.Text == "")
            {
                MessageBox.Show("Vui lòng chọn loại hóa đơn cần xem rôi nhấn tìm kiếm.");
                cboTK.Focus();
            }
            else if (cboTK.SelectedItem.ToString() == "Hóa đơn bán")
            {
                if (dgvTK.CurrentRow != null)
                {

                    string maHDB = dgvTK.CurrentRow.Cells["IDHDB"].Value.ToString();

                    frmXCTTKHD frmb = new frmXCTTKHD();
                    frmb.MaHDB = maHDB;
                    frmb.tkHDB = true;
                    frmb.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một hóa đơn cần xem chi tiết.");
                }
            }
            else if (cboTK.SelectedItem.ToString() == "Hóa đơn nhập")
            {
                if (dgvTK.CurrentRow != null)
                {

                    string maHDN = dgvTK.CurrentRow.Cells["IDHDN"].Value.ToString();

                    frmXCTTKHD frm = new frmXCTTKHD();
                    frm.MaHDN = maHDN;
                    frm.tkHDN = true;
                    frm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một hóa đơn cần xem chi tiết.");
                }
            }
        }
    }
}
