using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour
{
    private Renderer rend;
    private Color originalcolor;

    private bool isObstacle = false;

    private bool isWaypoint;
    public bool IsWaypoint
    {
        get { return isWaypoint; }
    }

    private UnitScript unit;

    private void Awake()
    {
        rend = GetComponent<Renderer>();
        originalcolor = rend.material.color;

        unit = Resources.Load<UnitScript>("Unit");
    }

    public void Waypoint() // активирует на тайле waypoint
    {
        if (!isObstacle && !isWaypoint)
        {
            rend.material.color = Color.grey;
            gameObject.transform.GetChild(1).gameObject.SetActive(true);
            isWaypoint = true;
        }
        else
        {
            rend.material.color = originalcolor;
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
            isWaypoint = false;
        }
    }

    public void Obstacle() //активирует на тайле препятствие
    {
        if (!isObstacle && !isWaypoint)
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            isObstacle = true;
        }
        else
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            isObstacle = false;
        }
    }
}
