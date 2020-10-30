using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DumbEnemyController : BaseEnemy
{
    protected override void EnemyMove()
    {
        Debug.Log("Dumb enemy don't kill they just fall "); 
    }   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlatformEndMarker")
        {
            EnemyMove();
        }
    }
}

