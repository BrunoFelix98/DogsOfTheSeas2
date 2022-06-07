using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

public class BuildingOptionDisabler : MonoBehaviour, IPointerClickHandler
{
    private TMP_Dropdown Dropdown;

    public PopulateBuildings popBuildings;

    private void Awake()
    {
        popBuildings = PopulateBuildings.instance;

        Dropdown = GetComponent<TMP_Dropdown>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        var toggleable = Dropdown.GetComponentsInChildren<Toggle>(true);

        for (int i = 0; i < popBuildings.buildings.Length; i++)
        {
            if (popBuildings.buildings[i].isBuilt)
            {
                toggleable[i + 2].interactable = false;
            }
        }
    }
}
