using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Services;
using Assets.Models;
using Assets.Helpers;
using System.Text;
using System;
using UnityEngine.SceneManagement;

public class SpaceShipControls : MonoBehaviour
{
	//private readonly ISpaceShipService _spaceShipService = new SpaceShipService();

	public SpaceShipModel model = new SpaceShipModel();

	private readonly IScreenHelper _screenHelper = new ScreenHelper();

	// Use this for initialization
	public void Start()
	{
		UpdateScoreUI();
		UpdateLivesUI();
	}
	
	// Update is called once per frame
	public void Update()
	{
		model.ThrustInput = Input.GetAxis("Vertical");
		model.TurnInput = Input.GetAxis("Horizontal");

		BulletFire();
		Hyperspace();

		transform.position = _screenHelper.AdjustPositionForScreen(transform.position, model.ScreenTop, model.ScreenRight, model.ScreenBottom, model.ScreenLeft);

		transform.Rotate(Vector3.forward * -model.TurnInput * Time.deltaTime * model.TurnThrust);
	}

	public void Hyperspace()
    {
		if (Input.GetButtonDown("Hyperspace") && model.SpriteRenderer.enabled)
        {
			HideSpaceShip();
			Invoke("Teleport", model.TeleportTimer);
		}
    }

	public void Teleport()
    {
		transform.position = new Vector3(UnityEngine.Random.Range(model.SpawnRangeMinX, model.SpawnRangeMaxX), UnityEngine.Random.Range(model.SpawnRangeMinY, model.SpawnRangeMaxY));
		model.SpriteRenderer.enabled = true;
		model.Collider2D.enabled = true;
	}

	public void BulletFire()
	{
		if (Input.GetButtonDown("Fire1") && model.SpriteRenderer.enabled)
		{
			GameObject newBullet = Instantiate(model.Bullet, transform.position, transform.rotation);
			newBullet.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * model.BulletForce);

			Destroy(newBullet, model.BulletLifespan);
		}
	}

	public void FixedUpdate()
	{
		model.RigidBody.AddRelativeForce(Vector2.up * model.ThrustInput);
		//model.RigidBody.AddTorque(-model.TurnInput);
	}

	public void OnTriggerEnter2D(Collider2D other)
	{
		if (!other.CompareTag("Beam"))
		{
			return;
		}

		SpaceShipHit();
	}

	public void OnCollisionEnter2D(Collision2D col)
    {
		if (col.relativeVelocity.magnitude > model.DeathForce)
        {
			SpaceShipHit();
		}
    }

	public void SpaceShipHit()
    {
		model.Lives -= 1;
		UpdateLivesUI();
		HideSpaceShip();

		if (model.Lives <= 0)
		{
			GameOver();
		}

		else
		{
			Invoke("RespawnSpaceShip", model.RespawnTimer);
		}
	}

	public void GameOver()
    {
		model.GameOverPanel.SetActive(true);
    }

	public void PlayAgain()
    {
		SceneManager.LoadScene("Space");
    }

	public void ScorePoints(int points)
    {
		model.Score += points;
		UpdateScoreUI();
	}

	public void HideSpaceShip()
    {
		model.SpriteRenderer.enabled = false;
		model.Collider2D.enabled = false;
	}

	public void RespawnSpaceShip()
    {
		transform.position = new Vector3(0, 0);
		model.RigidBody.velocity = Vector2.zero;

		model.SpriteRenderer.enabled = true;
		model.SpriteRenderer.color = model.InvisibleColor;
		Invoke("EnableCollider", model.RespawnTimer);
	}

	public void EnableCollider()
    {
		model.SpriteRenderer.color = model.NormalColor;
		model.Collider2D.enabled = true;
	}

	public void UpdateScoreUI()
    {
		model.ScoreText.text = String.Format("Score:  {0}", model.Score);
	}

	public void UpdateLivesUI()
    {
		model.LivesText.text = String.Format("Lives:  {0}", model.Lives);
	}
}
