using System;
using System.Collections.Generic;

namespace CompilerScloud {
    public class Compiler {
        public Compiler() { }

        public string[] GetObjects(string text) {
            return text.Split("\r\n\r\n");
        }

        public bool IsValid(string theObject) {
            // Предпологаем что первый и второй элемент это ЗАГОЛОВОК и CONNECT
            bool result = true;
            string[] parametrs = theObject.Split("\r\n");
            if(parametrs.Length < 2) {
                return false;
            }
            string head = parametrs[0];
            result = result & IsHeadValid(head);
            string connect = parametrs[1];
            result = result & IsConnectValid(connect);
            if(parametrs.Length >2) {
                for(int i = 2 ; i < parametrs.Length-1 ; i++) {
                    result = result & IsParametrValid(parametrs[i]);
                }
             }
            return result;
        }

        private bool IsConnectValid(string connect) {
            throw new NotImplementedException();
        }

        public bool IsHeadValid(string head) {
            bool result = false;
            string firstCharacter = head.Substring(0, 1);
            string lastCharacter = head.Substring(head.Length - 1, 1);
            if(firstCharacter == "[" && lastCharacter == "]") {
                head = head.Remove(0, 1);
                head = head.Remove(head.Length - 1, 1);
               result = !string.IsNullOrWhiteSpace(head);
            }
            return result;
        }

        public List<int> ConnectCheck(string[,] matrix) {
            List<int> result = new List<int>() { };
            int count = matrix.GetLength(1);

            int[,] mistake = new int[count, 2];

            for(int i = 0 ; i < count ; i++) {
                string ParameterConnect = matrix[i, 1];
                string ThisIsConnectFile = ParameterConnect.Substring(0, 14);
                string ThisIsConnectSrvr = ParameterConnect.Substring(0, 19);
                string LastCharacter = ParameterConnect.Substring(ParameterConnect.Length - 2, 1);


                if(ParameterConnect.Length > 20) {
                    if(ThisIsConnectSrvr == "Connect=Srvr=\"host\"" && LastCharacter == "\"") {
                        continue;
                    }
                    result.Add(1);
                    result.Add(i);
                }
                if(ParameterConnect.Length > 15) {
                    if(ThisIsConnectFile != "Connect=File=\"" && LastCharacter == "\"") {
                        continue;
                    }
                    result.Add(1);
                    result.Add(i);
                }

            }
            return result;
        }

        public bool IsParametrValid(string theObject) {
            bool result = false;
            string[] tmp = theObject.Split("=");
            if(tmp.Length == 2) {
                result = true;
            }

            return result;
        }

        public bool IsPathValid(string text) {
            bool result = true;
            return result;
        }
     }
}
