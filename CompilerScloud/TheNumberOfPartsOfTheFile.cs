using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompilerScloud {
    class TheNumberOfPartsOfTheFile {
        
        public int GetNum(string[] FileName) {
            int TheNumberOfParts = 1;
            for(int i = 0 ; i < FileName.Length ; i++) {
                if(FileName[i] == "") {
                    TheNumberOfParts++;
                }
            }
            return TheNumberOfParts;                     
        
        }
    }
}
