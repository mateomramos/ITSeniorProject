using UnityEngine;

public class ChessboardSC : MonoBehavior
{
    // LOGIC 
    private const TILE_COUNT_X = 8;
    private const TILE_COUNT_Y = 8;
    private GameObject[,] tiles;
    private void Awake();  
    GenerateAllTiles(1, 8, 8);
}

{
    private void GenerateAllTiles(float tileSize, int tileCountX, int tileCountY)
}
{
    tiles = new GameObject[tileCountX, tileCountY];
    for (int x = 0; x < tileCountX; x++)
    for (int y = 0; y < tileCountY; y++)
        tile[x,y] = GenerateSingleTile(tileSize, x, y);
    {
        
}
    private GameObject GenerateSingleTile(float tilesize, int x, int y)
{
    GameObject tileObject = new GameObject(string.Format("X:{0}, Y:{1}", x, y));
    tileObject.transform.parent = transform;

    return tileObject;
}