using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptLaser : MonoBehaviour
{
    LineRenderer line;

    public GameObject fireBall;
    public GameObject smoke;

    // Start is called before the first frame update
    void Start()
    {

        line = gameObject.GetComponent<LineRenderer>();
        line.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            StopCoroutine("FireLaser");
            StartCoroutine("FireLaser");
        }

    }

    IEnumerator FireLaser()
    {
        line.enabled = true;

        while (Input.GetButton("Fire1")) { 
            Ray ray = new Ray(transform.position, transform.forward);

            RaycastHit hit;

            line.SetPosition(0, ray.origin);

            if (Physics.Raycast(ray, out hit, 100))
            {
                line.SetPosition(1, hit.point);

                if (hit.rigidbody)
                {
                    Collider[] colliders = Physics.OverlapSphere(hit.point, 5);
                    foreach (Collider collider in colliders)
                    {
                        if (collider.GetComponent<Rigidbody>() == null) 
                        {
                            continue;
                        }
                        else
                        {
                            Instantiate(fireBall, collider.transform.position, Quaternion.identity);
                            Instantiate(smoke, collider.transform.position, Quaternion.identity);
                            collider.GetComponent<Rigidbody>().AddExplosionForce(8, hit.point, 10, 0, ForceMode.Impulse);
                        }
                        
                    }
                }
            }
            else
            {
                line.SetPosition(1, ray.GetPoint(100));
            }

            
            yield return null;
        }
        line.enabled = false;
    }
}
