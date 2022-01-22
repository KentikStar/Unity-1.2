using System.Collections.Generic;
using UnityEngine;

public class gameManag : MonoBehaviour
{
    private int killsCount;
    private int stageGame;
    [SerializeField] private List<int> countEnemy;
    [SerializeField] private PlayerControl playerControl;
    [SerializeField] GameObject canvas;
        
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && stageGame == 0)
        {
            canvas.SetActive(false);
            NextPoint();
        }
    }

    private void NextPoint()
    {
        killsCount = 0;
        stageGame++;
        playerControl.GoNextWayPoint();
    }

    public void TapToPlay()
    {
        stageGame = 1;
    }

    public void killEnemy()
    {
        killsCount++;
        Debug.Log(killsCount);

        if (countEnemy[stageGame] == killsCount)
        {
            NextPoint();
        }
    }
}
