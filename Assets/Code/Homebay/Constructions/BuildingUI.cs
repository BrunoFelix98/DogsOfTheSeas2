using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuildingUI : MonoBehaviour
{
    public BuildingTypesClass[] buildings;
    public PlayerBuildings_New slots;

    public Sprite[] boatImages;

    public UpdateWarehouseInventory warehouseInv;

    public TextMeshProUGUI constructionTitle;
    public TextMeshProUGUI productionText;
    public TextMeshProUGUI availableRawMaterial;
    public Image rawProductImage;
    public Image productImage;
    public TMP_InputField quantityToProduce;

    public RawImage productionUI;

    public Button close;

    public bool producing;

    public string buildName;
    public int resourceToUse;
    public int resourceToMake;

    // Start is called before the first frame update
    void Start()
    {
        producing = false;

        buildings = PopulateBuildingTypes.instance.buildingTypes;
    }

    // Update is called once per frame
    void Update()
    {
        if (producing)
        {
            productionUI.gameObject.SetActive(true);
            close.onClick.AddListener(CloseProduction);
        }
        else
        {
            productionUI.GetComponentInChildren<Button>().onClick.RemoveAllListeners();
            productionUI.gameObject.SetActive(false);
        }

        if (warehouseInv == null)
        {
            warehouseInv = GameObject.FindGameObjectWithTag("Warehouse").GetComponent<UpdateWarehouseInventory>();
        }
    }

    public void CloseProduction()
    {
        producing = false;
    }

    public void OpenProductionUI()
    {
        producing = true;

        productionUI.gameObject.SetActive(true);

        constructionTitle.text = buildName;
        rawProductImage.sprite = GameObject.FindGameObjectsWithTag("Controllers")[1].GetComponent<PopulateResources>().resources[resourceToUse].rssImage.GetComponent<SpriteRenderer>().sprite;
        productImage.sprite = GameObject.FindGameObjectsWithTag("Controllers")[1].GetComponent<PopulateResources>().resources[resourceToMake].rssImage.GetComponent<SpriteRenderer>().sprite;

        for (int i = 0; i < warehouseInv.warehouseInventory.Length; i++)
        {
            if (warehouseInv.warehouseInventory[i].ressType == resourceToUse)
            {
                availableRawMaterial.text = warehouseInv.warehouseInventory[i].rssAmount.ToString();
            }
        }
    }
}