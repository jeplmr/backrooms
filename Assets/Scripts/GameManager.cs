using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public Backrooms backroomsPrefab; 

    void Start(){
        backroomsPrefab.BeginGame(); 
    }

}
