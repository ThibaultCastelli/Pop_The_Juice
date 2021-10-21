using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MusicTC;

public class Music : MonoBehaviour
{
    [SerializeField] MusicEvent menuMusic;
    [SerializeField] MusicEvent gameMusic;

    // Observer of OnGameStart
    public void GameStart(bool isGameStart)
    {
        if (isGameStart)
            gameMusic.Play();
        else
            menuMusic.Play();
    }
}
