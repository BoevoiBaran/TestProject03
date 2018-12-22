using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitScript : MonoBehaviour
{
    private GameControllerScript gameController;
    private WaypointControllerScript waypointController;
    public NavMeshAgent agent;

    

    [SerializeField]
    [Range(1, 10)]
    private float speed;

    private Vector3 randomPoint;
    
    private bool isRandomMove = true;
    public void IsRandomMove()
    {
        isRandomMove = true;
    }

    private void Awake()
    {
        gameController = FindObjectOfType<GameControllerScript>();
        waypointController = FindObjectOfType<WaypointControllerScript>();
    }

    private void Start()
    {
        waypointController.unitList.Add(this);
        PathGenerate();
    }

    private void Update()
    {
        if (isRandomMove)
        {
            UnitRandomMove();
        }

        if(isRandomMove && Vector3.Distance(transform.position, randomPoint) < 0.3f)
        {

            PathGenerate();
        }
    }

    private void PathGenerate() // генерация рандомной точки назначения при хаотичном перемещении
    {
        int tileX = Random.Range(0, gameController.LevelWidth);
        int tileZ = Random.Range(0, gameController.LevelHeight);

        randomPoint = new Vector3(tileX + gameController.LevelOffset, 0.0f, tileZ + gameController.LevelOffset);

        if(waypointController.CheckIsObsacle(randomPoint)) // проверка не является ли целевая точка препятствием в данный момент
        {
            PathGenerate();
        }
    }

    public void UnitMoveToWaypoint(Vector3 waypointPos) // метод отправляющий юнита на waypoint
    {
        isRandomMove = false;
        agent.SetDestination(waypointPos);
    }

    private void UnitRandomMove() //рандомное перемещение юнита
    {
        agent.SetDestination(randomPoint);
    }
}
