using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game_instance : MonoBehaviour
{
    public static game_instance instance;
    public bool muted_game;
    public int player_score;


    void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        DontDestroyOnLoad(this.gameObject);
        instance = this;
    }
}
