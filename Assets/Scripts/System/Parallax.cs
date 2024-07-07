using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length, startpos;
    [SerializeField]
    private GameObject cam;
    [SerializeField]
    private float parallaxEffect;

    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    /*void Update()
    {
        
    }*/

    private void FixedUpdate()
    {
        parallax1();
    }

    void parallax1()
    {
        float tempX = (cam.transform.position.x * (1 - parallaxEffect));
        float distX = (cam.transform.position.x * parallaxEffect);

        transform.position = new Vector3(startpos + distX, transform.position.y, transform.position.z);

        if (tempX > startpos + length) startpos += length;
        else if (tempX < startpos - length) startpos -= length;
    }

    void parallax2()
    {
        float tempY = (cam.transform.position.y * (1 - parallaxEffect));
        float distY = (cam.transform.position.y * parallaxEffect);

        transform.position = new Vector3(transform.position.x, startpos + distY, transform.position.z);

        if (tempY > startpos + length) startpos += length;
        else if (tempY < startpos - length) startpos -= length;
    }
}
