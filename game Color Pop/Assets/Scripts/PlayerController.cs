using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float speedMultiplier;

    public float speedIncreaseMilestone;
    private float speedMilestoneCount; 

    public float jumpForce;

    private Rigidbody2D rb;

    public bool grounded;

    public LayerMask whatIsGround;
    public Transform groundCheck;
    public float groundCheckRadius;

    //private Collider2D myCollider;

    private Animator myAnimator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //myCollider = GetComponent<Collider2D>();

        myAnimator = GetComponent<Animator>();

        speedMilestoneCount = speedIncreaseMilestone;
    }

    // Update is called once per frame
    void Update()
    {
        //ngecek nyentuk tanah ngga
        //grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        //tambah kecepatan
        if(transform.position.x > speedMilestoneCount)
        {
            speedMilestoneCount += speedIncreaseMilestone;

            speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier;
            speed = speed * speedMultiplier;
        }


        //buat gerakan karakter
        rb.velocity = new Vector2 (speed,rb.velocity.y);

        //buat input loncat
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) 
        {
            //kalo di tanah bisa loncat
            if (grounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
            
        }

        myAnimator.SetFloat("Speed", rb.velocity.x);
        myAnimator.SetBool("Grounded", grounded);
    }
}
