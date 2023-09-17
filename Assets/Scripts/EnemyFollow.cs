using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    private Spawner SpawnerFollowController;
    public float new_speed;
    public Transform target;
    private bool enemyFacingLeft;
    
    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        SpawnerFollowController = GameObject.Find("SpawnArea").GetComponent<Spawner>();
        new_speed = SpawnerFollowController.speed; 
    }
        
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, new_speed * Time.deltaTime); 

        if ((transform.position.x < target.position.x) && !enemyFacingLeft)
        {
            TurnEnemy();
        }
        else if ((transform.position.x > target.position.x) && enemyFacingLeft)
        {
            TurnEnemy();
        }
    }

    public void TurnEnemy()
    {
        enemyFacingLeft = !enemyFacingLeft;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
