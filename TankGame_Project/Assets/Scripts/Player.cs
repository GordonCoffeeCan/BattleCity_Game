using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float moveSpeed = 3;
	public Sprite[] tankSprites;
	public Bullet bullet;
	public Explosion explosionPrefab;
	public GameObject defendingEffect;
	public AudioClip[] tankAudio;

	private float timeVal = 0.4f;
	private bool isDefended;
	private float defendedTimeVal = 3;

	private float inputH = 0f;
	private float inputV = 0f;
	private Vector3 bulletRotation;

	private SpriteRenderer spriteRenderer;
	private AudioSource audioSource;

	private void Awake() {
		spriteRenderer = this.GetComponent<SpriteRenderer>();
		audioSource = this.GetComponent<AudioSource>();
    }

	// Use this for initialization
	void Start () {
		isDefended = true;
	}
	
	// Update is called once per frame
	void Update () {
        //Defended timer
        if (isDefended) {
			defendingEffect.gameObject.SetActive(true);
			defendedTimeVal -= Time.deltaTime;
			if(defendedTimeVal <= 0) {
				isDefended = false;
				defendingEffect.gameObject.SetActive(false);
			}
        }

		//Attack Timer;
		if (GameManager.Instance.isDefeated) {
			return;
		}
		if (timeVal <= 0) {
			Attack();
        } else {
			timeVal -= Time.deltaTime;
        }
	}

	private void FixedUpdate() {
        if (GameManager.Instance.isDefeated) {
			return;
        }
		Move();
	}

	//Controlling the tank movement and direction;
	private void Move() {
		inputH = Input.GetAxisRaw("Horizontal");
		inputV = Input.GetAxisRaw("Vertical");

		if (inputV != 0) {
			inputH = 0;
		}

		transform.Translate(new Vector3(inputH, inputV, 0) * moveSpeed * Time.fixedDeltaTime, Space.World);

		if(Mathf.Abs(inputH) > 0.05f || Mathf.Abs(inputV) > 0.05f) {
			audioSource.clip = tankAudio[1];
        } else {
			audioSource.clip = tankAudio[0];
		}

		if (!audioSource.isPlaying) {
			audioSource.Play();
		}

		SpriteRendering(inputH, inputV);
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
        if (Input.GetKeyDown(KeyCode.Space)) {
			timeVal = 0.4f;
			Bullet _bullet = Instantiate(bullet, this.transform.position + Vector3.forward, Quaternion.Euler(bulletRotation)) as Bullet;
			_bullet.isPlayerBullet = true;
			_bullet.moveSpeed = 10;
        }
    }

	private void Die() {
        if (isDefended) {
			return;
        }
		GameManager.Instance.isDead = true;
		Instantiate(explosionPrefab, this.transform.position, Quaternion.identity);
		Destroy(this.gameObject);
    }
}
