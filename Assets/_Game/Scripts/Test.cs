using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject cube;
    public GameObject weaponHolder;

    private void Start()
    {
        Instantiate(cube, weaponHolder.transform.position, Quaternion.identity);
    }

    private void MoveToRandomPosition()
    {
      
    }
    private void Update()
    {

    }
}

