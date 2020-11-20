using UnityEngine;

public class barrierDestroy : MonoBehaviour {

    
    void Start () {
	
	}
	
	
	void Update () {
    
    }

    
    void OnCollisionEnter(Collision e)
    {
        if (e.collider.CompareTag("barrier"))
        {
            Destroy(e.gameObject);
        }
    }
}
