using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace App
{
    public partial class UserForm : Form
    {
        public string ConnectionString { get; set; }
        public string UserName { get; set; }
        public int Count { get; set; }
        public UserForm()
        {
            InitializeComponent();
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dateTimePicker2.MaxDate = DateTime.Today;
            Count = UserCount();
            label1.Text = "Kayıt Sayısı :" + Count.ToString();
            MessageBox.Show("Hoşgeldin " + UserName);
            UserList();
        }
        public void UserList()
        {
            dataGridView1.Rows.Clear();
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "SELECT Id,Username,Password,BirthDate FROM [User]";
            SqlCommand cmd = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    dataGridView1.Rows.Add(reader["Id"].ToString(), reader["Username"].ToString(), reader["Password"].ToString(), reader["BirthDate"].ToString());
                }
                Count = UserCount();
                label1.Text = "Kayıt Sayısı :" + Count.ToString();
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }
        private void BtnList_Click(object sender, EventArgs e)
        {
            UserList();
        }
        public void UserAdd(string Username, string Password, DateTime Date)
        {
            try
            {
                SqlConnection connection = new SqlConnection(ConnectionString);

                string query = "INSERT INTO [User] (Username, Password,BirthDate) VALUES (@Username, @Password,@Date)";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Username", Username);
                cmd.Parameters.AddWithValue("@Password", Password);
                cmd.Parameters.AddWithValue("@Date", Date);
                connection.Open();
                int count = cmd.ExecuteNonQuery();
                if (count > 0)
                {
                    MessageBox.Show("Kullanıcı başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Kullanıcı eklenirken bir hata oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void AddBtn_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            DateTime Date = dateTimePicker3.Value;
            string Id = textBox3.Text;
            UserAdd(username, password, Date);
        }
        public void UserDelete()
        {
            try
            {
                SqlConnection connection = new SqlConnection(ConnectionString);
                string query = "DELETE FROM [User] WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Id", textBox3.Text);

                connection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Kullanıcı başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Belirtilen ID'ye sahip kullanıcı bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            UserDelete();
        }
        public void UserUpdate(int id, string newUsername, string newPassword, DateTime date)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    string query = "UPDATE [User] SET Username = @NewUsername, Password = @NewPassword , BirthDate = @Date WHERE Id = @Id";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@NewUsername", newUsername);
                    cmd.Parameters.AddWithValue("@NewPassword", newPassword);
                    cmd.Parameters.AddWithValue("@Date", date);

                    connection.Open();
                    int count = cmd.ExecuteNonQuery();
                    if (count > 0)
                    {
                        MessageBox.Show("Kullanıcı başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Belirtilen ID'ye sahip kullanıcı bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            string newUsername = textBox4.Text;
            string newPassword = textBox6.Text;
            DateTime date = dateTimePicker4.Value;
            int Id = Int32.Parse(textBox5.Text);
            UserUpdate(Id, newUsername, newPassword, date);
        }
        public void TimeFilter()
        {
            dataGridView1.Rows.Clear();
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "SELECT * FROM [User] WHERE BirthDate >= @tarih1 AND BirthDate <= @tarih2";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@tarih1", dateTimePicker1.Value);
            DateTime tarih2 = dateTimePicker2.Value.Date.AddDays(1);
            cmd.Parameters.AddWithValue("@tarih2", tarih2);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                int Count = 0;
                while (reader.Read())
                {
                    dataGridView1.Rows.Add(reader["Id"].ToString(), reader["Username"].ToString(), reader["Password"].ToString(), reader["BirthDate"].ToString());
                    Count++;
                }
                reader.Close();
                label1.Text = "Kayıt Sayısı: " + Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void TimeFilterBtn_Click(object sender, EventArgs e)
        {
            TimeFilter();
        }
        public void SetWelcomeMessage(string username)
        {
            MessageBox.Show("Hoşgeldin, " + username + "!");
        }
        public int UserCount()
        {
            int count = 0;
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "SELECT COUNT(*) FROM [User]";
            SqlCommand cmd = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                count = (int)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return count;
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
