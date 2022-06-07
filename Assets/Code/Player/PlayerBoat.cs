using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlayerBoat : MonoBehaviour
{
    public GameObject boatInstance;

    public GameObject selectedEnemy;
    public BotManager selectedEnemyBM;

    public PlayerInventoryHolder playerInv;

    public Button repairHullButton;
    public Button repairSailButton;
    public Button chooseChainshot;
    public Button chooseCannonball;
    public Button gatherBtn;

    public GameObject targetUI;
    public Slider targetHealth;
    public Slider targetSail;

    public BoatClass[] boats;

    public Transform playerSpot;

    //Current boat
    public GameObject playerBoat;

    //Current boat parameters
    public float playerShipHitpoints;
    public float playerSailHitpoints;
    public float playerSpeed;
    public float playerExperience;

    public float selectedEnemyHullHealth;
    public float selectedEnemySailHealth;

    //Current boat type
    public int playerBoatType;
    public int playerCargoSize;
    public int playerLevel;
    public int selectedBoat;

    //Small boats
    public bool canCraftSmall;
    public bool canSailSmall;

    //Medium boats
    public bool canCraftMedium;
    public bool canSailMedium;

    //Large boats
    public bool canCraftLarge;
    public bool canSailLarge;

    //Parameters of the player
    public bool fireCannonball;
    public bool repairingSails;
    public bool repairingHull;
    public bool gathering;
    public float hullRepairTimeTop;
    public float hullRepairTimeCurrent;
    public float sailRepairTimeTop;
    public float sailRepairTimeCurrent;
    public float gatheringTimeTop;
    public float gatheringTimeCurrent;

    // Start is called before the first frame update
    void Start()
    {
        boats = PopulateBoats.instance.boats;

        playerInv = GameObject.FindGameObjectWithTag("InvHolder").GetComponent<PlayerInventoryHolder>();

        selectedBoat = playerInv.boatID;

        targetUI.SetActive(false);

        playerLevel = 1;
        canCraftSmall = true;
        canSailSmall = true;
        canCraftMedium = false;
        canSailMedium = false;
        canCraftLarge = false;
        canSailLarge = false;

        repairingHull = false;
        repairingSails = false;
        gathering = false;

        sailRepairTimeCurrent = sailRepairTimeTop;
        hullRepairTimeCurrent = hullRepairTimeTop;
        gatheringTimeCurrent = gatheringTimeTop;

        playerBoat = boats[selectedBoat].boatPrefab;
        playerShipHitpoints = boats[selectedBoat].shipHitPoints;
        playerSailHitpoints = boats[selectedBoat].sailHitPoints;
        playerSpeed = boats[selectedBoat].defaultSpeed * boats[selectedBoat].speedModifier;
        playerCargoSize = boats[selectedBoat].cargoSize;
        playerBoatType = boats[selectedBoat].boatID;

        boatInstance = Instantiate(playerBoat, playerSpot.position, playerSpot.rotation, transform) as GameObject;
        boatInstance.transform.localScale = boats[selectedBoat].scale;
        boatInstance.transform.rotation = Quaternion.Euler(-30, 0, 0);
        boatInstance.AddComponent<Rigidbody2D>();
        boatInstance.AddComponent<CircleCollider2D>();
        boatInstance.GetComponent<Rigidbody2D>().gravityScale = 0;
        boatInstance.GetComponent<CircleCollider2D>().radius = boats[selectedBoat].boatCollisionRadius;
        boatInstance.tag = "Player";

        repairHullButton.onClick.AddListener(RepairShip);
        repairSailButton.onClick.AddListener(RepairSails);
        chooseChainshot.onClick.AddListener(FireChainshot);
        chooseCannonball.onClick.AddListener(FireCannonball);
        gatherBtn.onClick.AddListener(Gather);
    }

    // Update is called once per frame
    void Update()
    {
        if (selectedEnemy != null)
        {
            selectedEnemyBM = selectedEnemy.GetComponentInParent<BotManager>();

            if (!targetUI.activeSelf)
            {
                targetUI.SetActive(true);
            }
            else
            {
                targetHealth.GetComponentInChildren<TextMeshProUGUI>().text = selectedEnemyBM.botHullHealth.ToString() + "/" + selectedEnemyBM.boats[selectedEnemyBM.botBoatType].shipHitPoints.ToString();
                targetSail.GetComponentInChildren<TextMeshProUGUI>().text = selectedEnemyBM.botSailHealth.ToString() + "/" + selectedEnemyBM.boats[selectedEnemyBM.botBoatType].sailHitPoints.ToString();

                targetHealth.maxValue = selectedEnemyBM.boats[selectedEnemyBM.botBoatType].shipHitPoints;
                targetSail.maxValue = selectedEnemyBM.boats[selectedEnemyBM.botBoatType].sailHitPoints;

                targetHealth.value = selectedEnemyBM.botHullHealth;
                targetSail.value = selectedEnemyBM.botSailHealth;

                if (Input.GetKeyDown("space"))
                {
                    if (fireCannonball)
                    {
                        //Shoot cannonball
                        FireCannonball();
                    }
                    else
                    {
                        //Shoot chainshot
                        FireChainshot();
                    }
                }
            }
        }
        else
        {
            targetUI.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            selectedBoat = 1;
            playerBoat = boats[selectedBoat].boatPrefab;
            playerShipHitpoints = boats[selectedBoat].shipHitPoints;
            playerSailHitpoints = boats[selectedBoat].sailHitPoints;
            playerSpeed = boats[selectedBoat].defaultSpeed * boats[selectedBoat].speedModifier;
            playerCargoSize = boats[selectedBoat].cargoSize;
            playerBoatType = boats[selectedBoat].boatID;

            Destroy(boatInstance);

            boatInstance = Instantiate(playerBoat, playerSpot.position, playerSpot.rotation, transform) as GameObject;
            boatInstance.transform.localScale = boats[selectedBoat].scale;
            boatInstance.transform.rotation = Quaternion.Euler(-30, 0, 0);
            boatInstance.AddComponent<Rigidbody2D>();
            boatInstance.AddComponent<CircleCollider2D>();
            boatInstance.GetComponent<Rigidbody2D>().gravityScale = 0;
            boatInstance.GetComponent<CircleCollider2D>().radius = boats[selectedBoat].boatCollisionRadius;
            boatInstance.tag = "Player";
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            selectedBoat = 2;
            playerBoat = boats[selectedBoat].boatPrefab;
            playerShipHitpoints = boats[selectedBoat].shipHitPoints;
            playerSailHitpoints = boats[selectedBoat].sailHitPoints;
            playerSpeed = boats[selectedBoat].defaultSpeed * boats[selectedBoat].speedModifier;
            playerCargoSize = boats[selectedBoat].cargoSize;
            playerBoatType = boats[selectedBoat].boatID;

            Destroy(boatInstance);

            boatInstance = Instantiate(playerBoat, playerSpot.position, playerSpot.rotation, transform) as GameObject;
            boatInstance.transform.localScale = boats[selectedBoat].scale;
            boatInstance.transform.rotation = Quaternion.Euler(-30, 0, 0);
            boatInstance.AddComponent<Rigidbody2D>();
            boatInstance.AddComponent<CircleCollider2D>();
            boatInstance.GetComponent<Rigidbody2D>().gravityScale = 0;
            boatInstance.GetComponent<CircleCollider2D>().radius = boats[selectedBoat].boatCollisionRadius;
            boatInstance.tag = "Player";
        }

        if (repairingSails)
        {
            if (playerSailHitpoints < boats[selectedBoat].sailHitPoints)
            {
                sailRepairTimeCurrent -= Time.deltaTime;
                if (sailRepairTimeCurrent < 0)
                {
                    playerSailHitpoints += 10;
                    sailRepairTimeCurrent = sailRepairTimeTop;
                }

                playerSpeed = playerSpeed * 0.2f;
            }
            else
            {
                repairingSails = false;

                playerSpeed = boats[selectedBoat].defaultSpeed * boats[selectedBoat].speedModifier;
            }
        }
        else
        {
            playerSpeed = ((boats[selectedBoat].defaultSpeed * boats[selectedBoat].speedModifier) * playerSailHitpoints) / boats[selectedBoat].sailHitPoints;
        }

        if (repairingHull)
        {
            if (playerShipHitpoints < boats[selectedBoat].shipHitPoints)
            {
                hullRepairTimeCurrent -= Time.deltaTime;
                if (hullRepairTimeCurrent < 0)
                {
                    playerShipHitpoints += 10;
                    hullRepairTimeCurrent = hullRepairTimeTop;
                }

                playerSpeed = playerSpeed * 0.2f;
            }
            else
            {
                repairingHull = false;

                playerSpeed = boats[selectedBoat].defaultSpeed * boats[selectedBoat].speedModifier;
            }
        }
        else
        {
            playerSpeed = ((boats[selectedBoat].defaultSpeed * boats[selectedBoat].speedModifier) * playerSailHitpoints) / boats[selectedBoat].sailHitPoints;
        }

        if (playerShipHitpoints <= 0)
        {
            playerShipHitpoints = 0;
        }

        if (playerSailHitpoints <= 0)
        {
            playerSailHitpoints = 0;
        }
    }

    public void Gather()
    {
        for (int i = 0; i < GetComponent<PlayerGathering>().mapRss.Length; i++)
        {
            if (GetComponent<PlayerGathering>().mapRss[i].GetComponent<CheckForPlayer>().playerEntered == true)
            {
                //Can collect from this rss

                GetComponent<PlayerGathering>().rssType = GetComponent<PlayerGathering>().mapRss[i].GetComponent<CheckForPlayer>().resourceType;

                for (int z = 0; z < GetComponent<PlayerGathering>().someInventory.GetInventoryItems().Length; z++)
                {
                    if (GetComponent<PlayerGathering>().someInventory.totalRssAmount < GetComponent<PlayerGathering>().someInventory.totalHoldableRss) //Check if the player has cargo space left
                    {
                        if (GetComponent<PlayerGathering>().someInventory.GetInventoryItems()[z].ressType == -1) //Check if the slot is empty
                        {
                            GetComponent<PlayerGathering>().someInventory.GetInventoryItems()[z].ressType = GetComponent<PlayerGathering>().rssType; //If empty, add this type to it
                        }
                        else if (GetComponent<PlayerGathering>().someInventory.GetInventoryItems()[z].ressType == GetComponent<PlayerGathering>().rssType) //If not empty but it has the same type as the one collected, add more to it
                        {
                            gatheringTimeCurrent -= Time.deltaTime;
                            if (gatheringTimeCurrent < 0)
                            {
                                GetComponent<PlayerGathering>().AddToExisting(i, z, true);
                            }
                        }
                        else
                        {
                            //This slot is full with a resource type that is not the one trying to be collected, move on
                            continue;
                        }

                        GetComponent<PlayerGathering>().AddNew(i, z, GetComponent<PlayerGathering>().rssType);

                        break;
                    }
                    break;
                }
            }
        }
    }

    public void RepairShip()
    {
        repairingHull = true;
    }

    public void RepairSails()
    {
        repairingSails = true;
    }

    public void FireCannonball()
    {
        fireCannonball = true;
        selectedEnemy.GetComponentInParent<BotManager>().botHullHealth = selectedEnemy.GetComponentInParent<BotManager>().botHullHealth - 10;
    }

    public void FireChainshot()
    {
        fireCannonball = false;
        selectedEnemy.GetComponentInParent<BotManager>().botSailHealth = selectedEnemy.GetComponentInParent<BotManager>().botSailHealth - 10;
    }
}