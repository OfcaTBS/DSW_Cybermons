using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace CMType
{ 

    public enum TypeOfCybermon
    {
        Fire, Water, Grass, Ice, Tech, Poison, Death, Life, Ground, Normal, Electricity
    }

    public static class TypesOfCybermon
    {
        public static Color32 GetColorByType(TypeOfCybermon _type)
        {
            var cybermonTypesColors = Resources.Load<CybermonTypesColors>("Cybermon Types Colors/StandardCybermonTypesColors");
            return _type switch
            {
                TypeOfCybermon.Death => cybermonTypesColors.death,
                TypeOfCybermon.Fire => cybermonTypesColors.fire,
                TypeOfCybermon.Grass => cybermonTypesColors.grass,
                TypeOfCybermon.Ground => cybermonTypesColors.ground,
                TypeOfCybermon.Ice => cybermonTypesColors.ice,
                TypeOfCybermon.Life => cybermonTypesColors.life,
                TypeOfCybermon.Normal => cybermonTypesColors.normal,
                TypeOfCybermon.Poison => cybermonTypesColors.poison,
                TypeOfCybermon.Tech => cybermonTypesColors.tech,
                TypeOfCybermon.Water => cybermonTypesColors.water,
                TypeOfCybermon.Electricity => cybermonTypesColors.electricity,
                _ => Color.white,
            };
        }
    }
}
