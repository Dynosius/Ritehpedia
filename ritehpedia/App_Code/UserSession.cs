using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

/// <summary>
/// Summary description for UserSession
/// </summary>
public class UserSession
{
    public enum Uloge { Admin = 1, Moderator = 2, Student = 3 }
    public string Username { get; set; }
    public int UserID { get; set; }
    public int StudijID { get; set; }
    public string StudijIme { get; set; }
    public int UlogaID { get; set; }

    public UserSession(string ime, int userid, int studijid, string studijime, int ulogaid)
    {
        Username = ime;
        UserID = userid;
        StudijID = studijid;
        StudijIme = studijime;
        UlogaID = ulogaid;
    }

    public static bool IsAdmin(HttpSessionState session)
    {
        UserSession sesija = session["User"] as UserSession;
        if (sesija != null && sesija.UlogaID == (int)Uloge.Admin)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public static bool IsModerator(HttpSessionState session)
    {
        UserSession sesija = session["User"] as UserSession;
        if (sesija != null && sesija.UlogaID == (int)Uloge.Moderator)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}