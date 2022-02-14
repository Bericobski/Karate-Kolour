using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player_char : MonoBehaviour
{
    public int posture_ID;
    public SpriteRenderer cube;
    public int score;

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
                }
            }
        }
        posture_check();
        inputButton();
    }

    public void posture_check()
    {
        switch (posture_ID)
        {
            case 0:
                cube.color = new Color(1, 0.5f, 0);
                break;
            case 1:
                cube.color = new Color(0, 1, 0);
                break;
            case 2:
                cube.color = new Color(1, 0, 1);
                break;
            case 3:
                cube.color = new Color(1, 1, 0);
                break;
            default:
                break;
        }//Modifque esta parte para dejar de lado el uso de tantos condicionales.
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
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            posture_ID = 1;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            posture_ID = 2;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            posture_ID = 3;
        }
    }
}