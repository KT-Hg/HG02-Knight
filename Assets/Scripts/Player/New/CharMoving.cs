using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMoving : MonoBehaviour
{
    public CharManager charManager;
    private Rigidbody2D myBody;
    private RigidbodyConstraints2D bodyConstraints;
    private float bodyGravityScale;
    private int MOVE1;
    private int MOVE2;
    private int MOVE3;

    private void Awake()
    {
        charManager = GetComponentInParent<CharManager>();
        myBody = GetComponentInParent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void walk(int move, float walkSpeed)
    {

        Vector3 scale = transform.parent.localScale;
        if (move > 0) scale.x = 1f;
        else scale.x = -1f;
        transform.parent.localScale = scale;
        transform.parent.position += new Vector3(move * walkSpeed * Time.deltaTime, 0, 0);
    }

    public void run(int move, float runSpeed)
    {
        Vector3 scale = transform.parent.localScale;
        if (move > 0) scale.x = 1f;
        else scale.x = -1f;
        transform.parent.localScale = scale;
        transform.parent.position += new Vector3(move * runSpeed * Time.deltaTime, 0, 0);
    }

    public void climb(int move,float climbSpeed)
    {
        bodyGravityScale = myBody.gravityScale;
        myBody.gravityScale = 0f;
        myBody.constraints = myBody.constraints;
        transform.parent.position += new Vector3(0, move * climbSpeed * Time.deltaTime, 0);
    }

    public void stopClimb()
    {
        myBody.constraints = ~RigidbodyConstraints2D.FreezePositionX;
        myBody.gravityScale = bodyGravityScale;
        myBody.constraints = bodyConstraints;
    }

    public void jump(int move, float jumpForce)
    {
        myBody.AddForce(new Vector2(0, jumpForce));
    }

    public void highJump(int move, float highJumpForce)
    {
        myBody.AddForce(new Vector2(0, highJumpForce));
    }

}
