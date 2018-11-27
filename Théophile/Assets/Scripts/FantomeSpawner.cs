using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FantomeSpawner : MonoBehaviour {

    public float spawnRate;
    public Vector2 offSetSpawnRate;
    public GameObject FantomeDevant;
    public GameObject FantomeDerriere;
    public bool gizmos = true;

    public float xOffset;

    public float yOffset;

	void Start () {
        StartCoroutine(beginSpawnDevant());
        StartCoroutine(beginSpawnDerriere());
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator beginSpawnDevant() {
        float offset = Random.Range(offSetSpawnRate.x, offSetSpawnRate.y);
        float randomX = Random.Range(transform.position.x - xOffset, transform.position.x + xOffset);
        float randomY = Random.Range(transform.position.y - yOffset, transform.position.y + yOffset);
        yield return new WaitForSeconds(spawnRate+offset);
        Instantiate(FantomeDevant, new Vector2(randomX, randomY), Quaternion.identity);
        StartCoroutine(beginSpawnDevant());
    }

    IEnumerator beginSpawnDerriere() {
        float offset = Random.Range(offSetSpawnRate.x, offSetSpawnRate.y);
        float randomX = Random.Range(transform.position.x - xOffset, transform.position.x + xOffset);
        float randomY = Random.Range(transform.position.y - yOffset, transform.position.y + yOffset);
        yield return new WaitForSeconds(spawnRate + offset+2f);
        Instantiate(FantomeDerriere, new Vector2(randomX, randomY), Quaternion.identity); StartCoroutine(beginSpawnDerriere());
    }

    private void OnDrawGizmos()
    {
        if (gizmos) {
            Gizmos.DrawCube(transform.position, new Vector3(xOffset*2, yOffset*2, 1f));
        }
    }
}
