using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public int room_type;
    public string entrance_direction;

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
}
