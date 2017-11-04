using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffenseStructureScript : MonoBehaviour {

    public GameObject mobprefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SpawnMob(Vector3 spawnLoc) {
        Vector3 offsetY = new Vector3(0, .5f, 0);
        Instantiate(mobprefab, transform.position + offsetY + spawnLoc, transform.rotation, transform);
    }
}
