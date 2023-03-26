using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField] Vector3 speed = new Vector3(5,5,0);

    void FixedUpdate(){
        transform.Translate(Vector3.Scale((transform.up * Time.deltaTime), speed), Space.World);
    }

    void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.name == "Enemy"){
            col.gameObject.GetComponent<Enemy>().Damage(5);
            Destroy(this.gameObject);
        }
        else{
            if(col.gameObject.name != "Player"){
                Destroy(this.gameObject);
            }
        }
    }
}
