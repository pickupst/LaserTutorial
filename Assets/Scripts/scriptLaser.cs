using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptLaser : MonoBehaviour
{
    LineRenderer line;

    // Start is called before the first frame update
    void Start()
    {

        line = gameObject.GetComponent<LineRenderer>();

    }

    // Update is called once per frame
    void Update()
    {

        Ray ray = new Ray(transform.position, transform.forward);
        line.SetPosition(0, ray.origin);
        line.SetPosition(1, ray.GetPoint(100));

    }
}
