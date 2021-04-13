using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Models
{
    [System.Serializable]
    public class GameManagerModel
    {
        #region Properties

        [HideInInspector]
        public GameObject SpaceShip;
        [HideInInspector]
        public GameObject UFO;

        [HideInInspector]
        public int CurrentLevel;
        [HideInInspector]
        public int AsteroidCount;
        public int BaseAsteroidSpawnCount;

        public float LevelTimer;

        public string AsteroidTag;

        public Text LevelText;

        public List<Vector3> SpawnPositions;
        public List<GameObject> AsteroidSpawner;

        #endregion

        #region Constructor

        public GameManagerModel()
        {
            SpaceShip = null;
            UFO = null;
            
            CurrentLevel = 0;
            AsteroidCount = 0;
            BaseAsteroidSpawnCount = 0;

            LevelTimer = 0;

            AsteroidTag = null;

            LevelText = null;

            SpawnPositions = new List<Vector3>();
            AsteroidSpawner = new List<GameObject>();
        }

        #endregion
    }
}
