using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlayerGathering : MonoBehaviour
{
    public Inventory someInventory;

    public SellResourceScrpt inventoryButtons;
    public GameObject sellingToCity;

    public GameObject[] mapRss;
    public Image[] inventorySlots;

    public float totalTime;
    public float timeLeft;

    [System.Serializable]
    public class InventoryItem
    {
        public string rssName;
        public int ressType;
        public int rssAmount;
        public Sprite rssImage;
    }

    [System.Serializable]
    public class Inventory
    {
        // Arbitary size of max 54
        public InventoryItem[] inventoryItems = new InventoryItem[54];

        public int totalRssAmount;
        public int totalHoldableRss;

        public bool FindInventorySlotIndexFromType(int type, out int index)
        {
            for (int i = 0; i < inventoryItems.Length; i++)
            {
                if (inventoryItems[i].ressType == type)
                {
                    index = i;
                    return true;
                }
            }
            index = int.MinValue;
            return false;
        }

        public bool FindInventoryEmptyIndex(out int index)
        {
            for (int i = 0; i < inventoryItems.Length; i++)
            {
                if (inventoryItems[i].ressType == -1)
                {
                    index = i;
                    return true;
                }
            }

            index = int.MinValue;
            return false;
        }

        public InventoryItem[] GetInventoryItems()
        {
            return inventoryItems;
        }
    }

    //public ResourceType[] inventory = new ResourceType[56];

    public int rssType;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < someInventory.GetInventoryItems().Length; i++)
        {
            someInventory.GetInventoryItems()[i].ressType = -1;
        }

        timeLeft = totalTime;
        someInventory.totalRssAmount = 0;
        mapRss = GameObject.FindGameObjectsWithTag("Resource");
        someInventory.totalHoldableRss = GetComponent<PlayerBoat>().playerCargoSize;
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name.Equals("Jogo1"))
        {
            if (Input.GetKey("space"))
            {
                //Have cargo space

                for (int i = 0; i < mapRss.Length; i++)
                {
                    if (mapRss[i].GetComponent<CheckForPlayer>().playerEntered == true)
                    {
                        //Can collect from this rss

                        rssType = mapRss[i].GetComponent<CheckForPlayer>().resourceType;

                        for (int z = 0; z < someInventory.GetInventoryItems().Length; z++)
                        {
                            if (someInventory.totalRssAmount < someInventory.totalHoldableRss) //Check if the player has cargo space left
                            {
                                if (someInventory.GetInventoryItems()[z].ressType == -1) //Check if the slot is empty
                                {
                                    someInventory.GetInventoryItems()[z].ressType = rssType; //If empty, add this type to it
                                }
                                else if (someInventory.GetInventoryItems()[z].ressType == rssType) //If not empty but it has the same type as the one collected, add more to it
                                {
                                    timeLeft -= Time.deltaTime;
                                    if (timeLeft < 0)
                                    {
                                        AddToExisting(i, z, true);
                                    }
                                }
                                else
                                {
                                    //This slot is full with a resource type that is not the one trying to be collected, move on
                                    continue;
                                }

                                AddNew(i, z, rssType);

                                break;
                            }
                            break;
                        }
                    }
                }
            }
        }
    }

    public void AddToExisting(int i, int z, bool collectingFromRss)
    {
        someInventory.totalRssAmount++; //Add to the players' total cargo
        someInventory.GetInventoryItems()[z].rssAmount++; //Add to the slots' stock

        if (collectingFromRss)
        {
            mapRss[i].GetComponent<CheckForPlayer>().resourceTotalTonnage--; //Remove from the resources' stock
            timeLeft = totalTime; //Timer for next collection
        }
    }

    public void AddNew(int i, int z, int rssTyp)
    {
        //Add the parameters of the collected resource to the inventory slot
        someInventory.GetInventoryItems()[z].rssName = mapRss[i].GetComponent<CheckForPlayer>().rssClass[rssTyp].rssName;
        someInventory.GetInventoryItems()[z].rssImage = mapRss[i].GetComponent<CheckForPlayer>().rssClass[rssTyp].rssImage.GetComponent<SpriteRenderer>().sprite;
        inventorySlots[z].GetComponentInChildren<TextMeshProUGUI>().text = someInventory.GetInventoryItems()[z].rssName + " " + someInventory.GetInventoryItems()[z].rssAmount.ToString();
        inventorySlots[z].gameObject.transform.GetChild(0).GetComponent<Image>().sprite = someInventory.GetInventoryItems()[z].rssImage;
        inventorySlots[z].gameObject.transform.GetChild(0).GetComponent<Image>().color = new Color(inventorySlots[z].gameObject.transform.GetChild(0).GetComponent<Image>().color.r, inventorySlots[z].gameObject.transform.GetChild(0).GetComponent<Image>().color.g, inventorySlots[z].gameObject.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
        inventoryButtons.inventorySlotButton[z].onClick.AddListener(() => { SellRss(rssTyp, z); });
    }

    public void SellRss(int type, int slot)
    {
        sellingToCity.transform.GetChild(1).GetComponent<Image>().sprite = someInventory.GetInventoryItems()[slot].rssImage;

        sellingToCity.transform.GetChild(3).GetComponent<Button>().onClick.RemoveAllListeners();

        sellingToCity.transform.GetChild(3).GetComponent<Button>().onClick.AddListener(() => { Sell(slot); });
    }

    public void Sell(int slot)
    {
        int amount;
        Int32.TryParse(sellingToCity.transform.GetChild(2).GetComponent<TMP_InputField>().text, out int result);
        amount = result;

        if (someInventory.GetInventoryItems()[slot].rssAmount == amount)
        {
            someInventory.GetInventoryItems()[slot].ressType = -1;
            someInventory.GetInventoryItems()[slot].rssAmount = 0;
            someInventory.GetInventoryItems()[slot].rssImage = null;
            someInventory.GetInventoryItems()[slot].rssName = " ";

            inventorySlots[slot].GetComponentInChildren<TextMeshProUGUI>().text = " ";
            inventorySlots[slot].gameObject.transform.GetChild(0).GetComponent<Image>().sprite = null;
            inventorySlots[slot].gameObject.transform.GetChild(0).GetComponent<Image>().color = new Color(inventorySlots[slot].gameObject.transform.GetChild(0).GetComponent<Image>().color.r, inventorySlots[slot].gameObject.transform.GetChild(0).GetComponent<Image>().color.g, inventorySlots[slot].gameObject.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
        }
        else if (someInventory.GetInventoryItems()[slot].rssAmount > amount)
        {
            someInventory.GetInventoryItems()[slot].rssAmount -= amount;

            inventorySlots[slot].GetComponentInChildren<TextMeshProUGUI>().text = someInventory.GetInventoryItems()[slot].rssName + " " + someInventory.GetInventoryItems()[slot].rssAmount.ToString();
        }

        for (int i = 0; i < someInventory.GetInventoryItems().Length; i++)
        {
            if (someInventory.GetInventoryItems()[i].ressType == 7)
            {
                //Player already has gold
                someInventory.GetInventoryItems()[i].rssAmount += amount;
                inventorySlots[i].GetComponentInChildren<TextMeshProUGUI>().text = someInventory.GetInventoryItems()[i].rssName + " " + someInventory.GetInventoryItems()[i].rssAmount.ToString(); ;
                break;
            }
            else if (someInventory.GetInventoryItems()[i].ressType == -1)
            {
                someInventory.GetInventoryItems()[i].rssAmount = amount;
                someInventory.GetInventoryItems()[i].ressType = mapRss[i].GetComponent<CheckForPlayer>().rssClass[7].rssType;
                someInventory.GetInventoryItems()[i].rssImage = mapRss[i].GetComponent<CheckForPlayer>().rssClass[7].rssImage.GetComponent<SpriteRenderer>().sprite;
                someInventory.GetInventoryItems()[i].rssName = mapRss[i].GetComponent<CheckForPlayer>().rssClass[7].rssName;

                inventorySlots[i].GetComponentInChildren<TextMeshProUGUI>().text = someInventory.GetInventoryItems()[i].rssName + " " + someInventory.GetInventoryItems()[i].rssAmount.ToString();
                inventorySlots[i].gameObject.transform.GetChild(0).GetComponent<Image>().color = new Color(inventorySlots[i].gameObject.transform.GetChild(0).GetComponent<Image>().color.r, inventorySlots[i].gameObject.transform.GetChild(0).GetComponent<Image>().color.g, inventorySlots[i].gameObject.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
                inventorySlots[i].gameObject.transform.GetChild(0).GetComponent<Image>().sprite = someInventory.GetInventoryItems()[i].rssImage;
                break;
            }
        }
    }
}