using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public Maze mazePrefab; 
    private Maze _mazeInstantance; 

    private void Start(){
        _mazeInstantance = Instantiate(mazePrefab) as Maze; 
        BeginGame(); 
    }

    private void BeginGame(){
        _mazeInstantance.Genrate(); 
    }

    private void RestartGame(){

    }
}
