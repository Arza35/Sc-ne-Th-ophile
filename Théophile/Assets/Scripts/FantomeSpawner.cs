using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FantomeSpawner : MonoBehaviour {

    public float spawnRate;
    public GameObject Fantome;
    public bool gizmos = true;

    public float xOffset;

    public float yOffset;

	void Start () {
        StartCoroutine(beginSpawn());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator beginSpawn() {
        yield return new WaitForSeconds(spawnRate);
        Instantiate(Fantome, new Vector2(Mathf.Clamp(transform.position.x, transform.position.x - xOffset, transform.position.x + xOffset), Mathf.Clamp(transform.position.y, transform.position.y - yOffset, transform.position.y + yOffset)), Quaternion.identity);
    }

    private void OnDrawGizmos()
    {
        if (gizmos) {

        }
    }
}
