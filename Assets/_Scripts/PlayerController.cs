using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // "Public" variables
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float jumpForce = 500.0f;
    [SerializeField] private Transform groundCheckPos;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private float groundCheckRadius = 0.15f;

    // Private variables
    public bool isGrounded = false;
    private Rigidbody2D rBody;
    private Animator anim;
    private bool isFacingRight = true;
    public bool canMove = true;
    VirtualCameraController cameraController;
    float horiz;
    public bool isDucking = false;

    // Start is called before the first frame update
    void Start()
    {
        cameraController = FindObjectOfType<VirtualCameraController>();
        rBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.6f);
        VirtualCameraController._instance.TransitionTo(VirtualCameraController._instance.levelCam, VirtualCameraController._instance.playerCam,4.5f);

    }

    private void Update() {
        horiz = Input.GetAxis("Horizontal");
        if (Input.GetKey(KeyCode.S) && horiz == 0)
        {
            isDucking = true;
        }
        else
        {
            isDucking = false;
        }

    }

    // Physics
    void FixedUpdate()
    {

        isGrounded = (GroundCheck() && rBody.velocity.y < 0.1f);

        if(canMove){

            // Jumping code will go here!
            if(isGrounded && Input.GetAxis("Jump") > 0)
            {
                //AudioManager.instance.Play("Jump");
                rBody.AddForce(new Vector2(0.0f, jumpForce));
                isGrounded = false;
            }

            rBody.velocity = new Vector2(horiz * speed, rBody.velocity.y);
            anim.SetBool("isDucking", isDucking);

        } 
        else
        {
            rBody.velocity = new Vector2(0, rBody.velocity.y);
        }

        // Check if sprite needs to be flipped
        if(isFacingRight && rBody.velocity.x < 0)
        {
            Flip();
        }
        else if (!isFacingRight && rBody.velocity.x > 0)
        {
            Flip();
        }


        anim.SetFloat("xSpeed", Mathf.Abs(rBody.velocity.x));
        anim.SetFloat("ySpeed", rBody.velocity.y);
        anim.SetBool("isGrounded", isGrounded);
    }

    private bool GroundCheck()
    {
        return Physics2D.OverlapCircle(groundCheckPos.position, groundCheckRadius, whatIsGround); ;
    }

    private void Flip()
    {
        Vector3 temp = transform.localScale;
        temp.x *= -1;
        transform.localScale = temp;

        isFacingRight = !isFacingRight;
    }
}