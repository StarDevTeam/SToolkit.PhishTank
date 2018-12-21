using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace SToolkit.PhishTank.CoreDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            PhishTankApi api = new PhishTankApi("API_KEY_HERE");
            var res = api.Check("http://yandex.ru");
            Console.WriteLine($"Url: {res.Url}");
            Console.WriteLine($"InDatabase: {res.InDatabase}");
            Console.WriteLine($"IsPhish: {res.IsPhish}");
            Console.WriteLine($"PhishID: {res.PhishID}");
            Console.WriteLine($"PhishPage: {res.PhishPage}");
            Console.WriteLine($"Verified: {res.Verified}");
            Console.WriteLine($"VerifiedDate: {res.VerifiedDate}");
            Console.ReadLine();
        }
    }
}
