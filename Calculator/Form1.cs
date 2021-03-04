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
        public bool isEqual(string c, List<string> v)
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

        public void print(string str)
        {
            Console.WriteLine(str);
        }

        // ------------------------------------------------------------------

        VariablesAlphabet variablesAlphabet = new VariablesAlphabet();
        SignsAlphabet signsAlphabet = new SignsAlphabet();
        InputString inputString = new InputString();
        Table table = new Table();
        Solve solve = new Solve();

        public Form1()
        {
            InitializeComponent();
        }

        private void Solve(object sender, EventArgs e)
        {
            inputString.CreateVariablesList(inputField.Text);
            table1.Text = table.MakeTable(inputField.Text);
        }


    }


    public class VariablesAlphabet
    {
        private List<char> variablesAlphabet = new List<char>();

        public VariablesAlphabet()
        {
            variablesAlphabet.Add('a');
            variablesAlphabet.Add('b');
            variablesAlphabet.Add('c');
            variablesAlphabet.Add('x');
            variablesAlphabet.Add('y');
            variablesAlphabet.Add('z');
            variablesAlphabet.Add('1');
            variablesAlphabet.Add('2');
        }

        public List<char> GetAlphabet()
        {
            return variablesAlphabet;
        }
    }

    public class SignsAlphabet
    {
        private List<char> signsAlphabet = new List<char>();

        public SignsAlphabet()
        {
            signsAlphabet.Add('∨');
            signsAlphabet.Add('∧');
            signsAlphabet.Add('¬');
            signsAlphabet.Add('⊕');
            signsAlphabet.Add('→');
            signsAlphabet.Add('≡');
            signsAlphabet.Add('↓');
            signsAlphabet.Add('↑');
        }

        public List<char> GetAlphabet()
        {
            return signsAlphabet;
        }
    }

    public class InputString
    {
        private List<char> variablesString = new List<char>();
        private VariablesAlphabet variablesAlphabet = new VariablesAlphabet();
        private SignsAlphabet signsAlphabet = new SignsAlphabet();
        private List<Tuple<char, int>> stepList = new List<Tuple<char, int>>();

        public InputString()
        {

        }

        public void CreateVariablesList(string inputField)
        {
            List<char> copyVars = new List<char>(variablesAlphabet.GetAlphabet());
            variablesString = new List<char>();
            for (int i = 0; i < inputField.Length; i++)
            {
                for (int j = 0; j < copyVars.Count; j++)
                {
                    if (copyVars[j] == inputField[i])
                    {
                        variablesString.Add(inputField[i]);
                        copyVars.RemoveAt(j);
                    }
                }
            }
        }

        public int GetVariablesCount(string inputField)
        {
            int res = 0;
            List<char> copyVars = new List<char>(variablesAlphabet.GetAlphabet());
            for (int i = 0; i < inputField.Length; i++)
            {
                for (int j = 0; j < copyVars.Count; j++)
                {
                    if (copyVars[j] == inputField[i])
                    {
                        res++;
                        copyVars.RemoveAt(j);
                    }
                }
            }
            return res;
        }

        public int GetStepsCount(string inputField)
        {
            int res = 0;
            for (int i = 0; i < inputField.Length; i++)
            {
                for (int j = 0; j < signsAlphabet.GetAlphabet().Count; j++)
                {
                    if (inputField[i] == signsAlphabet.GetAlphabet()[j])
                    {
                        res++;
                        stepList.Add(new Tuple<char, int>(signsAlphabet.GetAlphabet()[j], i));
                    }
                }
            }
            return res;
        }
    }

    public class Solve
    {
        public bool SolveExample(bool a, bool b, char sign)
        {
            switch (sign)
            {
                case '∨': return a || b;
                case '∧': return a && b;
                case '⊕': return a ^ b;
                case '≡': return !a && !b || a && b;
                case '→': return !a || b;
                case '↓': return !a && !b;
                case '↑': return !a || !b;
            }
            return false;
        }

        public bool SolveExample(bool a)
        {
            return !a;
        }
    }

    public class Table
    {
        InputString inputString = new InputString();
        List<List<int>> local_table = new List<List<int>>();
        public string MakeTable(string str)
        {
            string table = "";
            int n = 0;
            int count = inputString.GetVariablesCount(str);
            for (int i = 0; i < Math.Pow(2, count); i++)
            {
                local_table.Add(new List<int>());
                string s = Convert.ToString(n, 2);
                while (s.Length < count) s = "0" + s;
                for (int j = 0; j < count; j++)
                {
                    table += s[j];
                    local_table[i].Add(int.Parse(s[j].ToString()));
                }
                table += "\r\n";
                n++;
            }
            return table;
        }
    }
}
