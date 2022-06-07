using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeBoatToCustomise : MonoBehaviour
{
    public GameObject playerBoat;

    public GameObject[] boats;

    public int selectedBoat;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name.Equals("ChangeBoat") || SceneManager.GetActiveScene().name.Equals("ChangeBoat_Mobile"))
        {
            if (playerBoat == null)
            {
                playerBoat = GameObject.FindGameObjectWithTag("InvHolder");

                selectedBoat = playerBoat.GetComponent<PlayerInventoryHolder>().boatID;

                if (selectedBoat < boats.Length)
                {
                    GameObject boatInstance = Instantiate(boats[selectedBoat].gameObject, transform);
                    boatInstance.transform.position = transform.position;
                }
            }
        }
    }
}
