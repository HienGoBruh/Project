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
    public partial class frmChucNang : Form
    {
        public frmChucNang()
        {
            InitializeComponent();
        }
        private void Reset()
        {
            txtMaCN.ResetText();
            txtTenCN.ResetText();
        }
        private void ShowCN()
        {
            DataTable dtCN = new DataTable();
            HamXuLy.connect();
            string sqlCN = "SELECT * FROM CHUCNANG";
            dtCN.Clear();
            if (HamXuLy.TruyVan(sqlCN, dtCN))
            {
                dgvCN.DataSource = dtCN;

                dgvCN.Columns[0].HeaderText = "Mã chức năng";
                dgvCN.Columns[0].Width = 200;
                dgvCN.Columns[1].HeaderText = "Tên chức năng";
                dgvCN.Columns[1].Width = 250;

                dgvCN.EnableHeadersVisualStyles = false;
                dgvCN.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 120, 215);
                dgvCN.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgvCN.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                dgvCN.DefaultCellStyle.Font = new Font("Segoe UI", 12);
                dgvCN.DefaultCellStyle.BackColor = Color.White;
                dgvCN.DefaultCellStyle.ForeColor = Color.Black;
                dgvCN.DefaultCellStyle.SelectionBackColor = Color.FromArgb(220, 240, 255);
                dgvCN.DefaultCellStyle.SelectionForeColor = Color.Black;

                dgvCN.GridColor = Color.LightGray;
                dgvCN.RowTemplate.Height = 30;
                dgvCN.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                dgvCN.ColumnHeadersHeight = 35;
                dgvCN.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvCN.MultiSelect = false;
                dgvCN.ReadOnly = true;

                dgvCN.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
                dgvCN.BackgroundColor = Color.WhiteSmoke;
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            panel1.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            txtMaCN.Enabled = false;
            Reset();
            txtMaCN.Text = HamXuLy.TaoIDMoi("CHUCNANG", "IDCN", "CN");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaCN.Text == "")
            {
                MessageBox.Show("Bạn nên chọn 1 chức năng trước khi sửa", "Thông báo");
            }
            else
            {
                panel1.Enabled = true;
                txtMaCN.Enabled = false;
                btnThem.Enabled = false;
                btnXoa.Enabled = false;
                txtTenCN.Focus();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaCN.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn chức năng!", "Thông báo");
            }
            else
            {
                HamXuLy.connect();
                string sqlDelete = "DELETE FROM CHUCNANG WHERE IDCN = '" + txtMaCN.Text + "'";
                if (MessageBox.Show("Bạn có chắc xóa chức năng này không!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    HamXuLy.RunSQL(sqlDelete);
                    MessageBox.Show("Xóa thành công!", "Thông báo");
                }
                ShowCN();
                Reset();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            //Thêm
            if (btnSua.Enabled == false && btnThem.Enabled == true)
            {
                if (txtMaCN.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập mã chức năng!", "Thông báo");
                    txtMaCN.Focus();
                }
                else if (txtTenCN.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập tên chức năng!", "Thông báo");
                    txtTenCN.Focus();
                }
                else
                {
                    HamXuLy.connect();
                    string sqlInsert = "INSERT CHUCNANG (IDCN, TENCN) VALUES ('" + txtMaCN.Text + "',N'" + txtTenCN.Text + "')";
                    try
                    {
                        HamXuLy.RunSQL(sqlInsert);
                        MessageBox.Show("Thêm thành công!", "Thông báo");
                        HUY();
                        ShowCN();
                        Reset();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Thông báo");
                    }
                }
            }
            //Sửa 
            else if (btnThem.Enabled == false && btnSua.Enabled == true)
            {
                if (txtMaCN.Text == "")
                {
                    MessageBox.Show("Bạn chưa chọn chức năng!", "Thông báo");
                }
                else
                {
                    HamXuLy.connect();
                    string sqlUpdate = "UPDATE CHUCNANG SET TENCN = N'" + txtTenCN.Text + "' WHERE IDCN = '" + txtMaCN.Text + "'";
                    try
                    {
                        HamXuLy.RunSQL(sqlUpdate);
                        MessageBox.Show("Sửa thành công!", "Thông báo");
                        ShowCN();
                        HUY();
                        Reset();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi", "Thông báo");
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn 'Thêm' hoặc 'Sửa' trước khi lưu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        private void HUY()
        {
            panel1.Enabled = false;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            Reset();
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            HUY();
        }

        private void frmChucNang_Load(object sender, EventArgs e)
        {
            ShowCN();
            txtTK.Text = "Nhập tên Chức năng";
        }

        private void dgvCN_Click(object sender, EventArgs e)
        {
            txtMaCN.Text = dgvCN.CurrentRow.Cells["IDCN"].Value.ToString();
            txtTenCN.Text = dgvCN.CurrentRow.Cells["TENCN"].Value.ToString();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTK_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTK.Text.Trim();
            if (string.IsNullOrEmpty(tuKhoa))
            {
                MessageBox.Show("Vui lòng nhập tên chức năng để tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string query = "SELECT * FROM CHUCNANG WHERE TENCN LIKE @SearchTerm";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@SearchTerm", "%" + tuKhoa + "%")
                };
                DataTable dt = HamXuLy.TimKiem(query, parameters);

                if (dt != null && dt.Rows.Count > 0)
                {
                    dgvCN.DataSource = dt;
                    dgvCN.Refresh();
                }
                else
                {
                    MessageBox.Show("Không có ch nào phù hợp với tên: " + tuKhoa, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvCN.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm nhà cung cấp: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRESET_Click(object sender, EventArgs e)
        {
            ShowCN();
        }

        private void txtTK_Enter(object sender, EventArgs e)
        {
            if (txtTK.Text == "Nhập tên Chức năng")
            {
                txtTK.Text = "";
                txtTK.ForeColor = Color.Black;
            }
        }

        private void txtTK_Leave(object sender, EventArgs e)
        {
            if (txtTK.Text == "")
            {
                txtTK.Text = "Nhập tên Chức năng";
                txtTK.ForeColor = Color.Gray;
            }
        }

    }
}
