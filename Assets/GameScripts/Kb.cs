using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kb : MonoBehaviour {

	// List<string> keyboard = new List<string>() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11" };
	public static float holdTimer = 0;
	public bool stay = true;
	public bool fired = false;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		// if (textControl.randQuestion > -1){
		// 	GetComponent<TextMesh>().text = keyboard[textControl.randQuestion];
		// }


	}
	// Checks that its hand collision, sets timer for holding as kb pushed
	void OnCollisionEnter(Collision other) {
		// Debug.Log (gameObject.name);

		if (other.gameObject.name == "PalmL" || other.gameObject.name == "ThumbTipL" || other.gameObject.name == "IndexTipL" || other.gameObject.name == "MiddleTipL" || other.gameObject.name == "PalmR" || other.gameObject.name == "ThumbTipR" || other.gameObject.name == "IndexTipR" || other.gameObject.name == "MiddleTipR"  ) {
			if (textControl.randQuestion == 0) {
				textControl.selectedAnswer = gameObject.name;
				// textControl.choiceSelected = "y";

				holdTimer = Random.Range(1,5);
				fired = false;

			}
			if (textControl.sceneName == "test0") {
				holdTimer = Random.Range(1,4);
			}
		}

	}

	// counts down the hold, then fires next question
	void OnCollisionStay(Collision collisionInfo) {

		if (collisionInfo.gameObject.name == "PalmL" || collisionInfo.gameObject.name == "ThumbTipL" || collisionInfo.gameObject.name == "IndexTipL" || collisionInfo.gameObject.name == "MiddleTipL" || collisionInfo.gameObject.name == "PalmR" || collisionInfo.gameObject.name == "ThumbTipR" || collisionInfo.gameObject.name == "IndexTipR" || collisionInfo.gameObject.name == "MiddleTipR" ) {
			if (stay){
				if (fired == false){
					holdTimer -= Time.deltaTime;
					// Debug.Log(holdTimer);
					if(holdTimer < 0){
						// Debug.Log ("fire");
						textControl.randQuestion = -1;
						fired = true;

					}
				}
			}
		}
	}
}
