﻿using System;
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


        private string postfix_representation(string expr)
        {
            StringBuilder sb = new StringBuilder();

            Stack<string> operatorStack, operandStack;




            return "";
        }


        private void buttonEquals_click(object sender, EventArgs e)
        {
            
        }
    }
}
