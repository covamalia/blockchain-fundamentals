using System;
using System.Runtime.Serialization.Json;
using System.Text;
using Newtonsoft.Json;

namespace CryptoApp.Shared
{
    public class CryptoBlock {
        public CryptoBlock(int index, string data, string previousHash, DateTime utcNow)
        {
            this.Index = index;
            this.Data = data;
            this.PreviousHash = previousHash;
            this.Timestamp = utcNow;
            this.Hash=GetHash();
        }
        public readonly int Index;
        public readonly string Data;
        public readonly string Hash;
        public readonly string PreviousHash;
        public readonly DateTime Timestamp;

        public string GetHash() {
            string convertString = this.Index.ToString() + PreviousHash + Timestamp.ToLongDateString() + JsonConvert.SerializeObject(Data);
            var crypt = new System.Security.Cryptography.SHA256Managed();
            var hash = new System.Text.StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(convertString));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString();
        }
    }
}
