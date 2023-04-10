using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerBrainController : MonoBehaviour
{
    [SerializeField] private Image brainbarSprite;
    [SerializeField] private float maxBrainHealth;
    [SerializeField] private GameObject gameoverImg;
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
            

            if (gameoverImg != null)
            {
                gameoverImg.SetActive(true);
                Time.timeScale = 0f;
            }

            if (gameoverImg != null && Input.GetMouseButtonDown(0))
            {
                HideImgAndRestarGame();
                Time.timeScale = 1f;
            }
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

    public void HideImgAndRestarGame()
    {
        gameoverImg.SetActive(false);
        GameController.instance.RestartScene();
    }

    public void MoveImg()
    {
        Transform transformImg = gameoverImg.transform.GetChild(0).transform.GetChild(0).transform;
        transformImg.DOMoveY(transformImg.position.y - 200, 60);
    }
}
