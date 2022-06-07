using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DefaultWarehouse : MonoBehaviour
{
    public GameObject warehouseInv;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TMP_Dropdown>().onValueChanged.AddListener(delegate { OnOptionValueChanged(GetComponent<TMP_Dropdown>()); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnOptionValueChanged(TMP_Dropdown dropdown)
    {
        switch (dropdown.value)
        {
            case 1:
                if (warehouseInv.gameObject.activeSelf)
                {
                    warehouseInv.gameObject.SetActive(false);
                }
                else
                {
                    warehouseInv.gameObject.SetActive(true);
                }
                dropdown.value = 0;
                break;
            case 2:
                print("Leveled up warehouse!");
                dropdown.value = 0;
                break;
            case 0:
            default:
                break;
        }        
        dropdown.RefreshShownValue();
    }
}
