using System;
using System.Collections.Generic;

namespace CompilerScloud {
    public class Compiler {
        public Compiler() { }

        public string[] GetObjects(string text) {
            return text.Split("\r\n\r\n");
        }

        public bool IsValid(string theObject) {
            bool result = true;
            string[] parametrs = theObject.Split("\r\n");
            string head = parametrs[0];
            result = IsHeadValid(head);
            return result;
        }

        public bool IsHeadValid(string head) {
            bool result = false;
            string firstCharacter = head.Substring(0, 1);
            string lastCharacter = head.Substring(head.Length - 1, 1);
            char[] separators = new char[] { '[', ']' };
            string[] basicCharacters = head.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            if(firstCharacter == "[" && lastCharacter == "]") {
                head = head.Remove(0, 1);
                head = head.Remove(head.Length - 1, 1);
               result = !string.IsNullOrWhiteSpace(head);
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


                if(ParameterConnect.Length>20) {
                    if(ThisIsConnectSrvr == "Connect=Srvr=\"host\"" && LastCharacter == "\"") {
                        continue;
                    }
                    result.Add(1);
                    result.Add(i);
                }
                if(ParameterConnect.Length>15) {
                    if(ThisIsConnectFile != "Connect=File=\"" && LastCharacter == "\"") {
                        continue;
                    }
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
