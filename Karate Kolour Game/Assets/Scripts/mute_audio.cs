using UnityEngine;
using UnityEngine.UI;

public class mute_audio : MonoBehaviour
{
    public Sprite audio_si;
    public Sprite audio_no;
    public Image botoncete;

    void Start()
    {
        if (game_instance.instance.muted_game)
        {
            botoncete.sprite = audio_no;
        }
        else
        {
            botoncete.sprite = audio_si;
        }
    }

    public void audio_quiza()
    {
        game_instance.instance.muted_game = !game_instance.instance.muted_game;
        if (game_instance.instance.muted_game == true)
        {
            AudioListener.volume = 0;
            botoncete.sprite = audio_no;
        }
        else
        {
            AudioListener.volume = 1;
            botoncete.sprite = audio_si;
        }
    }
}
