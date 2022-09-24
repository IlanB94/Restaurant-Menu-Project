using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RestaurantManu
{
   
    class UserDetailsForm : Form
    {
        Label m_WelcomeUserLabel = new Label();
        Label m_ClientNameLabel = new Label();
        TextBox m_UserNameTextBox = new TextBox();
        Button m_NextBtn = new Button();
        Button m_CancelBtn = new Button();
        Form m_UserDetailsForm = new Form();
        public UserDetailsForm()
        {
            InitializeUserDetailsForm(m_UserDetailsForm);
            SetWelcomeLabel(m_WelcomeUserLabel);
            SetUserNameLabel(m_ClientNameLabel);
            SetUserNameTextBox(m_UserNameTextBox);
            SetNextBtn(m_NextBtn);
            SetCancelBtn(m_CancelBtn);

            m_CancelBtn.Click += M_CancelBtn_Click;
            m_NextBtn.Click += M_NextBtn_Click;

            this.Controls.AddRange(new Control[] { m_WelcomeUserLabel,m_ClientNameLabel , m_UserNameTextBox, m_NextBtn, m_CancelBtn });
        }

        private void M_NextBtn_Click(object sender, EventArgs e)
        {
            //RestaurantManuForm rs = new RestaurantManuForm(m_UserNameTextBox.Text);
            this.Close();
        }

        private void M_CancelBtn_Click(object sender, EventArgs e)
        {
           this.Close();
        }

        public void InitializeUserDetailsForm(Form i_form)
        {
            this.Text = "User Details";
            this.Height = 200;
            this.Width = 400;
            this.Left = 40;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        public void SetWelcomeLabel(Label i_WelcomeLabel)
        {
            i_WelcomeLabel.Font = new System.Drawing.Font("Ariel", 20);
            i_WelcomeLabel.BackColor = Color.Yellow;
            i_WelcomeLabel.Location = new Point(10, 20);
            i_WelcomeLabel.TextAlign = ContentAlignment.MiddleCenter;
            i_WelcomeLabel.Text = "Hello, please enter you name: ";
            i_WelcomeLabel.Height = 35;
            i_WelcomeLabel.Width = 380;
        }

        public void SetUserNameLabel(Label i_UserNameLabel)
        {
            i_UserNameLabel.Font = new System.Drawing.Font("Ariel", 10);
            i_UserNameLabel.AutoSize = true;
            i_UserNameLabel.TextAlign = ContentAlignment.MiddleCenter;
            i_UserNameLabel.Location = new Point(m_WelcomeUserLabel.Location.X + 40, m_WelcomeUserLabel.Location.Y + 50);
            i_UserNameLabel.Text = "enter your name: ";
            i_UserNameLabel.Height = 30;
            i_UserNameLabel.Size = new Size(110, 20);
        }

        public void SetUserNameTextBox(TextBox i_UserNameBox)
        {
            i_UserNameBox.AutoSize = false;
            i_UserNameBox.Size = new System.Drawing.Size(150, 20);
            i_UserNameBox.Location = new Point(m_ClientNameLabel.Location.X + 115, m_ClientNameLabel.Location.Y);
        }

        public void SetNextBtn(Button i_NextButton)
        {
            i_NextButton.Location = new Point(m_UserNameTextBox.Location.X + 75, m_UserNameTextBox.Location.Y + 40);
            i_NextButton.Text = "Next";
        }

        public void SetCancelBtn(Button i_CancelBtn)
        {
            i_CancelBtn.Location = new Point(m_ClientNameLabel.Location.X, m_ClientNameLabel.Location.Y + 40);
            i_CancelBtn.Text = "Cancel";
        }

        public String GetName
        {
            get
            {
                return m_UserNameTextBox.Text;
            }
            set
            {
                m_UserNameTextBox.Text = value;
            }
        }
    }
}
