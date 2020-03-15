using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminUniv_1
{
    public partial class Main : Form
    {
        LinkedList<Object> jointCols = new LinkedList<object>();
        public Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LinkedList<LinkedList<String>> rows = new LinkedList<LinkedList<string>>();

            LinkedList<String> r1 = new LinkedList<string>();
            r1.AddLast("Nombre");
            r1.AddLast("Apellido");
            r1.AddLast("Cedula");
            r1.AddLast("Carné");
            rows.AddLast(r1);

            LinkedList<String> r2 = new LinkedList<string>();
            r2.AddLast("Josue");
            r2.AddLast("Siles");
            r2.AddLast("101010");
            r2.AddLast("111111");
            rows.AddLast(r2);

            LinkedList<String> r3 = new LinkedList<string>();
            r3.AddLast("Gabriel");
            r3.AddLast("Duran");
            r3.AddLast("202020");
            r3.AddLast("222222");
            rows.AddLast(r3);

            showData(rows);

            jointCols.AddLast(0);
            jointCols.AddLast(3);
            jointCols.AddLast("Examen I");

            jointCols.AddLast(3);
            jointCols.AddLast(1);
            jointCols.AddLast("Examen II");

            loadCourses();
            loadGroups();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LinkedList<LinkedList<String>> rows = new LinkedList<LinkedList<string>>();

            LinkedList<String> r1 = new LinkedList<string>();
            r1.AddLast("Nombre");
            r1.AddLast("Apellido");
            r1.AddLast("Cedula");
            r1.AddLast("Carné");
            rows.AddLast(r1);

            LinkedList<String> r2 = new LinkedList<string>();
            r2.AddLast("Josue");
            r2.AddLast("Siles");
            r2.AddLast("101010");
            r2.AddLast("111111");
            rows.AddLast(r2);

            LinkedList<String> r3 = new LinkedList<string>();
            r3.AddLast("Gabriel");
            r3.AddLast("Duran");
            r3.AddLast("202020");
            r3.AddLast("222222");
            rows.AddLast(r3);

            showData(rows);
        }

        void showData(LinkedList<LinkedList<String>> rows)
        {
            grid.Rows.Clear();
            grid.Columns.Clear();
            LinkedList<String> colNames = rows.First();
            IEnumerator<String> e = colNames.GetEnumerator();
            while (e.MoveNext()) grid.Columns.Add("", "");
            IEnumerator<LinkedList<String>> e2 = rows.GetEnumerator();
            while (e2.MoveNext())
            {
                e = e2.Current.GetEnumerator();
                DataGridViewRow r = new DataGridViewRow();
                while (e.MoveNext())
                {
                    DataGridViewCell cel = new DataGridViewTextBoxCell();
                    cel.Value = e.Current;
                    r.Cells.Add(cel);
                }
                grid.Rows.Add(r);
            }
            grid.Refresh();
        }

        void loadCourses() { }
        void loadGroups() { }

        private void grid_Paint(object sender, PaintEventArgs e) {
            try {
                int columnIndex;
                int columnCount;
                String colText;
                IEnumerator<Object> en = jointCols.GetEnumerator();

                while (en.MoveNext())
                {
                    columnIndex = (int)en.Current;
                    en.MoveNext();
                    columnCount = (int)en.Current;
                    en.MoveNext();
                    colText = (String)en.Current;

                    Rectangle headerCellRectangle = grid.GetCellDisplayRectangle(columnIndex, 0, true);
                    int xCord = headerCellRectangle.Location.X;
                    int yCord = headerCellRectangle.Location.Y - grid.ColumnHeadersHeight + 1;
                    int mergedHeaderWidth = grid.Columns[columnIndex].Width - 1;
                    for (int i = columnIndex + 1; i < columnIndex + columnCount; i++) mergedHeaderWidth += grid.Columns[i].Width;
                    Rectangle mergedHeaderRect = new Rectangle(xCord, yCord, mergedHeaderWidth, grid.ColumnHeadersHeight - 2);
                    e.Graphics.FillRectangle(new SolidBrush(Color.White), mergedHeaderRect);
                    float textLen = colText.Length * grid.ColumnHeadersDefaultCellStyle.Font.SizeInPoints;
                    e.Graphics.DrawString(colText, grid.ColumnHeadersDefaultCellStyle.Font, Brushes.Black, xCord + (mergedHeaderWidth - textLen) / 2, yCord + 3);
                }
            } catch (Exception ex) {}
        }
    }
}
