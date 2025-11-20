
using UnityEngine;
using System.Collections;
using System;


public class player : MonoBehaviour
{

    public GameObject prefabExplosion;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField]float horizontalX;
    [SerializeField]float verticalY;

    [SerializeField] float torque = 20;
    [SerializeField] float velocidadMax = 10;
    [SerializeField] float velocidadAngMax = 5;

    public Transform rotulaAsteroids;

    Rigidbody2D rb;

    public Vector3 inicialPosRotula;

    public GameObject prefabBullet;
    public Transform posBullet;

    public float potencia = 100;
    void Start()
    {


        rb = GetComponent<Rigidbody2D>();

        StartCoroutine(setPointer());
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject balaActual = Instantiate(prefabBullet, posBullet.position, posBullet.rotation);
            balaActual.GetComponent<Rigidbody2D>().linearVelocity = posBullet.up * potencia;

            //Debug.Log("tecla espacio pulsada");
        }
    }





    private void FixedUpdate()
    {
        
    
        horizontalX = Input.GetAxis("Horizontal");
        verticalY = Input.GetAxis("Vertical");

       

        //transform.Translate(transform.right*horizontalX*Time.deltaTime * 100);

        //rb.linearVelocity = new Vector2 (horizontalX, verticalY);

        if (rb.linearVelocity.magnitude < velocidadMax)
        {

            rb.AddForce(transform.up * verticalY * Time.deltaTime * 100);
           

            


        }
        else { 
        
            rb.linearVelocity = rb.linearVelocity.normalized * 0.9f * velocidadMax;
        
        }

      

        rb.AddTorque(-torque * horizontalX);
            //velocidadAngMax = 0.99f * velocidadAngMax;
        if (Mathf.Abs(rb.angularVelocity) > velocidadAngMax)
        {
            if (rb.angularVelocity > 0)
            {

                rb.angularVelocity = velocidadAngMax;

            }
            else
            {

                rb.angularVelocity = -velocidadAngMax;
            }




        }


            //Debug.Log(rb.angularVelocity);

           
    }

    IEnumerator setPointer()
    {
        while (true)
        {
            
            float angle = MathF.Atan2(rb.linearVelocity.y, rb.linearVelocity.x)  * 360/6.28f;

            rotulaAsteroids.eulerAngles = new Vector3(0, 0, angle-90);

           // Debug.Log("Angulo: " + angle);
            yield return null;  
        }


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        Destroy(collision.gameObject);
        Instantiate(prefabExplosion, collision.transform.position, collision.transform.rotation);
        //Destroy(gameObject);
    }
}
