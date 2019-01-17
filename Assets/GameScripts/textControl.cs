using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textControl : MonoBehaviour {

    List<string> question = new List<string> { "Hold The Keyboard Down", "Press Light Blue", "Press Dark Blue", "Press Purple", "Press Pink", "Press Red", "Press Orange", "Press Yellow", "Press Light Green", "Press Dark Green", "Press Grey", "Press Black"};

    public static int randQuestion = -1;

	// Use this for initialization
	void Start () {
        //GetComponent<TextMesh>().text = question[0];

	}

	// Update is called once per frame
	void Update () {

        if (randQuestion == -1) {
            randQuestion = Random.Range(0,11);
        }
        if (randQuestion > -1){
            GetComponent<TextMesh>().text = question[randQuestion];
        }



        Debug.Log (question [randQuestion]);

	}
}
