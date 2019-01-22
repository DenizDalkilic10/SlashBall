using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour {
	private Rigidbody2D rb;
	public bool ball = false;
    public float rotSpeed = 100.0f;
	public bool leftWindmill = true;
	private bool lowerLimit = false;
	private float yAxis = 0;
	private Vector2 velocity  = new Vector2(0,1.0f);
	// Use this for initialization
	void Start () {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        
       
    }

    private void FixedUpdate()
    {
        rb.MoveRotation(rb.rotation + rotSpeed * Time.fixedDeltaTime);
        if (!ball)
        {
            //rb.MovePosition (rb.position - velocity * Time.fixedDeltaTime);

            if (leftWindmill && !lowerLimit)
            {
                rb.MovePosition(rb.position - velocity * Time.fixedDeltaTime);
                if (rb.position.y < -2.5)
                {
                    lowerLimit = true;
                }
            }
            else if (leftWindmill && lowerLimit)
            {
                rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
                if (rb.position.y > 2.5)
                {
                    lowerLimit = false;
                }
            }
            else if (!leftWindmill && !lowerLimit)
            {
                rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
                if (rb.position.y > 2.5)
                {
                    lowerLimit = true;
                }
            }
            else if (!leftWindmill && lowerLimit)
            {
                rb.MovePosition(rb.position - velocity * Time.fixedDeltaTime);
                if (rb.position.y < -2.5)
                {
                    lowerLimit = false;
                }
            }
        }
    }

}
