using UnityEngine;
using UnityEngine.SceneManagement;


public class destroy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)

    {

        if (collision.gameObject.tag == "Missile")
        {

            Destroy(gameObject);
            SceneManager.LoadScene(3);
        }


    }
            // Update is called once per frame
    void Update()
    {
        
    }
}
