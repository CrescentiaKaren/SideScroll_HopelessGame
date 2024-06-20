using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1f;
    public float jumpForce = 3f;
    
    private Rigidbody2D rb;
   
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        // Ambil komponen rigidbody dari objek player
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    #region AnimationHandler
    private Animator animator;
    private void PlayWalk()
    {
        animator.SetTrigger("goWalk");
    }
    private void PlayJump()
    {
        animator.SetTrigger("goJump");
    }
#endregion

		//sprite flip ini berguna untuk mengubah hadapan player
    private void SpriteFlip(float horizontalInput)
    {
        if (horizontalInput < 0) 
        {
            spriteRenderer.flipX = false;
        }  
        else 
        {
            spriteRenderer.flipX = true;
        }
    }



    void FixedUpdate()
    {
        // Menggerakan player ke kanan atau kiri menggunakan transform.translate
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(new Vector3(horizontalInput * speed * Time.deltaTime, 0f, 0f));
        SpriteFlip(horizontalInput);
 
    
        // Mengaktifkan lompatan player jika player menyentuh tanah
        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "Finish") {
             SceneManager.LoadSceneAsync("Menu");
        }
    }
}