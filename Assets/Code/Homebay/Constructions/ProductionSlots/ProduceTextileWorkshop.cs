using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProduceTextileWorkshop : MonoBehaviour
{
    //To produce Fabric
    public Sprite cotton;
    public Sprite fabric;

    //To produce rope
    public Sprite hemp;
    public Sprite rope;

    //To produce hide
    public Sprite cows;
    public Sprite hide;

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

    public void ProduceFabric()
    {
        productionHolder = GameObject.FindGameObjectWithTag("Producing");

        if (productionHolder.transform.GetChild(0).GetComponent<Button>().onClick.GetPersistentEventCount() == 0)
        {
            if (rssHolder != null)
            {
                cotton = rssHolder.GetComponent<PopulateResources>().resources[4].rssImage.GetComponent<SpriteRenderer>().sprite;
                fabric = rssHolder.GetComponent<PopulateResources>().resources[15].rssImage.GetComponent<SpriteRenderer>().sprite;
                if (productionHolder.GetComponentInChildren<Button>().onClick.GetPersistentEventCount() == 0)
                {
                    productionHolder.GetComponentInChildren<Button>().onClick.AddListener(ProduceFbrick);
                }
            }
        }
        else
        {
            productionHolder.transform.GetChild(0).GetComponent<Button>().onClick.RemoveAllListeners();
        }
    }

    public void ProduceRope()
    {
        productionHolder = GameObject.FindGameObjectWithTag("Producing");

        if (productionHolder.transform.GetChild(0).GetComponent<Button>().onClick.GetPersistentEventCount() == 0)
        {
            if (rssHolder != null)
            {
                hemp = rssHolder.GetComponent<PopulateResources>().resources[3].rssImage.GetComponent<SpriteRenderer>().sprite;
                rope = rssHolder.GetComponent<PopulateResources>().resources[9].rssImage.GetComponent<SpriteRenderer>().sprite;
                if (productionHolder.GetComponentInChildren<Button>().onClick.GetPersistentEventCount() == 0)
                {
                    productionHolder.GetComponentInChildren<Button>().onClick.AddListener(ProduceRop);
                }
            }
        }
        else
        {
            productionHolder.transform.GetChild(0).GetComponent<Button>().onClick.RemoveAllListeners();
        }
    }

    public void ProduceHide()
    {
        productionHolder = GameObject.FindGameObjectWithTag("Producing");

        if (productionHolder.transform.GetChild(0).GetComponent<Button>().onClick.GetPersistentEventCount() == 0)
        {
            if (rssHolder != null)
            {
                cows = rssHolder.GetComponent<PopulateResources>().resources[11].rssImage.GetComponent<SpriteRenderer>().sprite;
                hide = rssHolder.GetComponent<PopulateResources>().resources[10].rssImage.GetComponent<SpriteRenderer>().sprite;
                if (productionHolder.GetComponentInChildren<Button>().onClick.GetPersistentEventCount() == 0)
                {
                    productionHolder.GetComponentInChildren<Button>().onClick.AddListener(ProduceHid);
                }
            }
        }
        else
        {
            productionHolder.transform.GetChild(0).GetComponent<Button>().onClick.RemoveAllListeners();
        }
    }

    public void ProduceFbrick()
    {
        UpdateInventory(4, 15);
        canProduce = false;
        canTake = false;
    }

    public void ProduceRop()
    {
        UpdateInventory(3, 9);
        canProduce = false;
        canTake = false;
    }

    public void ProduceHid()
    {
        UpdateInventory(11, 10);
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