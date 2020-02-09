using System;

namespace Lab9
{
    public class Time
    {
        // Part 1
        private int hours;
        private int minutes;
        private static int count = 0;
        private int negHoursCheck = 0;

        public int Hours
        {
            get { return hours; }
            private set
            {
                if (value < 0)
                {
                    hours = 0;
                    minutes = 0;
                    negHoursCheck = value;
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
                    if (value < hours * 60)
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
                else
                {
                    minutes = value;
                    if (negHoursCheck < 0)
                    {
                        minutes -= Math.Abs(negHoursCheck) * 60;

                    }
                    hours += minutes / 60;
                    minutes %= 60;
                }

                negHoursCheck = 0;
            }
        }

        public static int Count
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
            Time tmp = new Time(this.hours - t.hours, this.minutes - t.minutes);
            return tmp;
        }

        public override string ToString()
        {
            return $"{Hours} ч {Minutes} мин.";
        }

        // Part 2
        public static Time operator ++(Time t)
        {
            t.Minutes++;
            return t;
        }

        public static Time operator --(Time t)
        {
            t.Minutes--;
            return t;
        }

        public static implicit operator int(Time t)
        {
            return t.Hours * 60 + t.Minutes;
        }

        public static explicit operator bool(Time t)
        {   
            return (t.hours != 0 && t.minutes != 0);
        }

        public static bool operator <(Time left, Time right)
        {
            return (int)left < (int)right;            
        }

        public static bool operator >(Time left, Time right)
        {
            return (int)left > (int)right;
        }

        // Test Required
        public override bool Equals(Object obj)
        {
            // Проверка на null и соответствие типов
            if (obj == null || !this.GetType().Equals(obj.GetType())) return false;
            else
            {
                Time time = (Time)obj;
                return (minutes == time.minutes && hours == time.hours);
            }
        }

        public override int GetHashCode()
        {
            return hours * 60 + minutes;
        }
    }
}