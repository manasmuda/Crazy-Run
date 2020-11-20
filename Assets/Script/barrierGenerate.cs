using UnityEngine;

public class barrierGenerate : MonoBehaviour {

    public GameObject barrier;
    public int level;

    public int barrierMax;
    public int barrierMin;

    // Use this for initialization
    void Start () {
        barrierMin = level-2;
        if (barrierMin < 0)
        {
            barrierMin = 0;
        }
        if (barrierMin > 2)
        {
            barrierMin = 2;
        }
        if (level > 3)
        {
            barrierMax = 4;
        }
        else
        {
            barrierMax = level+1;
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}

   
    void OnTriggerEnter(Collider e)
    {
       
        if (e.CompareTag("Player"))
        {
            
            Vector3 planePos = gameObject.transform.parent.position;           
            
            for(int i=-3;i<4;i+=3)
            {
                int temp = Random.Range(barrierMin, barrierMax);
                for (int j=0;j<temp;j++)
                {
                    
                    int seed = System.Guid.NewGuid().GetHashCode();
                    Random.InitState(seed);
                    
                    Vector3 barrierPos = new Vector3(i, 2.75f, Random.Range(planePos.z + 50 + (j * 100/temp), planePos.z + 50 + ((j+1)*100/temp)));
                    
                    Instantiate(barrier, barrierPos, transform.rotation);
                }
            }
        }
    }
}
