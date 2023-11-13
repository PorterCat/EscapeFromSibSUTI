using EscapeFromSibSUTI.script.Enums;
using EscapeFromSibSUTI.script.Scenes.Interfaces;

namespace EscapeFromSibSUTI.script.Scenes;

internal class CharacteristicSettingScene : IScene
{
    public void ShowScene(out SceneType returnScene)
    {
        returnScene = SceneType.CharacterCreation;

    }
}
