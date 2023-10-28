using GamePlay.Entities.Bullets;
using GamePlay.Entities.Character.Components;
using GamePlay.Entities.Character.Skills;
using GamePlay.Entities.Character.Skills.CharacterSkills.MainSkills;
using GamePlay.Entities.Character.Skills.CharacterSkills.ShootSkills;
using GamePlay.Entities.Character.Skills.CharacterSkills.SupportSkills;
using GamePlay.Entities.Character.Skills.Enums;
using GamePlay.Entities.Mines;
using GamePlay.Entities.Turrets;
using GamePlay.Level;
using GamePlay.Level.ScriptableObjects;
using UnityEngine;
using Zenject;

namespace GamePlay.Entities.Character
{
    public class CharacterControl : MonoBehaviour
    {
        [SerializeField] private InitialSkillsConfig _initialSkillsConfig;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private GameObject _characterBody;
        [SerializeField] private RotationManager _rotationManager;
        [SerializeField] private MovementManager _movementManager;
        [SerializeField] private SkillsManager _skillsManager;
        [SerializeField] private InteractionControl _interactionControl;
        [SerializeField] private GameObject _shield;
        [SerializeField] private GameObject _swords;
        [SerializeField] private GameObject _vortex;
        [SerializeField] private Transform _shootingSkillPosition;
        private readonly InputController _inputController = new();

        private ISpawner<Enemies.EnemyControl> _enemySpawner ;
        private ISpawner<BulletObject> _bulletSpawner ;
        private ISpawner<Mine> _mineSpawner ;
        private ISpawner<Turret> _turretSpawner ;

        private const string InteractableKey = "Interactable";
        
        [Inject]
        private void Construct(ISpawner<Enemies.EnemyControl> enemy, ISpawner<BulletObject> bullet, ISpawner<Mine> mine, ISpawner<Turret> turret)
        {
            _enemySpawner = enemy;
            _bulletSpawner = bullet;
            _mineSpawner = mine;
            _turretSpawner = turret;
        }
        private void Awake()
        {
            _skillsManager.SkillDictionaries.SkillsDamage = _initialSkillsConfig.SkillsDamage;
            _skillsManager.SkillDictionaries.SkillsReloadTimer = _initialSkillsConfig.SkillsReloadTimer;
            InitSkills();
            _rotationManager.InitData(_characterBody.transform);
            Subscribes();
        }

        private void Update()
        {
            _rotationManager.MoveRotationTarget();
            _rotationManager.RotateCharacter();

            _inputController.CheckKeyboardKeys();
            _inputController.CheckMouseKeys();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer(InteractableKey))
            {
                _interactionControl.CurrentInteractableObject = other.gameObject;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer(InteractableKey))
            {
                _interactionControl.CurrentInteractableObject = null;
            }
        }

        private void OnDestroy()
        {
            Unsubscribe();
        }

        private void InitSkills()
        {
            _skillsManager.SetSkill(InputSkillVariable.Shift, SkillTypes.Teleport, new Teleport(_rigidbody));
            _skillsManager.SetSkill(InputSkillVariable.LeftButtonMouse, SkillTypes.Arrow, new Arrow(_bulletSpawner, _shootingSkillPosition));
            _skillsManager.SetSkill(InputSkillVariable.RightButtonMouse, SkillTypes.Swords, new Swords(_swords));
        }

        private void OnShiftSkill() =>
            _skillsManager.Skills[InputSkillVariable.Shift].UseSkill();


        private void OnLeftButtonMouseSkill() =>
            _skillsManager.Skills[InputSkillVariable.LeftButtonMouse].UseSkill();


        private void OnRightButtonMouseSkill() =>
            _skillsManager.Skills[InputSkillVariable.RightButtonMouse].UseSkill();

        private void EPressed()
        {
            if (_interactionControl.CurrentInteractableObject != null)
            {
                _interactionControl.InteractWithEnvironment(_interactionControl.CurrentInteractableObject);
                _interactionControl.CurrentInteractableObject = null;
            }
        }

        private void MoveCharacter(Vector2 movementDirection)
        {
            _movementManager.MoveCharacter(movementDirection, _rigidbody);
        }

        private void Subscribes()
        {
            _inputController.OnMoveButtonsPressed += MoveCharacter;
            _inputController.OnShiftPressed += OnShiftSkill;
            _inputController.OnLeftButtonMousePressed += OnLeftButtonMouseSkill;
            _inputController.OnRightButtonMousePressed += OnRightButtonMouseSkill;
            _inputController.OnEPressed += EPressed;
        }

        private void Unsubscribe()
        {
            _inputController.OnMoveButtonsPressed -= MoveCharacter;
            _inputController.OnShiftPressed -= OnShiftSkill;
            _inputController.OnLeftButtonMousePressed -= OnLeftButtonMouseSkill;
            _inputController.OnRightButtonMousePressed -= OnRightButtonMouseSkill;
            _inputController.OnEPressed -= EPressed;
        }
    }
}