using System.Collections.Generic;
using UnityEngine;

public class ContainerUI : MonoBehaviour
{
    public InventoryManager targetInventory;
    public GameObject buttonPrefab;
    public Transform inventoryParent;
    public Transform containerParent;
    private List<GameObject> uiButtons = new();
    
    public Canvas containerUI;

    private Treasure treasure;
    

    // [Header("Debug")]
    // public InventoryContainer debugContainer;

    // private void Start()
    // {
    //     //InitUI(debugContainer);
        
    // }
    void Awake()
    {
        containerUI.enabled = false;

        treasure = GameObject.FindGameObjectWithTag("TreasureChest").GetComponent<Treasure>();
        Debug.Log($" treasure - {treasure}");

        treasure.onContainerOpen += InitUI;
    }

    public void InitUI(InventoryContainer container_)
    {
        
        containerUI.enabled = true;
        Dictionary<InventoryDataSO, InventoryItemData> inventoryRef = targetInventory.inventory;
        Dictionary<InventoryDataSO, InventoryItemData> containerRef = container_.containerInventory;

        foreach (InventoryItemData item in inventoryRef.Values)
        {
            GameObject tmp = Instantiate(buttonPrefab, inventoryParent);
            tmp.GetComponent<ContainerButton>().InitializeButton(item, container_, false);
            uiButtons.Add(tmp);
        }

        foreach (InventoryItemData item in containerRef.Values)
        {
            GameObject tmp = Instantiate(buttonPrefab, containerParent);
            tmp.GetComponent<ContainerButton>().InitializeButton(item, container_, true);
            uiButtons.Add(tmp);
        }
        container_.onContainerUpdated += UpdateContainerUI;
    }

    public void UpdateContainerUI(InventoryContainer container_)
    {
        foreach(GameObject button in uiButtons)
        {
            Destroy(button);
        }
        uiButtons.Clear();

        Dictionary<InventoryDataSO, InventoryItemData> inventoryRef = targetInventory.inventory;
        Dictionary<InventoryDataSO, InventoryItemData> containerRef = container_.containerInventory;

        foreach (InventoryItemData item in inventoryRef.Values)
        {
            GameObject tmp = Instantiate(buttonPrefab, inventoryParent);
            tmp.GetComponent<ContainerButton>().InitializeButton(item, container_, false);
            uiButtons.Add(tmp);
        }

        foreach (InventoryItemData item in containerRef.Values)
        {
            GameObject tmp = Instantiate(buttonPrefab, containerParent);
            tmp.GetComponent<ContainerButton>().InitializeButton(item, container_, true);
            uiButtons.Add(tmp);
        }
    }

    public void CloseUI()
    {
        uiButtons.Clear();
        containerUI.enabled = false;
    }
}
