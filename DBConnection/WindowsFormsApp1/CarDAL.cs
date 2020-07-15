﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class CarDAL
    {
        
        private SqlConnection myConnection;
        public CarDAL()
        {
            String connetionString = "";
            connetionString = @"Server=LAPTOP-4J4IUVJ3\SQLEXPRESS;Database=DriversDB;User ID=dbconnect;Password=123456";

            myConnection = new SqlConnection(connetionString);
            try
            {
                myConnection.Open();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not open connection ! ");
            }
        }

        public List<Car> SelectCars()
        {
            using (SqlCommand command = new SqlCommand("SELECT * FROM Car ", this.myConnection))
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
                    Car newCar = new Car(reader.GetInt32(0), reader.GetString(2), reader.GetInt32(1), reader.GetInt32(3), reader.GetString(4));

                    carsList.Add(newCar);

                    //ListViewItem lvi = new ListViewItem();
                    //lvi.Text = newCar.Id.ToString() ;
                    //lvi.SubItems.Add(newCar.Company);
                    //lvi.SubItems.Add(newCar.Comments);
                    //lvi.SubItems.Add(newCar.Size.ToString());
                    //lvi.SubItems.Add(newCar.Color.ToString());
                    //listView1.Items.Add(lvi);
                }
                return new List<Car>();
            }
        }
        public void InsertCar(Car car)
        {
            //SqlCommand sqlCommand = new SqlCommand(@"INSERT INTO Car VALUES (+" + txtId.Text + ", "+ txtSize.Text + ",'" + txtCompany.Text +  "', '" + txtComments.Text +"')", cnn);
            SqlCommand sqlCommand = new SqlCommand(@"INSERT INTO Car VALUES @ID, @CarSize, @CarCompany, @CarColor, Comments", this.myConnection);

            SqlParameter sqlParameter = new SqlParameter("ID", car.Id);
            sqlCommand.Parameters.Add(sqlParameter);

            SqlParameter sqlParameter1 = new SqlParameter("CarSize", car.Size);
            sqlCommand.Parameters.Add(sqlParameter1);
            SqlParameter sqlParameter2 = new SqlParameter("CarCompany", car.Company) ;
            sqlCommand.Parameters.Add(sqlParameter2);
            SqlParameter sqlParameter3 = new SqlParameter("CarColor", car.Color);
            sqlCommand.Parameters.Add(sqlParameter3);
            SqlParameter sqlParameter4 = new SqlParameter("Comments", car.Comments);
            sqlCommand.Parameters.Add(sqlParameter4);




            sqlCommand.ExecuteScalar();
        }
        public void UpdateCar(Car car)
        {

        }
        public void DeleteCar(Car car)
        {

        }


    }
}
