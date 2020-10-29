using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CryptoApp.Shared
{
    public class CryptoBlockChain {

        public CryptoBlockChain(string name = null)
        {
            ChainName = name == null ? new NameRandomizer().RandomName() : name;
            ChainId = Guid.NewGuid();
            Blockchain = new List<CryptoBlock>();
            AddStartingBlock("Base Block");
        }
        public Guid ChainId;
        public string ChainName;
        public List<CryptoBlock> Blockchain;
        private CryptoBlock AddStartingBlock(string _data){
            return AddNewBlock(_data, "0");
        }
        private int GetMaxBlockIndex() {
            return Blockchain.Max(maxBlock=>maxBlock.Index);
        }
        private int GetNextBlockIndex() {
            if (Blockchain.Any()) {
                return GetMaxBlockIndex()+1;
            } else {
                return 0;
            }
        }
        public CryptoBlock GetLatestBlock(){
            return Blockchain.FirstOrDefault(block=>block.Index==GetMaxBlockIndex());
        }
        public CryptoBlock AddNewBlock(string _data, string _previousHash)
        {
            CryptoBlock newBlock = new CryptoBlock(GetNextBlockIndex(), _data, _previousHash, DateTime.UtcNow);
            Blockchain.Add(newBlock);
            return newBlock;
        }

        public string MD5()
        {
            string input="";
            foreach (var item in Blockchain)
            {
                input += item.Hash;
            }
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }

        public bool CheckValidity() {
            foreach (CryptoBlock cryptoBlock in this.Blockchain) {
                if (cryptoBlock.Index>0) {
                    var precedingBlock = this.Blockchain.FirstOrDefault(f=>f.Index == cryptoBlock.Index-1);
                    if (precedingBlock.Hash != cryptoBlock.PreviousHash ||
                        cryptoBlock.GetHash() != cryptoBlock.Hash) {
                        return false;
                    }
                }
            }
            return true;
        }

        
    }
}
