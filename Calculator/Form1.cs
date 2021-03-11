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
                if (c == v[i])
                {
                    return true;
                }
            }
            return false;
        }

        // ------------------------------------------------------------------

        VariablesAlphabet variablesAlphabet = new VariablesAlphabet();
        SignsAlphabet signsAlphabet = new SignsAlphabet();
        InputString inputString;
        Table table;
        Solve solve = new Solve();

        public Form1()
        {
            InitializeComponent();
            inputString = new InputString(inputField.Text);
            table = new Table(Math.Pow(2, inputString.GetVariablesCount(inputField.Text)), 
                inputString.GetVariablesCount(inputField.Text), inputField.Text);
        }

        private List<Control> GetChildren(Control control = null)
        {
            //if (control == null) control = table2;

            List<Control> list = control.Controls.OfType<Control>().ToList();

            for (int i = 0; i < list.Count; i++)
            {
                Control child = list[i];
                list.AddRange(GetChildren(child));
            }

            return list;
        }

        private void Solve(object sender, EventArgs e)
        {
            DefaultSolve form = new DefaultSolve(inputField.Text);
            form.Visible = true;
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
        private List<char> signsAlphabet1 = new List<char>();
        private List<char> signsAlphabet2 = new List<char>();

        public SignsAlphabet()
        {
            signsAlphabet2.Add('∨');
            signsAlphabet1.Add('∧');
            signsAlphabet1.Add('¬');
            signsAlphabet2.Add('⊕');
            signsAlphabet2.Add('→');
            signsAlphabet2.Add('≡');
            signsAlphabet2.Add('↓');
            signsAlphabet2.Add('↑');
        }

        public List<char> GetFirstAlphabet()
        {
            return signsAlphabet1;
        }

        public List<char> GetSecondAlphabet()
        {
            return signsAlphabet2;
        }
    }

    public class InputString
    {
        private List<char> variablesString = new List<char>();
        private VariablesAlphabet variablesAlphabet = new VariablesAlphabet();
        private SignsAlphabet signsAlphabet = new SignsAlphabet();
        private List<Tuple<char, int>> stepList = new List<Tuple<char, int>>();

        public InputString(string inputField)
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

        public List<Tuple<char, int>> GetStepList(string inputField)
        {
            for (int i = 0; i < inputField.Length; i++)
            {
                for (int j = 0; j < signsAlphabet.GetFirstAlphabet().Count; j++)
                {
                    if (inputField[i] == signsAlphabet.GetFirstAlphabet()[j])
                    {
                        stepList.Add(new Tuple<char, int>(signsAlphabet.GetFirstAlphabet()[j], i));
                    }
                }
            }

            for (int i = 0; i < inputField.Length; i++)
            {
                for (int j = 0; j < signsAlphabet.GetSecondAlphabet().Count; j++)
                {
                    if (inputField[i] == signsAlphabet.GetSecondAlphabet()[j])
                    {
                        stepList.Add(new Tuple<char, int>(signsAlphabet.GetSecondAlphabet()[j], i));
                    }
                }
            }
            return stepList;
        }

        public List<char> GetVariables()
        {
            return variablesString;
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
                for (int j = 0; j < signsAlphabet.GetFirstAlphabet().Count; j++)
                {
                    if (inputField[i] == signsAlphabet.GetFirstAlphabet()[j])
                    {
                        res++;
                    }
                }

                for (int j = 0; j < signsAlphabet.GetSecondAlphabet().Count; j++)
                {
                    if (inputField[i] == signsAlphabet.GetSecondAlphabet()[j])
                    {
                        res++;
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


    /*public class Table
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
    }*/
    public class TableSolved
    {
        private List<List<TableCell>> _table = new List<List<TableCell>>();
        private InputString inputString;
        private double rows;
        private int column;

        private Table truthTable;

        private bool Solve(bool x, bool y, char sign)
        {
            switch (sign)
            {
                case '∨': 
                    return (x || y);
                    break;
                case '∧': 
                    return (x && y);
                    break;
                case '¬': 
                    return (!x);
                    break;
                case '⊕': 
                    return (!x&&y || x&&!y);
                    break;
                case '→': 
                    return (!x || y);
                    break;
                case '≡': 
                    return (!x && !y || x && y);
                    break;
                case '↓': 
                    return (!x && !y);
                    break;
                case '↑':
                    return (!x || !y);
                    break;
                default: return false;
            }
        }

        public TableSolved(double rows, int column, string input, Table truthTable)
        {
            this.rows = rows;
            this.column = column;
            inputString = new InputString(input);

            this.truthTable = truthTable; 

            int n = 0;

            _table.Add(new List<TableCell>());

            for (int i = 0; i < column; i++)
            {
                int index = inputString.GetStepList(input)[i].Item2;
                string text;
                if (input[index] != '¬')
                {
                    text = input[index - 1].ToString() + " " + input[index].ToString() + " " + input[index + 1].ToString();
                } else text = input[index].ToString() + " " + input[index + 1].ToString();
                TableCell newButton = new TableCell(text, 0, i);
                newButton.SetColor(0, 255, 100, 255);
                _table[0].Add(newButton);
            }

            for (int i = 1; i <= rows; i++)
            {
                _table.Add(new List<TableCell>());

                for (int j = 0; j < column; j++)
                {
                    int indexOfSign = inputString.GetStepList(input)[j].Item2;
                    string word1 = "1";
                    string word2 = "1";
                    string text = "";
                    if (input[indexOfSign] != '¬')
                    {
                        word1 = truthTable.GetCell(i, truthTable.GetVariableIndex(input[indexOfSign - 1])).Text;
                        word2 = truthTable.GetCell(i, truthTable.GetVariableIndex(input[indexOfSign + 1])).Text;
                        text = Solve(int.Parse(word1) != 0, int.Parse(word2) != 0, inputString.GetStepList(input)[j].Item1) ? "1" : "0";
                    } else
                    {
                        word1 = truthTable.GetCell(i, truthTable.GetVariableIndex(input[indexOfSign + 1])).Text;
                        text = Solve(int.Parse(word1) != 0, int.Parse(word2) != 0, inputString.GetStepList(input)[j].Item1) ? "1" : "0";
                    }


                    TableCell newButton = new TableCell(text, j, i);

                    _table[i].Add(newButton);
                }
                n++;
            }
        }

        public List<Tuple<char, int>> GetStepsList(string str)
        {
            return inputString.GetStepList(str);
        }

        public TableCell GetCell(int x, int y)
        {
            return _table[x][y];
        }

        public List<List<TableCell>> GetTable()
        {
            return _table;
        }

        public double GetRows()
        {
            return rows;
        }

        public int GetColumns()
        {
            return column;
        }
    }

    public class Table
    {
        private List<List<TableCell>> _table = new List<List<TableCell>>();

        private List<char> variables = new List<char>();
        private InputString inputString;
        private double rows;
        private int column;
        public Table(double rows, int column, string input)
        {
            this.rows = rows;
            this.column = column;
            inputString = new InputString(input);

            int n = 0;
            _table.Add(new List<TableCell>());

            for (int i = 0; i < column; i++)
            {
                TableCell newButton = new TableCell(inputString.GetVariables()[i].ToString(), i, 0);
                newButton.SetColor(0, 255, 100, 255);
                _table[0].Add(newButton);
                variables.Add(inputString.GetVariables()[i]);
            }

            for (int i = 1; i <= rows; i++)
            {
                _table.Add(new List<TableCell>());

                string s = Convert.ToString(n, 2);
                while (s.Length < column) s = "0" + s;
                for (int j = 0; j < column; j++)
                {
                    TableCell newButton = new TableCell(s[j].ToString(), j, i);
                    _table[i].Add(newButton);
                }
                n++;
            }
        }

        public int GetVariableIndex(char var)
        {
            for (int i = 0; i < variables.Count; i++)
            {
                if (variables[i] == var) return i;
            }

            Console.WriteLine("Can not find variable");
            return -1;
        }
        public TableCell GetCell(int x, int y)
        {
            return _table[x][y];
        }

        public List<List<TableCell>> GetTable()
        {
            return _table;
        }

        public double GetRows()
        {
            return rows;
        }

        public int GetColumns()
        {
            return column;
        }
    }

    public class TableCell : Button
    {
        public string value;
        int x, y;
        public TableCell (string text, int x, int y)
        {
            Enabled = false;
            BackColor = Color.FromArgb(255, 200, 200, 200);
            Text = text;
            Size = new Size(50, 30);
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;

            value = text;
            this.x = x;
            this.y = y;
        }

        public void SetColor(int x, int y, int z, int w)
        {
            BackColor = Color.FromArgb(w, x, y, z);
        }

        public string GetValue()
        {
            return value;
        }
    }
}
