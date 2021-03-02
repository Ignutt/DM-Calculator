using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace Calculator
{
    public partial class Form1 : Form
    {
        private void buttonA_Click(object sender, EventArgs e)
        {
            inputField.Text += "a";
        }

        private void buttonB_Click(object sender, EventArgs e)
        {
            inputField.Text += "b";
        }

        private void buttonOr_Click(object sender, EventArgs e)
        {
            inputField.Text += "∨";
        }

        private void buttonAnd_Click(object sender, EventArgs e)
        {
            inputField.Text += "∧";
        }

        private void buttonNot_Click(object sender, EventArgs e)
        {
            inputField.Text += "¬";
        }

        private void buttonXor_Click(object sender, EventArgs e)
        {
            inputField.Text += "⊕";
        }

        private void buttonImplic_Click(object sender, EventArgs e)
        {
            inputField.Text += "→";
        }

        private void buttonEq_Click(object sender, EventArgs e)
        {
            inputField.Text += "≡";
        }

        private void buttonPierce_Click(object sender, EventArgs e)
        {
            inputField.Text += "↓";
        }

        private void buttonSchaffer_Click(object sender, EventArgs e)
        {
            inputField.Text += "↑";
        }

        private void buttonZero_Click(object sender, EventArgs e)
        {
            inputField.Text += "0";
        }

        private void buttonOne_Click(object sender, EventArgs e)
        {
            inputField.Text += "1";
        }

        private void buttonC_KeyDown(object sender, EventArgs e)
        {
            inputField.Text += "c";
        }

        private void buttonX_Click(object sender, EventArgs e)
        {
            inputField.Text += "x";
        }

        private void buttonY_Click(object sender, EventArgs e)
        {
            inputField.Text += "y";
        }

        private void buttonZ_Click(object sender, EventArgs e)
        {
            inputField.Text += "z";
        }

        private void buttonOpenScope_Click(object sender, EventArgs e)
        {
            inputField.Text += "(";
        }

        private void buttonCloseScope_Click(object sender, EventArgs e)
        {
            inputField.Text += ")";
        }
        /*
        private void buttonX1_Click(object sender, EventArgs e)
        {
            inputField.Text += "X1";
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            inputField.Text += "X2";
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            inputField.Text += "X3";
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            inputField.Text += "X4";
        }

        private void buttonX5_Click(object sender, EventArgs e)
        {
            inputField.Text += "X5";
        }

        private void buttonX6_Click(object sender, EventArgs e)
        {
            inputField.Text += "X6";
        }*/


        List<String> signsАlphabet = new List<string>();
        List<String> variablsAlphabet = new List<string>();
        List<Tuple<string, int>> stepList = new List<Tuple<string, int>>();

        private void CreateSignsAlphabet()
        {
            signsАlphabet.Add("∨");
            signsАlphabet.Add("∧");
            signsАlphabet.Add("¬");
            signsАlphabet.Add("⊕");
            signsАlphabet.Add("→");
            signsАlphabet.Add("≡");
            signsАlphabet.Add("↓");
            signsАlphabet.Add("↑");
        }

        private void CreateVariablesAlphabet()
        {
            variablsAlphabet.Add("a");
            variablsAlphabet.Add("b");
            variablsAlphabet.Add("c");
            variablsAlphabet.Add("x");
            variablsAlphabet.Add("y");
            variablsAlphabet.Add("z");
            variablsAlphabet.Add("1");
            variablsAlphabet.Add("2");
        }

        public Form1()
        {
            InitializeComponent();
            CreateSignsAlphabet();
            CreateVariablesAlphabet();
        }

        private void print(String s)
        {
            Console.WriteLine(s);
        }

        public int GetVariablesCount()
        {
            int res = 0;
            List<String> copyVars = new List<String>(variablsAlphabet);
            for (int i = 0; i < inputField.Text.Length; i++)
            {
                for (int j = 0; j < copyVars.Count; j++)
                {
                    if (copyVars[j] == inputField.Text[i].ToString())
                    {
                        res++;
                        print("res++");
                        copyVars.RemoveAt(j);
                    }
                }
            }
            return res;
        }

        private void Solve(object sender, EventArgs e)
        {
            MakeStepsList();
            MakeTable();
            //Calculate();
        }

        private bool isEqual(string c, List<string> v)
        {
            for (int i = 0; i < v.Count; i++)
            {
                Console.WriteLine(c + " " + v[i]);
                if (c == v[i])
                {
                    return true;
                }
            }
            return false;
        }

        private void Calculate()
        {
            debug.Text = isEqual(inputField.Text[stepList[0].Item2 - 1].ToString(), variablsAlphabet).ToString();
            for (int i = 0; i < GetStepsCount(); i++)
            {
                if (isEqual(inputField.Text[stepList[i].Item2 - 1].ToString(), variablsAlphabet)
                    && isEqual(inputField.Text[stepList[i].Item2 + 1].ToString(), variablsAlphabet))
                {
                    //debug.Text = "YES!";
                }
                //else debug.Text = "NO!";
            }
        }

        private void MakeTable()
        {
            table1.Text = "";
            int n = 0;
            int count = GetVariablesCount();
            for (int i = 0; i < Math.Pow(2, count); i++)
            {
                string s = Convert.ToString(n, 2);
                while (s.Length < count) s = "0" + s;
                for (int j = 0; j < count; j++)
                {
                    table1.Text += s[j];
                }
                table1.Text += "\r\n";
                n++;
            }
        }

        private int GetStepsCount()
        {
            int res = 0;
            for (int i = 0; i < inputField.Text.Length; i++)
            {
                for (int j = 0; j < signsАlphabet.Count; j++)
                {
                    if (inputField.Text[i].ToString() == signsАlphabet[j])
                    {
                        res++;
                        stepList.Add(new Tuple<string, int>(signsАlphabet[j], i));
                    }
                }
            }
            return res;
        }

        private void MakeStepsList()
        {
            for (int i = 0; i < inputField.Text.Length; i++)
            {
                for (int j = 0; j < signsАlphabet.Count; j++)
                {
                    if (inputField.Text[i].ToString() == signsАlphabet[j])
                    {
                        stepList.Add(new Tuple<string, int>(signsАlphabet[j], i));
                    }
                }
            }
        }
    }
}
