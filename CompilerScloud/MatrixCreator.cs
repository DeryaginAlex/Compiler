using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace CompilerScloud {
    public class MatrixCreator {
        string text;
        public MatrixCreator(string text) {
            this.text = text;
        }
        public string[] Creating() {
            text = text.TrimEnd();
            string[] result = text.Split("\r\n\r\n");
            int height = 0;
            foreach(var item in result) {
                var length = item.Split("\r\n").Length;
                if(length > height) {
                    height = length;
                }
            }                         
            return result;
        }
    }
}