using UnityEngine;

public class Button : MonoBehaviour
{
    public int button_ID;
    public player_char player;

    public void click_button()
    {
        player.posture_ID = button_ID;
        player.play_idle();
    }
}
