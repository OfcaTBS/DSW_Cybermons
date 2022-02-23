using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace CMType
{ 
    public enum TypeOfCybermon
    {
        Fire, Water, Grass, Dark, Ice, Tech, Poison, Death, Life, Ground, Normal
    }

    public class TypesOfCybermon
    {
        public static Color TypeColor(TypeOfCybermon t)
        {

            return t switch
            {
                TypeOfCybermon.Dark => new Color(46, 43, 43),
                TypeOfCybermon.Death => new Color(0, 0, 0),
                TypeOfCybermon.Fire => new Color(217, 67, 2),
                TypeOfCybermon.Grass => new Color(0, 191, 45),
                TypeOfCybermon.Ground => new Color(97, 44, 0),
                TypeOfCybermon.Ice => new Color(90, 239, 255),
                TypeOfCybermon.Life => new Color(255, 248, 117),
                TypeOfCybermon.Normal => new Color(230, 230, 230),
                TypeOfCybermon.Poison => new Color(98, 0, 217),
                TypeOfCybermon.Tech => new Color(0, 43, 4),
                TypeOfCybermon.Water => new Color(0, 132, 255),
                _ => Color.white,
            };
        }
        
    }
}
