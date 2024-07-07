using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharParameter : MonoBehaviour
{  
    private ItemComponent.PlayerType playerType;
    private Transform transform;
    private int playerLV;
    private float maxHealth;
    private float currentHealth;
    private float maxMana;
    private float currentMana;
    private float physicalDefense;
    private float magicalDefense; 


    private float walkSpeed;
    private float climbSpeed;
    private float jumpSpeed;
    private float highJumpSpeed;
    private float runSpeed;


    private float attackDamage;
    private float extraAttackDamage;
    private float attackInRange;
    //Wi  ==========
    private float range1;
    private float range2;
    private GameObject bullet, extraBullet;
    //    ==========
    private Transform AttackPoint;
    private LayerMask enemyLayers;


    private float timeWait4NextAction;
    private bool button;
    private bool PhysicalOrMagical;
    private bool grounded;
    private bool ladder;
}
