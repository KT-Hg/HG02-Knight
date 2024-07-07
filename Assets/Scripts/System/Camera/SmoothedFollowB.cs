using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothedFollowB : MonoBehaviour
{
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        offset=gameObject.transform.position;
    }
    
    // Update is called once per frame
    void Update()
    {

    }

    private void LateUpdate()
    {
        Vector3 desiredPotisition;
        desiredPotisition = offset;
        desiredPotisition.y = target.position.y + offset.y;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPotisition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
