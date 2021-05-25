using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    public class Algorithm
    {
        public static int len;
        public static int[] arr;
        public static int max;
        public static int FindOfMax(int len, int[] array)
        {
            int maxN = array[0];
            for(int i = 0; i < len; i++)
            {
                if (maxN < array[i]) maxN = array[i];
            }
            return maxN;
        }
    }
}
