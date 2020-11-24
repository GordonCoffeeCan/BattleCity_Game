using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTransition : MonoBehaviour {

	private enum DirectionType {
		horizontalTrans,
		verticalTrans
    }

	[SerializeField] DirectionType directionType;

	public Transform[] camPivots;
	public Transform[] playerPivots;
	private int[] romIndexs = {0, 1};

	private Transform player;
	private int tempA;
	private int tempB;

	private void Start() {
		player = GameObject.FindGameObjectWithTag("Tank").transform;
	}

	private void Update() {

		if(directionType == DirectionType.horizontalTrans) {
			
            if ((this.transform.position.x - player.position.x) > 0) {
                this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180));
            } else if ((this.transform.position.x - player.position.x) < 0) {
                this.transform.rotation = Quaternion.Euler(Vector3.zero);
            }
        } else {

			if ((this.transform.position.y - player.position.y) > 0) {
				this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -90));
			} else if ((this.transform.position.y - player.position.y) < 0) {
				this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
			}
		}
	}
	
	private void OnTriggerEnter2D(Collider2D _col) {
		if(_col.tag == "Tank") {
			_col.transform.position = playerPivots[1].position;
			GameManager.Instance.camNewPositon = camPivots[1].position;
		}
    }
}
