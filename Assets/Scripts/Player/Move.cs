using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField]
    private float walkSpeed, climbSpeed, jumpSpeed,
        highJumpSpeed, runSpeed, move, climb;
    [SerializeField]
    private Transform checkPoint;
    private float timeToJump;
    private float timeToRun;
    private float timeWait;
    private bool button;
    private bool highJump;
    private bool run;
    private bool grounded;
    private bool ladder;
    public RigidbodyConstraints2D bodyConstraints;
    private Rigidbody2D myBody;
    private Animator anim;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        bodyConstraints = myBody.constraints;
        button = gameObject.GetComponent<Player>().button;
        timeWait = gameObject.GetComponent<Player>().timeWait;
    }

    // Update is called once per frame
    void Update()
    {
        if (button)
        {
            WalkButton();
            climbButton();
            jumpButton();
        }
        else
        {
            walkKeyBoard();
            climbKeyBoard();
            jumpKeyBoard();
        }
    }

    public virtual void setButtonTrue(int a)
    {
        if (button)
        {
            switch (a)
            {
                case 1:
                    move = -1;
                    break;
                case 2:
                    move = 1;
                    break;
                case 3:
                    climb = 1;
                    break;
                case 4:
                    climb = -1;
                    break;
                case 5:
                    if ((timeToJump == 0) && grounded)
                    {
                        timeToJump = Time.time;
                    }
                    else
                    {
                        highJump = true;
                    }
                    break;
            }
        }
    }

    public virtual void setButtonFalse(int a)
    {
        switch (a)
        {
            case 1:
                move = 0;
                break;
            case 2:
                climb = 0;
                break;
        }
    }

    void WalkButton()
    {
        if (move == 0 && (timeToRun == 0) && grounded)
        {
            timeToRun = Time.time;
            run = false;
            return;
        }

        if (move != 0) 
        {
            if ((move != 0 && Time.time < timeToRun + timeWait && grounded) || run)
            {
                timeToRun = 0;
                run = true;
                Vector3 scale = transform.localScale;
                if (move > 0)
                {
                    scale.x = 1f;
                }
                else
                {
                    scale.x = -1f;
                }
                transform.localScale = scale;
                transform.position += new Vector3(move * runSpeed * Time.deltaTime, 0, 0);
                anim.SetBool("Walk", false);
                anim.SetBool("Run", true);
            }
            else
            {
                timeToRun = 0;
                Vector3 scale = transform.localScale;
                if (move > 0)
                {
                    scale.x = 1f;
                }
                else
                {
                    scale.x = -1f;
                }
                transform.localScale = scale;
                transform.position += new Vector3(move * walkSpeed * Time.deltaTime, 0, 0);
                anim.SetBool("Run", false);
                anim.SetBool("Walk", true);
            }
        }
        else
        if (move == 0 || !grounded)
        {
            anim.SetBool("Walk", false);
            anim.SetBool("Run", false);
        }
    }

    void walkKeyBoard()
    {
        move = Input.GetAxisRaw("Horizontal");
        if (move == 0 && (timeToRun == 0) && grounded) 
        {
            timeToRun = Time.time;
            run = false;
            return;
        }

        if (move != 0) 
        {
            if ((move != 0 && Time.time < timeToRun + timeWait && grounded) || run)
            {
                timeToRun = 0;
                run = true;
                Vector3 scale = transform.localScale;
                if (move > 0)
                {
                    scale.x = 1f;
                }
                else
                {
                    scale.x = -1f;
                }
                transform.localScale = scale;
                transform.position += new Vector3(move * runSpeed * Time.deltaTime, 0, 0);
                anim.SetBool("Walk", false);
                anim.SetBool("Run", true);
            }
            else
            {
                timeToRun = 0;
                Vector3 scale = transform.localScale;
                if (move > 0)
                {
                    scale.x = 1f;
                }
                else
                {
                    scale.x = -1f;
                }
                transform.localScale = scale;
                transform.position += new Vector3(move * walkSpeed * Time.deltaTime, 0, 0);
                anim.SetBool("Run", false);
                anim.SetBool("Walk", true);
            }
        }
        else
        if (move == 0 || !grounded) 
        {
            anim.SetBool("Walk", false);
            anim.SetBool("Run", false);
        }
    }

    void climbButton()
    {
        if ((climb != 0) && ladder)
        {
            anim.SetBool("Climb", true);
            myBody.gravityScale = 0.5f;
            myBody.constraints = bodyConstraints;
            transform.position += new Vector3(0, climb * climbSpeed * Time.deltaTime, 0);
        }
        else
        if (climb == 0 && ladder)
        {
            anim.SetBool("Climb", false);
            myBody.constraints = ~RigidbodyConstraints2D.FreezePositionX;
        }
        else
        {
            anim.SetBool("Climb", false);
            myBody.gravityScale = 4f;
            myBody.constraints = bodyConstraints;
        }
    }

    void climbKeyBoard()
    {
        climb = Input.GetAxisRaw("Vertical");

        if ((climb != 0) && ladder)
        {
            anim.SetBool("Climb", true);
            myBody.gravityScale = 0.5f;
            myBody.constraints = bodyConstraints;
            transform.position += new Vector3(0, climb * climbSpeed * Time.deltaTime, 0);
        }
        else
        if (climb == 0 && ladder)
        {
            anim.SetBool("Climb", false);
            myBody.constraints = ~RigidbodyConstraints2D.FreezePositionX;
        }
        else
        {
            anim.SetBool("Climb", false);
            myBody.gravityScale = 4f;
            myBody.constraints = bodyConstraints;
        }
    }

    void jumpButton()
    {
        float forceX = 0f;
        float forceY = 0f;

        if (timeToJump != 0)
        {
            if (highJump)
            {
                forceY = highJumpSpeed;
                anim.SetTrigger("Jump+");
                timeToJump = 0f;
                highJump = false;
            }
            else
            if ((Time.time > timeToJump + timeWait) && grounded)
            {
                forceY = jumpSpeed;
                anim.SetTrigger("Jump");
                timeToJump = 0f;
            }
        }
        myBody.AddForce(new Vector2(forceX, forceY));
    }

    void jumpKeyBoard()
    {
        float forceX = 0f;
        float forceY = 0f;

        if (Input.GetKeyDown(KeyCode.Space) && (timeToJump == 0) && grounded)
        {
            timeToJump = Time.time;
            return;
        }

        if (timeToJump != 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                forceY = highJumpSpeed;
                anim.SetTrigger("Jump+");
                timeToJump = 0f;
            }
            else
            if ((Time.time > timeToJump + timeWait) && grounded)
            {
                forceY = jumpSpeed;
                anim.SetTrigger("Jump");
                timeToJump = 0f;
            }
        }
        myBody.AddForce(new Vector2(forceX, forceY));
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        grounded = false;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        ladder = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ladder")
        {
            ladder = true;
        }
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }
}
