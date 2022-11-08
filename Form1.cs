using System.Data;
using System.Diagnostics;
using System.Windows.Forms;

namespace Taschernrechner
{
    public partial class Form1 : Form
    {
        // Creates an empty string as input.
        string currentCalculation = "";


        private void consoletest(/*Input-TEST*/)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(currentCalculation);
        }



        public Form1()
        {
            InitializeComponent();
            button_pi.Visible = false;
            button_sqrt.Visible = false;
            buttonSin.Visible = false;
            buttonCos.Visible = false;
            buttonTan.Visible = false;
            buttonRickRoll.Visible = false;
            this.Height = 430;
            this.Width = 315;

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
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

        
        private void buttonPi_Click(object sender, EventArgs e)
        {   
            // PI-Code 
            // This adds the number or operator to the string calculation
            currentCalculation += "(3.14159)";

            // Display the current calculation back to the user
            textBox1.Text = currentCalculation;
        }

        private void button_equals_Click(object sender, EventArgs e)
        {
            // Prüft die Division durch 0 regel und meldet den benutzer
            if (currentCalculation.Contains("/0"))
            {
                MessageBox.Show("0 kann man nicht dividieren", "Herr Taschenrechner");
            }
            // Wurzel Berechner 
            else if (currentCalculation.Contains("√"))
            {
                consoletest();
                
                int SqrtIndex = currentCalculation.IndexOf('√');
                
                string SqrtSubString = currentCalculation.Substring(SqrtIndex + 1);
                
                Console.WriteLine(SqrtSubString);

                double sqrt = Convert.ToDouble(SqrtSubString);
                double MathSqrt = Math.Sqrt(sqrt);
                String currentsqrt = Convert.ToString(MathSqrt);

                currentCalculation = currentCalculation.Remove(SqrtIndex, 1).Remove(SqrtIndex, 1) + currentsqrt.ToString().Replace(",",".");
                consoletest();
                textBox1.Text = currentCalculation;

            }
            else if (checkBox_Open.Checked == true)
            {
                if (currentCalculation.Contains("sin"))
                {
                    currentCalculation = currentCalculation.Remove(0, 3);
                    double sin = Convert.ToDouble(currentCalculation);
                    //Math.Sin Radian und nicht Degree benutz muss man es in Degree um rechnen X*pi/180
                    sin = Math.Sin(sin*Math.PI / 180);
                    currentCalculation = Convert.ToString(sin);
                    textBoxSin.Text = currentCalculation.ToString().Replace(",", ".");
                    currentCalculation = textBox1.Text;
                    textBox_history.Text = "";
                    textBox_history.Text = textBox1.Text;

                }
                else if (currentCalculation.Contains("cos"))
                {
                    currentCalculation = currentCalculation.Remove(0, 3);
                    double cos = Convert.ToDouble(currentCalculation);
                    //Math.Cos Radian und nicht Degree benutz muss man es in Degree um rechnen X*pi/180
                    cos = Math.Cos(cos * Math.PI / 180);
                    currentCalculation = Convert.ToString(cos);
                    textBoxCos.Text = currentCalculation.ToString().Replace(",", ".");
                    currentCalculation = textBox1.Text;
                    textBox_history.Text = "";
                    textBox_history.Text = textBox1.Text;

                }
                else if (currentCalculation.Contains("tan"))
                {
                    currentCalculation = currentCalculation.Remove(0, 3);
                    double tan = Convert.ToDouble(currentCalculation);
                    //Math.Tan Radian und nicht Degree benutz muss man es in Degree um rechnen X*pi/180
                    tan = Math.Tan(tan * Math.PI / 180);
                    currentCalculation = Convert.ToString(tan);
                    textBoxTan.Text = currentCalculation.ToString().Replace(",", ".");
                    currentCalculation = textBox1.Text;
                    textBox_history.Text = "";
                    textBox_history.Text = textBox1.Text;

                }
            }
            else
            {
               //Berchnet und zeig die Gleichung an.
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
                    Console.WriteLine(ex);
                    MessageBox.Show("ERROR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void button_add_Click(object sender, EventArgs e)
        {
            currentCalculation += textBox_history.Text;

            textBox1.Text = currentCalculation;
        }

        private void checkBox_Open_CheckedChanged(object sender, EventArgs e)
        {
            //Versteckt Buttons 
            if (button_pi.Visible == false)
            {
                button_pi.Visible = true;
                button_sqrt.Visible = true;
                buttonSin.Visible = true;
                buttonCos.Visible = true;
                buttonTan.Visible = true;
                buttonRickRoll.Visible = true;

                this.Height = 430;
                this.Width = 500;
            }
            else
            {
                button_pi.Visible = false;
                button_sqrt.Visible = false;
                buttonSin.Visible = false;
                buttonCos.Visible = false;
                buttonTan.Visible = false;
                buttonRickRoll.Visible = false;
                this.Height = 430;
                this.Width = 315;
            }

        }

        private void buttonRickRoll_Click(object sender, EventArgs e)
        {
            var ps = new ProcessStartInfo("https://www.youtube.com/watch?v=-AXetJvTfU0")
            {
                UseShellExecute = true,
                Verb = "open"
            };

            Process.Start(ps);

            textBox1.Text = "Sorry :D";

        }
    }
}
