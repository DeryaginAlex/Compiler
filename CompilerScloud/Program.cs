using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CompilerScloud {
    class Program {
        static void Main(string[] args) {
            string[] FileName = File.ReadAllLines("input.txt");
           
            TheNumberOfPartsOfTheFile num = new TheNumberOfPartsOfTheFile();
            Console.WriteLine(num.GetNum(FileName));

            string[,] Parts= new string[4, 4];
            int j = 0;
            
            int i = 0;
            for(int count = 0 ; count < FileName.Length ; count++) {
               
                if(FileName[count] == "") {
                    j = 0;
                    i++;    
                } else {
                    Parts[i,j] = FileName[count];
                    j++;
                }

            }





            //HeaderCheck
            string Heading = Parts[0, 0];
            string FirstCharacter = Heading.Substring(0,1);
            string LastCharacter = Heading.Substring( Heading.Length-1, 1);

            char[] Separators = new char[] { '[', ']' };
            string[] BasicCharacters = Heading.Split(Separators, StringSplitOptions.RemoveEmptyEntries);


            if(FirstCharacter != "[" || LastCharacter != "]" || BasicCharacters[0] == "") {
                Console.WriteLine("Ошибка №1, Неправильно сформирован заголовок");
            }


            //CheckRequiredParameterConnect
            string ParameterConnect = Parts[0, 2];
            string ThisIsConnect = ParameterConnect.Substring(0, 7);
            if(ThisIsConnect== "Connect") {
                Console.WriteLine("Строка\n"+ ParameterConnect + "\nСодержит обязательный параметр Connect") ;
            } else {
                Console.WriteLine("Строка\n" + ParameterConnect + "\nНЕ содержит обязательный параметр Connect");
            }


            //CheckWay
            string Way = "C:\\Documents\\Newsletters\\Summer2018.pdf";
            Console.WriteLine(Way);

            if(Way == ) {

            }

            Console.ReadKey();
        }
    }
}
