using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProduceWorkshop : MonoBehaviour
{
    //To make tools
    public Sprite wood;
    public Sprite stone;
    public Sprite rope;
    public Sprite tools;

    //To make small cannons
    public Sprite coal;
    public Sprite copperIngot;
    public Sprite cannons;

    //To make medium cannons
    public Sprite ironIngot;

    //To make large cannons
    public Sprite goldIngot;

    public int quantity;

    public bool canProduce;
    public bool canTake;

    public GameObject[] controllers;

    public GameObject rssHolder;

    public UpdateWarehouseInventory warehouseInv;

    public GameObject productionHolder;

    // Start is called before the first frame update
    void Start()
    {
        canProduce = false;
        canTake = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (controllers.Length < 2)
        {
            controllers = GameObject.FindGameObjectsWithTag("Controllers");
            rssHolder = controllers[1];
        }

        if (warehouseInv == null)
        {
            warehouseInv = GameObject.FindGameObjectWithTag("Warehouse").GetComponent<UpdateWarehouseInventory>();
        }

        if (productionHolder == null)
        {
            productionHolder = GameObject.FindGameObjectWithTag("Producing");
        }
        else
        {
            //Text text = productionHolder.GetComponentInChildren<TMP_InputField>().GetComponentInChildren<TextMeshProUGUI>();
            Int32.TryParse(productionHolder.GetComponentInChildren<TMP_InputField>().text, out int result);
            quantity = result;
        }
    }

    public void ProduceTools()
    {
        productionHolder = GameObject.FindGameObjectWithTag("Producing");

        if (productionHolder.transform.GetChild(0).GetComponent<Button>().onClick.GetPersistentEventCount() == 0)
        {
            if (rssHolder != null)
            {
                wood = rssHolder.GetComponent<PopulateResources>().resources[0].rssImage.GetComponent<SpriteRenderer>().sprite;
                stone = rssHolder.GetComponent<PopulateResources>().resources[1].rssImage.GetComponent<SpriteRenderer>().sprite;
                rope = rssHolder.GetComponent<PopulateResources>().resources[9].rssImage.GetComponent<SpriteRenderer>().sprite;
                tools = rssHolder.GetComponent<PopulateResources>().resources[22].rssImage.GetComponent<SpriteRenderer>().sprite;
                if (productionHolder.GetComponentInChildren<Button>().onClick.GetPersistentEventCount() == 0)
                {
                    productionHolder.GetComponentInChildren<Button>().onClick.AddListener(ProduceTols);
                }
            }
        }
        else
        {
            productionHolder.transform.GetChild(0).GetComponent<Button>().onClick.RemoveAllListeners();
        }
    }

    public void ProduceCannonsS()
    {
        productionHolder = GameObject.FindGameObjectWithTag("Producing");

        if (productionHolder.transform.GetChild(0).GetComponent<Button>().onClick.GetPersistentEventCount() == 0)
        {
            if (rssHolder != null)
            {
                coal = rssHolder.GetComponent<PopulateResources>().resources[8].rssImage.GetComponent<SpriteRenderer>().sprite;
                copperIngot = rssHolder.GetComponent<PopulateResources>().resources[17].rssImage.GetComponent<SpriteRenderer>().sprite;
                tools = rssHolder.GetComponent<PopulateResources>().resources[22].rssImage.GetComponent<SpriteRenderer>().sprite;
                cannons = rssHolder.GetComponent<PopulateResources>().resources[21].rssImage.GetComponent<SpriteRenderer>().sprite;
                if (productionHolder.GetComponentInChildren<Button>().onClick.GetPersistentEventCount() == 0)
                {
                    productionHolder.GetComponentInChildren<Button>().onClick.AddListener(ProduceCannonS);
                }
            }
        }
        else
        {
            productionHolder.transform.GetChild(0).GetComponent<Button>().onClick.RemoveAllListeners();
        }
    }

    public void ProduceCannonsM()
    {
        productionHolder = GameObject.FindGameObjectWithTag("Producing");

        if (productionHolder.transform.GetChild(0).GetComponent<Button>().onClick.GetPersistentEventCount() == 0)
        {
            if (rssHolder != null)
            {
                coal = rssHolder.GetComponent<PopulateResources>().resources[8].rssImage.GetComponent<SpriteRenderer>().sprite;
                ironIngot = rssHolder.GetComponent<PopulateResources>().resources[16].rssImage.GetComponent<SpriteRenderer>().sprite;
                tools = rssHolder.GetComponent<PopulateResources>().resources[22].rssImage.GetComponent<SpriteRenderer>().sprite;
                cannons = rssHolder.GetComponent<PopulateResources>().resources[21].rssImage.GetComponent<SpriteRenderer>().sprite;
                if (productionHolder.GetComponentInChildren<Button>().onClick.GetPersistentEventCount() == 0)
                {
                    productionHolder.GetComponentInChildren<Button>().onClick.AddListener(ProduceCannonM);
                }
            }
        }
        else
        {
            productionHolder.transform.GetChild(0).GetComponent<Button>().onClick.RemoveAllListeners();
        }
    }

    public void ProduceCannonsL()
    {
        productionHolder = GameObject.FindGameObjectWithTag("Producing");

        if (productionHolder.transform.GetChild(0).GetComponent<Button>().onClick.GetPersistentEventCount() == 0)
        {
            if (rssHolder != null)
            {
                coal = rssHolder.GetComponent<PopulateResources>().resources[8].rssImage.GetComponent<SpriteRenderer>().sprite;
                goldIngot = rssHolder.GetComponent<PopulateResources>().resources[18].rssImage.GetComponent<SpriteRenderer>().sprite;
                tools = rssHolder.GetComponent<PopulateResources>().resources[22].rssImage.GetComponent<SpriteRenderer>().sprite;
                cannons = rssHolder.GetComponent<PopulateResources>().resources[21].rssImage.GetComponent<SpriteRenderer>().sprite;
                if (productionHolder.GetComponentInChildren<Button>().onClick.GetPersistentEventCount() == 0)
                {
                    productionHolder.GetComponentInChildren<Button>().onClick.AddListener(ProduceCannonL);
                }
            }
        }
        else
        {
            productionHolder.transform.GetChild(0).GetComponent<Button>().onClick.RemoveAllListeners();
        }
    }

    public void ProduceTols()
    {
        UpdateInventory(0, 1, 9, 22);
        canProduce = false;
        canTake = false;
    }

    public void ProduceCannonS()
    {
        UpdateInventory(8, 17, 22, 21);
        canProduce = false;
        canTake = false;
    }

    public void ProduceCannonM()
    {
        UpdateInventory(8, 16, 22, 21);
        canProduce = false;
        canTake = false;
    }

    public void ProduceCannonL()
    {
        UpdateInventory(8, 18, 22, 21);
        canProduce = false;
        canTake = false;
    }

    public void UpdateInventory(int raw, int raw2, int raw3, int produced)
    {
        canTake = true;

        if (warehouseInv != null)
        {
            for (int i = 0; i < warehouseInv.warehouseInventory.Length; i++)
            {
                if (warehouseInv.warehouseInventory[i].ressType == raw || warehouseInv.warehouseInventory[i].ressType == raw2 || warehouseInv.warehouseInventory[i].ressType == raw3)
                {
                    if (canTake)
                    {
                        if (warehouseInv.warehouseInventory[i].rssAmount > quantity)
                        {
                            //Remove from that raw resource
                            warehouseInv.warehouseInventory[i].rssAmount -= quantity;
                            canProduce = true;
                            warehouseInv.UpdateVisualsFromStart();
                            break;
                        }
                        else if (warehouseInv.warehouseInventory[i].rssAmount == quantity)
                        {
                            //Remove that raw resource
                            warehouseInv.warehouseInventory[i].rssAmount = 0;
                            warehouseInv.warehouseInventory[i].ressType = -1;
                            warehouseInv.warehouseInventory[i].rssImage = null;
                            warehouseInv.warehouseInventory[i].rssName = "";
                            warehouseInv.UpdateVisualsFromStart();
                            canProduce = true;
                            break;
                        }
                        else
                        {
                            //You are trying to produce more than you have
                            print("You dont have the required resources.");

                            canProduce = false;
                        }
                    }
                }
            }

            if (canProduce)
            {
                for (int i = 0; i < warehouseInv.warehouseInventory.Length; i++)
                {
                    if (warehouseInv.warehouseInventory[i].ressType == produced)
                    {
                        //Add to the slot that already has it
                        warehouseInv.warehouseInventory[i].rssAmount += quantity;
                        warehouseInv.UpdateVisualsFromStart();
                        break;
                    }
                    else if (warehouseInv.warehouseInventory[i].ressType == -1)
                    {
                        //Slot is empty, add it
                        warehouseInv.warehouseInventory[i].rssAmount = quantity;
                        warehouseInv.warehouseInventory[i].ressType = produced;
                        warehouseInv.warehouseInventory[i].rssImage = rssHolder.GetComponent<PopulateResources>().resources[produced].rssImage.GetComponent<SpriteRenderer>().sprite;
                        warehouseInv.warehouseInventory[i].rssName = rssHolder.GetComponent<PopulateResources>().resources[produced].rssImage.GetComponent<SpriteRenderer>().name;
                        warehouseInv.UpdateVisualsFromStart();
                        break;
                    }
                }
            }
        }
    }
}