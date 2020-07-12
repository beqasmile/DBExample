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
            string connetionString = null;
            SqlConnection cnn;
            connetionString = @"Server=LAPTOP-4J4IUVJ3\SQLEXPRESS;Database=DriversDB;User ID=dbconnect;Password=123456";

            cnn = new SqlConnection(connetionString);
            try
            {
                cnn.Open();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not open connection ! ");
            }

            using (SqlCommand command = new SqlCommand("SELECT * FROM Car ", cnn))
            {
                //
                // Add new SqlParameter to the command.
                //
                //command.Parameters.Add(new SqlParameter("Name", dogName));
                //
                // Read in the SELECT results.
                //
                List<Car> carsList = new List<Car>();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Car newCar = new Car(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetInt32(3), reader.GetString(4));

                    carsList.Add(newCar);

                    //ListViewItem lvi = new ListViewItem();
                    //lvi.Text = newCar.Id.ToString() ;
                    //lvi.SubItems.Add(newCar.Company);
                    //lvi.SubItems.Add(newCar.Comments);
                    //lvi.SubItems.Add(newCar.Size.ToString());
                    //lvi.SubItems.Add(newCar.Color.ToString());
                    //listView1.Items.Add(lvi);
                }
                dataGridView1.DataSource = carsList;
            }
        }
    }
}
