using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatBuilder
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
    public int shipID; //ID of the boat
    public int[] resourceTypeCost; //Types of resources used in the construction of this boat
    public int[] resourceTypeCostAmount; //Amount of those resources necessary

    //String parameters
    public string boatName; //Name of the boat

    //Vector parameters
    public Vector3 scale; //Scale of the boat in game

    public BoatBuilder HasBoatObject(GameObject boat)
    {
        boatPrefab = boat;
        return this;
    }

    public BoatBuilder DefaultSpeed(float dSpd)
    {
        defaultSpeed = dSpd;
        return this;
    }

    public BoatBuilder HasSpeedModifier(float spdMdf)
    {
        speedModifier = spdMdf;
        return this;
    }

    public BoatBuilder HullHitPoints(float hullHp)
    {
        shipHitPoints = hullHp;
        return this;
    }

    public BoatBuilder SailHitPoints(float sailHp)
    {
        sailHitPoints = sailHp;
        return this;
    }

    public BoatBuilder HasRadius(float boatColRd)
    {
        boatCollisionRadius = boatColRd;
        return this;
    }

    public BoatBuilder CargoSize(int cargoSz)
    {
        cargoSize = cargoSz;
        return this;
    }

    public BoatBuilder ShipType(int typ)
    {
        type = typ;
        return this;
    }

    public BoatBuilder CannonCount(int cannonCnt)
    {
        cannonCount = cannonCnt;
        return this;
    }

    public BoatBuilder HasID(int boatID)
    {
        shipID = boatID;
        return this;
    }

    public BoatBuilder CostsType(int[] rssTypeC)
    {
        resourceTypeCost = rssTypeC;
        return this;
    }

    public BoatBuilder CostsAmount(int[] rssCostAmnt)
    {
        resourceTypeCostAmount = rssCostAmnt;
        return this;
    }

    public BoatBuilder ShipName(string bName)
    {
        boatName = bName;
        return this;
    }

    public BoatBuilder ShipScale(Vector3 scl)
    {
        scale = scl;
        return this;
    }

    public BoatClass Build()
    {
        return new BoatClass(boatPrefab, defaultSpeed, speedModifier, shipHitPoints, sailHitPoints, boatCollisionRadius, cargoSize, type, cannonCount, shipID, resourceTypeCost, resourceTypeCostAmount, boatName, scale);
    }
}
