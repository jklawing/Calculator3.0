using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator3._0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        // Permanent Members
        string output = "";
        string operation = "";

        double temp = 0;
        double temp2 = 0;

        string sign = "";
        string number1 = "";
        string number2 = "";
        string result = "";

        bool clearOutputBox = false;

        public MainWindow()
        {
            InitializeComponent();

            // Button symbols
            ButtonDivide.Content = "\u00F7";
            ButtonSquared.Content = "x" + "\u00B2";
            ButtonSquareRoot.Content = "\u221A";
            ButtonPosNeg.Content = "\u00B1";
        }

        // Number Button Click Event
        private void ButtonNumber_Click(object sender, RoutedEventArgs e)
        {
            // Whichever button was clicked
            string name = ((Button)sender).Name;

            // After equals, clear output box on Number button click
            if (clearOutputBox == true)
            {
                output = "";
                clearOutputBox = false;
            }

            // Converts to output
            switch (name)
            {
                case "Button0":
                    output += "0";
                    temp2 = double.Parse(output);
                    OutputTextBlock.Text = output;
                    break;

                case "Button1":
                    output += "1";
                    temp2 = double.Parse(output);
                    OutputTextBlock.Text = output;
                    break;

                case "Button2":
                    output += "2";
                    temp2 = double.Parse(output);
                    OutputTextBlock.Text = output;
                    break;

                case "Button3":
                    output += "3";
                    temp2 = double.Parse(output);
                    OutputTextBlock.Text = output;
                    break;

                case "Button4":
                    output += "4";
                    temp2 = double.Parse(output);
                    OutputTextBlock.Text = output;
                    break;

                case "Button5":
                    output += "5";
                    temp2 = double.Parse(output);
                    OutputTextBlock.Text = output;
                    break;

                case "Button6":
                    output += "6";
                    temp2 = double.Parse(output);
                    OutputTextBlock.Text = output;
                    break;

                case "Button7":
                    output += "7";
                    temp2 = double.Parse(output);
                    OutputTextBlock.Text = output;
                    break;

                case "Button8":
                    output += "8";
                    temp2 = double.Parse(output);
                    OutputTextBlock.Text = output;
                    break;

                case "Button9":
                    output += "9";
                    temp2 = double.Parse(output);
                    OutputTextBlock.Text = output;
                    break;

                case "ButtonDecimal":
                    if (!output.Contains("."))
                    {
                        output += ".";
                        temp2 = double.Parse(output);
                        OutputTextBlock.Text = output;
                    }
                    break;
            }
        }

        #region Operation Button Click Events
        // Subtract
        private void ButtonSubtract_Click(object sender, RoutedEventArgs e)
        {
            clearOutputBox = false;
            if (output != "")
            {
                temp = double.Parse(output);
                output = "";
                operation = "subtract";
            }
        }

        // Add
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            clearOutputBox = false;
            if (output != "")
            {
                temp = double.Parse(output);
                output = "";
                operation = "add";
            }
        }

        // Multiply
        private void ButtonMultiply_Click(object sender, RoutedEventArgs e)
        {
            clearOutputBox = false;
            if (output != "")
            {
                temp = double.Parse(output);
                output = "";
                operation = "multiply";
            }
        }

        // Divide
        private void ButtonDivide_Click(object sender, RoutedEventArgs e)
        {
            clearOutputBox = false;
            if (output != "")
            {
                temp = double.Parse(output);
                output = "";
                operation = "divide";
            }
        }

        // Equals
        private void ButtonEquals_Click(object sender, RoutedEventArgs e)
        {
            double outputTemp;
            clearOutputBox = true;

            switch (operation)
            {
                case "subtract":
                    sign = "-";
                    number1 = temp.ToString();
                    number2 = temp2.ToString();
                    
                    outputTemp = temp - temp2;

                    output = outputTemp.ToString();
                    result = output;

                    OutputTextBlock.Text = output;
                    AddToHistory();

                    temp = outputTemp;
                    break;

                case "add":
                    sign = "+";
                    number1 = temp.ToString();
                    number2 = temp2.ToString();

                    outputTemp = temp + temp2;

                    output = outputTemp.ToString();
                    result = output;

                    OutputTextBlock.Text = output;
                    AddToHistory();

                    temp = outputTemp;
                    break;

                case "multiply":
                    sign = "*";
                    number1 = temp.ToString();
                    number2 = temp2.ToString();

                    outputTemp = temp * temp2;

                    output = outputTemp.ToString();
                    result = output;

                    OutputTextBlock.Text = output;
                    AddToHistory();

                    temp = outputTemp;
                    break;

                case "divide":
                    if (double.Parse(output) != 0)
                    {
                        sign = "/";
                        number1 = temp.ToString();
                        number2 = temp2.ToString();

                        outputTemp = temp / temp2;

                        output = outputTemp.ToString();
                        result = output;

                        OutputTextBlock.Text = output;
                        AddToHistory();

                        temp = outputTemp;
                        break;
                    }
                    break;
            }
        }

        // Squared
        private void ButtonSquared_Click(object sender, RoutedEventArgs e)
        {
            sign = "^";
            number1 = output;
            number2 = "2";
            double square = double.Parse(output);
            output = (square * square).ToString();
            result = output;
            OutputTextBlock.Text = output;
            AddToHistory();
        }

        // Clear
        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            output = "";
            OutputTextBlock.Text = output;
        }

        // Square Root
        private void ButtonSquareRoot_Click(object sender, RoutedEventArgs e)
        {
            if (output != "")
            {
                sign = "of";
                number1 = "Square root";
                number2 = output;
                double squareRoot = double.Parse(output);
                output = Math.Sqrt(squareRoot).ToString();
                result = output;
                OutputTextBlock.Text = output;
                AddToHistory();
            }
        }

        // Positive/Negative
        private void ButtonPosNeg_Click(object sender, RoutedEventArgs e)
        {
            double posNegTemp;
            if (output != "")
            {
                posNegTemp = double.Parse(output) * -1;
                output = (posNegTemp).ToString();
                OutputTextBlock.Text = output;
            }
        }
        #endregion

        // Add to History Method
        private void AddToHistory()
        {
            HistoryTextBlock.Text = HistoryTextBlock.Text + $"\n{number1} {sign} {number2} = {result}";
        }

        // Clear History Button Click Event
        private void ButtonClearHistory_Click(object sender, RoutedEventArgs e)
        {
            HistoryTextBlock.Text = "";
        }

        // KeyDown Events
        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                #region Number Keys
                // Key 0
                case Key.D0:
                case Key.NumPad0:
                    ButtonNumber_Click(Button0, e);
                    break;

                // Key 1
                case Key.D1:
                case Key.NumPad1:
                    ButtonNumber_Click(Button1, e);
                    break;

                // Key 2
                case Key.D2:
                case Key.NumPad2:
                    ButtonNumber_Click(Button2, e);
                    break;

                // Key 3
                case Key.D3:
                case Key.NumPad3:
                    ButtonNumber_Click(Button3, e);
                    break;

                // Key 4
                case Key.D4:
                case Key.NumPad4:
                    ButtonNumber_Click(Button4, e);
                    break;


                // Key 5
                case Key.D5:
                case Key.NumPad5:
                    ButtonNumber_Click(Button5, e);
                    break;

                // Key 6
                case Key.D6:
                case Key.NumPad6:
                    ButtonNumber_Click(Button6, e);
                    break;

                // Key 7
                case Key.D7:
                case Key.NumPad7:
                    ButtonNumber_Click(Button7, e);
                    break;

                // Key 8 & Key Multiply
                case Key.D8:
                    // Key Multiply
                    if (Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift))
                    {
                        ButtonMultiply_Click(ButtonMultiply, e);
                    }
                    // Key 8
                    else
                        ButtonNumber_Click(Button8, e);
                    break;
                case Key.NumPad8:
                    ButtonNumber_Click(Button8, e);
                    break;

                // Key 9
                case Key.D9:
                case Key.NumPad9:
                    ButtonNumber_Click(Button9, e);
                    break;

                // Key .
                case Key.OemPeriod:
                case Key.Decimal:
                    ButtonNumber_Click(ButtonDecimal, e);
                    break;
                #endregion

                #region Operator Keys
                // Key -
                case Key.Subtract:
                case Key.OemMinus:
                    ButtonSubtract_Click(ButtonSubtract, e);
                    break;

                // Key +
                case Key.Add:
                    ButtonAdd_Click(ButtonAdd, e);
                    break;
                case Key.OemPlus:
                    // Key +
                    if (Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift))
                    {
                        ButtonAdd_Click(ButtonAdd, e);
                    }
                    // Key =
                    else
                        ButtonEquals_Click(ButtonEquals, e);
                    break;

                // Key *
                case Key.Multiply:
                    ButtonMultiply_Click(ButtonMultiply, e);
                    break;

                // Key /
                case Key.Divide:
                case Key.OemQuestion:
                    ButtonDivide_Click(ButtonDivide, e);
                    break;

                // Key =
                case Key.Enter:
                    ButtonEquals_Click(ButtonEquals, e);
                    break;

                // Key Backspace
                case Key.Back:
                    if (output != "")
                    {
                        output = output.Remove((output.Length - 1), 1);
                        OutputTextBlock.Text = output;
                    }
                    break;
                    #endregion
            }
        }
    }
}
