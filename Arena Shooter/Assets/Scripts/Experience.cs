using TMPro;
using UnityEngine;

public class Experience : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI expText;
    int experience;

    private void Start()
    {
        UpdateExpText();
    }
    public void AddExpPoints(int pointsToAdd)
    {
        experience += pointsToAdd;
        UpdateExpText();
    }

    private void UpdateExpText()
    {
        expText.text = experience.ToString();
    }
}
