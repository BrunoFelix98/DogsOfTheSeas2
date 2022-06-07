using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceBuilder
{
    //Image of the resource
    public GameObject rssImage;

    //Int parameters
    public int rssType; //Type of resource (0 = wood, 1 = stone, etc...)

    //Float parameters
    public float rssAmount; //Amount of that resource (in tonnes)
    public float rssPrice; //Base price of the resource (in shiny sheckles)

    //String parameters
    public string rssName; //Name of the resource

    //Boolean parameters
    public bool isSpawnable; //Check if it is a spawnable resource

    public ResourceBuilder HasImage(GameObject rssImg)
    {
        rssImage = rssImg;
        return this;
    }

    public ResourceBuilder HasType(int rssTyp)
    {
        rssType = rssTyp;
        return this;
    }

    public ResourceBuilder HasAmount(float rssAmnt)
    {
        rssAmount = rssAmnt;
        return this;
    }

    public ResourceBuilder HasPrice(float rssPrc)
    {
        rssPrice = rssPrc;
        return this;
    }

    public ResourceBuilder HasName(string name)
    {
        rssName = name;
        return this;
    }

    public ResourceBuilder Spawnable(bool spawn)
    {
        isSpawnable = spawn;
        return this;
    }

    public ResourceClass Build()
    {
        return new ResourceClass(rssImage, rssType, rssAmount, rssPrice, rssName, isSpawnable);
    }
}
