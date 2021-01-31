using UnityEngine;
using UnityEngine.UI;

public class ScorePanel : MonoBehaviour
{
    [SerializeField] private Text _text;

    public void UpdateText(int value)
    {
        _text.text = value.ToString();
    }
}
