using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothedFollowA : MonoBehaviour
{
    [SerializeField]
    private float smoothSpeed;
    [SerializeField]
    private Vector3 offset;
    [SerializeField]
    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    
    // Update is called once per frame
    void Update()
    {

    }

    private void LateUpdate()
    {
        Vector3 desiredPotisition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPotisition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
