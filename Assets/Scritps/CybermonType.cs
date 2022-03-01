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
        public static Color32 TypeColor(TypeOfCybermon t)
        {

            return t switch
            {
                TypeOfCybermon.Dark => new Color32(46, 43, 43, 255),
                TypeOfCybermon.Death => new Color32(89, 84, 68, 255),
                TypeOfCybermon.Fire => new Color32(217, 67, 2, 255),
                TypeOfCybermon.Grass => new Color32(0, 191, 45, 255),
                TypeOfCybermon.Ground => new Color32(179, 134, 82, 255),
                TypeOfCybermon.Ice => new Color32(90, 239, 255, 255),
                TypeOfCybermon.Life => new Color32(126, 255, 56, 255),
                TypeOfCybermon.Normal => new Color32(230, 230, 230, 255),
                TypeOfCybermon.Poison => new Color32(98, 0, 217, 255),
                TypeOfCybermon.Tech => new Color32(0, 43, 4, 255),
                TypeOfCybermon.Water => new Color32(0, 132, 255, 255),
                _ => Color.white,
            };
        }
        
    }
}
