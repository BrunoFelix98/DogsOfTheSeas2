using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotSpawningAlgorithm : MonoBehaviour
{
    public GameObject bot;
    public int maxBots = 5;

    public List<GameObject> instantiatedBots;

    GameObject newBot;

    public float totalTime;
    public float timeLeft;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 boatTrsfrm;

        for (int i = 0; i < maxBots; i++)
        {
            for (int j = 1; j < GetComponentsInChildren<Transform>().Length; j++)
            {
                boatTrsfrm = GetComponentsInChildren<Transform>()[j].position;

                int rand = Random.Range(-2, 2);

                boatTrsfrm.y += rand;
                boatTrsfrm.x += rand;

                newBot = Instantiate(bot, boatTrsfrm, Quaternion.identity);
                newBot.transform.parent = GameObject.FindGameObjectWithTag("BotsController").transform;
                instantiatedBots.Add(newBot);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < instantiatedBots.Count; i++)
        {
            if (instantiatedBots[i] == null)
            {
                instantiatedBots.RemoveAt(i);
            }

            if (instantiatedBots[i].GetComponent<BotManager>().looted)
            {
                Destroy(newBot);
            }
        }

        if (instantiatedBots.Count < maxBots)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                SpawnNewBot();
            }
        }
    }

    public void SpawnNewBot()
    {
        for (int i = 1; i < GetComponentsInChildren<Transform>().Length; i++)
        {
            newBot = Instantiate(bot, GetComponentsInChildren<Transform>()[i].position, Quaternion.identity);
            newBot.transform.parent = GameObject.FindGameObjectWithTag("BotsController").transform;
            instantiatedBots.Add(newBot);
        }
        timeLeft = totalTime; //Timer for next spawn
    }
}
