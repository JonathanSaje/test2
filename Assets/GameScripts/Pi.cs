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

	void OnCollisionEnter(Collision other) {
		// Debug.Log (gameObject.name);

			// foreach (ContactPoint contact in other.contacts){
			// 	Debug.Log(contact.point);
			// 	Debug.Log("Hit");
			// 	Debug.Log(other.gameObject.name);
			// }

			if (textControl.randQuestion == 0) {

			}
			if (textControl.randQuestion > 0) {
				if (other.gameObject.name == "Palm" || other.gameObject.name == "ThumbTip" || other.gameObject.name == "IndexTip" || other.gameObject.name == "MiddleTip" ) {
					ContactPoint contact = other.contacts[0];
					Debug.DrawRay(contact.point, contact.normal, Color.white, 100, false);
					textControl.contact = other.contacts[0];
					textControl.selectedAnswer = gameObject.name;
					textControl.choiceSelected = "y";
				// textControl.randQuestion = 0;
				}
			// Debug.Log(contact.point);
			}
		}


}
