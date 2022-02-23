using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public int button_ID;
    public GameObject player;
    public Animator anims;
    public Sprite[] icono;

    void Start() { }
    void Update() { }
    private void OnMouseDown()
    {
        switch (button_ID)
        {
            case 0:
                anims.Play("boton_tigre");
                break;
            case 1:
                anims.Play("boton_gruya");
                break;
            case 2:
                anims.Play("boton_snake");
                break;
            case 3:
                anims.Play("boton_dragon");
                break;
            default:
                break;
        }
    }

}
