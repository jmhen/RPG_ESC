﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticStats
{
   
    private static int mp, hp, scene;
    private static Vector3 position;

    public static int Mp
    {
        get
        {
            return mp;
        }
        set
        {
            mp = value;
        }
    }

    public static int Hp
    {
        get
        {
            return hp;
        }
        set
        {
            hp = value;
        }
    }

    public static int Scene
    {
        get
        {
            return scene;
        }
        set
        {
            scene = value;
        }
    }

    public static Vector3 Position
    {
        get
        {
            return position;
        }
        set
        {
            position = value;
        }
    }
    
}