using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Scripts_LevelSelectMenu : MonoBehaviour
{
    public void StartLevel1()
    {
        SceneManager.LoadScene("Level1");
    }
    public void StartLevel2()
    {
        SceneManager.LoadScene("Level2");
    }
    public void StartLevel3()
    {
        SceneManager.LoadScene("Level3");
    }
    public void StartLevel4()
    {
        SceneManager.LoadScene("Level4");
    }
    public void StartLevel5()
    {
        SceneManager.LoadScene("Level5");
    }
}
