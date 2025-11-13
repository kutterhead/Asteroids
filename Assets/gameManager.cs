using System.Collections;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject asteroidPrefab;

    public Transform salidaAsteriod;

    public Transform nave;
    [SerializeField]Vector3 naveAnteriorPos;


    void Start()
    {
        //Instantiate(asteroidPrefab,salidaAsteriod.position,salidaAsteriod.rotation);

        StartCoroutine(suelyaAsteriod());
        naveAnteriorPos = nave.position;
    }

    // Update is called once per frame
   IEnumerator suelyaAsteriod()
    {
        while (true) {
            if (Vector3.Distance(naveAnteriorPos, nave.position)>1f)
            {  
                Vector3 offSet = new Vector3(Random.Range(-10.0f,10.0f),0,0);
                GameObject asteroideActual = Instantiate(asteroidPrefab, salidaAsteriod.position + offSet, salidaAsteriod.rotation);
                asteroideActual.GetComponent<Asteroid>().player = nave;
                naveAnteriorPos = nave.position;
                yield return new WaitForSeconds(1);
            }

            yield return null;
       
        }

        

    }
}
