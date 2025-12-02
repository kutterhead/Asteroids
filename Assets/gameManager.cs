using System.Collections;
using UnityEngine;
using System;

public class gameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject asteroidPrefab;
    public GameObject enemyPrefab;

    public Transform salidaAsteriod;

    public Transform nave;
    [SerializeField]Vector3 naveAnteriorPos;

    public static Action restaVida;
    void Start()
    {
        //Instantiate(asteroidPrefab,salidaAsteriod.position,salidaAsteriod.rotation);

        StartCoroutine(suelyaAsteriod());
        naveAnteriorPos = nave.position;
    }

    public void restarVida()
    {
        restaVida?.Invoke();

    }


    // Update is called once per frame
   IEnumerator suelyaAsteriod()
    {
        while (true) {
            if (Vector3.Distance(naveAnteriorPos, nave.position)>1f)
            {
                Vector3 offSet = new Vector3(UnityEngine.Random.Range(-10.0f, 10.0f), 0, 0);
                GameObject tempObject;
                if (UnityEngine.Random.Range(0,100)>50)
                {
                    tempObject = enemyPrefab;
                  


                  

                }
                else
                {
                    tempObject = asteroidPrefab;
                  


                   
                }

                Instantiate(tempObject, salidaAsteriod.position + offSet, salidaAsteriod.rotation);






                naveAnteriorPos = nave.position;
                yield return new WaitForSeconds(1);
            }

            yield return null;
       
        }

        

    }
}
