using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public float force = 0.2f;
    public float amplitude;
    public bool isPoweredUp = false;
    public Sprite PowerUpSprite;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        //move player
        if (rb)
        {
            Vector2 newPos = transform.position;
            newPos.x += Input.GetAxis("Horizontal") * force * Time.deltaTime;
            transform.position = newPos;

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {

                GetComponent<SpriteRenderer>().flipX = true;
            }

                if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                {
                        GetComponent<SpriteRenderer>().flipX = false;
                        Debug.Log("hola");
                }
                
        }
        

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

    }
    public void Jump()
    {
        if (rb)
        {  
                rb.AddForce(new Vector2(0, force), ForceMode2D.Impulse);
     
        }
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("saw") && isPoweredUp == false)
        {
            transform.Find("Main Camera").Find("Canvas").Find("Text").GetComponent<Text>().text = "Perdiste!";
            Time.timeScale = 0.0f;
        }
        else if(collision.gameObject.CompareTag("saw") && isPoweredUp)
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("corn"))
        {
            isPoweredUp = true;
            GetComponent<SpriteRenderer>().sprite = PowerUpSprite;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("exit"))
        {
            transform.Find("Main Camera").Find("Canvas").Find("Text").GetComponent<Text>().text = "Ganaste!";
            Time.timeScale = 0.0f;
        }
    }

  
}
