﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using Chiffrage.Catalogs.Domain;
using Chiffrage.Projects.Domain;
using Chiffrage.Catalogs.Module.ViewModel;
using Chiffrage.Projects.Module.ViewModel;

namespace Chiffrage.Projects.Module.Views.Impl.WizardPages
{
    public partial class EditProjectHardwarePage : UserControl
    {
        private class TextBoxWithComboBox
        {
            public TextBox TextBox { get; set; }

            public ComboBox ComboBox { get; set; }

            public ProjectHardwareTask ProjectHardwareTask { get; set; }
        }

        private IList<TextBoxWithComboBox> tasks = new List<TextBoxWithComboBox>();

        private IList<ProjectTask> projectTasks = new List<ProjectTask>();

        public EditProjectHardwarePage()
        {
            InitializeComponent();
        }

        protected override void OnValidating(CancelEventArgs e)
        {
            base.OnValidating(e);

            double tempDouble;

            if (!double.TryParse(this.textBoxMilestone.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out tempDouble))
            {
                e.Cancel = true;
                this.errorProvider.SetError(this.textBoxMilestone, "Doit être un nombre");
            }

            foreach (var item in tasks)
            {
                if (!double.TryParse(item.TextBox.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out tempDouble))
                {
                    e.Cancel = true;
                    this.errorProvider.SetError(item.TextBox, "Doit être un nombre");
                }
            }
        }
        
        public string HardwareName
        {
            set { this.textBoxHardwareName.Text = value; }
        }

        public double Milestone
        {
            get { return double.Parse(this.textBoxMilestone.Text, NumberStyles.Float, CultureInfo.InvariantCulture); }
            set { this.textBoxMilestone.Text = value.ToString(CultureInfo.InvariantCulture); }
        }

        public IList<ProjectTask> ProjectTasks
        {
            set
            {
                this.projectTasks = value;
            }
        }

        public IList<ProjectHardwareTask> HardwareTasks
        {
            set
            {
                var taskMap = new Dictionary<int, ProjectTask>();
                foreach (var item in projectTasks.OrderBy(x => x.OrderId))
                {
                    taskMap.Add(item.Id, item);
                }

                this.tableLayoutPanel.RowCount = 5 + (value.Count * 2);
                this.tableLayoutPanel.RowStyles.Clear();
                this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
                this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));

                this.tableLayoutPanel.Controls.Clear();
                this.tableLayoutPanel.Controls.Add(this.labelHardware, 0, 0);
                this.tableLayoutPanel.Controls.Add(this.textBoxHardwareName, 1, 0);

                int cptRow = 4;
                int size = 75;
                tasks.Clear();

                var orderedTasks = value.OrderBy(x => x.Task.OrderId);
                foreach (var item in orderedTasks)
                {
                    taskMap.Remove(item.Id);

                    // la valeur du catalogue
                    this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));

                    Label catalogLabel = new Label();
                    catalogLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
                    catalogLabel.AutoSize = true;
                    catalogLabel.Text = new String(new char[] { item.Task.Name[0] }).ToUpper() + item.Task.Name.Substring(1) + " (catalogue)";
                    this.tableLayoutPanel.Controls.Add(catalogLabel, 0, cptRow);

                    TextBox catalogTextbox = new TextBox();
                    catalogTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
                    catalogTextbox.Text = item.CatalogValue.ToString(CultureInfo.InvariantCulture);
                    catalogTextbox.Enabled = false;
                    this.tableLayoutPanel.Controls.Add(catalogTextbox, 1, cptRow);
                    
                    size += 26;

                    cptRow++;

