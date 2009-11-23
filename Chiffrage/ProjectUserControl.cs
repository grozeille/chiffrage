using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Chiffrage.Core;
using Chiffrage.Dto;
using Chiffrage.Properties;
using Chiffrage.WizardPages;

namespace Chiffrage
{
    public partial class ProjectUserControl : UserControl
    {
        private Font defaultFont = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular,
                                            GraphicsUnit.Point, ((byte) (0)));

        private Project project;

        public ProjectUserControl()
        {
            InitializeComponent();
        }

        #region Summary

        private void BuildSummary()
        {
            dataGridViewSummary.SuspendLayout();
            dataGridViewSummary.Rows.Clear();
            if (project != null)
            {
                BuildTotalRow(Resources.package, "Total matériel", null, project.TotalSuppliesCost);
                BuildRow("Etude", project.TotalStudyDays, project.StudyRate, project.TotalStudyDaysPrice);
                BuildRow("Saisie", project.TotalReferenceDays, project.ReferenceRate,
                         project.TotalReferenceDaysPrice);
                BuildTotalRow(Resources.map_edit, "Total Etude",
                              project.TotalStudyDays + project.TotalReferenceDays,
                              project.TotalStudyDaysPrice + project.TotalReferenceDaysPrice);
                BuildRow("Traveaux jour", project.TotalWorkDays, project.WorkDayRate, project.TotalWorkDaysPrice);
                BuildRow("Traveaux nuit courte", project.TotalWorkShortNights, project.WorkShortNightsRate,
                         project.TotalWorkShortNightsPrice);
                BuildRow("Traveaux nuit longue", project.TotalWorkLongNights, project.WorkLongNightsRate,
                         project.TotalWorkLongNightsPrice);
                BuildTotalRow(Resources.wrench, "Total Travaux",
                              project.TotalWorkDays + project.TotalWorkShortNights + project.TotalWorkLongNights,
                              project.TotalWorkDaysPrice + project.TotalWorkShortNightsPrice +
                              project.TotalWorkLongNightsPrice);
                BuildRow("Essais jour", project.TotalTestDays, project.TestDayRate, project.TotalTestDayPrice);
                BuildRow("Essais nuit", project.TotalTestNights, project.TestNightRate, project.TotalTestNightPrice);
                BuildTotalRow(Resources.rosette, "Total Essais", project.TotalTestDays + project.TotalTestNights,
                              project.TotalTestDayPrice + project.TotalTestNightPrice);
                BuildTotalRow(Resources.user_suit, "Total Divers", project.TotalOtherDays,
                              project.TotalOtherDaysPrice);
                BuildBigTotalRow(Resources.coins, "Total", project.TotalDays, project.TotalPrice);
            }
            dataGridViewSummary.ResumeLayout(true);
        }

        private void BuildBigTotalRow(Bitmap icon, string name, double? days, double cost)
        {
            int index = dataGridViewSummary.Rows.Add(
                icon,
                name,
                days,
                null,
                cost
                );
            foreach (DataGridViewCell cell in dataGridViewSummary.Rows[index].Cells)
            {
                cell.Style.BackColor = SystemColors.ControlDarkDark;
                cell.Style.Font = new Font(defaultFont, FontStyle.Bold);
                cell.Style.ForeColor = SystemColors.Window;
                cell.ReadOnly = true;
            }
        }

        private void BuildTotalRow(Bitmap icon, string name, double? days, double cost)
        {
            int index = dataGridViewSummary.Rows.Add(
                icon,
                name,
                days,
                null,
                cost
                );
            foreach (DataGridViewCell cell in dataGridViewSummary.Rows[index].Cells)
            {
                cell.Style.BackColor = SystemColors.ControlLight;
                cell.Style.Font = new Font(defaultFont, FontStyle.Bold);
                cell.ReadOnly = true;
            }
        }

        private void BuildRow(string name, double time, double rate, double cost)
        {
            int index = dataGridViewSummary.Rows.Add(
                Resources.blank,
                name,
                time,
                rate,
                cost
                );
            foreach (DataGridViewCell cell in dataGridViewSummary.Rows[index].Cells)
            {
                if (cell.ColumnIndex != 3)
                    cell.ReadOnly = true;
            }
        }

        #endregion

        public Project Project
        {
            get { return project; }
            set
            {
                project = value;
                LoadProject();
            }
        }

        public Catalog Catalog { get; set; }
        public event EventHandler ProjectChanged;

        private void LoadProject()
        {
            if (project == null)
                return;

            projectSupplyDtoBindingSource.SuspendBinding();
            var source = new BindingList<ProjectSupplyDto>();
            foreach (ProjectSupply item in project.Supplies)
            {
                var dto = new ProjectSupplyDto();
                dto.Item = item;
                source.Add(dto);
            }
            projectSupplyDtoBindingSource.DataSource = source;
            projectSupplyDtoBindingSource.ResumeBinding();
            toolStripButtonRemove.Enabled = source.Count > 0;

            projectHarwareDtoBindingSource.SuspendBinding();
            var sourceHardware = new BindingList<ProjectHardwareDto>();
            foreach (ProjectHardware item in project.Hardwares)
            {
                var dto = new ProjectHardwareDto();
                dto.Item = item;
                sourceHardware.Add(dto);
            }
            projectHarwareDtoBindingSource.DataSource = sourceHardware;
            projectHarwareDtoBindingSource.ResumeBinding();
            toolStripButtonRemoveHardware.Enabled = source.Count > 0;

            BuildSummary();

            if (project.Comment == null)
                project.Comment = string.Empty;
            if (!(project.Comment.StartsWith("{\\rtf") && project.Comment.EndsWith("}")))
                project.Comment = "{\\rtf" + project.Comment + "}";
            if (project.StartDate == DateTime.MinValue)
                project.StartDate = DateTime.Now;
            if (project.EndDate == DateTime.MinValue)
                project.EndDate = DateTime.Now;

            projectBindingSource.DataSource = project;
            projectBindingSource.ResetBindings(false);

            otherBenefitBindingSource.SuspendBinding();
            otherBenefitBindingSource.DataSource = new BindingList<OtherBenefit>(project.OtherBenefits);
            otherBenefitBindingSource.ResumeBinding();
        }


