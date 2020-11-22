using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Born : MonoBehaviour {

	public Player playerPrefab;
	public Enemy[] enemyPrefabs;

	public bool createPlayer = false;

	// Use this for initialization
	void Start () {
		Invoke("BornTank", 1f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void BornTank() {

        if (createPlayer) {
			Instantiate(playerPrefab, transform.position, Quaternion.identity);
        } else {
			int _num = Random.Range(0, 2);
			Instantiate(enemyPrefabs[_num], this.transform.position, Quaternion.identity);
        }

		
		Destroy(this.gameObject);
	}
}
