using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelectSceneManager : MonoBehaviour
{
    private GameManager _GameManager = null;

    void Start()
    {
        _GameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }

    //Unity.UIのButtonで実行
    public void LoadMainScene(int stageNum)
    {
        switch (stageNum)
        {
            case 1:
                _GameManager.ChangeScene(SceneType.Main_1);
                break;
            default:
                Debug.LogError("そのような番号のステージは存在しません");
                break;
        }
    }
}
