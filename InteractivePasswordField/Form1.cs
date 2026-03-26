using System;
using System.Text;
using System.Linq;
using System.Windows.Forms;

namespace InteractivePasswordField
{
    public partial class Form1 : Form
    {
        Random random = new Random();

        public Form1()
        {
            InitializeComponent();
            txtPassword.UseSystemPasswordChar = true;
        }

        private void label2_Click(object sender, EventArgs e) { }

        // 🔄 Double Click → Clear
        private void txtPassword_DoubleClick(object sender, EventArgs e)
        {
            txtPassword.Clear();
            txtPassword.UseSystemPasswordChar = true;
            lblStatus.Text = "Status: Password Cleared";
        }

        // 👁️ Hover → Show Password
        private void txtPassword_MouseEnter(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = false;
        }

        // 🔒 Leave → Hide Password
        private void txtPassword_MouseLeave(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
        }

        // 🖱️ Mouse Down → Left/Right Click Actions
        private void txtPassword_MouseDown(object sender, MouseEventArgs e)
        {
            // 👉 RIGHT CLICK → Generate password
            if (e.Button == MouseButtons.Right)
            {
                txtPassword.Text = GeneratePassword(10);
                txtPassword.UseSystemPasswordChar = true;
                lblStatus.Text = "Status: Random Password Generated";
            }

            // 👉 LEFT CLICK → Copy password
            else if (e.Button == MouseButtons.Left)
            {
                if (!string.IsNullOrEmpty(txtPassword.Text))
                {
                    Clipboard.SetText(txtPassword.Text);
                    lblStatus.Text = "Status: Password Copied";
                }
            }
        }

        // 🔐 Password Generator
        private string GeneratePassword(int length)
        {
            string lower = "abcdefghijklmnopqrstuvwxyz";
            string upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string numbers = "0123456789";
            string symbols = "!@#$%^&*";

            string all = lower + upper + numbers + symbols;

            StringBuilder password = new StringBuilder();

            password.Append(lower[random.Next(lower.Length)]);
            password.Append(upper[random.Next(upper.Length)]);
            password.Append(numbers[random.Next(numbers.Length)]);
            password.Append(symbols[random.Next(symbols.Length)]);

            for (int i = 4; i < length; i++)
            {
                password.Append(all[random.Next(all.Length)]);
            }

            return new string(password.ToString().OrderBy(x => random.Next()).ToArray());
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}