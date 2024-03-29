﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class PolinomJekalkina : Form
    {
        private InputString inputString;
        private Table table;
        private WindowPolinom windowsPolinom;
        private TableSolved tableSolved;


        private string firstElem = "a";

        private string firstString = "f(";
        private string resultString = "";
        private List<string> content = new List<string>();
        private List<string> mainString = new List<string>();
        private List<string> mainStringCopy = new List<string>();
        private List<string> mainStringIndexes = new List<string>();
        private List<int> mainStringOfTable = new List<int>();

        public PolinomJekalkina(string input)
        {
            InitializeComponent();

            string str = input;

            inputString = new InputString(input);

            table = new Table(Math.Pow(2, inputString.GetVariablesCount(str)), inputString.GetVariablesCount(str), str);
            tableOut.Size = new Size(inputString.GetVariablesCount(str) * 50 + 15 * inputString.GetVariablesCount(str),
                tableOut.Size.Height);

            tableSolved = new TableSolved(Math.Pow(2, inputString.GetVariablesCount(str)), inputString.GetStepsCount(str), str,
                table);


            DTF.Location = tableOut.Location + new Size(tableOut.Size.Width + 2, 0);


            CalculatePolinom();


            windowsPolinom = new WindowPolinom(firstString, content, resultString);

            for (int i = 0; i < windowsPolinom.GetFormTextsCount(); i++)
            {
                DTF.Controls.Add(windowsPolinom.GetFormText(i));
            }

            for (int i = 0; i < table.GetRows() + 1; i++)
            {
                for (int j = 0; j < table.GetColumns(); j++)
                {
                    tableOut.Controls.Add(table.GetCell(i, j));
                }
            }
        }

        bool isDigit(string digit)
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

        private void GenerateFirstLine()
        {
            for (int i = 0; i < table.GetColumns(); i++)
            {
                firstString += table.GetCell(0, i).GetValue();
                if (i + 1 != table.GetColumns()) firstString += ",";
            }

            firstString += ") = a";

            for (int i = 0; i < table.GetColumns(); i++)
            {
                firstString += "0";
                firstElem += "0";
            }
            firstString += " ⊕ ";

            int factor = 1;
            for (int k = 0; k < table.GetColumns() - 1; k++)
            {
                for (int i = 2; i < table.GetRows(); i++)
                {
                    string index = "";
                    string variables = "";

                    int countTruthVariable = 0;
                    for (int j = 0; j < table.GetColumns(); j++)
                    {
                        index += table.GetCell(i, j).GetValue();
                        if (table.GetCell(i, j).GetValue() == "1")
                        {
                            variables += table.GetCell(0, j).GetValue();
                            countTruthVariable++;
                        }
                    }

                    if (countTruthVariable == factor)
                    {
                        firstString += "a" + index + variables + " ⊕ ";
                    }
                }
                factor++;
            }

            firstString += "a";
            for (int i = 0; i < table.GetColumns(); i++) firstString += "1";
            for (int i = 0; i < table.GetColumns(); i++)
            {
                firstString += table.GetCell(0, i).GetValue();
            }



        }

        private void GenerateContent()
        {
            int factor = 0;
            for (int k = 0; k < table.GetRows() + 1; k++)
            {
                for (int i = 1; i < table.GetRows() + 1; i++)
                {
                    string str = "";
                    int countTruth = 0;
                    string strIndexes = "";
                    for (int j = 0; j < table.GetColumns(); j++)
                    {
                        str += table.GetCell(i, j).GetValue() == "1" ? table.GetCell(0, j).GetValue() : "";
                        if (table.GetCell(i, j).GetValue() == "1") countTruth++;
                        strIndexes += table.GetCell(i, j).GetValue();
                    }
                    if (countTruth == factor)
                    {
                        mainStringIndexes.Add(strIndexes);
                        mainString.Add(str);
                        mainStringCopy.Add(str);
                        mainStringOfTable.Add(i);
                    }
                }
                factor++;
            }

            //for (int i = 0; i < mainString.Count; i++) Console.WriteLine(mainString[i] + mainStringOfTable[i]);

            // GerateForm
            for (int i = 0; i < mainString.Count; i++)
            {
                List<string> str = new List<string>();
                string func = "f(";
                for (int j = 0; j < table.GetColumns(); j++)
                {
                    if (table.GetCell(mainStringOfTable[i], j).GetValue() == "1") str.Add(table.GetCell(0, j).GetValue());
                    func += table.GetCell(mainStringOfTable[i], j).GetValue();
                    if (j + 1 != table.GetColumns()) func += ", ";
                }

                content.Add(func + ") = a" + mainStringIndexes[0] + " ⊕ ");
                for (int j = 1; j < mainString.Count; j++)
                {
                    if (str.Count == 1)
                    {
                        if (str.Contains(mainString[j])) content[content.Count - 1] += "a" + mainStringIndexes[j] + mainString[j];
                    }
                    else if (str.Count != 0)
                    {
                        if (mainString[j].Length <= 2 && str.Contains(mainString[j]))
                        {
                            if (mainString[j].Length == 2 && isDigit(mainString[j][1].ToString()) || mainString[j].Length == 1) content[content.Count - 1] += "a" + mainStringIndexes[j] + mainString[j] + " ⊕ ";
                        }
                        else
                        {
                            if (mainString[j].Length <= str.Count * 2)
                            {
                                bool mainCorrect = true;
                                for (int l = 0; l < mainString[j].Length; l++)
                                {
                                    bool correct = false;
                                    for (int k = 0; k < str.Count; k++)
                                    {
                                        if (mainString[j][l].ToString() == "x" && isDigit(mainString[j][mainString[j].Length > 1 ? l + 1 : 0].ToString()))
                                        {
                                            if (mainString[j][l].ToString() + mainString[j][l + 1].ToString() == str[k])
                                            {
                                                correct = true;
                                                l++;
                                                k++;
                                            }
                                        }
                                        else
                                        {
                                            if (mainString[j][l].ToString() == str[k]) correct = true;
                                        }
                                    }
                                    if (!correct) mainCorrect = false;
                                }
                                if (mainCorrect)
                                {
                                    content[content.Count - 1] += "a" + mainStringIndexes[j] + mainString[j] + " ⊕ ";
                                }
                            }
                        }
                    }
                }
                if (str.Count != 1) content[content.Count - 1] = content[content.Count - 1].Remove(content[content.Count - 1].Length - 2);
            }

            // Generate Form Number
            string firstValue = tableSolved.GetCell(1, tableSolved.GetColumns() - 1).GetValue();
            if (firstValue == "1") resultString += firstValue + " ⊕ ";
            content[0] += " = " + firstValue;
            for (int i = 1; i < mainString.Count; i++)
            {
                // STR
                List<string> str = new List<string>();
                for (int j = 0; j < table.GetColumns(); j++)
                {
                    if (table.GetCell(mainStringOfTable[i], j).GetValue() == "1")
                    {
                        str.Add(table.GetCell(0, j).GetValue());
                    }
                }

                content[i] += " = " + firstValue;
                string lastValue = firstValue;
                for (int j = 1; j < mainString.Count; j++)
                {
                    if (str.Count == 1)
                    {
                        if (str.Contains(mainString[j]))
                        {
                            if (tableSolved.Solve(firstValue == "1", tableSolved.GetCell(mainStringOfTable[j], tableSolved.GetColumns() - 1).GetValue() == "1", '⊕')) resultString += mainStringCopy[j] + " ⊕ ";

                            mainStringCopy[j] = tableSolved.Solve(firstValue == "1", tableSolved.GetCell(mainStringOfTable[j], tableSolved.GetColumns() - 1).GetValue() == "1", '⊕') ? "1" : "0";
                            content[i] += " ⊕ " + tableSolved.GetCell(mainStringOfTable[j], tableSolved.GetColumns() - 1).GetValue() + " = " + mainStringCopy[j];
                        }
                    }
                    else if (str.Count != 0)
                    {
                        if ((mainStringCopy[j] == "1" || mainStringCopy[j] == "0") && str.Contains(mainString[j]))
                        {
                            content[i] += " ⊕ " + mainStringCopy[j];
                            lastValue = tableSolved.Solve(lastValue == "1", mainStringCopy[j] == "1", '⊕') ? "1" : "0";
                            Console.WriteLine(lastValue);
                        }
                        else
                        {
                            if (mainString[j].Length <= str.Count * 2)
                            {
                                bool mainCorrect = true;
                                for (int l = 0; l < mainString[j].Length; l++)
                                {
                                    bool correct = false;
                                    for (int k = 0; k < str.Count; k++)
                                    {
                                        if (mainString[j][l].ToString() == "x" && isDigit(mainString[j][l + 1].ToString()))
                                        {
                                            if (mainString[j][l].ToString() + mainString[j][l + 1].ToString() == str[k])
                                            {
                                                correct = true;
                                                l++;
                                                k++;
                                            }
                                        }
                                        else
                                        {
                                            if (mainString[j][l].ToString() == str[k]) correct = true;
                                        }
                                    }
                                    if (!correct) mainCorrect = false;
                                }
                                if (mainCorrect)
                                {
                                    if (mainStringCopy[j] != "1" && mainStringCopy[j] != "0")
                                    {
                                        if (tableSolved.Solve(lastValue == "1", tableSolved.GetCell(mainStringOfTable[j], tableSolved.GetColumns() - 1).GetValue() == "1", '⊕')) resultString += mainStringCopy[j] + " ⊕ ";

                                        lastValue = tableSolved.Solve(lastValue == "1", tableSolved.GetCell(mainStringOfTable[j], tableSolved.GetColumns() - 1).GetValue() == "1", '⊕') ? "1" : "0";
                                        mainStringCopy[j] = lastValue;
                                        Console.WriteLine(lastValue);
                                        content[i] += " ⊕ " + tableSolved.GetCell(mainStringOfTable[j], tableSolved.GetColumns() - 1).GetValue() + " = " + mainStringCopy[j];

                                    }
                                    else
                                    {
                                        lastValue = tableSolved.Solve(lastValue == "1", mainStringCopy[j] == "1", '⊕') ? "1" : "0";
                                        Console.WriteLine(lastValue);
                                        content[i] += " ⊕ " + mainStringCopy[j];
                                    }
                                }
                            }
                        }
                    }
                }
                Console.WriteLine();
                if (str.Count != 1)
                {
                }

            }
            resultString = resultString.Remove(resultString.Length - 3);
        }


        private void CalculatePolinom()
        {
            GenerateFirstLine();
            GenerateContent();
        }



    }



}