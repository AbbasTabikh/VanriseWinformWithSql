namespace VanriseWinformWithSql
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            add_button = new Button();
            search_button = new Button();
            search_box = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(22, 100);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(727, 338);
            dataGridView1.TabIndex = 0;
            dataGridView1.MouseClick += dataGridView1_MouseClick;
            // 
            // add_button
            // 
            add_button.Location = new Point(622, 34);
            add_button.Name = "add_button";
            add_button.Size = new Size(112, 34);
            add_button.TabIndex = 1;
            add_button.Text = "Add";
            add_button.UseVisualStyleBackColor = true;
            add_button.Click += add_button_Click;
            // 
            // search_button
            // 
            search_button.Location = new Point(492, 34);
            search_button.Name = "search_button";
            search_button.Size = new Size(112, 34);
            search_button.TabIndex = 2;
            search_button.Text = "Search";
            search_button.UseVisualStyleBackColor = true;
            search_button.Click += search_button_Click;
            // 
            // search_box
            // 
            search_box.Location = new Point(22, 37);
            search_box.Name = "search_box";
            search_box.Size = new Size(252, 31);
            search_box.TabIndex = 3;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(search_box);
            Controls.Add(search_button);
            Controls.Add(add_button);
            Controls.Add(dataGridView1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button add_button;
        private Button search_button;
        private TextBox search_box;
    }
}
