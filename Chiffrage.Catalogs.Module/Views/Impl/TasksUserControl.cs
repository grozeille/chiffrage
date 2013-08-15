﻿using System;
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

            this.eventBroker.RegisterToolStripBouttonClickEventSource(this.toolStripButtonAddSupply, () => new RequestNewTaskAction());
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
            });
        }

        public void DisplayTasks(IList<TaskViewModel> tasks, String[] taskTypes)
        {
            this.tasks = tasks == null ? null : new BindingList<TaskViewModel>(tasks);
            this.InvokeIfRequired(() =>
            {
                this.comboBoxType.Items.Clear();
                if (taskTypes != null)
                {
                    this.comboBoxType.Items.AddRange(taskTypes);
                }

                if (tasks == null)
                {
                    this.taskViewModelBindingSource.DataSource = new BindingList<TaskViewModel>();
                    this.taskViewModelBindingSource.ResetBindings(false);
                }
                else
                {
                    this.taskViewModelBindingSource.DataSource = tasks;
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
                        this.tasks.RemoveAt(index);
                        this.tasks.Insert(index, task);
                        this.taskViewModelBindingSource.ResetBindings(false);
                    }
                }
            });
        }

        private void comboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            (this.taskViewModelBindingSource.Current as TaskViewModel).Type = this.comboBoxType.SelectedItem.ToString();
        }
    }
}
