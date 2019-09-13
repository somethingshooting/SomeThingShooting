using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UniRx;

/// <summary>
/// すべてのシーンに存在
/// </summary>
public class GameManager : MonoBehaviour
{
    private Subject<SceneType> _NextLoadScene = new Subject<SceneType>();
    /// <summary>
    /// シーンが移動する直前に発行
    /// </summary>
    public IObservable<SceneType> NextLoadScene => _NextLoadScene;

    private void Start()
    {
        //シーン変移の際に破壊しないようにする
        DontDestroyOnLoad(gameObject);
    }

    /// <summary>
    /// シーンの変更
    /// </summary>
    /// <param name="sceneType">変更するシーン</param>
    public void ChangeScene(SceneType sceneType)
    {
        string sceneName = "";
        switch (sceneType)
        {
            case SceneType.Title:
                sceneName = "Title";
                break;
            case SceneType.StageSelect:
                sceneName = "StageSelect";
                break;
            case SceneType.Main_1:
                sceneName = "Main_1";
                break;
            case SceneType.Result:
                sceneName = "Result";
                break;
            default:
                break;
        }
        _NextLoadScene.OnNext(sceneType);
        SceneManager.LoadSceneAsync(sceneName);
    }
}
