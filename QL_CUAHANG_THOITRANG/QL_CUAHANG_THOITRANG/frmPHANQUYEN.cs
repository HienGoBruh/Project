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
    public partial class frmPHANQUYEN : Form
    {
        public frmPHANQUYEN()
        {
            InitializeComponent();
        }
        private void showPQ()
        {
            DataTable dtPQ = new DataTable();
            HamXuLy.connect();
            string sqlCHATLIEU = "select * From PHANQUYEN";
            dtPQ.Clear();
            if (HamXuLy.TruyVan(sqlCHATLIEU, dtPQ))
            {

                luoiPQ.DataSource = dtPQ;
                //Trang trí lưới
                luoiPQ.Columns[0].HeaderText = "ID PHÂN QUYỀN";
                luoiPQ.Columns[0].Width = 100;
                luoiPQ.Columns[1].HeaderText = "NGƯỜI DÙNG";
                luoiPQ.Columns[1].Width = 100;
                luoiPQ.Columns[2].HeaderText = "CHỨC NĂNG";
                luoiPQ.Columns[2].Width = 200;

                luoiPQ.EnableHeadersVisualStyles = false;
                luoiPQ.ColumnHeadersDefaultCellStyle.BackColor = Color.Cyan;
            }

        }
        private void cmbUSER_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbUSER.SelectedValue != null)
            {
                string userID = cmbUSER.SelectedValue.ToString();

                // 1. Clear CheckedListBox
                listcbPQ.Items.Clear();
                txtUSER.Text = "Tài khoản: " + cmbUSER.Text;
                // 2. Lấy toàn bộ chức năng
                string sqlAllCN = "SELECT IDCN, TENCN FROM CHUCNANG";
                SqlCommand cmdAll = new SqlCommand(sqlAllCN, HamXuLy.conn);
                SqlDataAdapter daAll = new SqlDataAdapter(cmdAll);
                DataTable dtAllCN = new DataTable();
                daAll.Fill(dtAllCN);

                // Nếu là Admin, check toàn bộ chức năng
                if (HamXuLy.CheckAdmin(userID) == 1)
                {
                    foreach (DataRow row in dtAllCN.Rows)
                    {
                        string tencn = row["TENCN"].ToString();
                        int index = listcbPQ.Items.Add(tencn);
                        listcbPQ.SetItemChecked(index, true); // Check tất cả
                    }
                    return; // Không cần xử lý phân quyền riêng nữa
                }

                // 3. Lấy danh sách IDCN mà user đã có
                string sqlPQ = "SELECT IDCN FROM PHANQUYEN WHERE IDUSER = @iduser";
                SqlCommand cmdPQ = new SqlCommand(sqlPQ, HamXuLy.conn);
                cmdPQ.Parameters.AddWithValue("@iduser", userID);
                SqlDataAdapter daPQ = new SqlDataAdapter(cmdPQ);
                DataTable dtPQ = new DataTable();
                daPQ.Fill(dtPQ);

                // 4. Duyệt chức năng, add vào CheckedListBox và check nếu user có quyền
                foreach (DataRow row in dtAllCN.Rows)
                {
                    string idcn = row["IDCN"].ToString();
                    string tencn = row["TENCN"].ToString();

                    int index = listcbPQ.Items.Add(tencn);

                    foreach (DataRow pqRow in dtPQ.Rows)
                    {
                        if (pqRow["IDCN"].ToString() == idcn)
                        {
                            listcbPQ.SetItemChecked(index, true);
                            break;
                        }
                    }
                }
            }
        }


        private void frmPHANQUYEN_Load(object sender, EventArgs e)
        {
            HamXuLy.connect();
            string SqlFillCombo1 = "Select * From TAIKHOAN";
            string SqlFillCombo2 = "Select * From CHUCNANG";
            HamXuLy.FillCombo(SqlFillCombo1, cmbUSER, "IDUSER", "TENDN");
            HamXuLy.FillCombo(SqlFillCombo2, cmbCN, "IDCN", "TENCN");
            showPQ();
            pnlPQ.Enabled = false;
            cmbUSER.SelectedIndexChanged += cmbUSER_SelectedIndexChanged;
            txtTIMKIEM.Text = "Nhập tên đăng nhập";

        }
        private void HUY()
        {
            pnlPQ.Enabled = false;
            btnSUA.Enabled = true;
            btnXOA.Enabled = true;
            btnTHEM.Enabled = true;
            txtIDPQ.ResetText();

        }
        private void btnHUY_Click(object sender, EventArgs e)
        {
            HUY();
        }

        private void luoiPQ_Click(object sender, EventArgs e)
        {
            HamXuLy.connect();
            txtIDPQ.Text = luoiPQ.CurrentRow.Cells["IDPQ"].Value.ToString();

            //Combo CL
            string IDNGDUNG = luoiPQ.CurrentRow.Cells["IDUSER"].Value.ToString();
            string sql1 = "Select TENDN From TAIKHOAN where IDUSER ='" + IDNGDUNG + "'";
            cmbUSER.Text = HamXuLy.GetFieldValues(sql1);

            //Combo DM
            string IDCNANG = luoiPQ.CurrentRow.Cells["IDCN"].Value.ToString();
            string sql2 = "Select TENCN From CHUCNANG where IDCN ='" + IDCNANG + "'";
            cmbCN.Text = HamXuLy.GetFieldValues(sql2);
        }

        private void btnTHEM_Click(object sender, EventArgs e)
        {
            btnSUA.Enabled = false;
            btnXOA.Enabled = false;
            pnlPQ.Enabled = true;
            txtIDPQ.Enabled = false;
            txtIDPQ.Text = HamXuLy.TaoIDMoi("PHANQUYEN", "IDPQ", "PQ");
            cmbUSER.Focus();
        }

        private void btnXOA_Click(object sender, EventArgs e)
        {
            if (txtIDPQ.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn gì để xóa", "Thông báo");
            }
            else
            {
                HamXuLy.connect();
                //Truy vấn sql
                String sqlDelete = "DELETE FROM PHANQUYEN WHERE IDPQ = '" + txtIDPQ.Text + "'";
                if (MessageBox.Show("Bạn có muốn xóa không ?", "XÁC NHẬN XÓA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        HamXuLy.RunSQL(sqlDelete);
                        MessageBox.Show("Xóa Thành Công");
                        showPQ();

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
            pnlPQ.Enabled = true;
            btnSUA.Enabled = true;
            btnXOA.Enabled = false;
            btnTHEM.Enabled = false;
            txtIDPQ.Enabled = false;
            if (txtIDPQ.Text == "")
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
                if (cmbUSER.Text == "")
                {
                    MessageBox.Show("Không được để trống Tài khoản", "Thông báo");
                    cmbUSER.Focus();
                }
                else if (cmbCN.Text == "")
                {
                    MessageBox.Show("Không được để trống Chức năng", "Thông báo");
                    cmbCN.Focus();
                }
                else
                {
                    HamXuLy.connect();
                    string idUser = cmbUSER.SelectedValue.ToString();
                    string idCN = cmbCN.SelectedValue.ToString();

                    // Kiểm tra đã tồn tại?
                    if (HamXuLy.ExistsPhanQuyen(idUser, idCN))
                    {
                        MessageBox.Show("Tài khoản '"+cmbUSER.Text+"' đã có chức năng này rồi.", "Thông báo");
                    }
                    else if (HamXuLy.CheckAdmin(idUser) == 1)
                    {
                        MessageBox.Show("Tài khoản thuộc nhóm ADMIN nên đã có toàn quyền.", "Không Phân Quyền được");
                    }
                    else
                    {
                        try
                        {
                            HamXuLy.connect();
                            //Xử lý đưa dữ liệu trên combo box về MACL thay vì TENCL
                            string sqlThem = "INSERT PHANQUYEN (IDPQ, IDUSER, IDCN) VALUES ('" + txtIDPQ.Text + "', N'" + cmbUSER.SelectedValue.ToString() + "', N'" + cmbCN.SelectedValue.ToString() + "')";
                            HamXuLy.RunSQL(sqlThem);
                            MessageBox.Show("Thêm Thành Công");
                            showPQ();

                            HUY();
                            HamXuLy.disconnect();

                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show(ex.Message);
                        }
                    }
                    
                }
            }
            //Lưu sửa
            else if (btnTHEM.Enabled == false && btnSUA.Enabled == true)
            {
                if (cmbUSER.Text == "")
                {
                    MessageBox.Show("Không được để trống Tài khoản", "Thông báo");
                    cmbUSER.Focus();
                }
                else if (cmbCN.Text == "")
                {
                    MessageBox.Show("Không được để trống Chức năng", "Thông báo");
                    cmbCN.Focus();
                }
                else
                {
                    HamXuLy.connect();
                    string idUser = cmbUSER.SelectedValue.ToString();
                    string idCN = cmbCN.SelectedValue.ToString();

                    // Kiểm tra đã tồn tại?
                    if (HamXuLy.ExistsPhanQuyen(idUser, idCN))
                    {
                        MessageBox.Show("Tài khoản '" + cmbUSER.Text + "' đã có chức năng này rồi.", "Thông báo");
                    }
                    else if (HamXuLy.CheckAdmin(idUser) == 1)
                    {
                        MessageBox.Show("Tài khoản thuộc nhóm ADMIN nên đã có toàn quyền.", "Không Phân Quyền được");
                    }
                    else
                    {
                        try
                        {
                            HamXuLy.connect();
                            string sqlSua = "UPDATE PHANQUYEN SET " +
                            "IDUSER = '" + cmbUSER.SelectedValue.ToString() + "', " +
                            "IDCN = '" + cmbCN.SelectedValue.ToString() + "' " +
                            "WHERE IDPQ = '" + txtIDPQ.Text + "'";

                            HamXuLy.RunSQL(sqlSua);

                            MessageBox.Show("Sửa Thành Công");
                            showPQ();
                            HUY();
                            HamXuLy.disconnect();
                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show(ex.Message, "Thông báo");
                        }
                    }
                    
                }
                
            }
            //Không chọn gì để lưu
            else
            {
                MessageBox.Show("Không có tùy chọn để lưu");
            }
        }

        private void btnRESET_Click(object sender, EventArgs e)
        {
            showPQ();
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
                
                string sqlTIM = "SELECT p.IDPQ, p.IDUSER, p.IDCN FROM PHANQUYEN p JOIN TAIKHOAN t ON p.IDUSER = t.IDUSER WHERE t.TENDN LIKE N'%" + txtTIMKIEM.Text + "%'";
                if (HamXuLy.TruyVan(sqlTIM, dtTIM))
                {

                    if (dtTIM.Rows.Count > 0)
                    {
                        luoiPQ.DataSource = dtTIM;

                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy tài khoản nào có tên " + txtTIMKIEM.Text);
                }
            }
        }

        private void txtTIMKIEM_Enter(object sender, EventArgs e)
        {
            if (txtTIMKIEM.Text == "Nhập tên đăng nhập")
            {
                txtTIMKIEM.Text = "";
                txtTIMKIEM.ForeColor = Color.Black;
            }
        }

        private void txtTIMKIEM_Leave(object sender, EventArgs e)
        {
            if (txtTIMKIEM.Text == "")
            {
                txtTIMKIEM.Text = "Nhập tên đăng nhập";
                txtTIMKIEM.ForeColor = Color.Gray;
            }
        }

        private void cmbCN_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtIDPQ_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void luoiPQ_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }


    }
}
