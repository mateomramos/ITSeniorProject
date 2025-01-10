using System;
using UnityEngine;

public class Chessboard : MonoBehaviour
{

    [Header("Art stuff")]
    [SerializeField] private Material tileMaterial;

    // LOGIC 
    private const int TILE_COUNT_X = 8;
    private const int TILE_COUNT_Y = 8;
    private GameObject[,] tiles;

    private void Awake() {
        GenerateAllTiles(1, TILE_COUNT_X, TILE_COUNT_Y);
    }

    private void GenerateAllTiles(float tileSize, int tileCountX, int tileCountY)
    {
        tiles = new GameObject[tileCountX, tileCountY];

        for (int x = 0; x < tileCountX; x++) {
            for (int y = 0; y < tileCountY; y++) {
                tiles[x, y] = GenerateSingleTile(tileSize, x, y);
            }
        }
    }
    private GameObject GenerateSingleTile(float tilesize, int x, int y)
    {
        GameObject tileObject = new GameObject(string.Format("X:{0}, Y:{1}", x, y));
        tileObject.transform.parent = transform;

        Mesh mesh = new Mesh();
        tileObject.AddComponent<MeshFilter>().mesh = mesh;
        tileObject.AddComponent<MeshRenderer>().material = tileMaterial;

        Vector3[] vertices = new Vector3[4];
        vertices[0] = new Vector3(x * tilesize, 0, y * tilesize);
        vertices[1] =new Vector3(x * tilesize, 0 , (y+1) * tilesize);
        vertices[2] = new Vector3((x + 1) * tilesize, 0, y * tilesize);
        vertices[3] = new Vector3((x + 1) * tilesize, 0, (y + 1) * tilesize);

        int[] tris = new int[] { 0, 1, 2, 1, 3, 2 };

        mesh.vertices = vertices;
        mesh.triangles = tris;

        tileObject.AddComponent<BoxCollider>();

        return tileObject;
    }
}