using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BuildingTypesClass
{
    //Int parameters
    public int buildType; //Type of building
    public int[] rssUsed; //Types of resources used in production
    public int[] rssNeededBuild; //Types of resources needed for construction
    public int[] product; //Type of product(s) it makes

    //String parameters
    public string buildName; //Name of the building

    //Float parameters
    public float productTimer; //Time it takes to produce

    public BuildingTypesClass(int bType, int[] rssUse,int[] rssBuild, int[] prod, string bName, float prodTimer)
    {
        this.buildType = bType;
        this.rssUsed = rssUse;
        this.rssNeededBuild = rssBuild;
        this.buildName = bName;
        this.product = prod;
        this.productTimer = prodTimer;
    }
}
