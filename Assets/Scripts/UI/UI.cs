using System.Collections;
using UnityEngine;

[System.Serializable]
public class UI
{
    public ScorePanel ScorePanel;
    public LevelPanel LevelPanel;
    public ParametersPanel ParametersPanel;
    public ParametersPanel ProductParametersPanel;

    public void SubscribeAll()
    {
        var database = Database.Instance;
        database.UserInfo.OnScoreChanged += ScorePanel.UpdateText;
        database.UserInfo.OnLevelChanged += LevelPanel.UpdateText;
        database.ParametersController.OnLevelParametersChanged += ParametersPanel.UpdateParameters;
    }

    public void UnSubscribeAll()
    {
        var database = Database.Instance;
        database.UserInfo.OnScoreChanged -= ScorePanel.UpdateText;
        database.UserInfo.OnLevelChanged -= LevelPanel.UpdateText;
        database.ParametersController.OnLevelParametersChanged -= ParametersPanel.UpdateParameters;
    }
}
