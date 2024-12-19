using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    public class MeowCounter : IMeow
    {
        private Cat _cat;
        private int _meowCount;

        public MeowCounter(Cat cat)
        {
            _cat = cat;
            _meowCount = 0;
        }

        public void Meow()
        {
            _cat.Meow();
            _meowCount++;
        }

        public int GetMeowCount()
        {
            return _meowCount;
        }

        public void Meow(int n)
        {
            _cat.Meow(n);
            _meowCount += n;
        }
    }

}
