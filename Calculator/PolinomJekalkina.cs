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

        private List<string> functions = new List<string>();
        private List<string> content1 = new List<string>();

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


            windowsPolinom = new WindowPolinom(functions, content1);

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
        private void CalculatePolinom()
        {
            string firstLine = "f(";
            for (int i = 0; i < table.GetColumns(); i++)
            {
                firstLine += table.GetCell(0, i).GetValue();
                if (i + 1 != table.GetColumns()) firstLine += ", ";
            }
            firstLine += ")";
            functions.Add(firstLine);

            string forContent1 = "";
            for (int i = 1; i < tableSolved.GetRows() + 1; i++)
            {
                string str = "f(";
                forContent1 = "";
                for (int j = 0; j < tableSolved.GetColumns() + 1; j++)
                {
                    str += table.GetCell(i, j).GetValue();
                    forContent1 += table.GetCell(i, j).GetValue();
                    if (j + 1 != table.GetColumns()) str += ", ";
                }
                str += ")";

                content1.Add((content1.Count - 1 >= 0 ? content1[content1.Count - 1] : "") + (i != 1 ? " ⊕ " : "") + "a" + forContent1);
                functions.Add(str);
            }
        }



    }



}
