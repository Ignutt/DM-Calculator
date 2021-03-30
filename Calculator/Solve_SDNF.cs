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
    public partial class Solve_SDNF : Form
    {
        private InputString inputString;
        private Table table;
        private WindowDTF windowsDTF;
        private TableSolved tableSolved;

        private string values = "";
        private List<string> mainValues;
        private string lastValue = "";

        public Solve_SDNF(string input)
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


            CalculateDTF();


            windowsDTF = new WindowDTF(values, mainValues, lastValue);

            for (int i = 0; i < windowsDTF.GetFormTextsCount(); i++)
            {
                DTF.Controls.Add(windowsDTF.GetFormText(i));
            }

            for (int i = 0; i < table.GetRows() + 1; i++)
            {
                for (int j = 0; j < table.GetColumns(); j++)
                {
                    tableOut.Controls.Add(table.GetCell(i, j));
                }
            }
        }
        private void CalculateDTF()
        {
            mainValues = new List<string>();

            int l = 1;
            for (int i = 1; i < tableSolved.GetRows() + 1; i++)
            {
                if (tableSolved.GetCell(i, tableSolved.GetColumns() - 1).GetValue() == "1")
                {
                    string str = "{";
                    for (int j = 0; j < table.GetColumns(); j++)
                    {
                        str += table.GetCell(i, j).GetValue();
                        if (j + 1 != table.GetColumns()) str += ", ";
                    }
                    str += "}";

                    mainValues.Add("K" + (l).ToString() + ":" + str + " - ");
                    l++;
                    lastValue += "(";
                    for (int j = 0; j < table.GetColumns(); j++)
                    {
                        if (table.GetCell(i, j).GetValue() == "1") mainValues[mainValues.Count - 1] += table.GetCell(0, j).GetValue();
                        else mainValues[mainValues.Count - 1] += "¬" + table.GetCell(0, j).GetValue();

                        if (table.GetCell(i, j).GetValue() == "1") lastValue += table.GetCell(0, j).GetValue();
                        else lastValue += "¬" + table.GetCell(0, j).GetValue();
                    }
                    lastValue += ")";

                    lastValue += "  ∨  ";
                    values += str;
                }
            }
            lastValue = lastValue.Remove(lastValue.Length - 5);
        }
    }
}