using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

    public const int gridLength = 20;
    public const int gridCapacity = gridLength * gridLength * gridLength;

    private TestUnit testUnit;

    public GameObject cubePrefab;

    public GameObject[,,] goGrid = new GameObject[gridLength, gridLength, gridLength];
    public bool[,,] grid = new bool[gridLength, gridLength, gridLength];

    private void Awake()
    {

        for (int z = 0; z < gridLength; ++z)
        {
            for (int y = 0; y < gridLength; ++y)
            {
                for (int x = 0; x < gridLength; ++x)
                {
                    goGrid[z, y, x] = Instantiate(cubePrefab, new Vector3(x, y, z), Quaternion.identity);
                }
            }
        }
    }

    private void changeCubeColorAtIndex(int x, int y, int z)
    {
        goGrid[z, y, x].GetComponent<MeshRenderer>().material.color = Color.red;
    }

    private IEnumerator magic()
    {
        for (int z = 0; z < gridLength; ++z)
        {
            for (int y = 0; y < gridLength; ++y)
            {
                for (int x = 0; x < gridLength; ++x)
                {
                    changeCubeColorAtIndex(x, y, z);
                    yield return 0;
                }
            }
        }
    }

    private int countFront(int x, int y, int z)
    {
        int count = 0;
        count += this.grid[z - 1, y - 1, x - 1] ? 1 : 0;
        count += this.grid[z - 1, y - 1, x] ? 1 : 0;
        count += this.grid[z - 1, y - 1, x + 1] ? 1 : 0;
        count += this.grid[z - 1 , y, x - 1] ? 1 : 0;
        count += this.grid[z - 1, y, x] ? 1 : 0;
        count += this.grid[z - 1, y, x + 1] ? 1 : 0;
        count += this.grid[z - 1, y + 1, x - 1] ? 1 : 0;
        count += this.grid[z - 1, y + 1, x] ? 1 : 0;
        count += this.grid[z - 1, y + 1, x + 1] ? 1 : 0;
        return (count);
    }

    public int countNeighborsAtIndex(int x, int y, int z)
    {
        int count = 0;
        count += countFront(x, y, z);
        return (count);
    }

    // Use this for initialization
    void Start () {
        StartCoroutine(magic());
        this.testUnit = new TestUnit(this);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
