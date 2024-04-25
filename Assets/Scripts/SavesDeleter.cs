using UnityEngine;
using YG;

public class SavesDeleter : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            YandexGame.ResetSaveProgress();
            YandexGame.SaveProgress();
        }
    }
}
