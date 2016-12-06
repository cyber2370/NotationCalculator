using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NotationCalculator;

namespace NotCalcWinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Number _number1, _number2;

        private void plus_button_Click(object sender, EventArgs e)
        {
            CollectDataFromForm();

            var number = MathExecutor.Execute(_number1, _number2, MathOperations.Addition);
            FillDiffNotations(number);
        }

        private void substract_button_Click(object sender, EventArgs e)
        {
            CollectDataFromForm();

            var number = MathExecutor.Execute(_number1, _number2, MathOperations.Subtraction);
            FillDiffNotations(number);
        }

        private void multiply_button_Click(object sender, EventArgs e)
        {
            CollectDataFromForm();

            var number = MathExecutor.Execute(_number1, _number2, MathOperations.Multiplication);
            FillDiffNotations(number);
        }

        private void divide_button_Click(object sender, EventArgs e)
        {
            CollectDataFromForm();

            var number = MathExecutor.Execute(_number1, _number2, MathOperations.Division);
            FillDiffNotations(number);
        }

        private void num2_TB_TextChanged(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void num1_TB_TextChanged(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void num1_nud_ValueChanged(object sender, EventArgs e)
        {

            ClearFields();
        }

        private void num2_nud_ValueChanged(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void CollectDataFromForm()
        {
            _number1 = new Number(num1_TB.Text.Trim(), (int)num1_nud.Value);
            _number2 = new Number(num2_TB.Text.Trim(), (int)num2_nud.Value);
        }

        private void FillDiffNotations(Number number)
        {
            not2_lbl.Text = (number.IsNegative ? "-" : "") + number.Value.ConvertToAnyNotation(number.Notation, 2).TrimStart();
            not8_lbl.Text = (number.IsNegative ? "-" : "") + number.Value.ConvertToAnyNotation(number.Notation, 8).TrimStart();
            not10_lbl.Text = (number.IsNegative ? "-" : "") + number.Value.ConvertToAnyNotation(number.Notation, 10).TrimStart();
            not16_lbl.Text = (number.IsNegative ? "-" : "") + number.Value.ConvertToAnyNotation(number.Notation, 16).TrimStart();
        }

        private void ClearFields()
        {
            not2_lbl.Text = "0";
            not8_lbl.Text = "0";
            not10_lbl.Text = "0";
            not16_lbl.Text = "0";
        }
    }
}
