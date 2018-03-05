using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void button_click(object sender, EventArgs e)
        {
            string operation = ((Button)sender).Text;
            bool divisionByZero = false;

            if (operation == "=")
            {

                double operand1 = Double.Parse(this.operand1.Text);
                double operand2 = Double.Parse(this.operand2.Text);
                double res = 0.0;

                switch (this.operation)
                {
                    case "+":
                        res = operand1 + operand2;
                        break;
                    case "-":
                        res = operand1 - operand2;
                        break;
                    case "*":
                        res = operand1 * operand2;
                        break;
                    case "/":
                        if (Math.Abs(operand2) < 1e-6)
                        {
                            divisionByZero = true;
                        }
                        res = operand1 / operand2;
                        break;
                    case "^":
                        res = Math.Pow(operand1, operand2);
                        break;
                    case "%":
                        res = operand1 % operand2;
                        if (res < 0)
                            res += operand2;
                        break;
                }
                if (divisionByZero)
                {
                    this.result.Text = "Division by zero";
                    return;
                }
                this.result.Text = res.ToString();
            }
            else
            {
                this.operation = operation;
            }
            
        }
        
    }
}
