using UnityEngine;
using System.Collections;


public class Asteroid : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    public GameObject[] asteroides;

    public Transform player;

    void Start()
    {

        int indiceRandom = Random.Range(0, asteroides.Length);
        for (int i = 0; i < asteroides.Length; i++)
        {

            asteroides[i].SetActive(false);
        }
        asteroides[indiceRandom].SetActive(true);
        StartCoroutine(checkDistance());
    }

    // Update is called once per frame
    IEnumerator checkDistance()
    {
        while (true)
        {
            if (Vector3.Distance(transform.position, player.position)>50)
            {

                Destroy(gameObject);
            }
            yield return new WaitForSeconds(2f);
        }
    }
}