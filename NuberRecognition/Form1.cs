using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NuberRecognition
{
    public partial class Form1 : Form
    {
        #region Learnin Neural Net
        List<string> numberMasks = new List<string>()
        {
        "111101101101111",//0 
        "001001001001001",//1 
        "111001111100111",//2 
        "111001111001111",//3 
        "101101111001001",//4 
        "111100111001111",//5 
        "111100111101111",//6 
        "111001001001001",//7 
        "111101111101111",//8 
        "111101111001111" //9 
        };
        const int countNumbers = 10;
        const int countInputs = 15; 
        double[,] weights = new double[countNumbers,countInputs];
        Random rnd = new Random(DateTime.Now.Millisecond);

        double ActivateFunction(double net)
        {
            return 1.0 / (1 + Math.Exp(-1 * net));
            //return net > 7 ? 1 : 0;    
        }

        double CalculateNet(string number, double[,] weights, int indexWeight)
        {
            double net = 0;

            for (int i = 0; i < countInputs; i++)
            {
                net += (Convert.ToInt32(number[i]) - 48) * weights[indexWeight,i];
            }

            return net;
        }

        double CheckNumber(string number, double[,] weights, int indexWeight)
        {
            return ActivateFunction(CalculateNet(number, weights, indexWeight));
        }

        void IncreaseWeight(string number, double[,] weights, int indexWeight)
        {
            for (int i = 0; i < countInputs; i++)
            {
                if (number[i] == '1')
                { weights[indexWeight, i] += 1; }
            }
        }
        void DecreaseWeight(string number, double[,] weights, int indexWeight)
        {
            for (int i = 0; i < countInputs; i++)
            {
                if (number[i] == '1')
                { weights[indexWeight, i] -= 1; }
            }
        }

        void PrintWeightMap()
        {
            for (int i = 0; i < countNumbers; i++)
            {
                for (int j = 0; j < countInputs; j++)
                {
                    if (j>0 && j % 3 == 0)
                    {
                        richTextBoxWeightMap.Text += "\n";
                    }
                    richTextBoxWeightMap.Text += String.Format("{0,3}", weights[i, j]);
                    
                }
                richTextBoxWeightMap.Text += "\n----------\n";
            }
        }


        void LearningNeuralNet()
        {
            int currentNumber;
            for (int i = 0; i < countNumbers; i++)
            {
                this.Invoke
                    (
                    new MethodInvoker
                    (
                        ()=>
                        {
                            richTextBoxLog.Text += String.Format("старт обучение цифре {0}\n",i);
                        }
                    )
                    );

                for (int j = 0; j < 100000; j++)
                {
                    currentNumber = rnd.Next(0, 10);
                    
                    if (currentNumber != i)
                    {
                        if (CheckNumber(numberMasks[currentNumber],weights,i) > 0.8 /*== 1*/)
                        {
                            DecreaseWeight(numberMasks[currentNumber],weights, i);
                        }
                    }
                    else
                    {
                        if (CheckNumber(numberMasks[currentNumber], weights, i) <= 0.8 /*== 0*/)
                        {
                            IncreaseWeight(numberMasks[currentNumber], weights, i);
                        }
                    }
                }

                this.Invoke
                    (
                    new MethodInvoker
                    (
                        () =>
                        {
                            richTextBoxLog.Text += String.Format("конец обучение цифре {0}\n", i);
                        }
                    )
                    );

            }
            
            this.Invoke
                (
                    new MethodInvoker(PrintWeightMap)
                );
            MessageBox.Show("Обучение окончено");
        }
        #endregion

        #region Testing Neural Net

        const int maskRows = 5;
        const int maskCells = 3;
        const int cellSize = 80;
        int[,] numberMask = new int[maskRows, maskCells];

        void TestingNeuralNet()
        {
            string mask = String.Empty;
            for (int i = 0; i < maskRows; i++)
            {
                for (int j = 0; j < maskCells; j++)
                {
                    mask += numberMask[i, j].ToString();
                }
            }

            richTextBoxAnswers.Clear();
            double actf = 0;
            int number = -1;
            for (int i = 0; i < countNumbers; i++)
            {
                double curActf = CheckNumber(mask, weights, i);
                if (curActf > actf)
                {
                    number = i;
                    actf = curActf;
                }
                richTextBoxAnswers.Text += String.Format("это {0} ? = {1:F3}\n", i, curActf);
            }
            if (number != -1)
            { richTextBoxAnswers.Text += String.Format("\n\nЭто {0}!", number); }
            else
            { richTextBoxAnswers.Text += String.Format("\n\nНеизвестно"); }

        }
        #endregion

        public Form1()
        {
            
            InitializeComponent();
        }

        private void buttonTeach_Click(object sender, EventArgs e)
        {
            Array.Clear(weights, 0, countInputs * countNumbers);

            Task t = Task.Factory.StartNew(LearningNeuralNet);
        }

        private void pictureBoxInputs_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < maskRows; i++)
            {
                for (int j = 0; j < maskCells; j++)
                {
                    if (numberMask[i, j] == 0)
                    {
                        e.Graphics.FillRectangle(Brushes.White, j * cellSize, i * cellSize, cellSize, cellSize);
                    }
                    else
                    {
                        e.Graphics.FillRectangle(Brushes.Yellow, j * cellSize, i * cellSize, cellSize, cellSize);
                    }
                    e.Graphics.DrawRectangle(Pens.Black, j * cellSize, i * cellSize, cellSize, cellSize);
                }
            }
        }

        private void pictureBoxInputs_MouseDown(object sender, MouseEventArgs e)
        {
            int i = e.Y / cellSize;
            int j = e.X / cellSize;

            if (numberMask[i, j] == 0)
            {
                numberMask[i, j] = 1;
            }
            else
            {
                numberMask[i, j] = 0;
            }

            pictureBoxInputs.Refresh();

            TestingNeuralNet();
        }
    }
}
