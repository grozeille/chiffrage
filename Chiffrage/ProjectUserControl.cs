using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Chiffrage.Dto;
using Chiffrage.Properties;
using Chiffrage.WizardPages;
using Chiffrage.Core;

namespace Chiffrage
{
    public partial class ProjectUserControl : UserControl
    {
        private Font defaultFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular,
            System.Drawing.GraphicsUnit.Point, ((byte)(0)));

        public event EventHandler ProjectChanged;

        private Project project;
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

        private void LoadProject()
        {
            if (this.project == null)
                return;

            projectSupplyDtoBindingSource.SuspendBinding();
            var source = new BindingList<ProjectSupplyDto>();
            foreach (var item in project.Supplies)
            {
                var dto = new ProjectSupplyDto();
                dto.ProjectSupply = item;
                source.Add(dto);
            }
            projectSupplyDtoBindingSource.DataSource = source;
            projectSupplyDtoBindingSource.CurrentItemChanged +=new EventHandler(projectSupplyDtoBindingSource_CurrentItemChanged);
            projectSupplyDtoBindingSource.ResumeBinding();

            BuildSummary();

            if (this.project.Comment == null)
                this.project.Comment = string.Empty;
            if (!(this.project.Comment.StartsWith("{\\rtf") && this.project.Comment.EndsWith("}")))
                this.project.Comment = "{\\rtf" + this.project.Comment + "}";
            if (this.project.StartDate == DateTime.MinValue)
                this.project.StartDate = DateTime.Now;
            if (this.project.EndDate == DateTime.MinValue)
                this.project.EndDate = DateTime.Now;

            this.projectBindingSource.DataSource = project;
            this.projectBindingSource.ResetBindings(false);
        }


        public ProjectUserControl()
        {
            InitializeComponent();
        }

        #region Summary
        private void BuildSummary()
        {
            this.dataGridViewSummary.SuspendLayout();
            this.dataGridViewSummary.Rows.Clear();
            if (project != null)
            {
                this.BuildTotalRow(Resources.package, "Total matériel", null, project.TotalSuppliesCost);
                this.BuildRow("Etude", project.TotalStudyDays, project.StudyRate, project.TotalStudyDaysPrice);
                this.BuildRow("Saisie", project.TotalReferenceDays, project.ReferenceRate,
                              project.TotalReferenceDaysPrice);
                this.BuildTotalRow(Resources.map_edit, "Total Etude",
                                   project.TotalStudyDays + project.TotalReferenceDays,
                                   project.TotalStudyDaysPrice + project.TotalReferenceDaysPrice);
                this.BuildRow("Traveaux jour", project.TotalWorkDays, project.WorkDayRate, project.TotalWorkDaysPrice);
                this.BuildRow("Traveaux nuit courte", project.TotalWorkShortNights, project.WorkShortNightsRate,
                              project.TotalWorkShortNightsPrice);
                this.BuildRow("Traveaux nuit longue", project.TotalWorkLongNights, project.WorkLongNightsRate,
                              project.TotalWorkLongNightsPrice);
                this.BuildTotalRow(Resources.wrench, "Total Travaux",
                                   project.TotalWorkDays + project.TotalWorkShortNights + project.TotalWorkLongNights,
                                   project.TotalWorkDaysPrice + project.TotalWorkShortNightsPrice +
                                   project.TotalWorkLongNightsPrice);
                this.BuildRow("Essais jour", project.TotalTestDays, project.TestDayRate, project.TotalTestDayPrice);
                this.BuildRow("Essais nuit", project.TotalTestNights, project.TestNightRate, project.TotalTestNightPrice);
                this.BuildTotalRow(Resources.rosette, "Total Essais", project.TotalTestDays + project.TotalTestNights,
                                   project.TotalTestDayPrice + project.TotalTestNightPrice);
                this.BuildTotalRow(Resources.user_suit, "Total Divers", project.TotalOtherDays,
                                   project.TotalOtherDaysPrice);
                this.BuildBigTotalRow(Resources.coins, "Total", project.TotalDays, project.TotalPrice);
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
                cell.Style.Font = new Font(defaultFont, FontStyle.Bold);
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
                cell.Style.Font = new Font(defaultFont, FontStyle.Bold);
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

        private void toolStripButtonAdd_Click(object sender, EventArgs e)
        {
            var page = new AddSupplyPage();
            page.Catalog = this.Catalog;
            var setting = new WizardSetting(page, "Ajouter un matériel", "Ajout d'un matériel au projet", true);
            if (new WizardForm().ShowDialog(setting) == System.Windows.Forms.DialogResult.OK)
            {
                foreach (var item in page.SelectedSupplies)
                {
                    this.project.Supplies.Add(new ProjectSupply
                                                  {
                                                      Quantity = 1,
                                                      Supply = item.Clone() as Supply,
                                                      TestsDays = item.TestsDays,
                                                      TestsNights = 0,
                                                      WorkDays = item.WorkDays,
                                                      WorkLongNights = 0,
                                                      WorkShortNights = 0
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
            if (MessageBox.Show("Êtes-vous sûr de vouloir supprimer cet item?", "Supprimer", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                this.projectSupplyDtoBindingSource.RemoveCurrent();
                if (ProjectChanged != null)
                    ProjectChanged(this, new EventArgs());
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
    }
}
