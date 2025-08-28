using System.ComponentModel;

namespace EmployeeListApplication
{
    public partial class Form1 : Form
    {
        private readonly EmployeeApiClient _api =
        new EmployeeApiClient("http://localhost:5064/");

        private BindingList<Employee> _employees = new();

        public Form1()
        {
            InitializeComponent();
            dgv_emplist.ReadOnly = true;
            dgv_emplist.AutoGenerateColumns = true;
            dgv_emplist.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_emplist.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_emplist.MultiSelect = false;
            txt_emp_id.ReadOnly = true;
        }

        private async Task NextIdAsync()
        {
            var employees = await _api.GetAllAsync();
            if (employees.Any())
            {
                int nextId = employees.Max(emp => emp.Id) + 1;
                txt_emp_id.Text = nextId.ToString();
            }
            else
            {
                txt_emp_id.Text = "1";
            }
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await RefreshGridAsync();
            await NextIdAsync();
        }

        private async Task RefreshGridAsync()
        {
            try
            {
                var list = await _api.GetAllAsync();
                _employees = new BindingList<Employee>(list ?? new List<Employee>());
                dgv_emplist.DataSource = _employees;

                dgv_emplist.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgv_emplist.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgv_emplist.ReadOnly = true;

                dgv_emplist.Columns["Id"].FillWeight = 40;
                dgv_emplist.Columns["FirstName"].FillWeight = 100;
                dgv_emplist.Columns["LastName"].FillWeight = 100;
                dgv_emplist.Columns["Position"].FillWeight = 150;
                dgv_emplist.Columns["Salary"].FillWeight = 80;
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Cannot reach API. Is it running?\n\n{ex.Message}",
                    "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearFields()
        {
            txt_emp_id.Clear();
            txt_fname.Clear();
            txt_lname.Clear();
            txt_position.Clear();
            txt_salary.Clear();
            txt_search.Clear();
            txt_fname.Focus();

            //txt_emp_id.Text = nextId.ToString();
        }

        private async void btn_add_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_fname.Text) ||
                string.IsNullOrWhiteSpace(txt_lname.Text) ||
                string.IsNullOrWhiteSpace(txt_position.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txt_salary.Text, out var salary))
            {
                MessageBox.Show("Salary must be a valid number.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_salary.Clear();
                txt_salary.Focus();
                return;
            }

            var emp = new Employee
            {
                FirstName = txt_fname.Text,
                LastName = txt_lname.Text,
                Position = txt_position.Text,
                Salary = salary
            };

            var created = await _api.CreateAsync(emp);
            if (created != null)
            {
                MessageBox.Show("Employee added successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed to create employee.", "API Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ClearFields();
            await RefreshGridAsync();
            await NextIdAsync();
            btn_update.Enabled = false;
            btn_delete.Enabled = false;
            btn_add.Enabled = true;
            txt_fname.Focus();
        }

        private async void btn_update_Click(object sender, EventArgs e)
        {
            if (dgv_emplist.CurrentRow != null)
            {
                if (string.IsNullOrWhiteSpace(txt_fname.Text) ||
                    string.IsNullOrWhiteSpace(txt_lname.Text) ||
                    string.IsNullOrWhiteSpace(txt_position.Text))
                {
                    MessageBox.Show("Please fill in all required fields (First Name, Last Name, Position).");
                    return;
                }

                if (!decimal.TryParse(txt_salary.Text, out var salary))
                {
                    MessageBox.Show("Salary must be a valid number.", "Validation",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_salary.Clear();
                    txt_salary.Focus();
                    return;
                }

                int id = (int)dgv_emplist.CurrentRow.Cells["Id"].Value;

                var emp = new Employee
                {
                    Id = id,
                    FirstName = txt_fname.Text.Trim(),
                    LastName = txt_lname.Text.Trim(),
                    Position = txt_position.Text.Trim(),
                    Salary = salary
                };

                var ok = await _api.UpdateAsync(emp);
                if (ok)
                {
                    MessageBox.Show("Employee information updated successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Update failed (record may not exist).", "API Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                ClearFields();
                await RefreshGridAsync();
                await NextIdAsync();
                btn_update.Enabled = false;
                btn_delete.Enabled = false;
                btn_add.Enabled = true;
                txt_fname.Focus();
            }
        }

        private async void btn_delete_Click(object sender, EventArgs e)
        {
            if (dgv_emplist.CurrentRow == null)
            {
                MessageBox.Show("Please select an employee to delete.");
                return;
            }

            int id = (int)dgv_emplist.CurrentRow.Cells["Id"].Value;

            var confirm = MessageBox.Show
                (
                    $"Are you sure you want to delete this employee?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

            if (confirm == DialogResult.Yes)
            {
                var ok = await _api.DeleteAsync(id);
                if (ok)
                {
                    MessageBox.Show("Employee deleted successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Delete failed (record may not exist).", "API Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                ClearFields();
                await RefreshGridAsync();
                await NextIdAsync();
                btn_update.Enabled = false;
                btn_delete.Enabled = false;
                btn_add.Enabled = true;
                txt_fname.Focus();
            }
        }

        private async void txt_search_TextChanged(object sender, EventArgs e)
        {
            string keyword = txt_search.Text.ToLower();
            var employees = await _api.GetAllAsync();
            var filtered = employees
                .Where(emp => emp.LastName.ToLower().Contains(keyword))
                .ToList();
            dgv_emplist.DataSource = filtered;
        }

        private void dgv_emplist_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgv_emplist.Rows[e.RowIndex];

                txt_emp_id.Text = row.Cells["Id"].Value.ToString();
                txt_fname.Text = row.Cells["FirstName"].Value.ToString();
                txt_lname.Text = row.Cells["LastName"].Value.ToString();
                txt_position.Text = row.Cells["Position"].Value.ToString();
                txt_salary.Text = row.Cells["Salary"].Value.ToString();

                btn_add.Enabled = false;
                btn_update.Enabled = true;
                btn_delete.Enabled = true;
            }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show
            (
                "Are you sure you want to exit?",
                "Confirm Exit",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private async void btn_cancel_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show
            (
                "Are you sure you want to cancel the operation?",
                "Confirm Cancellation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm == DialogResult.Yes)
            {
                ClearFields();
                await RefreshGridAsync();
                await NextIdAsync();
                btn_add.Enabled = true;
                btn_update.Enabled = false;
                btn_delete.Enabled = false;
                txt_fname.Focus();
            }
        }
    }
}
