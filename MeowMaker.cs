using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    public static class MeowMaker
    {
        public static void MakeThemMeow(IMeow[] meowers)
        {
            foreach (var meower in meowers)
            {
                meower.Meow();
            }
        }
    }

}
