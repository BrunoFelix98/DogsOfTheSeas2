using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DefaultDock : MonoBehaviour
{
    public GameObject boatInv;
    public GameObject makeBoatUI;

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
                if (makeBoatUI.gameObject.activeSelf)
                {
                    makeBoatUI.gameObject.SetActive(false);
                }
                else
                {
                    makeBoatUI.gameObject.SetActive(true);
                }
                dropdown.value = 0;
                break;
            case 2:
                if (boatInv.gameObject.activeSelf)
                {
                    boatInv.gameObject.SetActive(false);
                }
                else
                {
                    boatInv.gameObject.SetActive(true);
                }
                dropdown.value = 0;
                break;
            case 3:
                print("Leveled up Dock!");
                dropdown.value = 0;
                break;
            case 0:
            default:
                break;
        }        
        dropdown.RefreshShownValue();
    }
}
