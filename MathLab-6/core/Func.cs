using System;
using AngouriMath.Extensions;

namespace MathLab_6.core
{
    public class Func
    {
        // переменная хранит текстовое значение функции
        private String _func;
        // переменная хранит в себе значение точности 
        private int _celling;

        public Func(string func, int celling = 5)
        {
            _func = func;
            _celling = celling;
        }

        // принимает на хвод значение аргумента и приминяет его к функции
        public Double Invoke(Double value)
        {
            // тут получаем значение функции из библиотеки, а дальше тупо работа с точностьюи избавлением от дроби
            var fResult = _func.Substitute("x", value).Evaled.ToString();
            string sResult;

            if (!fResult.Contains('/'))
            {
                sResult = Celling(Double.Parse(fResult.Replace('.', ','))).ToString();
                return Celling(Double.Parse(sResult));
            }
            else
            {
                var args = fResult.Split('/');
                sResult = (Celling(Double.Parse(args[0].Replace('.', ',')))
                           / Celling(Double.Parse(args[1].Replace('.', ',')))).ToString();
                return Celling(Double.Parse(sResult));
            }
        }

        // Округление с точностью (возникали ошибки, так что в отдельный метод выделил)
        private Double Celling(Double value)
        {
            var args = value.ToString().Split(',');
            if (args.Length > 1 && args[1].Length <= _celling) return Math.Round(value, args[1].Length - 1);
            return Math.Round(value, _celling);
        }
    }
}