using System;
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



        private string firstString = "f(";
        private List<string> content = new List<string>();

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


            windowsPolinom = new WindowPolinom(firstString, content);

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

        List<string> variablesExist = new List<string>();
        List<string> indexes = new List<string>();

        private void GenerateFirstLine()
        {
            for (int i = 0; i < table.GetColumns(); i++)
            {
                variablesExist.Add(table.GetCell(0, i).GetValue());
                firstString += table.GetCell(0, i).GetValue();
                if (i + 1 != table.GetColumns()) firstString += ",";
            }

            firstString += ") = a";

            for (int i = 0; i < variablesExist.Count; i++) firstString += "0";
            firstString += " ⊕ ";

            int factor = 1;
            for (int k = 0; k < variablesExist.Count - 1; k++)
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


                        indexes.Add("");
                        for (int m = 0; m < index.Length; m++)
                        {
                            indexes[indexes.Count - 1] += index[m];
                            if (m + 1< index.Length) indexes[indexes.Count - 1] += ", ";
                        }
                    }
                }
                factor++;
            }

            firstString += "a";
            for (int i = 0; i < variablesExist.Count; i++) firstString += "1";
            for (int i = 0; i < variablesExist.Count; i++) firstString += variablesExist[i];
         
        }

        private void GenerateContent()
        {
            string step1 = "f(";
            string firstElem = "a";
            for (int i = 0; i < variablesExist.Count; i++) { 
                step1 += "0";
                if (i + 1 != variablesExist.Count) step1 += ", "; 
            }
            step1 += ") = ";
            for (int i = 0; i < variablesExist.Count; i++)
            {
                firstElem += "0";
            }
            step1 += firstElem + " = " + tableSolved.GetCell(1, tableSolved.GetColumns() - 1).GetValue() + " ⇒ " + firstElem + " = " + tableSolved.GetCell(1, tableSolved.GetColumns() - 1).GetValue();
            content.Add(step1);

            for (int k = 0; k < variablesExist.Count - 1; k++)
            {
                int factor = 1;
                for (int i = 2; i < table.GetRows(); i++)
                {
                    string str = "a";
                    for (int m = 0; m < variablesExist.Count; m++) str += "0";

                    int countTruthVariable = 0;
                    str += " a";
                    for (int j = 0; j < table.GetColumns(); j++)
                    {
                        str += table.GetCell(i, j).GetValue();
                        if (table.GetCell(i, j).GetValue() == "1")
                        {
                            countTruthVariable++;
                        }
                    }

                    if (countTruthVariable == factor)
                    {
                        content.Add("f(" + indexes[i - 2] + ") = ");
                        content[content.Count - 1] += str;
                    }
                }
                factor++;
            }

            
        }

        private void CalculatePolinom()
        {
            GenerateFirstLine();
            GenerateContent();
        }



    }



}
