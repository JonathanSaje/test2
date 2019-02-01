using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LB : MonoBehaviour {

	void Start () {
	}

	// Update is called once per frame
	void Update () {
	}

	 // Makes sure that the collision is with a hand, then sets quantative data we need
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
				}
			}
		}
}
