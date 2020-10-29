using System;
using Newtonsoft.Json;
using CryptoApp.Shared;

namespace CryptoConsoleApp
{
    static class Program
    {
        static void Main(string[] args)
        {
            var blockChain = new CryptoBlockChain();
            Console.WriteLine(JsonConvert.SerializeObject(blockChain,Formatting.Indented));
            Console.WriteLine("MD5: " + blockChain.MD5());
            Console.WriteLine("Valid BlockChain?: " + blockChain.CheckValidity());


            string hash = blockChain.GetLatestBlock().Hash;
            blockChain.AddNewBlock("MORE DATA!!!", hash);
            Console.WriteLine(JsonConvert.SerializeObject(blockChain, Formatting.Indented));
            Console.WriteLine("MD5: " + blockChain.MD5());
            Console.WriteLine("Valid BlockChain?: " + blockChain.CheckValidity());


            hash = blockChain.GetLatestBlock().Hash;
            blockChain.AddNewBlock("MOAR!", hash);
            Console.WriteLine(JsonConvert.SerializeObject(blockChain, Formatting.Indented));
            Console.WriteLine("MD5: " + blockChain.MD5());
            Console.WriteLine("Valid BlockChain?: " + blockChain.CheckValidity());
        }
    }
}
