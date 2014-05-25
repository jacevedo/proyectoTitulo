using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
namespace SFH_Software
{
   class Validaciones
    {
        public bool EsNumero(Control textbox)
        {
            Regex regex = new Regex(@"^[0-9]+$");
            return regex.IsMatch(textbox.Text);
        }
        public bool EsDecimalOEntero(Control textbox)
        {
            Regex regex = new Regex(@"^\d*[0-9](|.\d*[0-9]|,\d*[0-9])?$");
            return regex.IsMatch(textbox.Text);

        }
        public bool EsSoloTexto(Control textbox)
        {
            Regex regex = new Regex(@"^[^ ][a-zA-Z ]+[^ ]$");
            return regex.IsMatch(textbox.Text);
        }
        public bool EsSoloafanumerico(Control textbox)
        {
            Regex regex = new Regex(@"(\w(\s)?)+");
            return regex.IsMatch(textbox.Text);
        }
        public bool EsHora(Control textbox)
        {
            Regex regex = new Regex(@"^([0-1][0-9]|[2][0-3]):([0-5][0-9])$");
            return regex.IsMatch(textbox.Text);
        }
        public bool ValidaTelefono(Control textbox)
        {
            Regex regex = new Regex(@"^(([+]\d{2}[ ][1-9]\d{0,2}[ ])|([0]\d{1,3}[-]))((\d{2}([ ]\d{2}){2})|(\d{3}([ ]\d{3})*([ ]\d{2})+))$");
            return regex.IsMatch(textbox.Text);
        }
        public bool ValidaCorreo(Control textbox)
        {
            Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            return regex.IsMatch(textbox.Text);
        }
        public bool RutValido(string r,string dv)
        {
            int suma = 0;
            for (int x = r.Length - 1; x >= 0; x--)
                suma += int.Parse(char.IsDigit(r[x]) ? r[x].ToString() : "0") * (((r.Length - (x + 1)) % 6) + 2);
            int numericDigito = (11 - suma % 11);
            string digito = numericDigito == 11 ? "0" : numericDigito == 10 ? "K" : numericDigito.ToString();
            if(digito.Equals(dv)){
                return true;
            }else{
               return false;
            }
        }
        public bool ValidarClave(Control textbox)
        {
            if (textbox.Text.Length > 7)
            {
                return true;
            }
            else {
                return false;
            }
       }
        public bool ValidarClaves(Control textbox1, Control textbox2) {
            if (textbox1.Text.Equals(textbox1.Text))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
