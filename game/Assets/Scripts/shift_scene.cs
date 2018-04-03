using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;//增加命名空间

public class shift_scene : MonoBehaviour
{
    public void OnStartGame(string sceneName)
    {
        SceneManager.LoadScene(1);//1是场景的索引
    }
}