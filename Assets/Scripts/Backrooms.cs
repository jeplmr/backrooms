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
        Debug.Log(numRoomsSpawned.ToString()); 
    }

    public void CheckForNeighbors(int x, int z){
        foreach(Room r in rooms){
            if(r.isActiveAndEnabled){
                if(r.isOccupied()){
                    ///////////////////////////////////////////////////////////////////
                    //if no neighbors exist, Instantiate them. Otherwise, enable them//
                    ///////////////////////////////////////////////////////////////////
                    if(!rooms.Exists(e => e.name == "Room " + (r.ID.posX + 1) + ", " + r.ID.posZ)){
                        SpawnRoom(r.ID.posX + 1, r.ID.posZ);
                    } 
                    rooms.Find(e => e.name == "Room " + (r.ID.posX + 1) + ", " + r.ID.posZ).gameObject.SetActive(true);

                    if(!rooms.Exists(e => e.name == "Room " + (r.ID.posX - 1) + ", " + r.ID.posZ)){
                        SpawnRoom(r.ID.posX - 1, r.ID.posZ); 
                    }
                    rooms.Find(e => e.name == "Room " + (r.ID.posX - 1) + ", " + r.ID.posZ).gameObject.SetActive(true);

                    if(!rooms.Exists(e => e.name == "Room " + r.ID.posX + ", " + (r.ID.posZ + 1) )){
                        SpawnRoom(r.ID.posX, r.ID.posZ + 1 ); 
                    }
                    rooms.Find(e => e.name == "Room " + r.ID.posX + ", " + (r.ID.posZ + 1)).gameObject.SetActive(true);

                    if(!rooms.Exists(e => e.name == "Room " + r.ID.posX + ", " + (r.ID.posZ - 1))){
                        SpawnRoom(r.ID.posX, r.ID.posZ - 1); 
                    }
                    rooms.Find(e => e.name == "Room " + r.ID.posX + ", " + (r.ID.posZ - 1)).gameObject.SetActive(true);
                } else {
                    r.gameObject.SetActive(false); 
                }
            }
        }
    }

}
