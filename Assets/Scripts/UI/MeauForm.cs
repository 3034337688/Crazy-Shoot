using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MeauForm : MonoBehaviour
{
    [SerializeField] private ToggleGroup toggleGroup;
    private Toggle currentSelectToggle => toggleGroup.GetFirstActiveToggle();
    private Toggle onToggle;


    private void Start()
    {
        var toggles = toggleGroup.GetComponentsInChildren<Toggle>();
        foreach (var toggle in toggles)
        {
            toggle.onValueChanged.AddListener(_ => OnToggleValueChanged(toggle));
        }

        currentSelectToggle.onValueChanged?.Invoke(true);
    }

    private void OnToggleValueChanged(Toggle toggle)
    {
        if(currentSelectToggle==onToggle)
        {
            switch(toggle.name)
            {
                case "GameStart":
                    SceneManager.LoadScene("Game");
                    break;
                case "Settings":
                    break;
                case "Love":
                    break;

                case "Quit":
                    Application.Quit();
                    UnityEditor.EditorApplication.isPlaying = false;
                    break;
                default:
                    throw new UnityException("开关名字无效");

            }

            Debug.Log(currentSelectToggle.name);
            return;
        }
        if(toggle.isOn)
        {
            Debug.Log($"当前选择的开关：{toggle.name}");
            onToggle = toggle;


        }
        else
        {
            Debug.Log($"反选的开关是{toggle.name}");
        }
    }
}
