using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingsBuilder
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

    public BuildingsBuilder Image(Sprite buildImg)
    {
        buildingImage = buildImg;
        return this;
    }

    public BuildingsBuilder Type(int bTyp)
    {
        buildingType = bTyp;
        return this;
    }

    public BuildingsBuilder Level(int lvl)
    {
        buildingLevel = lvl;
        return this;
    }

    public BuildingsBuilder BuildTimer(float bTimer)
    {
        buildingTimer = bTimer;
        return this;
    }

    public BuildingsBuilder BuildName(string bName)
    {
        buildName = bName;
        return this;
    }

    public BuildingsBuilder BuiltCheck(bool built)
    {
        isBuilt = built;
        return this;
    }

    public BuildingsClass Build()
    {
        return new BuildingsClass(buildingImage, buildingType, buildingLevel, buildingTimer, buildName, isBuilt);
    }
}
