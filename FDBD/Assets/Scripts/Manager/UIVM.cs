using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugManager;

// MVVM 패턴을 위한 View Model

public class UIVM : MonoBehaviour
{
    // Model
    private EnemyController emModel;
    private UIManager uiModel;

    public void Start()
    {
        emModel = GameManager.Instance.enemyController;
        uiModel = GameManager.Instance.UIManager;

        // main ui
        GameManager.Instance.checkGameStart += HandleGameUI;
        GameManager.Instance.checkRoundStart += HandleRoundUI;
        GameManager.Instance.checkRoundTime += HandleRoundTimer;

        // ingame ui
        emModel.OnEnemyCountChanged += HandleEnemyCountChanged;
    }

    private void HandleEnemyCountChanged(int count)
    {
        uiModel.UpdateEnemyCount(count);
    }

    private void HandleGameUI(bool isGameStart)
    {
        if (isGameStart)
            uiModel.GameInit();
        else
            uiModel.GameEnd();
    }

    private void HandleRoundUI(bool isRoundStart)
    {
        if(isRoundStart)
            uiModel.RoundInit();
        else
            uiModel.RoundEnd();
    }

    private void HandleRoundTimer(float time)
    {
        uiModel.UpdateTimer(time);
    }

    private void OnEnable()
    {
        // 이벤트 해제
    }
}
