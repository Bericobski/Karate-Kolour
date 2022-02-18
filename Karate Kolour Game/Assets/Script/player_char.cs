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

    void Start() { }
    // Update is called once per frame
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
        //posture_check();
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
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            posture_ID = 1;
            anims.Play("idle_crane");
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            posture_ID = 2;
            anims.Play("idle_snake");
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            posture_ID = 3;
            anims.Play("idle_dragon");
        }
    }

    public void attacking(float pos_x)
    {
        if (pos_x < transform.position.x)
        {
            cube.flipX = true;
        }
        else
        {
            cube.flipX = false;
        }


        if (posture_ID == 0)
        {
            anims.Play("Tiger_attack");
        }

        if (posture_ID == 1)
        {
            anims.Play("crane_attack");
        }

        if (posture_ID == 2)
        {
            anims.Play("Snake_attack");
        }

        if (posture_ID == 3)
        {
            anims.Play("dragon_attack");
        }
    }

    public void play_idle()
    {
        if (posture_ID == 0)
        {
            anims.Play("idle_tiger");
        }

        if (posture_ID == 1)
        {
            anims.Play("idle_crane");
        }

        if (posture_ID == 2)
        {
            anims.Play("idle_snake");
        }

        if (posture_ID == 3)
        {
            anims.Play("idle_dragon");
        }
    }
}
