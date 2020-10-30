
using UnityEngine;
using UnityEngine.UI;

public class HealthUIController : MonoBehaviour
{
    // Start is called before the first frame update

   
    void Start()
    {
    }

    public void LivesDisplayUpdate(int lives)
    {

        transform.GetChild(lives).gameObject.SetActive(false);
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
