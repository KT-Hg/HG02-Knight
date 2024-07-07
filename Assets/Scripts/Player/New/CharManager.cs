using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharManager : Character
{
    public CharMoving charMoving;
    public CharAttack charAttack;
    public CharAnimation charAnimation;
    public DamageReceiver damageReceiver;
    public DamageSender damageSender;

    //====================================
    private float timeCount;

    private void Awake()
    {
        charMoving = GetComponentInChildren<CharMoving>();
        charAnimation = GetComponentInChildren<CharAnimation>();
        charAttack = GetComponentInChildren<CharAttack>();
        damageReceiver = GetComponentInChildren<DamageReceiver>();
        damageSender = GetComponentInChildren<DamageSender>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Move( int move)
    {
        if (move == 0)
        {
            timeCount = Time.time;
            charMoving.walk(move, walkSpeed); 
            charMoving.run(move, runSpeed);
        }
        if(grounded || ladder)
        {
            if ((timeCount + timeDelay > Time.time) && (timeCount != Time.time))
            {
                charMoving.run(move, runSpeed);
            }
            else
            {
                charMoving.walk(move, walkSpeed);
            }
        }
    }

    public void Climb(int climb)
    {
        if (climb != 0)
        {
            charMoving.climb(climb, climbSpeed);
        }
        charMoving.stopClimb();
    }

    public void Jump(int jump)
    {
        if (jump == 0)
        {
            timeCount = Time.time;
        }
        if (grounded || ladder)
        {
            if ((timeCount + timeDelay > Time.time) && (timeCount != Time.time))
            {
                charMoving.highJump(jump, highJumpForce);
            }
            else
            {
                charMoving.jump(jump, jumpForce);
            }
        }
    }

}
