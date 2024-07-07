using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public enum idEnemy
    {
        Goblin = 1,
        Dino = 2,
        Ent = 3,
        Mosquito = 4,
        Beholder = 5,
        Spider = 6,
    }
    public idEnemy id;
    public float maxHealth, currentHealth;

    [SerializeField]
    private float moveSpeed, rangeFollow, rangeForAttack, attackDamage, attackInRange, rangeBullet,
        physicalDefense, magicalDefense, distanceForReturn, Damage, timeDelay, distanceMove;
    [SerializeField]
    private bool PhysicalOrMagicalAttack, PhysicalOrMagical, WalkOrFly, meleeOrRange;
    [SerializeField]
    private Transform AttackPoint;
    [SerializeField]
    private LayerMask playerLayers;
    [SerializeField]
    private GameObject fire;

    [SerializeField]
    private Transform groundDetection;
    [SerializeField]
    private float distance;

    private bool grounded;
    private bool isDead;
    private float distanceFromPlayer;
    private float time;
    private float timeRestore;
    private float timeCountdown;
    private float timeStart;
    private float timeReturn;

    private Animator anim;
    private Transform player;
    public Vector3 originalPosition;
    private Vector3 Position;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        originalPosition = transform.position;
        Position = originalPosition;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (WalkOrFly && Time.time > timeReturn) 
        {
            CheckGround();
            AIWalk();
        }
        else
        {
            if (!WalkOrFly)
            {
                AIFly();
            }
        }
        hurt_death();
    }

    void AIWalk()
    {
        if (Time.time > time + Random.Range(2, 4))
        {
            time = Time.time;
            Position = originalPosition;
            Position.x = originalPosition.x + Random.Range(-distanceMove, distanceMove);
        }

        distanceFromPlayer = Vector2.Distance(player.position, transform.position);

        if (Mathf.Abs(originalPosition.x - player.position.x) < distanceForReturn)
        {
            if (distanceFromPlayer <= rangeForAttack && timeStart == 0)
            {
                timeStart = Time.time;
            }
            else
            {
                if (distanceFromPlayer >= rangeForAttack)
                {
                    timeStart = 0;
                }
            }

            if (distanceFromPlayer < rangeFollow && distanceFromPlayer > rangeForAttack)
            {
                walk(transform, player.position);
            }
            else
            {
                if (distanceFromPlayer < rangeForAttack)
                {
                    anim.SetBool("Walk", false);
                    if (Time.time >= timeCountdown && Time.time > timeStart + timeDelay) 
                    {
                        anim.SetTrigger("Attack");
                        Invoke("attack", 0.08f);
                        timeCountdown = Time.time + timeDelay;
                    }
                }
            }
        }
        else
        {
            walk(transform, Position);
        }
    }

    void AIFly()
    {
        if (Time.time > time + Random.Range(2, 4))
        {
            time = Time.time;
            Position = originalPosition;
            Position.x = originalPosition.x + Random.Range(-distanceMove, distanceMove);
            Position.y = originalPosition.y + Random.Range(-distanceMove, distanceMove);
        }

        distanceFromPlayer = Vector2.Distance(player.position, transform.position);

        if (Mathf.Abs(originalPosition.x - player.position.x) < distanceForReturn)
        {
            if (distanceFromPlayer <= rangeForAttack && timeStart == 0)
            {
                timeStart = Time.time;
            }
            else
            {
                if (distanceFromPlayer >= rangeForAttack)
                {
                    timeStart = 0;
                }
            }

            if (distanceFromPlayer < rangeFollow && distanceFromPlayer > rangeForAttack)
            {
                fly(transform, player.position);
            }
            else
            {
                if (distanceFromPlayer < rangeForAttack)
                {
                    anim.SetBool("Fly", false);
                    if (Time.time >= timeCountdown && Time.time > timeStart + timeDelay)
                    {
                        anim.SetTrigger("Attack");
                        Invoke("attack", 0.08f);
                        timeCountdown = Time.time + timeDelay;
                    }
                }
            }
        }
        else
        {
            fly(transform, Position);
        }
    }

    void attack()
    {
        if (meleeOrRange)
        {
            Collider2D[] hitPlayer = Physics2D
            .OverlapCircleAll(AttackPoint.position, attackInRange, playerLayers);
            foreach (Collider2D enemy in hitPlayer)
            {
                enemy.GetComponent<Player>()
                    .takeDamage(attackDamage + Random.Range(0, 3), PhysicalOrMagicalAttack);
            }
        }
        else
        {
            Instantiate(fire, AttackPoint.transform.position, AttackPoint.transform.rotation, gameObject.transform);
            GameObject[] listFire = GameObject.FindGameObjectsWithTag(fire.tag);
            foreach (GameObject fire in listFire)
            {
                fire.GetComponent<BulletEnemy>()
                    .setDamageAndRange(attackDamage, attackInRange, rangeBullet, PhysicalOrMagicalAttack, gameObject.transform);
            }
        }
        
    }

    void walk(Transform a, Vector3 b)
    {
        if (Mathf.Round(b.x) > Mathf.Round(a.position.x)) 
        {
            Vector3 scale = transform.localScale;
            scale.x = 1f;
            transform.localScale = scale;
            if (grounded)
            {
                transform.position += new Vector3(1 * moveSpeed * Time.deltaTime, 0, 0);
                anim.SetBool("Walk", true);
            }
        }
        else
        if (Mathf.Round(b.x) < Mathf.Round(a.position.x))
        {
            Vector3 scale = transform.localScale;
            scale.x = -1f;
            transform.localScale = scale;
            if (grounded)
            {
                transform.position += new Vector3(-1 * moveSpeed * Time.deltaTime, 0, 0);
                anim.SetBool("Walk", true);
            }
        }
        else
        {
            anim.SetBool("Walk", false);
        }
    }
    
    void fly(Transform a, Vector3 b)
    {
        b.y += 1f;
        if (Mathf.Round(b.x) > Mathf.Round(a.position.x))
        {
            Vector3 scale = transform.localScale;
            scale.x = 1f;
            transform.localScale = scale;
            b.x -= 1f;
            transform.position = Vector2.MoveTowards(a.position, b, moveSpeed * Time.deltaTime);
            anim.SetBool("Fly", true);
        }
        else
        if (Mathf.Round(b.x) < Mathf.Round(a.position.x))
        {
            Vector3 scale = transform.localScale;
            scale.x = -1f;
            transform.localScale = scale;
            b.x += 1f;
            transform.position = Vector2.MoveTowards(a.position, b, moveSpeed * Time.deltaTime);
            anim.SetBool("Fly", true);
        }
        else
        {
            anim.SetBool("Fly", false);
        }
    }

    void hurt_death()
    {
        if ((Time.time > timeRestore + 15f) && (currentHealth < maxHealth))
        {
            currentHealth = maxHealth;
        }

        if (Damage > 0)
        {
            timeCountdown = Time.time + timeDelay;
            if (PhysicalOrMagical && (Damage - physicalDefense) > 0)
            {
                currentHealth -= (Damage - physicalDefense);
                timeRestore = Time.time;
            }
            else
            if (!PhysicalOrMagical && (Damage - magicalDefense) > 0)
            {
                currentHealth -= (Damage - magicalDefense);
                timeRestore = Time.time;
            }

            Damage = 0;

            if (currentHealth > 0)
            {
                anim.SetTrigger("Hurt");
            }
            else
            {
                if (!isDead)
                {
                    anim.SetTrigger("Death");
                    Invoke("dropItem", 0.9f);
                    Invoke("destroy", 0.5f);
                    isDead = true;
                }
            }
        }
    }

    public void takeDamage(float damage, bool physicalormagical)
    {
        Damage = damage;
        PhysicalOrMagical = physicalormagical;
    }


    void dropItem()
    {

    }

    public void destroy()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, rangeFollow);
        Gizmos.DrawWireSphere(transform.position, rangeForAttack);
        Gizmos.DrawWireSphere(transform.position, distanceForReturn);

        if (AttackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(AttackPoint.position, attackInRange);
    }

    private void CheckGround()
    {
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        if (groundInfo.collider == null)
        {
            grounded = true;
            timeReturn = Time.time + timeDelay;
            walk(gameObject.transform, originalPosition);
        }
        else
        {
            if (groundInfo.collider.tag == "Ground")
            {
                grounded = true;
            }
            else
            {
                if (groundInfo.collider.tag == "Ladder")
                {
                    grounded = true;
                    gameObject.GetComponent<Rigidbody2D>().constraints = ~RigidbodyConstraints2D.FreezePositionX;
                }
                else
                {
                    timeReturn = Time.time + timeDelay;
                    walk(transform, originalPosition);
                }
            }
        }
        
    }

}
