using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProduceBlacksmith : MonoBehaviour
{
    //To make gunpowder
    public Sprite sulphur;
    public Sprite coal;
    public Sprite gunpowder;

    //To make cannonballs
    public Sprite ironIngot;
    public Sprite cannonBall;

    //To make chainshot
    public Sprite chainShot;

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

    public void ProduceGunpowder()
    {
        productionHolder = GameObject.FindGameObjectWithTag("Producing");

        if (productionHolder.transform.GetChild(0).GetComponent<Button>().onClick.GetPersistentEventCount() == 0)
        {
            if (rssHolder != null)
            {
                sulphur = rssHolder.GetComponent<PopulateResources>().resources[5].rssImage.GetComponent<SpriteRenderer>().sprite;
                coal = rssHolder.GetComponent<PopulateResources>().resources[8].rssImage.GetComponent<SpriteRenderer>().sprite;
                gunpowder = rssHolder.GetComponent<PopulateResources>().resources[14].rssImage.GetComponent<SpriteRenderer>().sprite;
                if (productionHolder.GetComponentInChildren<Button>().onClick.GetPersistentEventCount() == 0)
                {
                    productionHolder.GetComponentInChildren<Button>().onClick.AddListener(ProduceGPwder);
                }
            }
        }
        else
        {
            productionHolder.transform.GetChild(0).GetComponent<Button>().onClick.RemoveAllListeners();
        }
    }

    public void ProduceCannonball()
    {
        productionHolder = GameObject.FindGameObjectWithTag("Producing");

        if (productionHolder.transform.GetChild(0).GetComponent<Button>().onClick.GetPersistentEventCount() == 0)
        {
            if (rssHolder != null)
            {
                coal = rssHolder.GetComponent<PopulateResources>().resources[8].rssImage.GetComponent<SpriteRenderer>().sprite;
                ironIngot = rssHolder.GetComponent<PopulateResources>().resources[16].rssImage.GetComponent<SpriteRenderer>().sprite;
                gunpowder = rssHolder.GetComponent<PopulateResources>().resources[14].rssImage.GetComponent<SpriteRenderer>().sprite;
                cannonBall = rssHolder.GetComponent<PopulateResources>().resources[20].rssImage.GetComponent<SpriteRenderer>().sprite;
                if (productionHolder.GetComponentInChildren<Button>().onClick.GetPersistentEventCount() == 0)
                {
                    productionHolder.GetComponentInChildren<Button>().onClick.AddListener(ProduceCBall);
                }
            }
        }
        else
        {
            productionHolder.transform.GetChild(0).GetComponent<Button>().onClick.RemoveAllListeners();
        }
    }

    public void ProduceChainShot()
    {
        productionHolder = GameObject.FindGameObjectWithTag("Producing");

        if (productionHolder.transform.GetChild(0).GetComponent<Button>().onClick.GetPersistentEventCount() == 0)
        {
            if (rssHolder != null)
            {
                coal = rssHolder.GetComponent<PopulateResources>().resources[8].rssImage.GetComponent<SpriteRenderer>().sprite;
                ironIngot = rssHolder.GetComponent<PopulateResources>().resources[16].rssImage.GetComponent<SpriteRenderer>().sprite;
                gunpowder = rssHolder.GetComponent<PopulateResources>().resources[14].rssImage.GetComponent<SpriteRenderer>().sprite;
                chainShot = rssHolder.GetComponent<PopulateResources>().resources[26].rssImage.GetComponent<SpriteRenderer>().sprite;
                if (productionHolder.GetComponentInChildren<Button>().onClick.GetPersistentEventCount() == 0)
                {
                    productionHolder.GetComponentInChildren<Button>().onClick.AddListener(ProduceCShot);
                }
            }
        }
        else
        {
            productionHolder.transform.GetChild(0).GetComponent<Button>().onClick.RemoveAllListeners();
        }
    }

    public void ProduceGPwder()
    {
        UpdateInventory(5, 8, 14);
        canProduce = false;
        canTake = false;
    }

    public void ProduceCBall()
    {
        UpdateInventory2(8, 14, 16, 20);
        canProduce = false;
        canTake = false;
    }

    public void ProduceCShot()
    {
        UpdateInventory2(8, 14, 16, 26);
        canProduce = false;
        canTake = false;
    }

    public void UpdateInventory(int raw, int raw2, int produced)
    {
        canTake = true;

        if (warehouseInv != null)
        {
            for (int i = 0; i < warehouseInv.warehouseInventory.Length; i++)
            {
                if (warehouseInv.warehouseInventory[i].ressType == raw || warehouseInv.warehouseInventory[i].ressType == raw2)
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

    public void UpdateInventory2(int raw, int raw2, int raw3, int produced)
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