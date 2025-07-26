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
    public partial class frmNCC : Form
    {
        public bool IsFromTK = false;
        public frmNCC()
        {
            InitializeComponent();
        }
        private void ShowNcc()
        {
            DataTable dtNcc = new DataTable();
            HamXuLy.connect();
            string sqlNcc = "SELECT * FROM NHACUNGCAP";
            dtNcc.Clear();
            if (HamXuLy.TruyVan(sqlNcc, dtNcc))
            {
                dgvNcc.DataSource = dtNcc;

                dgvNcc.Columns[0].HeaderText = "Mã nhà cung cấp";
                dgvNcc.Columns[0].Width = 100;
                dgvNcc.Columns[1].HeaderText = "Tên nhà cung cấp";
                dgvNcc.Columns[1].Width = 200;
                dgvNcc.Columns[2].HeaderText = "Địa Chỉ";
                dgvNcc.Columns[2].Width = 200;
                dgvNcc.Columns[3].HeaderText = "SDT";
                dgvNcc.Columns[3].Width = 110;
                dgvNcc.Columns[4].HeaderText = "Email";
                dgvNcc.Columns[4].Width = 200;

                dgvNcc.EnableHeadersVisualStyles = false;
                dgvNcc.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 120, 215);
                dgvNcc.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgvNcc.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                dgvNcc.DefaultCellStyle.Font = new Font("Segoe UI", 12);
                dgvNcc.DefaultCellStyle.BackColor = Color.White;
                dgvNcc.DefaultCellStyle.ForeColor = Color.Black;
                dgvNcc.DefaultCellStyle.SelectionBackColor = Color.FromArgb(220, 240, 255);
                dgvNcc.DefaultCellStyle.SelectionForeColor = Color.Black;

                dgvNcc.GridColor = Color.LightGray;
                dgvNcc.RowTemplate.Height = 30;
                dgvNcc.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                dgvNcc.ColumnHeadersHeight = 35;
                dgvNcc.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvNcc.MultiSelect = false;
                dgvNcc.ReadOnly = true;

                dgvNcc.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
                dgvNcc.BackgroundColor = Color.WhiteSmoke;
            }
        }
        private void frmNCC_Load(object sender, EventArgs e)
        {
            if (IsFromTK)
            {
                btnTK.Visible = false;
                txtTK.Visible = false;
                btnThem.Enabled = false;
            }
            else
            {
                ShowNcc();
                txtTK.Text = "Nhập tên Nhà cung cấp";
                pnlNcc.Enabled = false;
            }
        }
        public void LoadDataFromTK(DataTable dt)
        {
            dgvNcc.DataSource = dt;
            IsFromTK = true;
        }

        private void btnTK_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTK.Text.Trim();
            if (string.IsNullOrEmpty(tuKhoa))
            {
                MessageBox.Show("Vui lòng nhập tên nhà cung để tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string query = "SELECT * FROM NHACUNGCAP WHERE TENNCC LIKE @SearchTerm";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@SearchTerm", "%" + tuKhoa + "%")
                };
                DataTable dt = HamXuLy.TimKiem(query, parameters);

                if (dt != null && dt.Rows.Count > 0)
                {
                    dgvNcc.DataSource = dt;
                    dgvNcc.Refresh();
                }
                else
                {
                    MessageBox.Show("Không có nhà cung cấp nào phù hợp với tên: " + tuKhoa, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvNcc.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm nhà cung cấp: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvNcc_Click(object sender, EventArgs e)
        {
            txtMaNcc.Text = dgvNcc.CurrentRow.Cells["IDNCC"].Value.ToString();
            txtTenNcc.Text = dgvNcc.CurrentRow.Cells["TENNCC"].Value.ToString();
            txtSDTNCC.Text = dgvNcc.CurrentRow.Cells["SDT"].Value.ToString();
            txtDiaChiNcc.Text = dgvNcc.CurrentRow.Cells["DIACHI"].Value.ToString();
            txtEmailNcc.Text = dgvNcc.CurrentRow.Cells["EMAIL"].Value.ToString();
        }
        private void Reset()
        {
            txtMaNcc.ResetText();
            txtTenNcc.ResetText();
            txtSDTNCC.ResetText();
            txtDiaChiNcc.ResetText();
            txtEmailNcc.ResetText();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            pnlNcc.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            txtMaNcc.Enabled = false;
            txtTenNcc.Focus();
            Reset();
            txtMaNcc.Text = HamXuLy.TaoIDMoi("NHACUNGCAP", "IDNCC", "NCC");
        }
        private void HUY()
        {
            pnlNcc.Enabled = false;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            Reset();
            txtTK.ResetText();
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (!IsFromTK)
            {
                HUY();
                ShowNcc();
            }
            else
            {
                pnlNcc.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaNcc.Text == "")
            {
                MessageBox.Show("Bạn nên chọn 1 nhà cung cấp trước khi sửa", "Thông báo");
            }
            else
            {
                pnlNcc.Enabled = true;
                txtMaNcc.Enabled = false;
                txtTenNcc.Focus();
                btnThem.Enabled = false;
                btnXoa.Enabled = false;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaNcc.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn nhà cung cấp để xóa", "Thông báo");
            }
            else
            {
                HamXuLy.connect();
                string sqlDelete = "DELETE FROM NHACUNGCAP WHERE IDNCC = '" + txtMaNcc.Text + "'";
                if (MessageBox.Show("Bạn có chắc xóa nhà cung cấp này không!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    HamXuLy.RunSQL(sqlDelete);
                    MessageBox.Show("Xóa thành công!", "Thông báo");
                }
                ShowNcc();
                Reset();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (btnSua.Enabled == false && btnThem.Enabled == true)
            {
                //Thêm 
                if (txtTenNcc.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập tên nhà cung cấp!", "Thông báo");
                    txtTenNcc.Focus();
                }
                else if (txtSDTNCC.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập số điện thoại!", "Thông báo");
                    txtSDTNCC.Focus();
                }
                else if (txtEmailNcc.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập email!", "Thông báo");
                    txtEmailNcc.Focus();
                }
                else if (txtDiaChiNcc.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập địa chỉ!", "Thông báo");
                    txtDiaChiNcc.Focus();
                }
                else
                {
                    HamXuLy.connect();
                    string sqlInsert = "INSERT NHACUNGCAP (IDNCC, TENNCC, SDT, EMAIL, DIACHI) VALUES ('" + txtMaNcc.Text + "', N'" + txtTenNcc.Text + "', '" + txtSDTNCC.Text + "', '" + txtEmailNcc.Text + "', N'" + txtDiaChiNcc.Text + "')";
                    try
                    {
                        HamXuLy.RunSQL(sqlInsert);
                        MessageBox.Show("Thêm thành công", "Thông báo");
                        HUY();
                        ShowNcc();
                        Reset();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Thông báo");
                    }
                }
            }
            else if (btnSua.Enabled == true && btnThem.Enabled == false)
            {
                //Sửa 
                if (txtMaNcc.Text == "")
                {
                    MessageBox.Show("Bạn chưa chọn nhà cung cấp", "Thông báo");
                }
                else
                {
                    HamXuLy.connect();
                    string sqlUpdate = "UPDATE NHACUNGCAP SET TENNCC = N'" + txtTenNcc.Text + "', SDT = '" + txtSDTNCC.Text + "', EMAIL = '" + txtEmailNcc.Text + "', DIACHI = N'" + txtDiaChiNcc.Text + "' WHERE IDNCC = '" + txtMaNcc.Text + "'";
                    try
                    {
                        HamXuLy.RunSQL(sqlUpdate);
                        MessageBox.Show("Sửa thành công", "Thông báo");
                        HUY();
                        ShowNcc();
                        Reset();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Thông báo");
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn 'Thêm' hoặc 'Sửa' trước khi lưu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnRESET_Click(object sender, EventArgs e)
        {
            ShowNcc();
        }

        private void txtTK_Enter(object sender, EventArgs e)
        {
            if (txtTK.Text == "Nhập tên Nhà cung cấp")
            {
                txtTK.Text = "";
                txtTK.ForeColor = Color.Black;
            }
        }

        private void txtTK_Leave(object sender, EventArgs e)
        {
            if (txtTK.Text == "")
            {
                txtTK.Text = "Nhập tên Nhà cung cấp";
                txtTK.ForeColor = Color.Gray;
            }
        }


    }
}
