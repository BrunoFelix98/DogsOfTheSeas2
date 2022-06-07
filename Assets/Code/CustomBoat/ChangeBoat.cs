using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChangeBoat : MonoBehaviour
{
    public Slider Yaxis;

    public Slider RedSlider;
    public Slider GreenSlider;
    public Slider BlueSlider;

    public GameObject WholeBoat;
    public GameObject SelectedPiece;

    public ChangeBoatToCustomise customBoat;

    public bool reset;
    public bool resetB;

    public float RedSliderValue;
    public float GreenSliderValue;
    public float BlueSliderValue;

    public LayerMask pieceLayer;

    public List<Material> boatMaterials = new List<Material>();

    // Start is called before the first frame update
    void Start()
    {
        reset = true;
        resetB = true;

        pieceLayer = LayerMask.GetMask("Mats");
    }

    // Update is called once per frame
    void Update()
    {
        if (SelectedPiece != null)
        {
            SetColorSliders();

            Color newColor = new Color(RedSlider.value, GreenSlider.value, BlueSlider.value);

            SelectedPiece.GetComponent<MeshRenderer>().material.color = newColor;

            foreach (Transform t in customBoat.boats[customBoat.selectedBoat].transform)
            {
                if (t.name == SelectedPiece.transform.name)
                {
                    t.GetComponent<MeshRenderer>().sharedMaterial.color = newColor;
                }
            }

            RedSliderValue = RedSlider.value;
            GreenSliderValue = GreenSlider.value;
            BlueSliderValue = BlueSlider.value;
        }

        if (WholeBoat != null)
        {
            SetRotationSliders();

            WholeBoat.transform.eulerAngles = new Vector3(0, Yaxis.value, 0);
        }

        //This is for mouse/computer
        /*if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;

            Ray ray = Camera.main.ScreenPointToRay(new Vector3(mousePos.x, mousePos.y, 0));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, pieceLayer))
            {
                print(hit.transform.name);
                if (hit.transform.tag.Equals("Piece"))
                {
                    SelectedPiece = hit.transform.gameObject;
                }
            }
        }*/

        //This is for mobile/touch screens
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Touch touch = Input.GetTouch(0);

            Ray ray = Camera.main.ScreenPointToRay(new Vector3(touch.position.x, touch.position.y, 0));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, pieceLayer))
            {
                if (hit.transform.tag.Equals("Piece"))
                {
                    SelectedPiece = hit.transform.gameObject;
                }
            }
        }
        
    }

    public void SetColorSliders()
    {
        //Set the sliders to the value of the piece itself

        RedSlider.maxValue = 1;
        GreenSlider.maxValue = 1;
        BlueSlider.maxValue = 1;

        RedSlider.minValue = 0;
        GreenSlider.minValue = 0;
        BlueSlider.minValue = 0;

        if (reset)
        {
            RedSlider.value = SelectedPiece.GetComponent<MeshRenderer>().material.color.r;
            GreenSlider.value = SelectedPiece.GetComponent<MeshRenderer>().material.color.g;
            BlueSlider.value = SelectedPiece.GetComponent<MeshRenderer>().material.color.b;
            reset = false;
        }
    }

    public void SetRotationSliders()
    {
        Yaxis.minValue = -360;
        Yaxis.maxValue = 360;

        if (resetB)
        {
            Yaxis.value = WholeBoat.transform.rotation.y;
            resetB = false;
        }
    }
}
