using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evade
{
    static class TriFuncTable
    {
        static float[] sin_table = new float[720];
        static float[] tan_table = new float[720];
        public static void LoadTable()
        {
            for (int i = 0; i < 720; i++)
            {
                sin_table[i] = (float)Math.Sin(0.5*i*Math.PI/180);
            }
            for (int i = 0; i < 720; i++)
            {
                tan_table[i] = Sin(1.0f * i / 2.0f) / Cos(1.0f * i / 2.0f + 90.0f);
            }
        }
        public static float Sin(float d)
        {
            int index = (int)(d * 2.0);
            index %= 720;
            if (index < 0)
            {
                index = 720 + index;
            }
            return sin_table[index];
        }
        public static float Cos(float d)
        {
            d += 90.0f;
            int index = (int)(d * 2.0);
            index %= 720;
            if (index < 0)
            {
                index = 720 + index;
            }
            return sin_table[index];
        }
        public static float Tan(float d)
        {
            int index = (int)(d * 2.0);
            index %= 720;
            if (index < 0)
            {
                index = 720 + index;
            }
            return tan_table[index];
        }
        
    }
}
