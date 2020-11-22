using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	//Values
	public float moveSpeed = 3;
	private float enemyH = 0f;
	private float enemyV = 0f;
	private Vector3 bulletRotation;

	//References
	private SpriteRenderer spriteRenderer;
	public Sprite[] tankSprites;
	public Bullet bullet;
	public Explosion explosionPrefab;

	//Timers
	private float timeVal = 3f;
	private float directionTimeVal = 4;

	private void Awake() {
		spriteRenderer = this.GetComponent<SpriteRenderer>();
	}

	// Use this for initialization
	void Start() {

	}

	// Update is called once per frame
	void Update() {

		//Attack Timer;
		if (timeVal <= 0) {
			Attack();
		} else {
			timeVal -= Time.deltaTime;
		}
	}

	private void FixedUpdate() {
		Move();
	}

	//Controlling the tank movement and direction;
	private void Move() {

		if(directionTimeVal >= 4) {
			int _num = Random.Range(0, 8);
			if(_num >= 5) {
				enemyH = 0;
				enemyV = -1;
            } else if(_num == 0) {
				enemyH = 0;
				enemyV = 1;
            }else if(_num > 0 && _num <= 2) {
				enemyH = -1;
				enemyV = 0;
            }else if(_num > 2 && _num <= 4) {
				enemyH = 1;
				enemyV = 0;
            }
			directionTimeVal = 0;
        } else {
			directionTimeVal += Time.fixedDeltaTime;
        }

		transform.Translate(new Vector3(enemyH, enemyV, 0) * moveSpeed * Time.fixedDeltaTime, Space.World);

		SpriteRendering(enemyH, enemyV);
	}

	//Rendering the tank graphics and direction;
	private void SpriteRendering(float _h, float _v) {
		if (tankSprites.Length > 0) {
			if (_h < 0) {
				spriteRenderer.sprite = tankSprites[3];
				bulletRotation = new Vector3(0, 0, 90);
			} else if (_h > 0) {
				spriteRenderer.sprite = tankSprites[1];
				bulletRotation = new Vector3(0, 0, -90);
			}
			if (_v < 0) {
				spriteRenderer.sprite = tankSprites[2];
				bulletRotation = new Vector3(0, 0, 180);
			} else if (_v > 0) {
				spriteRenderer.sprite = tankSprites[0];
				bulletRotation = new Vector3(0, 0, 0);
			}
		} else {
			Debug.LogError("No Sprites reference assigned to the object");
		}
	}

	private void Attack() {
		timeVal = 3f;
		Bullet _bullet = Instantiate(bullet, this.transform.position + Vector3.forward, Quaternion.Euler(bulletRotation)) as Bullet;
		_bullet.isPlayerBullet = false;
		_bullet.moveSpeed = 10;
	}

	private void Die() {
		GameManager.Instance.playerScore++;
		Instantiate(explosionPrefab, this.transform.position, Quaternion.identity);
		Destroy(this.gameObject);
	}

	private void OnCollisionEnter2D(Collision2D _col) {
		if(_col.gameObject.tag == "Enemy") {
			directionTimeVal = 4f;
        }
    }
}
