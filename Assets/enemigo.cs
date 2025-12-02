using UnityEngine;
using System.Collections;

public class enemigo : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject prefabBala;
    public Transform spawner;
    public Transform player;

    [Range(0f, 100f)]
    public float potencia = 10f;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        Invoke(nameof(dispara),1f);
        StartCoroutine(checkDistance());

        GetComponent<Rigidbody2D>().linearVelocity = transform.up * Random.Range(1f,5f);

    }


    void dispara()
    {
        GameObject bala = Instantiate(prefabBala, spawner.position, spawner.rotation);
        bala.GetComponent<Rigidbody2D>().linearVelocity = spawner.up * potencia;
        Destroy(bala,5f);
        Invoke(nameof(dispara), Random.Range(0.5f,4f));


    }


    IEnumerator checkDistance()
    {
        while (true)
        {
            if (!transform)
            {
                break;
            }

            if (Vector3.Distance(transform.position, player.position) > 50)
            {

                Destroy(gameObject);
            }
            yield return new WaitForSeconds(2f);
        }
    }

}
