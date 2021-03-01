using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleCenter : MonoBehaviour
{
    public float secondsPerSpawn = 0.5f;
    public float secondsPerSalvo = 8;
    public float spawnRadius = 5f; // the distance at which 'notes' spawn
    public float indicatorRadius = 8f;

    public GameObject hazard_indicator;

    public GameObject projectile;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawner());
    }

    void spawnEnemy()
    {
        Vector2 spawnPoint = (Random.insideUnitCircle * spawnRadius)+(Vector2.one*5);
        spawnEnemy(spawnPoint);
    }

    void spawnEnemy(Vector2 point)
    {
        GameObject obj = Instantiate(projectile, point, Quaternion.identity);
        obj.GetComponent<Projectile>().sendToward(transform.position);
    }
    
    IEnumerator Spawner()
    {
        while(true)
        {
            float salvo_angle = Random.Range(0, 359);
            Coroutine salvo = StartCoroutine(SpawnSalvo(salvo_angle, 3, 10));
            yield return new WaitForSeconds(1);
            Coroutine opp_salvo = StartCoroutine(SpawnSalvo(salvo_angle + 180, 3, 10));
            yield return salvo;
            yield return opp_salvo;
            yield return new WaitForSeconds(secondsPerSalvo);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        HeartIndicator.hearts--;
    }

   
    IEnumerator SpawnSalvo(float angle, int numProjectiles, float deviation)
    {
        WaitForSeconds shotCooldown = new WaitForSeconds(secondsPerSpawn);
        GameObject indc = null;
        if (hazard_indicator != null)
            indc = spawnIndicatorToward(angle);
        for (int i = 0; i < numProjectiles; i++)
        {

            float theta = GaussianRandoms.NextGaussian(angle, deviation) * Mathf.Deg2Rad;
            float x = spawnRadius * Mathf.Cos(theta);
            float y = spawnRadius * Mathf.Sin(theta);

            spawnEnemy(new Vector2(x, y));
            yield return shotCooldown;
        }

        if (indc != null) Destroy(indc);
        yield return null;
    }

    GameObject spawnIndicatorToward(float angle)
    {
        float theta = angle * Mathf.Deg2Rad;
        float x = indicatorRadius * Mathf.Cos(theta);
        float y = indicatorRadius * Mathf.Sin(theta);

        return Instantiate(hazard_indicator, new Vector2(x, y), Quaternion.identity);

    }
}
