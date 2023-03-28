using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePotion : MonoBehaviour
{
    GameObject player;

    void Start(){
        player = GameObject.Find("Player");
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.name == "Player"){
            player.GetComponent<PlayerActionController>().IncreaseShootCooldown();
            player.GetComponent<PlayerActionController>().IncreaseDamage();
            Destroy(this.gameObject);
        }
    }
}
