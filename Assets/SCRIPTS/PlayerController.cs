using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameObject groundChecker;
    public LayerMask whatIsGround;

    float maxSpeed = 12.0f;
    bool isOnGround = false;

    //Create a reference to the Rigidbody2D so we can manipulate it
    Rigidbody2D playerObject;

    public Text scoreText;
    int score = 0;



    Animator anim;




    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        //Find the Rigidbody2D component that is attached to the same object as this script
        playerObject = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score.ToString();
       
        if (Input.GetKey(KeyCode.LeftShift))
        {
            maxSpeed = 10.0f;
        }
        else
        {
            maxSpeed = 5.0f;
        }

        //Create a 'float' that will be equal to the players horizontal input
        //float movementValueX = Input.GetAxis("Horizontal");

        //Set movementValue to 1.0f, so that we always run foward and no longer care about player input
        float movementValueX = 1.0f;

        anim.SetFloat("Speed", Mathf.Abs(movementValueX));
        anim.SetBool("IsOnGround", isOnGround);
       
        //Change the velocity of the Rigidbody2D to be equal to the movement value
        playerObject.velocity = new Vector2 (movementValueX * maxSpeed, playerObject.velocity.y);

        //Check to see if thr ground check object is touching the ground
        isOnGround = Physics2D.OverlapCircle(groundChecker.transform.position, 1.0f, whatIsGround);

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround == true)
        {
            playerObject.AddForce(new Vector2(0.0f, 388.0f));
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "PickUp")
        {
            score += 10;
            Destroy(other.gameObject);
        }
    }
}
