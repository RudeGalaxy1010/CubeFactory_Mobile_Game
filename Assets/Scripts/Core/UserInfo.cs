using UnityEngine.Events;

// Player (User) info container

[System.Serializable]
public class UserInfo : ISaveable
{
    public UnityAction<int> OnScoreChanged;
    public UnityAction<int> OnLevelChanged;

    public int Score => _score;
    private int _score = 0;

    public int Level => _level;
    private int _level = 0;

    public Parameters AvailableParameters => _availableParameters;
    private Parameters _availableParameters = null;

    // TODO: need here?
    public void SetDefaultParameters(Parameters defaultParameters)
    {
        _availableParameters = defaultParameters;
    }

    public void AddScore(int value)
    {
        _score += value;
        OnScoreChanged?.Invoke(Score);
    }

    public void SetLevel(int value)
    {
        _level = value;
        OnLevelChanged?.Invoke(Level);
    }

    public object[] GetInfoToSave()
    {
        return new object[] { this };
    }

    public override string ToString()
    {
        return $"Score: {Score}\nLevel: {Level}\nParameters: {AvailableParameters}";
    }
}
