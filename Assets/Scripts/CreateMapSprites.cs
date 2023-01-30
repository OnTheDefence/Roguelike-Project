using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMapSprites : MonoBehaviour
{
    public void Generate(GameObject current_node){
        Debug.Log(current_node);

        Node node = current_node.GetComponent<Node>();
        Vector3 scale_vector = new Vector3((float)1.7,(float)1.7,1);

        GameObject sprites = new GameObject("Sprites");
        sprites.transform.position = current_node.transform.position;
        sprites.transform.parent = current_node.transform;


        GameObject north_door = new GameObject("north_door");
        north_door.transform.position = sprites.transform.position;
        north_door.transform.parent = sprites.transform;
        north_door.transform.localScale = scale_vector;
        north_door.AddComponent<SpriteRenderer>();
        if (current_node.GetComponent<Node>().GetNorthExit() != null){
            north_door.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Doors_north");
        } else{
            north_door.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Walls_north");
        }


        GameObject east_door = new GameObject("east_door");
        east_door.transform.position = sprites.transform.position;
        east_door.transform.parent = sprites.transform;
        east_door.transform.localScale = scale_vector;
        east_door.AddComponent<SpriteRenderer>();
        if (current_node.GetComponent<Node>().GetEastExit() != null){
            east_door.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Doors_east");
        } else{
            east_door.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Walls_east");
        }


        GameObject south_door = new GameObject("south_door");
        south_door.transform.position = sprites.transform.position;
        south_door.transform.parent = sprites.transform;
        south_door.transform.localScale = scale_vector;
        south_door.AddComponent<SpriteRenderer>();
        if (current_node.GetComponent<Node>().GetSouthExit() != null){
            south_door.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Doors_south");
        } else{
            south_door.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Walls_south");
        }


        GameObject west_door = new GameObject("west_door");
        west_door.transform.position = sprites.transform.position;
        west_door.transform.parent = sprites.transform;
        west_door.transform.localScale = scale_vector;
        west_door.AddComponent<SpriteRenderer>();
        if (current_node.GetComponent<Node>().GetWestExit() != null){
            west_door.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Doors_west");
        } else{
            west_door.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Walls_west");
        }


        GameObject map_skeleton = new GameObject("map_skeleton");
        map_skeleton.transform.position = sprites.transform.position + new Vector3(0,0,1);
        map_skeleton.transform.parent = sprites.transform;
        map_skeleton.transform.localScale = scale_vector;
        map_skeleton.AddComponent<SpriteRenderer>();
        map_skeleton.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Skeleton Map");

        
    }
}
