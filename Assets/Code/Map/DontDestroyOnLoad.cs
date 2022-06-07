using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    public GameObject[] objs;
    public GameObject invHolder;
    public GameObject homebayInvHolder;
    public GameObject boatCustomSettings;

    void Awake()
    {
        objs = GameObject.FindGameObjectsWithTag("Controllers");
        invHolder = GameObject.FindGameObjectWithTag("InvHolder");
        homebayInvHolder = GameObject.FindGameObjectWithTag("Warehouse");
        boatCustomSettings = GameObject.FindGameObjectWithTag("BoatCustom");

        if (objs.Length > 2)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }

        if (invHolder == null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }

        if (homebayInvHolder == null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }

        if (boatCustomSettings == null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}