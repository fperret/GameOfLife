using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TestUnit {

    private Game game;

    public TestUnit(Game game)
    {
        this.game = game;
        this.initGrid();
        runAllTests();
    }

    private void initGrid()
    {
        for (int z = 0; z < Game.gridLength; ++z)
        {
            for (int y = 0; y < Game.gridLength; ++y)
            {
                for (int x = 0; x < Game.gridLength; ++x)
                {
                    game.grid[z, y, x] = false;
                }
            }
        }
    }

    private bool centerNoNeighbor()
    {
        this.initGrid();
        if (this.game.countNeighborsAtIndex(5, 5, 5) != 0)
        {
            return (false);
        } else
        {
            return (true);
        }
    }

    private bool centerFullFrontNeighbor()
    {
        this.initGrid();
        for (int y = 4; y < 7; ++y)
        {
            for (int x = 4; x < 7; ++x)
            {
                this.game.grid[4, y, x] = true;
            }
        }
        this.game.grid[5, 5, 5] = true;
        if (this.game.countNeighborsAtIndex(5, 5, 5) != 9)
        {
            return (false);
        } else
        {
            return (true);
        }
    }

    private void runAllTests()
    {
        try
        {
            if (!this.centerNoNeighbor())
            {
                throw new System.Exception();
            }
            if (!this.centerFullFrontNeighbor())
            {
                throw new System.Exception();
            }
        } catch (System.Exception e)
        {
            UnityEditor.EditorApplication.isPlaying = false;
            Debug.Log("fjwefjwe");
        }

    }

}
