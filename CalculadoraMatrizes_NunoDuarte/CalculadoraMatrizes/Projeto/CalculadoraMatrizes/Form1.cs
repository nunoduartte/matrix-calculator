using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CalculadoraMatrizes
{
    public partial class Form1 : Form
    {
        private TextBox[,] Matriz1;
        private TextBox[,] Matriz2;
        private TextBox[,] MatrizResultante;
        private float determinante;

        int linha1, coluna1;
        int linha2, coluna2;
        public Form1()
        {
            InitializeComponent();
        }

        #region CriarMatriz
        private void btnCriarMatriz_Click(object sender, EventArgs e)
        {
            groupBoxMatriz1.Controls.Clear();

            /*if (textBox1.Text.Length == 0)
            {
                MessageBox.Show("A linha da matriz 1 é nula.", "Erro");
                return;
            }
            if (textBox3.Text == null)
            {
                MessageBox.Show("A coluna da matriz 1 é nula.", "Erro");
                return;
            }
            linha1 = Convert.ToInt32(textBox1.Text);
            coluna1 = Convert.ToInt32(textBox3.Text);*/
            if (!int.TryParse(textBox1.Text, out linha1))
            {
                MessageBox.Show("A linha da matriz 1 é nula.", "Erro");
                return;
            } 
            if (!int.TryParse(textBox3.Text, out coluna1))
            {
                MessageBox.Show("A coluna da matriz 1 é nula.", "Erro");
                return;
            }

            Matriz1 = new TextBox[linha1, coluna1];
            int TamanhoText = groupBoxMatriz1.Width / coluna1;
            for (int x = 0; x < Matriz1.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz1.GetLength(1); y++)
                {
                    Matriz1[x, y] = new TextBox();
                    Matriz1[x, y].Text = "0";
                    Matriz1[x, y].Top = (x * Matriz1[x, y].Height) + 20;
                    Matriz1[x, y].Left = y * TamanhoText + 6;
                    Matriz1[x, y].Width = TamanhoText;
                    groupBoxMatriz1.Controls.Add(Matriz1[x, y]);
                }
            }
        }
        private void btnCriarMatriz2_Click(object sender, EventArgs e)
        {
            groupBoxMatriz2.Controls.Clear();
                /*if (textBox2.Text == null)
                {
                    MessageBox.Show("A linha da matriz 2 é nula.", "Erro");
                    return;
                }

                if (textBox4.Text == null)
                {
                    MessageBox.Show("A coluna da matriz 2 é nula.", "Erro");
                    return;
                }
            linha2 = Convert.ToInt32(textBox2.Text);
            coluna2 = Convert.ToInt32(textBox4.Text);*/
            if (!int.TryParse(textBox2.Text, out linha2))
            {
                MessageBox.Show("A linha da matriz 2 é nula.", "Erro");
                return;
            }
            if (!int.TryParse(textBox4.Text, out coluna2))
            {
                MessageBox.Show("A coluna da matriz 2 é nula.", "Erro");
                return;
            }
            int TamanhoText = groupBoxMatriz2.Width / coluna2;
            Matriz2 = new TextBox[linha2, coluna2];
            TamanhoText = groupBoxMatriz2.Width / coluna2;
            for (int x = 0; x < Matriz2.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz2.GetLength(1); y++)
                {
                    Matriz2[x, y] = new TextBox();
                    Matriz2[x, y].Text = "0";
                    Matriz2[x, y].Top = (x * Matriz2[x, y].Height) + 20;
                    Matriz2[x, y].Left = y * TamanhoText + 6;
                    Matriz2[x, y].Width = TamanhoText;
                    groupBoxMatriz2.Controls.Add(Matriz2[x, y]);
                }
            }
        }
        #endregion
        #region Operações entre Matrizes
        private void btnSomar_Click(object sender, EventArgs e)
        {
            if (Matriz1 == null || Matriz2 == null)
            {
                MessageBox.Show("Matriz nula !", "Error - Matriz");
                return;
            }
            float[,] tempMatriz1 = new float[Matriz1.GetLength(0), Matriz1.GetLength(1)];
            float[,] tempMatriz2 = new float[Matriz2.GetLength(0), Matriz2.GetLength(1)];
            if (tempMatriz1.GetLength(0) != tempMatriz2.GetLength(0) || tempMatriz1.GetLength(1) != tempMatriz2.GetLength(1))
            {
                MessageBox.Show("So e possivel a soma de matrizes de mesma ordem !", "Erro - Soma Matrizes");
                return;
            }

            for (int x = 0; x < Matriz1.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz1.GetLength(1); y++)
                {
                    float n = 0;
                    float.TryParse(Matriz1[x, y].Text, out n);
                    tempMatriz1[x, y] = n;
                    //tempMatriz1[x, y] = Convert.ToInt32(Matriz1[x, y].Text);
                }
            } 
            for (int x = 0; x < Matriz2.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz2.GetLength(1); y++)
                {
                    float n = 0;
                    float.TryParse(Matriz2[x, y].Text, out n);
                    tempMatriz2[x, y] = n;
                    //tempMatriz2[x, y] = Convert.ToInt32(Matriz2[x, y].Text);
                }
            }

            float[,] tempMatrizResultante = CalculosMatrizes.SomarMatrizes(tempMatriz1, tempMatriz2);
            MatrizResultante = new TextBox[tempMatrizResultante.GetLength(0), tempMatrizResultante.GetLength(1)];
            int TamanhoText = groupBoxMatrizResultante.Width / MatrizResultante.GetLength(1);
            groupBoxMatrizResultante.Controls.Clear();
            for (int x = 0; x < MatrizResultante.GetLength(0); x++)
            {
                for (int y = 0; y < MatrizResultante.GetLength(1); y++)
                {
                    MatrizResultante[x, y] = new TextBox();
                    MatrizResultante[x, y].Text = tempMatrizResultante[x, y].ToString();
                    MatrizResultante[x, y].Top = (x * MatrizResultante[x, y].Height) + 20;
                    MatrizResultante[x, y].Left = y * TamanhoText + 6;
                    MatrizResultante[x, y].Width = TamanhoText;
                    groupBoxMatrizResultante.Controls.Add(MatrizResultante[x, y]);
                }
            }

        }
        private void btnDiminuir_Click(object sender, EventArgs e)
        {
            if (Matriz1 == null || Matriz2 == null)
            {
                MessageBox.Show("Matriz nula !", "Error - Matriz");
                return;
            }
            float[,] tempMatriz1 = new float[Matriz1.GetLength(0), Matriz1.GetLength(1)];
            float[,] tempMatriz2 = new float[Matriz2.GetLength(0), Matriz2.GetLength(1)];
            if (tempMatriz1.GetLength(0) != tempMatriz2.GetLength(0) || tempMatriz1.GetLength(1) != tempMatriz2.GetLength(1))
            {
                MessageBox.Show("So e possivel a subtracao de matrizes de mesma ordem !", "Erro - Soma Matrizes");
                return;
            }

            for (int x = 0; x < Matriz1.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz1.GetLength(1); y++)
                {
                    float n = 0;
                    float.TryParse(Matriz1[x, y].Text, out n);
                    tempMatriz1[x, y] = n;
                    //tempMatriz1[x, y] = Convert.ToInt32(Matriz1[x, y].Text);
                }
            }
            for (int x = 0; x < Matriz2.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz2.GetLength(1); y++)
                {
                    float n = 0;
                    float.TryParse(Matriz2[x, y].Text, out n);
                    tempMatriz2[x, y] = n;
                    //tempMatriz2[x, y] = Convert.ToInt32(Matriz2[x, y].Text);
                }
            }

            float[,] tempMatrizResultante = CalculosMatrizes.SubtrairMatrizes(tempMatriz1, tempMatriz2);
            MatrizResultante = new TextBox[tempMatrizResultante.GetLength(0), tempMatrizResultante.GetLength(1)];
            int TamanhoText = groupBoxMatrizResultante.Width / MatrizResultante.GetLength(1);
            groupBoxMatrizResultante.Controls.Clear();
            for (int x = 0; x < MatrizResultante.GetLength(0); x++)
            {
                for (int y = 0; y < MatrizResultante.GetLength(1); y++)
                {
                    MatrizResultante[x, y] = new TextBox();
                    MatrizResultante[x, y].Text = tempMatrizResultante[x, y].ToString();
                    MatrizResultante[x, y].Top = (x * MatrizResultante[x, y].Height) + 20;
                    MatrizResultante[x, y].Left = y * TamanhoText + 6;
                    MatrizResultante[x, y].Width = TamanhoText;
                    groupBoxMatrizResultante.Controls.Add(MatrizResultante[x, y]);
                }
            }
        }
        private void btnMultiplicar_Click(object sender, EventArgs e)
        {
            if (Matriz1 == null || Matriz2 == null)
            {
                MessageBox.Show("Matriz nula !", "Error - Matriz");
                return;
            }
            float[,] tempMatriz1 = new float[Matriz1.GetLength(0), Matriz1.GetLength(1)];
            float[,] tempMatriz2 = new float[Matriz2.GetLength(0), Matriz2.GetLength(1)];
            if (tempMatriz1.GetLength(1) != tempMatriz2.GetLength(0))
            {
                MessageBox.Show("So e possivel a multiplicacao de matrizes onde a coluna da matriz 1 e igual a linha da matriz 2  !", "Erro - Multiplicacao Matrizes");
                return;
            }

            for (int x = 0; x < Matriz1.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz1.GetLength(1); y++)
                {
                    float n = 0;
                    float.TryParse(Matriz1[x, y].Text, out n);
                    tempMatriz1[x, y] = n;
                    //tempMatriz1[x, y] = Convert.ToInt32(Matriz1[x, y].Text);
                }
            }
            for (int x = 0; x < Matriz2.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz2.GetLength(1); y++)
                {
                    float n = 0;
                    float.TryParse(Matriz2[x, y].Text, out n);
                    tempMatriz2[x, y] = n;
                    //tempMatriz2[x, y] = Convert.ToInt32(Matriz2[x, y].Text);
                }
            }

            float[,] tempMatrizResultante = CalculosMatrizes.MultiplicarMatrizes(tempMatriz1, tempMatriz2);
            MatrizResultante = new TextBox[tempMatrizResultante.GetLength(0), tempMatrizResultante.GetLength(1)];
            int TamanhoText = groupBoxMatrizResultante.Width / MatrizResultante.GetLength(1);
            groupBoxMatrizResultante.Controls.Clear();
            for (int x = 0; x < MatrizResultante.GetLength(0); x++)
            {
                for (int y = 0; y < MatrizResultante.GetLength(1); y++)
                {
                    MatrizResultante[x, y] = new TextBox();
                    MatrizResultante[x, y].Text = tempMatrizResultante[x, y].ToString();
                    MatrizResultante[x, y].Top = (x * MatrizResultante[x, y].Height) + 20;
                    MatrizResultante[x, y].Left = y * TamanhoText + 6;
                    MatrizResultante[x, y].Width = TamanhoText;
                    groupBoxMatrizResultante.Controls.Add(MatrizResultante[x, y]);
                }
            }
        }
        #endregion
        #region Matriz Resultante
        private void btnGerarOposta_Click(object sender, EventArgs e)
        {
            if (MatrizResultante == null)
            {
                MessageBox.Show("Matriz nula !", "Error - Matriz");
                return;
            }
            float[,] tempResultante = new float[MatrizResultante.GetLength(0), MatrizResultante.GetLength(1)];

            for (int x = 0; x < MatrizResultante.GetLength(0); x++)
            {
                for (int y = 0; y < MatrizResultante.GetLength(1); y++)
                {
                    float n = 0;
                    float.TryParse(MatrizResultante[x, y].Text, out n);
                    tempResultante[x, y] = n;
                    //tempResultante[x, y] = Convert.ToInt32(MatrizResultante[x, y].Text);
                }
            }

            float[,] tempMatrizResultante = CalculosMatrizes.GerarOposta(tempResultante);
            int TamanhoText = groupBoxMatrizResultante.Width / MatrizResultante.GetLength(1);
            for (int x = 0; x < MatrizResultante.GetLength(0); x++)
            {
                for (int y = 0; y < MatrizResultante.GetLength(1); y++)
                {
                    MatrizResultante[x, y].Text = tempMatrizResultante[x, y].ToString();
                }
            }
        }
        private void btnGerarTransposta_Click(object sender, EventArgs e)
        {
            if (MatrizResultante == null)
            {
                MessageBox.Show("Matriz nula !", "Error - Matriz");
                return;
            }
            float[,] tempResultante = new float[MatrizResultante.GetLength(0), MatrizResultante.GetLength(1)];

            for (int x = 0; x < MatrizResultante.GetLength(0); x++)
            {
                for (int y = 0; y < MatrizResultante.GetLength(1); y++)
                {
                    float n = 0;
                    float.TryParse(MatrizResultante[x, y].Text, out n);
                    tempResultante[x, y] = n;
                    //tempResultante[x, y] = Convert.ToInt32(MatrizResultante[x, y].Text);
                }
            }

            float[,] tempMatrizResultante = CalculosMatrizes.GerarTransposta(tempResultante);
            int TamanhoText = groupBoxMatrizResultante.Width / MatrizResultante.GetLength(1);
            MatrizResultante = new TextBox[tempMatrizResultante.GetLength(0), tempMatrizResultante.GetLength(1)];
            groupBoxMatrizResultante.Controls.Clear();
            for (int x = 0; x < MatrizResultante.GetLength(0); x++)
            {
                for (int y = 0; y < MatrizResultante.GetLength(1); y++)
                {   
                    MatrizResultante[x, y] = new TextBox();
                    MatrizResultante[x, y].Text = tempMatrizResultante[x, y].ToString();
                    MatrizResultante[x, y].Top = (x * MatrizResultante[x, y].Height) + 20;
                    MatrizResultante[x, y].Left = y * TamanhoText + 6;
                    MatrizResultante[x, y].Width = TamanhoText;
                    groupBoxMatrizResultante.Controls.Add(MatrizResultante[x, y]);
                }
            }
        }
        private void btnGerarDeterminante_Click(object sender, EventArgs e)
        {
            if (MatrizResultante == null)
            {
                MessageBox.Show("Matriz nula !", "Error - Matriz");
                return;
            }
            float[,] tempResultante = new float[MatrizResultante.GetLength(0), MatrizResultante.GetLength(1)];

            for (int x = 0; x < MatrizResultante.GetLength(0); x++)
            {
                for (int y = 0; y < MatrizResultante.GetLength(1); y++)
                {
                    float n = 0;
                    float.TryParse(MatrizResultante[x, y].Text, out n);
                    tempResultante[x, y] = n;
                    //tempResultante[x, y] = Convert.ToInt32(MatrizResultante[x, y].Text);
                }
            }
                if (tempResultante.GetLength(0) == 2 && tempResultante.GetLength(1) == 2)
                {
                    determinante = CalculosMatrizes.GerarDeterminante2x2(tempResultante);
                    MessageBox.Show("" + determinante, "Determinante...");
                }
                else if (tempResultante.GetLength(0) == 3 && tempResultante.GetLength(1) == 3)
                {
                    determinante = CalculosMatrizes.GerarDeterminante3x3(tempResultante);
                    MessageBox.Show("" + determinante, "Determinante...");
                }
                else
                {
                    MessageBox.Show("Nao e possivel gerar determinante !", "Error - Matriz invalida ");
                }
        }
        private void btnGerarInversa_Click(object sender, EventArgs e)
        {
            if (MatrizResultante == null)
            {
                MessageBox.Show("Matriz nula !", "Error - Matriz");
                return;
            }
            float[,] tempResultante = new float[MatrizResultante.GetLength(0), MatrizResultante.GetLength(1)];
            float[,] matrizAdjunta = new float[MatrizResultante.GetLength(0), MatrizResultante.GetLength(1)];
            float[,] matrizCofatora = new float[MatrizResultante.GetLength(0), MatrizResultante.GetLength(1)];
            float determinante = 0; 
            if (tempResultante.GetLength(0) != 2 || tempResultante.GetLength(1) != 2)
            {
                if (tempResultante.GetLength(0) != 3 || tempResultante.GetLength(1) != 3)
                {
                    MessageBox.Show("Matriz invalida !", "Error - Matriz");
                    return;
                }
            }

            for (int x = 0; x < MatrizResultante.GetLength(0); x++)
            {
                for (int y = 0; y < MatrizResultante.GetLength(1); y++)
                {
                    float n = 0;
                    float.TryParse(MatrizResultante[x, y].Text, out n);
                    tempResultante[x, y] = n;
                    //tempResultante[x, y] = Convert.ToInt32(MatrizResultante[x, y].Text);
                }
            }
            /*Matriz Adjunta(A) = Matriz Transposta(Matriz dos cofatores(A))
            Matriz Inversa(A) = (1/ Determinante(A)) * Matriz Adjunta(A)*/
            if (tempResultante.GetLength(0) == 2 && tempResultante.GetLength(1) == 2)
            {
                matrizCofatora = CalculosMatrizes.GerarCofatora2x2(tempResultante);
                matrizAdjunta = CalculosMatrizes.GerarTransposta(matrizCofatora);
                determinante = CalculosMatrizes.GerarDeterminante2x2(tempResultante);
            }
            else if (tempResultante.GetLength(0) == 3 && tempResultante.GetLength(1) == 3)
            {
                matrizCofatora = CalculosMatrizes.GerarCofatora3x3(tempResultante);
                matrizAdjunta = CalculosMatrizes.GerarTransposta(matrizCofatora);
                determinante = CalculosMatrizes.GerarDeterminante3x3(tempResultante);
            }
            else
            {
                MessageBox.Show("Matriz invalida 2!", "Error - Matriz");
                return;
            }
            if (determinante == 0)
            {
                MessageBox.Show("Matriz invalida, determinante igual a 0 !", "Error - Matriz");
                return;
            }
            float[,] tempMatrizResultante = CalculosMatrizes.GerarInversa(determinante, matrizAdjunta);
            int TamanhoText = groupBoxMatrizResultante.Width / MatrizResultante.GetLength(1);
            for (int x = 0; x < MatrizResultante.GetLength(0); x++)
            {
                for (int y = 0; y < MatrizResultante.GetLength(1); y++)
                {
                    MatrizResultante[x, y].Text = tempMatrizResultante[x, y].ToString();
                }
            }
        }
        #endregion
        #region Matriz 1
        private void btnGerarOpostaM1_Click(object sender, EventArgs e)
        {
            if (Matriz1 == null)
            {
                MessageBox.Show("Matriz nula !", "Error - Matriz");
                return;
            }
            float[,] tempResultante = new float[Matriz1.GetLength(0), Matriz1.GetLength(1)];

            for (int x = 0; x < Matriz1.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz1.GetLength(1); y++)
                {
                    float n = 0;
                    float.TryParse(Matriz1[x, y].Text, out n);
                    tempResultante[x, y] = n;
                    //tempResultante[x, y] = Convert.ToInt32(Matriz1[x, y].Text);
                }
            }

            float[,] tempMatrizResultante = CalculosMatrizes.GerarOposta(tempResultante);
            int TamanhoText = groupBoxMatriz1.Width / Matriz1.GetLength(1);
            for (int x = 0; x < Matriz1.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz1.GetLength(1); y++)
                {
                    Matriz1[x, y].Text = tempMatrizResultante[x, y].ToString();
                }
            }
        }
        private void btnGerarTranspostM1_Click(object sender, EventArgs e)
        {
            if (Matriz1 == null)
            {
                MessageBox.Show("Matriz nula !", "Error - Matriz");
                return;
            }
            float[,] tempResultante = new float[Matriz1.GetLength(0), Matriz1.GetLength(1)];

            for (int x = 0; x < Matriz1.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz1.GetLength(1); y++)
                {
                    float n = 0;
                    float.TryParse(Matriz1[x, y].Text, out n);
                    tempResultante[x, y] = n;
                    //tempResultante[x, y] = Convert.ToInt32(Matriz1[x, y].Text);
                }
            }

            float[,] tempMatrizResultante = CalculosMatrizes.GerarTransposta(tempResultante);
            int TamanhoText = groupBoxMatriz1.Width / Matriz1.GetLength(1);
            Matriz1 = new TextBox[tempMatrizResultante.GetLength(0), tempMatrizResultante.GetLength(1)];
            groupBoxMatriz1.Controls.Clear();
            for (int x = 0; x < Matriz1.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz1.GetLength(1); y++)
                {
                    Matriz1[x, y] = new TextBox();
                    Matriz1[x, y].Text = tempMatrizResultante[x, y].ToString();
                    Matriz1[x, y].Top = (x * Matriz1[x, y].Height) + 20;
                    Matriz1[x, y].Left = y * TamanhoText + 6;
                    Matriz1[x, y].Width = TamanhoText;
                    groupBoxMatriz1.Controls.Add(Matriz1[x, y]);
                }
            }
        }
        private void btnGerarDeterminanteM1_Click(object sender, EventArgs e)
        {
            if (Matriz1 == null)
            {
                MessageBox.Show("Matriz nula !", "Error - Matriz");
                return;
            }
            float[,] tempResultante = new float[Matriz1.GetLength(0), Matriz1.GetLength(1)];

            for (int x = 0; x < Matriz1.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz1.GetLength(1); y++)
                {
                    float n = 0;
                    float.TryParse(Matriz1[x, y].Text, out n);
                    tempResultante[x, y] = n;
                    //tempResultante[x, y] = Convert.ToInt32(Matriz1[x, y].Text);
                }
            }
            if (tempResultante.GetLength(0) == 2 && tempResultante.GetLength(1) == 2)
            {
                determinante = CalculosMatrizes.GerarDeterminante2x2(tempResultante);
                MessageBox.Show("" + determinante, "Determinante...");
            }
            else if (tempResultante.GetLength(0) == 3 && tempResultante.GetLength(1) == 3)
            {
                determinante = CalculosMatrizes.GerarDeterminante3x3(tempResultante);
                MessageBox.Show("" + determinante, "Determinante...");
            }
            else
            {
                MessageBox.Show("Nao e possivel gerar determinante !", "Error - Matriz invalida ");
            }
        }
        private void btnGerarInversaM1_Click(object sender, EventArgs e)
        {
            if (Matriz1 == null)
            {
                MessageBox.Show("Matriz nula !", "Error - Matriz");
                return;
            }
            float[,] tempResultante = new float[Matriz1.GetLength(0), Matriz1.GetLength(1)];
            float[,] matrizAdjunta = new float[Matriz1.GetLength(0), Matriz1.GetLength(1)];
            float[,] matrizCofatora = new float[Matriz1.GetLength(0), Matriz1.GetLength(1)];
            float determinante = 0;
            if (tempResultante.GetLength(0) != 2 || tempResultante.GetLength(1) != 2)
            {
                if (tempResultante.GetLength(0) != 3 || tempResultante.GetLength(1) != 3)
                {
                    MessageBox.Show("Matriz invalida !", "Error - Matriz");
                    return;
                }
            }
            for (int x = 0; x < Matriz1.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz1.GetLength(1); y++)
                {
                    float n = 0;
                    float.TryParse(Matriz1[x, y].Text, out n);
                    tempResultante[x, y] = n;
                }
            }
            /*Matriz Adjunta(A) = Matriz Transposta(Matriz dos cofatores(A))
            Matriz Inversa(A) = (1/ Determinante(A)) * Matriz Adjunta(A)*/
            if (tempResultante.GetLength(0) == 2 && tempResultante.GetLength(1) == 2)
            {
                matrizCofatora = CalculosMatrizes.GerarCofatora2x2(tempResultante);
                matrizAdjunta = CalculosMatrizes.GerarTransposta(matrizCofatora);
                determinante = CalculosMatrizes.GerarDeterminante2x2(tempResultante);
            }
            else if (tempResultante.GetLength(0) == 3 && tempResultante.GetLength(1) == 3)
            {
                matrizCofatora = CalculosMatrizes.GerarCofatora3x3(tempResultante);
                matrizAdjunta = CalculosMatrizes.GerarTransposta(matrizCofatora);
                determinante = CalculosMatrizes.GerarDeterminante3x3(tempResultante);
            }
            else
            {
                MessageBox.Show("Matriz invalida !", "Error - Matriz");
                return;
            }
            if (determinante == 0)
            {
                MessageBox.Show("Matriz invalida, determinante igual a 0 !", "Error - Matriz");
                return;
            }
            float[,] tempMatrizResultante = CalculosMatrizes.GerarInversa(determinante, matrizAdjunta);
            int TamanhoText = groupBoxMatriz1.Width / Matriz1.GetLength(1);
            for (int x = 0; x < Matriz1.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz1.GetLength(1); y++)
                {
                    Matriz1[x, y].Text = tempMatrizResultante[x, y].ToString();
                }
            }
        }
        #endregion
        #region Matriz 2
        private void btnGerarOpostaM2_Click(object sender, EventArgs e)
        {
            if (Matriz2 == null)
            {
                MessageBox.Show("Matriz nula !", "Error - Matriz");
                return;
            }
            float[,] tempResultante = new float[Matriz2.GetLength(0), Matriz2.GetLength(1)];

            for (int x = 0; x < Matriz2.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz2.GetLength(1); y++)
                {
                    float n = 0;
                    float.TryParse(Matriz2[x, y].Text, out n);
                    tempResultante[x, y] = n;
                    //tempResultante[x, y] = Convert.ToInt32(Matriz2[x, y].Text);
                }
            }

            float[,] tempMatrizResultante = CalculosMatrizes.GerarOposta(tempResultante);
            int TamanhoText = groupBoxMatriz2.Width / Matriz2.GetLength(1);
            for (int x = 0; x < Matriz2.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz2.GetLength(1); y++)
                {
                    Matriz2[x, y].Text = tempMatrizResultante[x, y].ToString();
                }
            }
        }
        private void btnGerarTranspostM2_Click(object sender, EventArgs e)
        {
            if (Matriz2 == null)
            {
                MessageBox.Show("Matriz nula !", "Error - Matriz");
                return;
            }
            float[,] tempResultante = new float[Matriz2.GetLength(0), Matriz2.GetLength(1)];

            for (int x = 0; x < Matriz2.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz2.GetLength(1); y++)
                {
                    float n = 0;
                    float.TryParse(Matriz2[x, y].Text, out n);
                    tempResultante[x, y] = n;
                    //tempResultante[x, y] = Convert.ToInt32(Matriz2[x, y].Text);
                }
            }

            float[,] tempMatrizResultante = CalculosMatrizes.GerarTransposta(tempResultante);
            int TamanhoText = groupBoxMatriz2.Width / Matriz2.GetLength(1);
            Matriz2 = new TextBox[tempMatrizResultante.GetLength(0), tempMatrizResultante.GetLength(1)];
            groupBoxMatriz2.Controls.Clear();
            for (int x = 0; x < Matriz2.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz2.GetLength(1); y++)
                {
                    Matriz2[x, y] = new TextBox();
                    Matriz2[x, y].Text = tempMatrizResultante[x, y].ToString();
                    Matriz2[x, y].Top = (x * Matriz2[x, y].Height) + 20;
                    Matriz2[x, y].Left = y * TamanhoText + 6;
                    Matriz2[x, y].Width = TamanhoText;
                    groupBoxMatriz2.Controls.Add(Matriz2[x, y]);
                }
            }
        }
        private void btnGerarDeterminanteM2_Click(object sender, EventArgs e)
        {
            if (Matriz2 == null)
            {
                MessageBox.Show("Matriz nula !", "Error - Matriz");
                return;
            }
            float[,] tempResultante = new float[Matriz2.GetLength(0), Matriz2.GetLength(1)];

            for (int x = 0; x < Matriz2.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz2.GetLength(1); y++)
                {
                    float n = 0;
                    float.TryParse(Matriz2[x, y].Text, out n);
                    tempResultante[x, y] = n;
                    //tempResultante[x, y] = Convert.ToInt32(Matriz2[x, y].Text);
                }
            }
            if (tempResultante.GetLength(0) == 2 && tempResultante.GetLength(1) == 2)
            {
                determinante = CalculosMatrizes.GerarDeterminante2x2(tempResultante);
                MessageBox.Show("" + determinante, "Determinante...");
            }
            else if (tempResultante.GetLength(0) == 3 && tempResultante.GetLength(1) == 3)
            {
                determinante = CalculosMatrizes.GerarDeterminante3x3(tempResultante);
                MessageBox.Show("" + determinante, "Determinante...");
            }
            else
            {
                MessageBox.Show("Nao e possivel gerar determinante !", "Error - Matriz invalida ");
            }
        }
        private void btnGerarInversaM2_Click(object sender, EventArgs e)
        {
            if (Matriz2 == null)
            {
                MessageBox.Show("Matriz nula !", "Error - Matriz");
                return;
            }
            float[,] tempResultante = new float[Matriz2.GetLength(0), Matriz2.GetLength(1)];
            float[,] matrizAdjunta = new float[Matriz2.GetLength(0), Matriz2.GetLength(1)];
            float[,] matrizCofatora = new float[Matriz2.GetLength(0), Matriz2.GetLength(1)];
            float determinante = 0;
            if (tempResultante.GetLength(0) != 2 || tempResultante.GetLength(1) != 2)
            {
                if (tempResultante.GetLength(0) != 3 || tempResultante.GetLength(1) != 3)
                {
                    MessageBox.Show("Matriz invalida !", "Error - Matriz");
                    return;
                }
            }

            for (int x = 0; x < Matriz2.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz2.GetLength(1); y++)
                {
                    float n = 0;
                    float.TryParse(Matriz2[x, y].Text, out n);
                    tempResultante[x, y] = n;
                    //tempResultante[x, y] = Convert.ToInt32(Matriz2[x, y].Text);
                }
            }
            /*Matriz Adjunta(A) = Matriz Transposta(Matriz dos cofatores(A))
            Matriz Inversa(A) = (1/ Determinante(A)) * Matriz Adjunta(A)*/
            if (tempResultante.GetLength(0) == 2 && tempResultante.GetLength(1) == 2)
            {
                matrizCofatora = CalculosMatrizes.GerarCofatora2x2(tempResultante);
                matrizAdjunta = CalculosMatrizes.GerarTransposta(matrizCofatora);
                determinante = CalculosMatrizes.GerarDeterminante2x2(tempResultante);
            }
            else if (tempResultante.GetLength(0) == 3 && tempResultante.GetLength(1) == 3)
            {
                matrizCofatora = CalculosMatrizes.GerarCofatora3x3(tempResultante);
                matrizAdjunta = CalculosMatrizes.GerarTransposta(matrizCofatora);
                determinante = CalculosMatrizes.GerarDeterminante3x3(tempResultante);
            }
            else
            {
                MessageBox.Show("Matriz invalida !", "Error - Matriz");
                return;
            }
            if (determinante == 0)
            {
                MessageBox.Show("Matriz invalida, determinante igual a 0 !", "Error - Matriz");
                return;
            }
            float[,] tempMatrizResultante = CalculosMatrizes.GerarInversa(determinante, matrizAdjunta);
            int TamanhoText = groupBoxMatriz2.Width / Matriz2.GetLength(1);
            for (int x = 0; x < Matriz2.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz2.GetLength(1); y++)
                {
                    Matriz2[x, y].Text = tempMatrizResultante[x, y].ToString();
                }
            }
        }
        #endregion
    }
}
