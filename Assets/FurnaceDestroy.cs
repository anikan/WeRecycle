using UnityEngine;
using System.Collections;

public class FurnaceDestroy : MonoBehaviour {
    AudioSource aud;
    public ParticleSystem p;
    public GameObject lights;
    void Start() {
        aud = this.GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision) {
        aud.Play();
        p.Play();
        StartCoroutine(flare());
        Destroy(collision.gameObject);
    }
    IEnumerator flare() {
        for(float i = 0; i < 1f; i += Time.deltaTime) {
            lights.GetComponent<Light>().intensity = Mathf.Lerp(0, 3, i / 1f);
            yield return null;
            Debug.Log(lights.GetComponent<Light>().intensity);
        }
        for(float i = 0; i < 1f; i += Time.deltaTime) {
            lights.GetComponent<Light>().intensity = Mathf.Lerp(3, 0, i / 1f);
            yield return null;
            Debug.Log(lights.GetComponent<Light>().intensity);
        }
        yield return null;
    }
}
