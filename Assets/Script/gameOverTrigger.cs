using UnityEngine;
using UnityEngine.SceneManagement;

public class gameOverTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

   
    void OnCollisionEnter(Collision e)
    {
        if (e.collider.CompareTag("Player"))
        {
            Debug.Log("GAME OVER");
            GameObject.Find("Canvas").GetComponent<gameUI>().gameEnd();
            //SceneManager.LoadScene(0);
            gameUI.gameActiveState = false;
        }
    }
}
