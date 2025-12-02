using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject prefabExplosion;
    void Start()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        Instantiate(prefabExplosion,transform.position, transform.rotation);


        if (!collision.gameObject.CompareTag("Player"))
        {

            Destroy(collision.gameObject);

        }
        
            Destroy(gameObject);//esta es la bala
    }
    /*public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collider normal: " + collision.gameObject.tag);

    }*/
}
