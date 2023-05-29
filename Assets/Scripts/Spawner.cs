using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] fruitToSpawnPrefab;
    public int chanceToSpawnBomb = 10;
    public GameObject bombPrefab;
    public Transform[] spawnPlaces;
    public float minWait=0.3f;
    public float maxWait=1f;
    public float minForse=12;
    public float maxForse=17;



    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnFruits());

        
    }

    private IEnumerator SpawnFruits()
    {
        while (true)
        {
        yield return new WaitForSeconds(Random.Range(minWait, maxWait));
        Transform t = spawnPlaces[Random.Range(0, spawnPlaces.Length)];

        GameObject go = null;
        float rnd = Random.Range(0, 100);

        if(chanceToSpawnBomb > 90)
        {
            chanceToSpawnBomb=90;
        }
        else if (chanceToSpawnBomb <0)
        {
            chanceToSpawnBomb=0;
        }

        if(rnd <chanceToSpawnBomb)
        {
            go = bombPrefab;
        }
        else{
            go =fruitToSpawnPrefab[Random.Range(0, fruitToSpawnPrefab.Length)];
        }
        GameObject fruit= Instantiate(go, t.transform.position, t.transform.rotation);

        fruit.GetComponent<Rigidbody2D>().AddForce(t.transform.up*Random.Range(minForse, maxForse),  ForceMode2D.Impulse);

        Debug.Log("Frucht wurde erzeugt");

        Destroy(fruit, 5);
        }
    }
}
