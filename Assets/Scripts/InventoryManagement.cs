using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManagement : MonoBehaviour
{
    string selected_item;
    GameObject player;
    [SerializeField] string[] current_inventory;
    GameObject inventory_go;

    void Awake(){
        inventory_go = GameObject.Find("Inventory");
        player = GameObject.Find("Player");
        current_inventory = new string[]{"", "", ""};
    }

    void FixedUpdate()
    {
        if (Input.GetAxisRaw("use1") != 0){
            selected_item = player.GetComponent<Player>().GetInvSlot(0);
            UseItem(selected_item);
            player.GetComponent<Player>().SetInvSlot(0, "");
        } else if (Input.GetAxisRaw("use2") != 0){
            selected_item = player.GetComponent<Player>().GetInvSlot(1);
            UseItem(selected_item);
            player.GetComponent<Player>().SetInvSlot(1, "");
        } else if (Input.GetAxisRaw("use3") != 0){
            selected_item = player.GetComponent<Player>().GetInvSlot(2);
            UseItem(selected_item);
            player.GetComponent<Player>().SetInvSlot(2, "");
        }
    }

    public void UseItem(string item){
        switch (item){
            case "Health Potion":
                player.GetComponent<Player>().IncreaseHealth(5);
                break;
            case "Speed Potion":
                player.GetComponent<PlayerActionController>().DecreaseShootCooldown();
                player.GetComponent<PlayerActionController>().DecreaseDamage();
                break;
            case "Damage Potion":
                player.GetComponent<PlayerActionController>().IncreaseShootCooldown();
                player.GetComponent<PlayerActionController>().IncreaseDamage();
                break;
        }

        SetInvUI(player.GetComponent<Player>().GetInv());
    }

    public void SetInvUI(string[] inv){
        for (int i = 0; i < inv.Length; i++){
            GameObject slot = null;
            if (inv[i] == "Health Potion"){
                switch (i){
                    case 0:
                        slot = GameObject.Find("InventorySlot1"); 
                        break;
                    case 1:
                        slot = GameObject.Find("InventorySlot2"); 
                        break;
                    case 2:
                        slot = GameObject.Find("InventorySlot3"); 
                        break;
                }
                
                slot.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("potion_red");
                slot.transform.GetChild(0).gameObject.SetActive(true);

            } else if (inv[i] == "Speed Potion"){
                switch (i){
                    case 0:
                        slot = GameObject.Find("InventorySlot1"); 
                        break;
                    case 1:
                        slot = GameObject.Find("InventorySlot2"); 
                        break;
                    case 2:
                        slot = GameObject.Find("InventorySlot3"); 
                        break;
                }
                
                slot.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("potion_blue");
                slot.transform.GetChild(0).gameObject.SetActive(true);

            } else if (inv[i] == "Damage Potion"){
                switch (i){
                    case 0:
                        slot = GameObject.Find("InventorySlot1"); 
                        break;
                    case 1:
                        slot = GameObject.Find("InventorySlot2"); 
                        break;
                    case 2:
                        slot = GameObject.Find("InventorySlot3"); 
                        break;
                }
                
                slot.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("potion_yellow");
                slot.transform.GetChild(0).gameObject.SetActive(true);
            } else{
                switch (i){
                    case 0:
                        slot = GameObject.Find("InventorySlot1"); 
                        break;
                    case 1:
                        slot = GameObject.Find("InventorySlot2"); 
                        break;
                    case 2:
                        slot = GameObject.Find("InventorySlot3"); 
                        break;
                }
                
                slot.transform.GetChild(0).gameObject.SetActive(false);
            }
        }
    }
}
