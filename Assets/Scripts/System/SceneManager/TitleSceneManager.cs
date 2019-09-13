using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class TitleSceneManager : MonoBehaviour
{
    [SerializeField] private GameObject _GameManagerObject = null;
    private GameManager _GameManager = null;

    void Start()
    {
        //GameManagerが存在しなければ生成する
        if (GameObject.FindWithTag("GameManager") == null) { Instantiate(_GameManagerObject); }
        _GameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();

        //Spaceキーが押されたときにLoadStageSelectSceneを走らせる
        this.UpdateAsObservable()
            .Where(_ => Input.GetKeyDown(KeyCode.Space))
            .Subscribe(_ => LoadStageSelectScene());

    }

    //ステージセレクトシーンに変移する
    private void LoadStageSelectScene()
    {
        _GameManager.ChangeScene(SceneType.StageSelect);
    }
}
