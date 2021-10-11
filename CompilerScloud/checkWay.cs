using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompilerScloud {
    class checkWay {
        public void check(string[,] twoDimensionalArray) {
            //CheckWay
            string Way = "C:\\Doc*uments\\Newsletters\\Summer2018.pdf";
            Console.WriteLine(Way);
            char[] collection = { '\'', '/', ':', '*', '?', '"', '<' };
            foreach(char item in collection) {
                if(Way.Contains(item) == true)
                    Console.WriteLine("Way.Contains {0}", item);
            }
        }
        }
}
