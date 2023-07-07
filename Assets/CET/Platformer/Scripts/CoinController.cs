using UnityEngine;

namespace CET.Platformer.Scripts
{
    public class CoinController : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.gameObject.CompareTag("Player"))
            {
                GameManager.instance.CollectCoin();
                Destroy(gameObject);
            }
        }
    }
}
