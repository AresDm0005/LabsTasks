using System;

namespace Lab8
{
    [Serializable]
    public class Income
    {
        public int recordId { get; set; }
        public int monthNo { get; set; }        
        public double monthIncome { get; set; }

        public Income() { }

        public Income(int id, int month, double income)
        {
            recordId = id;
            monthNo = month;
            monthIncome = income;
        }
    }
}