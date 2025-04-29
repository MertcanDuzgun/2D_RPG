using TMPro;
using UnityEngine;
using System.Collections;


public class TrainingMethod : MonoBehaviour
{
    private GameObject gameController;
    private GameObject body;
    private GameObject spirit;
    private GameObject mind;
    private GameObject currentMajorCultivationLevel;
    private GameObject currentMinorCultivationLevel;

    private float cultivationSpeedMultiplier;
    private float cultivationEnergyMultiplier;
    private int cultivationSpeedAddition;
    private int cultivationEnergyAddition;

    [SerializeField] private string trainingMethodName;
    [SerializeField] private string cultivationTarget;
    [SerializeField] private string trainingMethodElement;
    [SerializeField] private bool ifElemental;
    [SerializeField] private float trainingSpeed;
    [SerializeField] private float trainingMultiplier;
    [SerializeField] private int trainingTime;
    [SerializeField] private int trainingEnergy;
    [SerializeField] private int currentQuantity;
    [SerializeField] private int maxQuantity;
    [SerializeField] private bool ifTraining;
                                                               

    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController");
        body = GameObject.FindGameObjectWithTag("Body");
        mind = GameObject.FindGameObjectWithTag("Mind");
        spirit = GameObject.FindGameObjectWithTag("Spirit");

        setCurrentMajorCultivationLevel();
        setCurrentMinorCultivationLevel();
        setMultiplierValues();

        //StartCoroutine(EffectActivated());
    }

    /*IEnumerator EffectActivated()
    {
        for (; ; )
        {

            if (ifTraining == true && gameController.GetComponent<GameController>().getIfInAction() == false)
            {
                activateEffect();
                Debug.Log("Training effect has been applied.");
                yield return new WaitForSeconds(trainingTime / trainingSpeed);
            }
            else
            {
                StopCoroutine(EffectActivated());
            }
        }
    }*/

    public void activateEffect()
    {
        if(currentMajorCultivationLevel.GetComponent<MajorCultivationLevel>().checkMinorCompletion() == true)
        {
            currentMajorCultivationLevel.GetComponent<MajorCultivationLevel>().increaseCurrentEnergy((int)(trainingEnergy * trainingMultiplier));
        }
        else 
        { 
            currentMinorCultivationLevel.GetComponent<MinorCultivationLevel>().increaseCurrentEnergy((int)(trainingEnergy * trainingMultiplier));
        }
    }

    public void deActivateEffect()
    {
        ifTraining = false;
    }

    public void setCurrentMinorCultivationLevel()
    {
        currentMinorCultivationLevel = body.GetComponent<Body>().getCurrentMinorCultivationLevel();
    }

    public void setCurrentMajorCultivationLevel()
    {
        currentMajorCultivationLevel = body.GetComponent<Body>().getCurrentMajorCultivationLevel();

    }

    public void setMultiplierValues()
    {
        if (cultivationTarget == "Body")
        {
            cultivationSpeedMultiplier = body.GetComponent<Body>().getCultivationSpeedMultiplier();
            cultivationEnergyMultiplier = body.GetComponent<Body>().getCultivationEnergyMultiplier();
            cultivationSpeedAddition = body.GetComponent<Body>().getCultivationSpeedAddition();
            cultivationEnergyAddition = body.GetComponent<Body>().getCultivationEnergyAddition();

            trainingSpeed *= cultivationSpeedMultiplier;
            trainingMultiplier *= cultivationEnergyMultiplier;
            trainingSpeed += cultivationSpeedAddition;
            trainingMultiplier += cultivationEnergyAddition;
        }
    }

    public void increaseQuantity(int quantity)
    {
        if ( (currentQuantity + quantity) < maxQuantity) 
        {
            currentQuantity += quantity;
        }
    }

    public void decreaseQuantity(int quantity) 
    {
        if ( (currentQuantity - quantity) >= 0)
        {
            currentQuantity -= quantity;
        }
    }
}
