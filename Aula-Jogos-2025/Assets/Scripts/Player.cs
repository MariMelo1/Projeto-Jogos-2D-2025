using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector2 posicaoInicial;
    public GameManager gameManager;

    public Animator anim;
    private Rigidbody2D rigd;
    public float speed;

    ///Pulo
    public float jumpForce;
    public bool isGround;

    void Start()
    {
        anim=GetComponent<Animator>();
        rigd=GetComponent<Rigidbody2D>();
        posicaoInicial = transform.position;
    }

    void Update()
    {
        Move();
        Jump();
    }

    public void ReiniciarPosicao()
    {
        transform.position = posicaoInicial;
    }

    void Move()
    {
        float teclas = Input.GetAxis("Horizontal");
        rigd.linearVelocity = new Vector2(teclas * speed, rigd.linearVelocityY);

        if (teclas > 0 && isGround == true)
        {
            transform.eulerAngles = new Vector2(0, 0);
            anim.SetInteger("transitions", 1);
        }

        if (teclas < 0 && isGround == true)
        {
            transform.eulerAngles = new Vector2(0, 180);
            anim.SetInteger("transitions", 1);
        }

        if (teclas == 0 && isGround == true)
        {
            anim.SetInteger("transitions", 0);
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround == true)
        {
            rigd.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            anim.SetInteger("transitions", 2);
            isGround = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "tagGround")
        {
            isGround = true;
            //Debug.Log("ta funfando");
        }
    }
}