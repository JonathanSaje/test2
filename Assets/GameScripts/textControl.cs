using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textControl : MonoBehaviour {

    List<string> question = new List<string>() { "Hold The Keyboard Down", "Press Light Blue", "Press Dark Blue", "Press Purple", "Press Pink", "Press Red", "Press Orange", "Press Yellow", "Press Light Green", "Press Dark Green", "Press Grey", "Press Black"};

    List<string> correctAnswer = new List<string>() {"Kb", "LB", "DB", "Pu", "Pi", "R", "O", "Y", "LG", "DG", "G", "Bl" };

    public static string selectedAnswer;

    public static string choiceSelected = "n";

    public static float timeTaken = 0;

    public static int randQuestion = 0;

	// Use this for initialization
	void Start () {
        //GetComponent<TextMesh>().text = question[0];

	}

	// Update is called once per frame
	void Update () {



        if (randQuestion == 0) {
            GetComponent<TextMesh>().text = question[randQuestion];
        }

        if (randQuestion == -1) {
            randQuestion = Random.Range(1,12);
        }
        if (randQuestion > -1){
            GetComponent<TextMesh>().text = question[randQuestion];

            timeTaken += Time.deltaTime;

        }
        if (choiceSelected == "y") {

            choiceSelected = "n";

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
