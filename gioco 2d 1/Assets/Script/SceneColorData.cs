using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "SceneColorConfig", menuName = "ScriptableObjects/SceneColorData", order = 1)]
public class SceneColorData : ScriptableObject
{
    [System.Serializable]
    public struct SceneColorMapping
    {
        public string sceneName; // Il nome esatto della scena
        public Color backgroundColor;
    }

    public List<SceneColorMapping> sceneColors;

    // Metodo di utilità per recuperare il colore velocemente
    public Color GetColorForScene(string name)
    {
        foreach (var mapping in sceneColors)
        {
            if (mapping.sceneName == name)
                return mapping.backgroundColor;
        }
        return Color.gray; // Colore di fallback se la scena non viene trovata
    }
}