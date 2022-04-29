using UnityEngine;
using TMPro;

public class UI_Manager : MonoBehaviour
{
    public TextMeshProUGUI puntaje;
    public string uerreele = "https://imagecampus.itch.io";

    public void open_url()
    {
        Application.OpenURL(uerreele);
    } 

    public void update_score()
    {
        puntaje.text = "score: " + game_instance.instance.player_score;
    } 

    void Update()
    {
        update_score();
    }
}
