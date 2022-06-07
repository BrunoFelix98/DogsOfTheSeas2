using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneChange : MonoBehaviour
{
    public Button customisationBtn;
    public Button applyBtn;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public void Update()
    {
        if (SceneManager.GetActiveScene().name == "Homebay_New" || SceneManager.GetActiveScene().name == "Homebay_New_Mobile")
        {
            if (customisationBtn == null)
            {
                customisationBtn = GameObject.FindGameObjectWithTag("CustomiseBtn").GetComponent<Button>();
                customisationBtn.onClick.AddListener(GoToCustomise);
            }
        }

        if (SceneManager.GetActiveScene().name == "ChangeBoat" || SceneManager.GetActiveScene().name == "ChangeBoat_Mobile")
        {
            if (applyBtn == null)
            {
                applyBtn = GameObject.FindGameObjectWithTag("ApplyButton").GetComponent<Button>();
                applyBtn.onClick.AddListener(BackToHomebay);
            }
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            ChangeScene();
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            ChangeBack();
        }
    }

    public void BackToHomebay()
    {
        if (SceneManager.GetActiveScene().name == "ChangeBoat")
        {
            SceneManager.LoadScene("Homebay_New", LoadSceneMode.Single);
        }
        else
        {
            SceneManager.LoadScene("Homebay_New_Mobile", LoadSceneMode.Single);
        }
    }

    public void GoToCustomise()
    {
        if (SceneManager.GetActiveScene().name == "Homebay_New")
        {
            SceneManager.LoadScene("ChangeBoat", LoadSceneMode.Single);
        }
        else
        {
            GameObject.FindGameObjectWithTag("Warehouse").GetComponent<UpdateWarehouseInventory>().inventorySlots = null;
            GameObject.FindGameObjectWithTag("Warehouse").GetComponent<UpdateWarehouseInventory>().BinventorySlots = null;
            SceneManager.LoadScene("ChangeBoat_Mobile", LoadSceneMode.Single);
        }
    }

    public void ChangeScene()
    {
        if (SceneManager.GetActiveScene().name == "Jogo1")
        {
            SceneManager.LoadScene("Homebay_New", LoadSceneMode.Single);
        }
        else
        {
            SceneManager.LoadScene("Homebay_New_Mobile", LoadSceneMode.Single);
        }
    }

    public void ChangeBack()
    {
        if (SceneManager.GetActiveScene().name == "Homebay_New")
        {
            SceneManager.LoadScene("Jogo1", LoadSceneMode.Single);
        }
        else
        {
            GameObject.FindGameObjectWithTag("Warehouse").GetComponent<UpdateWarehouseInventory>().inventorySlots = null;
            GameObject.FindGameObjectWithTag("Warehouse").GetComponent<UpdateWarehouseInventory>().BinventorySlots = null;
            SceneManager.LoadScene("Jogo1_Mobile", LoadSceneMode.Single);
        }
    }
}