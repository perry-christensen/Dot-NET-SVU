using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sticks_abstract_form
{
    public partial class Game : Form
    {
        Program p = new winFormSolution();
        public Game()
        {
            InitializeComponent();
            listBox1.Items.Add(p.strRemove());
        }

        private void board_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(p.strRemove());
        }
    }
}
