using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDragging : MonoBehaviour
{
    [SerializeField]
    private float maxStretch = 3.0f;

    private float maxStretchSqr;

    private Transform player;

    private SpringJoint2D spring;
    private bool clickedOn = false;
    private Vector2 prevVelocity;

    private Ray rayToMouse;

    private Rigidbody2D rigidbody2D;

    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        spring = GetComponent<SpringJoint2D>();
        player = spring.connectedBody.transform;
    }

    void Start()
    {
        rayToMouse = new Ray(player.position, Vector3.zero);
        maxStretchSqr = maxStretch * maxStretch;
    }

    void Update()
    {
        if (clickedOn)
        {
            Dragging();
        }

        if (spring != null)
        {
            if (!rigidbody2D.isKinematic && prevVelocity.sqrMagnitude > rigidbody2D.velocity.sqrMagnitude)
            {
                Destroy(spring);
                rigidbody2D.velocity = prevVelocity;
            }

            if (!clickedOn)
                prevVelocity = rigidbody2D.velocity;
        }
        else
        {

        }
    }

    void OnMouseDown()
    {
        spring.enabled = false;
        clickedOn = true;
    }

    void OnMouseUp()
    {
        spring.enabled = true;
        rigidbody2D.isKinematic = false;
        clickedOn = false;
    }

    void Dragging()
    {
        Vector3 mouseWorldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // This is the angle
        Vector2 playerToMouse = mouseWorldPoint - player.position;

        if (playerToMouse.sqrMagnitude > maxStretchSqr)
        {
            rayToMouse.direction = playerToMouse;
            mouseWorldPoint = rayToMouse.GetPoint(maxStretch);
        }
        else
        {
            mouseWorldPoint.z = 0f;
            transform.position = mouseWorldPoint;
        }
    }
}
