﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cleanUp : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Destroy(gameObject, 1.5f);
	}
}
