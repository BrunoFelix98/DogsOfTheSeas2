using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulateBuildingTypes : MonoBehaviour
{
    public BuildingTypesClass[] buildingTypes = new BuildingTypesClass[10];

    public string Blacksmith = "Blacksmith";
    public string Metallurgy = "Metallurgy";
    public string Workshop = "Workshop";
    public string PastorialFarm = "Pastorial Farm";
    public string Quarry = "Quarry";
    public string Farm = "Farm";
    public string WoodWorkshop = "Wood Workshop";
    public string Tavern = "Tavern";
    public string TextileWorkshop = "Textile Workshop";
    public string Laboratory = "Laboratory";

    //Singleton instance of the types of buildings
    public static PopulateBuildingTypes instance;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;

        buildingTypes[0] = new BuildingTypesBuilder().Type(0).ResourcesUsed(new[] { 0, 5, 8, 16 }).ResourcesUsedToBuild(new[] { 0, 1, 2, 3, 4 }).ResourcesProduced(new[] { 8, 14, 20 }).Name(Blacksmith).ProductionTimer(10.0f).Build();
        buildingTypes[1] = new BuildingTypesBuilder().Type(1).ResourcesUsed(new[] { 0, 3, 6, 7 }).ResourcesUsedToBuild(new[] { 0, 1, 2, 3, 4 }).ResourcesProduced(new[] { 16, 17, 18 }).Name(Metallurgy).ProductionTimer(10.0f).Build();
        buildingTypes[2] = new BuildingTypesBuilder().Type(2).ResourcesUsed(new[] { 0, 1, 8, 9 }).ResourcesUsedToBuild(new[] { 0, 1, 2, 3, 4 }).ResourcesProduced(new[] { 21, 22 }).Name(Workshop).ProductionTimer(10.0f).Build();
        buildingTypes[3] = new BuildingTypesBuilder().Type(3).ResourcesUsedToBuild(new[] { 0, 1, 2, 3, 4 }).ResourcesProduced(new[] { 11 }).Name(PastorialFarm).ProductionTimer(10.0f).Build();
        buildingTypes[4] = new BuildingTypesBuilder().Type(4).ResourcesUsed(new[] { 1 }).ResourcesUsedToBuild(new[] { 0, 1, 2, 3, 4 }).ResourcesProduced(new[] { 1, 19 }).Name(Quarry).ProductionTimer(10.0f).Build();
        buildingTypes[5] = new BuildingTypesBuilder().Type(5).ResourcesUsedToBuild(new[] { 0, 1, 2, 3, 4 }).ResourcesProduced(new[] { 0, 1, 2, 3, 4 }).Name(Farm).ProductionTimer(10.0f).Build();
        buildingTypes[6] = new BuildingTypesBuilder().Type(6).ResourcesUsed(new[] { 0 }).ResourcesUsedToBuild(new[] { 0, 1, 2, 3, 4 }).ResourcesProduced(new[] { 0, 23 }).Name(WoodWorkshop).ProductionTimer(10.0f).Build();
        buildingTypes[7] = new BuildingTypesBuilder().Type(7).ResourcesUsed(new[] { 11, 12, 13 }).ResourcesUsedToBuild(new[] { 0, 1, 2, 3, 4 }).ResourcesProduced(new[] { 24, 25 }).Name(Tavern).ProductionTimer(10.0f).Build();
        buildingTypes[8] = new BuildingTypesBuilder().Type(8).ResourcesUsed(new[] { 2, 4, 11 }).ResourcesUsedToBuild(new[] { 0, 1, 2, 3, 4 }).ResourcesProduced(new[] { 9, 10, 15 }).Name(TextileWorkshop).ProductionTimer(10.0f).Build();
        buildingTypes[9] = new BuildingTypesBuilder().Type(9).ResourcesUsedToBuild(new[] { 0, 1, 2, 3, 4 }).ResourcesProduced(new[] { 5 }).Name(Laboratory).ProductionTimer(10.0f).Build();
    }
}
