using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Manager : MonoBehaviour
{
    public TextMeshProUGUI puntaje;

    public void update_score() { puntaje.text = "score: " + game_instance.instance.player_score; }

    void Update() { update_score(); }
}
