using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Chiffrage.App.ViewModel;
using Chiffrage.Catalogs.Domain;
using Chiffrage.Projects.Domain;
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
            this.InitializeComponent();
        }

        #region Summary

        private void BuildSummary()
        {
            this.dataGridViewSummary.SuspendLayout();
            this.dataGridViewSummary.Rows.Clear();
            if (this.project != null)
            {
                this.BuildTotalRow(Resources.package, "Total matériel", null, this.project.TotalSuppliesCost);
                this.BuildRow("Etude", this.project.TotalStudyDays, this.project.StudyRate,
                              this.project.TotalStudyDaysPrice);
                this.BuildRow("Saisie", this.project.TotalReferenceDays, this.project.ReferenceRate,
                              this.project.TotalReferenceDaysPrice);
                this.BuildTotalRow(Resources.map_edit, "Total Etude",
                                   this.project.TotalStudyDays + this.project.TotalReferenceDays,
                                   this.project.TotalStudyDaysPrice + this.project.TotalReferenceDaysPrice);
                this.BuildRow("Traveaux jour", this.project.TotalWorkDays, this.project.WorkDayRate,
                              this.project.TotalWorkDaysPrice);
                this.BuildRow("Traveaux nuit courte", this.project.TotalWorkShortNights,
                              this.project.WorkShortNightsRate,
                              this.project.TotalWorkShortNightsPrice);
                this.BuildRow("Traveaux nuit longue", this.project.TotalWorkLongNights, this.project.WorkLongNightsRate,
                              this.project.TotalWorkLongNightsPrice);
                this.BuildTotalRow(Resources.wrench, "Total Travaux",
                                   this.project.TotalWorkDays + this.project.TotalWorkShortNights +
                                   this.project.TotalWorkLongNights,
                                   this.project.TotalWorkDaysPrice + this.project.TotalWorkShortNightsPrice +
                                   this.project.TotalWorkLongNightsPrice);
                this.BuildRow("Essais jour", this.project.TotalTestDays, this.project.TestDayRate,
                              this.project.TotalTestDayPrice);
                this.BuildRow("Essais nuit", this.project.TotalTestNights, this.project.TestNightRate,
                              this.project.TotalTestNightPrice);
                this.BuildTotalRow(Resources.rosette, "Total Essais",
                                   this.project.TotalTestDays + this.project.TotalTestNights,
                                   this.project.TotalTestDayPrice + this.project.TotalTestNightPrice);
                this.BuildTotalRow(Resources.user_suit, "Total Divers", this.project.TotalOtherDays,
                                   this.project.TotalOtherDaysPrice);
                this.BuildBigTotalRow(Resources.coins, "Total", this.project.TotalDays, this.project.TotalPrice);
            }
            this.dataGridViewSummary.ResumeLayout(true);
        }

        private void BuildBigTotalRow(Bitmap icon, string name, double? days, double cost)
        {
            int index = this.dataGridViewSummary.Rows.Add(
                icon,
                name,
                days,
                null,
                cost
                );
            foreach (DataGridViewCell cell in this.dataGridViewSummary.Rows[index].Cells)
            {
                cell.Style.BackColor = SystemColors.ControlDarkDark;
                cell.Style.Font = new Font(this.defaultFont, FontStyle.Bold);
                cell.Style.ForeColor = SystemColors.Window;
                cell.ReadOnly = true;
            }
        }

        private void BuildTotalRow(Bitmap icon, string name, double? days, double cost)
        {
            int index = this.dataGridViewSummary.Rows.Add(
                icon,
                name,
                days,
                null,
                cost
                );
            foreach (DataGridViewCell cell in this.dataGridViewSummary.Rows[index].Cells)
            {
                cell.Style.BackColor = SystemColors.ControlLight;
                cell.Style.Font = new Font(this.defaultFont, FontStyle.Bold);
                cell.ReadOnly = true;
            }
        }

        private void BuildRow(string name, double time, double rate, double cost)
        {
            int index = this.dataGridViewSummary.Rows.Add(
                Resources.blank,
                name,
                time,
                rate,
                cost
                );
            foreach (DataGridViewCell cell in this.dataGridViewSummary.Rows[index].Cells)
            {
                if (cell.ColumnIndex != 3)
                    cell.ReadOnly = true;
            }
        }

        #endregion

        public Project Project
        {
            get { return this.project; }
            set
            {
                this.project = value;
                this.LoadProject();
            }
        }

        public Catalog Catalog { get; set; }
        public event EventHandler ProjectChanged;

        private void LoadProject()
        {
            if (this.project == null)
                return;

            this.projectSupplyDtoBindingSource.SuspendBinding();
            var source = new BindingList<ProjectSupplyViewModel>();
            foreach (ProjectSupply item in this.project.Supplies)
            {
                var dto = new ProjectSupplyViewModel();
                dto.Item = item;
                source.Add(dto);
            }
            this.projectSupplyDtoBindingSource.DataSource = source;
            this.projectSupplyDtoBindingSource.ResumeBinding();
            this.toolStripButtonRemove.Enabled = source.Count > 0;

            this.projectHarwareDtoBindingSource.SuspendBinding();
            var sourceHardware = new BindingList<ProjectHardwareViewModel>();
            foreach (ProjectHardware item in this.project.Hardwares)
            {
                var dto = new ProjectHardwareViewModel();
                dto.Item = item;
                sourceHardware.Add(dto);
            }
            this.projectHarwareDtoBindingSource.DataSource = sourceHardware;
            this.projectHarwareDtoBindingSource.ResumeBinding();
            this.toolStripButtonRemoveHardware.Enabled = source.Count > 0;

            this.BuildSummary();

            if (this.project.Comment == null)
                this.project.Comment = string.Empty;
            if (!(this.project.Comment.StartsWith("{\\rtf") && this.project.Comment.EndsWith("}")))
                this.project.Comment = "{\\rtf" + this.project.Comment + "}";
            if (this.project.StartDate == DateTime.MinValue)
                this.project.StartDate = DateTime.Now;
            if (this.project.EndDate == DateTime.MinValue)
                this.project.EndDate = DateTime.Now;

            this.projectBindingSource.DataSource = this.project;
            this.projectBindingSource.ResetBindings(false);

            this.otherBenefitBindingSource.SuspendBinding();
            this.otherBenefitBindingSource.DataSource = new BindingList<OtherBenefit>(this.project.OtherBenefits);
            this.otherBenefitBindingSource.ResumeBinding();
        }


        private void toolStripButtonAdd_Click(object sender, EventArgs e)
        {
            var page = new AddCatalogItemPage();
            page.Catalog = this.Catalog;
            page.DisplayItemType = AddCatalogItemPage.ItemType.Supply;
            var setting = new WizardSetting(page, "Ajouter un matériel", "Ajout d'un matériel au projet", true);
            if (new WizardForm().ShowDialog(setting) == DialogResult.OK)
            {
                foreach (Supply item in page.SelectedItems)
                {
                    this.project.Supplies.Add(new ProjectSupply(item)
                    {
                        Quantity = 1,
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
                this.LoadProject();
                if (this.ProjectChanged != null)
                    this.ProjectChanged(this, new EventArgs());
            }
        }

        private void tabControl_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPage == this.tabPageSummary)
                this.BuildSummary();
        }

        private void toolStripButtonRemove_Click(object sender, EventArgs e)
        {
            var current = (this.projectSupplyDtoBindingSource.Current as ProjectSupplyViewModel);
            if (current != null)
            {
                var result = MessageBox.Show("Êtes-vous sûr de vouloir supprimer cet item?", "Supprimer",
                                             MessageBoxButtons.OKCancel,
                                             MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    this.project.Supplies.Remove(current.Item);
                    this.LoadProject();
                    if (this.ProjectChanged != null)
                        this.ProjectChanged(this, new EventArgs());
                }
            }
        }

        private void projectSupplyDtoBindingSource_CurrentItemChanged(object sender, EventArgs e)
        {
            if (this.ProjectChanged != null)
                this.ProjectChanged(this, new EventArgs());
        }

        private void projectBindingSource_CurrentItemChanged(object sender, EventArgs e)
        {
            if (this.ProjectChanged != null)
                this.ProjectChanged(this, new EventArgs());
        }

        private void textBox_Enter(object sender, EventArgs e)
        {
            (sender as TextBox).SelectAll();
        }

        private void otherBenefitBindingSource_CurrentItemChanged(object sender, EventArgs e)
        {
            if (this.ProjectChanged != null)
                this.ProjectChanged(this, new EventArgs());
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
            page.Catalog = this.Catalog;
            page.DisplayItemType = AddCatalogItemPage.ItemType.Hardware;
            var setting = new WizardSetting(page, "Ajouter un matériel", "Ajout d'un matériel au projet", true);
            if (new WizardForm().ShowDialog(setting) == DialogResult.OK)
            {
                foreach (Hardware item in page.SelectedItems)
                {
                    this.project.Hardwares.Add(new ProjectHardware(item)
                    {
                        Quantity = 1,
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
                this.LoadProject();
                if (this.ProjectChanged != null)
                    this.ProjectChanged(this, new EventArgs());
            }
        }

        private void toolStripButtonRemoveHardware_Click(object sender, EventArgs e)
        {
            var current = (this.projectHarwareDtoBindingSource.Current as ProjectHardwareViewModel);
            if (current != null)
            {
                var result = MessageBox.Show("Êtes-vous sûr de vouloir supprimer cet item?", "Supprimer",
                                             MessageBoxButtons.OKCancel,
                                             MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    this.project.Hardwares.Remove(current.Item);
                    this.LoadProject();
                    if (this.ProjectChanged != null)
                        this.ProjectChanged(this, new EventArgs());
                }
            }
        }

        private void tabControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            //e.DrawBackground();
            var control = (TabControl) sender;
            e.Bounds.Inflate(this.imageListProject.Images[0].Width + 4, 0);
            e.Graphics.DrawImage(this.imageListProject.Images[0], e.Bounds.X + 2, e.Bounds.Y + 2);
            var drawBrush = new SolidBrush(Color.Black);
            e.Graphics.DrawString("toto", control.Font, drawBrush, 0, 0);
            e.Graphics.DrawString(
                control.TabPages[e.Index].Text,
                control.Font,
                drawBrush,
                e.Bounds.X + 2 + this.imageListProject.Images[0].Size.Width + 2,
                e.Bounds.Y + 2);
        }
    }
}