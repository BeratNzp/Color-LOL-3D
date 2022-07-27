using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    #region  Singleton class: UIManager

    public static UIManager Instance;

    void Awake ()
    {
        if (Instance == null) {
            Instance = this;
        }
    }

    #endregion

    [Header ("Level Progress UI")]
    [SerializeField] int sceneOffset;
    [SerializeField] TMP_Text currentLevelText;
    [SerializeField] TMP_Text nextLevelText;
    [SerializeField] Image progressFillImage;

    // Start is called before the first frame update
    void Start()
    {
        progressFillImage.fillAmount = 0f;
        SetLevelProgressText ();
    }

    void SetLevelProgressText ()
    {
        int level = SceneManager.GetActiveScene ().buildIndex + sceneOffset;
        currentLevelText.text = level.ToString ();
        nextLevelText.text = (level + 1).ToString ();
    }

    // Update is called once per frame
    public void UpdateLevelProgress()
    {
        float val = 1f - ((float) Level.Instance.objectsInScene / Level.Instance.totalObjects);
        //progressFillImage.fillAmount = val;
        progressFillImage.DOFillAmount (val, .4f);
    }
}
