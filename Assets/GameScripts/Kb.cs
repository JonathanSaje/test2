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

	void OnCollisionEnter(Collision other) {
		// Debug.Log (gameObject.name);

		if (other.gameObject.name == "Palm" || other.gameObject.name == "ThumbTip" || other.gameObject.name == "IndexTip" || other.gameObject.name == "MiddleTip" ) {
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


	void OnCollisionStay(Collision collisionInfo) {

		if (collisionInfo.gameObject.name == "Palm" || collisionInfo.gameObject.name == "ThumbTip" || collisionInfo.gameObject.name == "IndexTip" || collisionInfo.gameObject.name == "MiddleTip" ) {
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
