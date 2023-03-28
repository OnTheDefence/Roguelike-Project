using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameControl : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col){
        Debug.Log(col.gameObject.name);
        if (col.gameObject.name == "Player"){
            SceneManager.LoadScene("EndWin");
        }
    }
}
