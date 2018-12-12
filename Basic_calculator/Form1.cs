using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Basic_calculator
{
    /// <summary>
    /// Basic Calculator
    /// </summary>
    public partial class Form1 : Form
    {
        #region Constructor
        public Form1()
        {
            InitializeComponent();
        }
        #endregion

        #region Operators
        private void PercentButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("%");

        }

        private void Xbutton_Click(object sender, EventArgs e)
        {
            InsertTextValue("x");

            //focus the user input
            FocusedInputType();

        }
        private void DevideButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("/");

            //focus the user input
            FocusedInputType();
        }

        private void MinusButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("-");

            //focus the user input
            FocusedInputType();

        }

        private void PlusButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("+");

            //focus the user input
            FocusedInputType();

        }

        private void EqualButton_Click(object sender, EventArgs e)
        {
            CalculateEquation();

            //focus the user input
            FocusedInputType();
        }




        #endregion

        #region Numbers Methods
        private void ZeroButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("0");

            //focus the user input
            FocusedInputType();

        }

        private void OneButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("1");

            //focus the user input
            FocusedInputType();

        }

        private void TwoButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("2");

            //focus the user input
            FocusedInputType();
        }

        private void TreeButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("3");

            //focus the user input
            FocusedInputType();
        }

        private void FourButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("4");

            //focus the user input
            FocusedInputType();
        }

        private void FiveButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("5");

            //focus the user input
            FocusedInputType();
        }

        private void SixButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("6");

            //focus the user input
            FocusedInputType();
        }

        private void SevenButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("7");

            //focus the user input
            FocusedInputType();
        }

        private void EightButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("8");

            //focus the user input
            FocusedInputType();
        }

        private void NineButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("9");

            //focus the user input
            FocusedInputType();
        }

        private void DotButton_Click(object sender, EventArgs e)
        {
            InsertTextValue(".");

            //focus the user input
            FocusedInputType();

        }
        #endregion


        #region Clearing Methods
        private void Cbutton_Click(object sender, EventArgs e)
        {

        }

        private void DelButton_Click(object sender, EventArgs e)
        {
            if (this.UserInputText.Text.Length >= this.UserInputText.SelectionStart + 1)
                this.UserInputText.Text = this.UserInputText.Text.Remove(this.UserInputText.SelectionStart, 1);

            FocusedInputType();
        }

        private void CEbutton_Click(object sender, EventArgs e)
        {
            //clear the textfrom the user input
            this.UserInputText.Text = string.Empty;

            //focus the user input
            FocusedInputType();
        }
        #endregion

        #region private helpers

        private void FocusedInputType()
        {
            this.UserInputText.Focus();
        }

        private void InsertTextValue(string value)
        {
            var selectionStart = this.UserInputText.SelectionStart;
            this.UserInputText.Text = this.UserInputText.Text.Insert(this.UserInputText.SelectionStart, value);

            // Restore selection start
            this.UserInputText.SelectionStart = selectionStart + value.Length;

            //set selection length to 0
            this.UserInputText.SelectionLength = 0;
        }

        private void CalculateEquation()
        {

        }
        #endregion


        private void button13_Click(object sender, EventArgs e)
        {

        }


    }
}
