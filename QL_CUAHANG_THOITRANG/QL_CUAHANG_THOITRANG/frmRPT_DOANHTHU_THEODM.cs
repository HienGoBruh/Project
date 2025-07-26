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
    public partial class frmRPT_DOANHTHU_THEODM : Form
    {
        public string idDM;
        public frmRPT_DOANHTHU_THEODM()
        {
            InitializeComponent();
        }

        private void frmRPT_DOANHTHU_THEODM_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'QL_CUAHANG_THOITRANGDataSet.DOANHTHU_THEODM' table. You can move, or remove it, as needed.
            
            HamXuLy.connect();
            string SqlFillCombo1 = "Select * From DANHMUCSP";
            HamXuLy.FillCombo(SqlFillCombo1, cmbDM, "IDDM", "TENDM");
        }

        private void btnINBC_Click(object sender, EventArgs e)
        {
            if (cbALL.Checked == false)
            {
                if (cmbDM.Text == "" || cmbDM.SelectedValue.ToString() == null)
                {
                    MessageBox.Show("Bạn chưa chọn Danh mục cần in");
                    cmbDM.Focus();
                    return;
                }
                else
                {
                    idDM = cmbDM.SelectedValue.ToString();
                }

            }
            try
            {
                if (cbALL.Checked == true)
                {
                    this.DOANHTHU_THEODMTableAdapter.Fill(this.QL_CUAHANG_THOITRANGDataSet.DOANHTHU_THEODM, null);
                }
                else
                {
                    this.DOANHTHU_THEODMTableAdapter.Fill(this.QL_CUAHANG_THOITRANGDataSet.DOANHTHU_THEODM, idDM);
                }
                if (this.QL_CUAHANG_THOITRANGDataSet.DOANHTHU_THEODM.Rows.Count > 0)
                {
                    this.reportViewer1.RefreshReport();
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu của: " + cmbDM.SelectedValue.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }

        private void btnTAIBC_Click(object sender, EventArgs e)
        {
            if (this.QL_CUAHANG_THOITRANGDataSet.DOANHTHU_THEODM.Rows.Count > 0)
            {
                try
                {
                    
                    if (cbALL.Checked == true)
                    {
                        this.DOANHTHU_THEODMTableAdapter.Fill(this.QL_CUAHANG_THOITRANGDataSet.DOANHTHU_THEODM, null);
                    }
                    else
                    {
                        this.DOANHTHU_THEODMTableAdapter.Fill(this.QL_CUAHANG_THOITRANGDataSet.DOANHTHU_THEODM, idDM);
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
                    saveFileDialog.FileName = "BaoCao_DoanhThu_TheoDM.pdf";

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

        private void btnTHOAT_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbALL_CheckedChanged(object sender, EventArgs e)
        {
            if (cbALL.Checked == true)
            {
                cmbDM.Enabled = false;
            }
            else
            {
                cmbDM.Enabled = true;
            }
        }
    }
}
