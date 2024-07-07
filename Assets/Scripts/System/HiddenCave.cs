using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenCave : MonoBehaviour
{
    [SerializeField]
    private GameObject coverCaveObj;
    private bool hiddenCave;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hiddenCave)
        {
            coverCaveObj.SetActive(false);
        }
        else
        {
            coverCaveObj.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        hiddenCave = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            hiddenCave = true;
        }
    }
}
