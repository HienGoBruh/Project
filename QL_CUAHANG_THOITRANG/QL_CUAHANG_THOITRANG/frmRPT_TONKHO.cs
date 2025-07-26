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
    public partial class frmRPT_TONKHO : Form
    {
        public string idSP;
        public frmRPT_TONKHO()
        {
            InitializeComponent();
        }

        private void frmRPT_TONKHO_Load(object sender, EventArgs e)
        {
            HamXuLy.connect();
            string SqlFillCombo1 = "Select * From SANPHAM";
            HamXuLy.FillCombo(SqlFillCombo1, cmbSP, "IDSP", "TENSP");
        }

        private void btnINBC_Click(object sender, EventArgs e)
        {
            if (cbALL.Checked == false)
            {
                if (cmbSP.Text == "" || cmbSP.SelectedValue.ToString() == null)
                {
                    MessageBox.Show("Bạn chưa chọn sản phẩm cần in");
                    cmbSP.Focus();
                    return;
                }
                else
                {
                    idSP = cmbSP.SelectedValue.ToString();
                }

            }

            try
            {
                QL_CUAHANG_THOITRANGDataSet.EnforceConstraints = false;
                if (cbALL.Checked == true)
                {
                    QL_CUAHANG_THOITRANGDataSet.InBCTonKho.Clear();
                    this.InBCTonKhoTableAdapter.Fill(this.QL_CUAHANG_THOITRANGDataSet.InBCTonKho, null);
                }
                else
                {
                    QL_CUAHANG_THOITRANGDataSet.InBCTonKho.Clear();
                    this.InBCTonKhoTableAdapter.Fill(this.QL_CUAHANG_THOITRANGDataSet.InBCTonKho, idSP);
                }
                if (this.QL_CUAHANG_THOITRANGDataSet.InBCTonKho.Rows.Count > 0)
                {
                    this.reportViewer1.RefreshReport();
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu của: " + cmbSP.SelectedValue.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }

        private void btnTAIBC_Click(object sender, EventArgs e)
        {
            if (this.QL_CUAHANG_THOITRANGDataSet.InBCTonKho.Rows.Count > 0)
            {
                try
                {

                    if (cbALL.Checked == true)
                    {
                        QL_CUAHANG_THOITRANGDataSet.InBCTonKho.Clear();
                        this.InBCTonKhoTableAdapter.Fill(this.QL_CUAHANG_THOITRANGDataSet.InBCTonKho, null);
                    }
                    else
                    {
                        QL_CUAHANG_THOITRANGDataSet.InBCTonKho.Clear();
                        this.InBCTonKhoTableAdapter.Fill(this.QL_CUAHANG_THOITRANGDataSet.InBCTonKho, idSP);
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
                    saveFileDialog.FileName = "BaoCao_TonKho.pdf";

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
            QL_CUAHANG_THOITRANGDataSet.InBCTonKho.Clear();
            QL_CUAHANG_THOITRANGDataSet.EnforceConstraints = true;
            this.Close();
        }

        private void cbALL_CheckedChanged(object sender, EventArgs e)
        {
            if (cbALL.Checked == true)
            {
                cmbSP.Enabled = false;
            }
            else
            {
                cmbSP.Enabled = true;
            }
        }

        private void frmRPT_TONKHO_FormClosing(object sender, FormClosingEventArgs e)
        {
            QL_CUAHANG_THOITRANGDataSet.InBCTonKho.Clear();
            QL_CUAHANG_THOITRANGDataSet.EnforceConstraints = true;
        }
    }
}
