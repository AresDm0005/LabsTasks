using System;

namespace Lab9
{
    class TimeArray
    {
        //Part 3
        private Time[] arr;
        private int length;

        public int Length
        {
            get { return length; }
            private set {
                if (value > 0) length = value;
                else length = 0;
            }
        }

        public Time this[int index]
        {
            get { return arr[index]; }
            private set
            {
                arr[index] = value;
            }
        }

        public TimeArray()
        {
            length = 0;
            arr = new Time[0];
        }

        public TimeArray(int size)
        {
            length = size;
            arr = new Time[size];

            Random rand = new Random();
            for (int i = 0; i < length; i++)
            {
                arr[i] = new Time(rand.Next(0, 24), rand.Next(0, 60));
            }
        }

        public TimeArray(int size, Time[] times)
        {
            length = size;
            arr = new Time[size];

            for (int i = 0; i < length; i++)
            {
                arr[i] = times[i];
            }
        }

        public void Show()
        {
            foreach (Time t in arr) t.Show();
        }

        public Time MaxValue()
        {
            Time max = arr[0];
            for (int i = 1; i < length; i++)
            {
                if (arr[i] > max) max = arr[i];
            }
            return max;
        }
    }
}
