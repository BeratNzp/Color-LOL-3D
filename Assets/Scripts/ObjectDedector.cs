using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class ObjectDedector : MonoBehaviour
{
    void OnTriggerEnter (Collider other) {
        if (!Game.isGameOver)
        {
            string tag = other.tag;

            if (tag.Equals ("Object"))
            {
                Level.Instance.objectsInScene--;
                UIManager.Instance.UpdateLevelProgress ();
                
                Destroy (other.gameObject);

                // check if win scene
                if (Level.Instance.objectsInScene == 0)
                {
                    Level.Instance.PlayWinFx ();
                    Invoke ("NextLevel", 2f);
                }
            }
            else if (tag.Equals ("Obstacle"))
            {
                Game.isGameOver = true;
                Camera.main.transform
                    .DOShakePosition (1f, .2f, 20, 90f)
                    .OnComplete (() => {
                        Level.Instance.RestartLevel ();
                    });
            }
        }
    }

    void NextLevel()
    {
        Level.Instance.LoadNextLevel ();
    }
}
