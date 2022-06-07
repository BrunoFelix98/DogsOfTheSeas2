using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckFull : MonoBehaviour
{
    public bool isFull;

    public int currentRssHeld;

    // Start is called before the first frame update
    void Start()
    {
        currentRssHeld = 10;

        isFull = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
