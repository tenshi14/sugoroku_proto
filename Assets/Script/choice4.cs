﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class choice4 : MonoBehaviour {
	
	private Text choice;
	
	// Use this for initialization
	void Start () {
		choice=GetComponent<Text>();

	}
	
	// Update is called once per frame
	void Update () {
		choice.text=Database.e;
	}
}
