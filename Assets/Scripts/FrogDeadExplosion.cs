using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class FrogDeadExplosion : MonoBehaviour
{

    public float minForce, maxForce;

    private void Start()
    {
        Explode();
    }

    void Explode()
    {
        Rigidbody2D rb;
        Vector2 dir;
        float force;
        foreach (Transform t in transform.GetComponentsInChildren<Transform>())
        {
            rb = t.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                dir = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f,1f));
                force = Random.Range(minForce, maxForce);
				Debug.Log(dir);
                rb.AddForce(dir * force,ForceMode2D.Impulse);
            }
        }
    }



}
