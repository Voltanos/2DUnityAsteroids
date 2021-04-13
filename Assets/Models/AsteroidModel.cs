using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Models
{
    [System.Serializable]
    public class AsteroidModel
    {
        #region Properties

        public GameObject SmallerAsteroid;
        public GameObject Player;
        public GameManagerControls GameManager;

        public Rigidbody2D RigidBody;

        public float MaxThrust;
        public float MaxTorque;
        public float ScreenTop;
        public float ScreenRight;
        public float ScreenBottom;
        public float ScreenLeft;

        public int Points;

        #endregion

        #region Constructors()

        public AsteroidModel()
        {
            SmallerAsteroid = null;
            Player = null;
            GameManager = null;

            RigidBody = null;

            MaxThrust = 0;
            MaxTorque = 0;
            ScreenTop = 0;
            ScreenRight = 0;
            ScreenBottom = 0;
            ScreenLeft = 0;

            Points = 0;
        }

        #endregion
    }
}
