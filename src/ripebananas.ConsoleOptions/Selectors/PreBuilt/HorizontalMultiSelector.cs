//using System;
//using System.Collections.Generic;
//using System.Linq;
//using ripebananas.ConsoleOptions.Formatters;

//namespace ripebananas.ConsoleOptions.Selectors
//{
//    public class HorizontalMultiSelector<T> : MultiSelector<T>
//    {
//        protected internal override bool OnKey(
//            ConsoleKey key,
//            IFormatter<T> formatter,
//            out IEnumerable<T> result)
//        {
//            result = Enumerable.Empty<T>();

//            return key switch
//            {
//                ConsoleKey.RightArrow => base.OnNext(formatter),
//                ConsoleKey.LeftArrow => base.OnPrevious(formatter),
//                ConsoleKey.DownArrow => false,
//                ConsoleKey.UpArrow => false,
//                _ => base.OnKey(key, formatter, out result),
//            };
//        }
//    }
//}
