using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByJoystick : MonoBehaviour {

    public float speed = 8f;
    public float maxVelocity = 4f;

    private Rigidbody2D myBody;
    private Animator anim;

    public bool MoveLeft { get; set; }
    public bool MoveRight { get; set; }

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (MoveLeft)
        {
            SetMoveLeft();
        }
        if (MoveRight)
        {
            SetMoveRight();
        }
	}

    void SetMoveLeft()
    {
        float forceX = 0f;
        float vel = Mathf.Abs(myBody.velocity.x);

        if (vel < maxVelocity)
        {
            forceX = -speed; // Đi trái.
        }

        Vector3 temp = transform.localScale;
        temp.x = -1.3f;
        transform.localScale = temp;

        anim.SetBool("Walk", true);

        myBody.AddForce(new Vector2(forceX, 0));
    }

    void SetMoveRight()
    {
        float forceX = 0f;
        float vel = Mathf.Abs(myBody.velocity.x);

        if (vel < maxVelocity)
        {
            forceX = speed;
        }

        Vector3 temp = transform.localScale;
        temp.x = 1.3f;
        transform.localScale = temp;

        anim.SetBool("Walk", true);

        myBody.AddForce(new Vector2(forceX, 0));
    }

    public void StopMoving()
    {
        MoveLeft = MoveRight = false;
        anim.SetBool("Walk", false);
    }
}
