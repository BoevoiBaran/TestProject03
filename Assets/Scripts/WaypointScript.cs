using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointScript : MonoBehaviour
{
    private WaypointControllerScript waypointController;

    private void Awake()
    {
        waypointController = FindObjectOfType<WaypointControllerScript>();
    }


    private void OnEnable()
    {
        waypointController.waypointsList.Add(transform.position); // добавляет координаты waypointa в список
    }



    private void OnDisable()
    {
        waypointController.waypointsList.Remove(transform.position);
    }
}
