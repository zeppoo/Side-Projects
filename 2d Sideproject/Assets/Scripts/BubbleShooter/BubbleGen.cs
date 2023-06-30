using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleGen : MonoBehaviour
{
    [SerializeField]
    private float cellSize;
    [SerializeField]
    private int columns;
    [SerializeField]
    private int rows;
    private int[,] bubbles;
    private Vector3 offSet;

    // Start is called before the first frame update
    void Start()
    {
        bubbles = new int[columns, rows];
        GenerateBubbles();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GenerateBubbles()
    {
        System.Random rng = new System.Random();

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                bubbles[i, j] = rng.Next(0, 4);
            }
        }
    }

    void OnDrawGizmos()
    {
        if (bubbles != null)
        {
            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    if (bubbles[i, j] == 0)
                    {
                        Gizmos.color = Color.red;
                    }
                    else if (bubbles[i, j] == 1)
                    {
                        Gizmos.color = Color.green;
                    }
                    else if (bubbles[i, j] == 2)
                    {
                        Gizmos.color = Color.blue;
                    }
                    else if (bubbles[i, j] == 3)
                    {
                        Gizmos.color = Color.yellow;
                    }
                    else if (bubbles[i, j] == 4)
                    {
                        Gizmos.color = Color.black;
                    }
                    offSet = j % 2 == 1 ? new Vector3(1, 0, 0) * cellSize * .5f: Vector3.zero;
                    Vector2 gizPos = new Vector2(i , j);
                    Gizmos.DrawCube(gizPos, new Vector3(cellSize, cellSize, cellSize));
                }
            }
        }
    }
}
