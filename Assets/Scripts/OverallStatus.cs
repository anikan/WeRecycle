using UnityEngine;
using System.Collections;

public class OverallStatus : MonoBehaviour {

    public static GameObject playerCamera;
    public static GameObject textBubblePrefab;
    public GameObject textBubblePrefabInput;

    void Awake()
    {
        playerCamera = Camera.main.gameObject;
        textBubblePrefab = textBubblePrefabInput;
        Debug.Log(textBubblePrefab);
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
