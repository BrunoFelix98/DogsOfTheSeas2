using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Cities
{
    //Image of the resource
    public GameObject cityLoc;

    //Int parameters
    public int cityID; //City ID
    public List<int> nearbyRss = new List<int>(); //Rss near the city
    public List<int> sellingRss = new List<int>(); //Rss city is selling
    public List<float> rssCost = new List<float>(); //Cost of each resource the city is selling

    //String parameters
    public string cityName; //Name of the resource

    public Cities(GameObject cityPos, int cID, List<int> nearRss, List<int> sellRss, List<float> sellRssCost, string cityNm)
    {
        this.cityLoc = cityPos;
        this.cityID = cID;
        this.nearbyRss = nearRss;
        this.sellingRss = sellRss;
        this.rssCost = sellRssCost;
        this.cityName = cityNm;
    }
}