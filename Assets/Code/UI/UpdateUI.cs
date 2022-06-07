using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpdateUI : MonoBehaviour
{
    public TextMeshProUGUI shipHitpoints;
    public TextMeshProUGUI sailHitpoints;
    public TextMeshProUGUI tonnage;
    public TextMeshProUGUI currentShip;

    public Image[] inventorySlots;

    public Slider shipHitpointsScrollBar;
    public Slider sailHitpointsScrollBar;

    public PlayerBoat Player;
    public PlayerGathering PlayerGather;

    private float currentShipHitpoints;
    private float currentSailHitpoints;
    private float currentWeight = 0;

    private int currentBoat;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            inventorySlots[i].GetComponentInChildren<TextMeshProUGUI>().text = "";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.boatInstance != null)
        {
            currentBoat = Player.playerBoatType;
            currentWeight = PlayerGather.someInventory.totalRssAmount;

            currentShipHitpoints = Player.playerShipHitpoints;
            currentSailHitpoints = Player.playerSailHitpoints;

            shipHitpointsScrollBar.maxValue = Player.boats[currentBoat].shipHitPoints;
            sailHitpointsScrollBar.maxValue = Player.boats[currentBoat].sailHitPoints;

            shipHitpointsScrollBar.value = Player.playerShipHitpoints;
            sailHitpointsScrollBar.value = Player.playerSailHitpoints;

            shipHitpoints.text = currentShipHitpoints.ToString() + " / " + Player.boats[currentBoat].shipHitPoints.ToString();
            sailHitpoints.text = currentSailHitpoints.ToString() + " / " + Player.boats[currentBoat].sailHitPoints.ToString();

            tonnage.text = "Tonnage: " + currentWeight.ToString() + " / " + Player.boats[currentBoat].cargoSize.ToString();
        }
    }
}
