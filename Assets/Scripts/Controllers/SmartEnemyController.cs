using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class BaseEnemy :MonoBehaviour
{
    [SerializeField] float _enemySpeed = 1.25f;
    protected abstract void EnemyMove();
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player player = collision.gameObject?.GetComponent<Player>();
        if (player != null)
        {
            player.UpdateLives();
        }
    }
    private void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * _enemySpeed);
    }
}


public class SmartEnemyController : BaseEnemy 
{ 
    protected override void EnemyMove()
    {
        transform.Rotate(0.0f, 180.0f, 0.0f, Space.Self);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlatformEndMarker")
        {
            EnemyMove();
        }
    }
}
