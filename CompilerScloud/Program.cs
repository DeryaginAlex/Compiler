using System;
using System.IO;

namespace CompilerScloud {
    class Program {
        static void Main(string[] args) {
            Compiler compiler = new Compiler();
            string errorFileName = "bad_data.txt";
            string fileNameFormat = "base_{0}.txt";
            string errors = string.Empty;
            string filePath = Path.GetFullPath(args[0]);
            string text = File.ReadAllText(filePath);
            string[] objects = compiler.GetObjects(text);

            if(args[0] == null) {
                Console.WriteLine("Путь к файлу не найден. Он должен идти аргументом командной строки.");
            }
            if(string.IsNullOrEmpty(text)) {
                Console.WriteLine("Файл пуст");
            }
            for(int i = 0 ; i < objects.Length ; i++) {
                if(compiler.IsValid(objects[i])) {
                    string fileName = string.Format(fileNameFormat, i.ToString());
                    FileHelper.Write(fileName, objects[i]);
                } else {
                    errors = errors + objects[i] + "\r\n\r\n";
                }
            }
            if(!string.IsNullOrEmpty(errors)) {
                FileHelper.Write(errorFileName, errors);
            }
            Console.WriteLine("Game over, press any key...");
            Console.ReadKey();
        }
    }
}