using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public int button_ID;
    public GameObject player;
    public Animator anims;

    void Start()
    {

    }

    void Update()
    {
        
    }




    private void OnMouseDown()
    {
        if (button_ID == 0)
        {
            anims.Play("boton_tigre");
        }
        if (button_ID == 1)
        {
            anims.Play("boton_gruya");
        }
        if (button_ID == 2)
        {
            anims.Play("boton_snake");
        }
        if (button_ID == 3)
        {
            anims.Play("boton_dragon");
        }
    }

}
