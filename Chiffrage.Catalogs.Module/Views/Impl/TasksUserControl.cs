using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Chiffrage.Mvc.Views;
using Chiffrage.Catalogs.Module.ViewModel;
using Chiffrage.Mvc.Events;
using Chiffrage.Catalogs.Module.Actions;
using Chiffrage.Catalogs.Domain.Commands;
using Chiffrage.Mvc;

namespace Chiffrage.Catalogs.Module.Views.Impl
{
    public partial class TasksUserControl : UserControlView, ITasksView
    {
        private IEventBroker eventBroker;

        private BindingList<TaskViewModel> tasks;

        public TasksUserControl()
        {
            InitializeComponent();
        }

        public TasksUserControl(IEventBroker eventBroker)
            : this()
        {
            this.eventBroker = eventBroker;

            this.eventBroker.RegisterToolStripBouttonClickEventSource(this.toolStripButtonAddSupply, () => new RequestNewTaskAction(), Topics.UI);
            this.eventBroker.RegisterToolStripBouttonClickEventSource(this.toolStripButtonRemoveSupply, () =>
            {
                IDictionary<int, TaskViewModel> selected = new Dictionary<int, TaskViewModel>();
                foreach (DataGridViewCell item in this.dataGridViewTasks.SelectedCells)
                {
                    var supply = this.dataGridViewTasks.Rows[item.RowIndex].DataBoundItem as TaskViewModel;
                    if (!selected.ContainsKey(supply.Id))
                    {
                        selected.Add(supply.Id, supply);
                    }
                }

                if (selected.Count > 0)
                {
                    int maxItems = 10;
                    StringBuilder builder = new StringBuilder();
                    var selectedList = selected.Values.ToList();
                    for (int cpt = 0; cpt < (Math.Min(selected.Count, maxItems)); cpt++)
                    {
                        builder.Append(" - ").AppendLine(selectedList[cpt].Name);
                    }
                    if (selected.Count > maxItems)
                    {
                        builder.AppendLine("...");
                    }

                    var result = MessageBox.Show("Êtes-vous sûr de vouloir supprimer ces tâches: \n" + builder.ToString(), "Supprimer?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    var commands = new List<DeleteTaskCommand>();
                    if (result == DialogResult.OK)
                    {
                        foreach (var item in selectedList)
                        {
                            commands.Add(new DeleteTaskCommand(item.Id));
                        }
                    }

                    return commands;
                }

                return null;
            }, Topics.COMMANDS);

            this.dataGridViewTasks.SetDoubleBuffered();
        }

        public void DisplayTasks(IList<TaskViewModel> tasks, String[] taskTypes, String[] taskCategories)
        {
            this.tasks = tasks == null ? null : new SortableBindingList<TaskViewModel>(tasks);
            this.InvokeIfRequired(() =>
            {
                this.textBoxName.Enabled = false;
                this.comboBoxType.Enabled = false;
                this.comboBoxCategory.Enabled = false;

                this.comboBoxType.Items.Clear();
                if (taskTypes != null)
                {
                    this.comboBoxType.Items.AddRange(taskTypes);
                }

                this.comboBoxCategory.Items.Clear();
                if (taskCategories != null)
                {
                    this.comboBoxCategory.Items.AddRange(taskCategories);
                }

                if (tasks == null)
                {
                    this.taskViewModelBindingSource.DataSource = new SortableBindingList<TaskViewModel>();
                    this.taskViewModelBindingSource.ResetBindings(false);
                }
                else
                {
                    var ordered = tasks.OrderBy(x => x.OrderId);
                    int cpt = 0;
                    foreach (var item in ordered)
                    {
                        item.OrderId = cpt;
                        cpt++;
                    }
                    this.taskViewModelBindingSource.DataSource = this.tasks;
                    this.taskViewModelBindingSource.Sort = "OrderId ASC";
                    this.taskViewModelBindingSource.ResetBindings(false);
                }
            });
        }

        public IList<TaskViewModel> GetViewModel()
        {
            return this.tasks;
        }


        public void DeleteTask(int taskId)
        {
            this.InvokeIfRequired(() =>
            {
                if (tasks != null)
                {
                    var found = this.tasks.Where(x => x.Id == taskId).FirstOrDefault();
                    if (found != null)
                    {
                        this.tasks.Remove(found);
                        this.taskViewModelBindingSource.ResetBindings(false);
                    }
                }
            });
        }

        public void AddTask(TaskViewModel task)
        {
            this.InvokeIfRequired(() =>
            {
                if (tasks != null)
                {
                    this.tasks.Add(task);
                    this.taskViewModelBindingSource.ResetBindings(false);
                }
            });
        }


        public void UpdateTask(TaskViewModel task)
        {
            this.InvokeIfRequired(() =>
            {
                if (tasks != null)
                {
                    var found = this.tasks.Where(x => x.Id == task.Id).FirstOrDefault();
                    if (found != null)
                    {
                        
                        int index = this.tasks.IndexOf(found);
                        this.tasks[index] = task;
                        this.taskViewModelBindingSource.ResetBindings(false);
                    }
                }
            });
        }

        private void comboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            (this.taskViewModelBindingSource.Current as TaskViewModel).Type = this.comboBoxType.SelectedItem.ToString();
        }

        private void comboBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            (this.taskViewModelBindingSource.Current as TaskViewModel).Category = this.comboBoxCategory.SelectedItem.ToString();
        }

        private void taskViewModelBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (this.taskViewModelBindingSource.Current == null)
            {
                this.textBoxName.Enabled = false;
                this.comboBoxType.Enabled = false;
                this.comboBoxCategory.Enabled = false;
            }
            else
            {
                this.textBoxName.Enabled = true;
                this.comboBoxType.Enabled = true;
                this.comboBoxCategory.Enabled = true;
            }
        }

        private void toolStripButtonUp_Click(object sender, EventArgs e)
        {
            var current = this.taskViewModelBindingSource.Current as TaskViewModel;
            var position = this.taskViewModelBindingSource.Position;
            if(current.OrderId > 0)
            {
                current.OrderId--;
                this.tasks.Where(x => x.OrderId == current.OrderId && x.Id != current.Id).First().OrderId++;
                this.taskViewModelBindingSource.ApplySort(TypeDescriptor.GetProperties(typeof(TaskViewModel))["OrderId"], ListSortDirection.Ascending);
                this.dataGridViewTasks.CurrentCell = this.dataGridViewTasks.Rows[position - 1].Cells[0];
            }
        }

        private void toolStripButtonDown_Click(object sender, EventArgs e)
        {
            var current = this.taskViewModelBindingSource.Current as TaskViewModel;
            var position = this.taskViewModelBindingSource.Position;
            if (current.OrderId < this.tasks.Max(x => x.OrderId))
            {
                current.OrderId++;
                this.tasks.Where(x => x.OrderId == current.OrderId && x.Id != current.Id).First().OrderId--;
                this.taskViewModelBindingSource.ApplySort(TypeDescriptor.GetProperties(typeof(TaskViewModel))["OrderId"], ListSortDirection.Ascending);
                this.dataGridViewTasks.CurrentCell = this.dataGridViewTasks.Rows[position + 1].Cells[0];
            }
        }
    }
}
