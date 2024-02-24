using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace App
{
    public partial class Login : Form
    {
        string connectionString = "Server=DESKTOP-EVJH8OQ;Database=AppDb;Integrated Security=true";
        SqlConnection connection = null;
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void LoginBtn_Click(object sender, EventArgs e)
        {
            string Username = UsernameTxt.Text;
            string Password = PasswordTxt.Text;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM [Admin] WHERE Name = @Username AND Password = @Password";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@Username", Username);
                    cmd.Parameters.AddWithValue("@Password", Password);
                    int count = (int)cmd.ExecuteScalar();
                    if (count > 0)
                    {
                        //MessageBox.Show("Baþarýlý", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        UserForm userForm = new UserForm();
                        userForm.UserName = Username;
                        userForm.ConnectionString = connectionString;
                        this.Hide();
                        userForm.Show();
                        connection.Close();
                    }
                    else
                    {
                        MessageBox.Show("Kullanýcý Adý veya Parola Hatalý");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata :" + ex.Message);
            }
        }
    }
}
