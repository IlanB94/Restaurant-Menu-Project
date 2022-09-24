using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace RestaurantManu
{
  

    class RestaurantManuForm : Form
    {
        private String m_Name;
        public Form m_RestaurantManu;
        private Coffe[] m_CoffeArray = new Coffe[4];
        private static int m_LeftBtn = 20;
        Label m_CoffeChooseLbl = new Label();
        Label CoffeTypeLbl = new Label();
        Label CoffePriceLbl = new Label();
        private static int m_LeftNameLbl = 10;
        private double m_TotalSum = 0;
        Label m_TotalPriceDynmic = new Label();
        Label m_TotalPrice = new Label();
        Button m_ResetBtn = new Button();
        Button m_MakeOrderBtn = new Button();
        
        public RestaurantManuForm(String i_GetUserName)
        {
            m_Name = i_GetUserName;
            m_RestaurantManu = new Form();
            InitializeRestaurantForm(m_RestaurantManu);
            SetChooseCoffeLabel(m_CoffeChooseLbl);
            ShowCoffeManu();
            SetTotalPriceLabel();
            SetTotalPriceLblDynamic();
            SetResetPriceButton();
            MakeOrderBtn();

        }

        public void InitializeRestaurantForm(Form i_Form)
        {
            this.BackColor = System.Drawing.Color.FromArgb(180, 180, 180);
            this.Text = "Restaurant Manu";
            this.AutoSize = true;
            m_CoffeChooseLbl.AutoSize = true;
            m_CoffeChooseLbl.TextAlign = ContentAlignment.MiddleCenter;
            m_CoffeChooseLbl.Top = 20;
            m_CoffeChooseLbl.Left = 20;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Controls.Add(m_CoffeChooseLbl);
        }

        public void ShowCoffeManu()
        {
            Coffe Black = new Coffe("Black",1.5);
            Coffe Latte = new Coffe("Latte", 2.5);
            Coffe Cappuccino = new Coffe("Cappuccino", 3.5);
            Coffe Americano = new Coffe("Americano", 6.5);


            m_CoffeArray[0] = Black;
            m_CoffeArray[1] = Latte;
            m_CoffeArray[2] = Cappuccino;
            m_CoffeArray[3] = Americano;

            for(int i =0; i < m_CoffeArray.Length; i++)
            {
                CoffeTypeLbl = new Label();
                CoffePriceLbl = new Label();
                if (i == 0)
                {
                    m_CoffeArray[i].Text = m_CoffeArray[i].CoffeType;
                    m_CoffeArray[i].Image = Image.FromFile(@"C:\Users\ilan\Desktop\sadsad.jpg");
                    m_CoffeArray[i].Size = Size;
                    m_CoffeArray[i].BackgroundImage = m_CoffeArray[i].Image;                   
                    GenerateCoffeButtons(m_CoffeArray[i]);
                    GenerateLabelsCoffeName(CoffeTypeLbl, m_CoffeArray[i]);
                    GenerateLabelsCoffePrice(CoffePriceLbl, m_CoffeArray[i]);
                    this.Controls.AddRange(new Control[] { m_CoffeArray[i], CoffeTypeLbl, CoffePriceLbl });
                }
                else
                {
                    m_CoffeArray[i].Text = m_CoffeArray[i].CoffeType;
                    GenerateCoffeButtons(m_CoffeArray[i]);
                    GenerateLabelsCoffeName(CoffeTypeLbl, m_CoffeArray[i]);
                    GenerateLabelsCoffePrice(CoffePriceLbl, m_CoffeArray[i]);
                    this.Controls.AddRange(new Control[] { m_CoffeArray[i], CoffeTypeLbl, CoffePriceLbl });
                }    
            }

            for(int i =0; i < m_CoffeArray.Length; i++)
            {
                m_CoffeArray[i].Click += RestaurantManuForm_Click;
            }

            m_ResetBtn.Click += M_ResetButton_Click;
            m_MakeOrderBtn.Click += M_MakeOrderBtn_Click;
        }


        //Click Events, make order button and Reset button
        private void M_MakeOrderBtn_Click(object sender, EventArgs e)
        {
            if(m_TotalPriceDynmic.Text == "0")
            {
                MessageBox.Show("Your cart is Empty !");
            }
            else
            {
                MessageBox.Show("We Make Your order\n The price is: " + m_TotalPriceDynmic.Text);
                double zero = 0;
                m_TotalPriceDynmic.Text = zero.ToString();
                m_TotalSum = 0;
            }
            
        }

        private void M_ResetButton_Click(object sender, EventArgs e)
        {
            double zero = 0;
            m_TotalPriceDynmic.Text = zero.ToString();
            m_TotalSum = 0;
        }

        //End Click events

        public void MakeOrderBtn()
        {
            m_MakeOrderBtn.Text = "Make Order";
            m_MakeOrderBtn.Top = m_TotalPrice.Top + 30;
            m_MakeOrderBtn.Left = m_TotalPrice.Left + 100;
            this.Controls.Add(m_MakeOrderBtn);
        }

        public void SetResetPriceButton()
        {
            double price = 0;
            m_ResetBtn.Text = "Reset";
            m_ResetBtn.Top = m_TotalPrice.Top + 30;
            m_ResetBtn.Left = m_TotalPrice.Left;
            m_TotalSum = 0;
            m_TotalPriceDynmic.Text = price.ToString();
            this.Controls.Add(m_ResetBtn);
        }

        private void RestaurantManuForm_Click(object sender, EventArgs e)
        {
            m_TotalSum += ((Coffe)sender).CoffePrice;
            m_TotalPriceDynmic.Text = m_TotalSum.ToString();
        }

        public void SetTotalPriceLabel()
        {
            m_TotalPrice = new Label();
            m_TotalPrice.Top = CoffePriceLbl.Top + 25;
            m_TotalPrice.Left = m_CoffeArray[0].Left ;
            m_TotalPrice.Width = 35;
            m_TotalPrice.Text = "Price: ";
            m_TotalPrice.BackColor = System.Drawing.Color.Yellow;
            this.Controls.Add(m_TotalPrice);
        }

        public void SetTotalPriceLblDynamic()
        {
            m_TotalPriceDynmic = new Label();
            m_TotalPriceDynmic.Top = CoffePriceLbl.Top + 25;
            m_TotalPriceDynmic.Left = m_TotalPrice.Left + 40;
            m_TotalPriceDynmic.Width = 30;
            this.Controls.Add(m_TotalPriceDynmic);
        }

        public void SetChooseCoffeLabel(Label i_ChooseCoffeLabel)
        {
            i_ChooseCoffeLabel.Font = new System.Drawing.Font("Ariel", 20);
            i_ChooseCoffeLabel.BackColor = System.Drawing.Color.Yellow;
            i_ChooseCoffeLabel.Location = new Point(10, 20);
            i_ChooseCoffeLabel.TextAlign = ContentAlignment.MiddleCenter;
            i_ChooseCoffeLabel.Text = "Wellcome "+ m_Name  + " to my restaurat" ;
            i_ChooseCoffeLabel.Height = 35;
            i_ChooseCoffeLabel.Width = 380;
        }

        public void GenerateCoffeButtons(Coffe i_CoffeBtn)
        {
            i_CoffeBtn.Top = m_CoffeChooseLbl.Top + 50;
            i_CoffeBtn.Left = m_LeftBtn;
            i_CoffeBtn.Height = 100;
            i_CoffeBtn.Width = 100;
            m_LeftBtn += 120;
        }

        // generate coffe names and price labels
        public void GenerateLabelsCoffeName(Label i_NameLbl, Coffe i_CoffeType)
        {        
            i_NameLbl.Text = String.Format("Type: {0} ", i_CoffeType.CoffeType);
            i_NameLbl.Top = i_CoffeType.Location.Y + 110;
            i_NameLbl.Left = i_CoffeType.Location.X + m_LeftNameLbl;
        }

        public void GenerateLabelsCoffePrice(Label i_PriceLbl,Coffe i_CoffeType)
        {
            i_PriceLbl.Text = String.Format("Price: {0} ", i_CoffeType.CoffePrice.ToString());
            i_PriceLbl.Top = i_CoffeType.Location.Y  + 135;
            i_PriceLbl.Left = i_CoffeType.Location.X  + 10;
        }

        //End of generate coffe names and price labels

        private void GetName(string i_GetUserName)
        {
            m_Name = i_GetUserName;
        }
    }


}
