using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompilerScloud {
    class CheckRequiredParametert {

        public List<int> check(string[,] twoDimensionalArray) {


            List<int> res = new List<int>() { };

            for(int i = 0 ; i < 4 ; i++) {

                string ParameterConnect = twoDimensionalArray[i, 1];
                string ThisIsConnect = ParameterConnect.Substring(0, 7);
                if(ThisIsConnect != "Connect") {
                    res.Add(i);
                }

            }
            return res;
        }
    }
}
