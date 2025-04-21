using UnityEngine;

public class GameCleanup : MonoBehaviour
{
    public void CleanupAndQuit()
    {
        StopAllCoroutines();

      
        Resources.UnloadUnusedAssets();

      
        Caching.ClearCache();

        System.GC.Collect();

       
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
