using System;
using System.Collections.Generic;
using System.IO;

namespace CompilerScloud {
    class Program {
        static void Main(string[] args) {
            string errorFileName = "bad_data.txt";
            if(args[0] == null) {
                Console.WriteLine("Путь к файлу не найден. Он должен идти аргументом командной строки.");
            }
            string filePath = Path.GetFullPath(args[0]);
            string[] lines = File.ReadAllLines(filePath);
            if(lines == null) {
                Console.WriteLine("Файл пуст");
            }

            Compiler compiler = new Compiler(lines);
            List<int> errors = compiler.Validate();
            StreamWriter errorFile = new StreamWriter(errorFileName); ;
            if(!File.Exists(errorFileName)) {
                //если нет файла то создаем его
            }
            foreach(var item in errors) {
                errorFile.WriteLine(item);
            }

            MatrixDimensionCalculator length = new MatrixDimensionCalculator();
            int l = length.GetHeight(lines);
            string fileNameFormat = "base_{0}.txt";
            //int length = compiler.GetParts();
            for(int i = 1 ; i < l ; i++) {
                string fileName = string.Format(fileNameFormat, i.ToString());
                //тут сохраняем в файл 
            }

            Console.ReadKey();
        }
    }
}
