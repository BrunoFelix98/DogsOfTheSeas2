using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SellResourceScrpt : MonoBehaviour
{
    public Image[] inventorySlot;
    public Button[] inventorySlotButton;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < inventorySlot.Length; i++)
        {
            inventorySlotButton[i] = inventorySlot[i].transform.GetChild(0).GetComponent<Button>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
