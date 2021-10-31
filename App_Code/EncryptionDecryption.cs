using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for EncryptionDecryption
/// </summary>
public class EncryptionDecryption
{

    public string EncryptMyData(string data)
    {
        string newdata="";
        foreach (char ch in data)
        {
            int ascii = ch;
            ascii = ascii + 7;
            newdata = newdata + (char)ascii;
        }
        return newdata;
    }
    public string DecryptMyData(string data)
    {
        string newdata = "";
        foreach (char ch in data)
        {
            int ascii = ch;
            ascii = ascii - 7;
            newdata = newdata + (char)ascii;
        }
        return newdata;
    }


}