using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MuradBTask
{
    public partial class Form1 : Form
    {
        // List to store predefined users
        private List<User> users = new List<User>
        {
            new User("Murad", "56789on1", "Admin"),
            new User("Geskok", "whsgesk117", "User"),
            new User("Flos", "flosxd113", "Guest")
        };

        public Form1()
        {
            InitializeComponent();
        }

        // Event handler for the Login button click
        private void button1_Click(object sender, EventArgs e)
        {
            // Get the username and password from the textboxes
            string usernameInput = textBox1.Text;
            string passwordInput = textBox2.Text;

            try
            {
                // Authenticate the user
                User loggedInUser = AuthenticateUser(usernameInput, passwordInput);

                if (loggedInUser != null)
                {
                    // Successful login
                    MessageBox.Show($"Login successful! Welcome {loggedInUser.Username} ({loggedInUser.Role}).");
                }
                else
                {
                    // Login failed
                    MessageBox.Show("Error: Invalid username or password.");
                }
            }
            catch (Exception ex)
            {
                // Handle unexpected errors
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        // Method to authenticate the user
        private User AuthenticateUser(string username, string password)
        {
            foreach (var user in users)
            {
                if (user.Username == username && user.Password == password)
                {
                    return user; // Return the matching user
                }
            }
            return null; // Return null if no match is found
        }

        // Nested User class inside Form1
        public class User
        {
            // Private fields
            private string username;
            private string password;
            private string role;

            // Constructor to initialize the User object
            public User(string username, string password, string role = "User")
            {
                this.username = username;
                this.password = password;
                this.role = role;
            }

            // Public properties to access the private fields
            public string Username
            {
                get { return username; }
                set { username = value; }
            }

            public string Password
            {
                get { return password; }
                set { password = value; }
            }

            public string Role
            {
                get { return role; }
                set { role = value; }
            }
        }
    }
}