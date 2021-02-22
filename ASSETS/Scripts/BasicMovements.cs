using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovements : MonoBehaviour {
   
    //HelathBar
    public int maxHealth = 400;
    public int currentHealth;
    public HealthBar healthBar;
    //Animator
    public Animator animator;
    Rigidbody2D rigid2D;
    //Jump
    public bool isGrounded= false;
    //Death,Restart
    public GameObject gameOverText, restartButton; 

    public float jumpForce = 70.0f;
     void Start()
    {

        gameOverText.SetActive(false);
        restartButton.SetActive(false);
        this.rigid2D = GetComponent<Rigidbody2D>();
        //health bar
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

    }
    // Update is called once per frame
    void Update ()
    {

        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(20);
        }
        

        animator.SetFloat("RunSpeed", Input.GetAxisRaw("Horizontal"));
        Vector3 horizontal = new Vector3(Input.GetAxisRaw("Horizontal"), 0.0f, 0.0f);
        transform.position = transform.position + (horizontal*2) * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded == true) {
            rigid2D.AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse);
            

        }

      
        
        Vector3 characterScale = transform.localScale;
        if (Input.GetAxis("Horizontal")<0) {
            characterScale.x = -0.7553232f;
           
        }

        if (Input.GetAxis("Horizontal") > 0)
        {
            characterScale.x = 0.7553232f;
        }
        transform.localScale = characterScale;

    }

    ////private void FixedUpdate()
    //{
    //    this.rigid2D.velocity =
    ////}

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if (currentHealth == 0)
        {
            gameOverText.SetActive(true);
            restartButton.SetActive(true);
            gameObject.SetActive(false);
            Destroy(rigid2D.gameObject);
            Destroy(healthBar.gameObject);
            Debug.Log("DIE");
            FindObjectOfType<GameManager>().GameOver();

        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Gem"))
        {
            Destroy(other.gameObject);
        }

        
    }

    private void FixedUpdate()
    {
        if (rigid2D.position.y < -1f)
        {
            
            FindObjectOfType<GameManager>().GameOver();
            gameOverText.SetActive(true);
            restartButton.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Enemy")){
            TakeDamage(40);

        }
    }
}
