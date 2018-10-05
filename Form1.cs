using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace _2DArray
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            int[,] quiz = new int[4, 5];
            string[] quizName = new string[5];
            string[] student = new string[4];
            double[] weights = new double[5];

            int[] studentTotal = new int[4];
            int[] quizTotal = new int[5];

            StreamReader reader = new StreamReader("data.txt");

            for(int row = 1; row <= 3; row++)
            {
                for(int col = 1; col <= 4; col++)
                {
                    quiz[row, col] = int.Parse(reader.ReadLine());
                }
            }

            for (int r = 1; r <= 3; r++)
            {
                student[r] = reader.ReadLine();
            }

            for(int c = 1; c <= 4; c++)
            {
                quizName[c] = reader.ReadLine();
            }

            for(int r = 1; r <= 4; r++)
            {
                weights[r] = double.Parse(reader.ReadLine());
            }
            reader.Close();

            txtDisplay.Clear();

            txtDisplay.Text = "\t\tQuiz Score Analysis" + Environment.NewLine + Environment.NewLine;
            txtDisplay.Text += "Original Data" + Environment.NewLine;
            txtDisplay.Text += "\t";

            for (int c = 1; c <= 4; c++)
            {
                txtDisplay.Text += quizName[c] + "\t";
            }
            txtDisplay.Text += Environment.NewLine;

            for (int r = 1; r <= 3; r++)
            {
                txtDisplay.Text += student[r] + "\t";
                for (int c = 1; c <= 4; c++)
                {
                    txtDisplay.Text += quiz[r, c] + "\t";
                }
                txtDisplay.Text += Environment.NewLine;
            }
            txtDisplay.Text += Environment.NewLine;
            txtDisplay.Text += "Results over 80"+Environment.NewLine;


            for(int r = 1; r <= 3; r++)
            {
                for(int c = 1; c <= 4; c++)
                {
                    if (quiz[r, c] > 80)
                    {
                        txtDisplay.Text += student[r] + "\t" + quizName[c] +"\t"+ quiz[r, c]+Environment.NewLine;
                    }
                    
                }
                
            }
            txtDisplay.Text += Environment.NewLine;

            int highestMark = 0;
            int posX = 0;
            int posY = 0;
            for(int r = 1; r <= 3; r++)
            {
                for (int c = 1; c <= 4; c++)
                {
                    if (quiz[r, c] > highestMark)
                    {
                        highestMark = quiz[r, c];
                        posX = r;
                        posY = c;
                    }
                }
            }
            txtDisplay.Text += "The higest mark is " + highestMark + " obtained by student " + student[posX] + " in " + quizName[posY];
            txtDisplay.Text += Environment.NewLine + Environment.NewLine;
            txtDisplay.Text += "Student totals are" + Environment.NewLine;

            

            for(int r = 1; r <= 3; r++)
            {
                for(int c = 1; c <= 4; c++)
                {
                    studentTotal[r] += quiz[r, c];
                }
            }
            for(int r = 1; r <= 3; r++)
            {
                txtDisplay.Text += student[r] + "\t" + studentTotal[r]+Environment.NewLine;
            }

            txtDisplay.Text += Environment.NewLine ;

            int highestTotal = 0;
            int pX = 0;

            for(int r = 1; r <= 3; r++)
            {
                if (studentTotal[r] > highestTotal)
                {
                    highestTotal = studentTotal[r];
                    pX = r;
                }
            }

            txtDisplay.Text += "Highest total is " + highestTotal + " obtained by student " + student[pX];
            txtDisplay.Text += Environment.NewLine+Environment.NewLine;
            txtDisplay.Text += "Quiz totals are" + Environment.NewLine;
            for(int r = 1; r <= 3; r++)
            {
                for (int c = 1; c <= 4; c++)
                {
                    quizTotal[c] += quiz[r, c];
                }

            }
            for(int c = 1; c <= 4; c++)
            {
                txtDisplay.Text += quizName[c] + "\t" + quizTotal[c] + Environment.NewLine;
            }
            txtDisplay.Text += Environment.NewLine;
            txtDisplay.Text += "Overall average for each quiz" + Environment.NewLine;

            double[] quizAverage = new double[5];

            for(int c=1;c<=4; c++)
            {
                quizAverage[c] += (double)quizTotal[c] / 3;
            }

            for(int c = 1; c <= 4; c++)
            {
                txtDisplay.Text += quizAverage[c].ToString("n2") + "\t" + Environment.NewLine;
            }
            txtDisplay.Text += Environment.NewLine;

            int[] lowestMark = new int[5];
            int[] lowPos = new int[5];

            for(int c = 1; c <= 4; c++)
            {
                lowestMark[c] = 100;
                for(int r = 1; r <= 3; r++)
                {
                    if (quiz[r, c] < lowestMark[c])
                    {
                        lowestMark[c] = quiz[r, c];
                        lowPos[c] = r;
                    }
                }
            }

            for(int c = 1; c <= 4; c++)
            {
                txtDisplay.Text += "For " + quizName[c] + " the lowest mark was " + lowestMark[c] + " obtained by " + student[lowPos[c]]+Environment.NewLine;

            }

            double[] finalMark = new double[4];

            for(int r = 1; r <= 3; r++)
            {
                for(int c = 1; c <= 4; c++)
                {
                    finalMark[r] += (quiz[r, c] * weights[c]) / 100;
                }
            }
            txtDisplay.Text += Environment.NewLine;
            txtDisplay.Text += "Student final weighted marks" + Environment.NewLine;

            for(int r = 1; r <= 3; r++)
            {
                txtDisplay.Text += student[r] + "\t" + finalMark[r] + Environment.NewLine;
            }


        }
    }
}
