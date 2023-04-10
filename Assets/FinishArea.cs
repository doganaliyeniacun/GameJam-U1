
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishArea : MonoBehaviour
{
    [SerializeField] private GameObject finishScene;
    private bool collided = false;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && finishScene)
        {
            Time.timeScale = 0f;
            finishScene.SetActive(true);
            MoveImg();
            collided = true;
        }
    }

    private void Update()
    {
        if (collided && finishScene != null && Input.GetMouseButtonDown(0))
        {
            HideImgAndRestarGame();
            Time.timeScale = 1f;
            collided = false;
        }
    }

    public void HideImgAndRestarGame()
    {
        finishScene.SetActive(false);
        SceneManager.LoadScene(1);
    }

    public void MoveImg()
    {
        Transform transformImg = finishScene.transform.GetChild(0).transform.GetChild(0).transform;
        transformImg.DOMoveY(transformImg.position.y - 200, 60);
    }
}
