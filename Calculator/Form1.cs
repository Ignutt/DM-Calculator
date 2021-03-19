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

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainMenu form = new MainMenu();
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
            //signsAlphabet1.Add('¬');
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

        public bool isSign(char sign)
        {
            for (int i = 0; i < signsAlphabet1.Count; i++)
            {
                if (sign == signsAlphabet1[i]) return true;
            }

            for (int i = 0; i < signsAlphabet2.Count; i++)
            {
                if (sign == signsAlphabet2[i]) return true;
            }

            return false;
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

    class SolvingString
    {
        private List<string> solvingString = new List<string>();
        private List<int> stepList = new List<int>();
        private SignsAlphabet signsAlphabet = new SignsAlphabet();

        public SolvingString(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '¬')
                {
                    solvingString.Add(str[i].ToString() + str[i + 1]);
                    i++;
                } else solvingString.Add(str[i].ToString());
            }

            InitializeStepList();
        }

        public void InitializeStepList()
        {
            stepList = new List<int>();
            
            for (int i = 0; i < solvingString.Count; i++)
            {
                if (Exist(i, '¬') && solvingString[i].Length == 2)
                {
                    stepList.Add(i);
                }
            }

            for (int i = 0; i < solvingString.Count; i++)
            {
                for (int j = 0; j < signsAlphabet.GetFirstAlphabet().Count; j++)
                {
                    if ((solvingString[i] == signsAlphabet.GetFirstAlphabet()[j].ToString() || Exist(i, signsAlphabet.GetFirstAlphabet()[j])) && solvingString[i].Length == 1)
                    {
                        stepList.Add(i);
                    }
                }
            }

            for (int i = 0; i < solvingString.Count; i++)
            {
                for (int j = 0; j < signsAlphabet.GetSecondAlphabet().Count; j++)
                {
                    if ((solvingString[i] == signsAlphabet.GetSecondAlphabet()[j].ToString()) && solvingString[i].Length == 1)
                    {
                        stepList.Add(i);
                    }
                }
            }
        }

        public void ChangeValues(int index1, int index2)
        {
            for (int i = index1 + 1; i <= index2; i++)
            {
                solvingString[index1] += " " + solvingString[i];
            }

            for (int i = index1 + 1; i <= index2; i++) solvingString.RemoveAt(index1 + 1);

            InitializeStepList();
        }

        public bool Exist(int index, char value)
        {
            for (int i = 0; i < solvingString[index].Length; i++)
            {
                if (solvingString[index][i] == value) return true;
            }
            return false;
        }

        public List<int> GetStepsList()
        {
            return stepList;
        }

        public void RemoveElem(int index)
        {
            solvingString.RemoveAt(index);
        }

        public List<string> GetString()
        {
            return solvingString;
        }

        public void ChangeElem(int index, string newValue)
        {
            solvingString[index] = newValue;
        }
    }

    public class TableSolved
    {
        private List<List<TableCell>> _table = new List<List<TableCell>>();
        private InputString inputString;
        private SolvingString solvingString;
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
                    //return (!x || y);
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

        public bool isExist(string s)
        {
            for (int i = 0; i < _table.Count; i++)
            {
                for (int j = 0; j < _table[i].Count; j++)
                {
                    if (_table[i][j].GetValue().Length <= 2)
                    {
                        for (int l = 0; l < _table[i][j].GetValue().Length; l++)
                        {
                            if (_table[i][j].GetValue()[l].ToString() == s)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        public Tuple<int, int> GetPositionOfCell(string s)
        {
            for (int i = 0; i < _table.Count; i++)
            {
                for (int j = 0; j < _table[i].Count; j++)
                {
                    if (_table[i][j].GetValue().Length <= 2)
                    {
                        for (int l = 0; l < _table[i][j].GetValue().Length; l++)
                        {
                            if (_table[i][j].GetValue()[l].ToString() == s)
                            {
                                return new Tuple<int, int>(i, j);
                            }
                        }
                    }
                }
            }
            return new Tuple<int, int>(0, 0);
            Console.WriteLine("I fucked up! getPositonOfCell");
        }

        public TableSolved(double rows, int column, string input, Table truthTable)
        {
            this.rows = rows;
            this.column = column;
            inputString = new InputString(input);
            solvingString = new SolvingString(input);

            this.truthTable = truthTable;

            int n = 0;

            _table.Add(new List<TableCell>());

            List<List<string>> mainStepList = new List<List<string>>(); 
            int steps = solvingString.GetStepsList().Count; // т.к кол-во шагов меняется динамически
            int factorMinus = 0;
            for (int i = 0; i < steps; i++)
            {
                mainStepList.Add(new List<string>());
                int index = solvingString.GetStepsList()[0]; // всегда нужно брать первое действие
                string text = "";

                mainStepList[i].Add(solvingString.GetString()[index]);
                for (int l = 0; l < 5; l++)
                {
                    mainStepList[i].Add("");
                }

                if (!solvingString.Exist(index, '¬'))
                {
                    if (solvingString.GetString()[index - 1].Length == 1 && solvingString.GetString()[index + 1].Length == 1 
                        && !isExist(solvingString.GetString()[index - 1]) && !isExist(solvingString.GetString()[index + 1]))
                    {
                        factorMinus++;
                        Console.WriteLine("i am entered!");
                    }
                    if (isExist(solvingString.GetString()[index - 1]))
                    {
                        text += _table[GetPositionOfCell(solvingString.GetString()[index - 1]).Item1][GetPositionOfCell(solvingString.GetString()[index - 1]).Item2].GetValue();
                        mainStepList[i][1] = _table[GetPositionOfCell(solvingString.GetString()[index - 1]).Item1][GetPositionOfCell(solvingString.GetString()[index - 1]).Item2].GetValue();
                        mainStepList[i][3] = _table[GetPositionOfCell(solvingString.GetString()[index - 1]).Item1][GetPositionOfCell(solvingString.GetString()[index - 1]).Item2].GetValue().Length 
                            >= 2 ? (i - factorMinus).ToString() : "-1";
                    }
                    else
                    {
                        text += solvingString.GetString()[index - 1];
                        mainStepList[i][1] = solvingString.GetString()[index - 1];
                        mainStepList[i][3] = solvingString.GetString()[index - 1].Length >= 2 ? (i - factorMinus).ToString() : "-1";
                    }

                    text += solvingString.GetString()[index];
                    mainStepList[i][0] = solvingString.GetString()[index];

                    if (isExist(solvingString.GetString()[index + 1]))
                    {
                        text += _table[GetPositionOfCell(solvingString.GetString()[index + 1]).Item1][GetPositionOfCell(solvingString.GetString()[index + 1]).Item2].GetValue();
                        mainStepList[i][2] = _table[GetPositionOfCell(solvingString.GetString()[index + 1]).Item1][GetPositionOfCell(solvingString.GetString()[index + 1]).Item2].GetValue();
                        mainStepList[i][4] = _table[GetPositionOfCell(solvingString.GetString()[index + 1]).Item1][GetPositionOfCell(solvingString.GetString()[index + 1]).Item2].GetValue().Length 
                            >= 2 ? (i - factorMinus).ToString() : "-1";
                    }
                    else
                    {
                        text += solvingString.GetString()[index + 1];
                        mainStepList[i][2] = solvingString.GetString()[index + 1];
                        mainStepList[i][4] = solvingString.GetString()[index + 1].Length >= 2 ? (i - factorMinus).ToString() : "-1";
                    }
                } 
                else
                {
                    text = solvingString.GetString()[index];
                    mainStepList[i][0] = '¬'.ToString();
                    mainStepList[i][1] = text[1].ToString(); // ¬a  -> a
                    mainStepList[i][3] = i.ToString();
                    mainStepList[i][4] = i.ToString();
                    factorMinus++;
                }
                Console.WriteLine("Index: " + index.ToString());

                TableCell newButton = new TableCell(text, 0, i, 120);
                newButton.SetColor(0, 255, 100, 255);
                _table[0].Add(newButton);

                if (solvingString.Exist(index, '¬')) // инициализация и изменения происходят в конце, чтобы не было конфликтов
                {
                    solvingString.ChangeElem(index, text[1].ToString()); // костыль (но работает)}
                    solvingString.InitializeStepList();
                } else solvingString.ChangeValues(index - 1, index + 1);
            }

            Console.WriteLine("------------------");
            for (int i = 0; i < mainStepList.Count; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write(mainStepList[i][j] + " ");
                    Console.WriteLine();
                }
                Console.WriteLine("------------------");
            }

            for (int i = 1; i <= rows; i++)
            {
                _table.Add(new List<TableCell>());
                
                for (int j = 0; j < column; j++)
                {
                    string word1 = "1";
                    string word2 = "1";
                    string text = "";
                    if (mainStepList[j][0] != "¬")
                    {
                        if (mainStepList[j][1].Length == 1)
                        {
                            word1 = truthTable.GetCell(i, truthTable.GetVariableIndex(Convert.ToChar(mainStepList[j][1]))).GetValue();
                        }
                        else
                        {
                            Console.WriteLine("mainStepList[j][1] : " + mainStepList[j][1]);
                            word1 = _table[i][int.Parse(mainStepList[j][3])].GetValue();    
                        } 

                        if (mainStepList[j][2].Length == 1)
                        {
                            word2 = truthTable.GetCell(i, truthTable.GetVariableIndex(Convert.ToChar(mainStepList[j][2]))).GetValue();
                        }
                        else
                        {
                            Console.WriteLine("J: " + j);
                            word2 = _table[i][int.Parse(mainStepList[j][4])].GetValue();
                        }
                        text = Solve(word1 != "0", word2 != "0", Convert.ToChar(mainStepList[j][0])) ? "1" : "0";
                    }
                    else
                    {
                        word1 = truthTable.GetCell(i, truthTable.GetVariableIndex(Convert.ToChar(mainStepList[j][1]))).GetValue();
                        text = Solve(word1 != "0", word2 != "0", '¬') ? "1" : "0";
                    }


                    TableCell newButton = new TableCell(text, j, i, 120);

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
        public TableCell(string text, int x, int y, int width = 50, int height = 30)
        {
            Enabled = false;
            BackColor = Color.FromArgb(255, 200, 200, 200);
            Text = text;
            Size = new Size(width, height); // defult width = 50 сейчас 75!!!
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
