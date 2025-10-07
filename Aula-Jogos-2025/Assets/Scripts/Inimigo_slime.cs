using UnityEngine;

public class Inimigo_slime : MonoBehaviour
{
    public GameManager gameManager;
    void Start()
    {
    }
    void Update()
    {
        
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameManager.PerderVidas(1);
        }
    }
}
