using UnityEngine;
using UnityEngine.UIElements;
using System.Collections.Generic;

public class MapNavigation : MonoBehaviour
{
    public static MapNavigation Instance;

    [SerializeField] private Transform player;
    [SerializeField] private MapLibrary library;
    [SerializeField] private Transform mapParent;
    private Dictionary<int, GameMap> mapDictionary = new Dictionary<int, GameMap>();

    private GameObject currentMap;

    void Awake()
    {
        if(Instance == null) Instance = this;
    }
    private void InitializeMapDictionary()
    {
        mapDictionary.Clear();
        foreach(GameMap m in library.mapLibrary)
        {
            
        }
    }

    public void GoToMap(int index)
    {
        Destroy(currentMap);

        //need to convert from grid space to world space
        
        
    }
}
