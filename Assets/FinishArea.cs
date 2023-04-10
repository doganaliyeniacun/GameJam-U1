
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishArea : MonoBehaviour
{
    [SerializeField] private GameObject finishScene;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && finishScene)
        {
            Time.timeScale = 0f;
            finishScene.SetActive(true);
            MoveImg();
        }
    }

    private void Update()
    {
        if (finishScene != null && Input.GetMouseButtonDown(0))
        {
            HideImgAndRestarGame();
            Time.timeScale = 1f;
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
