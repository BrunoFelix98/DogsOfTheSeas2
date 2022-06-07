using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ResourceClass
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

    public ResourceClass(GameObject rssImg, int rssTyp, float rssAmnt, float rssPrc, string rssNm, bool spawn)
    {
        this.rssImage = rssImg;
        this.rssType = rssTyp;
        this.rssAmount = rssAmnt;
        this.rssPrice = rssPrc;
        this.rssName = rssNm;
        this.isSpawnable = spawn;
    }
}