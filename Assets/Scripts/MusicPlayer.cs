using System;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    void Start()
    {
        int numberOfMusicPlayers = FindObjectsByType<MusicPlayer>(FindObjectsSortMode.None).Length;
        if(numberOfMusicPlayers > 1)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
