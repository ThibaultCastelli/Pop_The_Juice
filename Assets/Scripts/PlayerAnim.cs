using UnityEngine;
using EasingTC;

public class PlayerAnim : MonoBehaviour
{
    EasingScale scale;

    private void Awake()
    {
        scale = GetComponent<EasingScale>();
    }

    // Observer of OnPressSpace
    public void SpaceAnim(bool isOnCollectible)
    {
        if (isOnCollectible)
            scale.PlayAnimation();
    }

    // Observer of OnGameStart
    public void GameStartAnim(bool isGameStart)
    {
        if (isGameStart)
            scale.PlayAnimation();
    }
}
