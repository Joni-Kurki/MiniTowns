using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class World {

    int _sizeX;
    int _sizeY;
    float _tileSize;

    /// <summary>
    /// tilessä;
    /// 0 = non buildable
    /// 1 = buildable   
    /// </summary>
    int[,] _mapTiles;

    const int MAP_TILE_CONTAINS_TILES = 16;

    public World(int x, int y, float tileSize) {
        _sizeX = x;
        _sizeY = y;
        _tileSize = tileSize;

        _mapTiles = new int [x,y];

        for (int i = 0; i < x; i++) {
            for (int j = 0; j < y; j++) {
                _mapTiles[i, j] = Random.Range(0, 2);
                Debug.Log("[" + i + "|" + j + "] " + _mapTiles[i, j]);
            }
        }
    }

    public bool canBuildAt(int x, int y) {
        if (_mapTiles[x, y] == 0) {
            return false;
        }
        return true;
    }
}