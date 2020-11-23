using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTransition : MonoBehaviour {

	public Transform[] camPivots;
	public Transform[] playerPivots;
	private int[] romIndexs = {0, 1};

	private int tempA;
	private int tempB;

	private void Update() {
		
	}
	
	private void OnTriggerEnter2D(Collider2D _col) {
		if(_col.tag == "Tank") {
			tempA = romIndexs[0];
			tempB = romIndexs[1];
			GameManager.Instance.camNewPositon = camPivots[tempB].position;
			_col.transform.position = playerPivots[tempA].position;
			romIndexs[0] = tempB;
			romIndexs[1] = tempA;
			//Debug.Log("Camera trans from " + tempA + " to " + tempB);

		}
		
    }

	private void OnTriggerExit2D(Collider2D _col) {
		if (_col.tag == "Tank") {
			
		}	
	}
}
