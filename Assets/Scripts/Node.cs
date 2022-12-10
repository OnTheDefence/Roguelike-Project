using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public int room_type;
    public string entrance_direction;
    public GameObject north_exit = null;
    public GameObject east_exit = null;
    public GameObject south_exit = null;
    public GameObject west_exit = null;
    public int assigned_seed_digit;

    public void SetRoomType(int id){
        this.room_type = id;
    }

    public int GetRoomType(){
        return this.room_type;
    }

    public void SetEntranceDirection(string direction){
        this.entrance_direction = direction;
    }

    public string GetEntranceDirection(){
        return this.entrance_direction;
    }

    public void SetAssignedSeedDigit(int seed_digit){
        this.assigned_seed_digit = seed_digit;
    }

    public int GetAssignedSeedDigit(int seed_digit){
        return this.assigned_seed_digit;
    }
}
