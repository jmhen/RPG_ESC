using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

[Serializable]
public static class DB
{
    private static string address = "http://10.12.54.189/";
    private static string header = "game.php?key=None";
    private static string JsonString;

    public static string setAll()
    {
        string uri = address + header + "&query=setAll" + 
        "&hp=" + StaticStats.Hp + 
            "&mp=" + StaticStats.Mp + 
        "&scene=" + StaticStats.Scene + 
            "&X=" + StaticStats.Position.x +
        "&Y=" + StaticStats.Position.y +
            "&Z=" + StaticStats.Position.z + 
        "&loginName=" + "Player";

        return HttpGet(uri);
    }

    public static string getAll()
    {
        string uri = address + header + "&query=getAll" +
            "&loginName=" + StaticStats.playerName;
        return HttpGet(uri);
    }

    public static string SetHp()
    {
        string uri = "http://10.12.54.189/game.php?key=None&query=setHp&hp=34567&loginName=Player";
        return HttpGet(uri);
    }

    public static string GetHp()
    {
        string uri = "http://10.12.54.189/game.php?key=None&query=getHp&loginName=Player";
        return HttpGet(uri);
    }

    public static string HttpGet(string uri)
    {
        try
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = "GET";
            request.ContentType = "text/html;charset=UTF-8";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader streamReader = new StreamReader(stream, Encoding.GetEncoding("utf-8"));
            string returnString = streamReader.ReadToEnd();

            streamReader.Close();
            stream.Close();
            response.Close();

            return returnString;

        }
        catch (Exception)
        {
            return "";
        }
    }
}

