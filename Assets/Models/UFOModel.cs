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
    public class UFOModel
    {
        #region Properties

        public GameObject Bullet;

        public SpriteRenderer SpriteRenderer;
        public CircleCollider2D CircleCollider;

        [HideInInspector]
        public Transform SpaceShipTransform;
        [HideInInspector]
        public SpriteRenderer SpaceShipSpriteRenderer;
        [HideInInspector]
        public GameObject Player;

        [HideInInspector]
        public GameManagerControls GameManager;

        public Rigidbody2D RigidBody;

        public Vector2 Direction;

        public List<Vector3> SpawnPositions;

        public float Speed;
        public float ShootingDelay;
        [HideInInspector]
        public float LastTimeShot;
        public float BulletForce;
        public float BulletLifespan;
        //[HideInInspector]
        public float SpeedBase;
        //[HideInInspector]
        public float BulletForceBase;
        //[HideInInspector]
        public int PointsBase;
        public float MinUFOTimer;
        public float MaxUFOTimer;
        public float ScreenTop;
        public float ScreenRight;
        public float ScreenBottom;
        public float ScreenLeft;

        public int Points;
        [HideInInspector]
        public int CurrentLevel;

        #endregion

        #region Constructors

        public UFOModel()
        {
            Bullet = null;

            SpriteRenderer = null;
            CircleCollider = null;

            SpaceShipTransform = null;
            SpaceShipSpriteRenderer = null;
            Player = null;

            GameManager = null;

            RigidBody = null;

            Direction = new Vector2();

            SpawnPositions = new List<Vector3>();

            Speed = 0;
            ShootingDelay = 0;
            LastTimeShot = 0;
            BulletForce = 0;
            BulletLifespan = 0;
            SpeedBase = 0;
            BulletForceBase = 0;
            PointsBase = 0;
            MinUFOTimer = 0;
            MaxUFOTimer = 0;
            ScreenTop = 0;
            ScreenRight = 0;
            ScreenBottom = 0;
            ScreenLeft = 0;

            Points = 0;
            CurrentLevel = 0;
        }

        #endregion
    }
}
