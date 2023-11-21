using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TrackingSystem
{
    public partial class form1 : Form
    {
        private DatabaseHelper databaseHelper;
        private TimeTracker timeTracker;

        public form1()
        {
            InitializeComponent();
            databaseHelper = new DatabaseHelper();
            timeTracker = new TimeTracker();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadProjects();
        }

        private void LoadProjects()
        {
            DataTable projects = databaseHelper.GetProjects();
            projectComboBox.DisplayMember = "ProjectName";
            projectComboBox.ValueMember = "ProjectID";
            projectComboBox.DataSource = projects;
        }

        private void projectComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTasks();
        }

        private void LoadTasks()
        {
            int projectId = (int)projectComboBox.SelectedValue;
            DataTable tasks = databaseHelper.GetTasksForProject(projectId);
            taskListBox.DisplayMember = "TaskName";
            taskListBox.ValueMember = "TaskID";
            taskListBox.DataSource = tasks;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            timeTracker.StartTracking();
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            TimeSpan elapsedTime = timeTracker.StopTracking();
            MessageBox.Show($"Time spent on the task: {elapsedTime.TotalHours:F2} hours");
        }

        private void saveProgressButton_Click(object sender, EventArgs e)
        {
            int taskId = (int)taskListBox.SelectedValue;
            string progress = progressTextBox.Text;

            if (databaseHelper.SaveProgress(taskId, progress))
            {
                MessageBox.Show("Progress saved successfully!");
            }
            else
            {
                MessageBox.Show("Failed to save progress!");
            }
        }
    }