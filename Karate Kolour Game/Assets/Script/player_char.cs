using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player_char : MonoBehaviour
{
    public int posture_ID;
    public SpriteRenderer cube;
    public int score;
    public Animator anims;
    public AudioSource soundboard;
    public AudioClip tiger_roar;
    public AudioClip crane_shout;
    public AudioClip snake_hiss;
    public AudioClip dragon_roar;
    public AudioSource piña_sonido;
    public AudioSource garganta;
    public AudioClip piña_1;
    public AudioClip piña_2;
    public AudioClip piña_3;
    public AudioClip grito_1;
    public AudioClip grito_2;

    void Start() { }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D rayHit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
            
            if (rayHit)
            {
                if (rayHit.transform.tag == "posture_shift")
                {
                    posture_ID = rayHit.transform.GetComponent<Button>().button_ID;
                    play_idle();
                }
            }
        }
        inputButton();
    }

    public void dead()
    {
        SceneManager.LoadScene("game_over");
    }

    public void inputButton()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            posture_ID = 0;
            anims.Play("idle_tiger");
            soundboard.clip = tiger_roar;
            soundboard.Play();
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            posture_ID = 1;
            anims.Play("idle_crane");
            soundboard.clip = crane_shout;
            soundboard.Play();
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            posture_ID = 2;
            anims.Play("idle_snake");
            soundboard.clip = snake_hiss;
            soundboard.Play();
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            posture_ID = 3;
            anims.Play("idle_dragon");
            soundboard.clip = dragon_roar;
            soundboard.Play();
        }
    }

    public void attacking(float pos_x)
    {
        if (pos_x < transform.position.x) { cube.flipX = true; }
        else { cube.flipX = false; }
        Posture_Attack();
    }

    public void play_idle()
    {
        switch (posture_ID)
        {
            case 0:
                anims.Play("idle_tiger");
                soundboard.clip = tiger_roar;
                soundboard.Play();
                break;
            case 1:
                anims.Play("idle_crane");
                soundboard.clip = crane_shout;
                soundboard.Play();
                break;
            case 2:
                anims.Play("idle_snake");
                soundboard.clip = snake_hiss;
                soundboard.Play();
                break;
            case 3:
                anims.Play("idle_dragon");
                soundboard.clip = dragon_roar;
                soundboard.Play();
                break;
            default:
                break;
        }
    }
    public void Posture_Attack()
    {
        switch (posture_ID)
        {
            case 0:
                anims.Play("Tiger_attack");
                break;
            case 1:
                anims.Play("crane_attack");
                break;
            case 2:
                anims.Play("Snake_attack");
                break;
            case 3:
                anims.Play("dragon_attack");
                break;
            default:
                break;
        }
    }




}
