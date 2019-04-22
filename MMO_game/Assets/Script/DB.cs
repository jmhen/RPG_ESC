using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[Serializable]
public static class DB
{
    private static string address = "10.12.54.189";
    private static string header = "/game.php?key=None";
    private static string JsonString;

    public static void setAll()
    {
        string uri = address + header + "&query=setAll" + 
        "&hp=" + StaticStats.Hp + 
            "&mp=" + StaticStats.Mp + 
        "&scene=" + StaticStats.Scene + 
            "&X=" + StaticStats.Position.x +
        "&Y=" + StaticStats.Position.y +
            "&Z=" + StaticStats.Position.z + 
        "&loginName=" + StaticStats.playerName;

        UnityWebRequest r = UnityWebRequest.Get(uri);
    }

    public static void getAll()
    {
        string uri = address + header + "&query=getAll" +
            "&loginName=" + StaticStats.playerName;
        UnityWebRequest r = UnityWebRequest.Get(uri);
    }

    public static void setHp()
    {
        string uri = "10.12.54.189/game.php?key=None&query=setHp&hp=8374862687&loginName=Player";
        UnityWebRequest r = UnityWebRequest.Get(uri);
    }
}
