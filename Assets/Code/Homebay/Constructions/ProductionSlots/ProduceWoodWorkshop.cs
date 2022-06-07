using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProduceWoodWorkshop : MonoBehaviour
{
    public Sprite rawWood;
    public Sprite planks;

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

    public void ProducePlanks()
    {
        productionHolder = GameObject.FindGameObjectWithTag("Producing");

        if (productionHolder.transform.GetChild(0).GetComponent<Button>().onClick.GetPersistentEventCount() == 0)
        {
            if (rssHolder != null)
            {
                rawWood = rssHolder.GetComponent<PopulateResources>().resources[0].rssImage.GetComponent<SpriteRenderer>().sprite;
                planks = rssHolder.GetComponent<PopulateResources>().resources[23].rssImage.GetComponent<SpriteRenderer>().sprite;
                if (productionHolder.GetComponentInChildren<Button>().onClick.GetPersistentEventCount() == 0)
                {
                    productionHolder.GetComponentInChildren<Button>().onClick.AddListener(ProducePlnks);
                }
            }
        }
        else
        {
            productionHolder.transform.GetChild(0).GetComponent<Button>().onClick.RemoveAllListeners();
        }
    }

    public void ProducePlnks()
    {
        UpdateInventory(0, 23);
        canProduce = false;
        canTake = false;
    }

    public void UpdateInventory(int raw, int produced)
    {
        canTake = true;

        if (warehouseInv != null)
        {
            for (int i = 0; i < warehouseInv.warehouseInventory.Length; i++)
            {
                if (warehouseInv.warehouseInventory[i].ressType == raw)
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