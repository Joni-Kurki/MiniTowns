using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseControllerScript : MonoBehaviour {

    BaseTiles _baseTiles;
    public Vector3 BasePosition;

    bool _initValuesSet;

    public GameObject[] TilePrefabs;

    private void Awake() {
        transform.position = BasePosition;
        _initValuesSet = false;
    }

    // Use this for initialization
    void Start () {

    }
	
    public void SetTileValues(int prod, int off, int def, int storage) {
        if (!_initValuesSet) {
            _baseTiles = new BaseTiles(prod, off, def, storage);

            for (int i = 0; i < _baseTiles._baseTileList.Count; i++) {
                InstantiateFromTile(_baseTiles._baseTileList[i]);
            }

            _initValuesSet = true;
        }
    }

	// Update is called once per frame
	void Update () {
		
	}

    void InstantiateFromTile(Tile t) {
        Vector3 tilePos = new Vector3(t._x, 0, t._y)+transform.position;
        var go = Instantiate(TilePrefabs[(int)t._tileType], tilePos, TilePrefabs[(int)t._tileType].transform.rotation, transform);
        BaseControllerScript bcs = go.GetComponent<BaseControllerScript>();
    }

}
