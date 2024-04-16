using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator : MonoBehaviour
{
    // Start is called before the first frame update
    private Character target;
    private Transform targetTf;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnInit(Character target, Transform targetTf )
    {
        this.target = target;
        this.targetTf = targetTf;
    }
}
