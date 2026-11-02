using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class RNGmap : MonoBehaviour
{
    [SerializeField] private List<Sprite> tilesGrass;
    [SerializeField] private List<Sprite> tilesSpace;
    [SerializeField] private List<Sprite> objects;
    [SerializeField] private int mapLength = 10;
    [SerializeField] private GameObject[] mapParents;
    [SerializeField] private int numberOfObjects = 30;

    private void Awake()
    {
        GenerateMap();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            foreach (GameObject parent in mapParents)
            {
                foreach (Transform child in parent.transform)
                {
                    Destroy(child.gameObject);
                }
            }
            GenerateMap();
        }
    }

    private void GenerateMap()
    {
        float x = -7.36f;
        for (int i = 0; i < mapLength; i++)
        {
            GameObject TempTile =Instantiate(new GameObject("GrassTile"), new Vector3(x,-0.4f,0),Quaternion.identity, mapParents[0].transform);
            TempTile.AddComponent<SpriteRenderer>().sprite = tilesGrass[Random.Range(0, tilesGrass.Count)];
            TempTile.tag = "GrassTile";
            TempTile.GetComponent<SpriteRenderer>().sortingOrder = 2;
            float y = -0.12f;
            for (int j = 0; j < 4; j++)
            {
                TempTile = Instantiate(new GameObject("SpaceTile"), new Vector3(x, y, 0), Quaternion.identity, mapParents[1].transform);
                TempTile.AddComponent<SpriteRenderer>().sprite = tilesSpace[Random.Range(0, tilesSpace.Count)];
                TempTile.GetComponent<SpriteRenderer>().sortingOrder = -1;
                TempTile.tag = "SpaceTile";
                y += 0.96f;
            }
            x += 1.04f;
        }
        for (int i = 0; i < numberOfObjects; i++)
        {
            GameObject TempTile = Instantiate(new GameObject("Object"), new Vector3(Random.Range(-7.873f,35.28f), Random.Range(-0.05f,0.01f), 0), Quaternion.identity, mapParents[2].transform);
            TempTile.AddComponent<SpriteRenderer>().sprite = objects[Random.Range(0, objects.Count)];
            TempTile.tag = "Object";
            TempTile.GetComponent<SpriteRenderer>().sortingOrder = 1;
        }
        ClearBug();
    }
    private void ClearBug()
    {
        GameObject[] clear = GameObject.FindObjectsByType<GameObject>(FindObjectsSortMode.None);
        foreach (GameObject obj in clear)
        {
            if (obj.CompareTag("Untagged"))
                Destroy(obj);
        }
    }
}
