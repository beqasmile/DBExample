using CarBL;
using CarCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace CarUI
{
    /// <summary>
    /// CarDataST - singleton
    /// </summary>
    public class CarDataST
    {
        private static CarDataST _instance;

        private List<Car> _cars;

        private CarDataST ()
        {
            Cars = new List<Car>();
            CarFactory carFactory;
            carFactory = new CarFactory();
            ICarServerLogic carServerLogic = carFactory.CreateCarServerLogic();
            _cars = carServerLogic.SelectCars();
        }

        public List<Car> Cars { get => _cars; set => _cars = value; }

        public static CarDataST GetInstance()
        {
            if (_instance==null)
            {
                _instance = new CarDataST();
            }
            return _instance;
        }
    }
}
