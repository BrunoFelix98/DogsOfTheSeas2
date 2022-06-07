using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckForPlayer : MonoBehaviour
{
    public ResourceClass[] rssClass;

    public GameObject resourceInstance;

    public SetCityLocation cityLoc;

    public bool playerEntered;
    public bool rssReachZero;

    public int number; //Resource number change
    public int type; //Resource type
    public int resourceType = 99; //Current rss available

    public float resourceTotalTonnage; //Current available rss amount
    public float rssPrice; //Current rss price

    // Start is called before the first frame update
    void Start()
    {
        playerEntered = false;

        rssClass = PopulateResources.instance.resources;

        rssReachZero = false;

        if (resourceInstance == null)
        {
            CheckNumber();

            resourceType = rssClass[type].rssType;
            resourceTotalTonnage = rssClass[type].rssAmount;
            rssPrice = rssClass[type].rssPrice;

            resourceInstance = Instantiate(rssClass[type].rssImage, this.transform.position, this.transform.rotation) as GameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Check if rss ran out
        //To do
        //Set a long timer for rss replacement
        if (rssReachZero)
        {
            UpdateResource();

            rssReachZero = false;
        }
    }

    void UpdateResource()
    {
        if (resourceInstance != null)
        {
            Destroy(resourceInstance);

            CheckNumber();

            resourceType = rssClass[type].rssType; //Change rss
            resourceTotalTonnage = rssClass[type].rssAmount; //Set rss amount
            rssPrice = rssClass[type].rssPrice; //Set rss price
            resourceInstance = Instantiate(rssClass[type].rssImage, this.transform.position, this.transform.rotation) as GameObject;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerEntered = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerEntered = false;
        }
    }

    void CheckNumber()
    {
        number = Random.Range(0, 100);

        switch (SceneManager.GetActiveScene().name)
        {
            case "Jogo1":
                if (number >= 0 && number <= 19)
                {
                    //The number is in between 1 and 20 so its Wood

                    type = 0;
                }
                else if (number >= 20 && number <= 39)
                {
                    //The number is in between 20 and 40 so its Stone

                    type = 1;
                }
                else if (number >= 40 && number <= 59)
                {
                    //The number is in between 40 and 60 so its Hemp

                    type = 2;
                }
                else if (number >= 60 && number <= 74)
                {
                    //The number is in between 60 and 75 so its Iron

                    type = 3;
                }
                else if (number >= 75 && number <= 84)
                {
                    //The number is in between 75 and 85 so its Cotton

                    type = 4;
                }
                else if (number >= 85 && number <= 92)
                {
                    //The number is in between 85 and 93 so its Sulfur

                    type = 5;
                }
                else
                {
                    //The number is in between 92 and 100 so its Copper

                    type = 6;
                }
                break;
            case "Jogo1_Mobile":
                if (number >= 0 && number <= 19)
                {
                    //The number is in between 1 and 20 so its Wood

                    type = 0;
                }
                else if (number >= 20 && number <= 39)
                {
                    //The number is in between 20 and 40 so its Stone

                    type = 1;
                }
                else if (number >= 40 && number <= 59)
                {
                    //The number is in between 40 and 60 so its Hemp

                    type = 2;
                }
                else if (number >= 60 && number <= 74)
                {
                    //The number is in between 60 and 75 so its Iron

                    type = 3;
                }
                else if (number >= 75 && number <= 84)
                {
                    //The number is in between 75 and 85 so its Cotton

                    type = 4;
                }
                else if (number >= 85 && number <= 92)
                {
                    //The number is in between 85 and 93 so its Sulfur

                    type = 5;
                }
                else
                {
                    //The number is in between 92 and 100 so its Copper

                    type = 6;
                }
                break;
            case "Jogo2":

                //Get chances for second level of the game with added resources

                break;
            default:
                break;
        }
    }
}
