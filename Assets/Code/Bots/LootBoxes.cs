using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
// Disposable Class
public class Loot
{
    // Any sort of types should be enums so you can read them properly but the speed of ints is kept in the background processing of the game
    // We Are arbitarily assuming each item is one ton
    public int[] lootType = new int[4];
    public int[] lootQuantity = new int[4];
}

public class LootBoxes : MonoBehaviour
{
    public Loot loot;

    public int totalTonneage;

    public GameObject LootUI;
    public GameObject LootUIInstance;

    public PlayerGathering playerGatherScript;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < loot.lootQuantity.Length; i++)
        {
            totalTonneage = totalTonneage + loot.lootQuantity[i];
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerGatherScript == null)
        {
            playerGatherScript = GameObject.FindGameObjectWithTag("Player").GetComponentInParent<PlayerGathering>();
        }
    }

    public void ShowUI()
    {
        LootUIInstance = Instantiate(LootUI, Camera.main.transform.position, Quaternion.identity, transform);
        LootUIInstance.GetComponent<LootUIInfo>().background.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
        LootUIInstance.GetComponent<LootUIInfo>().lootImageOne.sprite = playerGatherScript.mapRss[loot.lootType[0]].GetComponent<CheckForPlayer>().rssClass[loot.lootType[0]].rssImage.GetComponent<SpriteRenderer>().sprite;
        LootUIInstance.GetComponent<LootUIInfo>().lootImageTwo.sprite = playerGatherScript.mapRss[loot.lootType[1]].GetComponent<CheckForPlayer>().rssClass[loot.lootType[1]].rssImage.GetComponent<SpriteRenderer>().sprite;
        LootUIInstance.GetComponent<LootUIInfo>().lootImageThree.sprite = playerGatherScript.mapRss[loot.lootType[2]].GetComponent<CheckForPlayer>().rssClass[loot.lootType[2]].rssImage.GetComponent<SpriteRenderer>().sprite;
        LootUIInstance.GetComponent<LootUIInfo>().lootImageFour.sprite = playerGatherScript.mapRss[loot.lootType[3]].GetComponent<CheckForPlayer>().rssClass[loot.lootType[3]].rssImage.GetComponent<SpriteRenderer>().sprite;

        LootUIInstance.GetComponent<LootUIInfo>().lootQuantityOne.text = loot.lootQuantity[0].ToString();
        LootUIInstance.GetComponent<LootUIInfo>().lootQuantityTwo.text = loot.lootQuantity[1].ToString();
        LootUIInstance.GetComponent<LootUIInfo>().lootQuantityThree.text = loot.lootQuantity[2].ToString();
        LootUIInstance.GetComponent<LootUIInfo>().lootQuantityFour.text = loot.lootQuantity[3].ToString();

        //Close the UI and loot all the stuff in it
        Button lootBtn = LootUIInstance.GetComponent<LootUIInfo>().lootBtn;
        lootBtn.onClick.AddListener(TaskOnLoot);
    }

    void TaskOnLoot()
    {
        // Go Through Ships Loot and Loot as much as we can
        for (int i = 0; i < loot.lootType.Length; i++)
        {
            // Can I Pick Up The Whole Loot? For This Item Type
            if (loot.lootQuantity[i] + playerGatherScript.someInventory.totalRssAmount > playerGatherScript.someInventory.totalHoldableRss)
            {
                continue; // Too much to loot at once rip. Go onto the next one
            }

            int index = int.MinValue;
            if (playerGatherScript.someInventory.FindInventorySlotIndexFromType(loot.lootType[i], out index))
            {
                //Slot with the same resource as the one we are trying to add, so add to the amount
                playerGatherScript.someInventory.inventoryItems[index].rssAmount += loot.lootQuantity[i];

                playerGatherScript.someInventory.totalRssAmount += loot.lootQuantity[i];

                //Update the lootbox inventory
                loot.lootType[i] = -1;
                loot.lootQuantity[i] = 0;
            }
            else
            {
                //Slot empty, add a new resource
                if (playerGatherScript.someInventory.FindInventoryEmptyIndex(out index))
                {
                    playerGatherScript.someInventory.GetInventoryItems()[index].ressType = loot.lootType[i];
                    playerGatherScript.someInventory.GetInventoryItems()[index].rssAmount += loot.lootQuantity[i];
                    playerGatherScript.someInventory.GetInventoryItems()[index].rssImage = playerGatherScript.mapRss[i].GetComponent<CheckForPlayer>().rssClass[loot.lootType[i]].rssImage.GetComponent<SpriteRenderer>().sprite;
                    playerGatherScript.someInventory.GetInventoryItems()[index].rssName = playerGatherScript.mapRss[i].GetComponent<CheckForPlayer>().rssClass[loot.lootType[i]].rssName;

                    playerGatherScript.inventorySlots[index].GetComponentInChildren<TextMeshProUGUI>().text = playerGatherScript.mapRss[i].GetComponent<CheckForPlayer>().rssClass[loot.lootType[i]].rssName.ToString() + " " + playerGatherScript.someInventory.GetInventoryItems()[index].rssAmount.ToString();
                    playerGatherScript.inventorySlots[index].gameObject.transform.GetChild(0).GetComponent<Image>().sprite = playerGatherScript.mapRss[i].GetComponent<CheckForPlayer>().rssClass[loot.lootType[i]].rssImage.GetComponent<SpriteRenderer>().sprite;
                    playerGatherScript.inventorySlots[index].gameObject.transform.GetChild(0).GetComponent<Image>().color = new Color(playerGatherScript.inventorySlots[index].gameObject.transform.GetChild(0).GetComponent<Image>().color.r, playerGatherScript.inventorySlots[index].gameObject.transform.GetChild(0).GetComponent<Image>().color.g, playerGatherScript.inventorySlots[index].gameObject.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);

                    playerGatherScript.someInventory.totalRssAmount += loot.lootQuantity[i];

                    playerGatherScript.inventoryButtons.inventorySlotButton[index].onClick.AddListener(() => { playerGatherScript.SellRss(loot.lootType[i], index); });

                    loot.lootType[i] = -1;
                    loot.lootQuantity[i] = 0;
                    totalTonneage = 0;
                }
            }
        }

        if (LootUIInstance != null)
        {
            if (totalTonneage <= 0)
            {
                Destroy(LootUIInstance);
                GetComponentInParent<BotManager>().looted = true;
            }
        }
    }
}