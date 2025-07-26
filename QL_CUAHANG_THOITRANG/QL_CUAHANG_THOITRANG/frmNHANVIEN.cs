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
    public partial class frmNHANVIEN : Form
    {
        public string ddanh = "";
        public frmNHANVIEN()
        {
            InitializeComponent();
        }

        private void showNV()
        {
            DataTable dtNV = new DataTable();
            HamXuLy.connect();

            String sqlNHANVIEN = "SELECT NV.*, HN.DUONGDAN  FROM NHANVIEN NV LEFT JOIN HINHNV HN ON NV.IDNV = HN.IDNV";
            dtNV.Clear();
            if (HamXuLy.TruyVan(sqlNHANVIEN, dtNV))
            {
                luoiNV.DataSource = dtNV;
                //Trang trí lưới
                luoiNV.Columns[0].HeaderText = "MÃ NHÂN VIÊN";
                luoiNV.Columns[0].Width = 100;
                luoiNV.Columns[1].HeaderText = "HỌ TÊN";
                luoiNV.Columns[1].Width = 150;
                luoiNV.Columns[2].HeaderText = "GIỚI TÍNH";
                luoiNV.Columns[2].Width = 100;
                luoiNV.Columns[3].HeaderText = "NĂM SINH";
                luoiNV.Columns[3].Width = 100;
                luoiNV.Columns[4].HeaderText = "EMAIL";
                luoiNV.Columns[4].Width = 150;
                luoiNV.Columns[5].HeaderText = "SỐ ĐIỆN THOẠI";
                luoiNV.Columns[5].Width = 100;
                luoiNV.Columns[6].HeaderText = "ĐỊA CHỈ";
                luoiNV.Columns[6].Width = 200;
                luoiNV.Columns[7].HeaderText = "ẢNH NV";
                luoiNV.Columns[7].Width = 150;

                luoiNV.EnableHeadersVisualStyles = false;
                luoiNV.ColumnHeadersDefaultCellStyle.BackColor = Color.Cyan;
            }
        }

        private void frmNHANVIEN_Load(object sender, EventArgs e)
        {
            HamXuLy.connect();
            btnTHEMANH.Enabled = false;
            txtTIMKIEM.Text = "Nhập tên Nhân viên";
            showNV();
            pnlNV.Enabled = false;
        }

        private void HUY()
        {
            pnlNV.Enabled = false;
            btnSUA.Enabled = true;
            btnXOA.Enabled = true;
            btnTHEM.Enabled = true;
            btnTHEMANH.Enabled = false;
            txtMANV.ResetText();
            txtHOTEN.ResetText();
            txtGIOITINH.ResetText();
            txtNAMSINH.ResetText();
            txtEMAIL.ResetText();
            txtDIENTHOAI.ResetText();
            txtDIACHI.ResetText();
            pnlNV.Enabled = false;
            ddanh = "";
        }
        private void btnHUY_Click(object sender, EventArgs e)
        {
            HUY();
        }

        private void btnTHEM_Click(object sender, EventArgs e)
        {
            btnSUA.Enabled = false;
            btnXOA.Enabled = false;
            btnTHEMANH.Enabled = true;
            txtMANV.ResetText();
            txtHOTEN.ResetText();
            txtGIOITINH.ResetText();
            txtNAMSINH.ResetText();
            txtEMAIL.ResetText();
            txtDIENTHOAI.ResetText();
            txtDIACHI.ResetText();
            pnlNV.Enabled = true;
            txtMANV.Enabled = false;
            ddanh = "";
            txtMANV.Text = HamXuLy.TaoIDMoi("NHANVIEN", "IDNV", "NV");
            txtHOTEN.Focus();
        }

        private void btnSUA_Click(object sender, EventArgs e)
        {
            pnlNV.Enabled = true;
            btnSUA.Enabled = true;
            btnXOA.Enabled = false;
            btnTHEM.Enabled = false;
            btnTHEMANH.Enabled = true;
            txtMANV.Enabled = false;
            if (txtMANV.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn gì để sửa");
                HUY();
            }
        }

        private void luoiNV_Click(object sender, EventArgs e)
        {
            txtMANV.Text = luoiNV.CurrentRow.Cells["IDNV"].Value.ToString();
            txtHOTEN.Text = luoiNV.CurrentRow.Cells["HOTEN"].Value.ToString();
            txtGIOITINH.Text = luoiNV.CurrentRow.Cells["GIOITINH"].Value.ToString();
            txtNAMSINH.Text = luoiNV.CurrentRow.Cells["NAMSINH"].Value.ToString();
            txtEMAIL.Text = luoiNV.CurrentRow.Cells["EMAIL"].Value.ToString();
            txtDIENTHOAI.Text = luoiNV.CurrentRow.Cells["SDT"].Value.ToString();
            txtDIACHI.Text = luoiNV.CurrentRow.Cells["DIACHI"].Value.ToString();

            //Lấy từ thư mục gốc
            string project = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\"));
            //Đường dẫn đến thư mục img\nv
            string img = Path.Combine(project, "img", "nv");
            //Lấy ảnh từ dgv
            string duongDan = luoiNV.CurrentRow.Cells["DUONGDAN"].Value.ToString();
            //Đường dẫn đầy đủ
            string full = Path.Combine(img, duongDan);
            if (File.Exists(full))
            {
                ptbNV.Image = Image.FromFile(full);
                ptbNV.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else
            {
                ptbNV.Image = null;
            }
        }

        private void btnXOA_Click(object sender, EventArgs e)
        {
            if (txtMANV.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn gì để xóa", "Thông báo");
            }
            else
            {
                HamXuLy.connect();
                //Truy vấn sql
                String sqlDeleteA = "DELETE FROM HINHNV WHERE IDNV = '" + txtMANV.Text + "'";
                String sqlDelete = "DELETE FROM NHANVIEN WHERE IDNV = '" + txtMANV.Text + "'";
                if (MessageBox.Show("Bạn có muốn xóa không ?", "XÁC NHẬN XÓA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        HamXuLy.RunSQL(sqlDeleteA);
                        HamXuLy.RunSQL(sqlDelete);
                        
                        MessageBox.Show("Xóa Thành Công");
                        showNV();
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
            if (btnTHEM.Enabled == true && btnSUA.Enabled == false)
            {
                if (txtHOTEN.Text == "")
                {
                    MessageBox.Show("Không được để trống Họ tên", "Thông báo");
                    txtHOTEN.Focus();
                }
                else if (txtGIOITINH.Text == "")
                {
                    MessageBox.Show("Không được để trống Giới tính", "Thông báo");
                    txtGIOITINH.Focus();
                }
                else if (txtNAMSINH.Text == "")
                {
                    MessageBox.Show("Không được để trống Năm sinh", "Thông báo");
                    txtNAMSINH.Focus();
                }
                else if (txtDIENTHOAI.Text == "")
                {
                    MessageBox.Show("Không được để trống Điện thoại", "Thông báo");
                    txtDIENTHOAI.Focus();
                }
                else if (txtEMAIL.Text == "")
                {
                    MessageBox.Show("Không được để trống Email", "Thông báo");
                    txtEMAIL.Focus();
                }
                else if (txtDIACHI.Text == "")
                {
                    MessageBox.Show("Không được để trống Địa chỉ", "Thông báo");
                    txtDIACHI.Focus();
                }
                else if (ddanh == "")
                {
                    MessageBox.Show("Không được để trống hình ảnh", "Thông báo");
                    btnTHEMANH.Focus();
                }
                else
                {
                    try
                    {
                        HamXuLy.connect();
                        //Xử lý đưa dữ liệu trên combo box về MACL thay vì TENCL

                        string sqlThem = "INSERT NHANVIEN (IDNV, HOTEN, GIOITINH, NAMSINH, EMAIL, SDT, DIACHI) VALUES ('" + txtMANV.Text + "', N'" + txtHOTEN.Text + "', N'" + txtGIOITINH.Text + "', N'" + txtNAMSINH.Text + "', '" + txtEMAIL.Text + "', '" + txtDIENTHOAI.Text + "', N'" + txtDIACHI.Text + "')";
                        HamXuLy.RunSQL(sqlThem);
                        string sqlHinh = "INSERT INTO HINHNV (IDHINH, IDNV, DUONGDAN) VALUES ('" + HamXuLy.TaoIDMoi("HINHNV", "IDHINH", "HNV") + "', '" + txtMANV.Text + "', N'" + ddanh + "')";
                        HamXuLy.RunSQL(sqlHinh);

                        MessageBox.Show("Thêm Thành Công");
                        ddanh = "";
                        showNV();

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
                    string sqlSua = "UPDATE NHANVIEN SET " +
                    "HOTEN = N'" + txtHOTEN.Text + "', " +
                    "GIOITINH = N'" + txtGIOITINH.Text + "', " +
                    "NAMSINH = '" + txtNAMSINH.Text + "', " +
                    "EMAIL = '" + txtEMAIL.Text + "', " +
                    "SDT = '" + txtDIENTHOAI.Text + "', " +
                    "DIACHI = N'" + txtDIACHI.Text + "' " +
                    "WHERE IDNV = '" + txtMANV.Text + "'";

                    if(ddanh != "")
                    {
                        string sqlSuaA = "UPDATE HINHNV SET " +
                        "DUONGDAN = N'" + ddanh + "' " +
                        "WHERE IDNV = '" + txtMANV.Text + "'";
                        HamXuLy.RunSQL(sqlSuaA);
                    }
                    
                    HamXuLy.RunSQL(sqlSua);
                    

                    MessageBox.Show("Sửa Thành Công");
                    showNV();
                    ddanh = "";
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
                string sqlTIM = "SELECT * FROM NHANVIEN WHERE HOTEN LIKE N'%" + txtTIMKIEM.Text + "%'";
                if (HamXuLy.TruyVan(sqlTIM, dtTIM))
                {

                    if (dtTIM.Rows.Count > 0)
                    {
                        luoiNV.DataSource = dtTIM;

                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy Nhân viên nào có tên " + txtTIMKIEM.Text);
                }
            }
        }

        private void btnRESET_Click(object sender, EventArgs e)
        {
            showNV();
        }

        private void txtTIMKIEM_Leave(object sender, EventArgs e)
        {
            if (txtTIMKIEM.Text == "")
            {
                txtTIMKIEM.Text = "Nhập tên Nhân viên";
                txtTIMKIEM.ForeColor = Color.Gray;
            }
        }

        private void txtTIMKIEM_Enter(object sender, EventArgs e)
        {
            if (txtTIMKIEM.Text == "Nhập tên Nhân viên")
            {
                txtTIMKIEM.Text = "";
                txtTIMKIEM.ForeColor = Color.Black;
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
                ptbNV.Image = Image.FromFile(fullPath);
                ptbNV.SizeMode = PictureBoxSizeMode.Zoom;

                // Sao chép ảnh vào thư mục img\nv của project nếu chưa có
                string projectPath = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\"));
                string savePath = Path.Combine(projectPath, "img", "nv", fileName);
                if (!File.Exists(savePath))
                {
                    File.Copy(fullPath, savePath);
                }

                // Bạn có thể dùng ddanh để lưu vào CSDL bảng HINHNV
                MessageBox.Show("Ảnh đã được chọn: " + ddanh, "Thông báo");
            }
        }

    } //CLass
} //Namespace
