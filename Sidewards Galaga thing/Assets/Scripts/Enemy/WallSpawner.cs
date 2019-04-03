using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class WallSpawner : MonoBehaviour {

    public WallController wallPrefab;
    public float wallSpawnRate;
    float timeToNextWall;
    public float wallSpace;
    public float wallSpeed;
    private void Start()
    {
        timeToNextWall = wallSpawnRate;
    }
    private void Update()
    {
        timeToNextWall -= Time.deltaTime;
        if (timeToNextWall <= 0f)
        {
            #region Create wall then set all position and speed variables
            GameObject wall = Instantiate(wallPrefab.gameObject, transform);
            var wallController = wall.GetComponent<WallController>();
            wallController.Space = wallSpace;
            Vector3 wallPosition = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0));
            wallPosition.z = 0f;
            wallPosition.x += wallPosition.x * 0.1f;
            wallPosition.y = Random.Range(
                Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + wallController.Space / 2,
                Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - wallController.Space / 2);
            wall.transform.position = wallPosition;
            wallController.speed = wallSpeed;
            timeToNextWall = wallSpawnRate;
            #endregion
        }
    }

}
