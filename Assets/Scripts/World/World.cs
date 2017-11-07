using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class World {

    int _sizeX;
    int _sizeY;
    float _tileSize;

    /// <summary>
    /// 0 = non buildable
    /// </summary>
    public enum WorldTile {
        ruined = 0,
        factory = 1,
        warFactory = 2,
        fort = 3,
        hideout = 4,
    }
    
    /// <summary>
    /// Contains map's tile data, what is in what tile.
    /// </summary>
    int[,] _mapTiles;

    const int MAP_TILE_CONTAINS_TILES = 16;

    public World(int x, int y, float tileSize) {
        _sizeX = x;
        _sizeY = y;
        _tileSize = tileSize;

        _mapTiles = new int [x,y];

        initWorldTiles();
    }

    // Converts int to enum
    WorldTile GetEnumFromInt(int value) {
        switch (value) {
            case 0:
                return WorldTile.ruined;
            case 1:
                return WorldTile.factory;
            case 2:
                return WorldTile.warFactory;
            case 3:
                return WorldTile.fort;
            case 4:
                return WorldTile.hideout;
            default:
                return WorldTile.ruined;
        }
    }

    // Return WorldTile as enum at desired location
    public WorldTile GetWorldTileAt(int x, int y) {
        return GetEnumFromInt(_mapTiles[x, y]);
    }

    // Init worldTiles @Random
    void initWorldTiles() {
        int numberOfDifferentWorldTiles = Enum.GetNames(typeof(WorldTile)).Length;

        for (int i = 0; i < _sizeX; i++) {
            for (int j = 0; j < _sizeY; j++) {
                _mapTiles[i, j] = UnityEngine.Random.Range(0, numberOfDifferentWorldTiles + 1);
                //Debug.Log("[" + i + "|" + j + "] " + GetEnumFromInt(_mapTiles[i, j]));
            }
        }
    }

    // Check if tile is buildable or not.
    public bool canBuildAt(int x, int y) {
        if (_mapTiles[x, y] == 0) {
            return false;
        }
        return true;
    }
}