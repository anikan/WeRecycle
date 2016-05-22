using UnityEngine;
using System.Collections;

public class CompactTrash : MonoBehaviour {
    public float crushSize = 0f;
    public GameObject compactorAnim;
    
	// Use this for initialization
	void Start () {
	
	}
    void OnTriggerEnter(Collider c) 
        {
        
        StartCoroutine(crush(c));
        }
    
    IEnumerator crush(Collider c) {
        yield return new WaitForSeconds(1f);
        compactorAnim.GetComponent<Animator>().Play("New Animation");
        float startSize;
        Vector3 UAxis = new Vector3(0,0,0);
        if(Mathf.Abs(Vector3.Dot(c.transform.up, Vector3.up)) > .8f) {
            UAxis = new Vector3(0, 1, 0);
            //y
            Debug.Log("Y");

        }
        else if(Mathf.Abs(Vector3.Dot(c.transform.forward, Vector3.forward)) > .8f) {
            UAxis = new Vector3(0, 0, 1);
            Debug.Log("Z");
            //z
        }
        else if(Mathf.Abs(Vector3.Dot(c.transform.right, Vector3.right)) > .8f) {
            UAxis = new Vector3(1, 0, 0);
            Debug.Log("X");
            //x
        }
        //Debug.Log(UAxis);
        startSize = (Vector3.Dot(UAxis, c.transform.localScale));
        Debug.Log("This is the starting Size" + startSize);
        crushSize = 0;//startSize / 10000;
        for(float i = 0; i < .5f; i += Time.deltaTime) {
            if(UAxis.x > 0) {
                Debug.Log("X Val scale:" + c.transform.localScale);
                //c.transform.localScale.Set(Mathf.Lerp(c.transform.localScale.x, crushSize, i),c.transform.localScale.y,c.transform.localScale.z);
                c.transform.localScale = new Vector3(Mathf.Lerp(startSize, crushSize, i),c.transform.localScale.y,c.transform.localScale.z);
    }
            else if(UAxis.y > 0) {
                Debug.Log("Y Val scale:" + c.transform.localScale);
                c.transform.localScale = new Vector3(c.transform.localScale.x, Mathf.Lerp(startSize, crushSize, i), c.transform.localScale.z);
            }
            else if (UAxis.z > 0) {
                Debug.Log("Z Val scale:" + c.transform.localScale);
                c.transform.localScale = new Vector3(c.transform.localScale.x, c.transform.localScale.y, Mathf.Lerp(startSize, crushSize, i));
            }
            yield return null;
        }

    }
	// Update is called once per frame
	void Update () {
	
	}
}
