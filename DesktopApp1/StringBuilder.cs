using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// This is the code for your desktop app.
// Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.

namespace DesktopApp1
{
    public partial class StringBuilder : Form
    {
        public StringBuilder()
        {
            InitializeComponent();
            richTextBox1.ReadOnly=true;
        }

       
        private void button1_Click(object sender, EventArgs e)
        {

         
            string s = txtstr.Text;
            if (s.Trim().Length == 0)
            {
                MessageBox.Show("Please Enter string.");
                return;
            }

            List<string> lst = new List<string>();
            foreach (var permutation in s.Permutations())
                lst.Add(string.Concat(permutation));
            label5.Text = lst.Count.ToString();
            richTextBox1.Text = string.Join("\n", lst);




        }

      

     

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            txtstr.Clear();
            label5.Text = "0";
        }
    }

    public static class EnumerableExtensions
    {
        // Source: http://stackoverflow.com/questions/774457/combination-generator-in-linq#12012418
        private static IEnumerable<TSource> Prepend<TSource>(this IEnumerable<TSource> source, TSource item)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            yield return item;

            foreach (var element in source)
                yield return element;
        }

        public static IEnumerable<IEnumerable<TSource>> Permutations<TSource>(this IEnumerable<TSource> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            var list = source.ToList();

            if (list.Count > 1)
                return from s in list
                       from p in Permutations(list.Take(list.IndexOf(s)).Concat(list.Skip(list.IndexOf(s) + 1)))
                       select p.Prepend(s);

            return new[] { list };
        }
    }
}


