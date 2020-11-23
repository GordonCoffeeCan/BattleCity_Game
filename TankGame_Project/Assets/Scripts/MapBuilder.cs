using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBuilder : MonoBehaviour {

	//Game assets array for holding object showing on the map;
	public GameObject[] mapItems;

	public GameObject[] envPivots;

	//Store position where already has game assets;
	//private List<Vector3> fixedPositionList = new List<Vector3>();

	private void Awake() {
		//InitMap();

		envPivots = GameObject.FindGameObjectsWithTag("EnvPivots");

		InitMap();
	}

	private void InitMap() {
        //Spon the player
        //Born born = Instantiate(mapItems[3].GetComponent<Born>(), new Vector3(-2, -8, 0), Quaternion.identity);
        //fixedPositionList.Add(new Vector3(-2, -8, 0));
        //born.createPlayer = true;

        ////Spon the Enemy
        //CreateItems(mapItems[3], new Vector3(-10, 8, 0), Quaternion.identity);
        //CreateItems(mapItems[3], new Vector3(0, 8, 0), Quaternion.identity);
        //CreateItems(mapItems[3], new Vector3(10, 8, 0), Quaternion.identity);
        //InvokeRepeating("CreateEnemy", 4f, 5f);

        ////Make home
        //CreateItems(mapItems[0], new Vector3(0, -8, 0), Quaternion.identity);
        //CreateItems(mapItems[1], new Vector3(0, -7, 0), Quaternion.identity);
        //CreateItems(mapItems[1], new Vector3(-1, -8, 0), Quaternion.identity);
        //CreateItems(mapItems[1], new Vector3(1, -8, 0), Quaternion.identity);

        //for (int i = -1; i < 2; i++) {
        //	CreateItems(mapItems[1], new Vector3(i, -7, 0), Quaternion.identity);
        //}

        ////outter range barrier
        //for (int i = -11; i < 12; i++) {
        //	CreateItems(mapItems[6], new Vector3(i, 9, 0), Quaternion.identity);
        //	CreateItems(mapItems[6], new Vector3(i, -9, 0), Quaternion.identity);
        //}
        //for (int i = -8; i < 9; i++) {
        //	CreateItems(mapItems[6], new Vector3(-11, i, 0), Quaternion.identity);
        //	CreateItems(mapItems[6], new Vector3(11, i, 0), Quaternion.identity);
        //}

        ////Random Create the Map
        //for (int i = 0; i < 60; i++) {
        //	CreateItems(mapItems[1], CreateRandomPosition(), Quaternion.identity);
        //}

        //for (int i = 0; i < 20; i++) {
        //	CreateItems(mapItems[2], CreateRandomPosition(), Quaternion.identity);
        //	CreateItems(mapItems[4], CreateRandomPosition(), Quaternion.identity);
        //	CreateItems(mapItems[5], CreateRandomPosition(), Quaternion.identity);
        //}

		for (int i = 0; i < envPivots.Length; i++) {
			int _num = Random.Range(0, 2);
			if (_num == 0) {
				continue;
			} else {
				CreateItems(mapItems[0], envPivots[i].transform.position, Quaternion.identity);
			}
		}

        foreach (var i in envPivots) {
			if(i.transform.parent != null) {
				Destroy(i.transform.parent.gameObject);
			}
        }
	}

	private void CreateItems(GameObject _go, Vector3 _pos, Quaternion _rot) {
		GameObject _itemGO = Instantiate(_go, _pos, _rot, this.transform);
		//fixedPositionList.Add(_pos);
    }

	//Random Position
	private Vector3 CreateRandomPosition() {
        //should not have map object at x = -10, 10, y = -8, 8
        while (true) {
			//Vector3 createPosion = new Vector3(Random.Range(-9, 10), Random.Range(-7, 8), 0);
   //         if (!HasThePosition(createPosion)) {
			//	return createPosion;
			//}
        }
    }

	//compaire the new position to make sure not same as excisting position
	//private bool HasThePosition(Vector3 _pos) {
 //       for (int i = 0; i < fixedPositionList.Count; i++) {
	//		if(_pos == fixedPositionList[i]) {
	//			return true;
 //           }
 //       }
	//	return false;
 //   }

	//Random Create Enemey
	private void CreateEnemy() {
		int _num = Random.Range(0, 3);
		Vector3 _enemyPos = new Vector3();
		switch (_num) {
			case 0:
				_enemyPos = new Vector3(-10, 8, 0);
				break;
			case 1:
				_enemyPos = new Vector3(0, 8, 0);
				break;
			case 2:
				_enemyPos = new Vector3(10, 8, 0);
				break;
        }
		CreateItems(mapItems[3], _enemyPos, Quaternion.identity);
    }
}
