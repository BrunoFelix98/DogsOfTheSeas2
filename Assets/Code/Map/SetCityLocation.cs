using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCityLocation : MonoBehaviour
{
    public Cities[] popCities;
    public GameObject[] cities;

    public GameObject player;

    public CheckForPlayer[] resources;

    public ResourceClass[] resourceType;

    // Start is called before the first frame update
    void Start()
    {
        resourceType = PopulateResources.instance.resources;
        popCities = PopulateCities.instance.cities;
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }

        if (popCities != null)
        {
            if (cities.Length != 0)
            {
                for (int i = 0; i < popCities.Length; i++)
                {
                    popCities[i].cityLoc = cities[i];
                }
            }
        }

        AreaOfInfluence();
    }

    void AreaOfInfluence()
    {
        for (int i = 0; i < cities.Length; i++)
        {
            RemoveBases(i);

            for (int j = 0; j < resources.Length; j++)
            {
                if (CheckIfRssIsNearby(i, j))
                {
                    AddNearby(i, j);
                }
                else
                {
                    AddAway(i, j);
                }
            }

            for (int x = 0; x < resourceType.Length; x++)
            {
                if (!popCities[i].sellingRss.Contains(resourceType[x].rssType) && !popCities[i].nearbyRss.Contains(resourceType[x].rssType))
                {
                    popCities[i].sellingRss.Add(resourceType[x].rssType);
                }
            }

            CheckForPlayer(cities[i]);
        }
    }

    void AddNearby(int i, int j)
    {
        if (!popCities[i].nearbyRss.Contains(resources[j].resourceType))
        {
            //Check if the resource is not already in the list

            //Add the resource to the nearby list
            popCities[i].nearbyRss.Add(resources[j].resourceType);

            //Remove this resource from the selling list if it exists nearby
            popCities[i].sellingRss.Remove(resources[j].resourceType);
        }
        else
        {
            if (resources[j].resourceTotalTonnage < 0.1f)
            {
                popCities[i].nearbyRss.Remove(resources[j].resourceType);
                resources[j].rssReachZero = true;
            }
        }
    }

    void AddAway(int i, int j)
    {
        if (!popCities[i].sellingRss.Contains(resources[j].resourceType) && !popCities[i].nearbyRss.Contains(resources[j].resourceType))
        {
            //Add the resources to the selling list
            popCities[i].sellingRss.Add(resources[j].resourceType);

            //Remove this resource from the nearby list if it exists there
            popCities[i].nearbyRss.Remove(resources[j].resourceType);
        }
    }

    void RemoveBases(int i)
    {
        //Remove base lines
        if (popCities[i].rssCost.Contains(0))
        {
            popCities[i].rssCost.Remove(0);
        }
    }

    bool CheckIfRssIsNearby(int i, int j)
    {
        if (Vector3.Distance(cities[i].transform.position, resources[j].transform.position) < 20.1f)
        {
            //Resource is in the area of influence of the city
            return true;
        }
        else
        {
            return false;
        }
    }

    void CheckForPlayer(GameObject origin)
    {
        //Check if the player is near the city

        if (Vector3.Distance(player.transform.position, origin.transform.position) < 7.0f)
        {
            //Player is near a city
        }
    }
}