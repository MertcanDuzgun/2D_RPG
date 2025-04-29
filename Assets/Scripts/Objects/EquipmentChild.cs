using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public class EquipmentChild : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] public GameObject parentEquipment;

    public void showParentEquipmentDetails()
    {
        parentEquipment.GetComponent<Equipment>().showEquipmentDetails();
    }

    public void turnBackToParentEquipment()
    {
        this.transform.parent = parentEquipment.transform;
    }
}
