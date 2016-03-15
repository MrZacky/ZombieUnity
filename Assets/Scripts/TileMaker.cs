using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class TileMaker : NetworkBehaviour {

    public GameObject tilePrefab;
    public int bigTileAmout = 4; //4 x 25
    public float tileSizeX = 0.8f;
    public float tileSizeY = 0.4f;

    public override void OnStartServer()
    {
        //Vector3 startPosition = new Vector3(-((bigTileAmout / 4) * tileSizeX * 5), (bigTileAmout / 4) * tileSizeY * 5, 0);
        //SpawnBigTileNTimes(tilePrefab, startPosition, bigTileAmout);
        SpawnBigTile(tilePrefab, Vector3.zero);
    }

    public void SpawnBigTileNTimes(GameObject tile, Vector3 pos, int N)
    {
        for (int i = 0; i < N - N/2; i++)
        {
            for (int j = 0; j < N / 2; j++)
            {
                SpawnBigTile(tile, new Vector3(pos.x + tileSizeX * 5 * j, pos.y - tileSizeY * 5 * i, pos.z));
            }
        }
    }

    // pos - up-left tile position (generating to right and then down)
    public void SpawnBigTile(GameObject tile, Vector3 pos)
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                SpawnTileAtPos(tile, new Vector3(pos.x + tileSizeX * j, pos.y - tileSizeY * j, pos.z));
            }
            pos.x -= tileSizeX;
            pos.y -= tileSizeY;
        }
    }

    public void SpawnTileAtPos(GameObject tile, Vector3 pos)
    {
        var tileI = (GameObject)Instantiate(tile, pos, Quaternion.identity);
        NetworkServer.Spawn(tileI);
    }
}
