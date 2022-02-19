using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Manager : MonoBehaviour
{
    public TextMeshProUGUI puntaje;
    public player_char player;

    public void update_score() { puntaje.text = "score: " + player.score; }

    void Update() { update_score(); }
}
