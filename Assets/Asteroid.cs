using UnityEngine;

public class Asteroid : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    public GameObject[] asteroides;
    void Start()
    {

        int indiceRandom = Random.Range(0, asteroides.Length);
       for(int i = 0; i< asteroides.Length;i++)
        {

            asteroides[i].SetActive(false);
        }
        asteroides[indiceRandom].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
