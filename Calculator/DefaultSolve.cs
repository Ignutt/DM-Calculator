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
    public partial class DefaultSolve : Form
    {
        string str;
        VariablesAlphabet variablesAlphabet = new VariablesAlphabet();
        SignsAlphabet signsAlphabet = new SignsAlphabet();
        InputString inputString;
        Table table;
        TableSolved tableSolved;
        Solve solve = new Solve();

        SolvingString solvingString;

        List<List<TableCell>> _table = new List<List<TableCell>>();


        public DefaultSolve(string input)
        {
            InitializeComponent();
            str = input;
            inputString = new InputString(input);
            solvingString = new SolvingString(input);

            table = new Table(Math.Pow(2, inputString.GetVariablesCount(str)), inputString.GetVariablesCount(str), str);
            tableOut.Size = new Size(inputString.GetVariablesCount(str) * 50 + 15 * inputString.GetVariablesCount(str), 
                tableOut.Size.Height);


            tableSolved = new TableSolved(Math.Pow(2, inputString.GetVariablesCount(str)), solvingString.GetStepsList().Count, str,
                table);
            tableOutFunc.Size = new Size(solvingString.GetStepsList().Count * 120 + 15 * solvingString.GetStepsList().Count,
                tableOut.Size.Height);
            tableOutFunc.Location = tableOut.Location + new Size(tableOut.Size.Width + 2, 0);


            Solve();
        }

        private void Solve()
        {
            for (int i = 0; i < table.GetRows() + 1; i++)
            {
                for (int j = 0; j < table.GetColumns(); j++)
                {
                    tableOut.Controls.Add(table.GetCell(i, j));
                }
            }

            for (int i = 0; i < tableSolved.GetRows() + 1; i++)
            {
                for (int j = 0; j < tableSolved.GetColumns(); j++)
                {
                    tableOutFunc.Controls.Add(tableSolved.GetCell(i, j));
                }
            }
        }
    }


}
