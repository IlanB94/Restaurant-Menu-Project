using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RestaurantManu
{
    class Program
    {
        static void Main()
        {
            UserDetailsForm userDetailsForm = new UserDetailsForm();
            RestaurantManuForm restaurantManuForm = new RestaurantManuForm(userDetailsForm.GetName);
            userDetailsForm.ShowDialog();
            restaurantManuForm.ShowDialog();
        }
    }

    
}
