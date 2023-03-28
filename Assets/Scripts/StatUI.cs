using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatUI : MonoBehaviour
{
    private Sprite[] ui_sprites;
    private Dictionary<string, Sprite> ui_sprites_dict = new Dictionary<string, Sprite>();
    private GameObject player;

    private GameObject heart1;
    private GameObject heart2;
    private GameObject heart3;

    private GameObject damage1;
    private GameObject damage2;
    private GameObject damage3;
    private GameObject damage4;
    private GameObject damage5;
    private GameObject damage6;
    private GameObject damage7;
    private GameObject damage8;
    private GameObject damage9;

    private GameObject speed1;
    private GameObject speed2;
    private GameObject speed3;
    private GameObject speed4;
    private GameObject speed5;
    private GameObject speed6;
    private GameObject speed7;
    private GameObject speed8;
    private GameObject speed9;

    void Start()
    {
        player = GameObject.Find("Player");

        ui_sprites = Resources.LoadAll<Sprite>("ui_big_pieces");

        for (int i = 0; i < ui_sprites.Length; i++){
            ui_sprites_dict.Add(ui_sprites[i].name, ui_sprites[i]);
        }

        heart1 = GameObject.Find("Heart1");
        heart2 = GameObject.Find("Heart2");
        heart3 = GameObject.Find("Heart3");

        heart1.GetComponent<Image>().sprite = ui_sprites_dict["Red_Rounded_Health_Centre"];
        heart2.GetComponent<Image>().sprite = ui_sprites_dict["Red_Rounded_Health_Centre"];
        heart3.GetComponent<Image>().sprite = ui_sprites_dict["Red_Rounded_Health_Centre"];

        speed1 = GameObject.Find("SpeedBar1");
        speed2 = GameObject.Find("SpeedBar2");
        speed3 = GameObject.Find("SpeedBar3");
        speed4 = GameObject.Find("SpeedBar4");
        speed5 = GameObject.Find("SpeedBar5");
        speed6 = GameObject.Find("SpeedBar6");
        speed7 = GameObject.Find("SpeedBar7");
        speed8 = GameObject.Find("SpeedBar8");
        speed9 = GameObject.Find("SpeedBar9");

        speed1.GetComponent<Image>().sprite = ui_sprites_dict["Blue_Rounded_Speed_Centre"];
        speed2.GetComponent<Image>().sprite = ui_sprites_dict["Blue_Rounded_Speed_Centre"];
        speed3.GetComponent<Image>().sprite = ui_sprites_dict["Blue_Rounded_Speed_Centre"];
        speed4.GetComponent<Image>().sprite = ui_sprites_dict["Blue_Rounded_Speed_Centre"];
        speed5.GetComponent<Image>().sprite = ui_sprites_dict["Blue_Rounded_Speed_Centre"];
        speed6.GetComponent<Image>().sprite = ui_sprites_dict["Blue_Rounded_Speed_Centre"];
        speed7.GetComponent<Image>().sprite = ui_sprites_dict["Blue_Rounded_Speed_Centre"];
        speed8.GetComponent<Image>().sprite = ui_sprites_dict["Blue_Rounded_Speed_Centre"];
        speed9.GetComponent<Image>().sprite = ui_sprites_dict["Blue_Rounded_Speed_Centre"];

        damage1 = GameObject.Find("DamageBar1");
        damage2 = GameObject.Find("DamageBar2");
        damage3 = GameObject.Find("DamageBar3");
        damage4 = GameObject.Find("DamageBar4");
        damage5 = GameObject.Find("DamageBar5");
        damage6 = GameObject.Find("DamageBar6");
        damage7 = GameObject.Find("DamageBar7");
        damage8 = GameObject.Find("DamageBar8");
        damage9 = GameObject.Find("DamageBar9");

        damage1.GetComponent<Image>().sprite = ui_sprites_dict["Yellow_Rounded_Damage_Centre"];
        damage2.GetComponent<Image>().sprite = ui_sprites_dict["Yellow_Rounded_Damage_Centre"];
        damage3.GetComponent<Image>().sprite = ui_sprites_dict["Yellow_Rounded_Damage_Centre"];
        damage4.GetComponent<Image>().sprite = ui_sprites_dict["Yellow_Rounded_Damage_Centre"];
        damage5.GetComponent<Image>().sprite = ui_sprites_dict["Yellow_Rounded_Damage_Centre"];
        damage6.GetComponent<Image>().sprite = ui_sprites_dict["Yellow_Rounded_Damage_Centre"];
        damage7.GetComponent<Image>().sprite = ui_sprites_dict["Yellow_Rounded_Damage_Centre"];
        damage8.GetComponent<Image>().sprite = ui_sprites_dict["Yellow_Rounded_Damage_Centre"];
        damage9.GetComponent<Image>().sprite = ui_sprites_dict["Yellow_Rounded_Damage_Centre"];

        HandleDamageDecrease();
        HandleDamageIncrease();
        HandleHealthDecrease();
        HandleHealthIncrease();
        HandleSpeedDecrease();
        HandleSpeedIncrease();
    }

    public void HandleHealthDecrease(){
        if (player.GetComponent<Player>().GetHealth() < 15){
            heart3.SetActive(false);
            if (player.GetComponent<Player>().GetHealth() < 10){
                heart2.SetActive(false);
                if (player.GetComponent<Player>().GetHealth() < 5){
                    heart1.SetActive(false);
                }
            }
        }
    }

    public void HandleHealthIncrease(){
        if (player.GetComponent<Player>().GetHealth() >= 5){
            heart1.SetActive(true);
            if (player.GetComponent<Player>().GetHealth() >= 10){
                heart2.SetActive(true);
                if (player.GetComponent<Player>().GetHealth() >= 15){
                    heart3.SetActive(true);
                }
            }
        }
    }

    public void HandleDamageDecrease(){
        if (player.GetComponent<PlayerActionController>().GetDamage() < 15){
            damage9.SetActive(false);
            if (player.GetComponent<PlayerActionController>().GetDamage() < 13){
                damage8.SetActive(false);
                if (player.GetComponent<PlayerActionController>().GetDamage() < 11){
                    damage7.SetActive(false);
                    if (player.GetComponent<PlayerActionController>().GetDamage() < 9){
                        damage6.SetActive(false);
                        if (player.GetComponent<PlayerActionController>().GetDamage() < 7){
                            damage5.SetActive(false);
                            if (player.GetComponent<PlayerActionController>().GetDamage() < 5){
                                damage4.SetActive(false);
                                if (player.GetComponent<PlayerActionController>().GetDamage() < 4){
                                    damage3.SetActive(false);
                                    if (player.GetComponent<PlayerActionController>().GetDamage() < 3){
                                        damage2.SetActive(false);
                                        if (player.GetComponent<PlayerActionController>().GetDamage() < 2){
                                            damage1.SetActive(false);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    public void HandleDamageIncrease(){
        if (player.GetComponent<PlayerActionController>().GetDamage() >= 2){
            damage1.SetActive(true);
            if (player.GetComponent<PlayerActionController>().GetDamage() >= 3){
                damage2.SetActive(true);
                if (player.GetComponent<PlayerActionController>().GetDamage() >= 4){
                    damage3.SetActive(true);
                    if (player.GetComponent<PlayerActionController>().GetDamage() >= 5){
                        damage4.SetActive(true);
                        if (player.GetComponent<PlayerActionController>().GetDamage() >= 7){
                            damage5.SetActive(true);
                            if (player.GetComponent<PlayerActionController>().GetDamage() >= 9){
                                damage6.SetActive(true);
                                if (player.GetComponent<PlayerActionController>().GetDamage() >= 11){
                                    damage7.SetActive(true);
                                    if (player.GetComponent<PlayerActionController>().GetDamage() >= 13){
                                        damage8.SetActive(true);
                                        if (player.GetComponent<PlayerActionController>().GetDamage() >= 15){
                                            damage9.SetActive(true);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    public void HandleSpeedDecrease(){
        if (player.GetComponent<PlayerActionController>().GetShootCooldown() < 2.25f){
            speed9.SetActive(false);
            if (player.GetComponent<PlayerActionController>().GetShootCooldown() < 2f){
                speed8.SetActive(false);
                if (player.GetComponent<PlayerActionController>().GetShootCooldown() < 1.75f){
                    speed7.SetActive(false);
                    if (player.GetComponent<PlayerActionController>().GetShootCooldown() < 1.5f){
                        speed6.SetActive(false);
                        if (player.GetComponent<PlayerActionController>().GetShootCooldown() < 1.25f){
                            speed5.SetActive(false);
                            if (player.GetComponent<PlayerActionController>().GetShootCooldown() < 1f){
                                speed4.SetActive(false);
                                if (player.GetComponent<PlayerActionController>().GetShootCooldown() < 0.75f){
                                    speed3.SetActive(false);
                                    if (player.GetComponent<PlayerActionController>().GetShootCooldown() < 0.5f){
                                        speed2.SetActive(false);
                                        if (player.GetComponent<PlayerActionController>().GetShootCooldown() < 0.25f){
                                            speed1.SetActive(false);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    public void HandleSpeedIncrease(){
        if (player.GetComponent<PlayerActionController>().GetShootCooldown() >= 0.25f){
            speed1.SetActive(true);
            if (player.GetComponent<PlayerActionController>().GetShootCooldown() >= 0.5f){
                speed2.SetActive(true);
                if (player.GetComponent<PlayerActionController>().GetShootCooldown() >= 0.75f){
                    speed3.SetActive(true);
                    if (player.GetComponent<PlayerActionController>().GetShootCooldown() >= 1f){
                        speed4.SetActive(true);
                        if (player.GetComponent<PlayerActionController>().GetShootCooldown() >= 1.25f){
                            speed5.SetActive(true);
                            if (player.GetComponent<PlayerActionController>().GetShootCooldown() >= 1.5f){
                                speed6.SetActive(true);
                                if (player.GetComponent<PlayerActionController>().GetShootCooldown() >= 1.75f){
                                    speed7.SetActive(true);
                                    if (player.GetComponent<PlayerActionController>().GetShootCooldown() >= 2f){
                                        speed8.SetActive(true);
                                        if (player.GetComponent<PlayerActionController>().GetShootCooldown() >= 2.5f){
                                            speed9.SetActive(true);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
    
}
