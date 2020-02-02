using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    [Serializable]
    public struct IncomeId
    {
        public string name { get; set; }
        public int index { get; set; }

        public IncomeId(string name, int index)
        {
            this.name = name;
            this.index = index;
        }

        public static bool operator ==(IncomeId id1, IncomeId id2)
        {
            return (id1.name == id2.name && id1.index == id2.index);
        }

        public static bool operator !=(IncomeId id1, IncomeId id2)
        {
            return !(id1.name == id2.name && id1.index == id2.index);
        }
    }

    [Serializable]
    public class Firm
    {
        public const string depToRemove = "deletedDepartment";   // Идентификатор удаленного подразделения
        public const string incomeIdToRemove = "deletedIncome";  // Идентификатор удаленного индексатора дохода (название)
        public const int incomeIndexToRemove = -1;               // Идентификатор удаленного индексатора дохода (индекс)

        #region dateVariables
        public int startYear { get; private set; }
        public int endYear { get; private set; }
        public int startMonth { get; private set; }
        public int endMonth { get; private set; }
        public int yearSpan { get; private set; }
        #endregion
        public double averageIncome { get; private set; }

        public string name { get; private set; }                 // Название фирмы

        public string[] actualDepartmentNames;                   // Названия существующих (т.е. не удаленных) подразделений
        private Dictionary<string, Department> departments;      // Словарь отделений
        private IncomeId[] incomeRecords;                        // Массив записей о доходах
        private string[] departmentRecords;                      // Массив записей о подразделениях

        public int departCount { get; private set; }             // Счетчик актуальных подразделений
        public int departmentRecordCounter { get; private set; } // Нумерация записей для подразделений 
        public int incomeRecordCounter { get; private set; }     // Нумерация записей для месячных доходов

        private int toDeleteIncomeCount;                         // Счетчик удаленных записей для доходов
        private int toDeleteDepartmentsCount;                    // Счетчик удаленных подразделений

        public Firm() { }

        public Firm(string name, DateTime date)
        {
            this.name = name;

            startMonth = date.Month;
            endMonth = (date.Month == 1) ? 12 : date.Month - 1;

            startYear = date.Year - 5;
            endYear = (date.Month == 1) ? date.Year - 1 : date.Year;
            yearSpan = endYear - startYear + 1;

            departments = new Dictionary<string, Department>();
            incomeRecords = new IncomeId[0];
            departmentRecords = new string[0];

            actualDepartmentNames = new string[0];
            departCount = 0;
            averageIncome = 0;



            departmentRecordCounter = 0;
            toDeleteIncomeCount = 0;
            toDeleteDepartmentsCount = 0;
        }

        #region ActionsWithDepartments
        public void AddDepartment(string name, int pos)
        {

            Department dep = new Department(name, yearSpan, startMonth);
            departments.Add(dep.name, dep);

            departmentRecordCounter++;
            departCount++;

            string[] tmp = new string[departmentRecordCounter];
            for (int i = 0; i < pos; i++) tmp[i] = departmentRecords[i];
            tmp[pos] = name;
            for (int i = pos + 1; i < departmentRecordCounter; i++) tmp[i] = departmentRecords[i - 1];

            departmentRecords = tmp;

            Array.Resize(ref actualDepartmentNames, departCount);
            actualDepartmentNames[departCount - 1] = name;
        }

        public void DeleteDepartment(string name)
        {
            // Коррекция актуальных названий
            string[] tmp = new string[departCount - 1];
            int index = 0;
            for (int i = 0; i < departCount; i++)
            {
                if (actualDepartmentNames[i] != name) tmp[index++] = actualDepartmentNames[i];
            }
            actualDepartmentNames = tmp;

            // Установка записи подразделения под удаление
            index = Array.IndexOf(departmentRecords, name);
            departmentRecords[index] = depToRemove;
            toDeleteDepartmentsCount++;

            // Установка записей дохода под удаление
            for (int i = 0; i < incomeRecordCounter; i++)
            {
                if (incomeRecords[i].name == name)
                {
                    IncomeId id = new IncomeId(incomeIdToRemove, incomeIndexToRemove);
                    incomeRecords[i] = id;
                    toDeleteIncomeCount++;
                }
            }

            // Удаление из текущего словаря
            departments.Remove(name);
        }

        public void DeleteDepartment(int key)
        {
            DeleteDepartment(departmentRecords[key]);
        }

        public string GetDepartmentName(int key)
        {
            return departmentRecords[key];
        }

        public void ChangeDepartmentName(int key, string rename)
        {
            ChangeDepartmentName(departmentRecords[key], rename);
        }

        public void ChangeDepartmentName(string name, string rename)
        {
            // Изменение в массиве названий
            int index = Array.IndexOf(actualDepartmentNames, name);
            actualDepartmentNames[index] = rename;

            // Изменение в массиве записей подразделений
            index = Array.IndexOf(departmentRecords, name);
            departmentRecords[index] = rename;

            // Изменение в массиве записей доходов
            for (int i = 0; i < incomeRecordCounter; i++)
            {
                if (incomeRecords[i].name == name) incomeRecords[i].name = rename;
            }

            // Изменение в словаре подразделения
            departments[name].name = rename;
            departments.Add(rename, departments[name]);
            departments.Remove(name);
        }
        #endregion

        #region AdjustmentsToIncome
        public void SetIncome(string name, int index, double income, int pos)
        {
            IncomeId id = new IncomeId(name, index);

            incomeRecordCounter++;
            IncomeId[] tmp = new IncomeId[incomeRecordCounter];
            for (int i = 0; i < pos; i++) tmp[i] = incomeRecords[i];
            tmp[pos] = id;
            for (int i = pos + 1; i < incomeRecordCounter; i++) tmp[i] = incomeRecords[i - 1];

            incomeRecords = tmp;
            departments[name].SetIncome(income, index);
        }

        public void ChangeIncome(string name, int index, double income)
        {
            departments[name].SetIncome(income, index);
        }

        public void ChangeIncome(int key, double income)
        {
            ChangeIncome(incomeRecords[key].name, incomeRecords[key].index, income);
        }

        public void DeleteIncome(string name, int index)
        {
            IncomeId id = new IncomeId(name, index);

            departments[name].SetIncome(Department.INCOME_TO_REMOVE, index);

            toDeleteIncomeCount++;
            departments[name].SetIncome(Department.INCOME_TO_REMOVE, index);


            if (toDeleteIncomeCount > 0.5 * departmentRecordCounter && toDeleteDepartmentsCount >= 2)
            {
                ClearBucket();
            }
        }

        public void DeleteIncome(int key)
        {
            DeleteIncome(incomeRecords[key].name, incomeRecords[key].index);
        }

        public IncomeId GetIncomeId(int key)
        {
            return incomeRecords[key];
        }

        public bool IsIncomeValid(string name, int index)
        {
            return !IsIncomeDeleted(name, index) && IsIncomeSet(name, index);
        }

        public bool IsIncomeDeleted(string name, int index)
        {
            return departments[name].GetIncome(index) == Department.INCOME_TO_REMOVE;
        }

        public bool IsIncomeSet(string name, int index)
        {
            return !(departments[name].GetIncome(index) == Department.BASE_INCOME_VALUE);
        }
        #endregion

        public int GetCurrentMonth(int index)
        {
            return (index + startMonth) % 12;
        }

        public int GetCurrentYear(int index)
        {
            return (index + startMonth - 1) / 12 + startYear;
        }

        public void Task1()
        {
            foreach (string name in actualDepartmentNames)
            {
                departments[name].CountAnnualIncome();
            }
        }

        public void Task2()
        {
            double avgInc = 0;
            int count = 0;
            foreach (string name in actualDepartmentNames)
            {
                count++;
                departments[name].CountAnnualIncome();

                double inc = 0;
                for (int i = 0; i < yearSpan; i++)
                {
                    inc += departments[name].annualIncome[i];
                }
                avgInc += inc / 60;
            }

            if (count > 0)
                avgInc /= count;

            this.averageIncome = avgInc;

            foreach (string name in actualDepartmentNames)
            {
                if (name != Firm.depToRemove)
                {
                    departments[name].firmAverageIncome = averageIncome;
                    departments[name].LongestLowerAverageIncomePeriod();
                }
            }
        }

        public Department GetDepartment(string name)
        {
            return departments[name];
        }

        private void ClearBucket()
        {
            int newSize = 0;
            for (int i = 0; i < incomeRecordCounter; i++)
            {
                if (incomeRecords[i].name != incomeIdToRemove)
                {
                    newSize++;
                }
            }

            IncomeId[] newIncId = new IncomeId[newSize];
            int k = 0;
            for (int i = 0; i < incomeRecordCounter; i++)
            {
                if (incomeRecords[i].name != incomeIdToRemove)
                {
                    newIncId[k++] = incomeRecords[i];
                }
                else
                {
                    departments[incomeRecords[i].name].SetIncome(Department.BASE_INCOME_VALUE, incomeRecords[i].index);
                }
            }

            newSize = 0;
            for (int i = 0; i < departmentRecordCounter; i++)
            {
                if (departmentRecords[i] != depToRemove)
                {
                    newSize++;
                }
            }

            string[] newDepRecord = new string[newSize];
            k = 0;
            for (int i = 0; i < departmentRecordCounter; i++)
            {
                if (departmentRecords[i] != depToRemove)
                {
                    newDepRecord[k++] = departmentRecords[i];
                }
            }

            Dictionary<string, Department> newDeps = new Dictionary<string, Department>();

            foreach (string name in actualDepartmentNames)
            {
                if (name != depToRemove)
                {
                    newDeps[name] = departments[name];
                }
            }

            departments = newDeps;
            departmentRecords = newDepRecord;
            incomeRecords = newIncId;
            actualDepartmentNames = newDepRecord;

            departmentRecordCounter = departmentRecords.Length;
            incomeRecordCounter = incomeRecords.Length;
            departCount = departmentRecordCounter;

            toDeleteDepartmentsCount = 0;
            toDeleteIncomeCount = 0;
        }
    }
}
