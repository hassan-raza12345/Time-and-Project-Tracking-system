using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace TrackingSystem
{
    public partial class LoginForm : Form
    {
        private SqlConnection connection;
        private string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\SC\\source\\repos\\HotelReservationSystem\\HotelReservationSystem\\Database1.mdf;Integrated Security=True";

        public LoginForm()
        {
            InitializeComponent();
            connection = new SqlConnection(connectionString);
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable table = new DataTable();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand())
                    {
                        string query = "SELECT * FROM users WHERE username=@usn AND password=@pass";
                        command.CommandText = query;
                        command.Connection = connection;

                        command.Parameters.Add("@usn", SqlDbType.VarChar).Value = textBoxUsername.Text;
                        command.Parameters.Add("@pass", SqlDbType.VarChar).Value = textBoxPassword.Text;

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(table);
                        }
                    }
                }

                if (table.Rows.Count > 0)
                {
                    MessageBox.Show("Login Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Open the frmReservation form
                    form1 Form = new form1();
                    Form.Show();

                    // Hide the current login form
                    this.Hide();
                }
                else
                {
                    if (textBoxUsername.Text.Trim().Equals(""))
                    {
                        MessageBox.Show("Enter Your Username to Login", "Empty Username", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (textBoxPassword.Text.Trim().Equals(""))
                    {
                        MessageBox.Show("Enter Your Password to Login", "Empty Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Incorrect Username Or Password", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
