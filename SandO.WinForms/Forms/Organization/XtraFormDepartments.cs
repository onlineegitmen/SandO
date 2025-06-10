using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Mvvm.Native;
using DevExpress.Xpo;
using SandO.Bll.Managers;
using SandO.Entities.AppClasses;
using SandO.Entities.Db;
using SandO.WinForms.Enums;
using SandO.WinForms.Extensions;
using SandO.WinForms.Forms.Extras;

namespace SandO.WinForms.Forms.Organization
{
    public partial class XtraFormDepartments : XtraForm
    {
        public XtraFormDepartments()
        {
            InitializeComponent();
        }

        private void XtraFormTemps_Load(object sender, EventArgs e)
        {
            ribbonControl.SetRibbonStyle();
            gridViewMain.RestoreLayout();

            GetObjects();
        }

        private void XtraFormTemps_FormClosing(object sender, FormClosingEventArgs e)
        {
            gridViewMain.SaveLayout();
        }

        Department GetGridViewFocusedObject()
        {
            Department focusedRow = gridViewMain.GetFocusedRow() as Department;
            return focusedRow;
        }

        private void barButtonItemNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraFormDepartment form = new XtraFormDepartment();
            form.ShowDialog();
            if (form.ProgressResult.Result)
            {
                WaitFormMain.ShowWaitForm();
                GetObjects();
                WaitFormMain.CloseWaitForm();
            }
        }

        private void barButtonItemUpdate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Department focusedObject = GetGridViewFocusedObject();
            if (focusedObject == null)
            {
                ribbonControl.SetMessage("Güncellenecek kayıt seçiniz.", MessageType.Warning);
                return;
            }

            XtraFormDepartment form = new XtraFormDepartment(focusedObject.Id, FormOpenOption.Update);
            form.ShowDialog();

            if (form.ProgressResult.Result)
            {
                WaitFormMain.ShowWaitForm();
                GetObjects();
                WaitFormMain.CloseWaitForm();
            }
        }

        private void barButtonItemView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Department focusedObject = GetGridViewFocusedObject();
            if (focusedObject == null)
            {
                ribbonControl.SetMessage("Görüntülenecek kayıt seçiniz.", MessageType.Warning);
                return;
            }


            XtraFormDepartment form = new XtraFormDepartment(focusedObject.Id, FormOpenOption.View);
            form.ShowDialog();
        }

        private void barButtonItemDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Department focusedObject = GetGridViewFocusedObject();
            if (focusedObject == null)
            {
                ribbonControl.SetMessage("Silinecek kayıt seçiniz.", MessageType.Warning);
                return;
            }

            if (XtraMessageBox.Show($"Seçili departmanı silmek istediğinize emin misiniz?\nDepartman Adı: {focusedObject.Name}", "Departman Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            CompanyManager companyManager = new CompanyManager();
            WaitFormMain.ShowWaitForm();
            ProgressResult progressResult = companyManager.DeleteDepartment(focusedObject.Id);
            if (progressResult.Result)
            {
                GetObjects();
            }
            WaitFormMain.CloseWaitForm();
            ribbonControl.SetMessage(progressResult.Message, progressResult.Result ? MessageType.Information : MessageType.Error);
        }

        private void barButtonItemRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            WaitFormMain.ShowWaitForm();
            GetObjects();
            WaitFormMain.CloseWaitForm();
        }

        private void GetObjects()
        {
            CompanyManager companyManager = new CompanyManager();
            QueryResult<List<Department>> queryResult = companyManager.GetDepartments();
            if (queryResult.Result)
            {
                gridControlMain.DataSource = queryResult.ResultObject;
            }
            else
            {
                ribbonControl.SetMessage(queryResult.Message, MessageType.Error);
            }
        }

        private void gridControlMain_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
            {
                return;
            }

            popupMenu.ShowPopup(Cursor.Position);
        }

        private void XtraFormTemps_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                WaitFormMain.ShowWaitForm();
                GetObjects();
                WaitFormMain.CloseWaitForm();
            }
            else if (e.Control && e.Shift && e.KeyCode == Keys.N)
            {
                barButtonItemNew_ItemClick(null, null);
            }
        }

        private void barButtonItemExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (XtraSaveFileDialog saveFileDialog = new XtraSaveFileDialog())
            {
                saveFileDialog.Filter = "Excel Dosyası (*.xlsx)|*.xlsx|PDF Dosyası (*.pdf)|*.pdf|Metin Dosyası (*.txt)|*.txt";
                saveFileDialog.Title = "Listeyi Dışa Aktar";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    // Determine export format based on the file extension
                    if (filePath.EndsWith(".xlsx"))
                    {
                        gridViewMain.ExportToXlsx(filePath); // Export to Excel
                    }
                    else if (filePath.EndsWith(".pdf"))
                    {
                        gridViewMain.ExportToPdf(filePath); // Export to PDF
                    }
                    else if (filePath.EndsWith(".txt"))
                    {
                        gridViewMain.ExportToText(filePath); // Export to Text
                    }

                    if (XtraMessageBox.Show($"Liste başarıyla dışa aktarıldı.\nDosya Yolu:{saveFileDialog.FileName}\nDosya açılsın mı?", "Dışa Aktar", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        ProcessStartInfo startInfo = new ProcessStartInfo
                        {
                            FileName = filePath,
                            UseShellExecute = true
                        };

                        Process.Start(startInfo);
                    }
                }
            }
        }
    }
}