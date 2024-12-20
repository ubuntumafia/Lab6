using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    public class FractionCache
    {
        private double? cachedValue;

        public double GetCachedValue(int numerator, int denominator)
        {
            if (!cachedValue.HasValue)
            {
                cachedValue = (double)numerator / denominator; // Кэшируем значение
            }
            return cachedValue.Value;
        }

        public void InvalidateCache()
        {
            cachedValue = null; // Сбрасываем кэш
        }
    }

}
