using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public string node_name;
    public int[] coordinates = null;
    public int room_type;
    public GameObject entrance = null;
    public GameObject north_exit = null;
    public GameObject east_exit = null;
    public GameObject south_exit = null;
    public GameObject west_exit = null;
    public bool room_defeated = false;
    public int assigned_seed_digit;

    public void SetName(string name){
        this.node_name = name;
    }

    public string GetName(){
        return this.node_name;
    }

    public void CompleteRoom(){
        this.room_defeated = true;
    }

    public bool RoomCompleted(){
        return this.room_defeated;
    }

    public void SetCoordinates(int x, int y){
        this.coordinates = new int[]{x,y};
    }

    public int[] GetCoordinates(){
        return this.coordinates;
    }

    public void SetRoomType(int id){
        this.room_type = id;
    }

    public int GetRoomType(){
        return this.room_type;
    }

    public void SetEntrance(GameObject entrance, string direction){
        this.entrance = entrance;
        SetExit(this.entrance, direction);
    }

    public GameObject GetEntrance(){
        return this.entrance;
    }

    public bool IsEntrance(){
        if (this.entrance == null){
            return false;
        }

        return true;
    }

    public void SetAssignedSeedDigit(int seed_digit){
        this.assigned_seed_digit = seed_digit;
    }

    public int GetAssignedSeedDigit(){
        return this.assigned_seed_digit;
    }

    public void SetNorthExit(GameObject exit){
        this.north_exit = exit;
    }

    public GameObject GetNorthExit(){
        return this.north_exit;
    }

    public void SetEastExit(GameObject exit){
        this.east_exit = exit;
    }

    public GameObject GetEastExit(){
        return this.east_exit;
    }

    public void SetSouthExit(GameObject exit){
        this.south_exit = exit;
    }

    public GameObject GetSouthExit(){
        return this.south_exit;
    }

    public void SetWestExit(GameObject exit){
        this.west_exit = exit;
    }

    public GameObject GetWestExit(){
        return this.west_exit;
    }

    public void SetExit(GameObject exit, string direction){
        switch (direction){
            case "North":
                SetNorthExit(exit);
                break;
            case "East":
                SetEastExit(exit);
                break;
            case "South":
                SetSouthExit(exit);
                break;
            case "West":
                SetWestExit(exit);
                break;
        }
    }

    public GameObject GetExit(string direction){
        switch (direction){
            case "North":
                return GetNorthExit();
            case "East":
                return GetEastExit();
            case "South":
                return GetSouthExit();
            case "West":
                return GetWestExit();
            default:
                return null;
        }
    }

    static string OppositeDirection(string original_direction){
        switch(original_direction){
            case "North":
                return "South";
            case "East":
                return "West";
            case "South":
                return "North";
            case "West":
                return "East";
            default:
                return "";
        }
    }
}
