using UnityEngine;

public class Enemies : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    public Vector2 playerpos;
    public float speed;
    private bool speedBool = true;
    public int enemy_ID;
    public SpriteRenderer cube;
    public Animator anim;
    public int ninja_anim;
    public int knife_anim;
    public int beast_anim;
    public int dragon_anim;
    public GameObject expuroshon;
    public BoxCollider2D col;
    public AudioSource soniditos;
    public AudioClip ninja_grito_2;
    public AudioClip fantasmas;
    public AudioClip serpientes;
    public AudioClip ninja_grito;
    public AudioClip meteoro;
    public AudioClip metal;
    public int garganta_range;
    public int piña_range;

    void Start()
    {
        enemy_ID = Random.Range(0, 4);
        player = GameObject.FindGameObjectWithTag("player");
        ninja_anim = Random.Range(0, 2);
        knife_anim = Random.Range(2, 4);
        beast_anim = Random.Range(4, 6);
        dragon_anim = Random.Range(6, 8);
        garganta_range = Random.Range(0, 2);
        piña_range = Random.Range(0, 3);
        anim_check();
        x_correct();
        col_adjust();
        
    }

    void Update() 
    {
        SetSpedd(player);
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime); 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "player")
        {
            player_char karateka = other.GetComponent<player_char>();
            if (karateka != null)
            {
                if (karateka.posture_ID == enemy_ID)
                {
                    punch(player);
                    kiai(player);
                    GameObject go = Instantiate(expuroshon, transform.position, Quaternion.identity);
                    Destroy(this.gameObject);
                    Destroy(go, 1f);
                    karateka.score = karateka.score + 1;
                    game_instance.instance.player_score = karateka.score;
                    karateka.attacking(transform.position.x);
                    
                }
                else if (karateka.posture_ID != enemy_ID) { karateka.dead(); }
            }
        }
        else { Debug.Log("the player was not detected"); }
    }

    public void SetSpedd(GameObject other) 
    {
        player_char karateka = other.GetComponent<player_char>();


        if (karateka != null)
        {
            if (speedBool)
            {
                if (karateka.score < 5) { speed = 3f; }
                else if (karateka.score >= 5 && karateka.score <= 10) { speed = 5f; }
                else if (karateka.score > 10 && karateka.score <= 15) { speed = 7f; }
                else if (karateka.score > 15 && karateka.score <= 20) { speed = 9f; }
                else if (karateka.score > 20) { speedBool = false; }
            }
            else { speed = 11f; }
        }
        else { Debug.Log("player is null");  }
    }

    public void anim_check()
    {
        switch (enemy_ID)
        {
            case 0:
                if (ninja_anim == 0) { anim.Play("ninja_patada"); soniditos.clip = ninja_grito; soniditos.Play(); }
                else { anim.Play("ninja_nunchaku"); soniditos.clip = ninja_grito_2; soniditos.Play(); }
                break;
            case 1:
                if (knife_anim == 2) { anim.Play("shuriken"); soniditos.clip = metal; soniditos.Play(); }
                else { anim.Play("cuchillo"); soniditos.clip = metal; soniditos.Play(); }
                break;
            case 2:
                if (beast_anim == 4  || beast_anim == 5) { anim.Play("snake"); soniditos.clip = serpientes; soniditos.Play(); }
                //else { anim.Play("pez_globo"); }
                break;
            case 3:
                if (dragon_anim == 6) { anim.Play("fantasma"); soniditos.clip = fantasmas; soniditos.Play(); }
                else { anim.Play("fireball"); soniditos.clip = meteoro; soniditos.Play(); }
                break;
            default:
                break;
        }   
    }

    public void x_correct()
    {
        if(transform.position.x < 0f)
        {
            if (enemy_ID != 2) { cube.flipX = true; }
            else { cube.flipX = false; }
        }
        else
        {
            if (enemy_ID == 2) { cube.flipX = true; }
            else { cube.flipX = false; }
        }
    }

    public void col_adjust()
    {
        if (col != null)
        {
            if (enemy_ID == 0 && ninja_anim == 0) { col.size = new Vector3(2.8f, 1.8f); }
            else if (enemy_ID == 0 && ninja_anim == 1) { col.size = new Vector3(2.8f, 3f); }
            else if (enemy_ID == 1 && knife_anim == 3) { col.size = new Vector3(3.7f, 1f); }
            else if (enemy_ID == 3 && dragon_anim == 6) { col.size = new Vector3(4f, 3.1f); }
            else if (enemy_ID == 3 && dragon_anim == 7) { col.size = new Vector3(2.5f, 3.1f); }
        }
        else { Debug.Log("Collider is null"); }
    }

    public void punch(GameObject other)
    {
        player_char karateka = other.GetComponent<player_char>();
        if (karateka != null)
        {
            if (piña_range == 0)
            {
                karateka.piña_sonido.clip = karateka.piña_1;
                karateka.piña_sonido.Play();
            }
            if (piña_range == 1)
            {
                karateka.piña_sonido.clip = karateka.piña_2;
                karateka.piña_sonido.Play();
            }
            if (piña_range == 2)
            {
                karateka.piña_sonido.clip = karateka.piña_3;
                karateka.piña_sonido.Play();
            }
        }

    }

    public void kiai(GameObject other)
    {
        player_char karateka = other.GetComponent<player_char>();
        if (karateka != null)
        {
            if (piña_range == 0)
            {
                karateka.garganta.clip = karateka.grito_1;
                karateka.garganta.Play();
            }
            if (piña_range == 1)
            {
                karateka.garganta.clip = karateka.grito_2;
                karateka.garganta.Play();
            }
         }

    }
}
