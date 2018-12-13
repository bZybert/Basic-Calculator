using System;
using System.Linq;
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
            InsertTextValue("/");

        }

        private void Xbutton_Click(object sender, EventArgs e)
        {
            InsertTextValue("*");

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
            DeleteTextValue();


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

        private void DeleteTextValue()
        {
            //if we don't have value to delete, return
            if (this.UserInputText.Text.Length < this.UserInputText.SelectionStart + 1)
                return;

            //remember selection start
            var selectionStart = this.UserInputText.SelectionStart;

            //delete character to the right of the section
            this.UserInputText.Text = this.UserInputText.Text.Remove(this.UserInputText.SelectionStart, 1);

            // Restore selection start
            this.UserInputText.SelectionStart = selectionStart;

            //set selection length to 0
            this.UserInputText.SelectionLength = 0;
        }

        private void CalculateEquation()
        {

            this.CalculatorResultText.Text = ParseOperation();



            //focus the user input text
            FocusedInputType();
        }

        /// <summary>
        /// Parses the users equation and calculates result
        /// </summary>
        /// <returns></returns>
        private string ParseOperation()
        {
            try
            {
                // get the users equation input
                var input = this.UserInputText.Text;

                //remove all spaces
                input = input.Replace(" ", "");

                // create a new top level operation
                var operation = new Operation();
                var leftSide = true;


                //loop for the each character in input
                for (int i = 0; i < input.Length; i++)
                {
                    //TODO: handle order priority
                    // 6 + 1 * 3


                    //check if the character is a number      
                    if ("0123456789.".Any(c => input[i] == c))
                    {
                        if (leftSide)
                            operation.LeftSide = AddNumberPart(operation.LeftSide, input[i]);
                        else
                            operation.RightSide = AddNumberPart(operation.RightSide, input[i]);

                    }
                    // if it is a operator ( + - / * ) set the operator type
                    else if ("+-/*".Any(c => input[i] == c))
                    {
                        // if we are on the right side already, we don't need to calculate our current operation
                        // and set the result to the left side of the next operation
                        if (!leftSide)
                        {
                            var operatorType = GetOperationType(input[i]);

                            // check if we have a right side number
                            if (operation.RightSide.Length == 0)
                            {
                                // check the operator is not a minus
                                if (operatorType != OperationType.Minus)
                                    throw new InvalidOperationException($"Operator (+ * / or more then one - ) specified without a right side number");

                                operation.RightSide += input[i];
                            }
                            else
                            {
                              // calculate previous equation and set to left side
                                operation.LeftSide = CalculateOperation(operation);

                                // set new operator
                                operation.OperationType = operatorType;

                                // clear the previous right number
                                operation.RightSide = string.Empty;
                            }
                        }
                        else
                        {
                            var operatorType = GetOperationType(input[i]);

                            // check if we have a left side number
                            if (operation.LeftSide.Length == 0)
                            {
                                // check the operator is not a minus
                                if (operatorType != OperationType.Minus)
                                    throw new InvalidOperationException($"Operator (+ * / or more then one - ) specified without a left side number");

                                operation.LeftSide += input[i];
                            }
                            else
                            {
                                // if we get here, we have got a left number and now an operator , so we want to move to the right side

                                // set the operation type
                                operation.OperationType = operatorType;

                                // move to the right side 
                                leftSide = false;
                            }
                        }
                        }

                    }

                    // if we are done parsing, and there where no exceptions
                    // calculate the current operation
                    return CalculateOperation(operation);

                  //  return string.Empty;

                }
            catch (Exception ex)
            {
                return $"invalid  equation. {ex.Message}";
            }
        }

        /// <summary>
        /// Calculate an <see cref="Operation"/> and return the result
        /// </summary>
        /// <param name="operation">the operation to calculate</param>
        private string CalculateOperation(Operation operation)
        {
            //store the number values of the string representations
            decimal left = 0;
            decimal right = 0;

            // check if we have a valid left side number
            if (string.IsNullOrEmpty(operation.LeftSide) || !decimal.TryParse(operation.LeftSide, out left))
                throw new InvalidOperationException($"Left side of the operation was not a number. {operation.LeftSide}");

            // check if we have a valid rirht side number
            if (string.IsNullOrEmpty(operation.RightSide) || !decimal.TryParse(operation.RightSide, out right))
                throw new InvalidOperationException($"Right side of the operation was not a number. {operation.RightSide}");

            try
            {
                switch (operation.OperationType)
                {
                    case OperationType.Add:
                        return (left + right).ToString();
                    case OperationType.Minus:
                        return (left - right).ToString();
                    case OperationType.Divide:
                        return (left / right).ToString();
                    case OperationType.Multiply:
                        return (left * right).ToString();
                    default:
                        throw new InvalidOperationException($"Unknown operator type when calculating operation. {operation.OperationType}");
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Failed to calculate operation {operation.LeftSide} {operation.OperationType} {operation.RightSide}. {ex.Message}");
            }

        }

        /// <summary>
        /// Accept a character and return the known <see cref="OperationType"/>
        /// </summary>
        /// <param name="character">character to parse</param>
        /// <returns></returns>
        private OperationType GetOperationType(char character)
        {
            switch (character)
            {
                case '+':
                    return OperationType.Add;
                case '-':
                    return OperationType.Minus;
                case '/':
                    return OperationType.Divide;
                case '*':
                    return OperationType.Multiply;
                default:
                    throw new InvalidOperationException($"Unknown operator type: {character}");
            }

        }


        private string AddNumberPart(string currentNumber, char newCharacter)
        {
            //check if there is already a . in a number
            if (newCharacter == '.' && currentNumber.Contains('.'))
                throw new InvalidOperationException($"Number {currentNumber} already contains a . and another cannot be added");

            return currentNumber + newCharacter;
        }
        #endregion


        private void button13_Click(object sender, EventArgs e)
        {

        }


    }
}
