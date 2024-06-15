namespace VanriseWinformWithSql
{
    partial class AddStudentForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            nameTextBox = new TextBox();
            label1 = new Label();
            genderDropDown = new ComboBox();
            label2 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new Point(87, 134);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(175, 31);
            nameTextBox.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(136, 83);
            label1.Name = "label1";
            label1.Size = new Size(59, 25);
            label1.TabIndex = 1;
            label1.Text = "Name";
            // 
            // genderDropDown
            // 
            genderDropDown.FormattingEnabled = true;
            genderDropDown.Location = new Point(350, 134);
            genderDropDown.Name = "genderDropDown";
            genderDropDown.Size = new Size(182, 33);
            genderDropDown.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(410, 83);
            label2.Name = "label2";
            label2.Size = new Size(69, 25);
            label2.TabIndex = 3;
            label2.Text = "Gender";
            // 
            // button1
            // 
            button1.Location = new Point(420, 337);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 4;
            button1.Text = "Save";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // AddStudentForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(591, 415);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(genderDropDown);
            Controls.Add(label1);
            Controls.Add(nameTextBox);
            Name = "AddStudentForm";
            Text = "AddStudentForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox nameTextBox;
        private Label label1;
        private ComboBox genderDropDown;
        private Label label2;
        private Button button1;
    }
}