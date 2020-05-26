using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tiles;
    public float ySpawn = 0;
    public float tileLength = 100;
    public int numberOfTiles = 2;
    public Transform playerTransform;
    private List<GameObject> activeTiles = new List<GameObject>();
    void Start()
    {
        for (int i = 0; i < numberOfTiles; i++)
        {
            if (i == 0)
            {
                SpawnTile(0);
            }
            else
            {
                SpawnTile(Random.Range(0, tiles.Length));
            }
        }
    }
    void Update()
    {
        if (playerTransform.position.y - 70 > ySpawn - (numberOfTiles * tileLength))
        {
            SpawnTile(Random.Range(0, tiles.Length));
            DeleteTile();
        }
    }
    public void SpawnTile (int tileIndex)
    {
        GameObject go = Instantiate(tiles[tileIndex], transform.up * ySpawn, transform.rotation);
        activeTiles.Add(go);
        ySpawn += tileLength;
    }

    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
