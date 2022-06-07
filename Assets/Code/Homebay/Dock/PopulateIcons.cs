using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PopulateIcons : MonoBehaviour
{
    public BuildingUI buildingUI;

    public GameObject[] icons;

    public List<string> boatName = new List<string>();
    public List<string> allRssNeeded = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        icons = GameObject.FindGameObjectsWithTag("BoatIcon");

        for (int i = 0; i < icons.Length; i++)
        {
            for (int j = 0; j < GameObject.FindGameObjectsWithTag("Controllers")[0].GetComponent<PopulateBoats>().boats.Length; j++)
            {
                if (!boatName.Contains(GameObject.FindGameObjectsWithTag("Controllers")[0].GetComponent<PopulateBoats>().boats[j].boatName))
                {
                    boatName.Add(GameObject.FindGameObjectsWithTag("Controllers")[0].GetComponent<PopulateBoats>().boats[j].boatName);
                    int rssNeededID0 = GameObject.FindGameObjectsWithTag("Controllers")[0].GetComponent<PopulateBoats>().boats[j].resourceTypeCost[0];
                    int rssNeededID1 = GameObject.FindGameObjectsWithTag("Controllers")[0].GetComponent<PopulateBoats>().boats[j].resourceTypeCost[1];
                    int rssNeededID2 = GameObject.FindGameObjectsWithTag("Controllers")[0].GetComponent<PopulateBoats>().boats[j].resourceTypeCost[2];

                    string rssNeededName0 = GameObject.FindGameObjectsWithTag("Controllers")[1].GetComponent<PopulateResources>().resources[rssNeededID0].rssName;
                    string rssNeededName1 = GameObject.FindGameObjectsWithTag("Controllers")[1].GetComponent<PopulateResources>().resources[rssNeededID1].rssName;
                    string rssNeededName2 = GameObject.FindGameObjectsWithTag("Controllers")[1].GetComponent<PopulateResources>().resources[rssNeededID2].rssName;

                    string rssAmountNeeded0 = GameObject.FindGameObjectsWithTag("Controllers")[0].GetComponent<PopulateBoats>().boats[j].resourceTypeCostAmount[0].ToString();
                    string rssAmountNeeded1 = GameObject.FindGameObjectsWithTag("Controllers")[0].GetComponent<PopulateBoats>().boats[j].resourceTypeCostAmount[1].ToString();
                    string rssAmountNeeded2 = GameObject.FindGameObjectsWithTag("Controllers")[0].GetComponent<PopulateBoats>().boats[j].resourceTypeCostAmount[2].ToString();

                    string clumped = rssNeededName0 + " " + rssAmountNeeded0 + "; " + rssNeededName1 + " " + rssAmountNeeded1 + "; " + rssNeededName2 + " " + rssAmountNeeded2 + ";";
                    allRssNeeded.Add(clumped);
                    /*if (icons[i].transform.GetChild(0).GetComponent<Button>().onClick.GetPersistentEventCount() > 0)
                    {
                        icons[i].transform.GetChild(0).GetComponent<Button>().onClick.RemoveAllListeners();
                    }*/
                }
            }
            int closure = i;
            icons[i].transform.GetChild(0).GetComponent<Button>().onClick.AddListener(() => { MakeBoat(closure); });
            icons[i].transform.GetChild(0).GetComponent<Image>().sprite = buildingUI.boatImages[i];
            icons[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = boatName[i];
            icons[i].transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = allRssNeeded[i];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MakeBoat(int slot)
    {
        GameObject.FindGameObjectWithTag("InvHolder").GetComponent<PlayerInventoryHolder>().boatID = slot;
    }
}
