using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{

    private Backrooms _br; 

    public struct RoomID{
        public int posX; 
        public int posZ;
    }

    public RoomID ID; 

    public void SetID(int x, int z){
        ID.posX = x; 
        ID.posZ = z; 
    }

    public RoomID GetID(){
        return ID; 
    }

    private bool _occupied;

    void Awake(){
        if(_br == null){
            _br = GameObject.FindGameObjectWithTag("Backrooms").GetComponent<Backrooms>();  
        }
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Player"){
            _occupied = true;
            _br.CheckForNeighbors(ID.posX, ID.posZ); 
        }
    }

    void OnTriggerExit(Collider other){
        if(other.gameObject.tag == "Player"){
            _occupied = false; 
        }
    }

    public bool isOccupied(){
        return _occupied; 
    }
}
