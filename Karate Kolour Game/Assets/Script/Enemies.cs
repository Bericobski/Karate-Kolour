using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    public Vector2 playerpos;
    public float speed = 3f;
    public int enemy_ID;
    public SpriteRenderer cube;
    public Animator anim;
    public int ninja_anim;
    public int knife_anim;
    public int beast_anim;
    public int dragon_anim;

    void Start()
    {
        enemy_ID = Random.Range(0, 4);
        speed = Random.Range(3f, 6f);
        player = GameObject.FindGameObjectWithTag("player");
        ninja_anim = Random.Range(0, 1);
        knife_anim = Random.Range(2, 3);
        beast_anim = Random.Range(4, 5);
        dragon_anim = Random.Range(6, 7);
        anim_check();
    }

    void Update()
    {
        //SetSpedd();
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        //posture_check();
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Deflected by" + other.name);

        if (other.tag == "player")
        {
            player_char karateka = other.GetComponent<player_char>();
            if (karateka != null)
            {
                if (karateka.posture_ID == enemy_ID)
                {
                    Destroy(this.gameObject);
                    karateka.score = karateka.score + 1;
                    karateka.attacking(transform.position.x);
                }
                else if (karateka.posture_ID != enemy_ID) { karateka.dead();  }
            }
        }
    }

    /*public void posture_check()
    {
        switch (enemy_ID)
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
        }
    }*/

    public void SetSpedd() 
    {
        player_char karateka = gameObject.GetComponent<player_char>();
        if (karateka != null)
        {
            if (karateka.score >= 5 && karateka.score <= 10) { speed = Random.Range(7f, 10f); }
            else if (karateka.score > 10) { speed = Random.Range(7f, 10f); }
        }
        else { Debug.Log("No funca");  }
    //El problema seria que no reonoce al karateka por lo tanto lo toma como un nulo.
    }


    public void anim_check()
    {
        if (enemy_ID == 0)
        {
            if (ninja_anim == 0) { anim.Play("ninja_patada"); }
            if (ninja_anim == 1) { anim.Play("ninja_nunchaku"); }
        }
        if (enemy_ID == 1)
        {
            if (knife_anim == 2) { anim.Play("shuriken"); }
            if (knife_anim == 3) { anim.Play("cuchillo"); }
        }
        if (enemy_ID == 2)
        {
            if (beast_anim == 4) { anim.Play("snake"); }
            if (beast_anim == 5) { anim.Play("pez_globo"); }
        }
        if (enemy_ID == 3)
        {
            if (dragon_anim == 6) { anim.Play("fantasma"); }
            if (dragon_anim == 5) { anim.Play("fireball"); }
        }        
    }

}
