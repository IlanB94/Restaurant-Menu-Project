using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RestaurantManu
{
    class Food : Button
    {
        private String m_FoodType;
        private double m_FoodPrice;

        public Food(String i_FoodType, double i_FoodPrice)
        {
            m_FoodType = i_FoodType;
            m_FoodPrice = i_FoodPrice;
        }

        public String FoodType
        {
            get
            {
                return m_FoodType;
            }
            set
            {
                m_FoodType = value;
            }
        }

        public double FoodPrice
        {
            get
            {
                return m_FoodPrice;
            }
            set
            {
                m_FoodPrice = value;
            }
        }

    }
}
