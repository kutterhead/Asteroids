using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

   

    public Slider lifeSlide;
    public float life = 1f;

    void Start()
    {
        lifeSlide.value = life;
        gameManager.restaVida += restaVida;
    }

    public void restaVida()
    {
        
        life -= 0.1f;
        lifeSlide.value = life;

    }
}
