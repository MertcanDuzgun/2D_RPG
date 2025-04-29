using System.Linq;
using UnityEngine;

public class Body : MonoBehaviour 
{
    [SerializeField] private GameObject currentMinorCultivationLevel;
    [SerializeField] private GameObject currentMajorCultivationLevel;

    [SerializeField] private GameObject[] majorCultivationLevels;

    [SerializeField] private float cultivationEnergyMultiplier;
    [SerializeField] private float cultivationSpeedMultiplier;
    [SerializeField] private int cultivationEnergyAddition;
    [SerializeField] private int cultivationSpeedAddition;

    private void Start()
    {
        // Setting majorCultivationLevels array elements to Objects with tag "BodyMajCulLv"
        majorCultivationLevels = GameObject.FindGameObjectsWithTag("BodyMajCulLv");
        // Changing the order of elements according to energyLevel of Major Cultivation Levels in a ascending manner.
        majorCultivationLevels = majorCultivationLevels.OrderBy(p => p.transform.GetComponent<MajorCultivationLevel>().getEnergyLevel()).ToArray();

        setCurrentMajorCultivationLevel();
        setCurrentMinorCultivationLevel();
    }

    public int getCurrentEnergy()
    {
        if (currentMajorCultivationLevel.GetComponent<MajorCultivationLevel>().checkMinorCompletion() == true)
        {
            return currentMajorCultivationLevel.GetComponent<MajorCultivationLevel>().getEnergy();
        }
        else
        {
            return currentMinorCultivationLevel.GetComponent<MinorCultivationLevel>().getEnergy();
        }
    }

    public int getMaxEnergy()
    {
        if (currentMajorCultivationLevel.GetComponent<MajorCultivationLevel>().checkMinorCompletion() == true)
        {
            return currentMajorCultivationLevel.GetComponent<MajorCultivationLevel>().getEnergyRequirement();
        }
        else
        {
            return currentMinorCultivationLevel.GetComponent<MinorCultivationLevel>().getEnergyRequirement();
        }
    }

    public void majorCultivationLevelUp()
    {
        currentMajorCultivationLevel.gameObject.GetComponent<MajorCultivationLevel>().checkRequiredMaterialCompletion();

        if ( (currentMajorCultivationLevel.gameObject.GetComponent<MajorCultivationLevel>().checkMinorCompletion() == true )
              &&
             (currentMajorCultivationLevel.GetComponent<MajorCultivationLevel>().getEnergyRequirement() == currentMajorCultivationLevel.GetComponent<MajorCultivationLevel>().getEnergy())
              && 
             (currentMajorCultivationLevel.GetComponent <MajorCultivationLevel>().getRequirementCompletion() == true))
        {
            currentMajorCultivationLevel.gameObject.GetComponent<MajorCultivationLevel>().setCompletion(true);
            setCurrentMajorCultivationLevel();
        }
    }

    public void minorCultivationLevelUp()
    {
        if(currentMinorCultivationLevel.GetComponent<MinorCultivationLevel>().getEnergyRequirement() == currentMinorCultivationLevel.GetComponent<MinorCultivationLevel>().getEnergy())
        {
            currentMinorCultivationLevel.GetComponent<MinorCultivationLevel>().setCompletion(true);
            currentMajorCultivationLevel.GetComponent<MajorCultivationLevel>().setCurrentMinorCultivationLevel();
            setCurrentMinorCultivationLevel();
        }
    }

    public int getCultivationEnergyAddition()
    {
        return cultivationEnergyAddition;
    }

    public int getCultivationSpeedAddition()
    {
        return cultivationSpeedAddition;
    }

    public float getCultivationEnergyMultiplier()
    {
        return cultivationEnergyMultiplier;
    }

    public float getCultivationSpeedMultiplier()
    {
        return cultivationSpeedMultiplier;
    }

    public GameObject getCurrentMinorCultivationLevel()
    {
        return currentMinorCultivationLevel;
    }

    public GameObject getCurrentMajorCultivationLevel()
    {
        return currentMajorCultivationLevel;
    }

    public void setCurrentMajorCultivationLevel()
    {
        for (int i = 0; i < majorCultivationLevels.Length; i++)
        {
            if (majorCultivationLevels[i].GetComponent<MajorCultivationLevel>().getCompletion() == false)
            {
                currentMajorCultivationLevel = majorCultivationLevels[i];
                break;
            }
        }
    }

    public void setCurrentMinorCultivationLevel() 
    {
       currentMinorCultivationLevel = currentMajorCultivationLevel.GetComponent<MajorCultivationLevel>().getCurrentMinorCultivationLevel();
    }

    public void increaseMinorCultivationEnergy(int energy)
    {
        currentMinorCultivationLevel.GetComponent<MinorCultivationLevel>().increaseCurrentEnergy((int)(energy * cultivationEnergyMultiplier));
    }

    public void increaseMajorCultivationEnergy(int energy)
    {
        currentMajorCultivationLevel.GetComponent<MajorCultivationLevel>().increaseCurrentEnergy((int)(energy * cultivationEnergyMultiplier));
    }

    public void decreaseMinorCultivationEnergy(int energy)
    {
        currentMinorCultivationLevel.GetComponent<MinorCultivationLevel>().decreaseCurrentEnergy(energy);
    }

    public void decreaseMajorCultivationEnergy(int energy)
    {
        currentMajorCultivationLevel.GetComponent<MajorCultivationLevel>().decreaseCurrentEnergy(energy);
    }
}