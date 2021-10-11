using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace CompilerScloud {
    class checkHead {
        public int[,] check(string [,] twoDimensionalArray) {

            List<int> res = new List<int>() { };
            
            int count = twoDimensionalArray.GetLength(1);
            int[,] mistake= new int[count,2];
                                                    


            for(int i = 0 ; i < count ; i++) {

                string Heading = twoDimensionalArray[i, 0];
                string FirstCharacter = Heading.Substring(0, 1);
                string LastCharacter = Heading.Substring(Heading.Length - 1, 1);
                char[] Separators = new char[] { '[', ']' };
                string[] BasicCharacters = Heading.Split(Separators, StringSplitOptions.RemoveEmptyEntries);
               
                if(FirstCharacter != "[" || LastCharacter != "]" || BasicCharacters[0] == "") {
                    res.Add(i);
                }
            }

            for(int i = 0 ; i < res.Count ; i++) {
                mistake[i,0]= res[i];
            }

            return mistake;
        }                       
}
}
