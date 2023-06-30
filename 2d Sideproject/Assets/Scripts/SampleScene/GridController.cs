using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    public GameObject points;
    public List<bool> pointsList;

    public float size;
    public int gridWidth;
    public int gridHeight;

    private int[][] grid;
    void Start()
    {
        grid = new int[gridHeight][];
        for (int i = 0; i < grid.Length; i++)
        { 

            grid[i] = new int[gridWidth];

            int[] row = grid[i];
            for (int j = 0; j < row.Length; j++)
            {
                grid[i][j] = j;
                GameObject newPoint = Instantiate(points, new Vector3(j, i, 0) * size, Quaternion.identity);
                pointsList.Add(newPoint.GetComponent<PointController>().oneHot);
            }
        }

        for (int i = 0; i < gridHeight -1; i++)
        {
            for (int j = 0; j < gridWidth -1; j++)
            {
                float x = j * size;
                float y = i * size;
                Vector3 a = new Vector3(x + size * 0.5f, y, 0);
                Vector3 b = new Vector3(x + size, y + size * 0.5f , 0);
                Vector3 c = new Vector3(x + size * 0.5f, y + size, 0);
                Vector3 d = new Vector3(x, y + size * 0.5f, 0);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
