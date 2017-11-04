﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldControllerScript : MonoBehaviour {

    public GameObject BasePrefab;

	// Use this for initialization
	void Start () {
        World world = new World(5, 5, 1);

        for (int i = 0; i < 2; i++) {
            var go = Instantiate(BasePrefab, new Vector3(5*i, 0, 5*i), Quaternion.identity);

            BaseControllerScript bcs = go.GetComponent<BaseControllerScript>();
            bcs.SetTileValues(5, 3, 4, 4);
            bcs._belongsTo = i;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}