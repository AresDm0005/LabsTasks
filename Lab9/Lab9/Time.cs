using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9
{
    class Time
    {
        private int hours;
        private int minutes;
        private static int count = 0;

        public int Hours
        {
            get { return hours; }
            private set
            {
                if (value < 0)
                {
                    hours = 0;
                    minutes = 0;
                }
                else hours = value;
            }
        }

        public int Minutes
        {
            get { return minutes; }
            private set
            {
                if (value < 0)
                {
                    value = -value;
                    if(value < hours * 60)
                    {
                        hours -= (value - 1) / 60 + 1;
                        minutes = 60 - value % 60;
                    }
                    else
                    {
                        minutes = 0;
                        hours = 0;
                    }
                }
                else if (value >= 60)
                {
                    minutes = value;
                    hours += minutes / 60;
                    minutes %= 60;
                }
                else minutes = value;
            }
        }

        public int Count
        {
            get { return count; }
            private set { count = value; }
        }

        public Time() : this(0, 0) { }

        public Time(int hours, int minutes)
        {
            Hours = hours;
            Minutes = minutes;
            Count++;
        }

        public void Show()
        {
            Console.WriteLine($"{Hours} ч {Minutes} мин.");
        }

        public static Time DeductTime(Time t1, Time t2)
        {
            Time tmp = new Time();
            tmp.Hours = t1.Hours - t2.Hours;
            tmp.Minutes = t1.Minutes - t2.Minutes;
            return tmp;
        }

        public Time DeductTime(Time t)
        {
            Time tmp = new Time(this.Hours -= t.Hours, this.Minutes - t.Minutes);
            return tmp;
        }

        public override string ToString()
        {
            return $"{Hours} ч {Minutes} мин.";
        }
    }
}
