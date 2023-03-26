using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    GameObject gameController;
    public string direction = "None";

    void Start(){
        gameController = GameObject.Find("GameController");
    }

    void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.name == "Player"){
            gameController.GetComponent<GameController>().TransportPlayer(direction);
        }
    }
}
