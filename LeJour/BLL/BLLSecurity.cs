using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace LeJour.BLL
{
    public class BLLSecurity
    {
        public byte[] GenerateHashedPassword(string pass)
        {
            byte[] hash;
            var data = Encoding.UTF8.GetBytes(pass);
            using (SHA512 shaM = new SHA512Managed())
            {
                hash = shaM.ComputeHash(data);
            }

            return hash;
        }

        public bool VerifyPassWord(string enteredValue, byte[] hashedValue)
        {
            byte[] hash = GenerateHashedPassword(enteredValue);
            return hash.SequenceEqual(hashedValue);
        }
    }
}
