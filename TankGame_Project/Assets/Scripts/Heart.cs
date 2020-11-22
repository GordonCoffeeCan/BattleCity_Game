using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour {

	[SerializeField]
	private Sprite brokenSprite;

	private SpriteRenderer spriteRenderer;

	public Explosion explosionPrefab;

	public AudioClip dieAudio;

	private void Awake() {
		spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void Die() {
		spriteRenderer.sprite = brokenSprite;
		Instantiate(explosionPrefab, this.transform.position - Vector3.forward, Quaternion.identity);
		GameManager.Instance.isDefeated = true;
		AudioSource.PlayClipAtPoint(dieAudio, transform.position);
    }
}
