using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePotion : MonoBehaviour
{
    [SerializeField] GameObject player;

    void Start(){
        player = GameObject.Find("Player");
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.name == "Player"){
            if(player.GetComponent<Player>().GetInvSlot(0) == ""){
                player.GetComponent<Player>().SetInvSlot(0, "Damage Potion");
                Destroy(this.gameObject);
            } else if(player.GetComponent<Player>().GetInvSlot(1) == ""){
                player.GetComponent<Player>().SetInvSlot(1, "Damage Potion");
                Destroy(this.gameObject);
            } else if(player.GetComponent<Player>().GetInvSlot(2) == ""){
                player.GetComponent<Player>().SetInvSlot(2, "Damage Potion");
                Destroy(this.gameObject);
            }
            GameObject.Find("Inventory").GetComponent<InventoryManagement>().SetInvUI(player.GetComponent<Player>().GetInv());
        }
    }
}
