using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class CityUI : MonoBehaviour
{
    public GameObject resourcePrefab;

    public SetCityLocation citiesInfo;

    public List<int> nearRss = new List<int>();
    public int count;

    public Button closeBtn;

    public List<GameObject> sellingItemsInstance = new List<GameObject>(); //Store all the shop items' objects

    public bool clickable; //Prevent multiple instances of the same shop items

    // Start is called before the first frame update
    void Start()
    {
        clickable = true;
        closeBtn.onClick.AddListener(CloseUI);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CreateUI(int clickedCity)
    {
        float height = 50.0f;

        if (clickedCity != 99 && clickable) //Basically a cheat to make sure that all the resources displayed are the ones in the city
        {
            nearRss = citiesInfo.popCities[clickedCity].nearbyRss; //Set the list available in this script as the list of nearby resources in the clicked city

            GameObject Content = GameObject.FindGameObjectWithTag("ContentCitySell");

            for (int j = 0; j < nearRss.Count; j++)
            {
                GameObject rss = Instantiate(resourcePrefab, Content.transform.position, Quaternion.identity); //Create all the displayed resources
                rss.transform.parent = Content.transform;
                rss.transform.localScale *= 1.75f;

                rss.transform.localPosition = new Vector3(50, -(height * j) - 30, 0);

                sellingItemsInstance.Add(rss);

                ChangeInfo(rss, j);
            }

            RectTransform RectT = Content.GetComponent<RectTransform>();
            RectT.sizeDelta = new Vector2(RectT.sizeDelta.x, (height * nearRss.Count) + 30);

            PlayerGathering playergather = GameObject.FindGameObjectWithTag("Player").GetComponentInParent<PlayerGathering>();
            playergather.sellingToCity = GameObject.FindGameObjectWithTag("MainGameSelling");

            clickable = false;
        }        
    }

    void ChangeInfo(GameObject rss, int j)
    {
        rss.GetComponent<CityUIPrefab>().rssName.text = citiesInfo.resourceType[nearRss[j]].rssName;
        rss.GetComponent<CityUIPrefab>().rssType = citiesInfo.resourceType[nearRss[j]].rssType;
        rss.GetComponent<CityUIPrefab>().rssPrice.text = (citiesInfo.resourceType[nearRss[j]].rssPrice * 0.75f).ToString();
        rss.GetComponent<CityUIPrefab>().rssImage.sprite = citiesInfo.resourceType[nearRss[j]].rssImage.GetComponent<SpriteRenderer>().sprite;
    }

    void DestroyAllResourceInstances()
    {
        for (int i = 0; i < sellingItemsInstance.Count; i++)
        {
            Destroy(sellingItemsInstance[i]);
        }
        sellingItemsInstance.Clear();
    }

    void CloseUI()
    {
        nearRss.Clear(); //Clear the list in otder to be able to add to it later
        DestroyAllResourceInstances(); //Destroy all the resource instances displayed
        clickable = true;
        gameObject.SetActive(false);
    }
}