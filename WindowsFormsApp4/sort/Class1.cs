using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp4.sort
{
    class Class1
    {
        public static string ShakerSort(string temp)
        {
            char[] revmove = { ' ', '\n','\r' };
            string[] str = temp.Split(revmove);
            int kk = str.Length;
            if (str[str.Length - 1] == "")
                kk--;
            int[] mas = new int[kk];

            for (int i = 0; i < kk; i++)
                mas[i] = int.Parse(str[i]);

            bool flag = true;
            int left = 0, right = mas.Length - 1;
            while (left < right && flag)
            {
                flag = false;
                for (int i = left; i < right; i++)
                {
                    if (mas[i] > mas[i + 1])
                    {
                        Swap(mas, i, i + 1);
                        flag = true;
                    }

                }
                right--;
                for (int i = right; i > left; i--)
                {
                    if (mas[i - 1] > mas[i])
                    {
                        Swap(mas, i - 1, i);
                        flag = true;
                    }
                }
                left++;
            }

            string ans = null;
            foreach (var item in mas)
                ans += item + " ";
            return ans;
        }

        public static void Swap(int[] mas, int i, int j)
        {
            int cur = mas[i];
            mas[i] = mas[j];
            mas[j] = cur;
        }

        public static void Out(int[] mas)
        {
            for (int i = 0; i < mas.Length; i++)
                Console.Write(mas[i] + " ");
        }
    }
}
