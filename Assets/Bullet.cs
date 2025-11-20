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
        Destroy(collision.gameObject);
        Instantiate(prefabExplosion,transform.position, transform.rotation);
        Destroy(gameObject);
    }
    /*public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collider normal: " + collision.gameObject.tag);

    }*/
}
