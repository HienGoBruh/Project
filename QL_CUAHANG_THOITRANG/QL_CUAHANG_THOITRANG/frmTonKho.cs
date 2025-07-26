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
    public partial class frmTonKho : Form
    {
        public frmTonKho()
        {
            InitializeComponent();
        }
        private void ShowTK()
        {
            DataTable dtTK = new DataTable();
            HamXuLy.connect();
            string sqlTK = "SELECT tk.IDTONKHO, tk.IDSP, sp.TENSP, tk.IDSIZE, s.TENSIZE, tk.IDMAU, m.TENMAU, tk.SOLUONG  FROM SPTONKHO tk JOIN SANPHAM sp ON tk.IDSP = sp.IDSP JOIN SIZE s ON tk.IDSIZE = s.IDSIZE JOIN MAU m ON tk.IDMAU = m.IDMAU";
            dtTK.Clear();
            if (HamXuLy.TruyVan(sqlTK, dtTK))
            {
                dgvTK.DataSource = dtTK;

                dgvTK.Columns[0].HeaderText = "Mã tồn kho";
                dgvTK.Columns[0].Width = 120;
                dgvTK.Columns[1].HeaderText = "Mã sản phẩm";
                dgvTK.Columns[1].Width = 120;
                dgvTK.Columns[2].HeaderText = "Tên sản phẩm";
                dgvTK.Columns[2].Width = 150;
                dgvTK.Columns[3].HeaderText = "Mã size";
                dgvTK.Columns[3].Width = 100;
                dgvTK.Columns[4].HeaderText = "Size";
                dgvTK.Columns[4].Width = 100;
                dgvTK.Columns[5].HeaderText = "Mã màu";
                dgvTK.Columns[5].Width = 100;
                dgvTK.Columns[6].HeaderText = "Màu";
                dgvTK.Columns[6].Width = 100;
                dgvTK.Columns[7].HeaderText = "Số lượng";
                dgvTK.Columns[7].Width = 100;

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
        }
        private void frmTonKho_Load(object sender, EventArgs e)
        {
            HamXuLy.connect();
            string sqlSelectSP = "SELECT * FROM SANPHAM";
            string sqlSelectS = "SELECT * FROM SIZE";
            string sqlSelectM = "SELECT * FROM MAU";
            HamXuLy.FillCombo(sqlSelectSP, cboSP, "IDSP", "TENSP");
            HamXuLy.FillCombo(sqlSelectS, cboSize, "IDSIZE", "TENSIZE");
            HamXuLy.FillCombo(sqlSelectM, cboMau, "IDMAU", "TENMAU");
            txtTK.Text = "Nhập tên Sản phẩm";
            ShowTK();
        }

        private void dgvTK_Click(object sender, EventArgs e)
        {
            string idSP = dgvTK.CurrentRow.Cells["IDSP"].Value.ToString();
            string sqltenSP = "SELECT TENSP FROM SANPHAM WHERE IDSP = N'" + idSP + "'";
            cboSP.Text = HamXuLy.GetFieldValues(sqltenSP);

            string idS = dgvTK.CurrentRow.Cells["IDSIZE"].Value.ToString();
            string sqltenS = "SELECT TENSIZE FROM SIZE WHERE IDSIZE = N'" + idS + "'";
            cboSize.Text = HamXuLy.GetFieldValues(sqltenS);

            string idM = dgvTK.CurrentRow.Cells["IDMAU"].Value.ToString();
            string sqltenM = "SELECT TENMAU FROM MAU WHERE IDMAU = N'" + idM + "'";
            cboMau.Text = HamXuLy.GetFieldValues(sqltenM);

            txtMaTonKho.Text = dgvTK.CurrentRow.Cells["IDTONKHO"].Value.ToString();
            txtSL.Text = dgvTK.CurrentRow.Cells["SOLUONG"].Value.ToString();
        }
        private void Reset()
        {
            txtMaTonKho.ResetText();
            txtSL.ResetText();
            cboSP.ResetText();
            cboMau.ResetText();
            cboSize.ResetText();
        }
        private void HUY()
        {
            pnlTK.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            Reset();
            txtTK.ResetText();
            ShowTK();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            HUY();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaTonKho.Text == "")
            {
                MessageBox.Show("Bạn nên chọn 1 sản phẩm trước khi sửa", "Thông báo");
            }
            else
            {
                btnXoa.Enabled = false;
                btnThem.Enabled = false;
                pnlTK.Enabled = true;
                txtMaTonKho.Enabled = false;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (btnSua.Enabled == false && btnThem.Enabled == true)
            {
                //Thêm 
                if (txtSL.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập số lượng!", "Thông báo");
                    txtSL.Focus();
                }
                else
                {
                    HamXuLy.connect();
                    string sqlInsert = "INSERT SPTONKHO (IDTONKHO, IDSP, IDSIZE, IDMAU, SOLUONG) VALUES ('" + txtMaTonKho.Text + "', N'" + cboSP.SelectedValue.ToString() + "', '" + cboSize.SelectedValue.ToString() + "', '" + cboMau.SelectedValue.ToString() + "', N'" + txtSL.Text + "')";
                    try
                    {
                        HamXuLy.RunSQL(sqlInsert);
                        MessageBox.Show("Thêm thành công", "Thông báo");
                        HUY();
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
                if (txtMaTonKho.Text == "")
                {
                    MessageBox.Show("Bạn chưa chọn sản phẩm", "Thông báo");
                }
                else
                {
                    HamXuLy.connect();
                    string sqlUpdate = "UPDATE SPTONKHO SET SOLUONG = N'" + txtSL.Text + "' WHERE IDTONKHO = '" + txtMaTonKho.Text + "'";
                    try
                    {
                        HamXuLy.RunSQL(sqlUpdate);
                        MessageBox.Show("Sửa thành công", "Thông báo");
                        HUY();
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaTonKho.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn sản phẩm để xóa", "Thông báo");
            }
            else
            {
                HamXuLy.connect();
                string sqlDelete = "DELETE FROM SPTONKHO WHERE IDTONKHO = '" + txtMaTonKho.Text + "'";
                if (MessageBox.Show("Bạn có chắc xóa sản phẩm này khỏi kho không!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    HamXuLy.RunSQL(sqlDelete);
                    MessageBox.Show("Xóa thành công!", "Thông báo");
                }
                ShowTK();
                Reset();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            pnlTK.Enabled = true;
            txtMaTonKho.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            Reset();
            txtMaTonKho.Text = HamXuLy.TaoIDMoi("SPTONKHO", "IDTONKHO", "TK");
        }

        private void btnTK_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTK.Text.Trim();
            if (string.IsNullOrEmpty(tuKhoa))
            {
                MessageBox.Show("Vui lòng nhập tên sản phẩm để tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string query = "SELECT * FROM SPTONKHO tk JOIN SANPHAM sp ON tk.IDSP = sp.IDSP WHERE sp.TENSP LIKE @SearchTerm";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@SearchTerm", "%" + tuKhoa + "%")
                };
                DataTable dt = HamXuLy.TimKiem(query, parameters);

                if (dt != null && dt.Rows.Count > 0)
                {
                    dgvTK.DataSource = dt;
                    dgvTK.Refresh();
                }
                else
                {
                    MessageBox.Show("Không có sản phẩm nào phù hợp với tên: " + tuKhoa, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvTK.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRESET_Click(object sender, EventArgs e)
        {
            ShowTK();
        }

        private void txtTK_Enter(object sender, EventArgs e)
        {
            if (txtTK.Text == "Nhập tên Sản phẩm")
            {
                txtTK.Text = "";
                txtTK.ForeColor = Color.Black;
            }
        }

        private void txtTK_Leave(object sender, EventArgs e)
        {
            if (txtTK.Text == "")
            {
                txtTK.Text = "Nhập tên Sản phẩm";
                txtTK.ForeColor = Color.Gray;
            }
        }

    }
}
