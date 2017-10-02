using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Пример замыкания переменных цикла
//В Метода ExampleOfBadClosure происходит замыкание переменной, а не ее значение
//Так же в этом методе существует один экземпляр переменной i, 
//т.к. который изменяется на каждой итерации цикла, следовательно на выходе из цикла имеем i = 7
//В методе ExampleOfGoodClosure мы объявили переменную j и тем самым избавились от проблемы с созданием одного экз. i


namespace ClosureExample
{
    class Program
    {
        static void Main(string[] args)
        {
            BadClousure badClosure = new BadClousure();
            badClosure.ExampleOfBadClosure();
            Console.WriteLine();

            GoodClousure goodClosure = new GoodClousure();
            goodClosure.ExampleOfGoodClosure();
            Console.ReadKey();

        }
    }

    public class BadClousure
    {
        public void ExampleOfBadClosure()
        {
            Console.WriteLine("Example of bad closure:");
            var funcs = new List<Func<int>>();
            for (var i = 0; i < 7; i++)
            {
                funcs.Add(() => i);
            }

            foreach (var res in funcs)
            {
                Console.WriteLine(res());
            }
          
        }
    }

    public class GoodClousure
    {
        public void ExampleOfGoodClosure()
        {
            Console.WriteLine("Example of good closure:");
            var funcs = new List<Func<int>>();
            for (var i = 0; i < 7; i++)
            {
                var j = i;
                funcs.Add(() => j);
            }

            foreach (var res in funcs)
            {
                Console.WriteLine(res());
            }

        }
    }
}
