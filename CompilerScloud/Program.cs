using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CompilerScloud {
    class Program {
        static void Main(string[] args) {
            string[] fileName = File.ReadAllLines("input.txt");
           
            TheNumberOfPartsOfTheFile num = new TheNumberOfPartsOfTheFile();
            Console.WriteLine(num.GetNum(fileName));

            string[,] parts= new string[4, 4];
            int j = 0;
            
            int i = 0;
            for(int count = 0 ; count < fileName.Length ; count++) {
               
                if(fileName[count] == "") {
                    j = 0;
                    i++;    
                } else {
                    parts[i,j] = fileName[count];
                    j++;
                }

            }





            //HeaderCheck
            string heading = parts[0, 0];
            string firstCharacter = heading.Substring(0,1);
            string lastCharacter = heading.Substring( heading.Length-1, 1);

            char[] separators = new char[] { '[', ']' };
            string[] basicCharacters = heading.Split(separators, StringSplitOptions.RemoveEmptyEntries);


            if(firstCharacter != "[" || lastCharacter != "]" || basicCharacters[0] == "") {
                Console.WriteLine("Ошибка №1, Неправильно сформирован заголовок");
            }


            //CheckRequiredParameterConnect
            string parameterConnect = parts[0, 2];
            string thisIsConnect = parameterConnect.Substring(0, 7);
            if(thisIsConnect== "Connect") {
                Console.WriteLine("Строка\n"+ parameterConnect + "\nСодержит обязательный параметр Connect") ;
            } else {
                Console.WriteLine("Строка\n" + parameterConnect + "\nНЕ содержит обязательный параметр Connect");
            }


            //CheckWay
            string way = "C:\\Documents\\Newsletters\\Summer2018.pdf";
            Console.WriteLine(way);


            Console.ReadKey();
        }
    }
}
