using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour
{
    public GameObject enemy;
    public GameObject player;

    public void chase()
    {
    //Chase the player
             enemy.GetComponent<RefactorEnemy>().sight.position = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
             transform.LookAt(enemy.GetComponent<RefactorEnemy>().sight);
             transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Time.deltaTime * enemy.GetComponent<RefactorEnemy>().enemyStats.chaseSpeed);
           
            //Explode if we get within the enemyStats.explodeDist
            if (Vector3.Distance(transform.position, player.transform.position) < enemy.GetComponent<RefactorEnemy>().enemyStats.explodeDist)
            {
                StartCoroutine("Explode");
                enemy.GetComponent<RefactorEnemy>().enemyStats.idle = true;
            }
    }
}