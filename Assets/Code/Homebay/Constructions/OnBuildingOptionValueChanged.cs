using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OnBuildingOptionValueChanged : MonoBehaviour
{
    public PlayerBuildings_New playerBuildingScript;

    public int slotID;

    public void Start()
    {
        GetComponent<TMP_Dropdown>().onValueChanged.AddListener(delegate { OnOptionValueChanged(GetComponent<TMP_Dropdown>()); });
    }

    public void OnOptionValueChanged(TMP_Dropdown dropdown)
    {
        playerBuildingScript.SwitchToProduction((E_BuildingType)dropdown.value, slotID);
        dropdown.value = 0;
        dropdown.RefreshShownValue();
    }
}
