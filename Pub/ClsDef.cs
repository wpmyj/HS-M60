using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Runtime.InteropServices;
using System.IO;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Configuration;
using System.Collections;
using System.Security.Cryptography;//hash引用这个就行


namespace Pub
{
    public class Hash
    {
        public static string sSourceData;
        public static byte[] tmpSource;
        public static byte[] tmpHash;

        public static string Hasher(string instr)
        {
            sSourceData = instr;
            tmpSource = ASCIIEncoding.ASCII.GetBytes(sSourceData);
            tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource);

            StringBuilder hashresult = new StringBuilder();

            for (int i = 0; i < tmpHash.Length; i++)
            {
                hashresult.Append(tmpHash[i].ToString("X2"));
            }
            return hashresult.ToString();
        }
    }
}