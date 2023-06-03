using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Diagnostics.Eventing.Reader;
using System.Collections;
using System.Formats.Asn1;

namespace SortingVisualizer
{
    public partial class Form1 : Form
    {
        List<int> ls = new List<int>();
        int unu, doi;
        bool green = false;
        List<int> generateNumbers(int n)
        {
            Random r = new Random();
            List<int> numberList = new List<int>();
            for (int i = 0; i < n; ++i)
            {
                int x = r.Next(1, 600);
                numberList.Add(x);
            }
            return numberList;
        }

        void renderList(List<int> list)
        {

            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = Graphics.FromImage(bmp);
            SolidBrush blackBrush = new SolidBrush(Color.Gray);
            g.FillRectangle(blackBrush, new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height));
            pictureBox1.Image = bmp;
            int rect_width = pictureBox1.Width / list.Count;
            Point p = new Point(0, 0);
            foreach (var x in list)
            {
                p.Y = pictureBox1.Height - x;
                g.FillRectangle(new SolidBrush(Color.White), new Rectangle(p, new Size(rect_width, x)));
                if (x == unu || x == doi || green == true)
                {
                    g.FillRectangle(new SolidBrush(Color.Green), new Rectangle(p, new Size(rect_width, x)));
                }
                g.DrawRectangle(new Pen(Color.Black, 2), new Rectangle(p, new Size(rect_width, x)));
                p.X += rect_width;
            }
            timer1.Start();
            pictureBox1.Image = bmp;
        }

        async void MergeSort(List<int> lista)
        {
            if (lista.Count <= 1)
                return;

            int n = lista.Count;
            int marimeSublista;
            List<int> sublistaStanga = new List<int>();
            List<int> sublistaDreapta = new List<int>();

            for (marimeSublista = 1; marimeSublista < n; marimeSublista *= 2)
            {
                for (int start = 0; start < n - 1; start += 2 * marimeSublista)
                {
                    int mijloc = Math.Min(start + marimeSublista - 1, n - 1);
                    int sfarsit = Math.Min(start + 2 * marimeSublista - 1, n - 1);

                    sublistaStanga = new List<int>(lista.GetRange(start, mijloc - start + 1));
                    sublistaDreapta = new List<int>(lista.GetRange(mijloc + 1, sfarsit - mijloc));

                    Merge(lista, sublistaStanga, sublistaDreapta, start);
                    await Task.Delay(50);
                    renderList(lista);
                }
            }
            green = true;
            renderList(lista);
            green = false;
        }

        static void Merge(List<int> lista, List<int> sublistaStanga, List<int> sublistaDreapta, int start)
        {
            int i = 0, j = 0, k = start;

            while (i < sublistaStanga.Count && j < sublistaDreapta.Count)
            {
                if (sublistaStanga[i] <= sublistaDreapta[j])
                {
                    lista[k] = sublistaStanga[i];
                    i++;
                }
                else
                {
                    lista[k] = sublistaDreapta[j];
                    j++;
                }
                k++;
            }

            while (i < sublistaStanga.Count)
            {
                lista[k] = sublistaStanga[i];
                i++;
                k++;
            }

            while (j < sublistaDreapta.Count)
            {
                lista[k] = sublistaDreapta[j];
                j++;
                k++;
            }
        }
        async void insertionsort(List<int> lista)
        {
            int n = lista.Count;

            for (int i = 1; i < n; i++)
            {
                int elementCurent = lista[i];
                int j = i - 1;

                while (j >= 0 && lista[j] > elementCurent)
                {
                    lista[j + 1] = lista[j];
                    unu = lista[j + 1];
                    doi = lista[j];
                    j--;
                }
                renderList(lista);
                await Task.Delay(100);
                lista[j + 1] = elementCurent;
            }
            green = true;
            renderList(lista);
            green = false;
        }
        async void heapsort(List<int> list)
        {
            SortedSet<int> heap = new SortedSet<int>(list);

            list.Clear();
            await Task.Delay(100);
            foreach (var element in heap)
            {
                list.Add(element);
                unu = element;
                renderList(list);
                await Task.Delay(100);
            }
            green = true;
            renderList(list);
            green = false;
        }
        async void quicksort(List<int> lista)
        {
            if (lista.Count <= 1)
                return;

            Stack<int> stiva = new Stack<int>();
            stiva.Push(0);
            stiva.Push(lista.Count - 1);

            while (stiva.Count > 0)
            {
                int dreapta = stiva.Pop();
                int stanga = stiva.Pop();

                int pivot = Partition(lista, stanga, dreapta);

                if (pivot - 1 > stanga)
                {
                    stiva.Push(stanga);
                    stiva.Push(pivot - 1);
                }

                if (pivot + 1 < dreapta)
                {
                    stiva.Push(pivot + 1);
                    stiva.Push(dreapta);
                }
                await Task.Delay(100);
                renderList(lista);
            }
            green = true;
            renderList(lista);
            green = false;
        }

