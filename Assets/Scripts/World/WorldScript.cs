using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldScript : MonoBehaviour {

    public GameObject BasePrefab;

	// Use this for initialization
	void Start () {
        var go = Instantiate(BasePrefab, new Vector3(5, 0, 5), Quaternion.identity);

        BaseControllerScript bcs = go.GetComponent<BaseControllerScript>();
        bcs.SetTileValues(5, 3, 4, 4);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
