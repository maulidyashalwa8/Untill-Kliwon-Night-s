using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject enemyObject;

    private bool hasSpawned = false;

   
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasSpawned)
        {
            ActivateEnemy();
            hasSpawned = true;
            Destroy(this);
        }
    }


    private void ActivateEnemy()
    {
    
        enemyObject.SetActive(true);

        if (!enemyObject.GetComponent<EnemyMovement>())
        {
            EnemyMovement enemyMovement = enemyObject.AddComponent<EnemyMovement>();
            enemyMovement.speed = 5f;
        }
    }
}
