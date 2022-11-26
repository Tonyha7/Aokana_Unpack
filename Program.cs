using System;
using System.IO;

namespace Aokana_Unpack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PRead pRead;
            Console.WriteLine("鍵入dat完整路徑（如C:\\Games\\[蒼の彼方のフォーリズム][苍之彼方的四重奏][sprite]\\Aokana_Data\\sprites.dat）:");
            String dat = Console.ReadLine();
            Console.WriteLine("鍵入輸出路徑（如F:/）:");
            String outpath = Console.ReadLine();
            //String dat = "C:\\Games\\[蒼の彼方のフォーリズム][苍之彼方的四重奏][sprite]\\Aokana_Data\\sprites.dat";
            //String outpath = "F:\\";
            pRead = new PRead(dat);
            foreach (string fileName in pRead.ti.Keys) {
            if (!Directory.Exists(outpath)){ 
                    Directory.CreateDirectory(outpath);
                }
                Directory.CreateDirectory(Path.GetDirectoryName(Path.Combine(outpath, fileName)));
                FileStream fs = new FileStream(Path.Combine(outpath, fileName), FileMode.Create, FileAccess.Write);
                BinaryWriter binaryWriter = new BinaryWriter(fs);
                byte[] array = pRead.File(fileName);
                if (array!=null)
                {
                    foreach (byte b in array)
                    {
                        binaryWriter.Write(b);
                    }
                    binaryWriter.Close();
                }
            }
        }
    }
}
