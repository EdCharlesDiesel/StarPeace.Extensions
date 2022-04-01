using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarPeaceConsole
{
 public   class NumberOfTimes
    {
        private int number;
        private int times;

        public NumberOfTimes()
        {
            this.number = 0;
            this.times = 0;
        }

        public NumberOfTimes(int num, int Times)
        {
            this.number = num;
            this.times = Times;
        }

        public int Number
        {
            get { return this.number; }
            set { this.number = value; }
        }

        public int Times
        {
            get { return this.times; }
            set { this.times = value; }
        }
    }
}
