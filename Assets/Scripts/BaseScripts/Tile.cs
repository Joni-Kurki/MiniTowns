using System.Collections;
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
    public int _tileIndex {get; set; }

    public Tile(int x, int y, TileType tileType, int index) {
        this._x = x;
        this._y = y;
        _isTileEmpty = false;
        _tileType = tileType;
        _tileIndex = index;
    }
}

public class BaseTiles {
    // How many tiles base can have.
    const int MAX_TILE_COUNT = 16;
    // List of tiles the base has.
    public List<Tile> _baseTileList;
    /// <summary>
    /// 
    /// </summary>
    public int[] _numberOfTiles;

    public BaseTiles(int prod, int off, int def, int storage) {
        _baseTileList = new List<Tile>();
        InitBaseTiles(prod, off, def, storage);
    }

    /// <summary>
    /// Inits base's tiles to desired set of tiles.
    /// </summary>
    /// <param name="prod"></param>
    /// <param name="off"></param>
    /// <param name="def"></param>
    /// <param name="storage"></param>
    protected void InitBaseTiles(int prod, int off, int def, int storage) {
        int x = 0;
        int y = 0;
        int index = 0;

        for(int i=0; i<prod; i++) {
            Tile t = new Tile(x, y, Tile.TileType.production, index);
            x++;
            if (x >= 4) {
                y++;
                x = 0;
            }
            _baseTileList.Add(t);
            index++; 
        }
        for (int i = 0; i < off; i++) {
            Tile t = new Tile(x, y, Tile.TileType.offense, index);
            x++;
            if(x >= 4) {
                y++;
                x = 0;
            }
            _baseTileList.Add(t);
            index++;
        }
        for (int i = 0; i < def; i++) {
            Tile t = new Tile(x, y, Tile.TileType.defence, index);
            x++;
            if (x >= 4) {
                y++;
                x = 0;
            }
            _baseTileList.Add(t);
            index++;
        }
        for (int i = 0; i < storage; i++) {
            Tile t = new Tile(x, y, Tile.TileType.storage, index);
            x++;
            if (x >= 4) {
                y++;
                x = 0;
            }
            _baseTileList.Add(t);
            index++;
        }

        for(int i=0; i<_baseTileList.Count; i++) {
            Tile t = _baseTileList[i];
            //Debug.Log("[" + t._x + " | " + t._y + "] " + t._tileType);
        }
    }
}
