using UnityEngine;
using System.Collections;

public class CompactTrash : MonoBehaviour {
    public float crushSize = 0f;
    public GameObject platform;
    public GameObject animControl;
    public AudioClip[] toPlay;
	// Use this for initialization
	void Start () {
	
	}
    void OnTriggerEnter(Collider c) 
        {
        
        StartCoroutine(crush(c));
        StartCoroutine(crusher());
        }
    void PrintInfo(Collider V) 
    {
        Debug.Log("UP:" + V.transform.up);
        Debug.Log("FORWARD:" + V.transform.forward);
        Debug.Log("RIGHT:" + V.transform.right);
    }
    IEnumerator crush(Collider c) {
        float startSize;
        //Debug.Log("Crushing");
        animControl.GetComponent<Animator>().Play("New Animation");
        Vector3 UAxis = new Vector3(0,0,0);
        if(Mathf.Abs(Vector3.Dot(c.transform.up, Vector3.up)) > .7f) {
            UAxis = new Vector3(0, 1, 0);
            //y
           // Debug.Log("Y");

        }
        else if(Mathf.Abs(Vector3.Dot(c.transform.up, Vector3.forward)) > .7f) {
            UAxis = new Vector3(0, 0, 1);
           // Debug.Log("Z");
            //z
        }
        else if(Mathf.Abs(Vector3.Dot(c.transform.up, Vector3.right)) > .7f) {
            UAxis = new Vector3(1, 0, 0);
          //  Debug.Log("X");
            //x
        }
        // PrintInfo(c);
        //   if(Vector3.zero == UAxis) { UAxis = new Vector3(Mathf.Max(c.transform.up.x, c.transform.forward.x, c.transform.right.x), 0, 0); } 
        startSize = (Vector3.Dot(UAxis, c.transform.localScale));
      //  Debug.Log("This is the starting Size" + startSize);
        crushSize = startSize / 10;
        for(float i = 0; i < .5f; i += Time.deltaTime) {
            if(UAxis.x > 0) {
             //   Debug.Log("X Val scale:" + c.transform.localScale);
                //c.transform.localScale.Set(Mathf.Lerp(c.transform.localScale.x, crushSize, i),c.transform.localScale.y,c.transform.localScale.z);
                c.transform.localScale = new Vector3(Mathf.Lerp(startSize, crushSize, i/.5f),c.transform.localScale.y,c.transform.localScale.z);
    }
            else if(UAxis.y > 0) {
             //   Debug.Log("Y Val scale:" + c.transform.localScale);
                c.transform.localScale = new Vector3(c.transform.localScale.x, Mathf.Lerp(startSize, crushSize, i/.5f), c.transform.localScale.z);
            }
            else if (UAxis.z > 0) {
             //   Debug.Log("Z Val scale:" + c.transform.localScale);
                c.transform.localScale = new Vector3(c.transform.localScale.x, c.transform.localScale.y, Mathf.Lerp(startSize, crushSize, i/.5f));
            }
            yield return null;
        }
        AudioSource a = GetComponent<AudioSource>();
        if(c.tag == "Fruit") {
            a.clip = toPlay[0];
            a.Play();
        }
        else if(c.tag == "Metal") {
            a.clip = toPlay[1];
            a.Play();
        }
        else if(c.tag == "Battery") {
            a.clip = toPlay[2];
            a.Play();
        }
        else if(c.tag == "Plastic") {
            a.clip = toPlay[3];
            a.Play();
        }
        else if(c.tag == "Wood") {
            a.clip = toPlay[4];
            a.Play();
        }
       // animControl.GetComponent<Animator>().StopPlayback();
    }
    IEnumerator crusher() {
       // .5 --> -1.4
        for(float i = 0; i < .5f; i += Time.deltaTime) {
            //Debug.Log("HERE");
            platform.transform.localPosition =new Vector3( platform.transform.localPosition.x,Mathf.Lerp(.5f,-1.4f,i/.5f),platform.transform.localPosition.z);
            yield return null;
        }
        for(float i = 0; i < .5f; i += Time.deltaTime) {
            platform.transform.localPosition =new Vector3(platform.transform.localPosition.x, Mathf.Lerp(-1.4f, .5f, i / .5f), platform.transform.localPosition.z);
            yield return null;
        }
        yield return null;
    }
}
