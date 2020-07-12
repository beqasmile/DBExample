using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Car
    {
        private int id;
        private int size;
        private string company;
        private int color;
        private string comments;

        public Car(int id, int size, string company, int color, string comments)
        {
            this.id = id;
            this.size = size;
            this.company = company;
            this.color = color;
            this.comments = comments;
        }

        public int Id { get => id; set => id = value; }
        public int Size { get => size; set => size = value; }
        public string Company { get => company; set => company = value; }
        public int Color { get => color; set => color = value; }
        public string Comments { get => comments; set => comments = value; }
    }
}
