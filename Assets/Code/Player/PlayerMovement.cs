using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public GameObject Ship;

    public Joystick joystick;

    public Vector3 prevPos;

    public float Speed = 20.0f;
    public float Angle = 30.0f;

    public bool up = false;
    public bool down = false;
    public bool left = false;
    public bool right = false;


    void Start()
    {
        
    }

    void Update()
    {
        if (Ship == null)
        {
            Ship = GetComponent<PlayerBoat>().boatInstance.gameObject;
            prevPos = Ship.transform.position;
        }

        Speed = GetComponent<PlayerBoat>().playerSpeed;

        MoveForward();
    }

    void MoveForward()
    {
        if (SceneManager.GetActiveScene().name.Equals("Jogo1"))
        {
            if (Input.GetKey("up") || Input.GetKey("w"))
            {
                transform.Translate(0, Speed * Time.deltaTime, 0);
                up = true;
            }

            if (Input.GetKey("down") || Input.GetKey("s"))
            {
                transform.Translate(0, -Speed * Time.deltaTime, 0);
                down = true;
            }

            if (Input.GetKey("right") || Input.GetKey("d"))
            {
                transform.Translate(Speed * Time.deltaTime, 0, 0);
                right = true;
            }

            if (Input.GetKey("left") || Input.GetKey("a"))
            {
                transform.Translate(-Speed * Time.deltaTime, 0, 0);
                left = true;
            }

            if (Input.GetKeyUp("up") || Input.GetKeyUp("w"))
            {
                up = false;
            }

            if (Input.GetKeyUp("down") || Input.GetKeyUp("s"))
            {
                down = false;
            }

            if (Input.GetKeyUp("right") || Input.GetKeyUp("d"))
            {
                right = false;
            }

            if (Input.GetKeyUp("left") || Input.GetKeyUp("a"))
            {
                left = false;
            }
        }
        else
        {
            if (joystick.Horizontal < -0.2) //Left
            {
                transform.Translate(-Speed * Time.deltaTime, 0, 0);
                down = false;
                up = false;
                left = true;
                right = false;
            }

            if (joystick.Horizontal > 0.2) //Right
            {
                transform.Translate(Speed * Time.deltaTime, 0, 0);
                down = false;
                up = false;
                left = false;
                right = true;
            }

            if (joystick.Vertical > 0.2) //Up
            {
                transform.Translate(0, Speed * Time.deltaTime, 0);
                down = false;
                up = true;
                left = false;
                right = false;
            }

            if (joystick.Vertical < -0.2) //Down
            {
                transform.Translate(0, -Speed * Time.deltaTime, 0);
                down = true;
                up = false;
                left = false;
                right = false;
            }

            if (joystick.Vertical < -0.2 && joystick.Horizontal > 0.2) //Down & Right
            {
                right = true;
                down = true;
                up = false;
                left = false;
            }

            if (joystick.Vertical > 0.2 && joystick.Horizontal > 0.2) //Up & Right
            {
                right = true;
                down = false;
                up = true;
                left = false;
            }

            if (joystick.Vertical < -0.2 && joystick.Horizontal < -0.2) //Down & Left
            {
                right = false;
                down = true;
                up = false;
                left = true;
            }

            if (joystick.Vertical > 0.2 && joystick.Horizontal < -0.2) //Up & Left
            {
                right = false;
                down = false;
                up = true;
                left = true;
            }
        }

        if (prevPos != Ship.transform.position)
        {
            Vector3 dir = Ship.transform.position - prevPos;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            Ship.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward + new Vector3(Ship.transform.rotation.x, -90, Ship.transform.rotation.z));
            if (up)
            {
                Ship.transform.Rotate(Vector3.right, -Angle);
            }
            else if (down)
            {
                Ship.transform.Rotate(Vector3.right, Angle);
            }
            else if (left)
            {
                Ship.transform.Rotate(Vector3.forward, Angle);
            }
            else if (right)
            {
                Ship.transform.Rotate(Vector3.forward, -Angle);
            }
            prevPos = Ship.transform.position;
        }
    }
}
