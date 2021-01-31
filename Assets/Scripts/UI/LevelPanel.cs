using UnityEngine;

public class LevelPanel : MonoBehaviour
{
    [SerializeField] private TextMesh _text;

    public void UpdateText(int value)
    {
        _text.text = value.ToString();
    }
}