        private void toolStripButtonAdd_Click(object sender, EventArgs e)
        {
            var page = new AddCatalogItemPage();
            page.Catalog = Catalog;
            page.DisplayItemType = AddCatalogItemPage.ItemType.Supply;
            var setting = new WizardSetting(page, "Ajouter un matériel", "Ajout d'un matériel au projet", true);
            if (new WizardForm().ShowDialog(setting) == DialogResult.OK)
            {
                foreach (Supply item in page.SelectedItems)
                {
                    project.Supplies.Add(new ProjectSupply
                                             {
                                                 Quantity = 1,
                                                 Item = item.Clone() as Supply,
                                                 TestsDays = item.CatalogTestsDays,
                                                 TestsNights = 0,
                                                 WorkDays = item.CatalogWorkDays,
                                                 WorkLongNights = 0,
                                                 WorkShortNights = 0,
                                                 ExecutiveWorkDays = item.CatalogExecutiveWorkDays,
                                                 ExecutiveWorkLongNights = 0,
                                                 ExecutiveWorkShortNights = 0
                                             });
                }
                LoadProject();
                if (ProjectChanged != null)
                    ProjectChanged(this, new EventArgs());
            }
        }

        private void tabControl_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPage == tabPageSummary)
                BuildSummary();
        }

        private void toolStripButtonRemove_Click(object sender, EventArgs e)
        {
            ProjectSupplyDto current = (projectSupplyDtoBindingSource.Current as ProjectSupplyDto);
            if (current != null)
            {
                var result = MessageBox.Show("Êtes-vous sûr de vouloir supprimer cet item?", "Supprimer",
                                             MessageBoxButtons.OKCancel,
                                             MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    project.Supplies.Remove(current.Item);
                    LoadProject();
                    if (ProjectChanged != null)
                        ProjectChanged(this, new EventArgs());
                }
            }
        }

        private void projectSupplyDtoBindingSource_CurrentItemChanged(object sender, EventArgs e)
        {
            if (ProjectChanged != null)
                ProjectChanged(this, new EventArgs());
        }

        private void projectBindingSource_CurrentItemChanged(object sender, EventArgs e)
        {
            if (ProjectChanged != null)
                ProjectChanged(this, new EventArgs());
        }

        private void textBox_Enter(object sender, EventArgs e)
        {
            (sender as TextBox).SelectAll();
        }

        private void otherBenefitBindingSource_CurrentItemChanged(object sender, EventArgs e)
        {
            if (ProjectChanged != null)
                ProjectChanged(this, new EventArgs());
        }

        private void tabPageWork_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewWork_Scroll(object sender, ScrollEventArgs e)
        {
            //dataGridViewWorkExecutive.
        }

        private void toolStripButtonAddHardware_Click(object sender, EventArgs e)
        {
            var page = new AddCatalogItemPage();
            page.Catalog = Catalog;
            page.DisplayItemType = AddCatalogItemPage.ItemType.Hardware;
            var setting = new WizardSetting(page, "Ajouter un matériel", "Ajout d'un matériel au projet", true);
            if (new WizardForm().ShowDialog(setting) == DialogResult.OK)
            {
                foreach (Hardware item in page.SelectedItems)
                {
                    project.Hardwares.Add(new ProjectHardware
                    {
                        Quantity = 1,
                        Item = item.Clone() as Hardware,
                        TestsDays = item.CatalogTestsDays,
                        TestsNights = 0,
                        WorkDays = item.CatalogWorkDays,
                        WorkLongNights = 0,
                        WorkShortNights = 0,
                        ExecutiveWorkDays = item.CatalogExecutiveWorkDays,
                        ExecutiveWorkLongNights = 0,
                        ExecutiveWorkShortNights = 0
                    });
                }
                LoadProject();
                if (ProjectChanged != null)
                    ProjectChanged(this, new EventArgs());
            }
        }

        private void toolStripButtonRemoveHardware_Click(object sender, EventArgs e)
        {
            ProjectHardwareDto current = (projectHarwareDtoBindingSource.Current as ProjectHardwareDto);
            if (current != null)
            {
                var result = MessageBox.Show("Êtes-vous sûr de vouloir supprimer cet item?", "Supprimer",
                                             MessageBoxButtons.OKCancel,
                                             MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    project.Hardwares.Remove(current.Item);
                    LoadProject();
                    if (ProjectChanged != null)
                        ProjectChanged(this, new EventArgs());
                }
            }
        }
    }
}