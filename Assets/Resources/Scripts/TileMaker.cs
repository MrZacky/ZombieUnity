using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class TileMaker : NetworkBehaviour {

    private int mapSizeX = 5;
    private int mapSizeY = 5;

    private GameObject tilePrefab;
    private float tileSizeX = 0.8f;
    private float tileSizeY = 0.4f;
    private GameObject playerBasePrefab;
    private float playerBaseSizeY = 0.6f;
    private GameObject lumberMill;
    private float lumberMillSizeY = 0.6f;
    private GameObject stonePit;
    private float stonePitSizeY = 0.6f;
    // private int bigTileAmout = 4; //4 x 25

    public override void OnStartServer()
    {
        tilePrefab = Resources.Load("Prefabs/tile") as GameObject;
        playerBasePrefab = Resources.Load("Prefabs/playerBase") as GameObject;
        lumberMill = Resources.Load("Prefabs/lumberMill") as GameObject;
        stonePit = Resources.Load("Prefabs/stonePit") as GameObject;

        SpawnBigTileAtPos(tilePrefab, Vector3.zero);
        SpawnBaseAtPos(playerBasePrefab, new Vector3(0, -tileSizeY * 4 + playerBaseSizeY, 0));
        SpawnLumberMillAtPos(lumberMill, new Vector3(0, -tileSizeY * 6 + lumberMillSizeY, 0));
        SpawnStonePitAtPos(stonePit, new Vector3(tileSizeX * 3, -tileSizeY * 5 + stonePitSizeY, 0));
        Debug.Log("Wystartowałem serwer, stworzyłem obiekty.");
    }

    /*public void SpawnBigTileNTimes(GameObject tile, Vector3 pos, int N)
    {
        for (int i = 0; i < N - N/2; i++)
        {
            for (int j = 0; j < N / 2; j++)
            {
                SpawnBigTileAtPos(tile, new Vector3(pos.x + tileSizeX * 5 * j, pos.y - tileSizeY * 5 * i, pos.z));
            }
        }
    }*/

    // pos - up-left tile position (generating to right and then down)
    public void SpawnBigTileAtPos(GameObject tile, Vector3 pos)
    {
      for (int i = 0; i <= mapSizeY; i++)
       {
            for (int j = 0; j <= mapSizeX; j++)
            {
                SpawnTileAtPos(tile, new Vector3(pos.x + tileSizeX * j, pos.y - tileSizeY * j, pos.z), i*5+j);
            }
           pos.x -= tileSizeX;
           pos.y -= tileSizeY;
       }
    }

    public void SpawnBaseAtPos(GameObject prefab, Vector3 pos)
    {
        var playerBaseI = (GameObject)Instantiate(prefab, pos, Quaternion.identity);
        NetworkServer.Spawn(playerBaseI);
    }
    public void SpawnLumberMillAtPos(GameObject prefab, Vector3 pos)
    {
        var playerBaseI = (GameObject)Instantiate(prefab, pos, Quaternion.identity);
        NetworkServer.Spawn(playerBaseI);
    }
    public void SpawnStonePitAtPos(GameObject prefab, Vector3 pos)
    {
        var playerBaseI = (GameObject)Instantiate(prefab, pos, Quaternion.identity);
        NetworkServer.Spawn(playerBaseI);
    }

    public void SpawnTileAtPos(GameObject prefab, Vector3 pos, int sortingOrder)
    {
        var tileI = (GameObject)Instantiate(prefab, pos, Quaternion.identity);
        tileI.GetComponent<SpriteRenderer>().sortingOrder = sortingOrder;
        NetworkServer.Spawn(tileI);
    }
}
