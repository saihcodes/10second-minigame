using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float MoveSpeed, JumpForce;

    public bool Jumping;

    public Rigidbody2D RG2D;

     AudioSource audioSource;
      
    public AudioSource audioPlayer;
     public AudioClip bgMuse;

    private bool gameOver = false;

     public GameObject winTextObject;
    public GameObject loseTextObject;
    public AudioClip WinClip;
    public AudioClip LoseClip;
    public AudioClip Jumpsound; 
   
 
    // Start is called before the first frame update
    void Start()
    {
     

    winTextObject.SetActive(false);
       loseTextObject.SetActive(false);

        RG2D = GetComponent<Rigidbody2D>();

        MoveSpeed = 6f;
        JumpForce = 5f;

        Jumping = true;

    }

    // Update is called once per frame
    void Update()
    {
      float MovX = Input.GetAxisRaw("Horizontal");
      float MovY = Input.GetAxisRaw("Vertical");
       //Horizontal Movement
       if(MovX !=0)
       {
        RG2D.velocity = new Vector2(MoveSpeed * MovX, RG2D.velocity.y);
       }

       //Jumping
       if(MovY == 1 && !Jumping)
       {
        RG2D.velocity = new Vector2(RG2D.velocity.x, JumpForce);
        Jumping = true;
        audioSource.clip = Jumpsound;
        audioSource.Play();
       }

       

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Jumping = false;

    if (col.gameObject.tag.Equals("Bullet"))
    {
        Destroy (col.gameObject);
        Destroy (gameObject);
        gameOver = true;
       loseTextObject.SetActive(true);
       winTextObject.SetActive(false);
        audioSource.clip = bgMuse;
            audioSource.Stop();
            audioSource.clip = LoseClip;
            audioSource.Play();
     
    }
    }

    




}