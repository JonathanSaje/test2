using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LB : MonoBehaviour {

	void Start () {
		// Mesh mesh = GetComponent<MeshFilter>().mesh;
	   	// Vector3[] vertices = mesh.vertices;
	   	// Vector2[] uvs = new Vector2[vertices.Length];
		//
	   	// for (int i = 0; i < uvs.Length; i++)
	   	// {
		//    	uvs[i] = new Vector2(vertices[i].x, vertices[i].z);
	   	// }
	   	// mesh.uv = uvs;
		// Debug.Log(mesh.uv);
		Debug.Log(gameObject.name);
		Debug.Log(GetComponent<Collider>().bounds.size.ToString("F3"));
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



			// CHANGE FROM WORLDSPACE TO OBJECT (SHOULD BE EASY CONVERSION)



			if (textControl.randQuestion == 0) {

			}
			if (textControl.randQuestion > 0) {
				if (other.gameObject.name == "PalmL" || other.gameObject.name == "ThumbTipL" || other.gameObject.name == "IndexTipL" || other.gameObject.name == "MiddleTipL" || other.gameObject.name == "PalmR" || other.gameObject.name == "ThumbTipR" || other.gameObject.name == "IndexTipR" || other.gameObject.name == "MiddleTipR" ) {

					// RaycastHit hits;
					//
					ContactPoint contact = other.contacts[0];
					// Ray ray = new Ray(contact.point - contact.normal, contact.normal);
					// if(Physics.Raycast(ray, out hits)){
					// 	textControl.hit = hits;
					// 	Debug.Log(ray);
					// 	Debug.Log(hits.textureCoord);
					// }



					// Vector3 collisionPoint = contact.point;
					// Debug.Log(collisionPoint.ToString("F3"));
					// Vector3 localSpaceCollisionPoint = transform.InverseTransformPoint(collisionPoint);
					// Debug.Log(localSpaceCollisionPoint.ToString("F3"));

					string localSpace = transform.InverseTransformPoint(contact.point).ToString("F3");



					Debug.DrawRay(contact.point, contact.normal, Color.white, 100, false);
					textControl.localSpaceCollisionPoint = localSpace.Substring(1, localSpace.Length-2);
					textControl.buttonSize = GetComponent<Collider>().bounds.size.ToString("F3");
					textControl.contact = other.contacts[0];
					textControl.selectedAnswer = gameObject.name;
					textControl.choiceSelected = "y";
				}
			}
		}
}
