using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    public static ScoreController instance;
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

    public void IncrementScore()
    {
        count++;
        _text.text = ": " + count.ToString();
    }
}
