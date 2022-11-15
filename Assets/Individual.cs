using UnityEngine;
using System.Collections;
using UnityEngine.AI;


public class Individual : MonoBehaviour
{
    public Camera cam;
    public NavMeshAgent agent;


    public float timer;
    public float speed;
    int newtarget;

    public bool male;

    public Color myColor;

    public float rFloat;
    public float gFloat;
    public float bFloat;
    public float aFloat;
    string destination ="" ;
    public Renderer myRenderer;


    public Vector3 Target;

    
    Vector3 StoreA = new Vector3(1.62f,0.05f,0.62f);
    Vector3 StoreB = new Vector3(-0.88f,0.05f,0.62f);
    Vector3 StoreC = new Vector3(-3.18f,0.05f,0.62f);

    Vector3 ExitLocation = new Vector3(-5.4f,0.55f,-1.64f);
   

    void Start()
    {
        newtarget = Random.Range(2, 5);
        aFloat = 1;

        newTarget();
    }
    void OnTriggerEnter(Collider other){
        string othertag ="";
        othertag = other.GetComponent<Collider>().tag;
        if (othertag == "StoreA" && destination=="A")
        {
            Manager.visitorsA += 1;
            Destroy(gameObject);
            
            
        }
        if (othertag == "StoreB" && destination=="B")
        {
            Manager.visitorsB += 1;
            Destroy(gameObject);
            
            
        }
        if (othertag == "StoreC" && destination=="C")
        {
            Manager.visitorsC += 1;
            Destroy(gameObject);
            
            
        }

    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        
        //Debug.Log(collisionInfo.collider.tag);
        if (collisionInfo.collider.tag == "Exit" )
        {
            Manager.left += 1;
            Destroy(gameObject);
            
        }
        if (collisionInfo.collider.tag == "StoreA" && destination=="A")
        {
            Manager.visitorsA += 1;
            Destroy(gameObject);
            
            
        }
        if (collisionInfo.collider.tag == "StoreB" && destination=="B")
        {
            Manager.visitorsB += 1;
            Destroy(gameObject);
            
            
        }
        if (collisionInfo.collider.tag == "StoreC" && destination=="C")
        {
            Manager.visitorsC += 1;
            Destroy(gameObject);
            
            
        }

    }

    void Update()
    {

        // timer += Time.deltaTime;

        // if ((transform.position - Target).sqrMagnitude <= 1f)
        // {
        //     newTarget();
        //     timer = 0;
        // }
    }




    void newTarget()
    {
        float threshold =Manager.probabilityStore;
        float myChance = Random.Range(0f, 1f);
        //Debug.Log("MyChance " +myChance);
            if (myChance <= threshold)
            {
                //VISIT A STORE
                float storenumber = Random.Range(0f, 1f);
                //Debug.Log("STORE number" + storenumber);

                if (storenumber <= Manager.probabilityA){
                    agent.SetDestination(StoreA);
                    Debug.Log("IRE A LA TIENDA A");
                    destination="A";
                    

                }
                else if (storenumber > Manager.probabilityA && storenumber <= Manager.probabilityA+Manager.probabilityB){
                    agent.SetDestination(StoreB);
                    Debug.Log("IRE A LA TIENDA B");
                    destination="B";
                    


                }
                else if (storenumber >  Manager.probabilityA+Manager.probabilityB)
                {
                     agent.SetDestination(StoreC);
                     Debug.Log("IRE A LA TIENDA C");
                     destination="C";
                     
                }


            }
        else if (myChance > threshold) {
            float newX = Random.Range(-3f, 2.5f);
            float newZ = Random.Range(-1f, 0.5f);

            Target = new Vector3(newX, gameObject.transform.position.y, newZ);
            agent.SetDestination(ExitLocation);
            destination="";

        }



        
        
    }

    IEnumerator infect()
    {
        transform.gameObject.tag = "Transitioning";
        myColor = new Color(1f, 1f, 0f, 1f);
        myRenderer.material.color = myColor;
        yield return new WaitForSeconds(Manager.transitionTime);
        male = true;
        transform.gameObject.tag = "Infected";
        myColor = new Color(1f, 0f, 0f, 1f);
        myRenderer.material.color = myColor;
        //Manager.infectedCases += 1;
        //Debug.Log(Manager.infectedCases);
    }


    void changeColor()
    {
        rFloat = Random.Range(0.0f, 1f);
        gFloat = Random.Range(0.0f, 1f);
        bFloat = Random.Range(0.0f, 1f);
        myColor = new Color(rFloat, gFloat, bFloat, 1f);
        myRenderer.material.color = myColor;

    }


    
}

