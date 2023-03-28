using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOneBullet : MonoBehaviour
{
    [SerializeField] Vector3 speed = new Vector3(3,3,0);

    void FixedUpdate(){
        transform.Translate(Vector3.Scale((transform.up * Time.deltaTime), speed), Space.World);
    }

    void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.name == "Player"){
            if (col.gameObject.GetComponent<PlayerActionController>().IsRolling() == false){
                col.gameObject.GetComponent<Player>().ReduceHealth(5f);
                Destroy(this.gameObject);
            }
        }
        else{
            if(col.gameObject.name != "Enemy" && col.gameObject.name != "Boss" && col.gameObject.name != "Bullet"){
                Destroy(this.gameObject);
            }
        }
    }
}
