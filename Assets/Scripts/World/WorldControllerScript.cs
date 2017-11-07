using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldControllerScript : MonoBehaviour {

    public GameObject BasePrefab;
    public GameObject[] WorldTilePrefabs;

    const int WORLD_SIZE_X = 5;
    const int WORLD_SIZE_Y = 5;
    const float WORLD_TILESIZE = 4;

    World world;

    // Use this for initialization
    void Start () {
        world = new World(WORLD_SIZE_X, WORLD_SIZE_Y, WORLD_TILESIZE);

        // TODO: Miks tarvii tän???
        Vector3 offset = new Vector3(-1.5f, 0, -1.5f);
        for (int i = 0; i < 2; i++) {
            

            var go = Instantiate(BasePrefab, new Vector3(WORLD_TILESIZE * i + offset.x, 0, WORLD_TILESIZE * i + offset.z), Quaternion.identity);

            BaseControllerScript bcs = go.GetComponent<BaseControllerScript>();
            bcs.SetTileValues(5, 3, 4, 4);
            bcs._belongsTo = i;
        }
        IntantiateGameWorld();
    }
	
    // Instantiates worldtiles
    void IntantiateGameWorld() {
        for(int x = 0; x< WORLD_SIZE_X; x++) {
            for (int y = 0; y < WORLD_SIZE_Y; y++) {

                Vector3 instantiatePosition = new Vector3(x * WORLD_TILESIZE, 0, y * WORLD_TILESIZE);

                switch (world.GetWorldTileAt(x, y)) {
                    case World.WorldTile.ruined:
                        Instantiate(WorldTilePrefabs[0], instantiatePosition, WorldTilePrefabs[0].transform.rotation, transform);
                        break;
                    case World.WorldTile.factory:
                        Instantiate(WorldTilePrefabs[1], instantiatePosition, WorldTilePrefabs[1].transform.rotation, transform);
                        break;
                    case World.WorldTile.warFactory:
                        Instantiate(WorldTilePrefabs[2], instantiatePosition, WorldTilePrefabs[2].transform.rotation, transform);
                        break;
                    case World.WorldTile.fort:
                        Instantiate(WorldTilePrefabs[3], instantiatePosition, WorldTilePrefabs[3].transform.rotation, transform);
                        break;
                    case World.WorldTile.hideout:
                        Instantiate(WorldTilePrefabs[4], instantiatePosition, WorldTilePrefabs[4].transform.rotation, transform);
                        break;
                }
            }
        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}
