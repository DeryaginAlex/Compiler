using System;
using System.Collections.Generic;

namespace CompilerScloud {
    public class Compiler {
        string[,] matrix;
        public Compiler(string[] lines) {
            MatrixCreator matrixCreator = new MatrixCreator(lines);
            matrix = matrixCreator.Creating();
        }
        public List<int> Validate() {
            List<int> errors = new List<int>();

            errors.AddRange(HeadCheck(matrix));
            ConnectCheck(matrix);



            return errors;
        }
        public List<int> HeadCheck(string[,] matrix) {
            List<int> result = new List<int>() { };
            int count = matrix.GetLength(1);
            for(int i = 0 ; i < count ; i++) {
                string Heading = matrix[i, 0];
                string FirstCharacter = Heading.Substring(0, 1);
                string LastCharacter = Heading.Substring(Heading.Length - 1, 1);
                char[] Separators = new char[] { '[', ']' };
                string[] BasicCharacters = Heading.Split(Separators, StringSplitOptions.RemoveEmptyEntries);

                if(FirstCharacter != "[" || LastCharacter != "]" || BasicCharacters[0] == "") {
                    result.Add(i);
                    result.Add(0);
                }
            }

            return result;
        }

        public List<int> ConnectCheck (string[,] matrix) {
            List<int> result = new List<int>() { };
            int count = matrix.GetLength(1);

            int[,] mistake = new int[count, 2];

            for(int i = 0 ; i < count ; i++) {
                string ParameterConnect = matrix[i, 1];
                string ThisIsConnectFile = ParameterConnect.Substring(0, 14);
                string ThisIsConnectSrvr = ParameterConnect.Substring(0, 19);
                string LastCharacter = ParameterConnect.Substring(ParameterConnect.Length - 2, 1);
                
                if(ThisIsConnectFile == "Connect=File=\"" && LastCharacter == "\"") {
                    result.Add(1);
                    result.Add(i);
                }

                if(ThisIsConnectSrvr == "Connect=Srvr=\"host\"" && LastCharacter == "\"") {
                    result.Add(1);
                    result.Add(i);
                }

            }
            return result;
        }
        //public List<> GetParts();

        /*
                CheckRequiredParameterConnect parCon = new CheckRequiredParameterConnect();
                parCon.check(twoDimensionalArray);

                    checkHead head = new checkHead();
                errors = head.check(twoDimensionalArray);
        */

    }
}
