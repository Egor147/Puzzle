using UnityEngine;
using UnityEngine.SceneManagement;

public class AgainButton : MonoBehaviour
{
    public void OnClick(){
        SceneManager.LoadScene("Game");
    }
}
