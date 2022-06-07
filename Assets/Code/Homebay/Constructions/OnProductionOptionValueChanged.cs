using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OnProductionOptionValueChanged : MonoBehaviour
{
    public PlayerBuildings_New playerBuildingScript;

    public int slotID;

    public E_BuildingType buildType;

    public void Start()
    {
        GetComponent<TMP_Dropdown>().onValueChanged.AddListener(delegate { OnOptionValueChanged(GetComponent<TMP_Dropdown>()); });
    }

    public void OnOptionValueChanged(TMP_Dropdown dropdown)
    {
        bool isDestroy = dropdown.options[dropdown.value].text.Contains("Destroy");
        playerBuildingScript.SwitchToBuilding(buildType, slotID, isDestroy);

        switch(buildType)
        {
            case E_BuildingType.Blacksmith:
                playerBuildingScript.buildingUI.buildName = "Blacksmith";
                switch (dropdown.value)
                {
                    case 1:
                        playerBuildingScript.buildingUI.resourceToUse = 5;
                        playerBuildingScript.buildingUI.resourceToMake = 14;
                        playerBuildingScript.buildingUI.OpenProductionUI();
                        GetComponentInParent<ProduceBlacksmith>().ProduceGunpowder();
                        break;
                    case 2:
                        playerBuildingScript.buildingUI.resourceToUse = 16;
                        playerBuildingScript.buildingUI.resourceToMake = 20;
                        playerBuildingScript.buildingUI.OpenProductionUI();
                        GetComponentInParent<ProduceBlacksmith>().ProduceCannonball();
                        break;
                    case 3:
                        playerBuildingScript.buildingUI.resourceToUse = 16;
                        playerBuildingScript.buildingUI.resourceToMake = 26;
                        playerBuildingScript.buildingUI.OpenProductionUI();
                        GetComponentInParent<ProduceBlacksmith>().ProduceChainShot();
                        break;
                    default:
                        break;
                }
                dropdown.value = 0;
                break;
            case E_BuildingType.Metallurgy:
                playerBuildingScript.buildingUI.buildName = "Metallurgy";
                switch (dropdown.value)
                {
                    case 1:
                        playerBuildingScript.buildingUI.resourceToUse = 3;
                        playerBuildingScript.buildingUI.resourceToMake = 16;
                        playerBuildingScript.buildingUI.OpenProductionUI();
                        GetComponentInParent<ProduceMetallurgy>().ProduceIronIngot();
                        break;
                    case 2:
                        playerBuildingScript.buildingUI.resourceToUse = 6;
                        playerBuildingScript.buildingUI.resourceToMake = 17;
                        playerBuildingScript.buildingUI.OpenProductionUI();
                        GetComponentInParent<ProduceMetallurgy>().ProduceCopperIngot();
                        break;
                    case 3:
                        playerBuildingScript.buildingUI.resourceToUse = 7;
                        playerBuildingScript.buildingUI.resourceToMake = 18;
                        playerBuildingScript.buildingUI.OpenProductionUI();
                        GetComponentInParent<ProduceMetallurgy>().ProduceGoldIngot();
                        break;
                    default:
                        break;
                }
                dropdown.value = 0;
                break;
            case E_BuildingType.Workshop:
                playerBuildingScript.buildingUI.buildName = "Workshop";
                switch (dropdown.value)
                {
                    case 1:
                        playerBuildingScript.buildingUI.resourceToUse = 9;
                        playerBuildingScript.buildingUI.resourceToMake = 22;
                        playerBuildingScript.buildingUI.OpenProductionUI();
                        GetComponentInParent<ProduceWorkshop>().ProduceTools();
                        break;
                    case 2:
                        playerBuildingScript.buildingUI.resourceToUse = 17;
                        playerBuildingScript.buildingUI.resourceToMake = 21;
                        playerBuildingScript.buildingUI.OpenProductionUI();
                        GetComponentInParent<ProduceWorkshop>().ProduceCannonsS();
                        break;
                    case 3:
                        playerBuildingScript.buildingUI.resourceToUse = 16;
                        playerBuildingScript.buildingUI.resourceToMake = 21;
                        playerBuildingScript.buildingUI.OpenProductionUI();
                        GetComponentInParent<ProduceWorkshop>().ProduceCannonsM();
                        break;
                    case 4:
                        playerBuildingScript.buildingUI.resourceToUse = 18;
                        playerBuildingScript.buildingUI.resourceToMake = 21;
                        playerBuildingScript.buildingUI.OpenProductionUI();
                        GetComponentInParent<ProduceWorkshop>().ProduceCannonsL();
                        break;
                    default:
                        break;
                }
                dropdown.value = 0;
                break;
            case E_BuildingType.PastorialFarm:
                playerBuildingScript.buildingUI.buildName = "Pastorial Farm";
                dropdown.value = 0;
                break;
            case E_BuildingType.Quarry:
                playerBuildingScript.buildingUI.buildName = "Quarry";
                switch (dropdown.value)
                {
                    case 1:
                        playerBuildingScript.buildingUI.resourceToUse = 1;
                        playerBuildingScript.buildingUI.resourceToMake = 19;
                        playerBuildingScript.buildingUI.OpenProductionUI();
                        GetComponentInParent<ProduceQuarry>().ProduceStoneBlocks();
                        break;
                    default:
                        break;
                }
                dropdown.value = 0;
                break;
            case E_BuildingType.Farm:
                playerBuildingScript.buildingUI.buildName = "Farm";
                dropdown.value = 0;
                break;
            case E_BuildingType.WoodWorkshop:
                playerBuildingScript.buildingUI.buildName = "Wood Workshop";
                switch (dropdown.value)
                {
                    case 1:
                        playerBuildingScript.buildingUI.resourceToUse = 0;
                        playerBuildingScript.buildingUI.resourceToMake = 23;
                        playerBuildingScript.buildingUI.OpenProductionUI();
                        GetComponentInParent<ProduceWoodWorkshop>().ProducePlanks();
                        break;
                    default:
                        break;
                }
                dropdown.value = 0;
                break;
            case E_BuildingType.Tavern:
                playerBuildingScript.buildingUI.buildName = "Tavern";
                switch (dropdown.value)
                {
                    case 1:
                        playerBuildingScript.buildingUI.resourceToUse = 12;
                        playerBuildingScript.buildingUI.resourceToMake = 24;
                        playerBuildingScript.buildingUI.OpenProductionUI();
                        GetComponentInParent<ProduceTavern>().ProduceRum();
                        break;
                    case 2:
                        playerBuildingScript.buildingUI.resourceToUse = 13;
                        playerBuildingScript.buildingUI.resourceToMake = 25;
                        playerBuildingScript.buildingUI.OpenProductionUI();
                        GetComponentInParent<ProduceTavern>().ProduceFood();
                        break;
                    default:
                        break;
                }
                dropdown.value = 0;
                break;
            case E_BuildingType.TextileWorkshop:
                playerBuildingScript.buildingUI.buildName = "Textile Workshop";
                switch (dropdown.value)
                {
                    case 1:
                        playerBuildingScript.buildingUI.resourceToUse = 4;
                        playerBuildingScript.buildingUI.resourceToMake = 15;
                        playerBuildingScript.buildingUI.OpenProductionUI();
                        GetComponentInParent<ProduceTextileWorkshop>().ProduceFabric();
                        break;
                    case 2:
                        playerBuildingScript.buildingUI.resourceToUse = 3;
                        playerBuildingScript.buildingUI.resourceToMake = 9;
                        playerBuildingScript.buildingUI.OpenProductionUI();
                        GetComponentInParent<ProduceTextileWorkshop>().ProduceRope();
                        break;
                    case 3:
                        playerBuildingScript.buildingUI.resourceToUse = 11;
                        playerBuildingScript.buildingUI.resourceToMake = 10;
                        playerBuildingScript.buildingUI.OpenProductionUI();
                        GetComponentInParent<ProduceTextileWorkshop>().ProduceHide();
                        break;
                    default:
                        break;
                }
                dropdown.value = 0;
                break;
            case E_BuildingType.OpenSlot:
            case E_BuildingType.count:
            default:
                break;
        }
        dropdown.RefreshShownValue();
    }
}
