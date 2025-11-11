
using UnityEngine;


public class player : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField]float horizontalX;
    [SerializeField]float verticalY;

    [SerializeField] float torque = 20;
    [SerializeField] float velocidadMax = 10;
    [SerializeField] float velocidadAngMax = 5;

    Rigidbody2D rb;
    
    void Start()
    {


        rb = GetComponent<Rigidbody2D>();


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

            Debug.Log("velocidad: " + rb.linearVelocity.magnitude);
    }



}
