using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class CarList : Form
    {
        public CarList()
        {
            InitializeComponent();
        }

        private void CarList_Load(object sender, EventArgs e)
        {
            CarDAL carDAL;
            carDAL = new CarDAL();
            dataGridView1.DataSource = carDAL.SelectCars(); 
            
        }
    }
}
