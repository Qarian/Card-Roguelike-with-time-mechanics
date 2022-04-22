using Managers;
using UI.Cards;
using UI.CardsManagement;
using UI.Entities;
using UnityEngine;
using Utilities;
using Zenject;

namespace Installers
{
    public class EncounterInstaller : MonoInstaller<EncounterInstaller>
    {
        [SerializeField] private EnemyEntity enemyPrefab;

        [Space]
        [SerializeField] private CanvasProvider canvasProvider;
        [SerializeField] private UICardsController uiCardsController;
        [SerializeField] private UICardsDeck uiCardsDeck;
        [SerializeField] private UICardsHand uiCardsHand;
        [SerializeField] private UICardPreview uiCardPreview;
        [SerializeField] private EntitiesLayoutManager entitiesLayoutManager;
        [SerializeField] private EncounterManager encounterManager;
        [SerializeField] private PostCombatManager postCombatManager;
        [SerializeField] private PlayerEntity playerEntity;
        
    
        public override void InstallBindings()
        {
            Container.Bind<CanvasProvider>().FromInstance(GetComponent(ref canvasProvider)).AsSingle().NonLazy();
            Container.Bind<UICardsController>().FromInstance(GetComponent(ref uiCardsController)).AsSingle();
            Container.Bind<UICardsDeck>().FromInstance(GetComponent(ref uiCardsDeck)).AsSingle();
            Container.Bind<UICardsHand>().FromInstance(GetComponent(ref uiCardsHand)).AsSingle();
            Container.Bind<UICardPreview>().FromInstance(GetComponent(ref uiCardPreview)).AsSingle();
            Container.Bind<EntitiesLayoutManager>().FromInstance(GetComponent(ref entitiesLayoutManager)).AsSingle();
            Container.Bind<EncounterManager>().FromInstance(GetComponent(ref encounterManager)).AsSingle();
            Container.Bind<PostCombatManager>().FromInstance(GetComponent(ref postCombatManager)).AsSingle();
            Container.Bind<PlayerEntity>().FromInstance(GetComponent(ref playerEntity)).AsSingle();
            
            Container.Bind<CardUI.Factory>().FromNew().AsSingle();
            Container.BindFactory<EnemyEntity, EnemyEntity.Factory>().FromComponentInNewPrefab(enemyPrefab);
        }

        public T GetComponent<T>(ref T component) where T : MonoBehaviour
        {
            if (!component)
            {
                Debug.LogWarning($"{typeof(T)} has not been assigned!");
                component = FindObjectOfType<T>();
            }
        
            return component;
        }
    }
}
