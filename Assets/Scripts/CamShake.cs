using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamShake : MonoBehaviour
{
    [SerializeField] [Range(0f, 5f)] float shakeDuration;
    [SerializeField] [Range(0f, 5f)] float shakeStrength;

    // Observer of OnPressSpace
    public void Shake(bool isOnCollectible)
    {
        StopAllCoroutines();

        if (isOnCollectible)
            StartCoroutine(ShakeCoroutine(shakeDuration, shakeStrength));
        else
            StartCoroutine(ShakeCoroutine(shakeDuration * 3, shakeStrength * 2));
    }

    // Observer of OnGameStart
    public void ShakeStart(bool isGameStart)
    {
        StopAllCoroutines();

        if (isGameStart)
            StartCoroutine(ShakeCoroutine(shakeDuration, shakeStrength));
    }

    IEnumerator ShakeCoroutine(float duration, float strength)
    {
        float t = 0;
        float randomX;
        float randomY;

        while (t != duration)
        {
            randomX = Random.Range(-shakeStrength, shakeStrength);
            randomY = Random.Range(-shakeStrength, shakeStrength);

            transform.position = new Vector3(randomX, randomY, -10);

            yield return null;
            t = Mathf.Clamp(t + Time.deltaTime, 0, duration);
        }

        transform.position = new Vector3(0, 0, -10);
    }
}
