using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backrooms : MonoBehaviour
{
    public Room roomPrefab; 
    public int roomSize; 
    private int numRoomsSpawned; 
    private List<Room> rooms = new List<Room>(); 

    public void BeginGame(){
        numRoomsSpawned = 0;
        SpawnRoom(0, 0);
    }

    private void SpawnRoom(int x, int z){
        Room newRoom = Instantiate(roomPrefab, new Vector3(x * roomSize, 0, z * roomSize), Quaternion.identity) as Room; 
        newRoom.SetID(x, z); 
        newRoom.name = "Room " + x + ", " + z;
        rooms.Add(newRoom);
        numRoomsSpawned++;
    }

    public void InstantiateNeighbors(int x, int z){  
        ///////////////////////////////////////////////////////////////////
        //if no neighbors exist, Instantiate them//////////////////////////
        ///////////////////////////////////////////////////////////////////
        for(int i = 0; i < rooms.Count; i++){
            if(!rooms.Exists(e => e.name == "Room " + (x + 1) + ", " + z)){
                SpawnRoom(x + 1, z);
            } 
            if(!rooms.Exists(e => e.name == "Room " + (x - 1) + ", " + z)){
                SpawnRoom(x - 1, z); 
            }
            if(!rooms.Exists(e => e.name == "Room " + x + ", " + (z + 1))){
                SpawnRoom(x, z + 1 ); 
            }
            if(!rooms.Exists(e => e.name == "Room " + x + ", " + (z - 1))){
                SpawnRoom(x, z - 1); 
            }
        }
    }

    public void EnableNeighbors(int x, int z){
        ///////////////////////////////////////////////////////////////////
        //SetActive(true) on neighboring rooms/////////////////////////////
        ///////////////////////////////////////////////////////////////////
        foreach(Room r in rooms){ 
            if(r.isActiveAndEnabled){
                rooms.Find(e => e.name == "Room " + (x + 1) + ", " + z).gameObject.SetActive(true);
                rooms.Find(e => e.name == "Room " + (x - 1) + ", " + z).gameObject.SetActive(true);
                rooms.Find(e => e.name == "Room " + x + ", " + (z + 1)).gameObject.SetActive(true);
                rooms.Find(e => e.name == "Room " + x + ", " + (z - 1)).gameObject.SetActive(true);
            }
        }
    }

    public void DisableRooms(int x, int z){
        for(int i = 0; i < rooms.Count; i++){
            if(rooms.Exists(e => e.name == "Room " + (x - 1) + ", " + (z - 1))){
                rooms.Find(e => e.name == "Room " + (x - 1) + ", " + (z - 1)).gameObject.SetActive(false);
            }   
            if(rooms.Exists(e => e.name == "Room " + (x + 1) + ", " + (z - 1))){
                rooms.Find(e => e.name == "Room " + (x + 1) + ", " + (z - 1)).gameObject.SetActive(false);
            }

            if(rooms.Exists(e => e.name == "Room " + (x + 1) + ", " + (z + 1))){
                rooms.Find(e => e.name == "Room " + (x + 1) + ", " + (z + 1)).gameObject.SetActive(false);
            }   
            if(rooms.Exists(e => e.name == "Room " + (x - 1) + ", " + (z + 1))){
                rooms.Find(e => e.name == "Room " + (x - 1) + ", " + (z + 1)).gameObject.SetActive(false);
            }

            if(rooms.Exists(e => e.name == "Room " + x + ", " + (z - 2))){
                rooms.Find(e => e.name == "Room " + x + ", " + (z - 2)).gameObject.SetActive(false);
            }   
            if(rooms.Exists(e => e.name == "Room " + x + ", " + (z + 2))){
                rooms.Find(e => e.name == "Room " + x + ", " + (z + 2)).gameObject.SetActive(false);
            }

            if(rooms.Exists(e => e.name == "Room " + (x + 2) + ", " + z)){
                rooms.Find(e => e.name == "Room " + (x + 2) + ", " + z).gameObject.SetActive(false);
            }
            if(rooms.Exists(e => e.name == "Room " + (x - 2) + ", " + z)){
                rooms.Find(e => e.name == "Room " + (x - 2) + ", " + z).gameObject.SetActive(false);
            }  
        }
    }
    

}
