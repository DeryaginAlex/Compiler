using System.Linq;
using System.Collections.Generic;

namespace CompilerScloud {
    public class MatrixDimensionCalculator {
        List<int> errorList = new List<int>() { 0 };
        public int GetWidth(string[] lines) {
            int result = 1;
            for(int i = 0 ; i < lines.Length ; i++) {
                if(lines[i] == "") {
                    result++;
                    errorList.Add(i);
                }
            }            
            return result;
        }

        public int GetHeight(string[] lines) {
            int[] array = new int[errorList.Count];
            int[] arrayUpd = new int[errorList.Count];

            errorList.Reverse();
            array = errorList.ToArray();
            
            int count = errorList.Count - 1;
            
            for(int i = 0 ; i < count ; i++) {
                arrayUpd[i] = array[i] - array[i + 1];

            }
            int result = arrayUpd.Max();
            result = result - 1;
            return result;
        }
    }
}
