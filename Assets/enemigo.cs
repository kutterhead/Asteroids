using UnityEngine;

public class enemigo : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject prefabBala;
    public Transform spawner;

    [Range(0f, 100f)]
    public float potencia = 10f;
    
    void Start()
    {


        Invoke(nameof(dispara),1f);
    }


    void dispara()
    {
        GameObject bala = Instantiate(prefabBala, spawner.position, spawner.rotation);
        bala.GetComponent<Rigidbody2D>().linearVelocity = spawner.up * potencia;
        Destroy(bala,5f);
        Invoke(nameof(dispara), 1f);
    }


}
