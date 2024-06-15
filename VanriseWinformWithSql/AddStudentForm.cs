#nullable disable
using VanriseWinformWithSql.Enums;
using VanriseWinformWithSql.Managers.Students;
using VanriseWinformWithSql.Models;

namespace VanriseWinformWithSql
{
    public partial class AddStudentForm : Form
    {
        private readonly StudentManager _studentManager;
        private event EventHandler<Student> StudentAdded;
        private event EventHandler StudentEdited;

        private Student EditStudent;
        public AddStudentForm()
        {
            InitializeComponent();
            InitializeCombobox(null);

            _studentManager = new StudentManager(Resources.ConnectionString);
        }


        public AddStudentForm(Student student)
        {
            InitializeComponent();
            InitializeCombobox(student.Gender);
            EditStudent = student;
            nameTextBox.Text = student.Name;

            _studentManager = new StudentManager(Resources.ConnectionString);
        }

        private void InitializeCombobox(Gender? gender)
        {
            genderDropDown.DataSource = Enum.GetValues(typeof(Gender));

            //to make the text not editable (for the selected item to be not null always)
            genderDropDown.DropDownStyle = ComboBoxStyle.DropDownList;

            //if for edit, initialize with the student's gebder
            if (gender is not null)
                genderDropDown.SelectedItem = gender;
        }

        //save button
        private async void button1_Click(object sender, EventArgs e)
        {
            //for adding student
            if (EditStudent is null)
            {
                var newStudent = new Student { Name = nameTextBox.Text, Gender = (Gender)genderDropDown.SelectedItem };
                await _studentManager.Insert(newStudent);
                NotifyStudentAdded(newStudent);
                return;
            }

            //for editing student
            EditStudent.Name = nameTextBox.Text;
            EditStudent.Gender = (Gender)genderDropDown.SelectedItem;
            await _studentManager.Update(EditStudent);
            NotifyStudentEdited();
            EditStudent = null;
            Close();
        }

        public void SubscribeToStudentAdded(EventHandler<Student> eventHandler)
        {
            StudentAdded += eventHandler;
        }

        public void NotifyStudentAdded(Student student)
        {
            StudentAdded?.Invoke(this, student);
        }

        public void SubscribeToStudentEdited(EventHandler eventHandler)
        {
            StudentEdited += eventHandler;
        }

        private void NotifyStudentEdited()
        {
            StudentEdited?.Invoke(this, null);
        }

    }
}
