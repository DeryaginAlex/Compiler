﻿using System;
using System.Collections.Generic;
using System.IO;

namespace CompilerScloud {
    class Program {
        static void Main(string[] args) {
            string errorFileName = "bad_data.txt";
            string fileNameFormat = "base_{0}.txt";
            
            if(args[0] == null) {
                Console.WriteLine("Путь к файлу не найден. Он должен идти аргументом командной строки.");
            }
            string filePath = Path.GetFullPath(args[0]);
            string text = File.ReadAllText(filePath);
            if(string.IsNullOrEmpty(text)) {
                Console.WriteLine("Файл пуст");
            }

            Compiler compiler = new Compiler();
            string[] objects = compiler.GetObjects(text);
            
            StreamWriter errorFile = new StreamWriter(errorFileName); ;
            if(!File.Exists(errorFileName)) {
                //если нет файла то создаем его
            }

            for(int i = 0 ; i < objects.Length ; i++) {
                if(compiler.IsValid(objects[i])) {
                    string fileName = string.Format(fileNameFormat, i.ToString());
                    //записываем корректные данные
                } else {
                    //записывваем ошибочные данные 
                }
            }                      
            Console.ReadKey();
        }
    }
}
