using TMPro;
using UnityEngine;

public class Experience : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI expText;
    int experience;
    public void AddExpPoints(int pointsToAdd)
    {
        experience += pointsToAdd;
        expText.text = experience.ToString();
    }
}
