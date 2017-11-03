﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile  {

    public enum TileType {
        production = 0,
        offense = 1,
        defence = 2,
        storage = 3
    }

    public int _x { get; set; }
    public int _y { get; set; }
    public bool _isTileEmpty;
    public TileType _tileType;
    

    public Tile(int x, int y, TileType tileType) {
        this._x = x;
        this._y = y;
        _isTileEmpty = false;
        _tileType = tileType;
    }
}

public class BaseTiles {
    const int MAX_TILE_COUNT = 16;
    public List<Tile> _baseTileList;
    /// <summary>
    /// 
    /// </summary>
    public int[] _numberOfTiles;

    public BaseTiles(int prod, int off, int def, int storage) {
        _baseTileList = new List<Tile>();
        _numberOfTiles = new int[MAX_TILE_COUNT];
        InitBaseTiles(prod, off, def, storage);
    }

    protected void InitBaseTiles(int prod, int off, int def, int storage) {
        int x = 0;
        int y = 0;

        for(int i=0; i<prod; i++) {
            Tile t = new Tile(x, y, Tile.TileType.production);
            x++;
            if (x >= 4) {
                y++;
                x = 0;
            }
            _baseTileList.Add(t);
        }
        for (int i = 0; i < off; i++) {
            Tile t = new Tile(x, y, Tile.TileType.offense);
            x++;
            if(x >= 4) {
                y++;
                x = 0;
            }
            _baseTileList.Add(t);
        }
        for (int i = 0; i < def; i++) {
            Tile t = new Tile(x, y, Tile.TileType.defence);
            x++;
            if (x >= 4) {
                y++;
                x = 0;
            }
            _baseTileList.Add(t);
        }
        for (int i = 0; i < storage; i++) {
            Tile t = new Tile(x, y, Tile.TileType.storage);
            x++;
            if (x >= 4) {
                y++;
                x = 0;
            }
            _baseTileList.Add(t);
        }

        for(int i=0; i<_baseTileList.Count; i++) {
            Tile t = _baseTileList[i];
            //Debug.Log("[" + t._x + " | " + t._y + "] " + t._tileType);
        }
    }
}