using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SandO.Bll.Managers;
using SandO.Entities.AppClasses;
using SandO.Entities.AppClasses.Organization;
using SandO.Entities.Db;
using SandO.WinForms.Forms.Extras;

namespace SandO.WinForms.Forms.UserGroup.UserControl
{
    public partial class XtraUcUserDepartment : DevExpress.XtraEditors.XtraUserControl
    {
        public UserDepartment UserDepartment { get; set; }
        public XtraUcUserDepartment()
        {
            InitializeComponent();
        }

        private void XtraUcUserDepartment_Load(object sender, EventArgs e)
        {
            CompanyManager companyManager = new CompanyManager();
            QueryResult<List<CompanyForSelection>> companiesForSelection = companyManager.GetCompaniesForSelection(includePlants: true);

            comboBoxEditCompanies.Properties.Items.AddRange(companiesForSelection.ResultObject);

            QueryResult<List<DepartmentForSelection>> departmentForSelection = companyManager.GetDepartmentsForSelection();
            comboBoxEditDepartments.Properties.Items.AddRange(departmentForSelection.ResultObject);

            QueryResult<List<AppellationForSelection>> appellationForSelection = companyManager.GetAppellationsForSelection();
            comboBoxEditAppelations.Properties.Items.AddRange(appellationForSelection.ResultObject);
        }

        private void comboBoxEditCompanies_SelectedIndexChanged(object sender, EventArgs e)
        {
            CompanyForSelection companyForSelection = comboBoxEditCompanies.SelectedItem as CompanyForSelection;
            if (companyForSelection == null)
            {
                return;
            }

            comboBoxEditPlants.EditValue = null;
            comboBoxEditPlants.Properties.Items.Clear();
            comboBoxEditPlants.Properties.Items.AddRange(companyForSelection.PlantForSelections);

        }
    }
}
