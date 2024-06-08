using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAttack : MonoBehaviour
{
    public float radius = 70f;

    private void Update()
    {
        DetectColession();
    }

    private void DetectColession()
    {
       Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);

        foreach (var el in hitColliders)
        {
            if ((gameObject.CompareTag("Player") && el.gameObject.CompareTag("Enemy")) ||
            (gameObject.CompareTag("Enemy") && el.gameObject.CompareTag("Player")))

            {
                Debug.Log(el.name);
            }
        }        
    } 
}
