using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class MapPortal : MonoBehaviour
{
    public int targetMap;
    public int targetEntryPoint;
    public List<Vector3> cellSize = new List<Vector3>();
    public int cellSizeType;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player") return;

        MapNavigation.Instance.GoToMap(targetMap, targetEntryPoint);

        //make a switch for cell sized that takes cell sixe type
    }
}
