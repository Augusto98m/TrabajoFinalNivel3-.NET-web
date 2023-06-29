using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;


namespace Services
{
    public static class Validacion
    {
        public static bool validaVacio(object control)
        {
            if (control is TextBox)
            {
                if (string.IsNullOrEmpty(((TextBox)control).Text))
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            return false;
        }        
    }
}
