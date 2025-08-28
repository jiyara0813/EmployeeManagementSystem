namespace EmployeeListApplication
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
            txt_emp_id = new TextBox();
            label1 = new Label();
            label2 = new Label();
            txt_fname = new TextBox();
            label3 = new Label();
            txt_lname = new TextBox();
            txt_position = new TextBox();
            label4 = new Label();
            txt_salary = new TextBox();
            label5 = new Label();
            groupBox1 = new GroupBox();
            btn_add = new Button();
            btn_update = new Button();
            btn_delete = new Button();
            dgv_emplist = new DataGridView();
            label6 = new Label();
            txt_search = new TextBox();
            btn_exit = new Button();
            btn_cancel = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_emplist).BeginInit();
            SuspendLayout();
            // 
            // txt_emp_id
            // 
            txt_emp_id.Enabled = false;
            txt_emp_id.Location = new Point(44, 56);
            txt_emp_id.Name = "txt_emp_id";
            txt_emp_id.Size = new Size(102, 23);
            txt_emp_id.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(44, 38);
            label1.Name = "label1";
            label1.Size = new Size(73, 15);
            label1.TabIndex = 1;
            label1.Text = "Employee ID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(183, 38);
            label2.Name = "label2";
            label2.Size = new Size(64, 15);
            label2.TabIndex = 2;
            label2.Text = "First Name";
            // 
            // txt_fname
            // 
            txt_fname.Location = new Point(183, 56);
            txt_fname.Name = "txt_fname";
            txt_fname.Size = new Size(245, 23);
            txt_fname.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(464, 38);
            label3.Name = "label3";
            label3.Size = new Size(63, 15);
            label3.TabIndex = 4;
            label3.Text = "Last Name";
            // 
            // txt_lname
            // 
            txt_lname.Location = new Point(464, 56);
            txt_lname.Name = "txt_lname";
            txt_lname.Size = new Size(245, 23);
            txt_lname.TabIndex = 5;
            // 
            // txt_position
            // 
            txt_position.Location = new Point(183, 119);
            txt_position.Name = "txt_position";
            txt_position.Size = new Size(245, 23);
            txt_position.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(183, 101);
            label4.Name = "label4";
            label4.Size = new Size(50, 15);
            label4.TabIndex = 6;
            label4.Text = "Position";
            // 
            // txt_salary
            // 
            txt_salary.Location = new Point(464, 119);
            txt_salary.Name = "txt_salary";
            txt_salary.Size = new Size(245, 23);
            txt_salary.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(464, 101);
            label5.Name = "label5";
            label5.Size = new Size(38, 15);
            label5.TabIndex = 8;
            label5.Text = "Salary";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txt_salary);
            groupBox1.Controls.Add(txt_emp_id);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txt_position);
            groupBox1.Controls.Add(txt_fname);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txt_lname);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(776, 179);
            groupBox1.TabIndex = 10;
            groupBox1.TabStop = false;
            groupBox1.Text = "Employee Information";
            // 
            // btn_add
            // 
            btn_add.BackColor = Color.Green;
            btn_add.Font = new Font("Segoe UI", 13F);
            btn_add.ForeColor = Color.White;
            btn_add.Location = new Point(12, 475);
            btn_add.Name = "btn_add";
            btn_add.Size = new Size(160, 40);
            btn_add.TabIndex = 11;
            btn_add.Text = "Add";
            btn_add.UseVisualStyleBackColor = false;
            btn_add.Click += btn_add_Click;
            // 
            // btn_update
            // 
            btn_update.BackColor = Color.FromArgb(192, 64, 0);
            btn_update.Enabled = false;
            btn_update.Font = new Font("Segoe UI", 13F);
            btn_update.ForeColor = Color.White;
            btn_update.Location = new Point(178, 475);
            btn_update.Name = "btn_update";
            btn_update.Size = new Size(160, 40);
            btn_update.TabIndex = 12;
            btn_update.Text = "Update";
            btn_update.UseVisualStyleBackColor = false;
            btn_update.Click += btn_update_Click;
            // 
            // btn_delete
            // 
            btn_delete.BackColor = Color.Red;
            btn_delete.Enabled = false;
            btn_delete.Font = new Font("Segoe UI", 13F);
            btn_delete.ForeColor = Color.White;
            btn_delete.Location = new Point(344, 475);
            btn_delete.Name = "btn_delete";
            btn_delete.Size = new Size(160, 40);
            btn_delete.TabIndex = 13;
            btn_delete.Text = "Delete";
            btn_delete.UseVisualStyleBackColor = false;
            btn_delete.Click += btn_delete_Click;
            // 
            // dgv_emplist
            // 
            dgv_emplist.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_emplist.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_emplist.Location = new Point(12, 246);
            dgv_emplist.Name = "dgv_emplist";
            dgv_emplist.ReadOnly = true;
            dgv_emplist.Size = new Size(776, 204);
            dgv_emplist.TabIndex = 15;
            dgv_emplist.CellContentClick += dgv_emplist_CellContentClick;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 212);
            label6.Name = "label6";
            label6.Size = new Size(117, 15);
            label6.TabIndex = 10;
            label6.Text = "Search by Last Name";
            // 
            // txt_search
            // 
            txt_search.Location = new Point(135, 204);
            txt_search.Name = "txt_search";
            txt_search.Size = new Size(305, 23);
            txt_search.TabIndex = 10;
            txt_search.TextChanged += txt_search_TextChanged;
            // 
            // btn_exit
            // 
            btn_exit.BackColor = Color.FromArgb(192, 0, 0);
            btn_exit.Font = new Font("Segoe UI", 13F);
            btn_exit.ForeColor = Color.White;
            btn_exit.Location = new Point(676, 475);
            btn_exit.Name = "btn_exit";
            btn_exit.Size = new Size(112, 40);
            btn_exit.TabIndex = 16;
            btn_exit.Text = "Exit";
            btn_exit.UseVisualStyleBackColor = false;
            btn_exit.Click += btn_exit_Click;
            // 
            // btn_cancel
            // 
            btn_cancel.BackColor = Color.FromArgb(192, 192, 0);
            btn_cancel.Font = new Font("Segoe UI", 13F);
            btn_cancel.ForeColor = Color.White;
            btn_cancel.Location = new Point(510, 475);
            btn_cancel.Name = "btn_cancel";
            btn_cancel.Size = new Size(160, 40);
            btn_cancel.TabIndex = 17;
            btn_cancel.Text = "Cancel";
            btn_cancel.UseVisualStyleBackColor = false;
            btn_cancel.Click += btn_cancel_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 547);
            Controls.Add(btn_cancel);
            Controls.Add(btn_exit);
            Controls.Add(txt_search);
            Controls.Add(label6);
            Controls.Add(dgv_emplist);
            Controls.Add(btn_delete);
            Controls.Add(btn_update);
            Controls.Add(btn_add);
            Controls.Add(groupBox1);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Employee Management System";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_emplist).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txt_emp_id;
        private Label label1;
        private Label label2;
        private TextBox txt_fname;
        private Label label3;
        private TextBox txt_lname;
        private TextBox txt_position;
        private Label label4;
        private TextBox txt_salary;
        private Label label5;
        private GroupBox groupBox1;
        private Button btn_add;
        private Button btn_update;
        private Button btn_delete;
        private DataGridView dgv_emplist;
        private Label label6;
        private TextBox txt_search;
        private Button btn_exit;
        private Button btn_cancel;
    }
}
