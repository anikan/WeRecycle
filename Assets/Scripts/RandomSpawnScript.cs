using UnityEngine;
using System.Collections;

public class RandomSpawnScript : MonoBehaviour {
    public float spawnRate = 2f;
    void Start() {
        StartCoroutine(spawnSeconds());
    }
    // Update is called once per frame
    void Update () {
	}
    IEnumerator spawnSeconds() 
        {
        while(true) {
            Object[] batt = (Object[])Resources.LoadAll("TrashSort", typeof(GameObject));
            GameObject randomBat = (GameObject)batt[Random.Range(0, batt.Length)];
            GameObject battery = (GameObject)Instantiate(randomBat, transform.position, transform.rotation);
            yield return new WaitForSeconds(spawnRate);
        }
    }
}
