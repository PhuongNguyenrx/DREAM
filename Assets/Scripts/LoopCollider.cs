using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopCollider : MonoBehaviour
{
    public LevelManager level;
    private void OnCollisionEnter2D(Collision2D collision)
    { 
        if (collision.gameObject.tag == "Player")
        {
           
            level.NextLoop();
        }
    }
}
