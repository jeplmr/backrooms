using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maze : MonoBehaviour
{
    public int sizeX, sizeZ; 
    public MazeCell cellPrefab; 
    private MazeCell[,] cells; 

    public void Genrate(){
        cells = new MazeCell[sizeX, sizeZ]; 
        for(int x = 0; x < sizeZ; x++){
            for(int z = 0; z < sizeZ; z++){
                CreateCell(x, z); 
            }
        }
    }

    private void CreateCell(int x, int z){
        MazeCell newCell = Instantiate(cellPrefab) as MazeCell; 
        cells[x,z] = newCell; 
        newCell.name = "Maze Cell " + x + ", " + z; 
        newCell.transform.parent = transform; 
        newCell.transform.localPosition = new Vector3((x - sizeX) * 40f - 20f, 0f, (z - sizeZ) * 40f -20f);
    }

}
