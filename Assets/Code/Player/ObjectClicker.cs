using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClicker : MonoBehaviour
{
    public GameObject player;

    public Camera mainCamera;

    public CityUI cityUI;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
 
            if (hit.collider != null)
            {
                if (hit.transform != null)
                {
                    switch (hit.collider.gameObject.transform.tag)
                    {
                        case "Bot":
                            player.GetComponentInParent<PlayerBoat>().selectedEnemy = hit.transform.gameObject;
                            break;
                        case "Loot":
                            hit.transform.GetComponent<LootBoxes>().ShowUI();
                            break;
                        case "City":
                            cityUI.gameObject.SetActive(true);
                            cityUI.CreateUI(hit.collider.gameObject.GetComponent<CityIDHolder>().ID);
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}