using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointControllerScript : MonoBehaviour
{
    private UnitScript[] unit;

    public List<Vector3> waypointsList = new List<Vector3>(); //лист который содержит координаты waypointов активных в данный момент

    public List<Vector3> obstaclePosList = new List<Vector3>(); //лист который содержит координаты препятствий активных в данный момент

    public List<UnitScript> unitList = new List<UnitScript>(); // юниты


    private bool isWaypointActiveited = false;


    private void Awake()
    {
        unit = FindObjectsOfType<UnitScript>();
    }

    public void ToWaypointMove() // метод который присваивает юнитам позиции точек который они должны занять по команде
    {
        if (!isWaypointActiveited)
        {
            for (int i = 0; i < unitList.Count; i++)
            {
                try
                {
                    var unit = unitList[i];
                    unit.UnitMoveToWaypoint(waypointsList[i]);
                }
                catch
                {
                    Debug.Log("Нужно больше waypoint'ов!");
                }
            }

            isWaypointActiveited = true;
        }
        else
        {
            for (int i = 0; i < unitList.Count; i++)
            {
                var unit = unitList[i];
                unit.IsRandomMove();
            }

            isWaypointActiveited = false;
        }
    }

    public bool CheckIsObsacle(Vector3 randomPoint) //проверка является ли целевая точка при рандомном перемещении юнита препятствием
    {
        for (int i = 0; i < obstaclePosList.Count; i++)
        {
            if(obstaclePosList[i] == randomPoint)
            {
                return true;
            }
            
        }
        return false;

    }
}
