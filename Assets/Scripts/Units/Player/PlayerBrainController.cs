using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBrainController : MonoBehaviour
{
    [SerializeField] private Image brainbarSprite;
    [SerializeField] private float maxBrainHealth;
    private float currentBrainHealth;

    private void Awake()
    {
        currentBrainHealth = maxBrainHealth;
    }

    private void Start()
    {
        UpdateBrainBar(maxBrainHealth, currentBrainHealth);
    }

    private void Update()
    {
        if (0f >= currentBrainHealth)
        {
            GameController.instance.RestartScene();
            PenCollection.instance.count = 0;
        }
    }

    public void TakeDamage(float damage)
    {
        currentBrainHealth -= damage;
        UpdateBrainBar(maxBrainHealth, currentBrainHealth);
    }
    
    private void UpdateBrainBar(float maxBrain, float currentBrain)
    {
        brainbarSprite.DOFillAmount(currentBrain / maxBrain, 1);
    }
}
