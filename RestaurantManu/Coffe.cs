using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace RestaurantManu
{
    class Coffe : Button
    {
        private String m_CoffeType;
        private double m_CoffePrice;

        public Coffe(String i_CoffeType, double i_CoffePrice)
        {
            m_CoffeType = i_CoffeType;
            m_CoffePrice = i_CoffePrice;

        }


        public string CoffeType
        {
            get
            {
                return m_CoffeType;
            }
            set
            {
                m_CoffeType = value;
            }
        }

        public double CoffePrice
        {
            get
            {
                return m_CoffePrice;
            }
            set
            {
                m_CoffePrice = value;
            }
        }


    }
}
