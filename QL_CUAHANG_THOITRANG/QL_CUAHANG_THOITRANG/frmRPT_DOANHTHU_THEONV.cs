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
using Microsoft.Reporting.WinForms;

namespace QL_CUAHANG_THOITRANG
{
    public partial class frmRPT_DOANHTHU_THEONV : Form
    {
        public string idNV;
        public frmRPT_DOANHTHU_THEONV()
        {
            InitializeComponent();
        }

        private void frmRPT_DOANHTHU_THEONV_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'QL_CUAHANG_THOITRANGDataSet.DOANHTHU_THEONV' table. You can move, or remove it, as needed.
            
            HamXuLy.connect();
            string SqlFillCombo1 = "Select * From NHANVIEN";
            HamXuLy.FillCombo(SqlFillCombo1, cmbNV, "IDNV", "HOTEN");
        }

        private void btnTHOAT_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTAIBC_Click(object sender, EventArgs e)
        {
            if (this.QL_CUAHANG_THOITRANGDataSet.DOANHTHU_THEONV.Rows.Count > 0)
            {
                try
                {
                    if (cbALLNV.Checked == true)
                    {
                        this.DOANHTHU_THEONVTableAdapter.Fill(this.QL_CUAHANG_THOITRANGDataSet.DOANHTHU_THEONV, null);
                    }
                    else
                    {
                        this.DOANHTHU_THEONVTableAdapter.Fill(this.QL_CUAHANG_THOITRANGDataSet.DOANHTHU_THEONV, idNV);
                    }
                    // 3. Render PDF
                    Warning[] warnings;
                    string[] streamIds;
                    string mimeType = "", encoding = "", extension = "";

                    byte[] bytes = reportViewer1.LocalReport.Render(
                        "PDF", null, out mimeType, out encoding,
                        out extension, out streamIds, out warnings);

                    // 4. Chọn nơi lưu file
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
                    saveFileDialog.Title = "Lưu báo cáo dưới dạng PDF";
                    saveFileDialog.FileName = "BaoCao_DoanhThu_TheoNV.pdf";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        using (System.IO.FileStream fs = new System.IO.FileStream(saveFileDialog.FileName, System.IO.FileMode.Create))
                        {
                            fs.Write(bytes, 0, bytes.Length);
                        }

                        MessageBox.Show("Xuất file PDF thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xuất PDF: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để tải về");
            }
        }

        private void btnINBC_Click(object sender, EventArgs e)
        {
            if (cbALLNV.Checked == false)
            {
                if (cmbNV.Text == "" || cmbNV.SelectedValue.ToString() == null)
                {
                    MessageBox.Show("Bạn chưa chọn nhân viên cần in");
                    cmbNV.Focus();
                    return;
                }
                else
                {
                    idNV = cmbNV.SelectedValue.ToString();
                }

            }
            try
            {

                if (cbALLNV.Checked == true)
                {
                    this.DOANHTHU_THEONVTableAdapter.Fill(this.QL_CUAHANG_THOITRANGDataSet.DOANHTHU_THEONV, null);
                }
                else
                {
                    this.DOANHTHU_THEONVTableAdapter.Fill(this.QL_CUAHANG_THOITRANGDataSet.DOANHTHU_THEONV, idNV);
                }
                if (this.QL_CUAHANG_THOITRANGDataSet.DOANHTHU_THEONV.Rows.Count > 0)
                {
                    this.reportViewer1.RefreshReport();
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu của nhân viên: " + cmbNV.SelectedValue.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void cbALLNV_CheckedChanged(object sender, EventArgs e)
        {
            if (cbALLNV.Checked == true)
            {
                cmbNV.Enabled = false;
            }
            else
            {
                cmbNV.Enabled = true;
            }
            
        }
    }
}
