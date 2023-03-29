using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageItem : MonoBehaviour
{
    [SerializeField] GameObject player;

    void Start(){
        player = GameObject.Find("Player");
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.name == "Player"){
            GameObject.Find("Inventory").GetComponent<InventoryManagement>().UseItem("Damage Item");
            Destroy(this.gameObject);
        }
    }
}
