using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    const int UP = 1;
    const int LEFT = 2;
    const int DOWN = 3;
    const int RIGHT = 4;

    private Rigidbody2D rb;
    [SerializeField]
    private float movementSpeed;
    private Animator an;

    public bool canMove = false;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        an = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void FixedUpdate()
    {
        if (canMove) {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");

            HandleMovement(horizontal, vertical);
        }
    }

    private void HandleMovement(float h, float v)
    {
        rb.velocity = (new Vector2(h, v)).normalized * movementSpeed;
        if (h > 0 && h > Mathf.Abs(v))
        {
            an.SetInteger("direction", RIGHT);
        } else if (h < 0 && Mathf.Abs(h) > Mathf.Abs(v))
        {
            an.SetInteger("direction", LEFT);
        }
        else if (v > 0)
        {
            an.SetInteger("direction", UP);
        }
        else if (v < 0)
        {
            an.SetInteger("direction", DOWN);
        } else
        {
            an.SetInteger("direction", 0);
        }
    }
}
