using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using UnityEditor;
using Unity.VisualScripting;

public class GameController : MonoBehaviour
{
    // SAVE
    [SerializeField] private bool gameSaved;
    [SerializeField] private bool ifInAction;


    // LIFESPAN 
    [SerializeField] private double MAX_LIFESPAN;
    [SerializeField] private double LIFESPAN_DAYS;
    [SerializeField] private int LIFESPAN_YEARS;

    // MAIN STATS
    [SerializeField] private double VITALITY;
    [SerializeField] private double STRENGTH;
    [SerializeField] private double AGILITY;
    [SerializeField] private double ENDURANCE;
    [SerializeField] private double DEXTERITY;
    [SerializeField] private double INTELLIGENCE;
    [SerializeField] private double WISDOM;

    // SIDE STATS


    // NECESARRY OBJECT CALLS
    
    
    private void Start()
    {
        // Temporary until saving game is added.
        gameSaved = false;

        // Setting Max Lifespan
        setMaxLifeSpan();
        // Setting Effective Lifespan
        setLifeSpanDays();
        setLifeSpanYears();

        // Setting Main Stats
        setMainStats();

        StartCoroutine("TimeTicsEverySecond");
    }

    private void Update()
    {

    }

    IEnumerator TimeTicsEverySecond()
    {
        for (; ; )
        {
           /* Debug.Log("Tic");
            Debug.Log(LIFESPAN_DAYS);*/
            LIFESPAN_DAYS--;
            LIFESPAN_YEARS = (int)(LIFESPAN_DAYS / 300);
            yield return new WaitForSeconds(1f);
        }
    }

    public void setMainStats()
    {
        if (gameSaved == false)
        {
            VITALITY = 10.0;
            STRENGTH = 10.0;
            AGILITY = 10.0;
            ENDURANCE  = 10.0;
            DEXTERITY = 10.0;
            INTELLIGENCE = 10.0;
            WISDOM = 10.0;

            Debug.Log("Succesfully set main stats.");
            Debug.Log("MAIN STATS: ");
            Debug.Log(VITALITY);
            Debug.Log(STRENGTH);
            Debug.Log(AGILITY);
            Debug.Log(ENDURANCE);
            Debug.Log(DEXTERITY);
            Debug.Log(INTELLIGENCE);
            Debug.Log(WISDOM);
            Debug.Log("END OF MAIN STATS.");
        }
    }

    public void setMaxLifeSpan()
    {
        
        if (gameSaved == false)
        {
            MAX_LIFESPAN = 50.0;
        }
        else
        {
            MAX_LIFESPAN = 0.0;

            if (VITALITY <= 10)
            {
                MAX_LIFESPAN = VITALITY * 5;
            }
            else if (VITALITY <= 30)
            {
                MAX_LIFESPAN = 0.0;
                MAX_LIFESPAN += 10 * 5;
                MAX_LIFESPAN += (VITALITY - 10) * 2.5;
            }
            else if ( VITALITY <= 100)
            {
                MAX_LIFESPAN = 0.0;
                MAX_LIFESPAN += 10 * 5;
                MAX_LIFESPAN += 20 * 2.5;
                MAX_LIFESPAN += (VITALITY - 30) * 1;
            }
            else if (VITALITY <= 200)
            {
                MAX_LIFESPAN = 0.0;
                MAX_LIFESPAN += 10 * 5;
                MAX_LIFESPAN += 20 * 2.5;
                MAX_LIFESPAN += 70 * 1;
                MAX_LIFESPAN += (VITALITY - 100) * 0.5;
            }
            else if (VITALITY <= 500)
            {
                MAX_LIFESPAN = 0.0;
                MAX_LIFESPAN += 10 * 5;
                MAX_LIFESPAN += 20 * 2.5;
                MAX_LIFESPAN += 70 * 1;
                MAX_LIFESPAN += 100 * 0.5;
                MAX_LIFESPAN += (VITALITY - 200) * 0.25;
            }
            else if (500 < VITALITY)
            {
                MAX_LIFESPAN = 0.0;
                MAX_LIFESPAN += 10 * 5;
                MAX_LIFESPAN += 20 * 2.5;
                MAX_LIFESPAN += 70 * 1;
                MAX_LIFESPAN += 100 * 0.5;
                MAX_LIFESPAN += 300 * 0.25;
                MAX_LIFESPAN += (VITALITY - 500) * 0.1;
            }
            else
            {
                Debug.Log("Negative MAX_LIFESPAN DETECTED");
            }
        }
        Debug.Log("MAX_LIFESPAN: ");
        Debug.Log(MAX_LIFESPAN);
    }

    public void setLifeSpanDays()
    {
        if(gameSaved == false)
        {
            LIFESPAN_DAYS = MAX_LIFESPAN * 300;
        }
    }
    
    public void setLifeSpanYears()
    {
        if(gameSaved == false)
        {
            LIFESPAN_YEARS = (int)MAX_LIFESPAN;
        }
    }

    public double getLifeSpanDays()
    {
        return LIFESPAN_DAYS;
    }

    public double getLifeSpanYears()
    {  
        return LIFESPAN_YEARS; 
    }

    public void stopTime()
    {
        StopCoroutine("TimeTicsEverySecond");
        //StopCoroutine("TimeTicsEvery300Secs");
    }

    public void resumeTime()
    {
        StartCoroutine("TimeTicsEverySecond");
        //StartCoroutine("TimeTicsEvery300Secs");
    }

    // GET methods for MAIN STATS

    public double getVitality()
    {
        return VITALITY;
    }
    public double getStrength()
    {
        return STRENGTH;
    }
    public double getAgility()
    {
        return AGILITY;
    }
    public double getEndurance()
    {
        return ENDURANCE;
    }
    public double getDexterity()
    {
        return DEXTERITY;
    }
    public double getIntelligence()
    {
        return INTELLIGENCE;
    }
    public double getWisdom()
    {
        return WISDOM;
    }

    // SET methods for MAIN STATS
    public void setVitality(double input)
    {
        VITALITY = input;
    }
    public void setStrength(double input)
    {
        STRENGTH = input;
    }
    public void setAgility(double input)
    {
        AGILITY = input;
    }
    public void setEndurance(double input)
    {
        ENDURANCE = input;
    }
    public void setDexterity(double input)
    {
        DEXTERITY = input;
    }
    public void setIntelligence(double input)
    {
        INTELLIGENCE = input;
    }
    public void setWisdom(double input)
    {
        WISDOM = input;
    }

    public bool getIfInAction()
    {
        return ifInAction;
    }



    /*warning = GameObject.FindGameObjectWithTag("Warning");
        warningText = GameObject.FindGameObjectWithTag("WarningText");
        information = GameObject.FindGameObjectWithTag("Information");
        informationText = GameObject.FindGameObjectWithTag("InformationText");*/
}