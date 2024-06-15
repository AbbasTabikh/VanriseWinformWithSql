using VanriseWinformWithSql.Managers.Students;
using VanriseWinformWithSql.Models;

namespace VanriseWinformWithSql
{
    public partial class Form1 : Form
    {
        private readonly StudentManager _studentManager;
        private List<Student> students;
        public Form1()
        {
            InitializeComponent();
            students = [];
            _studentManager = new StudentManager(Resources.ConnectionString);
        }

        private void add_button_Click(object sender, EventArgs e)
        {
            using var studentForm = new AddStudentForm();
            studentForm.SubscribeToStudentAdded(OnStudentAdded);
            studentForm.ShowDialog();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            students = await _studentManager.GetAll();
            dataGridView1.DataSource = students;
        }

        private void OnContextMenuClicked(object? sender, EventArgs e)
        {
            var row = dataGridView1.SelectedRows[0];
            var student = row.DataBoundItem as Student;
            using var studentForm = new AddStudentForm(student);
            studentForm.SubscribeToStudentEdited(OnStudentEdited);
            studentForm.ShowDialog();
        }


        private ContextMenuStrip CreateContextMenuStrip(string action)
        {
            ContextMenuStrip menuStrip = new ContextMenuStrip();
            menuStrip.Items.Add(action);
            menuStrip.Items[0].Text = action;
            menuStrip.Items[0].Click += OnContextMenuClicked;
            return menuStrip;
        }


        private async void search_button_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(search_box.Text))
            {
                students = await _studentManager.GetAll();
                dataGridView1.DataSource = students;
                return;
            }
            students = await _studentManager.GetFiltered(search_box.Text);
            dataGridView1.DataSource = students;
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            int currentMouseOverRow = dataGridView1.HitTest(e.X, e.Y).RowIndex;

            // if the click was on a row
            if (currentMouseOverRow >= 0)
            {
                dataGridView1.ClearSelection();
                dataGridView1.Rows[currentMouseOverRow].Selected = true;
                var m = CreateContextMenuStrip("Edit");
                m.Show(dataGridView1, new Point(e.X, e.Y));
            }
        }

        /* Event Handlers */
        private void OnStudentEdited(object? sender, EventArgs e)
        {
            dataGridView1.Refresh();
        }

        private async void OnStudentAdded(object? sender, Student e)
        {
            students = await _studentManager.GetAll();
            dataGridView1.DataSource = students;
        }
        /* End Event Handlers */
    }
}
