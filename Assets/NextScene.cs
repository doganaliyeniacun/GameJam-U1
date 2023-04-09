using UnityEngine;
using UnityEngine.Events;

public class NextScene : MonoBehaviour
{
    [SerializeField] private UnityEvent sceneEvent; 
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            sceneEvent?.Invoke();
        }
    }

}
