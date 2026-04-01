using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace BMI計算機
{
    public partial class frmBMI : Form
    {
        private readonly string userFilePath = "users.txt";
        private readonly string recordFilePath = "records.txt";
        private string currentUser = "";

        public frmBMI()
        {
            InitializeComponent();
        }

        private void frmBMI_Load(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
            lblLoginStatus.Text = "目前未登入";

            if (!File.Exists(userFilePath))
            {
                File.Create(userFilePath).Close();
            }
            txtPassword.UseSystemPasswordChar = true;
            lblLoginStatus.Text = "目前未登入";

            if (!File.Exists(userFilePath))
            {
                File.Create(userFilePath).Close();
            }

            if (!File.Exists(recordFilePath))
            {
                File.Create(recordFilePath).Close();
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            double height, weight;

            bool isHeightValid = double.TryParse(txtHeight.Text, out height);
            bool isWeightValid = double.TryParse(txtWeight.Text, out weight);

            if (!isHeightValid)
            {
                MessageBox.Show("請輸入有效的身高數值。", "身高值錯誤",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (height <= 0)
            {
                MessageBox.Show("身高必須大於零。", "身高值錯誤",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!isWeightValid)
            {
                MessageBox.Show("請輸入有效的體重數值。", "體重值錯誤",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (weight <= 0)
            {
                MessageBox.Show("體重必須大於零。", "體重值錯誤",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!rdoMale.Checked && !rdoFemale.Checked)
            {
                MessageBox.Show("請選擇性別。", "性別未選擇",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string gender = "";
            if (rdoMale.Checked)
                gender = "男";
            else if (rdoFemale.Checked)
                gender = "女";

            height /= 100.0;
            double bmi = weight / (height * height);

            string[] strResultList =
            {
        "體重過輕", "健康體位", "體位過重", "輕度肥胖", "中度肥胖", "重度肥胖"
    };

            Color[] colorList =
            {
        Color.LightBlue, Color.LightGreen, Color.Gold,
        Color.Orange, Color.OrangeRed, Color.MediumPurple
    };

            int resultIndex;

            if (bmi < 18.5)
                resultIndex = 0;
            else if (bmi < 24)
                resultIndex = 1;
            else if (bmi < 27)
                resultIndex = 2;
            else if (bmi < 30)
                resultIndex = 3;
            else if (bmi < 35)
                resultIndex = 4;
            else
                resultIndex = 5;

            string strResult = strResultList[resultIndex];
            Color colorResult = colorList[resultIndex];

            lblResult.AutoSize = false;
            lblResult.TextAlign = ContentAlignment.MiddleCenter;
            lblResult.Text = $"{bmi:F2} ({strResult})";
            lblResult.BackColor = colorResult;
            lblResult.ForeColor = Color.Black;
            if (currentUser != "")
            {
                string recordLine = currentUser + "," +
                                    DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "," +
                                    bmi.ToString("F2");

                File.AppendAllText(recordFilePath, recordLine + Environment.NewLine);
            }
            else
            {
                MessageBox.Show("目前未登入，這次 BMI 不會保存。");
            }
        }

        private void txtWeight_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtHeight_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (username == "")
            {
                MessageBox.Show("請輸入帳號。");
                return;
            }

            if (password == "")
            {
                MessageBox.Show("請輸入密碼。");
                return;
            }

            List<string> lines = File.ReadAllLines(userFilePath).ToList();
            bool loginSuccess = false;

            foreach (string line in lines)
            {
                string[] parts = line.Split(',');

                if (parts.Length >= 2)
                {
                    if (parts[0] == username && parts[1] == password)
                    {
                        loginSuccess = true;
                        currentUser = username;
                        break;
                    }
                }
            }

            if (loginSuccess)
            {
                lblLoginStatus.Text = "已登入：" + currentUser;
                MessageBox.Show("登入成功！");
            }
            else
            {
                MessageBox.Show("帳號或密碼錯誤。");
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (username == "")
            {
                MessageBox.Show("請輸入帳號。");
                return;
            }

            if (password == "")
            {
                MessageBox.Show("請輸入密碼。");
                return;
            }

            List<string> lines = File.ReadAllLines(userFilePath).ToList();

            foreach (string line in lines)
            {
                string[] parts = line.Split(',');

                if (parts.Length >= 2 && parts[0] == username)
                {
                    MessageBox.Show("此帳號已存在。");
                    return;
                }
            }

            File.AppendAllText(userFilePath, username + "," + password + Environment.NewLine);

            MessageBox.Show("註冊成功！");
            txtUsername.Clear();
            txtPassword.Clear();
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            if (currentUser == "")
            {
                MessageBox.Show("請先登入。");
                return;
            }

            frmHistory historyForm = new frmHistory(currentUser);
            historyForm.ShowDialog();
        }
    }
}
