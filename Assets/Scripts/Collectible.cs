using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] [Range(2, 30)] int minDistance = 2;
    [SerializeField] [Range(40, 300)] int maxDistance = 140;

    Player player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            player = collision.GetComponent<Player>();
    }

    // Observer of OnPressSpace
    public void Respawn(bool isOnCollectible)
    {
        if (!isOnCollectible)
            return;

        float newAngle = Random.Range(transform.rotation.z + (minDistance * player.CurrentDir), 
            transform.rotation.z + (Mathf.Clamp(player.CurrentSpeed, 0, maxDistance) * player.CurrentDir));
        transform.rotation = Quaternion.Euler(0, 0, newAngle);
    }

    public void GameStart(bool isGameStart)
    {
        if (isGameStart)
        {
            transform.position = Vector3.zero;
            transform.rotation = Quaternion.Euler(0, 0, Random.Range(30, 100));
        }
        else
        {
            transform.position = new Vector3(50, 50, 0);
        }
    }
}
