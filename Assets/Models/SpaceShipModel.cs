using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Models
{
	[System.Serializable]
	public class SpaceShipModel
	{
		#region Properties

		public Rigidbody2D RigidBody;
		public SpriteRenderer SpriteRenderer;
		public Collider2D Collider2D;

		public float Thrust;
		public float TurnThrust;
		public float ScreenTop;
		public float ScreenBottom;
		public float ScreenLeft;
		public float ScreenRight;

		public float SpawnRangeMinX;
		public float SpawnRangeMaxX;
		public float SpawnRangeMinY;
		public float SpawnRangeMaxY;

		[HideInInspector]
		public float ThrustInput;
		[HideInInspector]
		public float TurnInput;

		public float BulletForce;
		public float BulletLifespan;
		public float DeathForce;
		public float RespawnTimer;
		public float TeleportTimer;

		public GameObject Bullet;
		public GameObject GameOverPanel;

		public Text ScoreText;
		public Text LivesText;

		[HideInInspector]
		public int Score;

		public int Lives;

		public Color InvisibleColor;
		public Color NormalColor;

		#endregion

		#region Constructors

		public SpaceShipModel()
		{
			RigidBody = null;
			SpriteRenderer = null;
			Collider2D = null;

			Thrust = 0;
			TurnThrust = 0;
			ScreenTop = 0;
			ScreenBottom = 0;
			ScreenLeft = 0;
			ScreenRight = 0;
			ThrustInput = 0;
			TurnInput = 0;
			BulletForce = 0;
			BulletLifespan = 0;
			DeathForce = 0;
			RespawnTimer = 0;
			TeleportTimer = 0;

			SpawnRangeMinX = 0;
			SpawnRangeMaxX = 0;
			SpawnRangeMinY = 0;
			SpawnRangeMaxY = 0;

			Bullet = null;
			GameOverPanel = null;

			Score = 0;
			Lives = 0;

			ScoreText = null;
			LivesText = null;

			InvisibleColor = new Color();
			NormalColor = new Color();
		}

		#endregion
	}
}

