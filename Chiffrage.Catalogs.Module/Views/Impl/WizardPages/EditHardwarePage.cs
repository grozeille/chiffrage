using System.Linq;
using System.Windows.Forms;
using System.ComponentModel;
using Chiffrage.Catalogs.Module.ViewModel;
using System.Globalization;
using Chiffrage.Catalogs.Domain;
using System.Collections.Generic;
using System;

namespace Chiffrage.Catalogs.Module.Views.Impl.WizardPages
{
    public partial class EditHardwarePage : UserControl
    {
        private IList<TextBox> tasks = new List<TextBox>();

        private IList<Task> catalogTasks = new List<Task>();

        public EditHardwarePage()
        {
            this.InitializeComponent();
        }

        protected override void OnValidating(CancelEventArgs e)
        {
            base.OnValidating(e);

            double tempDouble;

            foreach (var item in tasks)
            {
                HardwareTask task = item.Tag as HardwareTask;
                if (!double.TryParse(item.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out tempDouble))
                {
                    e.Cancel = true;
                    this.errorProvider.SetError(item, "Doit être un nombre");
                }
            }
        }

        public string HardwareName
        {
            get { return this.textBoxHardwareName.Text; }
            set { this.textBoxHardwareName.Text = value; }
        }

        public IList<Task> CatalogTasks
        {
            set
            {
                this.catalogTasks = value;
            }
        }

        public IList<HardwareTask> HardwareTasks
        {
            set
            {
                var hardwareTaskMap = new Dictionary<int, HardwareTask>();
                foreach(var item in value)
                {
                    hardwareTaskMap.Add(item.Task.Id, item);
                }

                this.tableLayoutPanel.RowCount = 3 + value.Count;
                this.tableLayoutPanel.RowStyles.Clear();
                this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
                this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));

                this.tableLayoutPanel.Controls.Clear();
                this.tableLayoutPanel.Controls.Add(this.labelHardware, 0, 0);
                this.tableLayoutPanel.Controls.Add(this.textBoxHardwareName, 1, 0);

                int cptRow = 2;
                int size = 50;
                tasks.Clear();
                
                foreach (var item in this.catalogTasks.OrderBy(x => x.OrderId))
                {
                    HardwareTask hardwareTask;
                    if(!hardwareTaskMap.TryGetValue(item.Id, out hardwareTask))
                    {
                        hardwareTask = new HardwareTask { Task = item };
                    }
                    

                    this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));

                    Label label = new Label();
                    label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
                    label.AutoSize = true;
                    label.Text = new String(new char[] { item.Name[0] }).ToUpper() + item.Name.Substring(1);
                    this.tableLayoutPanel.Controls.Add(label, 0, cptRow);

                    TextBox textbox = new TextBox();
                    textbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
                    textbox.Tag = hardwareTask;
                    textbox.Text = hardwareTask.Value.ToString(CultureInfo.InvariantCulture);
                    this.tableLayoutPanel.Controls.Add(textbox, 1, cptRow);

                    tasks.Add(textbox);

                    size += 26;

                    cptRow++;
                }

                this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
                this.tableLayoutPanel.Height = size;
            }
            get
            {
                var result = new List<HardwareTask>();
                foreach (var item in tasks)
                {
                    var task = item.Tag as HardwareTask;
                    task.Value = Double.Parse(item.Text, NumberStyles.Float, CultureInfo.InvariantCulture);
                    result.Add(task);
                }

                return result;
            }
        }
    }
}