using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace CompilerScloud {
    public class MatrixCreator {
        string[] lines;
        public MatrixCreator(string[] lines) {
            this.lines = lines;
        }
        public string[,] Creating() {
            MatrixDimensionCalculator num = new MatrixDimensionCalculator();
            int Width = num.GetWidth(lines);
            int Height = num.GetHeight(lines);

            string[,] arr = new string[Width, Height];
            int j = 0;
            int i = 0;

            for(int count = 0 ; count < lines.Length ; count++) {

                if(lines[count] == "") {
                    j = 0;
                    i++;
                } else {
                    arr[i, j] = lines[count];
                    j++;

                }
            }
            return arr;
        }
    }
}