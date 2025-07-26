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
using System.Windows.Forms;

namespace QL_CUAHANG_THOITRANG
{
    public partial class frmRPT_HOADONBAN_KH : Form
    {
        public string idKH;
        public frmRPT_HOADONBAN_KH()
        {
            InitializeComponent();
        }

        private void frmRPT_HOADONBAN_KH_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'QL_CUAHANG_THOITRANGDataSet.HOADONBAN_KH' table. You can move, or remove it, as needed.
            HamXuLy.connect();
            string SqlFillCombo1 = "Select * From KHACHHANG";
            HamXuLy.FillCombo(SqlFillCombo1, cmbKH, "IDKH", "HOTEN");
            

        }

        private void btnINBC_Click(object sender, EventArgs e)
        {
            if (cbALL.Checked == false)
            {
                if (cmbKH.Text == "" || cmbKH.SelectedValue.ToString() == null)
                {
                    MessageBox.Show("Bạn chưa chọn sản phẩm cần in");
                    cmbKH.Focus();
                    return;
                }
                else
                {
                    idKH = cmbKH.SelectedValue.ToString();
                }
                
            }
            
            try
            {
                if (cbALL.Checked == true)
                {
                    this.HOADONBAN_KHTableAdapter.Fill(this.QL_CUAHANG_THOITRANGDataSet.HOADONBAN_KH, null);
                }
                else
                {
                    this.HOADONBAN_KHTableAdapter.Fill(this.QL_CUAHANG_THOITRANGDataSet.HOADONBAN_KH, idKH);
                }
                if (this.QL_CUAHANG_THOITRANGDataSet.HOADONBAN_KH.Rows.Count > 0)
                {
                    this.reportViewer1.RefreshReport();
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu của: " + cmbKH.SelectedValue.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
           
        }

        private void btnTAIBC_Click(object sender, EventArgs e)
        {
            if (this.QL_CUAHANG_THOITRANGDataSet.HOADONBAN_KH.Rows.Count > 0)
            {
                try
                {

                    if (cbALL.Checked == true)
                    {
                        this.HOADONBAN_KHTableAdapter.Fill(this.QL_CUAHANG_THOITRANGDataSet.HOADONBAN_KH, null);
                    }
                    else
                    {
                        this.HOADONBAN_KHTableAdapter.Fill(this.QL_CUAHANG_THOITRANGDataSet.HOADONBAN_KH, idKH);
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
                    saveFileDialog.FileName = "HOADONMUAHANG.pdf";

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
                cmbKH.Enabled = false;
            }
            else
            {
                cmbKH.Enabled = true;
            }
        }
    }
}
