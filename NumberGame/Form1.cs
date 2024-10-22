using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NumberGame
{
    public partial class Form1 : Form
    {
        private List<int> numbersToShow = new List<int>();
        private int currentIndex = 0;
        private bool isGameRunning = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!isGameRunning)
            {
                StartGame();
                isGameRunning = true;
            }
        }

        private void StartGame()
        {
            numbersToShow.Clear();
            GenerateNumbersToShow();
            ShowNumbers();
            currentIndex = 0;
        }

        private void GenerateNumbersToShow()
        {
            Random random = new Random();
            for (int i = 1; i <= 5; i++)
            {
                numbersToShow.Add(random.Next(1, 10));
            }
        }

        private void ShowNumbers()
        {
            timer1.Interval = 1000;
            timer1.Tick += Timer_Tick;
            timer1.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (currentIndex < numbersToShow.Count)
            {
                labelNumber.Visible = true;
                labelNumber.Text = numbersToShow[currentIndex].ToString();
                currentIndex++;
            }
            else
            {
                timer1.Stop();
                labelNumber.Text = "Good Luck!";
            }

            Timer hideTimer = new Timer();
            hideTimer.Interval = 500;
            hideTimer.Tick += (s, args) => { labelNumber.Text = ""; hideTimer.Stop(); };
            hideTimer.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string input = textBox.Text.Trim();
            string[] inputNumbers = input.Split(' ');

            if (inputNumbers.Length != numbersToShow.Count)
            {
                MessageBox.Show("Please enter 5 numbers with space between them!");
                return;
            }

            bool isCorrect = true;
            for (int i = 0; i < numbersToShow.Count; i++)
            {
                int guessedNumber;
                if (!int.TryParse(inputNumbers[i], out guessedNumber))
                {
                    MessageBox.Show("Please enter only numbers!");
                    return;
                }

                if (guessedNumber != numbersToShow[i])
                {
                    isCorrect = false;
                    break;
                }
            }
            if (isCorrect)
            {
                MessageBox.Show("Congratulations! You got all the numbers!");
                this.Close();
            }
            else
            {
                string correctNumbersText = string.Join(" ", numbersToShow);
                MessageBox.Show($"You lose! The numbers were: {correctNumbersText}");
                this.Close();
            }
        }
    }
}
