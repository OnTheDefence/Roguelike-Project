using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPotion : MonoBehaviour
{
    GameObject player;

    void Start(){
        player = GameObject.Find("Player");
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.name == "Player"){
            player.GetComponent<PlayerActionController>().DecreaseShootCooldown();
            player.GetComponent<PlayerActionController>().DecreaseDamage();
            Destroy(this.gameObject);
        }
    }
}
