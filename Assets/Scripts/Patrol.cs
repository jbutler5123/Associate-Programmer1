using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public GameObject enemy;
    public void patrol()
    {
        //Patrol Logic
                Vector3 moveToPoint = enemy.GetComponent<RefactorEnemy>().patrolPoints[enemy.GetComponent<RefactorEnemy>().currentPatrolPoint].position;
                transform.position = Vector3.MoveTowards(enemy.GetComponent<RefactorEnemy>().transform.position, moveToPoint, enemy.GetComponent<RefactorEnemy>().enemyStats.walkSpeed * Time.deltaTime);

                if (Vector3.Distance(transform.position, moveToPoint) < 0.01f)
                {
                    enemy.GetComponent<RefactorEnemy>().currentPatrolPoint++;
                    if (enemy.GetComponent<RefactorEnemy>().currentPatrolPoint > enemy.GetComponent<RefactorEnemy>().patrolPoints.Length - 1)
                    {
                        enemy.GetComponent<RefactorEnemy>().currentPatrolPoint = 0;
                    }
                }
    }
}
