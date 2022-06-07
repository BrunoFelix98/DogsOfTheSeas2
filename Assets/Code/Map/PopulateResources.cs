using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulateResources : MonoBehaviour
{
    public ResourceClass[] resources = new ResourceClass[27];

    public GameObject Wood;
    public GameObject Stone;
    public GameObject Iron;
    public GameObject Cotton;
    public GameObject Hemp;
    public GameObject Sulfur;
    public GameObject Copper;
    public GameObject Gold;
    public GameObject Coal;
    public GameObject Rope;
    public GameObject Hide;
    public GameObject Cows;
    public GameObject Fruit;
    public GameObject Fish;
    public GameObject Gunpowder;
    public GameObject Fabric;
    public GameObject ironIngot;
    public GameObject copperIngot;
    public GameObject goldIngot;
    public GameObject stoneBlock;
    public GameObject cannonBall;
    public GameObject cannons;
    public GameObject tools;
    public GameObject planks;
    public GameObject rum;
    public GameObject food;
    public GameObject chainShot;

    //Singleton instance of the resources
    public static PopulateResources instance;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;

        //zone 1 resources
        resources[0] = new ResourceBuilder().HasImage(Wood).HasType(0).HasAmount(500).HasPrice(20).HasName("Wood").Spawnable(true).Build();
        resources[1] = new ResourceBuilder().HasImage(Stone).HasType(1).HasAmount(500).HasPrice(20).HasName("Stone").Spawnable(true).Build();
        resources[2] = new ResourceBuilder().HasImage(Hemp).HasType(2).HasAmount(500).HasPrice(30).HasName("Hemp").Spawnable(true).Build();
        resources[3] = new ResourceBuilder().HasImage(Iron).HasType(3).HasAmount(500).HasPrice(40).HasName("Iron").Spawnable(true).Build();
        resources[4] = new ResourceBuilder().HasImage(Cotton).HasType(4).HasAmount(500).HasPrice(50).HasName("Cotton").Spawnable(true).Build();
        resources[5] = new ResourceBuilder().HasImage(Sulfur).HasType(5).HasAmount(500).HasPrice(60).HasName("Sulfur").Spawnable(true).Build();
        resources[6] = new ResourceBuilder().HasImage(Copper).HasType(6).HasAmount(500).HasPrice(70).HasName("Copper").Spawnable(true).Build();

        //zone 2 resources
        resources[7] = new ResourceBuilder().HasImage(Gold).HasType(7).HasAmount(500).HasPrice(90).HasName("Gold").Spawnable(true).Build();
        resources[8] = new ResourceBuilder().HasImage(Coal).HasType(8).HasAmount(500).HasPrice(15).HasName("Coal").Spawnable(true).Build();

        //undefined
        resources[9] = new ResourceBuilder().HasImage(Rope).HasType(9).HasPrice(25).HasName("Rope").Build();
        resources[10] = new ResourceBuilder().HasImage(Hide).HasType(10).HasPrice(30).HasName("Hide").Build();
        resources[11] = new ResourceBuilder().HasImage(Cows).HasType(11).HasPrice(25).HasName("Cows").Build();
        resources[12] = new ResourceBuilder().HasImage(Fruit).HasType(12).HasPrice(10).HasName("Fruit").Build();
        resources[13] = new ResourceBuilder().HasImage(Fish).HasType(13).HasPrice(10).HasName("Fish").Build();
        resources[14] = new ResourceBuilder().HasImage(Gunpowder).HasType(14).HasPrice(10).HasName("Gunpowder").Build();
        resources[15] = new ResourceBuilder().HasImage(Fabric).HasType(15).HasPrice(50).HasName("Fabric").Build();
        resources[16] = new ResourceBuilder().HasImage(ironIngot).HasType(16).HasPrice(140).HasName("Iron Ingot").Build();
        resources[17] = new ResourceBuilder().HasImage(copperIngot).HasType(17).HasPrice(170).HasName("Copper Ingot").Build();
        resources[18] = new ResourceBuilder().HasImage(goldIngot).HasType(18).HasPrice(190).HasName("Gold Ingot").Build();
        resources[19] = new ResourceBuilder().HasImage(stoneBlock).HasType(19).HasPrice(40).HasName("Stone Block").Build();
        resources[20] = new ResourceBuilder().HasImage(cannonBall).HasType(20).HasPrice(50).HasName("Cannonball").Build();
        resources[21] = new ResourceBuilder().HasImage(cannons).HasType(21).HasPrice(1200).HasName("Cannons").Build();
        resources[22] = new ResourceBuilder().HasImage(tools).HasType(22).HasPrice(10).HasName("Tools").Build();
        resources[23] = new ResourceBuilder().HasImage(planks).HasType(23).HasPrice(30).HasName("Planks").Build();
        resources[24] = new ResourceBuilder().HasImage(rum).HasType(24).HasPrice(50).HasName("Rum").Build();
        resources[25] = new ResourceBuilder().HasImage(food).HasType(25).HasPrice(30).HasName("Food").Build();
        resources[26] = new ResourceBuilder().HasImage(chainShot).HasType(26).HasPrice(45).HasName("Chainshot").Build();
    }
}
