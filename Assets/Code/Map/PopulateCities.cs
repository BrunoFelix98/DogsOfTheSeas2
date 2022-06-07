using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulateCities : MonoBehaviour
{
    public Cities[] cities = new Cities[22];

    public GameObject[] citiesPos;

    //Singleton instance of the cities
    public static PopulateCities instance;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;

        cities[0] = new CityBuilder().HasPosition(citiesPos[0]).CityID(0).NearbyRss(new List<int> { }).TypesOfRss(new List<int> { }).CostOfRss(new List<float> { }).CityName("Name").Build();
        cities[1] = new CityBuilder().HasPosition(citiesPos[1]).CityID(1).NearbyRss(new List<int> { }).TypesOfRss(new List<int> { }).CostOfRss(new List<float> { }).CityName("Name").Build();
        cities[2] = new CityBuilder().HasPosition(citiesPos[2]).CityID(2).NearbyRss(new List<int> { }).TypesOfRss(new List<int> { }).CostOfRss(new List<float> { }).CityName("Name").Build();
        cities[3] = new CityBuilder().HasPosition(citiesPos[3]).CityID(3).NearbyRss(new List<int> { }).TypesOfRss(new List<int> { }).CostOfRss(new List<float> { }).CityName("Name").Build();
        cities[4] = new CityBuilder().HasPosition(citiesPos[4]).CityID(4).NearbyRss(new List<int> { }).TypesOfRss(new List<int> { }).CostOfRss(new List<float> { }).CityName("Name").Build();
        cities[5] = new CityBuilder().HasPosition(citiesPos[5]).CityID(5).NearbyRss(new List<int> { }).TypesOfRss(new List<int> { }).CostOfRss(new List<float> { }).CityName("Name").Build();
        cities[6] = new CityBuilder().HasPosition(citiesPos[6]).CityID(6).NearbyRss(new List<int> { }).TypesOfRss(new List<int> { }).CostOfRss(new List<float> { }).CityName("Name").Build();
        cities[7] = new CityBuilder().HasPosition(citiesPos[7]).CityID(7).NearbyRss(new List<int> { }).TypesOfRss(new List<int> { }).CostOfRss(new List<float> { }).CityName("Name").Build();
        cities[8] = new CityBuilder().HasPosition(citiesPos[8]).CityID(8).NearbyRss(new List<int> { }).TypesOfRss(new List<int> { }).CostOfRss(new List<float> { }).CityName("Name").Build();
        cities[9] = new CityBuilder().HasPosition(citiesPos[9]).CityID(9).NearbyRss(new List<int> { }).TypesOfRss(new List<int> { }).CostOfRss(new List<float> { }).CityName("Name").Build();
        cities[10] = new CityBuilder().HasPosition(citiesPos[10]).CityID(10).NearbyRss(new List<int> { }).TypesOfRss(new List<int> { }).CostOfRss(new List<float> { }).CityName("Name").Build();
        cities[11] = new CityBuilder().HasPosition(citiesPos[11]).CityID(11).NearbyRss(new List<int> { }).TypesOfRss(new List<int> { }).CostOfRss(new List<float> { }).CityName("Name").Build();
        cities[12] = new CityBuilder().HasPosition(citiesPos[12]).CityID(12).NearbyRss(new List<int> { }).TypesOfRss(new List<int> { }).CostOfRss(new List<float> { }).CityName("Name").Build();
        cities[13] = new CityBuilder().HasPosition(citiesPos[13]).CityID(13).NearbyRss(new List<int> { }).TypesOfRss(new List<int> { }).CostOfRss(new List<float> { }).CityName("Name").Build();
        cities[14] = new CityBuilder().HasPosition(citiesPos[14]).CityID(14).NearbyRss(new List<int> { }).TypesOfRss(new List<int> { }).CostOfRss(new List<float> { }).CityName("Name").Build();
        cities[15] = new CityBuilder().HasPosition(citiesPos[15]).CityID(15).NearbyRss(new List<int> { }).TypesOfRss(new List<int> { }).CostOfRss(new List<float> { }).CityName("Name").Build();
        cities[16] = new CityBuilder().HasPosition(citiesPos[16]).CityID(16).NearbyRss(new List<int> { }).TypesOfRss(new List<int> { }).CostOfRss(new List<float> { }).CityName("Name").Build();
        cities[17] = new CityBuilder().HasPosition(citiesPos[17]).CityID(17).NearbyRss(new List<int> { }).TypesOfRss(new List<int> { }).CostOfRss(new List<float> { }).CityName("Name").Build();
        cities[18] = new CityBuilder().HasPosition(citiesPos[18]).CityID(18).NearbyRss(new List<int> { }).TypesOfRss(new List<int> { }).CostOfRss(new List<float> { }).CityName("Name").Build();
        cities[19] = new CityBuilder().HasPosition(citiesPos[19]).CityID(19).NearbyRss(new List<int> { }).TypesOfRss(new List<int> { }).CostOfRss(new List<float> { }).CityName("Name").Build();
        cities[20] = new CityBuilder().HasPosition(citiesPos[20]).CityID(20).NearbyRss(new List<int> { }).TypesOfRss(new List<int> { }).CostOfRss(new List<float> { }).CityName("Name").Build();
        cities[21] = new CityBuilder().HasPosition(citiesPos[21]).CityID(21).NearbyRss(new List<int> { }).TypesOfRss(new List<int> { }).CostOfRss(new List<float> { }).CityName("Name").Build();
    }
}
