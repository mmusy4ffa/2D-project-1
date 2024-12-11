using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //menambahkan kolom dan fungsi speed untuk menambahkan kecepatan
    [SerializeField] private float speed;
    private Rigidbody2D body;
    private Animator anim;
    private bool grounded;
    
    private void Awake()
    {
        //get untuk mendapatkan akses yang dituju
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        //agar lebih mudah untuk mengambil fungsi float horizontal
        float horizontalInput = Input.GetAxis("Horizontal");

        
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);
        
        //fungsi untuk membalik kanan/kiri player
        if (horizontalInput > 0.01f)
            transform.localScale = Vector2.one;
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1,1,1);

        if (Input.GetKey(KeyCode.W) && grounded)
        jump();



        //pengaturan animasi idle to run
        anim.SetBool("walk", horizontalInput != 0);
        anim.SetBool("grounded", grounded);
    }

    private void jump ()
    {
        body.velocity = new Vector2(body.velocity.x, speed);
        anim.SetTrigger("jump");
        grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground") 
        grounded = true;
    }
}
