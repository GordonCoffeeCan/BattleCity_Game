using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	[HideInInspector]
	public float moveSpeed = 0;

	[HideInInspector]
	public bool isPlayerBullet;

	public AudioClip bulletAudio;

	// Use this for initialization
	void Start () {
        if (isPlayerBullet) {
			AudioSource.PlayClipAtPoint(bulletAudio, this.transform.position);
        }
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Translate(Vector3.up * moveSpeed * Time.deltaTime, Space.Self);
	}

	private void OnTriggerEnter2D(Collider2D _col) {
        switch (_col.tag) {
			case "Tank":
                if (!isPlayerBullet) {
					_col.SendMessage("Die");
					Destroy(this.gameObject);
				}
				break;
			case "Heart":
				_col.SendMessage("Die");
				Destroy(this.gameObject);
				break;
			case "Enemy":
                if (isPlayerBullet) {
					_col.SendMessage("Die");
					Destroy(this.gameObject);
				}
				break;
			case "Wall":
				Destroy(_col.gameObject);
				Destroy(this.gameObject);
				break;
			case "Barrier":
				_col.SendMessage("PlayAudio");
				Destroy(this.gameObject);
				break;
            default:
				break;
		}
		
	}
}
