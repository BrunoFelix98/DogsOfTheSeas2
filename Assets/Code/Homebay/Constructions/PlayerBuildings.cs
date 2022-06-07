using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerBuildings : MonoBehaviour
{
    public Image[] constructionSlots;
    public BuildingsClass[] buildings;
    public TMP_Dropdown[] dropdownOptions;
    public int[] currentBuildingBuilt = {0,0,0,0,0}; //Preserve the current type of buildings that are built (each index represents a slot, the value in that index represents the type of building)

    //public GameObject buildingSlotPrefab;
    //public GameObject[] slotAnchors;

    // Start is called before the first frame update
    void Start()
    {
        buildings = PopulateBuildings.instance.buildings;

        //Delete all options if there are any
        for (int i = 0; i < dropdownOptions.Length; i++)
        {
            dropdownOptions[i].options.Clear();
        }

        //Create lists for the names of the buildings as well as their sprites
        List<string> buildNames = new List<string>();
        List<Sprite> buildSprites = new List<Sprite>();

        //Assign the values of the lists
        for (int i = 0; i < buildings.Length; i++)
        {
            buildNames.Add(buildings[i].buildName);
            buildSprites.Add(buildings[i].buildingImage);
        }

        //ConstructDropdowns(buildSprites, buildNames);

        //Assign the values of the buildings into the dropdown menus' options
        for (int i = 0; i < buildNames.Count; i++)
        {
            for (int j = 0; j < dropdownOptions.Length; j++)
            {
                if (!buildings[i].isBuilt)
                {
                    dropdownOptions[j].options.Add(new TMP_Dropdown.OptionData() { text = buildNames[i], image = buildSprites[i] });
                }
            }
        }

        //Add listener event to slot 0
        SlotZeroChanged(dropdownOptions[0]);
        dropdownOptions[0].onValueChanged.AddListener(delegate { SlotZeroChanged(dropdownOptions[0]); });

        //Add listener event to slot 1
        SlotOneChanged(dropdownOptions[1]);
        dropdownOptions[1].onValueChanged.AddListener(delegate { SlotOneChanged(dropdownOptions[1]); });

        //Add listener event to slot 2
        SlotTwoChanged(dropdownOptions[2]);
        dropdownOptions[2].onValueChanged.AddListener(delegate { SlotTwoChanged(dropdownOptions[2]); });

        //Add listener event to slot 3
        SlotThreeChanged(dropdownOptions[3]);
        dropdownOptions[3].onValueChanged.AddListener(delegate { SlotThreeChanged(dropdownOptions[3]); });

        //Add listener event to slot 4
        SlotFourChanged(dropdownOptions[4]);
        dropdownOptions[4].onValueChanged.AddListener(delegate { SlotFourChanged(dropdownOptions[4]); });
    }

    /*public void ConstructDropdowns(List<Sprite> image, List<string> text)
    {
        List<GameObject> buildingsPrefabInstance = new List<GameObject>();
        List<GameObject> productionOptionsInstance = new List<GameObject>();

        for (int i = 0; i < slotAnchors.Length; i++)
        {
            GameObject slotInstance = Instantiate(buildingSlotPrefab, slotAnchors[i].transform);
            slotInstance.transform.parent = slotAnchors[i].transform;

            ConstructBuildingSlot(image[i], text[i]);

            buildingsPrefabInstance.Add(slotInstance);
            //Call initialised interface
        }
    }

    public void ConstructBuildingSlot(Sprite image, string text)
    { 

    }*/

    void SlotZeroChanged(TMP_Dropdown dropdown)
    {
        int index = dropdown.value; //Set the index value to the current selected value

        buildings[currentBuildingBuilt[0]].isBuilt = false; //Unbuild the previous building that was in this slot
        buildings[index].isBuilt = true; //Build the new building
        currentBuildingBuilt[0] = index; //Update the current built building value

        constructionSlots[0].sprite = dropdown.options[index].image; //Update the image of the slot

        if (constructionSlots[0].sprite == null)
        {
            constructionSlots[0].color = new Color(constructionSlots[0].color.r, constructionSlots[0].color.r, constructionSlots[0].color.b, 0.0f);
        }
        else
        {
            constructionSlots[0].color = new Color(constructionSlots[0].color.r, constructionSlots[0].color.r, constructionSlots[0].color.b, 1.0f);
        }

        AddOptions(index);
    }

    void SlotOneChanged(TMP_Dropdown dropdown)
    {
        int index = dropdown.value;

        buildings[currentBuildingBuilt[1]].isBuilt = false;
        buildings[index].isBuilt = true;
        currentBuildingBuilt[1] = index;

        constructionSlots[1].sprite = dropdown.options[index].image;

        if (constructionSlots[1].sprite == null)
        {
            constructionSlots[1].color = new Color(constructionSlots[1].color.r, constructionSlots[1].color.r, constructionSlots[1].color.b, 0.0f);
        }
        else
        {
            constructionSlots[1].color = new Color(constructionSlots[1].color.r, constructionSlots[1].color.r, constructionSlots[1].color.b, 1.0f);
        }
    }

    void SlotTwoChanged(TMP_Dropdown dropdown)
    {
        int index = dropdown.value;

        buildings[currentBuildingBuilt[2]].isBuilt = false;
        buildings[index].isBuilt = true;
        currentBuildingBuilt[2] = index;

        constructionSlots[2].sprite = dropdown.options[index].image;

        if (constructionSlots[2].sprite == null)
        {
            constructionSlots[2].color = new Color(constructionSlots[2].color.r, constructionSlots[2].color.r, constructionSlots[2].color.b, 0.0f);
        }
        else
        {
            constructionSlots[2].color = new Color(constructionSlots[2].color.r, constructionSlots[2].color.r, constructionSlots[2].color.b, 1.0f);
        }
    }

    void SlotThreeChanged(TMP_Dropdown dropdown)
    {
        int index = dropdown.value;

        buildings[currentBuildingBuilt[3]].isBuilt = false;
        buildings[index].isBuilt = true;
        currentBuildingBuilt[3] = index;

        constructionSlots[3].sprite = dropdown.options[index].image;

        if (constructionSlots[3].sprite == null)
        {
            constructionSlots[3].color = new Color(constructionSlots[3].color.r, constructionSlots[3].color.r, constructionSlots[3].color.b, 0.0f);
        }
        else
        {
            constructionSlots[3].color = new Color(constructionSlots[3].color.r, constructionSlots[3].color.r, constructionSlots[3].color.b, 1.0f);
        }
    }

    void SlotFourChanged(TMP_Dropdown dropdown)
    {
        int index = dropdown.value;

        buildings[currentBuildingBuilt[4]].isBuilt = false;
        buildings[index].isBuilt = true;
        currentBuildingBuilt[4] = index;

        constructionSlots[4].sprite = dropdown.options[index].image;

        if (constructionSlots[4].sprite == null)
        {
            constructionSlots[4].color = new Color(constructionSlots[4].color.r, constructionSlots[4].color.r, constructionSlots[4].color.b, 0.0f);
        }
        else
        {
            constructionSlots[4].color = new Color(constructionSlots[4].color.r, constructionSlots[4].color.r, constructionSlots[4].color.b, 1.0f);
        }
    }

    public void AddOptions(int index)
    {
        //Update the dropdown

        switch (index)
        {
            case 0:
                //Open slot
                break;
            case 1:
                //Blacksmith
                dropdownOptions[0].options.Clear(); //Clear options of the list

                //Add the new options
                dropdownOptions[0].options.Add(new TMP_Dropdown.OptionData() { text = "Blacksmith" });
                dropdownOptions[0].options.Add(new TMP_Dropdown.OptionData() { text = "Produce Iron Ingot" });
                dropdownOptions[0].options.Add(new TMP_Dropdown.OptionData() { text = "Produce Copper Ingot" });
                dropdownOptions[0].options.Add(new TMP_Dropdown.OptionData() { text = "Produce Gold Ingot" });
                dropdownOptions[0].options.Add(new TMP_Dropdown.OptionData() { text = "Upgrade" });
                dropdownOptions[0].options.Add(new TMP_Dropdown.OptionData() { text = "Destroy" });
                //This currently doesnt work how I want it to
                //Currently all dropdowns, regardless of type of building, access this code, and i only want this to happen when the building is not built, not when it is already built

                break;
            case 2:
                //Metallurgy
                break;
            case 3:
                //Workshop
                break;
            case 4:
                //PastorialFarm
                break;
            case 5:
                //Quarry
                break;
            case 6:
                //Farm
                break;
            case 7:
                //WoodWorkshop
                break;
            case 8:
                //Tavern
                break;
            case 9:
                //TextileWorkshop
                break;
            default:
                break;
        }
    }
}
