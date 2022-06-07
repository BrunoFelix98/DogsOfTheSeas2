using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulateBoats : MonoBehaviour
{
    public BoatClass[] boats = new BoatClass[3];

    //Small boats
    public GameObject Sloop;

    //Medium boats
    public GameObject Brig;

    //Large boats
    public GameObject Galleon;

    //Singleton instance of the boats
    public static PopulateBoats instance;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;

        //Small boats
        boats[0] = new BoatBuilder().HasBoatObject(Sloop).DefaultSpeed(3).HasSpeedModifier(1).HullHitPoints(500).SailHitPoints(500).HasRadius(6.37f).CargoSize(500).ShipType(0).CannonCount(2).HasID(0).CostsType(new int[] { 0, 1, 2 }).CostsAmount(new int[] {100, 20, 150}).ShipName("Sloop").ShipScale(new Vector3(0.05f, 0.05f, 0.05f)).Build();

        //Medium boats
        boats[1] = new BoatBuilder().HasBoatObject(Brig).DefaultSpeed(4).HasSpeedModifier(1.5f).HullHitPoints(1500).SailHitPoints(1500).HasRadius(7.0f).CargoSize(1500).ShipType(1).CannonCount(4).HasID(1).CostsType(new int[] { 0, 1, 2 }).CostsAmount(new int[] { 150, 70, 200 }).ShipName("Brig").ShipScale(new Vector3(0.1f, 0.1f, 0.1f)).Build();

        //Large boats
        boats[2] = new BoatBuilder().HasBoatObject(Galleon).DefaultSpeed(4).HasSpeedModifier(0.75f).HullHitPoints(2000).SailHitPoints(2000).HasRadius(10.0f).CargoSize(2000).ShipType(2).CannonCount(6).HasID(2).CostsType(new int[] { 0, 1, 2 }).CostsAmount(new int[] { 200, 120, 250 }).ShipName("Galleon").ShipScale(new Vector3(0.1f, 0.1f, 0.1f)).Build();
    }
}
