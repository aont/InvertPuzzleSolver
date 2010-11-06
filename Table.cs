using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Aont
{
    public class Table
    {
        public string Show()
        {
            StringBuilder sz = new StringBuilder();
            var Clicked = this.Clicked;
            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Column; j++)
                {
                    var Clicked_ij = Clicked[i, j];
                    if (Clicked_ij) { sz.Append('1'); } else { sz.Append('0'); }
                } sz.Append('\n');
            }
            return sz.ToString();
        }

        public bool[,] Clicked { get; private set; }
        public bool[,] Checked { get; private set; }
        public int Row { get; private set; }
        public int Column { get; private set; }

        public Table(int Row, int Column)
        {
            this.Row = Row;
            this.Column = Column;
            bool[,] Clicked = this.Clicked = new bool[Row, Column];
            bool[,] Checked = this.Checked = new bool[Row, Column];

        }

        public void Click(int i, int j)
        {
            bool[,] Clicked = this.Clicked;
            bool[,] Checked = this.Checked;

            Clicked[i, j] = !Clicked[i, j];
            Checked[i, j] = !Checked[i, j];
            if (i > 0) Checked[i - 1, j] = !Checked[i - 1, j];
            if (i < Row - 1) Checked[i + 1, j] = !Checked[i + 1, j];
            if (j > 0) Checked[i, j - 1] = !Checked[i, j - 1];
            if (j < Column - 1) Checked[i, j + 1] = !Checked[i, j + 1];
        }

        public bool CheckComplete()
        {
            bool[,] Checked = this.Checked;
            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Column; j++)
                {
                    if (!Checked[i, j])
                        return false;
                }
            }
            return true;
        }
        public Table(Table Copy)
        {
            int Row = this.Row = Copy.Row;
            int Column = this.Column = Copy.Column;

            bool[,] Clicked = Copy.Clicked;
            bool[,] Checked = Copy.Checked;
            bool[,] newClicked = this.Clicked = new bool[Row, Column];
            bool[,] newChecked = this.Checked = new bool[Row, Column];


            for (int j = 0; j < Column; j++)
            {
                newClicked[0, j] = Clicked[0, j];
                newChecked[0, j] = Checked[0, j];
            }
            for (int j = 0; j < Column; j++)
            {
                newChecked[1, j] = Checked[1, j];
            }
        }



        public Bitmap Save()
        {
            Bitmap bmp = new Bitmap(Column, Row);
            var Clicked = this.Clicked;
            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Column; j++)
                {
                    var Clicked_ij = Clicked[i, j];
                    if (!Clicked_ij)
                        bmp.SetPixel(j, i, Color.White);
                    else
                        bmp.SetPixel(j, i, Color.Black);
                }
            }

            return bmp;
            

        }

    }
}
