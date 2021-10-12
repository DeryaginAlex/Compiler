using System;
using System.Collections.Generic;
using System.IO;

namespace CompilerScloud {
    public class Compiler {
        public Compiler() { }

        public string[] GetObjects(string text) {
            return text.TrimEnd().Split("\r\n\r\n");
        }

        public bool IsValid(string theObject) {
            // Предпологаем что первый и второй элемент это ЗАГОЛОВОК и CONNECT
            bool result = true;
            string[] parametrs = theObject.Split("\r\n");
            if(parametrs.Length < 2) {
                return false;
            }
            string head = parametrs[0];
            result &= IsHeadValid(head);
            string connect = parametrs[1];
            result &= IsConnectValid(connect);
            if(parametrs.Length > 2) {
                for(int i = 2 ; i < parametrs.Length - 1 ; i++) {
                    result &= IsPairValid(parametrs[i]);
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
                string path = GetPath(text);
                FileInfo info = new FileInfo(path);
                //path.IndexOfAny(Path.GetInvalidPathChars()) == -1;
            } catch {
                return false;
            }
            return result;
        }

        public string GetPath(string text) {
            string firstCharacter = text.Substring(0, 1);
            string lastCharacter = text.Substring(text.Length - 2, 2);
            if(!(firstCharacter == @"""" && lastCharacter == @""";")) {
                throw new Exception();
            }
            text = text.Remove(0, 1);
            text = text.Remove(text.Length - 2, 2);
            return text;
        }                                                                                                           

        public bool IsServerValid(string text) {
            bool result = true;
            string[] items = text.Split(";", StringSplitOptions.RemoveEmptyEntries);
            if(items.Length != 2) {
                return false;
            }
            if(!IsPairValid(items[0]) || !IsPairValid(items[1])) {
                return false;
            }
            return result;
        }

        public bool IsPairValid(string theObject) {
            bool result = false;
            string[] tmp = theObject.Split("=");
            if(tmp.Length == 2 && !string.IsNullOrEmpty(tmp[0]) && !string.IsNullOrEmpty(tmp[1])) {
                result = true;
            }
            return result;
        }
    }
}
