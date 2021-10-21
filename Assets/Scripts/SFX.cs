using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SFXTC;

public class SFX : MonoBehaviour
{
    [SerializeField] SFXEvent collectSFX;
    [SerializeField] SFXEvent gameOverSFX;

    // Observer of OnPressSpace
    public void Collect(bool isOnCollectible)
    {
        if (isOnCollectible)
            collectSFX.Play();
        else
            gameOverSFX.Play();
    }

    
}
