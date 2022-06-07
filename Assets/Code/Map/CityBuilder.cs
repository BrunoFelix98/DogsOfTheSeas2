using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityBuilder
{
    //Image of the resource
    public GameObject cityLocation;

    //Int parameters
    public int cityID; //City ID
    public List<int> nearbyResources = new List<int>(); //Rss near the city
    public List<int> sellingResources = new List<int>();//Rss city is selling
    public List<float> resourcesSellCost = new List<float>(); //Cost of each resource the city is selling

    //String parameters
    public string cityName; //Name of the resource

    public CityBuilder HasPosition(GameObject cityLoc)
    {
        cityLocation = cityLoc;
        return this;
    }

    public CityBuilder CityID(int cID)
    {
        cityID = cID;
        return this;
    }

    public CityBuilder NearbyRss(List<int> nearRss)
    {
        nearbyResources = nearRss;
        return this;
    }

    public CityBuilder TypesOfRss(List<int> sellRss)
    {
        sellingResources = sellRss;
        return this;
    }

    public CityBuilder CostOfRss(List<float> rssCost)
    {
        resourcesSellCost = rssCost;
        return this;
    }

    public CityBuilder CityName(string cName)
    {
        cityName = cName;
        return this;
    }

    public Cities Build()
    {
        return new Cities(cityLocation, cityID, nearbyResources, sellingResources, resourcesSellCost, cityName);
    }
}