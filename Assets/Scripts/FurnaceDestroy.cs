using UnityEngine;
using System.Collections;

public class FurnaceDestroy : MonoBehaviour {
    AudioSource aud;
    public ParticleSystem p;
    public GameObject lights;
    public GameObject conveyor;
    public GameObject successFruit;
    int furnaceDmg;
    void Start() {
        aud = this.GetComponent<AudioSource>();
    }
    void Update() 
        {
        if(furnaceDmg > 0) 
            {
            conveyor.GetComponent<ConveyorBelt>().maxSpeed = Mathf.Min(conveyor.GetComponent<ConveyorBelt>().maxSpeed - .02f,.5f);
            furnaceDmg -= 1;
            }
        if(TrashScript.fruitSuccess > 0) {
            conveyor.GetComponent<ConveyorBelt>().maxSpeed += .02f;
           TrashScript.fruitSuccess -= 1;
        }
    }
    void OnCollisionEnter(Collision collision) {
        OverallStatus.overallStatusInstance.onIncinerate();
        aud.Play();
        p.Play();
        StartCoroutine(flare());
        Destroy(collision.gameObject);
        furnaceDmg += 1;
    }
    IEnumerator flare() {
        for(float i = 0; i < 1f; i += Time.deltaTime) {
            lights.GetComponent<Light>().intensity = Mathf.Lerp(0, 3, i / 1f);
            yield return null;
        }
        for(float i = 0; i < 1f; i += Time.deltaTime) {
            lights.GetComponent<Light>().intensity = Mathf.Lerp(3, 0, i / 1f);
            yield return null;
        }
        yield return null;
    }
}
