using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{

    public bool isGamePaused = true;
    public GameObject healthyPrefab;
    //Variables del input
    public int customersAmount;
    public float probabilityGeneral;
    public float probabilityA;
    public float probabilityB;
    public float probabilityC;

    int created= 0;
    float timerInterval = 1f;
    float timer =0f;

    public GameObject pauseMenuUI;
    public GameObject simulationUI;

    
    public GameObject inputCustomers;
    public GameObject inputStore;
    public GameObject inputProbabilityA;
    public GameObject inputProbabilityB;
    public GameObject inputProbabilityC;

    
    
    
    public Vector3 StoreA = new Vector3(-3.3f,0.5f,0.82f);
    public Vector3 StoreB = new Vector3(0.91f,0.5f,0.82f);
    public Vector3 StoreC = new Vector3(1.65f,0.5f,0.82f);

    void Start()
    {
        
        Pause();     

    }

   

    IEnumerator populate()
    {

        yield return new WaitForSeconds(1);
    }

    public void Pause()
    {
        simulationUI.SetActive(false);
        pauseMenuUI.SetActive(true);
        isGamePaused = true;
        Time.timeScale = 0f;
    }

    public void Begin()
    {
        ReadFromUI();
        Resume();
        Spawn();
    }
    public void ReadFromUI()
    {
        //LEER PROMEDIO DE VISITANTES POR SEGUNDO 
        try
        {
            
            string customerInput = inputCustomers.GetComponent<Text>().text;
            customersAmount = int.Parse(customerInput);
            Debug.Log("Lei el input de customers");

        }
        catch
        {
            customersAmount = 10;
            Debug.Log("NO Lei el input de healthy");
        }
        //LEER PPROBABILIDAD DE VISITAR UNA TIENDA 
        try
        {
            
            string probabilityInput = inputStore.GetComponent<Text>().text;
            probabilityGeneral = float.Parse(probabilityInput);
            Debug.Log("Lei el input de probabilidad de visitar tiendas");

        }
        catch
        {
            probabilityGeneral = 0.5f;
            Debug.Log("NO Lei el input de la probabilidad de tiendas");
        }
        //LEER PROBABILIDAD DE TIENDA A 
        
        try
        {
            
            string probabilityAInput = inputProbabilityA.GetComponent<Text>().text;
            probabilityA = float.Parse(probabilityAInput);
            Debug.Log("Lei el input de probabilidad de visitar tienda A");

        }
        catch
        {
            probabilityA = 0.33f;
            Debug.Log("NO Lei el input de la probabilidad de visitar tienda A");
        }
         //LEER PROBABILIDAD DE TIENDA B 
        
        try
        {
            
            string probabilityBInput = inputProbabilityB.GetComponent<Text>().text;
            probabilityB = float.Parse(probabilityBInput);
            Debug.Log("Lei el input de probabilidad de visitar tienda B");

        }
        catch
        {
            probabilityB = 0.33f;
            Debug.Log("NO Lei el input de la probabilidad de visitar tienda B");
        }
         //LEER PROBABILIDAD DE TIENDA C 
        
        try
        {
            
            string probabilityCInput = inputProbabilityC.GetComponent<Text>().text;
            probabilityC = float.Parse(probabilityCInput);
            Debug.Log("Lei el input de probabilidad de visitar tienda C");

        }
        catch
        {
            probabilityC = 0.33f;
            Debug.Log("NO Lei el input de la probabilidad de visitar tienda C");
        }
        Manager.customerTraffic= customersAmount;
        Manager.probabilityStore = probabilityGeneral;
        Manager.probabilityA= probabilityA;
        Manager.probabilityB= probabilityB;
        Manager.probabilityC= probabilityC;

    }

    public void Resume()
    {
        simulationUI.SetActive(true);
        pauseMenuUI.SetActive(false);
        isGamePaused = false;
        Time.timeScale = 1f;
    }


    
    public void Spawn()
        
    {
        
        // for (int i = 0; i < healthyAmount; i++)
        // {
        //     GameObject a = Instantiate(healthyPrefab) as GameObject;
        //     a.transform.position= new Vector3 (Random.Range(6.7f,9.5f ),0.1f, Random.Range(-2f, 0.5f));
        //     Manager.headCount += 1;

        // }


    }

    void Update()
    {
        
        timer += Time.deltaTime;
        if (timer >= timerInterval)
        {
            //Debug.Log(timerInterval.ToString()+ " seconds have passed!");
            timer = 0;
            created = 0;
            
        }
        if (created < customersAmount){
            GameObject a = Instantiate(healthyPrefab) as GameObject;
            a.transform.position= new Vector3 (Random.Range(6.7f,9.5f ),0.1f, Random.Range(-2f, 0.5f));
            Manager.headCount += 1;
            created+= 1;

        }

    }




    public void reLaunch()
    {
        SceneManager.LoadScene("Simulation");
        Manager.headCount = 0;
        Manager.visitorsA = 0;
    }


    public void quit()
    {
        Application.Quit();
    }

}
