using TMPro;
using UnityEngine;

public class MinorCultivationLevel: MonoBehaviour
{
    [SerializeField] private int energyRequirement;
    [SerializeField] private int currentEnergy;
    [SerializeField] private int energyLevel;

    private GameObject body;
    private GameObject[] trainingMethods;

    [SerializeField] private bool completed;

    private void Start()
    {
        
        body = GameObject.FindGameObjectWithTag("Body");
        trainingMethods = GameObject.FindGameObjectsWithTag("TrainingMethod");
    }

    public void increaseCurrentEnergy(int energy)
    {
        currentEnergy += energy;

        if (currentEnergy >= energyRequirement)
        {
            currentEnergy = energyRequirement;
            setCompletion(true);


           /* warningText.GetComponent<TextMeshProUGUI>().text = "You have reached maximum energy for this energy level.";
            warning.SetActive(true);*/
        }
    }

    public void decreaseCurrentEnergy(int energy)
    {
        if ((currentEnergy - energy) > 0)
        {
            currentEnergy -= energy;
        }
    }

    public int getEnergy() 
    { 
        return currentEnergy;
    }

    public void setEnergy(int energy)
    {
        currentEnergy = energy;
    }

    public int getEnergyRequirement()
    {
        return energyRequirement;
    }

    public int getEnergyLevel()
    {
        return energyLevel; 
    }

    public bool getCompletion()
    {  
        return completed; 
    }

    public void setCompletion(bool completion)
    {
        completed = completion;
        transform.parent.GetComponent<MajorCultivationLevel>().setCurrentMinorCultivationLevel();
        body.gameObject.GetComponent<Body>().setCurrentMinorCultivationLevel();

        for (int i = 0; i < trainingMethods.Length; i++)
        {
            Debug.Log("Training method currentMinorCultivationLevel set.");
            trainingMethods[i].gameObject.GetComponent<TrainingMethod>().setCurrentMinorCultivationLevel();
            trainingMethods[i].gameObject.GetComponent<TrainingMethod>().deActivateEffect();
        }
    }
}