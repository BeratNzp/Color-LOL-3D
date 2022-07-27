using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    #region  Singleton class: Level

    public static Level Instance;

    void Awake ()
    {
        if (Instance == null) {
            Instance = this;
        }
    }

    #endregion
    
    [SerializeField] ParticleSystem winFx;

    [Space]
    public int objectsInScene;
    public int totalObjects;
    public int firstLevelObjects;
    public int secondLevelObjects;

    [SerializeField] Transform firstLevelObjectsParent;
    [SerializeField] Transform secondLevelObjectsParent;

    // Start is called before the first frame update
    void Start()
    {
        CountObjects();
    }

    // Update is called once per frame
    void CountObjects ()
    {
        firstLevelObjects = firstLevelObjectsParent.childCount;
        secondLevelObjects = secondLevelObjectsParent.childCount;
        objectsInScene = firstLevelObjects + secondLevelObjects;
        totalObjects = objectsInScene;
    }

    public void PlayWinFx ()
    {
        winFx.Play ();
    }

    public void LoadNextLevel () 
    {
        SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
    }

    public void RestartLevel () 
    {
        SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
    }
}
