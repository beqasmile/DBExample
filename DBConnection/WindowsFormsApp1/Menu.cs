﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CarBlankForm carBlankForm = new CarBlankForm();
            carBlankForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CarList carList = new CarList();
            carList.Show();
        }
    }
}
