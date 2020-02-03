using System;

namespace Lab8
{
    [Serializable]
    public class Department
    {
        public const double BASE_INCOME_VALUE = double.MinValue;  // Начальное значение дохода
        public const double INCOME_TO_REMOVE = -0.001;            // Идентификатор удаленного дохода

        private double[] monthlyIncome;                           // Массив месячных доходов подразделения
        public double[] annualIncome;                            // Массив годовых доходов подразделения

        public string name { get; set; }                          // Название подразделения (Ключ)
        public double firmAverageIncome { get; set; }             // Средний доход по фирме (Для подсчета задания)
        public int longestIncomeFallPeriod { get; set; } = 0;

        private int startMonth;                                   // Номер начального месяца
        private int yearSpan;                                     // На сколько лет распространяются 60 мес. (5 или 6)

        public int indexStartPeriod { get; private set; }

        public Department() { }

        public Department(string name, int yearSpan, int startMonth)
        {
            this.name = name;

            monthlyIncome = new double[60];
            for (int i = 0; i < 60; i++) monthlyIncome[i] = BASE_INCOME_VALUE;

            this.startMonth = startMonth;
            this.yearSpan = yearSpan;

            annualIncome = new double[yearSpan];
            for (int i = 0; i < yearSpan; i++) annualIncome[i] = 0;
        }

        public void SetIncome(double income, int index)
        {
            monthlyIncome[index] = income;
        }

        public double GetIncome(int index)
        {
            return monthlyIncome[index];
        }

        public void DeleteIncome(int index) 
        {
            monthlyIncome[index] = INCOME_TO_REMOVE;
        }

        public void CountAnnualIncome()
        {
            int curYear = 0;
            int firstYearEnd = 12 - startMonth + 1;
            for (int i = 0; i < yearSpan; i++) annualIncome[i] = 0;

            for (int i = 0; i < 60; i++)
            {
                if (i < firstYearEnd)
                {
                    if (monthlyIncome[i] != BASE_INCOME_VALUE && monthlyIncome[i] != INCOME_TO_REMOVE)
                        annualIncome[curYear] += monthlyIncome[i];
                }
                else
                {
                    if ((i - firstYearEnd) % 12 == 0) curYear++;

                    if (monthlyIncome[i] != BASE_INCOME_VALUE && monthlyIncome[i] != INCOME_TO_REMOVE)
                        annualIncome[curYear] += monthlyIncome[i];
                }
            }
        }

        public int MaxIncomeYear()
        {
            int year = 0;
            double max = annualIncome[year];
            
            for (int i = 1; i < yearSpan; i++)
            {
                if (annualIncome[i] > max)
                {
                    max = annualIncome[i];
                    year = i;                    
                }
            }

            return year;
        }

        public double MaxIncomeValue()
        {
            double max = annualIncome[0];
            for (int i = 1; i < yearSpan; i++) max = Math.Max(max, annualIncome[i]);

            return max;
        }

        public void LongestLowerAverageIncomePeriod()
        {
            int max = 0;
            int cur = 0;

            indexStartPeriod = 0;

            int tmpIndex = 0;

            for (int i = 0; i < 60; i++)
            {
                if ((monthlyIncome[i] != BASE_INCOME_VALUE && monthlyIncome[i] != INCOME_TO_REMOVE) && (monthlyIncome[i] < firmAverageIncome))
                {
                    if (tmpIndex == -1) tmpIndex = i;
                    cur++; 
                }
                else
                {
                    if(cur > max)
                    {
                        max = cur;
                        indexStartPeriod = tmpIndex;
                        tmpIndex = -1;
                    }
                    
                    cur = 0;
                }
            }

            if (cur > max)
            {
                longestIncomeFallPeriod = cur;
                indexStartPeriod = tmpIndex;
            } else
            {
                longestIncomeFallPeriod = max;
            }
        }
    }
}
