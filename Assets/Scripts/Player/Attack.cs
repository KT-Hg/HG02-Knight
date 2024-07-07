using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float attackDamage;
    [SerializeField]
    public float extraAttackDamage, attackInRange, range1, range2;
    [SerializeField]
    public bool PhysicalOrMagicalAttack;
    [SerializeField]
    public GameObject fire, extraFire;
    [SerializeField]
    public Transform AttackPoint;
    [SerializeField]
    public LayerMask enemyLayers;

    public float timeToAttack;
    public float timeWait;
    public bool button;
    public bool doubleAttack;
    public Rigidbody2D myBody;
    public Animator anim;

    public void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        button = gameObject.GetComponent<Player>().button;
        timeWait = gameObject.GetComponent<Player>().timeWait;
        extraAttackDamage = 1.5f * attackDamage;
    }

    // Update is called once per frame
    void Update()
    {
        if (button)
        {
            if (PhysicalOrMagicalAttack)
            {
                meleeAttackButton();
            }
            else
            {
                shotAttackButton();
            }
        }
        else
        {
            if (PhysicalOrMagicalAttack)
            {
                meleeAttackKeyboard();
            }
            else
            {
                shotAttackKeyboard();
            }
        }
    }

    public void setButtonTrue(int a)
    {
        if (button)
        {
            switch (a)
            {
                case 1:
                    if (timeToAttack == 0)
                    {
                        timeToAttack = Time.time;
                    }
                    else
                    {
                        doubleAttack = true;
                    }
                    break;
            }
        }
    }

    void meleeAttackKeyboard()
    {
        if (Input.GetMouseButtonUp(0) && (timeToAttack == 0))
        {
            timeToAttack = Time.time;
            return;
        }

        if (timeToAttack != 0)
        {
            if (Input.GetMouseButtonUp(0))
            {
                anim.SetTrigger("Attack+");
                timeToAttack = 0f;
                Collider2D[] hitEnemies = Physics2D
                    .OverlapCircleAll(AttackPoint.position, attackInRange, enemyLayers);
                foreach (Collider2D enemy in hitEnemies)
                {
                    enemy.GetComponent<Enemy>()
                        .takeDamage(extraAttackDamage + Random.Range(-8, 8), PhysicalOrMagicalAttack);
                }
            }
            else
            if (Time.time > timeToAttack + timeWait)
            {
                if (anim.GetCurrentAnimatorStateInfo(0).IsName("Walk"))
                {
                    
                    anim.SetBool("Walk", false);
                    anim.SetTrigger("Walk+Attack");
                }
                else
                {
                    if (anim.GetCurrentAnimatorStateInfo(0).IsName("Run"))
                    {
                        anim.SetBool("Walk", false);
                        anim.SetTrigger("Run+Attack");
                    }
                    else
                    {
                        anim.SetTrigger("Attack");
                    }
                }
                timeToAttack = 0f;
                Collider2D[] hitEnemies = Physics2D
                    .OverlapCircleAll(AttackPoint.position, attackInRange, enemyLayers);
                foreach (Collider2D enemy in hitEnemies)
                {

                    enemy.GetComponent<Enemy>()
                        .takeDamage(attackDamage + Random.Range(-4, 4), PhysicalOrMagicalAttack);
                }
            }
        }
    }

    void meleeAttackButton()
    {
        if (timeToAttack != 0)
        {
            if (doubleAttack)
            {
                anim.SetTrigger("Attack+");
                timeToAttack = 0f;
                Collider2D[] hitEnemies = Physics2D
                    .OverlapCircleAll(AttackPoint.position, attackInRange, enemyLayers);
                foreach (Collider2D enemy in hitEnemies)
                {
                    enemy.GetComponent<Enemy>()
                        .takeDamage(extraAttackDamage + Random.Range(-8, 8), PhysicalOrMagicalAttack);
                }
                doubleAttack = false;
            }
            else
            if (Time.time > timeToAttack + timeWait)
            {
                if (anim.GetCurrentAnimatorStateInfo(0).IsName("Walk"))
                {

                    anim.SetBool("Walk", false);
                    anim.SetTrigger("Walk+Attack");
                }
                else
                {
                    if (anim.GetCurrentAnimatorStateInfo(0).IsName("Run"))
                    {
                        anim.SetBool("Walk", false);
                        anim.SetTrigger("Run+Attack");
                    }
                    else
                    {
                        anim.SetTrigger("Attack");
                    }
                }
                timeToAttack = 0f;
                Collider2D[] hitEnemies = Physics2D
                    .OverlapCircleAll(AttackPoint.position, attackInRange, enemyLayers);
                foreach (Collider2D enemy in hitEnemies)
                {

                    enemy.GetComponent<Enemy>()
                        .takeDamage(attackDamage + Random.Range(-4, 4), PhysicalOrMagicalAttack);
                }
                doubleAttack = false;
            }
        }
    }

    void shotAttackKeyboard()
    {

        if (Input.GetMouseButtonUp(0) && (timeToAttack == 0))
        {
            timeToAttack = Time.time;
            return;
        }

        if (timeToAttack != 0)
        {
            if (Input.GetMouseButtonUp(0))
            {
                anim.SetTrigger("Attack+");
                timeToAttack = 0f;
                Invoke("create2", .25f);
            }
            else
            {
                if (Time.time > timeToAttack + timeWait)
                {
                    if (anim.GetCurrentAnimatorStateInfo(0).IsName("Walk"))
                    {
                        anim.SetBool("Walk", false);
                        anim.SetTrigger("Walk+Attack");
                    }
                    else
                    {
                        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Run"))
                        {
                            anim.SetBool("Walk", false);
                            anim.SetTrigger("Run+Attack");
                        }
                        else
                        {
                            anim.SetTrigger("Attack");
                        }
                    }
                    timeToAttack = 0f;
                    Invoke("create1", .25f);

                }
            }
        }
    }

    void shotAttackButton()
    {
        if ((Time.time < timeToAttack + .2f) && timeToAttack != 0 && timeToAttack != Time.time)
        {
            if (doubleAttack)
            {
                anim.SetTrigger("Attack+");
                timeToAttack = 0f;
                Invoke("create2", .5f);
                doubleAttack = false;
            }
        }
        else
        if ((Time.time > timeToAttack + .2f) && timeToAttack != 0)
        {
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Walk"))
            {

                anim.SetBool("Walk", false);
                anim.SetTrigger("Walk+Attack");
            }
            else
            {
                if (anim.GetCurrentAnimatorStateInfo(0).IsName("Run"))
                {
                    anim.SetBool("Walk", false);
                    anim.SetTrigger("Run+Attack");
                }
                else
                {
                    anim.SetTrigger("Attack");
                }
            }
            timeToAttack = 0f;
            Invoke("create1", .5f);
        }

    }

    void create1()
    {
        Instantiate(fire, AttackPoint.transform.position, AttackPoint.transform.rotation, gameObject.transform);

        GameObject[] listFire = GameObject.FindGameObjectsWithTag(fire.tag);
        foreach (GameObject fire in listFire)
        {
            fire.GetComponent<BulletPlayer>().
                setDamageAndRange(attackDamage, attackInRange, range1, PhysicalOrMagicalAttack, gameObject.transform);
        }
    }

    void create2()
    {
        Instantiate(extraFire, AttackPoint.transform.position, AttackPoint.transform.rotation, gameObject.transform);
        GameObject[] listExtraFire = GameObject.FindGameObjectsWithTag(extraFire.tag);
        foreach (GameObject extraFire in listExtraFire)
        {
            extraFire.GetComponent<BulletPlayer>()
                .setDamageAndRange(extraAttackDamage, attackInRange, range2, PhysicalOrMagicalAttack, gameObject.transform);
        }
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(AttackPoint.position, attackInRange);
    }

}
