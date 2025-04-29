using UnityEngine;
using System.Linq;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private GameObject INVENTORY;
    [SerializeField] private GameObject[] Consumables;
    [SerializeField] private GameObject[] Equipments;
    [SerializeField] private GameObject[] Materials;
    [SerializeField] private GameObject[] Objects;

    private void Start()
    {
        Consumables = GameObject.FindGameObjectsWithTag("Consumable");
        Consumables = Consumables.OrderByDescending(p => p.transform.GetComponent<Consumable>().getCurrentQuantity()).ToArray();

        Equipments = GameObject.FindGameObjectsWithTag("Equipment");
        Equipments = Equipments.OrderByDescending(p => p.transform.GetComponent<Equipment>().getCurrentQuantity()).ToArray();

        Materials = GameObject.FindGameObjectsWithTag("Material");
        Materials = Materials.OrderByDescending(p => p.transform.GetComponent<Material>().getCurrentQuantity()).ToArray();

        setConsumablesToInventory();
        setEquipmentsToInventory();
        setMaterialsToInventory();
    }

    private void setConsumablesToInventory()
    {
        for (int i = 0; i < Consumables.Length; i++)
        {
            if (Consumables[i].GetComponent<Consumable>() != null)
            {
                if (Consumables[i].GetComponent<Consumable>().getCurrentQuantity() != 0)
                {
                    Consumables[i].transform.parent = INVENTORY.transform;
                }
            }
        }
    }

    private void setEquipmentsToInventory()
    {
        for (int i = 0; i < Equipments.Length; i++)
        {
            if (Equipments[i].GetComponent<Equipment>() != null)
            {
                if (Equipments[i].GetComponent<Equipment>().getCurrentQuantity() > 0) // && Equipments[i].GetComponent<Equipment>().getIsEquipped() == false
                {
                    Equipments[i].transform.parent = INVENTORY.transform;
                }
                else if (Equipments[i].GetComponent<Equipment>().getCurrentQuantity() > 1 && Equipments[i].GetComponent<Equipment>().getIsEquipped() == true)
                {
                    Equipments[i].transform.parent = INVENTORY.transform;
                }
            }
        }
    }

    private void setMaterialsToInventory()
    {
        for (int i = 0; i < Materials.Length; i++)
        {
            if (Materials[i].GetComponent<Material>() != null)
            {
                if (Materials[i].GetComponent<Material>().getCurrentQuantity() != 0)
                {
                    Materials[i].transform.parent = INVENTORY.transform;
                }
            }
        }
    }

    public void activateAllItemsInInventory()
    {
        for (int i = 0; i < Consumables.Length; i++) 
        {
            if(Consumables[i].transform.parent == INVENTORY.transform)
            {
                Consumables[i].GetComponent<UnityEngine.UI.Button>().enabled = true;
                Consumables[i].GetComponent<UnityEngine.UI.Image>().enabled = true;
            }
        }

        for (int i = 0; i < Equipments.Length; i++) 
        {
            if (Equipments[i].transform.parent == INVENTORY.transform)
            {
                Equipments[i].GetComponent<UnityEngine.UI.Button>().enabled = true;
                Equipments[i].GetComponent<UnityEngine.UI.Image>().enabled = true;
            }
        }

        for (int i = 0; i < Materials.Length; i++)
        {
            if (Materials[i].transform.parent == INVENTORY.transform)
            {
                Materials[i].GetComponent<UnityEngine.UI.Button>().enabled = true;
                Materials[i].GetComponent<UnityEngine.UI.Image>().enabled = true;
            }
        }
    }

    public void deActivateAllItemsInInventory()
    {
        for (int i = 0; i < Consumables.Length; i++)
        {
            if (Consumables[i].transform.parent == INVENTORY.transform)
            {
                Consumables[i].GetComponent<UnityEngine.UI.Button>().enabled = false;
                Consumables[i].GetComponent<UnityEngine.UI.Image>().enabled = false;
            }
        }

        for (int i = 0; i < Equipments.Length; i++)
        {
            if (Equipments[i].transform.parent == INVENTORY.transform)
            {
                Equipments[i].GetComponent<UnityEngine.UI.Button>().enabled = false;
                Equipments[i].GetComponent<UnityEngine.UI.Image>().enabled = false;
            }
        }

        for (int i = 0; i < Materials.Length; i++)
        {
            if (Materials[i].transform.parent == INVENTORY.transform)
            {
                Materials[i].GetComponent<UnityEngine.UI.Button>().enabled = false;
                Materials[i].GetComponent<UnityEngine.UI.Image>().enabled = false;
            }
        }
    }
}