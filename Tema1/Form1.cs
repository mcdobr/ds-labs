using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tema1
{
    public partial class CalculatorForm : Form
    {
        private static char GUARDIAN_OPERATION = '#';
        private static Dictionary<char, int> operatorPriorityInExpression = new Dictionary<char, int>()
        {
            {'#', -1},
            {'+', 1}, {'-', 1},
            {'*', 2}, {'/', 2},
            {'^', 4},
            {'(', 5},
        };
        private static Dictionary<char, int> operatorPriorityInStack = new Dictionary<char, int>()
        {
            {'#', -1},
            {'+', 1}, {'-', 1},
            {'*', 2}, {'/', 2},
            {'^', 3},
            {'(', 0},
        };

        private static char[] operators = {'+', '-', '*', '/', '^', '('};


        public CalculatorForm()
        {
            InitializeComponent();
        }

        private void button_click(object sender, EventArgs e)
        {
            calcBox.Text += (sender as Button).Text;
        }

        private void buttonClear_click(object sender, EventArgs e)
        {
            calcBox.Text = "";
        }

        private void buttonBackspace_click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(calcBox.Text))
                calcBox.Text = calcBox.Text.Remove(calcBox.Text.Length - 1);
        }

        private bool isOperator(char c)
        {
            return operators.Contains(c);
        }

        private string postfix_representation(string expr)
        {
            StringBuilder sb = new StringBuilder();

            Stack<char> operatorStack = new Stack<char>();
            operatorStack.Push(GUARDIAN_OPERATION);
            
            foreach (char c in expr)
            {
                if (Char.IsDigit(c) || c == '.')
                {
                    sb.Append(c);
                }
                else if (isOperator(c))
                {
                    sb.Append(' ');
                    if (operatorPriorityInExpression[c] <= operatorPriorityInStack[operatorStack.Peek()])
                        sb.Append(operatorStack.Pop());
                    operatorStack.Push(c);
                }
                else if (c == ')')
                {
                    sb.Append(' ');
                    while (operatorStack.Peek() != '(')
                        sb.Append(operatorStack.Pop());
                    operatorStack.Pop();
                }
            }

            while (operatorStack.Peek() != GUARDIAN_OPERATION)
            {
                sb.Append(' ');
                sb.Append(operatorStack.Pop());
            }
            return sb.ToString().Trim();
        }

        private double eval(string postfix_repr)
        {
            double result = 0.0;

            string[] tokens = postfix_repr.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            Stack<double> operandStack = new Stack<double>();


            foreach (string token in tokens)
            {
                if (isOperator(token[0]))
                {
                    double operandRight = operandStack.Pop();
                    double operandLeft = operandStack.Pop();

                    double intermediary_res = 0;
                    switch (token[0])
                    {
                        case '+':
                            intermediary_res = operandLeft + operandRight;
                            break;
                        case '-':
                            intermediary_res = operandLeft - operandRight;
                            break;
                        case '*':
                            intermediary_res = operandLeft * operandRight;
                            break;
                        case '/':
                            intermediary_res = operandLeft / operandRight;
                            break;
                        case '^':
                            intermediary_res = Math.Pow(operandLeft, operandRight);
                            break;
                    }
                    operandStack.Push(intermediary_res);

                }
                else
                {
                    operandStack.Push(Double.Parse(token));
                }
            }

            result = operandStack.Pop();
            return result;
        }

        private void buttonEquals_click(object sender, EventArgs e)
        {
            string postfix_expr = postfix_representation(this.calcBox.Text);
            double result = eval(postfix_expr);

            this.calcBox.Text = result.ToString();
            
            this.textBox1.Text = postfix_expr;
        }
    }
}
