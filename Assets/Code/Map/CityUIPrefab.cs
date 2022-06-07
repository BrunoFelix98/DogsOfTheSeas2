using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CityUIPrefab : MonoBehaviour
{
    public Image rssImage;

    public TextMeshProUGUI rssName;
    public TextMeshProUGUI rssPrice;

    public int rssType;

    public Button buyBtn;

    public PlayerGathering playerGatherScript;

    public void Start()
    {
        buyBtn.onClick.AddListener(OnBuy);
    }

    public void Update()
    {
        
    }

    void OnBuy()
    {
        if (playerGatherScript == null)
        {
            playerGatherScript = GameObject.FindGameObjectWithTag("Player").GetComponentInParent<PlayerGathering>();
        }

        //ToDo: Check if the player has enough money

        playerGatherScript.someInventory.totalHoldableRss = playerGatherScript.GetComponent<PlayerBoat>().playerCargoSize;

        for (int z = 0; z < playerGatherScript.someInventory.GetInventoryItems().Length; z++)
        {
            if (playerGatherScript.someInventory.totalRssAmount < playerGatherScript.someInventory.totalHoldableRss) //Check if the player has cargo space left
            {
                if (playerGatherScript.someInventory.GetInventoryItems()[z].ressType == -1) //Check if the slot is empty
                {
                    playerGatherScript.someInventory.GetInventoryItems()[z].ressType = rssType; //If empty, add this type to it
                }
                else if (playerGatherScript.someInventory.GetInventoryItems()[z].ressType == rssType) //If not empty but it has the same type as the one collected, add more to it
                {
                    playerGatherScript.AddToExisting(1, z, false);
                }
                else
                {
                    //This slot is full with a resource type that is not the one trying to be collected, move on
                    continue;
                }

                playerGatherScript.AddNew(1, z, rssType);

                break;
            }
            break;
        }
    }
}