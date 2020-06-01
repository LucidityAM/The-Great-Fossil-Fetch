using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerMovementFinal : MonoBehaviour
{
    public float moveForce = 7f;

    //Jump Stuff
    public float jumpForce = 7f;
    private float rememberGroundedFor = .05f;
    private float lastTimeGrounded;

    //Ground Check
    public Transform isGroundedChecker;
    public float checkGroundRadius;
    public LayerMask groundLayer;

    //Bools
    private bool isJumping;
    public bool isGrounded;
    private bool isMoving;
    private bool isFlipped;

    //Components
    Rigidbody2D rb2;
    Animator anim;
    SpriteRenderer sr;
    AudioSource audioSrc;

    public ParticleSystem dust;

    // Start is called before the first frame update
    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        #region Basic Movement

        if (isGrounded || Time.time - lastTimeGrounded <= rememberGroundedFor)
        {
            if (Input.GetButton("Jump"))
            {
                StartCoroutine(Dust());
                rb2.velocity = new Vector2(rb2.velocity.x, jumpForce);
                anim.SetBool("inJump", true);

                if (isJumping == true)
                {
                    isJumping = false;
                }
            }
        }//Checks if the player is grounded or if they were grounded in the last couple miliseconds and then jumps

        //Basic sidescrolling movement
        float x = Input.GetAxis("Horizontal");
        float moveBy = x * moveForce;
        rb2.velocity = new Vector2(moveBy, rb2.velocity.y);

        if(isGrounded == false)
        {
            float y = Input.GetAxis("Horizontal");
            float moving = y * moveForce;
            rb2.velocity = new Vector2(moving, rb2.velocity.y);
        }
        else
        {
            if (isJumping == false)
            {
                StartCoroutine(Dust());
                isJumping = true;
            }
        }

        if (rb2.velocity.x != 0 && isGrounded == true)
        {
            if (!audioSrc.isPlaying)
                audioSrc.Play();
        }
        else
        {
            audioSrc.Stop();
        }
        //Plays the sounds of walking when the player is moving

        anim.SetFloat("walkSpeed", Mathf.Abs(rb2.velocity.x));

        //Anim Speed
        if (Mathf.Abs(rb2.velocity.x) != 0)
        {
            anim.speed = Mathf.Abs(rb2.velocity.x) * .05f;
        }
        else
        {
            anim.speed = 0.6f;
        }
        #endregion Basic Movement

        #region Flip
        //Flipping
        if (rb2.velocity.x > 0)
        {
            sr.flipX = false;

            if(isFlipped == false && isGrounded == true)
            {
                StartCoroutine(Dust());
                isFlipped = true;
            }

        }
        else if (rb2.velocity.x < 0)
        {
            if(isFlipped == true && isGrounded == true)
            {
                StartCoroutine(Dust());
                isFlipped = false;
            }

            sr.flipX = true;

        }
        else if(rb2.velocity.x == 0)
        {
            sr.flipX = false;

            if(isGrounded == true)
            {
                DeleteDust();
            } 
        }
        //Checks if the player switched directions, flips the sprite, then generates some dust
        #endregion Flip

        #region Ground
        Collider2D colliders = Physics2D.OverlapCircle(isGroundedChecker.position, checkGroundRadius, groundLayer);

        if (colliders != null)
        {
            isGrounded = true;

            anim.SetBool("inJump", false);
        }
        else
        {
            if (isGrounded)
            {
                lastTimeGrounded = Time.time;
            }
            isGrounded = false;
        }
        //Creates an overlaping circle that detects if the player is touching the ground and either sets isGrounded to true or false
        #endregion Ground
    }

    void CreateDust()
    {
        dust.Play();
    }

    void DeleteDust()
    {
        dust.Stop();
    }

    IEnumerator Dust()
    {
        CreateDust();

        yield return new WaitForSeconds(.09f);

        DeleteDust();

    }//Generates a short burst of dust
}
