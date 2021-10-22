using System.Collections;
using UnityEngine;
using EasingTC;

public class Collectible : MonoBehaviour
{
    [Header("BEHAVIOURS")]
    [SerializeField] [Range(2, 30)] int minDistance = 2;
    [SerializeField] [Range(40, 300)] int maxDistance = 140;
    [Space]

    [Header("ANIMATIONS")]
    [SerializeField] EasingScale easingScale;

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

        easingScale.PlayAnimation();
        StartCoroutine(RespawnCoroutine(newAngle));
    }

    IEnumerator RespawnCoroutine(float newAngle)
    {
        yield return new WaitForSeconds(easingScale.duration / 2);

        transform.rotation = Quaternion.Euler(0, 0, newAngle);
        //easingScale.PlayAnimationInOut();
    }

    // Observer of OnGameStart
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
