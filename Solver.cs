using System;
using System.Collections.Generic;
using System.Text;

namespace Aont
{
    public class Solver
    {
        public static Table[] Solve(int Row, int Column)
        {
            return (new Solver(Row, Column)).Start();
        }

        private int Row, Column;

        private Solver(int Row, int Column)
        {
            this.Row = Row; this.Column = Column;
            this.Solutions = new List<Table>();
        }

        bool Searched;
        List<Table> Solutions;
        private Table[] Start()
        {
            if (!this.Searched)
            {
                FirstRowTree(new Table(Row, Column), 0);
                this.Searched = true;
            }
            return this.Solutions.ToArray();
        }
        private void FirstRowTree(Table table, int j)
        {
            if (j < Column)
            {
                Table table1 = new Table(table);
                table1.Click(0, j);
                FirstRowTree(table, j + 1);
                FirstRowTree(table1, j + 1);

            }
            else if (j == Column)
            {
                Complete(table);
                if (BottomRowCheckComplete(table))
                {
                    Solutions.Add(table);
                }
            }
        }

        private bool BottomRowCheckComplete(Table table)
        {
            int Row = this.Row;
            for (int j = 0; j < Column; j++)
            {
                if (!table.Checked[Row - 1, j])
                    return false;
            }
            return true;
        }
        private void Complete(Table table)
        {
            for (int i = 1; i < Row; i++)
            {
                DeleteMethod(table, i);
            }
        }

        private void DeleteMethod(Table table, int i)
        {
            for (int j = 0; j < Column; j++)
            {
                if (!table.Checked[i - 1, j])
                    table.Click(i, j);
            }
        }

    }

}
