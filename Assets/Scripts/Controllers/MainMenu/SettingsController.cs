using UnityEngine;
using UnityEngine.UI;

namespace Controllers.MainMenu
{
    public class SettingsController : MonoBehaviour
    {
        public UnityEngine.Camera mainCamera;
        public Toggle muteToggle;
        
        public void ToggleValueChanged()
        {
            if (muteToggle.isOn)
            {
                MuteAll();
            }
            else
            {
                UnmuteAll();
            }
        }

        public void MuteAll()
        {
            mainCamera.GetComponent<AudioSource>().mute = true;
        }

        public void UnmuteAll()
        {
            mainCamera.GetComponent<AudioSource>().mute = false;
        }
    }
}
