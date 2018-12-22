using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class GameControllerScript : MonoBehaviour
{
    
    public NavMeshSurface surface; // ссылка на навигационный меш

    [SerializeField] // Префаб тайла из которого состоит поле
    private GameObject tile;

    [SerializeField] // префаб юнита
    private GameObject unit;

    private int levelWidth; //ширина игрового поля
    public int LevelWidth
    {
        get { return levelWidth; }
    }

    private int levelHeight; //высота игрового поля
    public int LevelHeight
    {
        get { return levelHeight; }
    }

    private float levelOffset = 0.5f;
    public float LevelOffset
    {
        get { return levelOffset; }
    }

    private void Awake()
    {
        levelWidth = Random.Range(5, 11); //задание параметров поля
        levelHeight = Random.Range(5, 11);
    }

    private void Start()
    {
        GenerateLevel(); // создание уровня

        surface.BuildNavMesh(); // запекание навигационного меша

        UnitSpawn(); // спавн юнитов
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) CreateObstacle();
        if (Input.GetMouseButtonDown(1)) CreateWaypoint();
    }

    private void GenerateLevel() // метод создания игрового поля
    {
        for (int i = 0; i < levelWidth; i++)
        {
            for (int j = 0; j < levelHeight; j++)
            {
                GameObject go = Instantiate(tile, new Vector3(i + levelOffset, 0.0f, j + levelOffset), Quaternion.identity) as GameObject;
            }
        }
    }

    private void UnitSpawn() // метод спавна юнитов
    {
        int spawnCount = Random.Range(1, 6);
        Debug.Log(spawnCount);

        for (int i = 1; i <= spawnCount; i++)
        {
            Instantiate(unit, transform.position, Quaternion.identity);
        }
    }

    private void CreateObstacle() // создание препятствия
    {
        RaycastHit hit;
        if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 25.0f, LayerMask.GetMask("TilePlane")))
        {
            hit.collider.GetComponent<TileScript>().Obstacle();
        }
    }

    private void CreateWaypoint() // создание waypont'а
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 25.0f, LayerMask.GetMask("TilePlane")))
        {
            hit.collider.GetComponent<TileScript>().Waypoint();
        }
    }

    public void RestartScene() //кнопка рестарта
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame() // кнопка выхода из приложения
    {
        Application.Quit();
    }

}
