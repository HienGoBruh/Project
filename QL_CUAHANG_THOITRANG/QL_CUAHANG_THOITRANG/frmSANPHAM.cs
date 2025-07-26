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
using System.IO;

namespace QL_CUAHANG_THOITRANG
{

    public partial class frmSANPHAM : Form
    {
        public string ddanh = "";
        public frmSANPHAM()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        private void showSP()
        {
            DataTable dtSP = new DataTable();
            HamXuLy.connect();

            String sqlSANPHAM = "SELECT SP.*, HN.DUONGDAN  FROM SANPHAM SP LEFT JOIN HINHSP HN ON SP.IDSP = HN.IDSP";
            
            dtSP.Clear();
            if (HamXuLy.TruyVan(sqlSANPHAM, dtSP))
            {
                luoiSP.DataSource = dtSP;
                //Trang trí lưới
                luoiSP.Columns[0].HeaderText = "MÃ SẢN PHẨM";
                luoiSP.Columns[0].Width = 100;
                luoiSP.Columns[1].HeaderText = "MÃ DANH MỤC";
                luoiSP.Columns[1].Width = 100;
                luoiSP.Columns[2].HeaderText = "MÃ CHÂT LIỆU";
                luoiSP.Columns[2].Width = 100;
                luoiSP.Columns[3].HeaderText = "TÊN SẢN PHẨM";
                luoiSP.Columns[3].Width = 200;
                luoiSP.Columns[4].HeaderText = "ĐƠN GIÁ NHẬP";
                luoiSP.Columns[4].Width = 100;
                luoiSP.Columns[5].HeaderText = "ĐƠN GIÁ BÁN";
                luoiSP.Columns[5].Width = 100;
                luoiSP.Columns[6].HeaderText = "MÔ TẢ";
                luoiSP.Columns[6].Width = 300;
                luoiSP.Columns[7].HeaderText = "ẢNH SP";
                luoiSP.Columns[7].Width = 150;

                luoiSP.EnableHeadersVisualStyles = false;
                luoiSP.ColumnHeadersDefaultCellStyle.BackColor = Color.Cyan;
            }
        }
        private void frmSANPHAM_Load(object sender, EventArgs e)
        {
            HamXuLy.connect();
            txtTIMKIEM.Text = "Nhập tên Sản phẩm";
            string SqlFillCombo1 = "Select * From CHATLIEU";
            string SqlFillCombo2 = "Select * From DANHMUCSP";
            HamXuLy.FillCombo(SqlFillCombo1, cmbCL, "IDCL", "TENCL");
            HamXuLy.FillCombo(SqlFillCombo2, cmbDM, "IDDM", "TENDM");
            showSP();
            btnTHEMANH.Enabled = false;
            pnlSP.Enabled = false;
            ddanh = "";
        }

        private void HUY()
        {
            pnlSP.Enabled = false;
            btnSUA.Enabled = true;
            btnXOA.Enabled = true;
            btnTHEM.Enabled = true;
            txtMASP.ResetText();
            txtTENSP.ResetText();
            txtDGNHAP.ResetText();
            txtDGBAN.ResetText();
            txtMOTA.ResetText();
            cmbCL.ResetText();
            cmbDM.ResetText();
            ddanh = "";
            btnTHEMANH.Enabled = false;
            pnlSP.Enabled = false;
        }

        private void btnHUY_Click(object sender, EventArgs e)
        {
            HUY();
        }

