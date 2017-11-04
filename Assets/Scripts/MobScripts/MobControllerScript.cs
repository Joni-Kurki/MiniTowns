using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobControllerScript : MonoBehaviour {

    Mob mob; 

	// Use this for initialization
	void Start () {
        mob = new Mob(10, 2, 1);
	}
	
	// Update is called once per frame
	void Update () {
        // DMG TEST
        if (Input.GetKeyDown(KeyCode.F5)) {
            mob._hp -= mob._damage;
            Debug.Log("DMG -" + mob._damage + " HP " + mob._hp);
        }

        if (mob._hp <= 0) {
            Destroy(gameObject);
        }
	}
}
