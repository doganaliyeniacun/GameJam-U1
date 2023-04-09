using UnityEngine;
using TMPro;


public class PenCollection : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    public static PenCollection instance;
    public int count = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject.transform.root.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pen"))
        {
            count++;
            Destroy(collision.gameObject);
            _text.text = ": " + count.ToString();
            AudioManager.instance.PlaySFX("Collectable");
        }
    }
}