        int Partition(List<int> lista, int stanga, int dreapta)
        {
            int pivot = lista[dreapta];
            int i = stanga - 1;

            for (int j = stanga; j < dreapta; j++)
            {
                if (lista[j] < pivot)
                {
                    i++;
                    Swap(lista, i, j);
                }
            }

            Swap(lista, i + 1, dreapta);
            return i + 1;
        }

        async void Swap(List<int> lista, int index1, int index2)
        {
            int temp = lista[index1];
            lista[index1] = lista[index2];
            lista[index2] = temp;
            unu = lista[index1];
            doi = lista[index2];
        }

        async void BubbleSort(List<int> list)
        {
            int n = list.Count;
            bool swapped;

            for (int i = 0; i < n - 1; i++)
            {
                swapped = false;
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (list[j] > list[j + 1])
                    {
                        unu = list[j];
                        doi = list[j + 1];
                        int temp = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = temp;
                        swapped = true;
                    }
                }
                renderList(list);
                await Task.Delay(100);
                if (!swapped)
                    break;
            }
            green = true;
            renderList(list);
            green = false;
        }
        async void countingsort(List<int> list)
        {
            int[] f = new int[1000];
            foreach (var x in list) f[x]++;
            List<int> ans = new List<int>();
            //renderList(ans);
            for (int i = 0; i <= 600; ++i)
            {
                while (f[i] > 0)
                {
                    ans.Add(i);
                    f[i]--;
                }
                if (ans.Count > 0)
                    renderList(ans);
                await Task.Delay(10);
            }
            green = true;
            renderList(ans);
            green = false;
        }
        public Form1()
        {
            InitializeComponent();

            //making combobox
            {
                comboBox1.Items.Add("bubblesort");
                comboBox1.Items.Add("mergesort");
                comboBox1.Items.Add("countingsort");
                comboBox1.Items.Add("quicksort");
                comboBox1.Items.Add("insertionsort");
                comboBox1.Items.Add("heapsort");
                comboBox1.SelectedIndex = 0;
            }
            timer1.Interval = 1000;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            trackBar1_Scroll(sender, e);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            green = false;
            unu = -1;
            doi = -1;
            ls = generateNumbers(trackBar1.Value);
            renderList(ls);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (comboBox1.SelectedItem == "bubblesort")
                BubbleSort(ls);
            else if (comboBox1.SelectedItem == "countingsort")
                countingsort(ls);
            else if (comboBox1.SelectedItem == "mergesort")
                MergeSort(ls);
            else if (comboBox1.SelectedItem == "quicksort")
                quicksort(ls);
            else if (comboBox1.SelectedItem == "insertionsort")
                insertionsort(ls);
            else
                heapsort(ls);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            trackBar1_Scroll(sender, e);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            trackBar1_Scroll(sender, e);
        }
    }
}