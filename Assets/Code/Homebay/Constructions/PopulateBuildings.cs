using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopulateBuildings : MonoBehaviour
{
    public BuildingsClass[] buildings = new BuildingsClass[10];

    public Sprite Blacksmith;
    public Sprite Metallurgy;
    public Sprite Workshop;
    public Sprite PastorialFarm;
    public Sprite Quarry;
    public Sprite Farm;
    public Sprite WoodWorkshop;
    public Sprite Tavern;
    public Sprite TextileWorkshop;

    //Singleton instance of the buildings
    public static PopulateBuildings instance;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;

        buildings[0] = new BuildingsBuilder().BuildName("OpenSlot").Build();
        buildings[1] = new BuildingsBuilder().Image(Blacksmith).Type(1).Level(0).BuildTimer(5).BuildName("Blacksmith").BuiltCheck(false).Build();
        buildings[2] = new BuildingsBuilder().Image(Metallurgy).Type(2).Level(0).BuildTimer(5).BuildName("Metallurgy").BuiltCheck(false).Build();
        buildings[3] = new BuildingsBuilder().Image(Workshop).Type(3).Level(0).BuildTimer(5).BuildName("Workshop").BuiltCheck(false).Build();
        buildings[4] = new BuildingsBuilder().Image(PastorialFarm).Type(4).Level(0).BuildTimer(5).BuildName("Pastorial Farm").BuiltCheck(false).Build();
        buildings[5] = new BuildingsBuilder().Image(Quarry).Type(5).Level(0).BuildTimer(5).BuildName("Quarry").BuiltCheck(false).Build();
        buildings[6] = new BuildingsBuilder().Image(Farm).Type(6).Level(0).BuildTimer(5).BuildName("Farm").BuiltCheck(false).Build();
        buildings[7] = new BuildingsBuilder().Image(WoodWorkshop).Type(7).Level(0).BuildTimer(5).BuildName("Wood Workshop").BuiltCheck(false).Build();
        buildings[8] = new BuildingsBuilder().Image(Tavern).Type(8).Level(0).BuildTimer(5).BuildName("Tavern").BuiltCheck(false).Build();
        buildings[9] = new BuildingsBuilder().Image(TextileWorkshop).Type(9).Level(0).BuildTimer(5).BuildName("Textile Workshop").BuiltCheck(false).Build();
    }
}
