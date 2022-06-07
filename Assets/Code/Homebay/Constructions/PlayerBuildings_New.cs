using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum E_BuildingType
{
    OpenSlot,
    Blacksmith,
    Metallurgy,
    Workshop,
    PastorialFarm,
    Quarry,
    Farm,
    WoodWorkshop,
    Tavern,
    TextileWorkshop,
    count //Acts like an END of a list, using count-1
}

[System.Serializable]
public struct S_ProductionUI
{
    E_BuildingType buildingType;

    public GameObject buildingDropdown;
    public GameObject productionDropdown;
}

public class PlayerBuildings_New : MonoBehaviour
{
    public GameObject[] productionOptions = new GameObject[(int)E_BuildingType.count]; //All the types of production UI references (blacksmith UI for example) "Nelson did something naughty and he transformed the prefabs into a list in this case" - Nelson 2022

    public BuildingUI buildingUI;

    private S_ProductionUI[] instantiatedSlots = new S_ProductionUI[5]; //All the UI references for the slots
    private int availableSlots = 5; //Count of the total slots

    public BuildingsClass[] buildings;

    public GameObject buildingSlotPrefab;
    public GameObject[] slotAnchors;

    // Start is called before the first frame update
    void Start()
    {
        buildings = PopulateBuildings.instance.buildings;

        buildingUI = GetComponentInParent<BuildingUI>();

        ConstructData();

        //Create lists for the names of the buildings as well as their sprites
        List<string> buildNames = new List<string>();
        List<Sprite> buildSprites = new List<Sprite>();

        //Assign the values of the lists
        for (int i = 0; i < buildings.Length; i++)
        {
            buildNames.Add(buildings[i].buildName);
            buildSprites.Add(buildings[i].buildingImage);
        }
    }

    public void ConstructData()
    {
        for (int i = 0; i < availableSlots; i++)
        {
            instantiatedSlots[i] = new S_ProductionUI(); //Populate the array with empty structs

            GameObject newBuildInstance = Instantiate(buildingSlotPrefab, slotAnchors[i].transform); //Instantiate a building prefab
            instantiatedSlots[i].buildingDropdown = newBuildInstance; //Add this prefab to that slot of the array
            InitialiseBuildingScript(newBuildInstance, i);
        }

        for (int i = 1; i < (int) E_BuildingType.count; i++)
        {
            GameObject newProdInstance = Instantiate(productionOptions[i], slotAnchors[0].transform); //Instantiate the production option for that building
            productionOptions[i] = newProdInstance; //Naugthy bit
            newProdInstance.SetActive(false); //Disable them since they are unnecessary until they are used
        }
    }

    public void InitialiseBuildingScript(GameObject instance, int slotID)
    {
        OnBuildingOptionValueChanged[] buildOptValueChanged = instance.GetComponentsInChildren<OnBuildingOptionValueChanged>();

        for (int i = 0; i < buildOptValueChanged.Length; i++)
        {
            buildOptValueChanged[i].playerBuildingScript = this;
            buildOptValueChanged[i].slotID = slotID;
        }
    }

    public void InitialiseProductionScript(GameObject instance, int slotID, E_BuildingType buildType)
    {
        OnProductionOptionValueChanged[] productionOptValueChanged = instance.GetComponentsInChildren<OnProductionOptionValueChanged>();

        for (int i = 0; i < productionOptValueChanged.Length; i++)
        {
            productionOptValueChanged[i].playerBuildingScript = this;
            productionOptValueChanged[i].slotID = slotID;
            productionOptValueChanged[i].buildType = buildType;
        }
    }

    public void SwitchToProduction(E_BuildingType buildType, int slotID)
    {
        if (buildType == E_BuildingType.OpenSlot)
        {
            return;
        }

        buildings[(int)buildType].isBuilt = true;

        instantiatedSlots[slotID].productionDropdown = GetProductionDropdownFromEnum(buildType);
        instantiatedSlots[slotID].productionDropdown.transform.parent = slotAnchors[slotID].transform;
        instantiatedSlots[slotID].productionDropdown.transform.position = slotAnchors[slotID].transform.position;

        InitialiseProductionScript(instantiatedSlots[slotID].productionDropdown, slotID, buildType);

        instantiatedSlots[slotID].buildingDropdown.SetActive(false);
        instantiatedSlots[slotID].productionDropdown.SetActive(true);
    }

    public void SwitchToBuilding(E_BuildingType buildType, int slotID, bool isDestroy)
    {
        if (!isDestroy)
        {
            return;
        }

        buildings[(int)buildType].isBuilt = false;

        instantiatedSlots[slotID].productionDropdown.SetActive(false);
        instantiatedSlots[slotID].productionDropdown = null;
        instantiatedSlots[slotID].buildingDropdown.SetActive(true);
    }

    public GameObject GetProductionDropdownFromEnum(E_BuildingType buildType)
    {
        return productionOptions[(int)buildType];
    }
}