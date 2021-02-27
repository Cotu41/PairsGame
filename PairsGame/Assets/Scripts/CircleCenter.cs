using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleCenter : MonoBehaviour
{
    public float secondsPerSpawn = 0.5f;
    public float spawnRadius = 5f; // the distance at which 'notes' spawn

    public GameObject projectile;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawner());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void spawnEnemy()
    {
        Vector2 spawnPoint = Random.insideUnitCircle * spawnRadius;

        GameObject obj = Instantiate(projectile, spawnPoint, Quaternion.identity);
        obj.GetComponent<Projectile>().sendToward(transform.position);
    }

    IEnumerator Spawner()
    {
        while(true)
        {
            spawnEnemy();
            yield return new WaitForSeconds(secondsPerSpawn);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }


}
