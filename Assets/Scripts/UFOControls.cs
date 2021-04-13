using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Models;
using Assets.Helpers;

public class UFOControls : MonoBehaviour
{
    public UFOModel model = new UFOModel();

    private readonly IScreenHelper _screenHelper = new ScreenHelper();

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        model.SpaceShipTransform = player.transform;
        model.SpaceShipSpriteRenderer = player.GetComponent<SpriteRenderer>();
        model.Player = player;
        model.GameManager = GameObject.FindObjectOfType<GameManagerControls>();

        NewSpawnPosition();
        SetUFOSpawnTimer();
        SetUFOState(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (IsDisabled())
        {
            return;
        }

        float angle = Mathf.Atan2(model.Direction.y, model.Direction.x) * Mathf.Rad2Deg - 90;
        model.RigidBody.MoveRotation(angle);

        transform.position = _screenHelper.AdjustPositionForScreen(transform.position, model.ScreenTop, model.ScreenRight, model.ScreenBottom, model.ScreenLeft);

        FireBullet();
    }

    public void FireBullet()
    {
        if (Time.time > model.LastTimeShot + model.ShootingDelay && model.SpaceShipSpriteRenderer.enabled)
        {
            model.LastTimeShot = Time.time;

            GameObject newBullet = Instantiate(model.Bullet, transform.position, transform.rotation);
            newBullet.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * model.BulletForce);

            Destroy(newBullet, model.BulletLifespan);
        }
    }

    public void FixedUpdate()
    {
        if (IsDisabled())
        {
            return;
        }

        model.Direction = (model.SpaceShipTransform.position - transform.position).normalized;
        model.RigidBody.AddRelativeForce(Vector2.up * model.Speed);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Bullet"))
        {
            return;
        }

        DestroyUFO();
        model.Player.SendMessage("ScorePoints", model.Points);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.transform.CompareTag("Player"))
        {
            return;
        }

        DestroyUFO();
        model.Player.SendMessage("ScorePoints", model.Points);
    }

    public void DestroyUFO()
    {
        NewSpawnPosition();
        SetUFOSpawnTimer();
        SetUFOState(false);
    }

    public void SetUFOState(bool state)
    {
        model.SpriteRenderer.enabled = state;
        model.CircleCollider.enabled = state;
    }

    public void NewSpawnPosition()
    {
        int positionIndex = UnityEngine.Random.Range(0, model.SpawnPositions.Count);
        transform.position = model.SpawnPositions[positionIndex];
    }

    public void UpdateStatsBasedOnLevel()
    {
        model.CurrentLevel = model.GameManager.GetCurrentLevel();
        int levelAdjustment = (model.CurrentLevel - 1);

        model.Speed = (0.05f * levelAdjustment) + model.SpeedBase;
        model.BulletForce = (250f * levelAdjustment) + model.BulletForceBase;
        model.Points = (500 * levelAdjustment) + model.PointsBase;
    }

    public void SetUFOSpawnTimer()
    {
        Invoke("EnableUFO", GetUFOSpawnTimer());
    }

    public float GetUFOSpawnTimer()
    {
        float maxRange = model.MaxUFOTimer - model.CurrentLevel;

        if (maxRange <= model.MinUFOTimer)
        {
            maxRange = model.MinUFOTimer;
        }

        return UnityEngine.Random.Range(model.MinUFOTimer, maxRange);
    }

    public void EnableUFO()
    {
        UpdateStatsBasedOnLevel();
        SetUFOState(true);
    }

    internal bool IsDisabled()
    {
        return (
                !model.SpriteRenderer.enabled &&
                !model.CircleCollider.enabled
            );
    }
}
