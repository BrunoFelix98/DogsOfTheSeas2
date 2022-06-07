using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomebayLocation : MonoBehaviour
{
    public Button homebayButton;

    public GameObject dontDestroy;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        homebayButton.onClick.AddListener(ChangeToHomebay);
        dontDestroy = GameObject.FindGameObjectWithTag("DontDestroyOnLoad");
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        if (Vector3.Distance(transform.position, player.transform.position) <= 5.0f)
        {
            homebayButton.gameObject.SetActive(true);
        }
        else
        {
            homebayButton.gameObject.SetActive(false);
        }
    }

    public void ChangeToHomebay()
    {
        dontDestroy.GetComponent<SceneChange>().ChangeScene();
    }
}
