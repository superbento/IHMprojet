using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene: MonoBehaviour
{
    private AsyncOperation mAsyncOperation;
    public GameObject Cube;
    public GameObject Player1;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    // 碰撞开始
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == Player1) {
            mAsyncOperation = SceneManager.LoadSceneAsync("11");
        }
    }
}
