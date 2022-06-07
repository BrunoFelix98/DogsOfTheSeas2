 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BotManager : MonoBehaviour
{
    public BoatClass[] boats;

    //Bot itself
    public GameObject botBoat;
    public GameObject boatInstance;

    //Loot
    public GameObject[] lootBoxes;
    public GameObject lootDrop = null;

    //Parameters of the bot
    public float botHullHealth;
    public float botSailHealth;
    public float botSpeed;
    public float botCargoSize;
    public float smallShipScale;
    public float shipScale;
    
    //Current boat type
    public int botBoatType;
    public int botLevel;

    //Boat inventory
    public int[] lootTypes = new int[4];
    public int[] quantity = new int[4];
    public bool looted;

    // Start is called before the first frame update
    void Start()
    {
        boats = PopulateBoats.instance.boats;

        switch (botLevel)
        {
            case 0:
                //Its a sloop

                botBoat = boats[0].boatPrefab;
                botHullHealth = boats[0].shipHitPoints;
                botSailHealth = boats[0].sailHitPoints;
                botSpeed = boats[0].defaultSpeed * boats[1].speedModifier;
                botCargoSize = boats[0].cargoSize;
                botBoatType = boats[0].type;
                GetComponent<NavMeshAgent>().radius = boats[0].boatCollisionRadius * 0.1f;
                GetComponent<CircleCollider2D>().radius = boats[0].boatCollisionRadius * 0.1f;
                GetComponent<NavMeshAgent>().updateRotation = false;
                GetComponent<NavMeshAgent>().updateUpAxis = false;

                break;
            case 1:
                //Its a brig

                botBoat = boats[1].boatPrefab;
                botHullHealth = boats[1].shipHitPoints;
                botSailHealth = boats[1].sailHitPoints;
                botSpeed = boats[1].defaultSpeed * boats[1].speedModifier;
                botCargoSize = boats[1].cargoSize;
                botBoatType = boats[1].type;
                GetComponent<NavMeshAgent>().radius = boats[1].boatCollisionRadius * 0.1f;
                GetComponent<CircleCollider2D>().radius = boats[1].boatCollisionRadius * 0.1f;
                GetComponent<NavMeshAgent>().updateRotation = false;
                GetComponent<NavMeshAgent>().updateUpAxis = false;

                break;
            case 2:
                //Its a galleon

                botBoat = boats[2].boatPrefab;
                botHullHealth = boats[2].shipHitPoints;
                botSailHealth = boats[2].sailHitPoints;
                botSpeed = boats[2].defaultSpeed * boats[1].speedModifier;
                botCargoSize = boats[2].cargoSize;
                botBoatType = boats[2].type;
                GetComponent<NavMeshAgent>().radius = boats[2].boatCollisionRadius * 0.1f;
                GetComponent<CircleCollider2D>().radius = boats[2].boatCollisionRadius * 0.1f;
                GetComponent<NavMeshAgent>().updateRotation = false;
                GetComponent<NavMeshAgent>().updateUpAxis = false;

                break;
            default:
                break;
        }

        boatInstance = Instantiate(botBoat, transform.position, transform.rotation, transform) as GameObject;
        //boatInstance.AddComponent<Rigidbody2D>();
        //boatInstance.AddComponent<CircleCollider2D>();
        //boatInstance.GetComponent<Rigidbody2D>().gravityScale = 0;
        ChangeScale(botLevel);
        boatInstance.tag = "Bot";
        AddLoot(botLevel);

        looted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (botHullHealth <= 0)
        {
            botHullHealth = 0;

            if (botBoat.activeSelf)
            {
                DropLoot(botLevel);
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                player.GetComponentInParent<PlayerBoat>().targetUI.SetActive(false);
                player.GetComponentInParent<PlayerBoat>().selectedEnemy = null;
                player.GetComponentInParent<PlayerBoat>().selectedEnemyBM = null;
                Destroy(boatInstance);
                GetComponentInChildren<StateManager>().enabled = false;
            }
        }

        if (looted)
        {
            Destroy(lootDrop);
        }

        botSpeed = ((boats[botBoatType].defaultSpeed * boats[botBoatType].speedModifier) * botSailHealth) / boats[botBoatType].sailHitPoints;
        GetComponent<NavMeshAgent>().speed = botSpeed;
    }

    public void AddLoot(int level)
    {
        switch (level)
        {
            case 0:
                //Small loot
                lootTypes[0] = 0; //wood
                lootTypes[1] = 1; //stone
                lootTypes[2] = 10; //hide
                lootTypes[3] = 15; //fabric

                quantity[0] = 15;
                quantity[1] = 11;
                quantity[2] = 6;
                quantity[3] = 3;
                break;
            case 1:
                //Medium loot
                lootTypes[0] = 0; //wood
                lootTypes[1] = 9; //rope
                lootTypes[2] = 10; //hide
                lootTypes[3] = 12; //fruit

                quantity[0] = 20;
                quantity[1] = 9;
                quantity[2] = 7;
                quantity[3] = 4;
                break;
            case 2:
                //Big loot
                lootTypes[0] = 5; //sulfur
                lootTypes[1] = 23; //planks
                lootTypes[2] = 24; //rum
                lootTypes[3] = 25; //food

                quantity[0] = 17;
                quantity[1] = 10;
                quantity[2] = 5;
                quantity[3] = 4;
                break;
            default:
                break;
        }

        lootBoxes[level].GetComponent<LootBoxes>().loot.lootType = lootTypes;
        lootBoxes[level].GetComponent<LootBoxes>().loot.lootQuantity = quantity;
    }

    public void DropLoot(int level)
    {
        if (lootDrop == null)
        {
            lootDrop = Instantiate(lootBoxes[level], transform.position, transform.rotation, transform) as GameObject;
            lootDrop.transform.rotation = Quaternion.Euler(-30, 0, 0);
        }
    }

    public void ChangeScale(int type)
    {
        switch (type)
        {
            case 0:
                //Sloop
                boatInstance.transform.localScale = new Vector3(smallShipScale, smallShipScale, smallShipScale);
                break;
            case 1:
                //Brig
                boatInstance.transform.localScale = new Vector3(shipScale, shipScale, shipScale);
                break;
            case 2:
                //Galleon
                boatInstance.transform.localScale = new Vector3(shipScale, shipScale, shipScale);
                break;
            default:
                break;
        }
    }
}