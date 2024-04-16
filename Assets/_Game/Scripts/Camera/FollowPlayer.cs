using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    public Vector3 offset;
    public float moveSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 pos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, pos, moveSpeed * Time.deltaTime);
    }
}
