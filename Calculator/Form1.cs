﻿using System;
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

        private void x1_Button_Click(object sender, EventArgs e)
        {
            inputField.Text += "x1";
        }

        private void x2_Button_Click(object sender, EventArgs e)
        {
            inputField.Text += "x2";
        }

        private void x3_Button_Click(object sender, EventArgs e)
        {
            inputField.Text += "x3";
        }

        private void x4_Button_Click(object sender, EventArgs e)
        {
            inputField.Text += "x4";
        }

        private void x5_Button_Click(object sender, EventArgs e)
        {
            inputField.Text += "x5";
        }

        private void x6_Button_Click(object sender, EventArgs e)
        {
            inputField.Text += "x6";
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

            try
            {
                DefaultSolve form = new DefaultSolve(inputField.Text);
                form.Visible = true;
                errorMessage.Visible = false;
            }
            catch
            {
                errorMessage.Visible = true;
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainMenu form = new MainMenu();
            form.Visible = true;


        }

        private void SdnfButton_Click(object sender, EventArgs e)
        {
            try
            {
                Solve_SDNF form = new Solve_SDNF(inputField.Text);
                form.Visible = true;
                errorMessage.Visible = false;
            }
            catch
            {
                errorMessage.Visible = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Solve_SKNF form = new Solve_SKNF(inputField.Text);
                form.Visible = true;
                errorMessage.Visible = false;
            }
            catch
            {
                errorMessage.Visible = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                PolinomJekalkina form = new PolinomJekalkina(inputField.Text);
                form.Visible = true;
                errorMessage.Visible = false;
            }
            catch
            {
                errorMessage.Visible = true;
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (inputField.Text.Length > 0) inputField.Text = inputField.Text.Remove(inputField.Text.Length - 1);
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

    public class Sign {
        private string value = "+";
        private int priory = 0;

        public Sign(string value, int priory)
        {
            this.value = value;
            this.priory = priory;
        }

        public int GetPriority()
        {
            return priory;
        }

        public string GetValue()
        {
            return value;
        }
    }

    public class SignsAlphabet
    {
        private List<Sign> signsAlphabet = new List<Sign>();

        public SignsAlphabet()
        {
            signsAlphabet.Add(new Sign("¬", 8));
            signsAlphabet.Add(new Sign("∧", 7));
            signsAlphabet.Add(new Sign("∨", 6));
            signsAlphabet.Add(new Sign("⊕", 5));
            signsAlphabet.Add(new Sign("↑", 4));
            signsAlphabet.Add(new Sign("→", 3));
            signsAlphabet.Add(new Sign("↓", 2));
            signsAlphabet.Add(new Sign("≡", 1));
            //signsAlphabet.Add(new Sign("(", -100));
            //signsAlphabet.Add(new Sign(")", -100));
        }

        public List<Sign> GetFirstAlphabet()
        {
            return signsAlphabet;
        }

        public int GetSignPriority(string val)
        {
            for (int i = 0; i < signsAlphabet.Count; i++)
            {
                if (val == signsAlphabet[i].GetValue()) return signsAlphabet[i].GetPriority();
            }
            return -1;
        }

        public bool isSign(string sign)
        {
            for (int i = 0; i < signsAlphabet.Count; i++)
            {
                if (sign == signsAlphabet[i].GetValue()) return true;
            }

            for (int i = 0; i < signsAlphabet.Count; i++)
            {
                if (sign == signsAlphabet[i].GetValue()) return true;
            }

            return false;
        }
    }

    public class InputString
    {
        private List<string> variablesString = new List<string>();
        private VariablesAlphabet variablesAlphabet = new VariablesAlphabet();
        private SignsAlphabet signsAlphabet = new SignsAlphabet();
        private List<Tuple<char, int>> stepList = new List<Tuple<char, int>>();

        private bool isDigit(string digit)
        {
           List<string> digitAlphabet = new List<string>() { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
           for (int i = 0; i < digitAlphabet.Count; i++)
           {
                if (digit == digitAlphabet[i])
                {
                    return true;
                }
           }
            return false;
        }

        public InputString(string inputField)
        {
            List<char> copyVars = new List<char>(variablesAlphabet.GetAlphabet());
            variablesString = new List<string>();
            for (int i = 0; i < inputField.Length; i++)
            {
                for (int j = 0; j < copyVars.Count; j++)
                {
                    if (!isDigit(inputField[i].ToString()))
                    {
                        if (copyVars[j] == inputField[i])
                        {
                            if (inputField[i] == 'x' && isDigit(inputField[i + 1 < inputField.Length ? i + 1 : i].ToString()))
                            {
                                variablesString.Add(inputField[i].ToString() + inputField[i + 1].ToString());
                                i++;
                            }
                            else
                            {
                                variablesString.Add(inputField[i].ToString());
                                copyVars.RemoveAt(j);
                            }
                        }
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
                    if (inputField[i].ToString() == signsAlphabet.GetFirstAlphabet()[j].GetValue())
                    {
                        stepList.Add(new Tuple<char, int>(Convert.ToChar(signsAlphabet.GetFirstAlphabet()[j].GetValue()), i));
                    }
                }
            }

            for (int i = 0; i < inputField.Length; i++)
            {
                for (int j = 0; j < signsAlphabet.GetFirstAlphabet().Count; j++)
                {
                    if (inputField[i].ToString() == signsAlphabet.GetFirstAlphabet()[j].GetValue())
                    {
                        stepList.Add(new Tuple<char, int>(Convert.ToChar(signsAlphabet.GetFirstAlphabet()[j].GetValue()), i));
                    }
                }
            }
            return stepList;
        }

        public List<string> GetVariables()
        {
            return variablesString;
        }

        public int GetVariablesCount(string inputField)
        {
            return variablesString.Count;
        }

        public int GetStepsCount(string inputField)
        {
            int res = 0;
            for (int i = 0; i < inputField.Length; i++)
            {
                for (int j = 0; j < signsAlphabet.GetFirstAlphabet().Count; j++)
                {
                    if (inputField[i].ToString() == signsAlphabet.GetFirstAlphabet()[j].GetValue())
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

    class SolvingString
    {
        private List<string> solvingString = new List<string>();
        private List<int> stepList = new List<int>();
        private SignsAlphabet signsAlphabet = new SignsAlphabet();

        private List<Tuple<int, int>> scopes = new List<Tuple<int, int>>();

        private void GenerateScopeArray(string str)
        {
            scopes = new List<Tuple<int, int>>();
            List<int> indexesOpen = new List<int>();
            if (str.Contains("(") || str.Contains(")"))
                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i] == '(')
                    {
                        indexesOpen.Add(i);
                    }
                    else if (str[i] == ')')
                    {
                        scopes.Add(new Tuple<int, int>(indexesOpen[indexesOpen.Count - 1], i));
                        indexesOpen.RemoveAt(indexesOpen.Count - 1);
                    }
                }
        }

        public SolvingString(string str)
        {
            GenerateScopeArray(str);
            if (!str.Contains(")") || !str.Contains("("))
            {
                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i] == '¬')
                    {
                        solvingString.Add(str[i].ToString() + str[i + 1]);
                        i++;
                    }
                    else solvingString.Add(str[i].ToString());
                }
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

            for (int i = 0; i < signsAlphabet.GetFirstAlphabet().Count; i++)
            {
                for (int j = 0; j < solvingString.Count; j++)
                {
                    if ((solvingString[j] == signsAlphabet.GetFirstAlphabet()[i].ToString() || Exist(j, Convert.ToChar(signsAlphabet.GetFirstAlphabet()[i].GetValue()))) && solvingString[j].Length == 1)
                    {
                        stepList.Add(j);
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
        private SignsAlphabet signsAlphabet = new SignsAlphabet();
        private double rows;
        private int column;

        private Table truthTable;
        public bool Solve(bool x, bool y, char sign)
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

        private string ReverseString(string s)
        {
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }

        private bool isDigit(string digit)
        {
            List<string> digitAlphabet = new List<string>() { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
            for (int i = 0; i < digitAlphabet.Count; i++)
            {
                if (digit == digitAlphabet[i])
                {
                    return true;
                }
            }
            return false;
        }

        public TableSolved(double rows, int column, string input, Table truthTable)
        {
            this.rows = rows;
            this.column = column;
            inputString = new InputString(input);

            this.truthTable = truthTable;

            int n = 0;

            _table.Add(new List<TableCell>());

            //HEADER
            List<string> vars = new List<string>();
            List<Sign> signs = new List<Sign>();
            for (int i = 0; i < input.Length; i++)
            {
                if (signsAlphabet.isSign(input[i].ToString()) || input[i] == ')' || input[i] == '(')
                {
                    if (signs.Count > 0)
                    {
                        // проверка на скобки
                        if (input[i] == '(')
                        {
                            signs.Add(new Sign(input[i].ToString(), signsAlphabet.GetSignPriority(input[i].ToString())));
                        }
                        else if (input[i] == ')')
                        {
                            while (signs[signs.Count - 1].GetValue() != "(")
                            {
                                string newValue = "";
                                if (signs[signs.Count - 1].GetValue() != "¬")
                                {
                                    newValue = vars[vars.Count - 2] + signs[signs.Count - 1].GetValue() + vars[vars.Count - 1];
                                    newValue = "(" + newValue + ")";
                                    vars.RemoveAt(vars.Count - 1);
                                    vars.RemoveAt(vars.Count - 1);
                                    signs.RemoveAt(signs.Count - 1);
                                }
                                else
                                {
                                    newValue = signs[signs.Count - 1].GetValue() + " " + vars[vars.Count - 1];
                                    vars.RemoveAt(vars.Count - 1);
                                    signs.RemoveAt(signs.Count - 1);
                                }
                                vars.Add(newValue);

                                TableCell newButton = new TableCell(newValue, 0, i, 120);
                                newButton.SetColor(0, 255, 100, 255);
                                _table[0].Add(newButton);

                            }

                            signs.RemoveAt(signs.Count - 1);
                        }
                        // работа без скобок
                        else if (signs[signs.Count - 1].GetPriority() < signsAlphabet.GetSignPriority(input[i].ToString()) &&
                                signs[signs.Count - 1].GetValue() != ")" && signs[signs.Count - 1].GetValue() != "(")
                        {
                            signs.Add(new Sign(input[i].ToString(), signsAlphabet.GetSignPriority(input[i].ToString())));
                        }
                        else
                        {
                            while (signs[signs.Count - 1].GetPriority() >= signsAlphabet.GetSignPriority(input[i].ToString()) && 
                                signs[signs.Count - 1].GetValue() != ")" && signs[signs.Count - 1].GetValue() != "(")
                            {
                                string newValue = "";
                                if (signs[signs.Count - 1].GetValue() != "¬")
                                {
                                    newValue = vars[vars.Count - 2] + signs[signs.Count - 1].GetValue() + vars[vars.Count - 1];
                                    vars.RemoveAt(vars.Count - 1);
                                    vars.RemoveAt(vars.Count - 1);
                                    signs.RemoveAt(signs.Count - 1);
                                } else
                                {
                                    newValue = signs[signs.Count - 1].GetValue() + " " + vars[vars.Count - 1];
                                    vars.RemoveAt(vars.Count - 1);
                                    signs.RemoveAt(signs.Count - 1);
                                }
                                vars.Add(newValue);

                                TableCell newButton = new TableCell(newValue, 0, i, 120);
                                newButton.SetColor(0, 255, 100, 255);
                                _table[0].Add(newButton);

                                if (signs.Count == 0)
                                {
                                    break;
                                }
                            } 
                            signs.Add(new Sign(input[i].ToString(), signsAlphabet.GetSignPriority(input[i].ToString())));
                        }
                    }
                    else
                    {
                        signs.Add(new Sign(input[i].ToString(), signsAlphabet.GetSignPriority(input[i].ToString())));
                    }
                }
                else
                {
                    if (input[i] == 'x' && isDigit(input[i + 1 < input.Length ? i + 1 : i].ToString()))
                    {
                        vars.Add(input[i].ToString() + input[i + 1].ToString());
                        i++;
                    }
                    else vars.Add(input[i].ToString());
                }
            }

            while (signs.Count != 0)
            {
                string newValue = "";
                if (signs[signs.Count - 1].GetValue() != "¬")
                {
                    newValue = vars[vars.Count - 2] + signs[signs.Count - 1].GetValue() + vars[vars.Count - 1];
                    vars.RemoveAt(vars.Count - 1);
                    vars.RemoveAt(vars.Count - 1);
                    signs.RemoveAt(signs.Count - 1);
                }
                else
                {
                    newValue = signs[signs.Count - 1].GetValue() + " " + vars[vars.Count - 1];
                    vars.RemoveAt(vars.Count - 1);
                    signs.RemoveAt(signs.Count - 1);
                }
                vars.Add(newValue);

                TableCell newButton = new TableCell(newValue, 0, 0, 120);
                newButton.SetColor(0, 255, 100, 255);
                _table[0].Add(newButton);
            }

            //MAINPART
            vars = new List<string>();
            signs = new List<Sign>();

            for (int l = 1; l < rows + 1; l++)
            {
                _table.Add(new List<TableCell>());
                vars = new List<string>();
                signs = new List<Sign>();
                for (int i = 0; i < input.Length; i++)
                {
                    if (signsAlphabet.isSign(input[i].ToString()) || input[i] == ')' || input[i] == '(')
                    {
                        if (signs.Count > 0)
                        {
                            // проверка на скобки
                            if (input[i] == '(')
                            {
                                signs.Add(new Sign(input[i].ToString(), signsAlphabet.GetSignPriority(input[i].ToString())));
                            }
                            else if (input[i] == ')')
                            {
                                while (signs[signs.Count - 1].GetValue() != "(")
                                {
                                    string newValue = "";
                                    if (signs[signs.Count - 1].GetValue() != "¬")
                                    {
                                        string val1 = vars[vars.Count - 2] == "0" || vars[vars.Count - 2] == "1"
                                                    ? vars[vars.Count - 2]
                                                    : truthTable.GetCell(l, truthTable.GetVariableIndex(vars[vars.Count - 2])).GetValue();

                                        string val2 = vars[vars.Count - 1] == "0" || vars[vars.Count - 1] == "1"
                                            ? vars[vars.Count - 1]
                                            : truthTable.GetCell(l, truthTable.GetVariableIndex(vars[vars.Count - 1])).GetValue();

                                        newValue = Solve(val1 == "1", val2 == "1", Convert.ToChar(signs[signs.Count - 1].GetValue())) ? "1" : "0";

                                        vars.RemoveAt(vars.Count - 1);
                                        vars.RemoveAt(vars.Count - 1);
                                        signs.RemoveAt(signs.Count - 1);
                                    }
                                    else
                                    {
                                        string val2 = vars[vars.Count - 1] == "0" || vars[vars.Count - 1] == "1"
                                            ? vars[vars.Count - 1]
                                            : truthTable.GetCell(l, truthTable.GetVariableIndex(vars[vars.Count - 1])).GetValue();

                                        newValue = Solve(val2 == "1", val2 == "1", Convert.ToChar(signs[signs.Count - 1].GetValue())) ? "1" : "0";

                                        vars.RemoveAt(vars.Count - 1);
                                        signs.RemoveAt(signs.Count - 1);
                                    }
                                    vars.Add(newValue);

                                    TableCell newButton = new TableCell(newValue, l, i, 120);
                                    newButton.SetColor(255, 200, 200, 200);
                                    _table[l].Add(newButton);

                                }

                                signs.RemoveAt(signs.Count - 1);
                            }
                            // работа без скобок
                            else if (signs[signs.Count - 1].GetPriority() < signsAlphabet.GetSignPriority(input[i].ToString()) &&
                                    signs[signs.Count - 1].GetValue() != ")" && signs[signs.Count - 1].GetValue() != "(")
                            {
                                signs.Add(new Sign(input[i].ToString(), signsAlphabet.GetSignPriority(input[i].ToString())));
                            }
                            else
                            {
                                while (signs[signs.Count - 1].GetPriority() >= signsAlphabet.GetSignPriority(input[i].ToString()) &&
                                    signs[signs.Count - 1].GetValue() != ")" && signs[signs.Count - 1].GetValue() != "(")
                                {
                                    string newValue = "";
                                    if (signs[signs.Count - 1].GetValue() != "¬")
                                    {
                                        string val1 = vars[vars.Count - 2] == "0" || vars[vars.Count - 2] == "1"
                                                    ? vars[vars.Count - 2]
                                                    : truthTable.GetCell(l, truthTable.GetVariableIndex(vars[vars.Count - 2])).GetValue();

                                        string val2 = vars[vars.Count - 1] == "0" || vars[vars.Count - 1] == "1"
                                            ? vars[vars.Count - 1]
                                            : truthTable.GetCell(l, truthTable.GetVariableIndex(vars[vars.Count - 1])).GetValue();

                                        newValue = Solve(val1 == "1", val2 == "1", Convert.ToChar(signs[signs.Count - 1].GetValue())) ? "1" : "0";

                                        vars.RemoveAt(vars.Count - 1);
                                        vars.RemoveAt(vars.Count - 1);
                                        signs.RemoveAt(signs.Count - 1);
                                    }
                                    else
                                    {
                                        string val2 = vars[vars.Count - 1] == "0" || vars[vars.Count - 1] == "1"
                                            ? vars[vars.Count - 1]
                                            : truthTable.GetCell(l, truthTable.GetVariableIndex(vars[vars.Count - 1])).GetValue();

                                        newValue = Solve(val2 == "1", val2 == "1", Convert.ToChar(signs[signs.Count - 1].GetValue())) ? "1" : "0";
                                        vars.RemoveAt(vars.Count - 1);
                                        signs.RemoveAt(signs.Count - 1);
                                    }
                                    vars.Add(newValue);

                                    TableCell newButton = new TableCell(newValue, l, i, 120);
                                    newButton.SetColor(255, 200, 200, 200);
                                    _table[l].Add(newButton);

                                    if (signs.Count == 0)
                                    {
                                        break;
                                    }
                                }
                                signs.Add(new Sign(input[i].ToString(), signsAlphabet.GetSignPriority(input[i].ToString())));
                            }
                        }
                        else
                        {
                            signs.Add(new Sign(input[i].ToString(), signsAlphabet.GetSignPriority(input[i].ToString())));
                        }
                    }
                    else
                    {
                        if (input[i] == 'x' && isDigit(input[i + 1 < input.Length ? i + 1 : i].ToString()))
                        {
                            vars.Add(input[i].ToString() + input[i + 1].ToString());
                            i++;
                        }
                        else vars.Add(input[i].ToString());
                    }
                }
             
                while (signs.Count != 0)
                {
                    string newValue = "";
                    if (signs[signs.Count - 1].GetValue() != "¬")
                    {
                        string val1 = vars[vars.Count - 2] == "0" || vars[vars.Count - 2] == "1"
                            ? vars[vars.Count - 2]
                        : truthTable.GetCell(l, truthTable.GetVariableIndex(vars[vars.Count - 2])).GetValue();

                        string val2 = vars[vars.Count - 1] == "0" || vars[vars.Count - 1] == "1"
                            ? vars[vars.Count - 1]
                            : truthTable.GetCell(l, truthTable.GetVariableIndex(vars[vars.Count - 1])).GetValue();

                        newValue = Solve(val1 == "1", val2 == "1", Convert.ToChar(signs[signs.Count - 1].GetValue())) ? "1" : "0";

                        vars.RemoveAt(vars.Count - 1);
                        vars.RemoveAt(vars.Count - 1);
                        signs.RemoveAt(signs.Count - 1);
                    }
                    else
                    {
                        string val2 = vars[vars.Count - 1] == "0" || vars[vars.Count - 1] == "1"
                            ? vars[vars.Count - 1]
                            : truthTable.GetCell(l, truthTable.GetVariableIndex(vars[vars.Count - 1])).GetValue();

                        newValue = Solve(val2 == "1", val2 == "1", Convert.ToChar(signs[signs.Count - 1].GetValue())) ? "1" : "0";
                        vars.RemoveAt(vars.Count - 1);
                        signs.RemoveAt(signs.Count - 1);
                    }
                    vars.Add(newValue);

                    TableCell newButton = new TableCell(newValue, l, l, 120);
                    newButton.SetColor(255, 200, 200, 200);
                    _table[l].Add(newButton);


                }
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

        private List<string> variables = new List<string>();
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

        public int GetVariableIndex(string var)
        {
            for (int i = 0; i < variables.Count; i++)
            {
                if (variables[i] == var) return i;
            }

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

    public class FormText: Button
    {
        private int defaultHeight = 27; //px
        private int defaultWordCount = 68; //count
        public FormText(string text, float size = 11.25f)
        {
            Enabled = false;
            BackColor = Color.White;
            ForeColor = Color.Black;
            Text = text;

            int wordsCount = text.Length;
            int height = 0;
            while (wordsCount > 0 && wordsCount - defaultHeight >= 0)
            {
                height += defaultHeight;
                wordsCount -= defaultWordCount;
            }
            if (height <= 0) height = defaultHeight;
            Size = new Size(590, height);
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;

            Font = new Font("Segoe UI", size, FontStyle.Bold);
            TextAlign = ContentAlignment.TopLeft;
        }
    }

    public class WindowDTF
    {
        private List<FormText> window = new List<FormText>();

        public WindowDTF(string values, List<string> mainValues, string lastValue)
        {
            window.Add(new FormText("Решение СДНФ:"));
            window.Add(new FormText("Найдём наборы, на которых функция принимает истинное значение:"));
            window.Add(new FormText(values));
            window.Add(new FormText("В соответствие найденным наборам поставим элементарные конъюнкции по всем переменным, причём если переменная в наборе принимает значение 0, то она будет записана с отрицанием:"));
            for (int i = 0; i < mainValues.Count; i++) window.Add(new FormText(mainValues[i]));
            window.Add(new FormText("Объединим конъюнкции с помощью операции ИЛИ и получим совершенную дизъюнктивную нормальную форму:"));
            window.Add(new FormText(lastValue));
        }

        public FormText GetFormText(int index)
        {
            return window[index];
        }

        public int GetFormTextsCount()
        {
            return window.Count;
        }
    }

    public class WindowKTF
    {
        private List<FormText> window = new List<FormText>();

        public WindowKTF(string values, List<string> mainValues, string lastValue)
        {
            window.Add(new FormText("Решение СKНФ:"));
            window.Add(new FormText("Найдём наборы, на которых функция принимает ложное значение:"));
            window.Add(new FormText(values));
            window.Add(new FormText("В соответствие найденным наборам поставим элементарные дизъюнкции по всем переменным, причём если переменная в наборе принимает значение 1, то она будет записана с отрицанием:"));
            for (int i = 0; i < mainValues.Count; i++) window.Add(new FormText(mainValues[i]));
            window.Add(new FormText("Объединим дизъюнкции с помощью операции И и получим совершенную конъюнктивную нормальную форму:"));
            window.Add(new FormText(lastValue));
        }

        public FormText GetFormText(int index)
        {
            return window[index];
        }

        public int GetFormTextsCount()
        {
            return window.Count;
        }
    }

    public class WindowPolinom
    {
        private List<FormText> window = new List<FormText>();

        public WindowPolinom(string firstString, List<string> content, string resultString)
        {
            window.Add(new FormText("Решение Полином Жегалкина:"));
            window.Add(new FormText("Запишем данную функцию в виде полинома Жегалкина с неопределёнными коэффициентами:"));
            window.Add(new FormText(firstString));
            for (int i = 0; i < content.Count; i++) window.Add(new FormText(content[i]));
            window.Add(new FormText("Окончательно получаем: " + resultString));
        }

        public FormText GetFormText(int index)
        {
            return window[index];
        }

        public int GetFormTextsCount()
        {
            return window.Count;
        }
    }
}
