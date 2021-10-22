using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundStrob : MonoBehaviour
{
    Image image;
    Color defaultColor;

    private void Awake()
    {
        image = GetComponent<Image>();
        defaultColor = image.color;
    }

    // Observer of OnPressSpace
    public void Strob(bool isOnCollectible)
    {
        if (!isOnCollectible)
            return;

        StartCoroutine(StrobCoroutine());
    }

    IEnumerator StrobCoroutine()
    {
        image.color = Random.ColorHSV(0, 1, 0, 1, 0, 1, 1, 1);
        yield return new WaitForSeconds(0.1f);
        image.color = defaultColor;
    }
}
