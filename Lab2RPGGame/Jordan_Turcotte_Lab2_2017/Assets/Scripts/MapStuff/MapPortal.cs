using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class MapPortal : MonoBehaviour
{
    public int targetMap;
    public int targetEntryPoint;
    public Vector3 cellSizeType;
    public Vector3 scale;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player") return;

        MapNavigation.Instance.GoToMap(targetMap, targetEntryPoint, cellSizeType, scale);
        

        //make a switch for cell sized that takes cell sixe type
    }
}
