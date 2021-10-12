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
            if(parametrs.Length > 2) {
                for(int i = 2 ; i < parametrs.Length - 1 ; i++) {
                    result = result & IsParameterValid(parametrs[i]);
                }
            }
            return result;
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

        private bool IsConnectValid(string connect) {
            bool result = true;
            string[] tmp = connect.Split("=");
            if(tmp[0] != "Connect") {
                return false;
            }
            if(tmp[1] == "File" && string.IsNullOrEmpty(tmp[2])) {
                return IsPathValid(tmp[2]);
            }
            if(tmp[1] == "Srvr") {
                return IsServerValid(connect.Remove(0, 8));
            }
            return result;
        }

        public bool IsPathValid(string text) {
            bool result = true;
            try {
                string path = AddressNormalization(text);
            } catch {
                return false;                
            }
            return result;
        }

        public bool IsServerValid(string text) {
            bool result = true;
            return result;
        }

        public string AddressNormalization(string address) {
            string result = "";
            string firstCharacter = address.Substring(0, 1);
            string lastCharacter = address.Substring(address.Length - 2, 2);                 
            if(!(firstCharacter == @"""" && lastCharacter == @""";")) {
                throw new Exception();
            }
            return result;
        }
        public bool IsParameterValid(string theObject) {
            bool result = false;
            string[] tmp = theObject.Split("=");
            if(tmp.Length == 2 && !string.IsNullOrEmpty(tmp[0]) && !string.IsNullOrEmpty(tmp[1])) {
                result = true;
            }
            return result;
        }
    }
}
