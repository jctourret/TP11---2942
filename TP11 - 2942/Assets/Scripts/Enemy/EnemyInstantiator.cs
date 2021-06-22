using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
struct EnemySpawn
{
    public enum EnemyType { BOSS, NORMAL, PATROL };
    public enum ScreenPosition { MID, LEFT, RIGHT, FAR_LEFT, FAR_RIGHT };

    public EnemyType type;
    public ScreenPosition pos;
    public float minute;
    public float second;
    public float spawnTimeInSeconds { get { return minute * 60 + second; } }

    public Vector3 GetVec3Position(float nearPos, float farPos, float yPos)
    {
        Vector3 position = new Vector3(0, yPos, 0); ;
        switch (pos)
        {
            case ScreenPosition.LEFT:
                position.x = -nearPos;
                break;
            case ScreenPosition.RIGHT:
                position.x = nearPos;
                break;
            case ScreenPosition.FAR_LEFT:
                position.x = -farPos;
                break;
            case ScreenPosition.FAR_RIGHT:
                position.x = farPos;
                break;
            default:
                break;
        }
        return position;
    }
    public static int SortBySpawnTime(EnemySpawn enemy1, EnemySpawn enemy2)
    {
        return enemy1.spawnTimeInSeconds.CompareTo(enemy2.spawnTimeInSeconds);
    }
}

public class EnemyInstantiator : MonoBehaviour
{
    [SerializeField] List<GameObject> _enemyTemplates;
    [SerializeField] float _yPosition;
    [SerializeField] float _nearDistance;
    [SerializeField] float _farDistance;
    [SerializeField] Transform _player;
    [SerializeField] List<EnemySpawn> _enemies;

    private void Start()
    {
        _enemies.Sort(EnemySpawn.SortBySpawnTime);
    }

    private void Update()
    {
        if (_enemies[0].spawnTimeInSeconds > Time.time) { return; }
        InstatiateEnemy(_enemies[0]);
    }

    void InstatiateEnemy(EnemySpawn enemy)
    {
        _enemies.Remove(enemy);
     
        GameObject enemyGO = Instantiate(_enemyTemplates[(int)enemy.type]);
        enemyGO.transform.position = enemy.GetVec3Position(_nearDistance, _farDistance, _yPosition);

        EnemyMovement enemyMove = enemyGO.GetComponent<EnemyMovement>();
        if (enemyMove == null) { return; }
        enemyMove._player = _player;
    }
}