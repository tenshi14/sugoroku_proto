﻿using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	//Member

	public GameObject sugoroku;


	//Flags
	public bool moving;
	

	// Use this for initialization
	void Start () {
		sugoroku = GameObject.Find ("Sugoroku");
	}
	
	// Update is called once per frame
	void Update () {
		if (Sugoroku.nowPlayer == transform.GetSiblingIndex() ) {
			GetComponent<SpriteRenderer> ().sortingOrder = 10;
		} else {
			GetComponent<SpriteRenderer> ().sortingOrder = 0;
		}
	}

	void Move(int num) {
		moving = true;

		StartCoroutine ("coRoutineMove",num);
	}

	//コルーチン

	IEnumerator coRoutineMove(int num) {
		//GetComponent<Animator> ().enabled = true;
		for(int i = 0; i < num; i ++ ) {
			Vector3 nowGridPos = transform.position;
			Sugoroku.nowGrids[Sugoroku.nowPlayer] = (Sugoroku.nowGrids[Sugoroku.nowPlayer] + 1) % (Sugoroku.grids.Length -1 );
			Vector3 nextGridPos = Sugoroku.grids[Sugoroku.nowGrids[Sugoroku.nowPlayer]].transform.position;
			
			for (int j = 0; j <= 50; j++) {
				transform.position = Vector3.Lerp(nowGridPos,nextGridPos, (float)(0.02 * j) );
				yield return null;
			}

			for(int k = 0; k < 10; k++) yield return null;
		}

		this.moving = false;
		
		//GetComponent<Animator> ().enabled = false;

		// ここでイベント発生
		Debug.Log (this.name + " reach to " + Sugoroku.grids[Sugoroku.nowGrids[Sugoroku.nowPlayer]].name);
	

		Sugoroku.isToMoveQuestion = true;

	}
}
