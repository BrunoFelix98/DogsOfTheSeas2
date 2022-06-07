using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UpdateWarehouseInventory : MonoBehaviour
{
    public PlayerInventoryHolder playerInv;

    public GameObject[] inventorySlots;
    public GameObject[] BinventorySlots;

    public int totalTonneage;
    public int warehouseTotalTonnes;

    public PlayerGathering.InventoryItem[] playerInvHolder = new PlayerGathering.InventoryItem[54];

    [System.Serializable]
    public class WarehouseSlots
    {
        public string rssName = "";
        public int ressType = -1;
        public int rssAmount = 0;
        public Sprite rssImage = null;
    }

    public WarehouseSlots[] warehouseInventory = new WarehouseSlots[54];

    // Start is called before the first frame update
    void Start()
    {
        if (warehouseTotalTonnes == 0)
        {
            for (int i = 0; i < warehouseInventory.Length; i++)
            {
                warehouseInventory[i].rssName = "";
                warehouseInventory[i].ressType = -1;
                warehouseInventory[i].rssAmount = 0;
                warehouseInventory[i].rssImage = null;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInv == null)
        {
            playerInv = GameObject.FindGameObjectWithTag("InvHolder").GetComponent<PlayerInventoryHolder>();
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            playerInv.PassToWarehouse();
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            playerInv.PassToPlayerInv();
        }

        if (SceneManager.GetActiveScene().name.Equals("Homebay_New") || SceneManager.GetActiveScene().name.Equals("Homebay_New_Mobile"))
        {
            inventorySlots = GameObject.FindGameObjectsWithTag("WarehouseInvSlot");
            UpdateVisualsFromStart();

            BinventorySlots = GameObject.FindGameObjectsWithTag("BoatInvSlot");
            BUpdateVisualsFromStart();
        }
    }

    public void SetTonneage()
    {
        for (int i = 0; i < warehouseInventory.Length; i++)
        {
            totalTonneage = totalTonneage + warehouseInventory[i].rssAmount;
        }
    }

    #region UpdateWarehouseSlots
    public void UpdateWarehouseValues()//Send the information from the player inventory to the warehouse inventory
    {
        totalTonneage = 0;

        for (int i = 0; i < warehouseInventory.Length; i++)
        {
            for (int j = 0; j < playerInv.playerInvHolder.inventoryItems.Length; j++)
            {
                if (playerInv.playerInvHolder.inventoryItems[j].ressType != -1)
                {
                    if (warehouseInventory[i].ressType == -1)
                    {
                        warehouseInventory[i].ressType = playerInv.playerInvHolder.inventoryItems[j].ressType; //Pass the type of resource to the warehouse inventory
                        warehouseInventory[i].rssAmount = playerInv.playerInvHolder.inventoryItems[j].rssAmount; //Pass the quantity
                        warehouseInventory[i].rssImage = playerInv.playerInvHolder.inventoryItems[j].rssImage; //Pass the image
                        warehouseInventory[i].rssName = playerInv.playerInvHolder.inventoryItems[j].rssName; //Pass the name

                        UpdateVisualsFromTransfer(i, false);

                        BinventorySlots[i].gameObject.transform.GetChild(0).GetComponent<Image>().sprite = null;
                        BinventorySlots[i].gameObject.transform.GetChild(0).GetComponent<Image>().color = new Color(BinventorySlots[i].gameObject.transform.GetChild(0).GetComponent<Image>().color.r, BinventorySlots[i].gameObject.transform.GetChild(0).GetComponent<Image>().color.g, BinventorySlots[i].gameObject.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
                        BinventorySlots[i].gameObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = " ";

                        playerInv.playerInvHolder.inventoryItems[j].ressType = -1; //Take it off of the player inventory
                        playerInv.playerInvHolder.inventoryItems[j].rssAmount = 0; //Take the quantity off
                        playerInv.playerInvHolder.inventoryItems[j].rssName = ""; //Take the name off
                        playerInv.playerInvHolder.inventoryItems[j].rssImage = null; //Take the image off

                        playerInvHolder[i].rssName = playerInv.playerInvHolder.inventoryItems[j].rssName;
                        playerInvHolder[i].ressType = playerInv.playerInvHolder.inventoryItems[j].ressType;
                        playerInvHolder[i].rssAmount = playerInv.playerInvHolder.inventoryItems[j].rssAmount;
                        playerInvHolder[i].rssImage = playerInv.playerInvHolder.inventoryItems[j].rssImage;

                        warehouseTotalTonnes += warehouseInventory[i].rssAmount;
                    }
                    else
                    {
                        //This slot is already filled with something else
                    }
                }

                if (playerInv.playerInvHolder.inventoryItems[j].ressType == warehouseInventory[i].ressType) //Check if the type of resource on either slot is the same for both inventories
                {
                    warehouseInventory[i].rssAmount += playerInv.playerInvHolder.inventoryItems[j].rssAmount;
                    warehouseTotalTonnes += warehouseInventory[i].rssAmount;

                    UpdateVisualsFromTransfer(i, true);

                    BinventorySlots[i].gameObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = " ";

                    playerInv.playerInvHolder.inventoryItems[j].ressType = -1; //Take it off of the player inventory
                    playerInv.playerInvHolder.inventoryItems[j].rssAmount = 0; //Take the quantity off
                    playerInv.playerInvHolder.inventoryItems[j].rssName = ""; //Take the name off
                    playerInv.playerInvHolder.inventoryItems[j].rssImage = null; //Take the image off

                    playerInvHolder[i].rssName = playerInv.playerInvHolder.inventoryItems[j].rssName;
                    playerInvHolder[i].ressType = playerInv.playerInvHolder.inventoryItems[j].ressType;
                    playerInvHolder[i].rssAmount = playerInv.playerInvHolder.inventoryItems[j].rssAmount;
                    playerInvHolder[i].rssImage = playerInv.playerInvHolder.inventoryItems[j].rssImage;
                }

                if (warehouseInventory[i].ressType == -1)
                {
                    if (playerInv.playerInvHolder.inventoryItems[j].ressType == warehouseInventory[i].ressType)
                    {
                        inventorySlots[i].gameObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = " ";
                        continue;
                    }
                }
            }
        }
    }

    public void UpdateVisualsFromTransfer(int i, bool increasing)
    {
        if (!increasing)
        {
            int closure = i; //Add a closure prevention method
            inventorySlots[i].gameObject.transform.GetChild(0).GetComponent<Image>().sprite = warehouseInventory[i].rssImage;
            inventorySlots[i].gameObject.transform.GetChild(0).GetComponent<Button>().onClick.RemoveAllListeners();
            inventorySlots[i].gameObject.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(() => { InvSlotPress(i); });
            inventorySlots[i].gameObject.transform.GetChild(0).GetComponent<Image>().color = new Color(inventorySlots[i].gameObject.transform.GetChild(0).GetComponent<Image>().color.r, inventorySlots[i].gameObject.transform.GetChild(0).GetComponent<Image>().color.g, inventorySlots[i].gameObject.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            inventorySlots[i].gameObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = warehouseInventory[i].rssName + " " + warehouseInventory[i].rssAmount.ToString();
        }
        else
        {
            inventorySlots[i].gameObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = warehouseInventory[i].rssName + " " + warehouseInventory[i].rssAmount.ToString();
        }
    }

    public void UpdateVisualsFromStart()
    {
        for (int i = 0; i < warehouseInventory.Length; i++)
        {
            if (warehouseInventory[i].ressType != -1)
            {
                inventorySlots[i].gameObject.transform.GetChild(0).GetComponent<Image>().sprite = warehouseInventory[i].rssImage;
                inventorySlots[i].gameObject.transform.GetChild(0).GetComponent<Image>().color = new Color(inventorySlots[i].gameObject.transform.GetChild(0).GetComponent<Image>().color.r, inventorySlots[i].gameObject.transform.GetChild(0).GetComponent<Image>().color.g, inventorySlots[i].gameObject.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
                inventorySlots[i].gameObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = warehouseInventory[i].rssName + " " + warehouseInventory[i].rssAmount.ToString();
            }
            else
            {
                inventorySlots[i].gameObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = " ";
            }
        }
    }
    #endregion

    public void UpdateBoatValues(int totalTonnes)
    {
        SetTonneage();

        if (totalTonneage <= totalTonnes)
        {
            for (int i = 0; i < playerInv.playerInvHolder.inventoryItems.Length; i++)
            {
                for (int j = 0; j < warehouseInventory.Length; j++)
                {
                    if (warehouseInventory[i].ressType != -1)
                    {
                        playerInv.playerInvHolder.inventoryItems[i].ressType = warehouseInventory[j].ressType; //Pass the type of resource to the player inventory
                        playerInv.playerInvHolder.inventoryItems[i].rssAmount = warehouseInventory[j].rssAmount; //Pass the quantity
                        playerInv.playerInvHolder.inventoryItems[i].rssImage = warehouseInventory[j].rssImage; //Pass the image
                        playerInv.playerInvHolder.inventoryItems[i].rssName = warehouseInventory[j].rssName; //Pass the name

                        BUpdateVisualsFromTransfer(i, false);

                        inventorySlots[i].gameObject.transform.GetChild(0).GetComponent<Image>().sprite = null;
                        inventorySlots[i].gameObject.transform.GetChild(0).GetComponent<Image>().color = new Color(inventorySlots[i].gameObject.transform.GetChild(0).GetComponent<Image>().color.r, inventorySlots[i].gameObject.transform.GetChild(0).GetComponent<Image>().color.g, inventorySlots[i].gameObject.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
                        inventorySlots[i].gameObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = " ";

                        warehouseInventory[j].ressType = -1; //Take it off of the warehouse inventory
                        warehouseInventory[j].rssAmount = 0; //Take the quantity off
                        warehouseInventory[j].rssName = ""; //Take the name off
                        warehouseInventory[j].rssImage = null; //Take the image off

                        playerInvHolder[i].rssName = playerInv.playerInvHolder.inventoryItems[i].rssName;
                        playerInvHolder[i].ressType = playerInv.playerInvHolder.inventoryItems[i].ressType;
                        playerInvHolder[i].rssAmount = playerInv.playerInvHolder.inventoryItems[i].rssAmount;
                        playerInvHolder[i].rssImage = playerInv.playerInvHolder.inventoryItems[i].rssImage;

                        warehouseTotalTonnes -= playerInv.playerInvHolder.inventoryItems[i].rssAmount;
                    }

                    if (warehouseInventory[i].ressType == playerInv.playerInvHolder.inventoryItems[i].ressType)
                    {
                        playerInv.playerInvHolder.inventoryItems[i].rssAmount += warehouseInventory[i].rssAmount;
                        warehouseTotalTonnes -= playerInv.playerInvHolder.inventoryItems[i].rssAmount;

                        BUpdateVisualsFromTransfer(i, true);

                        inventorySlots[i].gameObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = " ";

                        warehouseInventory[j].ressType = -1; //Take it off of the warehouse inventory
                        warehouseInventory[j].rssAmount = 0; //Take the quantity off
                        warehouseInventory[j].rssName = ""; //Take the name off
                        warehouseInventory[j].rssImage = null; //Take the image off

                        playerInvHolder[i].rssName = playerInv.playerInvHolder.inventoryItems[i].rssName;
                        playerInvHolder[i].ressType = playerInv.playerInvHolder.inventoryItems[i].ressType;
                        playerInvHolder[i].rssAmount = playerInv.playerInvHolder.inventoryItems[i].rssAmount;
                        playerInvHolder[i].rssImage = playerInv.playerInvHolder.inventoryItems[i].rssImage;
                    }

                    if (playerInv.playerInvHolder.inventoryItems[i].ressType == -1)
                    {
                        if (playerInv.playerInvHolder.inventoryItems[i].ressType == warehouseInventory[j].ressType)
                        {
                            BinventorySlots[i].gameObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = " ";
                            continue;
                        }
                    }
                }
            }
        }
        else
        {
            print("Ship has no space left");
        }
    }

    public void BUpdateVisualsFromTransfer(int i, bool increasing)
    {
        if (!increasing)
        {
            int closure = i; //Add a closure prevention method
            BinventorySlots[i].gameObject.transform.GetChild(0).GetComponent<Image>().sprite = playerInv.playerInvHolder.inventoryItems[i].rssImage;
            BinventorySlots[i].gameObject.transform.GetChild(0).GetComponent<Button>().onClick.RemoveAllListeners();
            BinventorySlots[i].gameObject.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(() => { BInvSlotPress(closure); });
            BinventorySlots[i].gameObject.transform.GetChild(0).GetComponent<Image>().color = new Color(BinventorySlots[i].gameObject.transform.GetChild(0).GetComponent<Image>().color.r, BinventorySlots[i].gameObject.transform.GetChild(0).GetComponent<Image>().color.g, BinventorySlots[i].gameObject.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
            BinventorySlots[i].gameObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = playerInv.playerInvHolder.inventoryItems[i].rssName + " " + playerInv.playerInvHolder.inventoryItems[i].rssAmount.ToString();
        }
        else
        {
            BinventorySlots[i].gameObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = playerInv.playerInvHolder.inventoryItems[i].rssName + " " + playerInv.playerInvHolder.inventoryItems[i].rssAmount.ToString();
        }
    }

    public void BUpdateVisualsFromStart()
    {
        for (int i = 0; i < playerInv.playerInvHolder.inventoryItems.Length; i++)
        {
            if (playerInv.playerInvHolder.inventoryItems[i].ressType != -1)
            {
                int closure = i; //Add a closure prevention method
                BinventorySlots[i].gameObject.transform.GetChild(0).GetComponent<Image>().sprite = playerInv.playerInvHolder.inventoryItems[i].rssImage;
                BinventorySlots[i].gameObject.transform.GetChild(0).GetComponent<Button>().onClick.RemoveAllListeners();
                BinventorySlots[i].gameObject.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(() => { BInvSlotPress(closure); });
                BinventorySlots[i].gameObject.transform.GetChild(0).GetComponent<Image>().color = new Color(BinventorySlots[i].gameObject.transform.GetChild(0).GetComponent<Image>().color.r, BinventorySlots[i].gameObject.transform.GetChild(0).GetComponent<Image>().color.g, BinventorySlots[i].gameObject.transform.GetChild(0).GetComponent<Image>().color.b, 1.0f);
                BinventorySlots[i].gameObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = playerInv.playerInvHolder.inventoryItems[i].rssName + " " + playerInv.playerInvHolder.inventoryItems[i].rssAmount.ToString();
            }
            else
            {
                BinventorySlots[i].gameObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = " ";
            }
        }
    }

    public void InvSlotPress(int i)
    {
        GameObject transferObject = GameObject.FindGameObjectWithTag("Transfer");

        transferObject.transform.GetChild(1).GetComponent<Image>().sprite = warehouseInventory[i].rssImage;
        transferObject.transform.GetChild(3).GetComponent<Button>().onClick.RemoveAllListeners();
        transferObject.transform.GetChild(3).GetComponent<Button>().onClick.AddListener(() => { TransferSlot(i, transferObject); });

        print("The slot: " + i + " has " + warehouseInventory[i].rssName + " in it.");
    }

    public void BInvSlotPress(int i)
    {
        GameObject transferObject = GameObject.FindGameObjectWithTag("Transfer");

        transferObject.transform.GetChild(1).GetComponent<Image>().sprite = playerInv.playerInvHolder.inventoryItems[i].rssImage;
        transferObject.transform.GetChild(3).GetComponent<Button>().onClick.RemoveAllListeners();
        transferObject.transform.GetChild(3).GetComponent<Button>().onClick.AddListener(() => { BTransferSlot(i, transferObject); });

        print("The slot: " + i + " has " + playerInv.playerInvHolder.inventoryItems[i].rssName + " in it.");
    }

    public void TransferSlot(int rssinstance, GameObject transferObj)
    {
        TMP_InputField input = transferObj.transform.GetChild(2).GetComponent<TMP_InputField>();
        int amount = int.Parse(input.text);

        print("Clicked transfer!" + amount);

        if ((amount + playerInv.currentTonnes) > playerInv.maxTonnes)
        {
            print("The amount passed fills up the cargo of the ship");
            return;
        }

        for (int i = 0; i < playerInv.playerInvHolder.inventoryItems.Length; i++)
        {
            if (playerInv.playerInvHolder.inventoryItems[i].ressType == -1)
            {
                print("Found an empty slot!" + amount);

                if (amount < warehouseInventory[rssinstance].rssAmount)
                {
                    print("Added to the empty slot but didnt empty the warehouse slot out!");

                    playerInv.playerInvHolder.inventoryItems[i].ressType = warehouseInventory[rssinstance].ressType; //Pass the type of resource to the player inventory
                    playerInv.playerInvHolder.inventoryItems[i].rssAmount += amount; //Pass the quantity
                    playerInv.playerInvHolder.inventoryItems[i].rssImage = warehouseInventory[rssinstance].rssImage; //Pass the image
                    playerInv.playerInvHolder.inventoryItems[i].rssName = warehouseInventory[rssinstance].rssName; //Pass the name

                    warehouseInventory[rssinstance].rssAmount -= amount;
                    BUpdateVisualsFromStart();
                    UpdateVisualsFromStart();
                    break;
                }
                else if (amount == warehouseInventory[rssinstance].rssAmount)
                {
                    print("Added to the empty slot and emptied the warehouse slot out!");

                    playerInv.playerInvHolder.inventoryItems[i].rssAmount += amount; //Pass the quantity

                    inventorySlots[rssinstance].gameObject.transform.GetChild(0).GetComponent<Image>().sprite = null;
                    inventorySlots[rssinstance].gameObject.transform.GetChild(0).GetComponent<Image>().color = new Color(inventorySlots[rssinstance].gameObject.transform.GetChild(0).GetComponent<Image>().color.r, inventorySlots[rssinstance].gameObject.transform.GetChild(0).GetComponent<Image>().color.g, inventorySlots[rssinstance].gameObject.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
                    inventorySlots[rssinstance].gameObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = " ";

                    warehouseInventory[rssinstance].ressType = -1; //Take it off of the warehouse inventory
                    warehouseInventory[rssinstance].rssAmount = 0; //Take the quantity off
                    warehouseInventory[rssinstance].rssName = ""; //Take the name off
                    warehouseInventory[rssinstance].rssImage = null; //Take the image off
                    BUpdateVisualsFromStart();
                    UpdateVisualsFromStart();
                    break;
                }
            }
            else if (playerInv.playerInvHolder.inventoryItems[i].ressType == warehouseInventory[rssinstance].ressType)
            {
                print("The slot we found is of the same type!");

                if (amount < warehouseInventory[rssinstance].rssAmount)
                {
                    playerInv.playerInvHolder.inventoryItems[i].rssAmount += amount; //Pass the quantity

                    warehouseInventory[rssinstance].rssAmount -= amount;
                    BUpdateVisualsFromStart();
                    UpdateVisualsFromStart();
                    break;
                }
                else if (amount == warehouseInventory[rssinstance].rssAmount)
                {
                    playerInv.playerInvHolder.inventoryItems[i].rssAmount += amount; //Pass the quantity

                    inventorySlots[rssinstance].gameObject.transform.GetChild(0).GetComponent<Image>().sprite = null;
                    inventorySlots[rssinstance].gameObject.transform.GetChild(0).GetComponent<Image>().color = new Color(inventorySlots[rssinstance].gameObject.transform.GetChild(0).GetComponent<Image>().color.r, inventorySlots[rssinstance].gameObject.transform.GetChild(0).GetComponent<Image>().color.g, inventorySlots[rssinstance].gameObject.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
                    inventorySlots[rssinstance].gameObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = " ";

                    warehouseInventory[rssinstance].ressType = -1; //Take it off of the warehouse inventory
                    warehouseInventory[rssinstance].rssAmount = 0; //Take the quantity off
                    warehouseInventory[rssinstance].rssName = ""; //Take the name off
                    warehouseInventory[rssinstance].rssImage = null; //Take the image off
                    BUpdateVisualsFromStart();
                    UpdateVisualsFromStart();
                    break;
                }
            }
        }
    }

    public void BTransferSlot(int rssinstance, GameObject transferObj)
    {
        TMP_InputField input = transferObj.transform.GetChild(2).GetComponent<TMP_InputField>();
        int amount = int.Parse(input.text);

        print("Clicked transfer!" + amount);

        for (int i = 0; i < warehouseInventory.Length; i++)
        {
            if (warehouseInventory[i].ressType == -1)
            {
                print("Found an empty slot!" + amount);

                if (amount < playerInv.playerInvHolder.inventoryItems[rssinstance].rssAmount)
                {
                    print("Added to the empty slot but didnt empty the warehouse slot out!");

                    warehouseInventory[i].ressType = playerInv.playerInvHolder.inventoryItems[rssinstance].ressType; //Pass the type of resource to the player inventory
                    warehouseInventory[i].rssAmount += amount; //Pass the quantity
                    warehouseInventory[i].rssImage = playerInv.playerInvHolder.inventoryItems[rssinstance].rssImage; //Pass the image
                    warehouseInventory[i].rssName = playerInv.playerInvHolder.inventoryItems[rssinstance].rssName; //Pass the name

                    playerInv.playerInvHolder.inventoryItems[rssinstance].rssAmount -= amount;
                    BUpdateVisualsFromStart();
                    UpdateVisualsFromStart();
                    break;
                }
                else if (amount == playerInv.playerInvHolder.inventoryItems[rssinstance].rssAmount)
                {
                    print("Added to the empty slot and emptied the warehouse slot out!");

                    warehouseInventory[i].rssAmount += amount; //Pass the quantity

                    BinventorySlots[rssinstance].gameObject.transform.GetChild(0).GetComponent<Image>().sprite = null;
                    BinventorySlots[rssinstance].gameObject.transform.GetChild(0).GetComponent<Image>().color = new Color(inventorySlots[rssinstance].gameObject.transform.GetChild(0).GetComponent<Image>().color.r, inventorySlots[rssinstance].gameObject.transform.GetChild(0).GetComponent<Image>().color.g, inventorySlots[rssinstance].gameObject.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
                    BinventorySlots[rssinstance].gameObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = " ";

                    playerInv.playerInvHolder.inventoryItems[rssinstance].ressType = -1; //Take it off of the warehouse inventory
                    playerInv.playerInvHolder.inventoryItems[rssinstance].rssAmount = 0; //Take the quantity off
                    playerInv.playerInvHolder.inventoryItems[rssinstance].rssName = ""; //Take the name off
                    playerInv.playerInvHolder.inventoryItems[rssinstance].rssImage = null; //Take the image off
                    BUpdateVisualsFromStart();
                    UpdateVisualsFromStart();
                    break;
                }
            }
            else if (warehouseInventory[i].ressType == playerInv.playerInvHolder.inventoryItems[rssinstance].ressType)
            {
                print("The slot we found is of the same type!");

                if (amount < playerInv.playerInvHolder.inventoryItems[rssinstance].rssAmount)
                {
                    warehouseInventory[i].rssAmount += amount; //Pass the quantity

                    playerInv.playerInvHolder.inventoryItems[rssinstance].rssAmount -= amount;
                    BUpdateVisualsFromStart();
                    UpdateVisualsFromStart();
                    break;
                }
                else if (amount == playerInv.playerInvHolder.inventoryItems[rssinstance].rssAmount)
                {
                    warehouseInventory[i].rssAmount += amount; //Pass the quantity

                    BinventorySlots[rssinstance].gameObject.transform.GetChild(0).GetComponent<Image>().sprite = null;
                    BinventorySlots[rssinstance].gameObject.transform.GetChild(0).GetComponent<Image>().color = new Color(inventorySlots[rssinstance].gameObject.transform.GetChild(0).GetComponent<Image>().color.r, inventorySlots[rssinstance].gameObject.transform.GetChild(0).GetComponent<Image>().color.g, inventorySlots[rssinstance].gameObject.transform.GetChild(0).GetComponent<Image>().color.b, 0.0f);
                    BinventorySlots[rssinstance].gameObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = " ";

                    playerInv.playerInvHolder.inventoryItems[rssinstance].ressType = -1; //Take it off of the warehouse inventory
                    playerInv.playerInvHolder.inventoryItems[rssinstance].rssAmount = 0; //Take the quantity off
                    playerInv.playerInvHolder.inventoryItems[rssinstance].rssName = ""; //Take the name off
                    playerInv.playerInvHolder.inventoryItems[rssinstance].rssImage = null; //Take the image off
                    BUpdateVisualsFromStart();
                    UpdateVisualsFromStart();
                    break;
                }
            }
        }
    }
}