using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    private WaypointControllerScript waypointController;

    private void Awake()
    {
        waypointController = FindObjectOfType<WaypointControllerScript>();
    }


    private void OnEnable()
    {
        waypointController.obstaclePosList.Add(transform.parent.position); // добавляет координаты препятствия в общий список
    }

    private void OnDisable()
    {
        waypointController.obstaclePosList.Remove(transform.parent.position);
    }

}
