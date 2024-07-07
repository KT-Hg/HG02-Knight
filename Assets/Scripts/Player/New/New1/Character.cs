using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    protected Transform transform;
    protected int playerLV;
    protected float maxHealth;
    protected float currentHealth;
    protected float maxMana;
    protected float currentMana;
    protected float physicalDefense;
    protected float magicalDefense;

   
    protected float walkSpeed;
    protected float climbSpeed;
    protected float jumpSpeed;
    protected float highJumpSpeed;
    protected float runSpeed;


    protected float attackDamage;
    protected float extraAttackDamage;
    protected float attackInRange;
    //Wi  ==========
    protected float range1;
    protected float range2;
    protected GameObject bullet, extraBullet;
    //    ==========
    protected Transform AttackPoint;
    protected LayerMask enemyLayers;


    protected float timeWait4NextAction;
    protected bool button;
    protected bool PhysicalOrMagical;
    protected bool grounded;
    protected bool ladder;

    public virtual DamageReceiver()
    {

    }
    
}