                    // la valeur saisie
                    this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));

                    Label label = new Label();
                    label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
                    label.AutoSize = true;
                    label.Text = new String(new char[] { item.Task.Name[0] }).ToUpper() + item.Task.Name.Substring(1);
                    this.tableLayoutPanel.Controls.Add(label, 0, cptRow);

                    TextBox textbox = new TextBox();
                    textbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
                    textbox.Text = item.Value.ToString(CultureInfo.InvariantCulture);
                    this.tableLayoutPanel.Controls.Add(textbox, 1, cptRow);

                    ComboBox comboBox = new ComboBox();
                    comboBox.Size = new System.Drawing.Size(20, comboBox.Size.Height);
                    comboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
                    if (item.Task.Type == TaskType.DAYS)
                    {
                        comboBox.Items.AddRange(new String[] { ProjectHardwareTaskTypeConsts.DAY });
                    }
                    else if (item.Task.Type == TaskType.DAYS_NIGHT)
                    {
                        comboBox.Items.AddRange(new String[] { ProjectHardwareTaskTypeConsts.DAY, ProjectHardwareTaskTypeConsts.NIGHT });
                    }
                    else if (item.Task.Type == TaskType.DAYS_LONGNIGHT_SHORTNIGHT)
                    {
                        comboBox.Items.AddRange(new String[] { ProjectHardwareTaskTypeConsts.DAY, ProjectHardwareTaskTypeConsts.SHORT_NIGHT, ProjectHardwareTaskTypeConsts.LONG_NIGHT });
                    }
                    comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                    comboBox.Text = ProjectHardwareTaskTypeConsts.ToString(item.HardwareTaskType);
                    this.tableLayoutPanel.Controls.Add(comboBox, 2, cptRow);

                    var textBoxWithComboBox = new TextBoxWithComboBox { TextBox = textbox, ComboBox = comboBox, ProjectHardwareTask = item };

                    tasks.Add(textBoxWithComboBox);

                    size += 26;

                    cptRow++;
                }

                foreach (var item in taskMap.Values)
                {
                    // la valeur du catalogue
                    this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));

                    Label catalogLabel = new Label();
                    catalogLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
                    catalogLabel.AutoSize = true;
                    catalogLabel.Text = new String(new char[] { item.Name[0] }).ToUpper() + item.Name.Substring(1) + " (catalogue)";
                    this.tableLayoutPanel.Controls.Add(catalogLabel, 0, cptRow);

                    TextBox catalogTextbox = new TextBox();
                    catalogTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
                    catalogTextbox.Text = "0.0";
                    catalogTextbox.Enabled = false;
                    this.tableLayoutPanel.Controls.Add(catalogTextbox, 1, cptRow);

                    size += 26;

                    cptRow++;

                    // la valeur saisie
                    this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));

                    Label label = new Label();
                    label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
                    label.AutoSize = true;
                    label.Text = new String(new char[] { item.Name[0] }).ToUpper() + item.Name.Substring(1);
                    this.tableLayoutPanel.Controls.Add(label, 0, cptRow);

                    TextBox textbox = new TextBox();
                    textbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
                    textbox.Text = "0.0";
                    this.tableLayoutPanel.Controls.Add(textbox, 1, cptRow);

                    ComboBox comboBox = new ComboBox();
                    comboBox.Size = new System.Drawing.Size(20, comboBox.Size.Height);
                    comboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
                    if (item.Type == TaskType.DAYS)
                    {
                        comboBox.Items.AddRange(new String[] { ProjectHardwareTaskTypeConsts.DAY });
                    }
                    else if (item.Type == TaskType.DAYS_NIGHT)
                    {
                        comboBox.Items.AddRange(new String[] { ProjectHardwareTaskTypeConsts.DAY, ProjectHardwareTaskTypeConsts.NIGHT });
                    }
                    else if (item.Type == TaskType.DAYS_LONGNIGHT_SHORTNIGHT)
                    {
                        comboBox.Items.AddRange(new String[] { ProjectHardwareTaskTypeConsts.DAY, ProjectHardwareTaskTypeConsts.SHORT_NIGHT, ProjectHardwareTaskTypeConsts.LONG_NIGHT });
                    }
                    comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                    comboBox.Text = ProjectHardwareTaskTypeConsts.DAY;
                    this.tableLayoutPanel.Controls.Add(comboBox, 2, cptRow);

                    var textBoxWithComboBox = new TextBoxWithComboBox
                    {
                        TextBox = textbox,
                        ComboBox = comboBox,
                        ProjectHardwareTask = new ProjectHardwareTask
                        {
                            Task = item,
                            HardwareTaskType = ProjectHardwareTaskType.DAY,
                            Value = 0.0
                        }
                    };

                    tasks.Add(textBoxWithComboBox);

                    size += 26;

                    cptRow++;
                }

                this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
                this.tableLayoutPanel.Height = size;
            }
            get
            {
                var result = new List<ProjectHardwareTask>();
                foreach (var item in tasks)
                {
                    var task = item.ProjectHardwareTask;
                    task.Value = Double.Parse(item.TextBox.Text, NumberStyles.Float, CultureInfo.InvariantCulture);
                    task.HardwareTaskType = ProjectHardwareTaskTypeConsts.ParseString(item.ComboBox.Text);
                    result.Add(task);
                }

                return result;
            }
        }
    }
}
