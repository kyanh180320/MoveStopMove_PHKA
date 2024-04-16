using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    // Start is called before the first frame update
    public BoxCollider boundsMove;
    public List<Transform> listSpawnPos = new List<Transform>();
    public Vector3 RandomPos()
    {
        Bounds bounds = boundsMove.bounds;
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float z = Random.Range(bounds.min.z, bounds.max.z);
        Vector3 randomPos = new Vector3(x, 0, z);
        return randomPos;
    }
}
