
using TMPro;
using UnityEngine;

public class MajorCultivationLevel: MonoBehaviour
{
    [SerializeField] private int energyRequirement;
    [SerializeField] private int currentEnergy;
    [SerializeField] private int energyLevel;
    [SerializeField] private int requiredAmount;

    [SerializeField] private string energyLevelName;

    [SerializeField] private GameObject[] minorCultivationLevels;
    [SerializeField] private GameObject[] requiredMaterials;
    [SerializeField] private GameObject currentMinorCultivationLevel;

    private GameObject inventory;

    [SerializeField] private bool minorCompletion;
    [SerializeField] private bool completed;
    [SerializeField] private bool requirementCompletion;

    private int check;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Inventory");

        setCurrentMinorCultivationLevel();
    }



    // Checks if required materials are in inventory and have enough amount if so sets requirementCompletion to true
    public void checkRequiredMaterialCompletion()
    {
        check = requiredMaterials.Length;

        for (int i = 0; i < requiredMaterials.Length; i++)
        {
            if (requiredMaterials[i].GetComponent<Consumable>() != null)
            {
                for (int j = 0; j < inventory.transform.childCount; j++)
                {
                    if (requiredMaterials[i] == inventory.transform.GetChild(j) 
                        && 
                       (requiredMaterials[i].GetComponent<Consumable>().getCurrentQuantity() - requiredAmount >= 0)) 
                    {
                        check--;
                    }
                }
            }
        }

        if (check == 0)
        {
            requirementCompletion = true;
        }
    }

    // Checks if last minor cultivation level is completed. if so returns true otherwise returns false.
    public bool checkMinorCompletion()
    {
        if (minorCultivationLevels[(minorCultivationLevels.Length - 1)].GetComponent<MinorCultivationLevel>().getCompletion() == true)
        {
            minorCompletion = true;
            return true;
        }
        else
        {
            return false;
        }
    }



    //Returns all minor cultivation levels of current major cultivation level
    public GameObject[] getMinorCultivationLevels()
    {  
        return minorCultivationLevels;
    }

    // Returns completion of current major cultivation level.
    public bool getCompletion()
    {
        return completed;
    }

    // Returns current minor cultivation level the user is trying to complete.
    public GameObject getCurrentMinorCultivationLevel()
    {
        return currentMinorCultivationLevel;
    }

    // Returns energy of current major cultivation level.
    public int getEnergy()
    {
        return currentEnergy;
    }

    // Returns requirement completion value
    public bool getRequirementCompletion()

    {
        return requirementCompletion;
    }

    // Returns all of the required materials to complete current major cultivation level.
    public GameObject[] getRequiredMaterials()
    {
        return requiredMaterials;
    }

    // Returns energy requirement of current major cultivation level.
    public int getEnergyRequirement()
    {
        return energyRequirement;
    }

    // Returns energy level of current major cultivation level.
    public int getEnergyLevel()
    {
        return energyLevel;
    }

    // Returns energy level name of current major cultivation level.
    public string getEnergyLevelName()
    { 
        return energyLevelName;
    }



    // Sets current minor cultivation level the user is trying to complete to designated minor level.
    public void setCurrentMinorCultivationLevel()
    {
        for (int i = 0; i < minorCultivationLevels.Length; i++)
        {
            if (minorCultivationLevels[i].GetComponent<MinorCultivationLevel>().getCompletion() == false)
            {
                currentMinorCultivationLevel = minorCultivationLevels[i];
                break;
            }
        }
    }

    // Sets energy of current major cultivation level to designated value.
    public void setEnergy(int energy)
    {
        currentEnergy = energy;
    }

    // Sets completion of current major level to designated value.
    public void setCompletion(bool completion)
    {
        completed = completion;
    }



    // Increases the energy of current major cultivation level a designated amount.
    public void increaseCurrentEnergy(int energy)
    {
        currentEnergy += energy;

        if (currentEnergy >= energyRequirement)
        {
            currentEnergy = energyRequirement;
        }
    }

    // Decreases the energy of current major cultivation level a designated amount.
    public void decreaseCurrentEnergy(int energy)
    {
        if ((currentEnergy - energy) >= 0)
        {
            currentEnergy -= energy;
        }
    }
}