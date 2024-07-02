using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CarAttack : MonoBehaviour
{
    public float radius = 70f;
    public GameObject bullet;
    private Coroutine _coroutine;

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
                if (gameObject.CompareTag("Enemy"))
                    GetComponent<NavMeshAgent>().SetDestination(el.transform.position);

                _coroutine = StartCoroutine(StartAttack(el.transform.position));
            }
        }        
    } 

    IEnumerator StartAttack(Vector3 enemyPos)
    {
        while (true)
        {
           GameObject obj = Instantiate(bullet, transform.GetChild(1).position, Quaternion.identity);
            obj.GetComponent<BulletController>().position = enemyPos;
            yield return new WaitForSeconds(1f);
        }
    }
}
