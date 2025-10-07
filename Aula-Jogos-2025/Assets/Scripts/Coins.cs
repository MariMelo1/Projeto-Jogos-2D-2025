using UnityEngine;

public class Coins : MonoBehaviour
{
    public GameManager gameManager;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D colisao)
    {
        if (colisao.CompareTag("Player"))
        {
            gameManager.AddPontos(10);
            Destroy(gameObject);
        }
    }

}
