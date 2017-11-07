using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseControllerScript : MonoBehaviour {

    // MiniTownin tilet
    BaseTiles _baseTiles;

    public int _belongsTo;

    bool _initValuesSet;

    public GameObject[] TilePrefabs;

    private void Awake() {
        _initValuesSet = false;
    }

    // Use this for initialization
    void Start () {

    }
	
    public void SetPosition(Vector3 pos){
        transform.Translate(pos);
    }

    // Let's set and instantiate tiles
    public void SetTileValues(int prod, int off, int def, int storage) {
        if (!_initValuesSet) {
            _baseTiles = new BaseTiles(prod, off, def, storage);

            for (int i = 0; i < _baseTiles._baseTileList.Count; i++) {
                _baseTiles._baseTileList[i]._isTileEmpty = true;
                _baseTiles._baseTileList[0]._isTileEmpty = false;
                _baseTiles._baseTileList[3]._isTileEmpty = false;
                _baseTiles._baseTileList[5]._isTileEmpty = false;
                _baseTiles._baseTileList[8]._isTileEmpty = false;
                _baseTiles._baseTileList[11]._isTileEmpty = false;
                _baseTiles._baseTileList[14]._isTileEmpty = false;
                InstantiateFromTile(_baseTiles._baseTileList[i]);
            }
            _initValuesSet = true;
        }
        
    }

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.F1)) {
            ManuFactureMob();
        }
	}

    void ManuFactureMob() {
        // Etsi off building -> return off building
        // off building -> spawn mob @ location

        // -- FIND -- 
        // GET all child
        // Find 1st child of typ off
        // More Conditions later
        // return that

        GameObject[] childList = new GameObject[transform.childCount];
        for (int i = 0; i < childList.Length; i++) {
            childList[i] = transform.GetChild(i).gameObject;
        }
        int index = -1;
        for (int i = 0; i < childList.Length; i++) {
            if (childList[i].name.StartsWith("off")) {
                index = i;
                break;
            }
        }

        Vector3 spawnLoc = new Vector3(0, 0, 0);
        OffenseStructureScript oss = childList[index].GetComponent<OffenseStructureScript>();
        oss.SpawnMob(spawnLoc);
    }

    void InstantiateFromTile(Tile t) {
        if (!t._isTileEmpty) {
            Vector3 tilePos = new Vector3(t._x, 0, t._y) + transform.position;
            var go = Instantiate(TilePrefabs[(int)t._tileType], tilePos, TilePrefabs[(int)t._tileType].transform.rotation, transform);
        } else {
            Vector3 tilePos = new Vector3(t._x, 0, t._y) + transform.position;
            var go = Instantiate(TilePrefabs[4], tilePos, TilePrefabs[(int)t._tileType].transform.rotation, transform);
        }
    }
}
