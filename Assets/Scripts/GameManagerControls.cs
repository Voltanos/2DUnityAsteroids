using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Models;
using UnityEngine.UI;
using System;

public class GameManagerControls : MonoBehaviour
{
    public GameManagerModel model = new GameManagerModel();

    // Start is called before the first frame update
    void Start()
    {
        model.CurrentLevel = 1;
        SpawnAsteroids();
        UpdateLevelUI();

        model.SpaceShip = GameObject.FindWithTag("Player");
        model.UFO = GameObject.FindWithTag("UFO");
    }

    public void UpdateAsteroidCount(int change)
    {
        model.AsteroidCount += change;
        LevelCheck();
    }

    public void LevelCheck()
    {
        if (model.AsteroidCount <= 0)
        {
            Invoke("NewLevel", model.LevelTimer);
        }
    }

    public void NewLevel()
    {
        model.CurrentLevel += 1;
        UpdateLevelUI();
        model.SpaceShip.SendMessage("RespawnSpaceShip");
        SpawnAsteroids();
        model.UFO.SendMessage("DestroyUFO");
    }

    public void SpawnAsteroids()
    {
        int maxAsteroidSpawn = model.BaseAsteroidSpawnCount + model.CurrentLevel;

        for (int i = 0; i < maxAsteroidSpawn; i += 1)
        {
            Instantiate(GetRandomAsteroid(), GetRandomPosition(), Quaternion.identity);
        }
    }

    public Vector3 GetRandomPosition()
    {
        int positionIndex = UnityEngine.Random.Range(0, model.SpawnPositions.Count);
        return model.SpawnPositions[positionIndex];
    }

    public GameObject GetRandomAsteroid()
    {
        int asteroidIndex = UnityEngine.Random.Range(0, model.AsteroidSpawner.Count);
        return model.AsteroidSpawner[asteroidIndex];
    }

    public void UpdateLevelUI()
    {
        model.LevelText.text = String.Format("Level:  {0}", model.CurrentLevel);
    }

    public int GetCurrentLevel()
    {
        return model.CurrentLevel;
    }
}
