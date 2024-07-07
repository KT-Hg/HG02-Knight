using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public ItemComponent.PlayerType playerType;
    public Transform transform;
    public int playerLV;
    public bool buttonOrKeyboard;
    public bool PhysicalOrMagical;
    public float timeWait4NextAction;
    public float timeDelay;


    public float maxHealth;
    public float currentHealth;
    public float maxMana;
    public float currentMana;
    public float physicalDefense;
    public float magicalDefense;


    public float walkSpeed; 
    public float runSpeed;
    public float climbSpeed;
    public float jumpForce;
    public float highJumpForce;



    public float attackDamage;
    public float extraAttackDamage;
    public GameObject bullet;
    public GameObject extraBullet;
    public float attackInRange;
    public float attackInRange2;
    public Transform AttackPoint;
    public LayerMask enemyLayers;


    public bool grounded;
    public bool ladder;
}
