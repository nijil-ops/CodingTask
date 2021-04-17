using JellyMoveLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JellyMove
{
    class Program
    {
        static void Main(string[] args)
        {
            Input objinput = new Input();
            var inputValue = objinput.GetInput();
            List<Jelly> lstJelly = objinput.ExtractInputAndGenerateResult(inputValue);
            //Display Jelly
            string output = Result.DisplayResult(lstJelly);
            Console.WriteLine(output);
            Console.Read();
        }
    }
}
