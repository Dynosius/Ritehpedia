using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserSession
/// </summary>
public class UserSession
{
    public string Username { get; set; }
    public int UserID { get; set; }
    public int StudijID { get; set; }
    public string StudijIme { get; set; }

    public UserSession(string ime, int userid, int studijid, string studijime)
    {
        Username = ime;
        UserID = userid;
        StudijID = studijid;
        StudijIme = studijime;
    }
}