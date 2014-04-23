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
using System.Web;
using System.Security.Cryptography;//hash引用这个就行

namespace MobilFuncManager
{
    ////读写INI文件的函数
    //public class IniFile
    //{
    //    ///  <summary>
    //    ///  ini文件名称（带路径)
    //    ///  </summary>
    //    public string filePath;

    //    //声明读写INI文件的API函数
    //    [DllImport("kernel32")]
    //    private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

    //    [DllImport("kernel32")]
    //    private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

    //    ///  <summary>
    //    ///  类的构造函数
    //    ///  </summary>
    //    ///  <param  name="INIPath">INI文件名</param>  
    //    public IniFile(string INIPath)
    //    {
    //        filePath = INIPath;
    //    }

    //    ///  <summary>
    //    ///   写INI文件
    //    ///  </summary>
    //    ///  <param  name="Section">Section</param>
    //    ///  <param  name="Key">Key</param>
    //    ///  <param  name="value">value</param>
    //    public void WriteInivalue(string Section, string Key, string value)
    //    {
    //        WritePrivateProfileString(Section, Key, value, this.filePath);

    //    }

    //    ///  <summary>
    //    ///    读取INI文件指定部分
    //    ///  </summary>
    //    ///  <param  name="Section">Section</param>
    //    ///  <param  name="Key">Key</param>
    //    ///  <returns>String</returns>  
    //    public string ReadInivalue(string Section, string Key)
    //    {
    //        StringBuilder temp = new StringBuilder(255);
    //        int i = GetPrivateProfileString(Section, Key, "", temp, 255, this.filePath);
    //        return temp.ToString();

    //    }
    //}

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

            StringBuilder  hashresult =new StringBuilder();

            for (int i=0; i < tmpHash.Length; i++)
            {
                hashresult.Append(tmpHash[i].ToString("X2"));             
            }
            return hashresult.ToString();
        }
    }
}
