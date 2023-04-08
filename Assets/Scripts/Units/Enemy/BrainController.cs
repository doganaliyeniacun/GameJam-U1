using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class BrainController : MonoBehaviour
{
    [SerializeField] private Image brainbarSprite;
    [SerializeField] private float maxBrainHealth;
    [SerializeField] private EnemyAI enemyAI; 
    private float currentBrainHealth;

    private void Start()
    {
        UpdateBrainBar(maxBrainHealth, currentBrainHealth);
    }

    private void Update()
    {
        Vector2 brainBarDirection = transform.localScale;
        brainbarSprite.transform.localScale = brainBarDirection;

        if (maxBrainHealth == currentBrainHealth)
        {
            enemyAI.brainless = false;
        }
    }

    public void TakeDamage(float damage)
    {

        currentBrainHealth += damage;
        UpdateBrainBar(maxBrainHealth, currentBrainHealth);

    }
    private void UpdateBrainBar(float maxBrain, float currentBrain)
    {
        brainbarSprite.DOFillAmount(currentBrain / maxBrain, 1);
    }
}
