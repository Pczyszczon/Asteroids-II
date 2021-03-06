﻿using UnityEngine;
using System.Collections;

public class CameraControler: MonoBehaviour {

	public GameObject player;

	private Vector3 offset;        

	void Start (){
		offset = transform.position - player.transform.position;
	}

	void Update (){
		if(player!=null)
			transform.position = player.transform.position + offset;
	}
}