        private void luoiSP_Click(object sender, EventArgs e)
        {
            txtMASP.Text = luoiSP.CurrentRow.Cells["IDSP"].Value.ToString();
            txtTENSP.Text = luoiSP.CurrentRow.Cells["TENSP"].Value.ToString();
            txtDGNHAP.Text = luoiSP.CurrentRow.Cells["DGNHAP"].Value.ToString();
            txtDGBAN.Text = luoiSP.CurrentRow.Cells["DGBAN"].Value.ToString();
            txtMOTA.Text = luoiSP.CurrentRow.Cells["MOTA"].Value.ToString();
            //Xử lý cho combobox
            String MACL, MADM, sql1, sql2;
            //Combo CL
            HamXuLy.connect();
            MACL = luoiSP.CurrentRow.Cells["IDCL"].Value.ToString();
            sql1 = "Select TENCL From CHATLIEU where IDCL ='" + MACL + "'";
            cmbCL.Text = HamXuLy.GetFieldValues(sql1);

            //Combo DM
            MADM = luoiSP.CurrentRow.Cells["IDDM"].Value.ToString();
            sql2 = "Select TENDM From DANHMUCSP where IDDM ='" + MADM + "'";
            cmbDM.Text = HamXuLy.GetFieldValues(sql2);

            //Lấy từ thư mục gốc
            string project = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\"));
            //Đường dẫn đến thư mục img\nv
            string img = Path.Combine(project, "img", "sp");
            //Lấy ảnh từ dgv
            string duongDan = luoiSP.CurrentRow.Cells["DUONGDAN"].Value.ToString();
            //Đường dẫn đầy đủ
            string full = Path.Combine(img, duongDan);
            if (File.Exists(full))
            {
                ptbSP.Image = Image.FromFile(full);
                ptbSP.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else
            {
                ptbSP.Image = null;
            }
        }

        private void btnTHEM_Click(object sender, EventArgs e)
        {
            btnSUA.Enabled = false;
            btnXOA.Enabled = false;
            btnTHEMANH.Enabled = true;
            txtMASP.ResetText();
            txtTENSP.ResetText();
            txtDGNHAP.ResetText();
            txtDGBAN.ResetText();
            txtMOTA.ResetText();
            cmbCL.ResetText();
            cmbDM.ResetText();
            ddanh = "";
            pnlSP.Enabled = true;
            txtMASP.Enabled = false;
            txtMASP.Text = HamXuLy.TaoIDMoi("SANPHAM", "IDSP", "SP");
            txtTENSP.Focus();
        }

        private void btnSUA_Click(object sender, EventArgs e)
        {
            pnlSP.Enabled = true;
            btnSUA.Enabled = true;
            btnXOA.Enabled = false;
            btnTHEMANH.Enabled = true;
            ddanh = "";
            btnTHEM.Enabled = false;
            txtMASP.Enabled = false;
            if (txtMASP.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn gì để sửa");
                HUY();
            }
        }

        private void btnXOA_Click(object sender, EventArgs e)
        {
            if (txtMASP.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn gì để xóa", "Thông báo");
            }
            else
            {
                HamXuLy.connect();
                //Truy vấn sql
                String sqlDelete = "DELETE FROM SANPHAM WHERE IDSP = '" + txtMASP.Text + "'";
                String sqlDeleteA = "DELETE FROM HINHSP WHERE IDSP = '" + txtMASP.Text + "'";
                if (MessageBox.Show("Bạn có muốn xóa không ?", "XÁC NHẬN XÓA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        HamXuLy.RunSQL(sqlDelete);
                        HamXuLy.RunSQL(sqlDeleteA);
                        MessageBox.Show("Xóa Thành Công");
                        showSP();
                        ddanh = "";
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
            double DGNHAP, DGBAN;
            if (btnTHEM.Enabled == true && btnSUA.Enabled == false)
            {
                if (cmbDM.Text == "")
                {
                    MessageBox.Show("Không được để trống Danh Mục", "Thông báo");
                    cmbDM.Focus();
                }
                else if (cmbCL.Text == "")
                {
                    MessageBox.Show("Không được để trống Chất Liệu", "Thông báo");
                    cmbCL.Focus();
                }
                else if (txtTENSP.Text == "")
                {
                    MessageBox.Show("Không được để trống tên sản phẩm", "Thông báo");
                    txtTENSP.Focus();
                }
                else if (txtDGNHAP.Text == "")
                {
                    MessageBox.Show("Không được để trống Giá nhập", "Thông báo");
                    txtDGNHAP.Focus();
                }
                else if (txtDGBAN.Text == "")
                {
                    MessageBox.Show("Không được để trống Giá bán", "Thông báo");
                    txtDGBAN.Focus();
                }
                else if (ddanh == "")
                {
                    MessageBox.Show("Không được để trống hình ảnh", "Thông báo");
                    btnTHEMANH.Focus();
                }
                else
                {
                    DGNHAP = double.Parse(txtDGNHAP.Text);
                    DGBAN = double.Parse(txtDGBAN.Text);
                    if (DGNHAP > DGBAN)
                    {
                        MessageBox.Show("Giá Bán Phải Lớn hơn Giá Nhập");
                        txtDGNHAP.Focus();
                        
                    }
                    else
                    {
                        try
                        {
                            HamXuLy.connect();
                            //Xử lý đưa dữ liệu trên combo box về MACL thay vì TENCL

                            string sqlThem = "INSERT SANPHAM (IDSP, IDDM, IDCL, TENSP, DGNHAP, DGBAN, MOTA) VALUES ('" + txtMASP.Text + "', '" + cmbDM.SelectedValue.ToString() + "', '" + cmbCL.SelectedValue.ToString() + "', N'" + txtTENSP.Text + "', '" + txtDGNHAP.Text + "', '" + txtDGBAN.Text + "', '" + txtMOTA.Text + "')";
                            HamXuLy.RunSQL(sqlThem);
                            string sqlHinh = "INSERT INTO HINHSP (IDHINH, IDSP, DUONGDAN) VALUES ('" + HamXuLy.TaoIDMoi("HINHSP", "IDHINH", "HSP") + "', '" + txtMASP.Text + "', N'" + ddanh + "')";
                            HamXuLy.RunSQL(sqlHinh);
                            MessageBox.Show("Thêm Thành Công");
                            showSP();
                            ddanh = "";
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
                DGNHAP = double.Parse(txtDGNHAP.Text);
                DGBAN = double.Parse(txtDGBAN.Text);
                if (DGNHAP > DGBAN)
                {
                    MessageBox.Show("Giá Bán Phải Lớn hơn Giá Nhập");
                    txtDGNHAP.Focus();

                }
                else
                {
                    try
                    {
                        HamXuLy.connect();
                        string sqlSua = "UPDATE SANPHAM SET " +
                        "IDDM = '" + cmbDM.SelectedValue.ToString() + "', " +
                        "IDCL = '" + cmbCL.SelectedValue.ToString() + "', " +
                        "TENSP = '" + txtTENSP.Text + "', " +
                        "DGNHAP = '" + txtDGNHAP.Text + "', " +
                        "DGBAN = '" + txtDGBAN.Text + "', " +
                        "MOTA = '" + txtMOTA.Text + "' " +
                        "WHERE IDSP = '" + txtMASP.Text + "'";

                        if (ddanh != "")
                        {
                            string sqlSuaA = "UPDATE HINHSP SET " +
                            "DUONGDAN = N'" + ddanh + "' " +
                            "WHERE IDSP = '" + txtMASP.Text + "'";
                            HamXuLy.RunSQL(sqlSuaA);
                        }

                        HamXuLy.RunSQL(sqlSua);
                        ddanh = "";
                        MessageBox.Show("Sửa Thành Công");
                        showSP();
                        HUY();
                        HamXuLy.disconnect();
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message, "Thông báo");
                    }
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
                string sqlTIM =
                      "SELECT SP.*, HN.DUONGDAN " +
                      "FROM SANPHAM SP " +
                      "LEFT JOIN HINHSP HN ON SP.IDSP = HN.IDSP " +
                      "WHERE SP.TENSP LIKE N'%" + txtTIMKIEM.Text + "%'";
                if (HamXuLy.TruyVan(sqlTIM, dtTIM))
                {

                    if (dtTIM.Rows.Count > 0)
                    {
                        luoiSP.DataSource = dtTIM;

                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy Sản phẩm nào có tên " + txtTIMKIEM.Text);
                }
            }
        }

        private void btnRESET_Click(object sender, EventArgs e)
        {
            showSP();
        }

        private void txtTIMKIEM_Enter(object sender, EventArgs e)
        {
            if (txtTIMKIEM.Text == "Nhập tên Sản phẩm")
            {
                txtTIMKIEM.Text = "";
                txtTIMKIEM.ForeColor = Color.Black;
            }
        }

        private void txtTIMKIEM_Leave(object sender, EventArgs e)
        {
            if (txtTIMKIEM.Text == "")
            {
                txtTIMKIEM.Text = "Nhập tên Sản phẩm";
                txtTIMKIEM.ForeColor = Color.Gray;
            }
        }

        private void btnTHEMANH_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Chọn hình ảnh nhân viên";
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fullPath = openFileDialog.FileName;
                string fileName = Path.GetFileName(fullPath);  // tên file ảnh

                // Tạo biến để lưu tên ảnh (biến ddanh bạn yêu cầu)
                ddanh = fileName;

                // Hiển thị ảnh đã chọn lên PictureBox
                ptbSP.Image = Image.FromFile(fullPath);
                ptbSP.SizeMode = PictureBoxSizeMode.Zoom;

                // Sao chép ảnh vào thư mục img\nv của project nếu chưa có
                string projectPath = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\"));
                string savePath = Path.Combine(projectPath, "img", "sp", fileName);
                if (!File.Exists(savePath))
                {
                    File.Copy(fullPath, savePath);
                }

                // Bạn có thể dùng ddanh để lưu vào CSDL bảng HINHNV
                MessageBox.Show("Ảnh đã được chọn: " + ddanh, "Thông báo");
            }
        }

    }
}
