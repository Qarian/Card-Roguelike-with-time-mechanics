using System.Collections.Generic;
using UnityEngine;

namespace PathManagement
{
    public class PathWindow : MonoBehaviour
    {
        [SerializeField] private PathOption optionPrefab;
        
        [Space]
        [SerializeField] private Transform optionsParent;
        
        [Space]
        [SerializeField] private List<PossibleOption> options;
        
        
        public void SpawnOptions()
        {
            foreach (var option in options)
            {
                if (Random.Range(0,100) <= option.probability)
                    CreateOption(option.name);
            }
        }

        public void CreateOption(string optionName)
        {
            PathOption po = Instantiate(optionPrefab, optionsParent);
            po.SetButton(optionName);
        }
    }

    [System.Serializable]
    public struct PossibleOption
    {
        [Range(0f ,100f)]
        public float probability;
        public string name;
    }
}
