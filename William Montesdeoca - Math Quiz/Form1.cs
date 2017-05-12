using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace William_Montesdeoca___Math_Quiz
{
    public partial class Form1 : Form
    {
        // Declare variables
        int timeLeft, add1, add2, sub1, sub2, times1, times2, frac1, frac2;

        Random randomizer = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Pre set the values before the click of the start button
            fecha.Text = DateTime.Now.ToShortDateString();
            timeLabel.Text = "30 seconds";
            timer1.Enabled = true;
            timer1.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Decrement the timer until problems are solved
            if (timeLeft > 0)
            {
                timeLeft--;
                timeLabel.Text = timeLeft.ToString() + " seconds";

                // Once the problems are solved then stop the timer and display the JOLLY news
                if ((add1 + add2 == addition.Value) && (sub1 - sub2 == subtract.Value) && (times1 * times2 == multiply.Value) &&
                (frac1 / frac2 == division.Value))
                {
                    timer1.Stop();
                    MessageBox.Show("Congratulations! You successfully answered all the problems correctly.");
                    startButton.Enabled = true;
                }
            }
            // Stop the timer when it reaches 0 and display the BAD message
            else
            {
                timer1.Stop();
                timeLabel.Text = "Times Up!";
                MessageBox.Show("Sorry you ran out of time! Please try again.");
                startButton.Enabled = true;
            }
        }

        private void startButton_Click_1(object sender, EventArgs e)
        {
            // Run when the start button is pressed
            startQuiz();
            timeLeft = 30;
            timeLabel.Text = "30 seconds";
            timer1.Start();
            startButton.Enabled = false;
        }

        public void startQuiz()
        {
            // Randomize adding integers
            add1 = randomizer.Next(50) + 1;
            sum1.Text = add1.ToString();

            add2 = randomizer.Next(50) + 1;
            sum2.Text = add2.ToString();

            // Randomize substrating integers
            sub1 = randomizer.Next(1, 100) + 1;
            minus1.Text = sub1.ToString();

            sub2 = randomizer.Next(1, sub1) + 1;
            minus2.Text = sub2.ToString();

            // Randomize multiplication integers
            times1 = randomizer.Next(2, 10);
            mult1.Text = times1.ToString();

            times2 = randomizer.Next(2, times1);
            mult2.Text = times2.ToString();

            // Randomize division integers
            frac1 = randomizer.Next(2, 100);
            frac2 = randomizer.Next(2, frac1);

            // Randomize forever until numerator is evenly 
            // divisible by the denominator
            for (;;)
            {
                if (frac1 % frac2 == 0)
                {
                    div1.Text = frac1.ToString();
                    div2.Text = frac2.ToString();
                    break;
                }
                else
                {
                    frac1 = randomizer.Next(2, 100);
                    frac2 = randomizer.Next(2, frac1);
                }
            }
        }
    }
}
