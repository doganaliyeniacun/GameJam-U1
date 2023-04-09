using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class StoryController : MonoBehaviour
{
    public List<GameObject> imgList;
    private GameObject prefab;
    private int imageCounter;

    private void Awake()
    {
        imgList = new List<GameObject>(Resources.LoadAll<GameObject>("ImgPref"));
    }

    private void Start()
    {
        SpawnImg(imageCounter);
    }

    private void Update()
    {
        if (prefab != null && Input.GetMouseButtonDown(0))
        {
            DestroyImg();
        }
    }


    public void SpawnImg(int counter)
    {
        prefab = new GameObject();
        prefab = Instantiate(imgList[counter], transform.position, quaternion.identity);
        MoveImg();

    }

    public void MoveImg()
    {
        Transform transformImg = prefab.transform.GetChild(0).transform.GetChild(0).transform;
        transformImg.DOMoveY(transformImg.position.y - 200, 60);
    }

    public void DestroyImg()
    {        
        imageCounter++;
        if (imageCounter != imgList.Count)
        {
            DestroyStory();
            SpawnImg(imageCounter);
        }
        else
        {
            FinalScene();
            Invoke(nameof(DestroyStory), 0.5f);
        }
    }

    public void FinalScene()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Additive);
    }

    private void DestroyStory()
    {
        Destroy(prefab);
    }


}
