using UnityEngine.UI;
using UnityEngine;

public class TierManagerSkills2 : MonoBehaviour
{
    [Header("ButtonsTier1")]
    public Button[] buttons;
    public GameObject[] objectsToToggle;

    private void Start()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i;
            buttons[i].onClick.AddListener(() => ToggleObject(index));
        }
    }

    private void ToggleObject(int index)
    {
        if (index >= 0 && index < objectsToToggle.Length)
        {
            for (int i = 0; i < objectsToToggle.Length; i++)
            {
                if (i != index && objectsToToggle[i].activeSelf)
                {
                    objectsToToggle[i].SetActive(false);
                }
            }

            objectsToToggle[index].SetActive(true);
        }
    }
}
