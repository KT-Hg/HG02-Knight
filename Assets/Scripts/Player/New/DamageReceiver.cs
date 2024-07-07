using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageReceiver : MonoBehaviour
{
    public CharManager charManager;

    private void Awake()
    {
        charManager = GetComponentInParent<CharManager>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        charManager.grounded = false;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            charManager.grounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        charManager.ladder = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ladder")
        {
            charManager.ladder = true;
        }
        if (collision.gameObject.tag == "Ground")
        {
            charManager.grounded = true;
        }
    }
}
