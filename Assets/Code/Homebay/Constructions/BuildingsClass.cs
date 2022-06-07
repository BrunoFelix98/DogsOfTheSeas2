using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class BuildingsClass
{
    //Sprite parameters
    public Sprite buildingImage; //Image of the resource

    //Int parameters
    public int buildingType; //Type of building (0 = wood, 1 = stone, etc...)
    public int buildingLevel; //Building level

    //Float parameters
    public float buildingTimer; //Amount of time that it takes to build it

    //String parameters
    public string buildName; //Name of the building

    //Boolean parameters
    public bool isBuilt;

    public BuildingsClass(Sprite buildImg, int buildTyp, int buildLvl, float buildTime, string buildNm, bool isBuilt)
    {
        this.buildingImage = buildImg;
        this.buildingType = buildTyp;
        this.buildingLevel = buildLvl;
        this.buildingTimer = buildTime;
        this.buildName = buildNm;
        this.isBuilt = isBuilt;
    }
}
