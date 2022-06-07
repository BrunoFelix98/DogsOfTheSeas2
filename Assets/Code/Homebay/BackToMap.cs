using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackToMap : MonoBehaviour
{
    public Button sailBtn;

    public SceneChange sceneChanger;

    // Update is called once per frame
    void Update()
    {
        if (sceneChanger == null)
        {
            sceneChanger = GameObject.FindGameObjectWithTag("DontDestroyOnLoad").GetComponent<SceneChange>();

            sailBtn.onClick.AddListener(SendBackToMap);
        }
    }

    public void SendBackToMap()
    {
        if (sceneChanger != null)
        {
            sceneChanger.ChangeBack();
        }
    }
}