using System.Data;

namespace Taschernrechner
{
    public partial class Form1 : Form
    {
        // Creates an empty string as input.
        private string currentCalculation = "";


        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            /*
             * Shows the Clalculation in Textbox
             * 
             * Is called in button_equals_click
             */
        }

        /*
         * From button0 to button9 and button_+,-,*,/,(,),π use the same code:
        
            // This adds the number or operator to the string calculation
            currentCalculation += (sender as Button).Text;

            // Display the current calculation back to the user
            textBox1.Text = currentCalculation;

         */

        private void button0_Click(object sender, EventArgs e)
        {
            // This adds the number or operator to the string calculation
            currentCalculation += (sender as Button).Text;

            // Display the current calculation back to the user
            textBox1.Text = currentCalculation;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // This adds the number or operator to the string calculation
            currentCalculation += (sender as Button).Text;

            // Display the current calculation back to the user
            textBox1.Text = currentCalculation;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // This adds the number or operator to the string calculation
            currentCalculation += (sender as Button).Text;

            // Display the current calculation back to the user
            textBox1.Text = currentCalculation;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // This adds the number or operator to the string calculation
            currentCalculation += (sender as Button).Text;

            // Display the current calculation back to the user
            textBox1.Text = currentCalculation;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // This adds the number or operator to the string calculation
            currentCalculation += (sender as Button).Text;

            // Display the current calculation back to the user
            textBox1.Text = currentCalculation;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // This adds the number or operator to the string calculation
            currentCalculation += (sender as Button).Text;

            // Display the current calculation back to the user
            textBox1.Text = currentCalculation;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // This adds the number or operator to the string calculation
            currentCalculation += (sender as Button).Text;

            // Display the current calculation back to the user
            textBox1.Text = currentCalculation;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // This adds the number or operator to the string calculation
            currentCalculation += (sender as Button).Text;

            // Display the current calculation back to the user
            textBox1.Text = currentCalculation;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            // This adds the number or operator to the string calculation
            currentCalculation += (sender as Button).Text;

            // Display the current calculation back to the user
            textBox1.Text = currentCalculation;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            // This adds the number or operator to the string calculation
            currentCalculation += (sender as Button).Text;

            // Display the current calculation back to the user
            textBox1.Text = currentCalculation;
        }

        private void button_plus_Click(object sender, EventArgs e)
        {
            // This adds the number or operator to the string calculation
            currentCalculation += (sender as Button).Text;

            // Display the current calculation back to the user
            textBox1.Text = currentCalculation;
        }

        private void button_minus_Click(object sender, EventArgs e)
        {
            // This adds the number or operator to the string calculation
            currentCalculation += (sender as Button).Text;

            // Display the current calculation back to the user
            textBox1.Text = currentCalculation;
        }

        private void button_multi_Click(object sender, EventArgs e)
        {
            // This adds the number or operator to the string calculation
            currentCalculation += (sender as Button).Text;

            // Display the current calculation back to the user
            textBox1.Text = currentCalculation;
        }

        private void button_division_Click(object sender, EventArgs e)
        {
            // This adds the number or operator to the string calculation
            currentCalculation += (sender as Button).Text;

            // Display the current calculation back to the user
            textBox1.Text = currentCalculation;
        }

        private void button_klammerL_Click(object sender, EventArgs e)
        {
            // This adds the number or operator to the string calculation
            currentCalculation += (sender as Button).Text;

            // Display the current calculation back to the user
            textBox1.Text = currentCalculation;
        }

        private void button_klammerR_Click(object sender, EventArgs e)
        {
            // This adds the number or operator to the string calculation
            currentCalculation += (sender as Button).Text;

            // Display the current calculation back to the user
            textBox1.Text = currentCalculation;
        }

        private void button_pi_Click(object sender, EventArgs e)
        {
            // This adds the number or operator to the string calculation
            currentCalculation += (sender as Button).Text;

            // Display the current calculation back to the user
            textBox1.Text = currentCalculation;
        }

        private void button_equals_Click(object sender, EventArgs e)
        {
            // Erkennt das Pi im currentCalculation und setzt das Witzt ein.
            if(currentCalculation.Contains("π"))
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

        private void textBox_history_TextChanged(object sender, EventArgs e)
        {
            /* 
             * Shows the last calulation in Textbox
             * Is called in button_equals_Click 
            */
        }


    }
}