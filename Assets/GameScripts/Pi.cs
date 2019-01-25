using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pi : MonoBehaviour {

	// List<string> pink = new List<string>() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11" };


	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		// if (textControl.randQuestion > -1){
		// 	GetComponent<TextMesh>().text = pink[textControl.randQuestion];
		// }

	}

	void OnTriggerEnter() {
		// Debug.Log (gameObject.name);

		if (textControl.randQuestion == 0) {

		}
		if (textControl.randQuestion > 0) {

			textControl.selectedAnswer = gameObject.name;
			textControl.choiceSelected = "y";
			// textControl.randQuestion = 0;

		}
	}


}
