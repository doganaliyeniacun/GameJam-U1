using UnityEngine;

public class NextScene : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameController.instance.NextScene(1);
        }
    }

}
