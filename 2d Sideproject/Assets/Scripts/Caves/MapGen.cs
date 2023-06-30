using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEditor;
using UnityEngine;

public class MapGen : MonoBehaviour
{
    public string seed;

    [Range(0,100)]
    public int mapFillPercent;
    public int[,] map;
    public int mapWidth;
    public int mapHeight;
    public int smoothCount;

    public bool useRandomSeed;

    public void GenerateMap()
    {
        map = new int[mapWidth, mapHeight];
        RandomFillMap();

        for (int i = 0; i < smoothCount; i++)
        {
            SmoothMap();
        }
    }

    void RandomFillMap()
    {
        if (useRandomSeed)
        {
            seed = Time.time.ToString();
        }

        System.Random prng = new System.Random(seed.GetHashCode());

        for (int x = 0; x < mapWidth; x++)
        {
            for (int y = 0; y < mapHeight; y++)
            {
                if (x == 0 || x == mapWidth - 1 || y == 0 || y == mapHeight - 1)
                {
                    map[x, y] = 1;
                }
                else
                {
                    map[x, y] = (prng.Next(0, 100) < mapFillPercent) ? 1 : 0;
                }
            }
        }
    }

    void SmoothMap()
    {
        for (int x = 0; x < mapWidth; x++)
        {
            for (int y = 0; y < mapHeight; y++)
            {
                int neighbourWallCount = GetSurroundingWallCount(x,y);

                if (neighbourWallCount > 4)
                {
                    map[x, y] = 1;
                }
                else if (neighbourWallCount < 4)
                {
                    map[x, y] = 0;
                }
            }
        }
    }

    int GetSurroundingWallCount(int x, int y)
    {
        int wallCount = 0;
        for (int neighbourX = x -1; neighbourX <= x + 1; neighbourX++)
        {
            for (int neighbourY = y - 1; neighbourY <= y + 1; neighbourY++)
            {
                if (neighbourX >= 0 && neighbourX < mapWidth && neighbourY >= 0 && neighbourY < mapHeight)
                {
                    if (neighbourX != x || neighbourY == y)
                    {
                        wallCount += map[neighbourX, neighbourY];
                    }
                }
                else
                {
                    wallCount++;
                }
            }
        }
        return wallCount;
    }

    private void OnDrawGizmos()
    {
        if (map != null)
        {
            for (int x = 0; x < mapWidth; x++)
            {
                for (int y = 0; y < mapHeight; y++)
                {
                    Gizmos.color = (map[x,y] == 1) ? Color.black : Color.white;
                    Vector2 gizPos = new Vector2(-mapWidth/2 + x + .5f, mapHeight/2 + y + .5f);
                    Gizmos.DrawCube(gizPos,Vector3.one);
                }
            }
        }
    }
}
