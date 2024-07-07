using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlayer : MonoBehaviour
{
    [SerializeField]
    private Transform AttackPoint, parent;
    [SerializeField]
    private LayerMask enemyLayers;
    [SerializeField]
    private float speed, attackRandomDamage;
    private float range;
    private float attackDamage;
    private float attackRange;
    private bool PhysicalOrMagicalAttack;

    private Vector3 startPoint;
    private bool enemy;
    private bool destroyTF;

    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        AttackPoint = gameObject.GetComponentInChildren<Transform>();
    }

    // Start is called before the first frame update
    void Start()
    {
        startPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!destroyTF)
        {
            if (enemy)
            {
                anim.SetTrigger("Hit");
                hit();
                destroyTF = true;
                Invoke("destroy", .15f);
            }
            else
            if (Mathf.Round(transform.position.x - startPoint.x) == range
                || Mathf.Round(startPoint.x - transform.position.x) == range)
            {
                anim.SetTrigger("Hit");
                destroyTF = true;
                Invoke("destroy", .15f);
            }
            else
            {
                walk();
            }
        }
    }

    void walk()
    {
        float h = parent.localScale.x;
        transform.position += new Vector3(h * speed * Time.deltaTime, 0, 0);
    }

    void hit()
    {
        Collider2D[] hitEnemies = Physics2D
            .OverlapCircleAll(AttackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>()
                .takeDamage(attackDamage + Random.Range(-attackRandomDamage, attackRandomDamage), PhysicalOrMagicalAttack);
        }
    }

    public void setDamageAndRange(float a, float b, float c, bool d, Transform e)
    {
        attackDamage = a;
        attackRange = b;
        range = c;
        PhysicalOrMagicalAttack = d;
        parent = e;
    }

    void destroy()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            enemy = true;
        }
    }
}
