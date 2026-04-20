namespace AgileTool.GUI
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlSideBar = new System.Windows.Forms.Panel();
            this.btnNavTask = new System.Windows.Forms.Button();
            this.btnNavStory = new System.Windows.Forms.Button();
            this.btnNavPerson = new System.Windows.Forms.Button();
            this.btnNavProject = new System.Windows.Forms.Button();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.listBoxMain = new System.Windows.Forms.ListBox();
            this.lblLabels = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.txtID1 = new System.Windows.Forms.TextBox();
            this.txtID2 = new System.Windows.Forms.TextBox();
            this.txtVal1 = new System.Windows.Forms.TextBox();
            this.txtVal2 = new System.Windows.Forms.TextBox();
            this.pnlProjectActions = new System.Windows.Forms.Panel();
            this.btnCreateProject = new System.Windows.Forms.Button();
            this.pnlPersonActions = new System.Windows.Forms.Panel();
            this.btnAddPerson = new System.Windows.Forms.Button();
            this.pnlStoryActions = new System.Windows.Forms.Panel();
            this.btnDeleteStory = new System.Windows.Forms.Button();
            this.btnAddStory = new System.Windows.Forms.Button();
            this.pnlTaskActions = new System.Windows.Forms.Panel();
            this.btnUpdatePriority = new System.Windows.Forms.Button();
            this.btnUnassignPerson = new System.Windows.Forms.Button();
            this.btnAssignPerson = new System.Windows.Forms.Button();
            this.btnAddTask = new System.Windows.Forms.Button();
            this.pnlSideBar.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlProjectActions.SuspendLayout();
            this.pnlPersonActions.SuspendLayout();
            this.pnlStoryActions.SuspendLayout();
            this.pnlTaskActions.SuspendLayout();
            this.SuspendLayout();
             
            // pnlSideBar
             
            this.pnlSideBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.pnlSideBar.Controls.Add(this.btnNavTask);
            this.pnlSideBar.Controls.Add(this.btnNavStory);
            this.pnlSideBar.Controls.Add(this.btnNavPerson);
            this.pnlSideBar.Controls.Add(this.btnNavProject);
            this.pnlSideBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSideBar.Location = new System.Drawing.Point(0, 0);
            this.pnlSideBar.Name = "pnlSideBar";
            this.pnlSideBar.Size = new System.Drawing.Size(150, 450);
             
            // btnNavProject, btnNavPerson, btnNavStory, btnNavTask (Sidebar Buttons)
           
            this.btnNavProject.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavProject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavProject.ForeColor = System.Drawing.Color.White;
            this.btnNavProject.Height = 50;
            this.btnNavProject.Text = "PROJECTS";
            this.btnNavProject.Click += new System.EventHandler(this.btnNavProject_Click);

            this.btnNavPerson.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavPerson.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavPerson.ForeColor = System.Drawing.Color.White;
            this.btnNavPerson.Height = 50;
            this.btnNavPerson.Text = "PERSONS";
            this.btnNavPerson.Click += new System.EventHandler(this.btnNavPerson_Click);

            this.btnNavStory.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavStory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavStory.ForeColor = System.Drawing.Color.White;
            this.btnNavStory.Height = 50;
            this.btnNavStory.Text = "STORIES";
            this.btnNavStory.Click += new System.EventHandler(this.btnNavStory_Click);

            this.btnNavTask.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavTask.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavTask.ForeColor = System.Drawing.Color.White;
            this.btnNavTask.Height = 50;
            this.btnNavTask.Text = "TASKS";
            this.btnNavTask.Click += new System.EventHandler(this.btnNavTask_Click);
          
            // pnlContent (Main Area)
            
            this.pnlContent.Controls.Add(this.pnlTaskActions);
            this.pnlContent.Controls.Add(this.pnlStoryActions);
            this.pnlContent.Controls.Add(this.pnlPersonActions);
            this.pnlContent.Controls.Add(this.pnlProjectActions);
            this.pnlContent.Controls.Add(this.lblLabels);
            this.pnlContent.Controls.Add(this.txtVal2);
            this.pnlContent.Controls.Add(this.txtVal1);
            this.pnlContent.Controls.Add(this.txtID2);
            this.pnlContent.Controls.Add(this.txtID1);
            this.pnlContent.Controls.Add(this.txtDesc);
            this.pnlContent.Controls.Add(this.txtName);
            this.pnlContent.Controls.Add(this.listBoxMain);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(150, 0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(650, 450);
             
            // Visual Elements (ListBox and Inputs)
            
            this.listBoxMain.Location = new System.Drawing.Point(20, 10);
            this.listBoxMain.Size = new System.Drawing.Size(610, 230);

            this.lblLabels.Location = new System.Drawing.Point(20, 250);
            this.lblLabels.Size = new System.Drawing.Size(610, 20);
            this.lblLabels.Text = "Name | Desc / Role | ID 1 | ID 2 | Prio | Diff";

            this.txtName.Location = new System.Drawing.Point(20, 270); this.txtName.Size = new System.Drawing.Size(100, 20);
            this.txtDesc.Location = new System.Drawing.Point(125, 270); this.txtDesc.Size = new System.Drawing.Size(150, 20);
            this.txtID1.Location = new System.Drawing.Point(280, 270); this.txtID1.Size = new System.Drawing.Size(40, 20);
            this.txtID2.Location = new System.Drawing.Point(325, 270); this.txtID2.Size = new System.Drawing.Size(40, 20);
            this.txtVal1.Location = new System.Drawing.Point(370, 270); this.txtVal1.Size = new System.Drawing.Size(40, 20);
            this.txtVal2.Location = new System.Drawing.Point(415, 270); this.txtVal2.Size = new System.Drawing.Size(40, 20);
             
            // Action Panels (Hidden by default)
            
            this.pnlProjectActions.Controls.Add(this.btnCreateProject);
            this.pnlProjectActions.Location = new System.Drawing.Point(20, 300);
            this.pnlProjectActions.Size = new System.Drawing.Size(610, 100);
            this.pnlProjectActions.Visible = false;

            this.pnlPersonActions.Controls.Add(this.btnAddPerson);
            this.pnlPersonActions.Location = new System.Drawing.Point(20, 300);
            this.pnlPersonActions.Size = new System.Drawing.Size(610, 100);
            this.pnlPersonActions.Visible = false;

            this.pnlStoryActions.Controls.Add(this.btnAddStory);
            this.pnlStoryActions.Controls.Add(this.btnDeleteStory);
            this.pnlStoryActions.Location = new System.Drawing.Point(20, 300);
            this.pnlStoryActions.Size = new System.Drawing.Size(610, 100);
            this.pnlStoryActions.Visible = false;

            this.pnlTaskActions.Controls.Add(this.btnAddTask);
            this.pnlTaskActions.Controls.Add(this.btnAssignPerson);
            this.pnlTaskActions.Controls.Add(this.btnUnassignPerson);
            this.pnlTaskActions.Controls.Add(this.btnUpdatePriority);
            this.pnlTaskActions.Location = new System.Drawing.Point(20, 300);
            this.pnlTaskActions.Size = new System.Drawing.Size(610, 100);
            this.pnlTaskActions.Visible = false;
            
            // Buttons Text and Click

            this.btnCreateProject.Text = "Create Project"; this.btnCreateProject.Size = new System.Drawing.Size(120, 40);
            this.btnCreateProject.Click += new System.EventHandler(this.btnCreateProject_Click);

            this.btnAddPerson.Text = "Add Person"; this.btnAddPerson.Size = new System.Drawing.Size(120, 40);
            this.btnAddPerson.Click += new System.EventHandler(this.btnAddPerson_Click);

            this.btnAddStory.Text = "Add Story"; this.btnAddStory.Size = new System.Drawing.Size(100, 40);
            this.btnAddStory.Click += new System.EventHandler(this.btnAddStory_Click);

            this.btnDeleteStory.Text = "Delete Story"; this.btnDeleteStory.Location = new System.Drawing.Point(110, 0); this.btnDeleteStory.Size = new System.Drawing.Size(100, 40);
            this.btnDeleteStory.Click += new System.EventHandler(this.btnDeleteStory_Click);

            this.btnAddTask.Text = "Add Task"; this.btnAddTask.Size = new System.Drawing.Size(100, 40);
            this.btnAddTask.Click += new System.EventHandler(this.btnAddTask_Click);

            this.btnAssignPerson.Text = "Assign"; this.btnAssignPerson.Location = new System.Drawing.Point(110, 0); this.btnAssignPerson.Size = new System.Drawing.Size(100, 40);
            this.btnAssignPerson.Click += new System.EventHandler(this.btnAssignPerson_Click);

            this.btnUnassignPerson.Text = "Remove"; this.btnUnassignPerson.Location = new System.Drawing.Point(220, 0); this.btnUnassignPerson.Size = new System.Drawing.Size(100, 40);
            this.btnUnassignPerson.Click += new System.EventHandler(this.btnUnassignPerson_Click);

            this.btnUpdatePriority.Text = "Update Prio"; this.btnUpdatePriority.Location = new System.Drawing.Point(330, 0); this.btnUpdatePriority.Size = new System.Drawing.Size(100, 40);
            this.btnUpdatePriority.Click += new System.EventHandler(this.btnUpdatePriority_Click);
            
            // Form1

            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlSideBar);
            this.Name = "Form1";
            this.Text = "Agile Project Tool - Final UI";
            this.pnlSideBar.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            this.pnlProjectActions.ResumeLayout(false);
            this.pnlPersonActions.ResumeLayout(false);
            this.pnlStoryActions.ResumeLayout(false);
            this.pnlTaskActions.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlSideBar, pnlContent, pnlProjectActions, pnlPersonActions, pnlStoryActions, pnlTaskActions;
        private System.Windows.Forms.Button btnNavProject, btnNavPerson, btnNavStory, btnNavTask;
        private System.Windows.Forms.Button btnCreateProject, btnAddPerson, btnAddStory, btnDeleteStory, btnAddTask, btnAssignPerson, btnUnassignPerson, btnUpdatePriority;
        private System.Windows.Forms.ListBox listBoxMain;
        private System.Windows.Forms.TextBox txtName, txtDesc, txtID1, txtID2, txtVal1, txtVal2;
        private System.Windows.Forms.Label lblLabels;
    }
}