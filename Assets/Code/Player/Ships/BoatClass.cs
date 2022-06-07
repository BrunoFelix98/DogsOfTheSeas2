using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BoatClass
{
    //Boat Itself
    public GameObject boatPrefab;

    //Float parameters
    public float defaultSpeed;
    public float speedModifier; //According to boat type
    public float shipHitPoints;
    public float sailHitPoints;
    public float boatCollisionRadius;

    //Int parameters
    public int cargoSize; //Maximum tonneage of the cargo hold of the boat
    public int type; // 0 = Light, 1 = Medium, 2 = Large
    public int cannonCount; //Number of cannons on the ship (total number, portside + broadside)
    public int boatID; //ID of the boat
    public int[] resourceTypeCost; //Types of resources used in the construction of this boat
    public int[] resourceTypeCostAmount; //Amount of those resources necessary
    
    //String parameters
    public string boatName; //Name of the boat

    //Vector parameters
    public Vector3 scale; //Scale of the boat in game

    public BoatClass(GameObject boat, float spd, float spdMd, float shipHp, float sailHp, float boatColRd, int crgo, int typ, int canCount, int shipID, int[] rssTypCost, int[] rssTypeAmnt, string boatNm, Vector3 scl)
    {
        this.boatPrefab = boat;
        this.defaultSpeed = spd;
        this.speedModifier = spdMd;
        this.shipHitPoints = shipHp;
        this.sailHitPoints = sailHp;
        this.boatCollisionRadius = boatColRd;
        this.cargoSize = crgo;
        this.type = typ;
        this.cannonCount = canCount;
        this.boatID = shipID;
        this.resourceTypeCost = rssTypCost;
        this.resourceTypeCostAmount = rssTypeAmnt;
        this.boatName = boatNm;
        this.scale = scl;
    }
}
