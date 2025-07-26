using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_CUAHANG_THOITRANG
{
    public partial class frmDANGNHAP : Form
    {
        public frmDANGNHAP()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            HamXuLy.connect();
            if (txtTK.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tài khoản");
                txtTK.Focus();
            }
            else if (txtMK.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập Mật Khẩu");
                txtMK.Focus();
            }
            else //Nhập đủ thông tin
            {
                string taikhoan = txtTK.Text.Trim();
                string matkhau = txtMK.Text.Trim();
                string sql1 = "Select * From TAIKHOAN Where TENDN = '" + taikhoan + "' AND MATKHAU = '" + matkhau + "'";
                string sql2 = "Select * From TAIKHOAN Where TENDN = '" + taikhoan + "' AND MATKHAU != '" + matkhau + "'";
                DataTable dtlg = new DataTable();
                frmMain frmM = new frmMain();
                if (HamXuLy.TruyVan(sql1, dtlg))
                {
                    //Thanh cong
                    string nhom = dtlg.Rows[0]["NHOM"].ToString().Trim();
                    string iduser = dtlg.Rows[0]["IDUSER"].ToString().Trim();
                    if (nhom == "admin") // Đăng nhập vào admin
                    {
                        frmM.Show();
                        frmM._mnHethong.Enabled = true;
                        frmM._mnQuanly.Enabled = true;
                        frmM._mnBaocao.Enabled = true;
                        frmM._mnTimkiem.Enabled = true;
                        frmM._mnTrogiup.Enabled = true;

                        frmM._mnQLTK.Enabled = true;
                        frmM._mnQLCN.Enabled = true;
                        frmM._mnPhanQuyen.Enabled = true;

                        frmM._mnQLDM.Enabled = true;
                        frmM._mnQLCL.Enabled = true;
                        frmM._mnQLSP.Enabled = true;
                        frmM._mnQLNV.Enabled = true;
                        frmM._mnQLKH.Enabled = true;
                        frmM._mnQLSize.Enabled = true;
                        frmM._mnQLMau.Enabled = true;
                        frmM._mnQLHD.Enabled = true;
                        frmM._mnQLTONKHO.Enabled = true;
                        frmM._mnQLNCC.Enabled = true;

                        //frmM._mnBCDoanhThu.Enabled = true;
                        //frmM._mnBCTonKho.Enabled = true;
                        //frmM._mnBCLoiN.Enabled = true;
                        //frmM._mnBCNhap.Enabled = true;

                    }
                    else //Đăng nhập vào user
                    {
                        frmM.Show();
                        //Login User
                        string sql3 = "Select * From PHANQUYEN where IDUSER = '" + iduser + "'";
                        DataTable dtpq = new DataTable();
                        if (HamXuLy.TruyVan(sql3, dtpq))
                        {
                            frmM.Show();
                            foreach (DataRow Row in dtpq.Rows)
                            {
                                if (Row["IDCN"].ToString().Trim() == "CN01")
                                {
                                    frmM._mnHethong.Enabled = true;
                                    frmM._mnQLTK.Enabled = true;
                                }
                                if (Row["IDCN"].ToString().Trim() == "CN02")
                                {
                                    frmM._mnHethong.Enabled = true;
                                    frmM._mnPhanQuyen.Enabled = true;
                                }
                                if (Row["IDCN"].ToString().Trim() == "CN03")
                                {
                                    frmM._mnQuanly.Enabled = true;
                                    frmM._mnQLCL.Enabled = true;
                                }
                                if (Row["IDCN"].ToString().Trim() == "CN04")
                                {
                                    frmM._mnQuanly.Enabled = true;
                                    frmM._mnQLSP.Enabled = true;
                                }
                                if (Row["IDCN"].ToString().Trim() == "CN05")
                                {
                                    frmM._mnQuanly.Enabled = true;
                                    frmM._mnQLNV.Enabled = true;
                                }
                                if (Row["IDCN"].ToString().Trim() == "CN06")
                                {
                                    frmM._mnQuanly.Enabled = true;
                                    frmM._mnQLKH.Enabled = true;
                                }
                                if (Row["IDCN"].ToString().Trim() == "CN07")
                                {
                                    frmM._mnQuanly.Enabled = true;
                                    frmM._mnQLHD.Enabled = true;
                                }
                                if (Row["IDCN"].ToString().Trim() == "CN08")
                                {
                                    frmM._mnQuanly.Enabled = true;
                                    frmM._mnQLHD.Enabled = true;
                                }
                                if (Row["IDCN"].ToString().Trim() == "CN09")
                                {
                                    frmM._mnTimkiem.Enabled = true;

                                }
                                if (Row["IDCN"].ToString().Trim() == "CN10")
                                {
                                    frmM._mnBaocao.Enabled = true;

                                }

                            }
                        }
                    }

                }
                else if (HamXuLy.TruyVan(sql2, dtlg))
                {
                    //Sai MK
                    MessageBox.Show("Sai Mật Khẩu");
                    txtMK.Focus();
                }
                else
                {
                    //TK Khong ton tai
                    MessageBox.Show("Tài Khoản Không Tồn Tại");
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ckbHMK_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbHMK.Checked == true)
            {
                txtMK.PasswordChar = '\0';
            }
            else
            {
                txtMK.PasswordChar = '*';
            }
        }

        private void frmDANGNHAP_Load(object sender, EventArgs e)
        {
            txtMK.PasswordChar = '*';
        }
    }
}
