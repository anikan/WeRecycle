using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OverallStatus : MonoBehaviour {

    public static GameObject playerCamera;
    public static GameObject textBubblePrefab;
    public static OverallStatus overallStatusInstance;

    public GameObject textBubblePrefabInput;
    public GameObject canvas;
    public GameObject conveyorBelt;

    public GameObject correctGameObject;
    public GameObject incorrectGameObject;
    public GameObject defaultImageGameObject;

    public Text statsText;
    public Text errorText;
    public Text scoreText;

    public static int numSorted = 0;
    public static int numMissed = 0;
    public static int numIncorrect = 0;
    public static int score = 0;

    void Awake()
    {
        playerCamera = Camera.main.gameObject;
        textBubblePrefab = textBubblePrefabInput;
        overallStatusInstance = this;
    }

    // Use this for initialization
    void Start () {
        updateStatsScore();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void onCorrectInput()
    {
        float speed = conveyorBelt.GetComponent<ConveyorBelt>().maxSpeed;
        numSorted++;

        score += (int)(speed * 10);

        updateStatsScore();

        StopAllCoroutines();
        resetState();
        StartCoroutine(showCorrect());
    }

    public void onIncorrectInput(string errorString)
    {
        numIncorrect++;
        updateStatsScore();

        StopAllCoroutines();
        resetState();
        StartCoroutine(showIncorrect(errorString));
    }

    public void onIncinerate()
    {
        numMissed++;
        updateStatsScore();
    }

    IEnumerator showCorrect()
    {
        correctGameObject.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        correctGameObject.SetActive(false);
    }

    IEnumerator showIncorrect(string errorString)
    {
        incorrectGameObject.SetActive(true);
        errorText.text = errorString;
        errorText.gameObject.SetActive(true);
        yield return new WaitForSeconds(5.0f);
        incorrectGameObject.SetActive(false);
        errorText.gameObject.SetActive(false);
    }

    void resetState()
    {
        correctGameObject.SetActive(false);
        incorrectGameObject.SetActive(false);
        errorText.gameObject.SetActive(false);
        defaultImageGameObject.SetActive(true);
    }


    void updateStatsScore()
    {
        float speed = conveyorBelt.GetComponent<ConveyorBelt>().maxSpeed;
        string stats = "Speed: " + speed.ToString("F2") + "\n# Sorted: " + numSorted + "\n# Incorrect: " + numIncorrect + "\n# Missed: " + numMissed;
        statsText.text = stats;

        //score -= 1;
        scoreText.text = "Score: " + score;
    }
}
