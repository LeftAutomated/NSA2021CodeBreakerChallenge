using System;
using System.Text; // Encoding
using System.Linq; // Enumerable
using System.IO; //File
class Program
{

    static byte[] hexStreamToByte(string hex) {
        return Enumerable.Range(0, hex.Length)
                     .Where(x => x % 2 == 0)
                     .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                     .ToArray();
    }
    static void Main(string[] args)
    {   
        string s = File.ReadAllText("hexstream.txt");
        byte[] bytes = hexStreamToByte(s);
        byte[] dec = new byte[bytes.Length];
        byte prev = 68;
        for(var i = 0; i < bytes.Length; i++){
            prev = (byte)(bytes[i] ^ prev);
            dec[i] = prev;
        }
        Console.WriteLine(Encoding.UTF8.GetString(dec)); 
    }
}