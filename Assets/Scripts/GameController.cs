using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private GameObject current_node;
    private GameObject player;
    private GameObject enemies;
    private GameObject camera;
    private bool level_clear = false;
    private string[] directions = {"north", "east", "south", "west"};
    private string[] gate_names = {"", "", "", ""};


    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.Find("Player");
        current_node = GameObject.Find("Start Node");
        enemies = GameObject.Find("Enemies");
        camera = GameObject.Find("Main Camera");
        camera.transform.position = new Vector3(current_node.transform.position.x, current_node.transform.position.y, -10);

        for (int i = 0; i < 4; i++){
            gate_names[i] = directions[i] + "_door_gate";
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(enemies.transform.childCount == 0 && level_clear == false){
            GameObject sprites = GetChildWithName(current_node, "Sprites");

            GameObject gate = null;

            for (int i = 0; i < 4; i++){
                gate = GetChildWithName(sprites, gate_names[i]);
                if (gate != null){
                    Destroy(gate);
                }
            }

            level_clear = true;

        }
    }

    public void TransportPlayer(string direction){
        current_node = GetChildWithName(current_node, direction);
        camera.transform.position = new Vector3(current_node.transform.position.x, current_node.transform.position.y, -10);
        float x_offset = 4f;
        float y_offset = 2.7f;
        GameObject sprites_local = GetChildWithName(current_node, "Sprites");
        GameObject door = null;
        switch(direction){
            case "North":
                
                door = GetChildWithName(sprites_local, ("north_door"));
                player.transform.position = new Vector3(door.transform.position.x, door.transform.position.y - y_offset);
                break;
            case "East":
                door = GetChildWithName(sprites_local, ("east_door"));
                player.transform.position = new Vector3(door.transform.position.x - x_offset, door.transform.position.y);
                break;
            case "South":
                door = GetChildWithName(sprites_local, ("north_door"));
                player.transform.position = new Vector3(door.transform.position.x, door.transform.position.y + y_offset);
                break;
            case "West":
                door = GetChildWithName(sprites_local, ("east_door"));
                player.transform.position = new Vector3(door.transform.position.x + x_offset, door.transform.position.y);
                break;
        }
    }

    public static GameObject GetChildWithName(GameObject obj, string name){

        Transform trans = obj.transform;
        Transform childTrans = trans.Find(name);
             
        if (childTrans != null){
            return childTrans.gameObject;
        }
 
        return null;
        }

}
