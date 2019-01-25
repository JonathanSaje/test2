using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class textControl : MonoBehaviour {

    List<string> question = new List<string>() { "Hold The Keyboard Down", "Press Light Blue", "Press Dark Blue", "Press Purple", "Press Pink", "Press Red", "Press Orange", "Press Yellow", "Press Light Green", "Press Dark Green", "Press Grey", "Press Black", "Task Complete! Please take off your Headset"};

    List<string> correctAnswer = new List<string>() {"Kb", "LB", "DB", "Pu", "Pi", "R", "O", "Y", "LG", "DG", "G", "Bl" };

    public static string selectedAnswer;

    public static string choiceSelected = "n";

    public static float timeTaken = 0;

    public static int randQuestion = 0;

    public static float timeLeft = 120.0f;

    public static string sceneName;


	// Use this for initialization
	void Start () {
        //GetComponent<TextMesh>().text = question[0];
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        Debug.Log(sceneName);

        if (sceneName == "test0") {
            timeLeft = 30.0f;
        }

	}

	// Update is called once per frame
	void Update () {

        timeLeft -= Time.deltaTime;

        if (timeLeft < 0) {
            GetComponent<TextMesh>().text = question[12];
        }
        else {
            if (randQuestion == 0) {
                GetComponent<TextMesh>().text = question[randQuestion];
            }

            if (randQuestion == -1) {
                if (sceneName == "test0") {
                    randQuestion = Random.Range(1,4);
                }
                if (sceneName == "test1" || sceneName == "test4") {
                    randQuestion = Random.Range(1,12);
                }
                if (sceneName == "test2") {
                    randQuestion = Random.Range(1,5);
                }
                if (sceneName == "test3") {
                    randQuestion = Random.Range(1,8);
                }

            }
            if (randQuestion > -1){
                GetComponent<TextMesh>().text = question[randQuestion];

                timeTaken += Time.deltaTime;

            }
            if (choiceSelected == "y") {

                choiceSelected = "n";
                // Debug.Log(timeLeft);

                if (correctAnswer[randQuestion]==selectedAnswer) {
                    Debug.Log( "y,"+timeTaken+","+selectedAnswer+","+correctAnswer[randQuestion]);
                    timeTaken = 0;
                    textControl.randQuestion = 0;
                }else{
                    Debug.Log( "n,"+timeTaken+","+selectedAnswer+","+correctAnswer[randQuestion]);
                    timeTaken = 0;
                    textControl.randQuestion = 0;
                }

            }

        }






	}
}
