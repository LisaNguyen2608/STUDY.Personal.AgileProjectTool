using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AgileTool.Controllers;

namespace AgileTool.GUI
{
    public partial class Form1 : Form
    {
        private ProjectController _projCtrl = new ProjectController();
        private PersonController _persCtrl = new PersonController();
        private UserStoryController _storyCtrl = new UserStoryController();
        private TaskController _taskCtrl = new TaskController();

        public Form1() { InitializeComponent(); }

        private void ShowPanel(Panel activePanel)
        {
            pnlProjectActions.Visible = false;
            pnlPersonActions.Visible = false;
            pnlStoryActions.Visible = false;
            pnlTaskActions.Visible = false;
            if (activePanel != null) activePanel.Visible = true;

            // Clear all input fields
            txtName.Clear(); txtDesc.Clear(); txtID1.Clear();
            txtID2.Clear(); txtVal1.Clear(); txtVal2.Clear();
        }

        // --- NAVIGATION ---
        private void btnNavProject_Click(object sender, EventArgs e) { ShowPanel(pnlProjectActions); RefreshProjects(); }
        private void btnNavPerson_Click(object sender, EventArgs e) { ShowPanel(pnlPersonActions); RefreshPersons(); }
        private void btnNavStory_Click(object sender, EventArgs e) { ShowPanel(pnlStoryActions); RefreshStories(); }
        private void btnNavTask_Click(object sender, EventArgs e) { ShowPanel(pnlTaskActions); RefreshTasks(); }

        // --- PROJECT ACTIONS ---
        private void btnCreateProject_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtName.Text))
            {
                _projCtrl.CreateProject(txtName.Text, txtDesc.Text);
                RefreshProjects();
            }
        }

        // --- PERSON ACTIONS ---
        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtName.Text))
            {
                _persCtrl.AddPerson(txtName.Text, txtDesc.Text); // txtDesc is used for Role here
                RefreshPersons();
            }
        }

        // --- STORY ACTIONS (TASK 4) ---
        private void btnAddStory_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtID1.Text, out int pid) && int.TryParse(txtVal1.Text, out int prio))
            {
                _storyCtrl.AddStory(pid, txtDesc.Text, prio);
                RefreshStories();
            }
        }
        private void btnDeleteStory_Click(object sender, EventArgs e)
        {
            int id = GetSelectedId();
            if (id != -1) { _storyCtrl.DeleteStory(id); RefreshStories(); }
        }

        // --- TASK ACTIONS (TASK 5 & 6) ---
        private void btnAddTask_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtID1.Text, out int sid) && int.TryParse(txtVal1.Text, out int prio) && int.TryParse(txtVal2.Text, out int diff))
            {
                _taskCtrl.AddTask(sid, txtDesc.Text, prio, diff);
                RefreshTasks();
            }
        }
        private void btnAssignPerson_Click(object sender, EventArgs e)
        {
            int tid = GetSelectedId();
            if (tid != -1 && int.TryParse(txtID1.Text, out int pid)) _taskCtrl.AssignPerson(tid, pid);
        }
        private void btnUnassignPerson_Click(object sender, EventArgs e)
        {
            int tid = GetSelectedId();
            if (tid != -1 && int.TryParse(txtID1.Text, out int pid)) _taskCtrl.UnassignPerson(tid, pid);
        }
        private void btnUpdatePriority_Click(object sender, EventArgs e)
        {
            int tid = GetSelectedId();
            if (tid != -1 && int.TryParse(txtVal1.Text, out int prio)) { _taskCtrl.UpdatePriority(tid, prio); RefreshTasks(); }
        }

        // --- LIST REFRESH METHODS ---
        private void RefreshProjects() { listBoxMain.Items.Clear(); foreach (var p in _projCtrl.GetAllProjects()) listBoxMain.Items.Add($"{p.Id}. {p.Name}"); }
        private void RefreshPersons() { listBoxMain.Items.Clear(); foreach (var p in _persCtrl.GetAllPersons()) listBoxMain.Items.Add($"{p.Id}. {p.Name} ({p.Role})"); }
        private void RefreshStories() { listBoxMain.Items.Clear(); foreach (var s in _storyCtrl.GetAllStories()) listBoxMain.Items.Add($"{s.Id}. {s.Description}"); }
        private void RefreshTasks() { listBoxMain.Items.Clear(); foreach (var t in _taskCtrl.GetAllTasks()) listBoxMain.Items.Add($"{t.Id}. {t.Description} (P: {t.Priority})"); }

        private int GetSelectedId()
        {
            if (listBoxMain.SelectedItem == null) return -1;
            string txt = listBoxMain.SelectedItem.ToString();
            return txt.Contains(".") ? int.Parse(txt.Split('.')[0]) : -1;
        }

        private void Form1_Load(object sender, EventArgs e) { }
    }
}