using System;
using System.IO;

namespace CompilerScloud {
    public static class FileHelper {
        public static void Write(string fileName, string content) {
            if(File.Exists(fileName)) {
                File.Delete(fileName);
            }
            File.Create(fileName,);
            using(StreamWriter streamWriter = new StreamWriter(fileName)) {
                streamWriter.WriteLine(content);
            }
        }
    }
}
