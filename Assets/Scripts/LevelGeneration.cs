using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    public GameObject Pipe;
    public GameObject Level;
    public GameObject HealthCapsule;
    public GameObject OpenPath;
    public GameObject BlockedPath;
    public GameObject Coin;
    public int pipeWallsAmount = 10;
    public bool inMainMenu = true;

    private List<GameObject> spawnList = new List<GameObject>();
    private Transform _localItem;

    private int _planeSpawnOffset = 150;
    private void Awake()
    {
        spawnList.Add(Instantiate(Level, new Vector3(0, 0, 0), Quaternion.identity));
        if (!inMainMenu)
        {
            GenerateWallOfObjects(0);
        }
    }

    public void GeneratePlatform()
    {
        spawnList.Add(Instantiate(Level, new Vector3(0, 0, _planeSpawnOffset), Quaternion.identity));
        if (!inMainMenu) {
            GenerateWallOfObjects(spawnList.Count -1);
        }
        _planeSpawnOffset += 150;
    }

    public void DestroyPlatform()
    {
        if (!inMainMenu) {
            Destroy(spawnList[0]);
            spawnList.Remove(spawnList[0]);
        }
    }

    private void GenerateWallOfObjects(int i)
    {
        _localItem = spawnList[i].transform;
        int WallOffsetZ = 0;
        for (int j = 0; WallOffsetZ < 150; j++) {
            WallOffsetZ += Random.Range(25, 50);
            if (WallOffsetZ > 150) { return; }
            SpawnFenceOnLevelEdges(WallOffsetZ);

            for (float levelEdgeX = -5.9643f; levelEdgeX < 5.9643f; levelEdgeX += 2.3857f) {
                int objectSpawnRandomizer = Random.Range(1, 7);
                switch (objectSpawnRandomizer) {
                    case <= 3:
                        SpawnObject(levelEdgeX, WallOffsetZ, Pipe);
                        break;
                    case 4:
                        SpawnObject(levelEdgeX, WallOffsetZ, OpenPath);
                        break;
                    case >=5:
                        SpawnObject(levelEdgeX, WallOffsetZ, BlockedPath);
                        break;
                }
            }
        }
    }
    private void SpawnObject(float _x, float _z,GameObject gameObject)
    {
        int coinSpawnChance = Random.Range(0, 7);
        if (gameObject == Pipe && coinSpawnChance == 0) {
            GameObject pipeWithCoin = Instantiate(gameObject, _localItem.position + new Vector3(_x, 0, _z),
                Quaternion.identity, _localItem);
            Instantiate(Coin, _localItem.position + new Vector3(_x, 0, _z),
                Quaternion.identity, pipeWithCoin.transform);
        }
        else {
            Instantiate(gameObject, _localItem.position + new Vector3(_x, 0, _z),
                Quaternion.identity, _localItem);
        }

        int healthSpawnerAmount = Random.Range(1, 15);
        int offsetZ = 0;
        for (int i = 1; i < healthSpawnerAmount; i++) {
            int healthSpawnerSwitch = Random.Range(0, 2);
            offsetZ += 5;
            if (healthSpawnerSwitch == 0) { return; } 
                Instantiate(HealthCapsule, _localItem.position + new Vector3(_x, 0, _z - offsetZ),
                    Quaternion.identity, _localItem);
        }
    }
    private void SpawnFenceOnLevelEdges(float z)
    {
        float x = -8.36f;
        for (int i = 0; i < 2; i++) {
        Instantiate(BlockedPath, _localItem.position + new Vector3(x, 0, z),
                Quaternion.identity, _localItem);
            x = -x; }
    }
}
