using UnityEngine;
using System.Collections;

public class TrashScript : MonoBehaviour {

    public BinType type;
    public string incorrectBinString = "";
    public bool isReady = true;

    public static int fruitSuccess;


    public AudioClip[] toPlay;
    AudioSource a;
    // Use this for initialization
    void Start () {
        a = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnTriggerEnter(Collider other)
    {
        BinScript binScript = other.GetComponent<BinScript>();
        if (binScript)
        {
            //Yay match.
            if (binScript.type == this.type && isReady)
            {
                other.GetComponentInChildren<ParticleSystem>().Play();

                OverallStatus.overallStatusInstance.onCorrectInput();

                fruitSuccess += 1;
            a.clip = toPlay[0];
                a.volume = .5f;
                a.Play();
                //Play sound
                //Do particles

            }

            //Darn incorrect.
            else
            {
                OverallStatus.overallStatusInstance.onIncorrectInput(incorrectBinString);
                a.clip = toPlay[1];
                a.volume = .2f;
                a.Play();
                // makeBubble(incorrectBinString, binScript.gameObject);
            }

            GrabScriptVive[] vives = OverallStatus.playerCamera.transform.parent.GetComponentsInChildren<GrabScriptVive>();

            for (int i =0; i< vives.Length; i++)
            {
                vives[i].DisconnectIfEqual(this.gameObject);
            }

            StartCoroutine(destroyInTime(5.0f));
        }

    }

    /// <summary>
    /// Create a text bubble with default 0,.5f,0 offset.
    /// </summary>
    /// <param name="message"></param>
    public void makeBubble(string message, GameObject parent)
    {
        makeBubble(message, new Vector3(0, 3.5f, 0), parent);
    }

    /// <summary>
    /// Create a text bubble that hovers over the object.
    /// </summary>
    /// <param name="message"></param>
    /// <param name="offset"></param>
    public void makeBubble(string message, Vector3 offset, GameObject parent)
    {
        //Create the bubble above the object.
        GameObject bubble = (GameObject)GameObject.Instantiate(OverallStatus.textBubblePrefab, transform.position, new Quaternion());

        bubble.GetComponent<TextBubbleScript>().fullMessage = message;

        bubble.transform.SetParent(parent.transform, true);
        bubble.transform.localPosition = offset;
    }

    IEnumerator destroyInTime(float time)
    {
        yield return new WaitForSeconds(time);
        GrabScriptVive[] vives = OverallStatus.playerCamera.transform.parent.GetComponentsInChildren<GrabScriptVive>();

        for (int i = 0; i < vives.Length; i++)
        {
            vives[i].DisconnectIfEqual(this.gameObject);
        }

        Destroy(this.gameObject);
    }
}
