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
    public partial class CarBlankForm : Form
    {
        public CarBlankForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
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
            SqlCommand sqlCheckCommand = new SqlCommand(@"SELECT count(*) FROM Car WHERE ID = " + txtId.Text, cnn);

            Int32 newProdID = (Int32)sqlCheckCommand.ExecuteScalar();
            if (newProdID>0)
            {
                SqlCommand sqlUpdateCommand = new SqlCommand();
                return;
            }


            //SqlCommand sqlCommand = new SqlCommand(@"INSERT INTO Car VALUES (+" + txtId.Text + ", "+ txtSize.Text + ",'" + txtCompany.Text +  "', '" + txtComments.Text +"')", cnn);
            SqlCommand sqlCommand = new SqlCommand(@"INSERT INTO Car VALUES @ID, @CarSize, @CarCompany, @CarColor, Comments", cnn);

            SqlParameter sqlParameter = new SqlParameter("ID", txtId.Text);
            sqlCommand.Parameters.Add(sqlParameter);

            SqlParameter sqlParameter1 = new SqlParameter("CarSize", txtSize.Text);
            sqlCommand.Parameters.Add(sqlParameter1);
            SqlParameter sqlParameter2 = new SqlParameter("CarCompany", txtCompany.Text);
            sqlCommand.Parameters.Add(sqlParameter2);
            SqlParameter sqlParameter3 = new SqlParameter("CarColor", txtColor.Text);
            sqlCommand.Parameters.Add(sqlParameter3);
            SqlParameter sqlParameter4 = new SqlParameter("Comments", txtComments.Text);
            sqlCommand.Parameters.Add(sqlParameter4);




            sqlCommand.ExecuteScalar();

            MessageBox.Show("Succeded ! ");

            cnn.Close();
        }
    }
}
