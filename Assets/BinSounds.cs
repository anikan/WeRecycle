using UnityEngine;
using System.Collections;
[RequireComponent(typeof(AudioSource))]
public class BinSounds : MonoBehaviour {
    public AudioClip[] toPlay;
    public AudioSource a;
    // Use this for initialization
    void Start () {
        a = GetComponent<AudioSource>();
	}
    void OnTriggerEnter(Collider other) {
       
    }
        // Update is called once per frame
        void Update () {
	
	}
}
