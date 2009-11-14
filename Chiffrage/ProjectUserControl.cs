﻿using System;
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
using Grozeille.Chiffrage.Core;

namespace Chiffrage
{
    public partial class ProjectUserControl : UserControl
    {
        private Font defaultFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular,
            System.Drawing.GraphicsUnit.Point, ((byte)(0)));

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
            projectSupplyDtoBindingSource.SuspendBinding();
            var source = new BindingList<ProjectSupplyDto>();
            if (project != null)
            {
                foreach (var item in project.Supplies)
                {
                    var dto = new ProjectSupplyDto();
                    dto.ProjectSupply = item;
                    source.Add(dto);
                }
                projectSupplyDtoBindingSource.DataSource = source;
            }
            projectSupplyDtoBindingSource.ResumeBinding();

            BuildSummary();   
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

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            var page = new AddSupplyPage();
            page.Catalog = this.Catalog;
            var setting = new WizardSetting(page, "Ajouter un matériel", "Ajout d'un matériel au projet", true);
            if (new WizardForm().ShowDialog(setting) == System.Windows.Forms.DialogResult.OK)
            {
                foreach(var item in page.SelectedSupplies)
                {
                    this.project.Supplies.Add(new ProjectSupply
                                                  {
                                                      Quantity = 1,
                                                      Supply = item,
                                                      TestsDays = item.TestsDays,
                                                      TestsNights = 0,
                                                      WorkDays = item.WorkDays,
                                                      WorkLongNights = 0,
                                                      WorkShortNights = 0
                                                  });
                }
                LoadProject();
            }
        }

        private void tabControl_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPage == tabPageSummary)
                BuildSummary();
        }
    }
}
