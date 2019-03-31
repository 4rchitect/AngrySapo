using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private float maxStretch = 3.0f;
    private float maxStretchSqr;

    private bool clicked = false;

    Vector3 startPoint, endPoint;

    private Rigidbody2D myRigidbody2D;

    private float myAngle = 0.0f;

    void Awake()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Use this for initialization
    void Start ()
    {
        maxStretchSqr = maxStretch * maxStretch;
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (clicked)
        {
            endPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
	}

    void OnMouseDown()
    {
        clicked = true;
        startPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
    }

    void OnMouseUp()
    {
        clicked = false;

        Vector3 direction = startPoint - endPoint;
        direction = new Vector3(direction.x, direction.y, 0f);

        Vector2 dilmarecao = new Vector2(direction.x, direction.y);

        Debug.Log(direction);

        //myAngle = Vector3.Angle(endPoint, startPoint);

        dilmarecao *= maxStretch;

        myRigidbody2D.AddForce(dilmarecao);

        

        // Set Max Range and Max angle

        //TODO: Jump Stuff
    }
}
