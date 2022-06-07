using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    public BoxCollider2D boundariesBox;
    private Vector3 minBounds; 
    private Vector3 maxBounds;

    private Camera theCamera;
    private float halfHeight;
    private float halfWidth;

    // Start is called before the first frame update
    void Start()
    {
        minBounds = boundariesBox.bounds.min;
        maxBounds = boundariesBox.bounds.max;

        theCamera = GetComponent<Camera>();
        halfHeight = theCamera.orthographicSize;
        halfWidth = halfHeight * Screen.width / Screen.height;
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            player = FindObjectOfType<PlayerBoat>().boatInstance.transform;
        }

        transform.position = Vector3.Lerp(transform.position, new Vector3(player.position.x + offset.x, player.position.y + offset.y, offset.z), 3 * Time.deltaTime);
        //transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, offset.z);

        float ClampX = Mathf.Clamp(transform.position.x, minBounds.x + halfWidth, maxBounds.x - halfWidth);
        float ClampY = Mathf.Clamp(transform.position.y, minBounds.y + halfHeight, maxBounds.y - halfHeight);

        transform.position = new Vector3(ClampX, ClampY, offset.z);
    }
}
