using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora_Wind
{   public enum Operacion
    {
        Nodefinida=0,suma=1,resta=2,division=3,multiplicacion=4,modulo=5
     }
    public partial class Form1 : Form
    {
        double valor1 = 0;
        double valor2 = 0;
        bool unNumero = false;
        Operacion operador = Operacion.Nodefinida;
        public Form1()
        {
            InitializeComponent();
        }
        private void LeerNumero(string numero)
        {
            unNumero = true;
            if (txtResultado.Text == "0" && txtResultado.Text != null)
            {
                txtResultado.Text = numero;
            }
            else
            {
                txtResultado.Text += numero;
            }
        }
        private double EjecurarOperacion()
        {
            double resultado = 0;
            switch (operador)
            {
                case Operacion.suma:
                    resultado = valor1 + valor2;
                    break;
                case Operacion.resta:
                    resultado = valor1 - valor2;
                    break;
                case Operacion.division:
                    if (valor2 == 0)
                    {
                        lblHistorial.Text = "no se puede dividir para 0";
                        MessageBox.Show("no se puede dividir para 0");
                        resultado = 0;
                    }
                    else
                    {
                        resultado = valor1 / valor2;
                    }
                    break;
                case Operacion.multiplicacion:
                    resultado = valor1 * valor2;
                    break;
                case Operacion.modulo:
                    resultado = valor1 % valor2;
                    break;
            }
            return resultado;
        }
        private void btn0_Click(object sender, EventArgs e)
        {
            unNumero = true;
            if (txtResultado.Text == "0")
            {
                return;
            }
            else
            {

                txtResultado.Text += "0";
            }
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            LeerNumero("1");
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            LeerNumero("2");

        }

        private void btn3_Click(object sender, EventArgs e)
        {
            LeerNumero("3");

        }

        private void btn4_Click(object sender, EventArgs e)
        {
            LeerNumero("4");

        }

        private void btn5_Click(object sender, EventArgs e)
        {
            LeerNumero("5");

        }

        private void btn6_Click(object sender, EventArgs e)
        {
            LeerNumero("6");

        }

        private void btn7_Click(object sender, EventArgs e)
        {
            LeerNumero("7");

        }

        private void btn8_Click(object sender, EventArgs e)
        {
            LeerNumero("8");

        }

        private void btn9_Click(object sender, EventArgs e)
        {
            LeerNumero("9");
        }

        private void ObtenerValor(string operador)
        {
            valor1 = Convert.ToDouble(txtResultado.Text);
            lblHistorial.Text = txtResultado.Text + operador;
            txtResultado.Text = "0";
        }
        private void btnsuma_Click(object sender, EventArgs e)
        {
            operador = Operacion.suma;
            ObtenerValor("+");
        }

        private void btnigual_Click(object sender, EventArgs e)
        {
            if (valor2 == 0 && unNumero)
            {
                valor2 = Convert.ToDouble(txtResultado.Text);
                lblHistorial.Text += valor2+"=";
                double resultado = EjecurarOperacion();
                valor1 = 0;
                valor2 = 0;
                unNumero = false;
                txtResultado.Text = Convert.ToString(resultado);
            }
        }

        private void btnresta_Click(object sender, EventArgs e)
        {
            operador = Operacion.resta;
            ObtenerValor("-");
        }

      

        private void btndivision_Click(object sender, EventArgs e)
        {
            operador = Operacion.division;
            ObtenerValor("/");
        }

        private void btnmodulo_Click(object sender, EventArgs e)
        {
            operador = Operacion.modulo;
            ObtenerValor("%");
        }

        private void btnmultiplicacion_Click_1(object sender, EventArgs e)
        {
            operador = Operacion.multiplicacion;
            ObtenerValor("*");
        }

        private void btnborrar_Click(object sender, EventArgs e)
        {
            if (txtResultado.Text.Length > 1)
            {
                string resultado = txtResultado.Text;
                resultado = resultado.Substring(0, resultado.Length - 1);
                if(resultado.Length==1 && resultado.Contains("-"))
                {
                    txtResultado.Text = "0";
                }
                else
                {

                    txtResultado.Text = resultado;
                }
            }
            else
            {
                txtResultado.Text = "0";
            }
        }

        private void btnpunto_Click(object sender, EventArgs e)
        {
            if (txtResultado.Text.Contains("."))
            {
                return;
            }
            txtResultado.Text += ".";
        }

        private void btnc_Click(object sender, EventArgs e)
        {
            txtResultado.Text = "0";
            lblHistorial.Text = "";
        }
    }
}
