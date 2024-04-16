using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    // Start is called before the first frame update
    public Level level;
    private int amountBotOnMap = 3;
    private int amountBo = 50;
    public Bot botPrefab;
    private List<Bot> bots = new List<Bot>();

    private void Start()
    {
        OnInit();
    }
    private void OnInit()
    {
        for (int i = 0; i < amountBotOnMap; i++)
        {
            Vector3 spawnPos = LevelManager.Ins.level.listSpawnPos[i].position;
            SpawnBot(spawnPos);
        }
    }
    private void SpawnEnemy()
    {

    }
    public void SpawnBot(Vector3 spawnPos)
    {

        Bot botClone = Instantiate(botPrefab, spawnPos, Quaternion.identity);
        bots.Add(botClone);
    }


}
