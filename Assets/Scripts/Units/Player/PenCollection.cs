using UnityEngine;
using TMPro;


public class PenCollection : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pen"))
        {
            Destroy(collision.gameObject);            
            ScoreController.instance.IncrementScore();
            AudioManager.instance.PlaySFX("Collectable");
        }
    }
}
