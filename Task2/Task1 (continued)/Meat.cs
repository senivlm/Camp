using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    internal class Meat : Product
    {
        public MeatGradeEnum? MeatGrade { get; init; }
        public MeatTypeEnum? MeatType { get; init; }

        public Meat() { }
        public Meat(string name, decimal price, double weight, 
            MeatGradeEnum meatGrade, MeatTypeEnum meatType)
            : base(name, price, weight)
        {
            MeatType = meatType;
            MeatGrade = meatGrade;
        }

        public override string ToString()
        {
            return string.Format($"{base.ToString()}| Grade: {MeatGrade,-13}| Type: {MeatType,-10}");
        }
    }
}
