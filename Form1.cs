using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data;  


namespace Cals
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.richTextBox1.AppendText("0");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string text = richTextBox1.Text;

            // Start from the end and find the last operator
            int lastOperatorIndex = Math.Max(
                Math.Max(text.LastIndexOf('+'), text.LastIndexOf('-')),
                Math.Max(text.LastIndexOf('*'), Math.Max(text.LastIndexOf('/'), text.LastIndexOf('x')))
            );

            // Get the current number segment after the last operator
            string currentSegment = text.Substring(lastOperatorIndex + 1);

            // If current number already contains a '.', don't add another one
            if (!currentSegment.Contains("."))
            {
                richTextBox1.AppendText(".");
            }
        }




        private void button9_Click(object sender, EventArgs e)
        {

            string currentText = RemoveLeadingZero(richTextBox1.Text);
            richTextBox1.Text = currentText + "1";
        }

        private void button8_Click(object sender, EventArgs e)
        {

            string currentText = RemoveLeadingZero(richTextBox1.Text);
            richTextBox1.Text = currentText + "2";
        }

        private void button7_Click(object sender, EventArgs e)
        {

            string currentText = RemoveLeadingZero(richTextBox1.Text);
            richTextBox1.Text = currentText + "3";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            string currentText = RemoveLeadingZero(richTextBox1.Text);
            richTextBox1.Text = currentText + "4";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            string currentText = RemoveLeadingZero(richTextBox1.Text);
            richTextBox1.Text = currentText + "5";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            string currentText = RemoveLeadingZero(richTextBox1.Text);
            richTextBox1.Text = currentText + "6";
        }

        private void button13_Click(object sender, EventArgs e)
        {

            string currentText = RemoveLeadingZero(richTextBox1.Text);
            richTextBox1.Text = currentText + "7";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string currentText = RemoveLeadingZero(richTextBox1.Text);
            richTextBox1.Text = currentText + "8";
        }

        private void button11_Click(object sender, EventArgs e)
        {

            string currentText = RemoveLeadingZero(richTextBox1.Text);
            richTextBox1.Text = currentText + "9";
        }

        private void button6_Click(object sender, EventArgs e)
        {

            string currentText = richTextBox1.Text;

            // Don't add '/' if the last character is already an operator
            if (currentText.EndsWith("/") || currentText.EndsWith("+") || currentText.EndsWith("-") || currentText.EndsWith("*") || currentText.EndsWith("x"))
                return;

            richTextBox1.AppendText("+");
        }

        private void button14_Click(object sender, EventArgs e)
        {

            string currentText = richTextBox1.Text;

            // Don't add '/' if the last character is already an operator
            if (currentText.EndsWith("/") || currentText.EndsWith("+") || currentText.EndsWith("-") || currentText.EndsWith("*") || currentText.EndsWith("x"))
                return;

            richTextBox1.AppendText("-");
        }

        private void button10_Click(object sender, EventArgs e)
        {

            string currentText = richTextBox1.Text;

            // Don't add '/' if the last character is already an operator
            if (currentText.EndsWith("/") || currentText.EndsWith("+") || currentText.EndsWith("-") || currentText.EndsWith("*") || currentText.EndsWith("x"))
                return;

            richTextBox1.AppendText("x");
        }

        private void button22_Click(object sender, EventArgs e)
        {
            string currentText = richTextBox1.Text;

            // Don't add '/' if the last character is already an operator
            if (currentText.EndsWith("/") || currentText.EndsWith("+") || currentText.EndsWith("-") || currentText.EndsWith("*") || currentText.EndsWith("x"))
                return;

            richTextBox1.AppendText("/");
        }



        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string input = richTextBox1.Text;

                // Replace 'x' (or 'X') with '*' for multiplication
                input = input.Replace("x", "*").Replace("X", "*");

                var result = new DataTable().Compute(input, null);
                richTextBox1.Text = "Answer: " + result.ToString();
            }
            catch
            {
                richTextBox1.Text = "Error: Invalid expression";
            }
        }



        private void button23_Click(object sender, EventArgs e)
        {

            if (richTextBox1.Text.Length > 0)
            {
                // Remove the last character
                richTextBox1.Text = richTextBox1.Text.Substring(0, richTextBox1.Text.Length - 1);
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "0";
        }



        private string RemoveLeadingZero(string text)
        {
            // If the text is exactly "0" or starts with "Answer", return empty
            if (text == "0" || text.StartsWith("Answer"))
                return "";

            return text;
        }

        private void button25_Click(object sender, EventArgs e)
        {
            try
            {
                string input = richTextBox1.Text;

                // If input starts with "Answer:", remove it
                if (input.StartsWith("Answer:"))
                {
                    input = input.Replace("Answer:", "").Trim();
                }

                // Evaluate if it's an expression, or just a number
                var result = new DataTable().Compute(input, null);

                // Convert to double and calculate percentage
                double number = Convert.ToDouble(result);
                double percent = number / 100.0;

                richTextBox1.Text = "Answer: " + percent.ToString();
            }
            catch
            {
                richTextBox1.Text = "Error: Invalid input";
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string input = richTextBox1.Text;

                // If input starts with "Answer", extract the number after it
                if (input.StartsWith("Answer"))
                {
                    input = input.Replace("Answer:", "").Trim();
                }

                // Convert to number
                double number = Convert.ToDouble(input);

                // Toggle the sign
                number = -number;

                // Update textbox
                richTextBox1.Text = number.ToString();
            }
            catch
            {
                richTextBox1.Text = "Error: Invalid number";
            }
        }

    }
}
