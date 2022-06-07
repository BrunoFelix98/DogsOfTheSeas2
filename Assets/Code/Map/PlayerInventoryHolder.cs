using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInventoryHolder : MonoBehaviour
{
    public PlayerGathering playerInvScript;

    public int currentTonnes;
    public int maxTonnes;

    public PlayerGathering.Inventory playerInvHolder = new PlayerGathering.Inventory();

    public int boatID = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInvScript == null && (SceneManager.GetActiveScene().name.Equals("Jogo1") || SceneManager.GetActiveScene().name.Equals("Jogo1_Mobile")))
        {
            GameObject playerInv = GameObject.FindGameObjectWithTag("Player");
            playerInvScript = playerInv.GetComponentInParent<PlayerGathering>();

            currentTonnes = playerInvScript.someInventory.totalRssAmount;
            maxTonnes = playerInvScript.someInventory.totalHoldableRss;
            playerInvHolder = playerInvScript.someInventory;
        }
        if (SceneManager.GetActiveScene().name.Equals("Homebay_New") || SceneManager.GetActiveScene().name.Equals("Homebay_New_Mobile"))
        {
            playerInvScript = null;
        }
    }

    public void PassToWarehouse()
    {
        GameObject warehouse = GameObject.FindGameObjectWithTag("Warehouse");

        warehouse.GetComponent<UpdateWarehouseInventory>().UpdateWarehouseValues();
    }

    public void PassToPlayerInv()
    {
        GameObject warehouse = GameObject.FindGameObjectWithTag("Warehouse");

        warehouse.GetComponent<UpdateWarehouseInventory>().UpdateBoatValues(maxTonnes);
    }
}