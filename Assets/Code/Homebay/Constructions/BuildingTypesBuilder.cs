using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingTypesBuilder
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

    public BuildingTypesBuilder Type(int bType)
    {
        buildType = bType;
        return this;
    }

    public BuildingTypesBuilder ResourcesUsed(int[] rssUse)
    {
        rssUsed = rssUse;
        return this;
    }

    public BuildingTypesBuilder ResourcesUsedToBuild(int[] rssUseBuild)
    {
        rssNeededBuild = rssUseBuild;
        return this;
    }

    public BuildingTypesBuilder ResourcesProduced(int[] rssProd)
    {
        product = rssProd;
        return this;
    }

    public BuildingTypesBuilder Name(string bName)
    {
        buildName = bName;
        return this;
    }

    public BuildingTypesBuilder ProductionTimer(float built)
    {
        productTimer = built;
        return this;
    }

    public BuildingTypesClass Build()
    {
        return new BuildingTypesClass(buildType, rssUsed, rssNeededBuild, product, buildName, productTimer);
    }
}
