using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Models;
using Assets.Helpers;

public class AsteroidsControls : MonoBehaviour
{
	public AsteroidModel model = new AsteroidModel();

	private readonly IScreenHelper _screenHelper = new ScreenHelper();

	// Use this for initialization
	public void Start()
	{
		Vector2 thrust = new Vector2(Random.Range(-model.MaxThrust, model.MaxThrust), Random.Range(-model.MaxThrust, model.MaxThrust));
		float torque = Random.Range(-model.MaxTorque, model.MaxTorque);

		model.RigidBody.AddForce(thrust);
		model.RigidBody.AddTorque(torque);

		//Find the player.
		model.Player = GameObject.FindWithTag("Player");
		model.GameManager = GameObject.FindObjectOfType<GameManagerControls>();

		model.GameManager.UpdateAsteroidCount(1);
	}
	
	// Update is called once per frame
	public void Update()
	{
		transform.position = _screenHelper.AdjustPositionForScreen(transform.position, model.ScreenTop, model.ScreenRight, model.ScreenBottom, model.ScreenLeft);
	}

	public void OnTriggerEnter2D(Collider2D other)
    {
		if (!other.CompareTag("Bullet"))
        {
			return;
        }

		Destroy(other.gameObject);

		if (model.SmallerAsteroid != null)
        {
			Instantiate(model.SmallerAsteroid, transform.position, transform.rotation);
			Instantiate(model.SmallerAsteroid, transform.position, transform.rotation);
		}

		//Get SpaceShip.component and add Asteroid.score to SpaceShip.component.score.
		model.Player.SendMessage("ScorePoints", model.Points);

		model.GameManager.UpdateAsteroidCount(-1);
		Destroy(gameObject);
    }
}
