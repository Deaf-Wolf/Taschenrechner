using System.Data;

namespace Taschernrechner
{
    public partial class Form1 : Form
    {
        // Creates an empty string as input.
         string currentCalculation = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            textBox1.Text = currentCalculation;
            /*
             * Shows the Clalculation in Textbox
             * 
             * Is called in button_equals_click
             */
        }

        private void textBox_history_TextChanged(object sender, EventArgs e)
        {
            /* 
             * Shows the last calulation in Textbox
             * Is called in button_equals_Click 
            */
        }

        /*
         * Die button0 bis button9 und die button_+,-,*,/,(,),π benutzen die gleiche code
         * Um Zeit und Platzt sparen kann man das Code einmal Schreiben und bei jeden Button
         * im Event beim click zuweisen. 
         */

        private void button0_Click(object sender, EventArgs e)
        {
            // This adds the number or operator to the string calculation
            currentCalculation += (sender as Button).Text;

            // Display the current calculation back to the user
            textBox1.Text = currentCalculation;
        }

        private void button_equals_Click(object sender, EventArgs e)
        {
            // Erkennt das Pi im currentCalculation und setzt das Witzt ein.
            if (currentCalculation.Contains("π"))
            {
                textBox1.Text = "So schlau bin ich nicht ;D";
            }
            //Berchnet und zeig die Gleichung an.
            else
            {
                try
                {
                    textBox1.Text = new DataTable().Compute(currentCalculation, null).ToString();
                    currentCalculation = textBox1.Text;
                    textBox_history.Text = "";
                    textBox_history.Text = textBox1.Text;
                }
                catch (Exception ex)
                {
                    textBox1.Text = "Error";
                    currentCalculation = "";
                }
            }

        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            //Reset the claculator and show clear on Textbox
            currentCalculation = "";
            textBox1.Text = "clear";
        }

        private void button_clearEntry_Click(object sender, EventArgs e)
        {
            // If the calculation is not empty, remove the last number/operator entered
            if (currentCalculation.Length > 0)
            {
                currentCalculation = currentCalculation.Remove(currentCalculation.Length - 1, 1);

                // Update the calculation onto the Textbox
                textBox1.Text = currentCalculation;
            }
            else
            {
                textBox1.Text = "clear";
            }



        }

        private void button_moveLeft_Click(object sender, EventArgs e)
        {
            // If the calculation is not empty, remove the last number/operator entered
            if (currentCalculation.Length > 0)
            {
                currentCalculation = currentCalculation.Remove(currentCalculation.Length - 1, 1);

                // Update the calculation onto the Textbox
                textBox1.Text = currentCalculation;
            }
            else
            {
                textBox1.Text = "clear";
            }
        }


    }
}