using System.Collections.Generic;
using GamePlay.Bullets.Movers;
using GamePlay.Character.Components;
using GamePlay.Character.Skills;
using GamePlay.Character.Skills.CharacterSkills.MainSkills;
using GamePlay.Character.Skills.CharacterSkills.ShootSkills;
using GamePlay.Character.Skills.CharacterSkills.SupportSkills;
using GamePlay.Entities.Bullets;
using GamePlay.Entities.Character.Skills.CharacterSkills.ShootSkills;
using GamePlay.Entities.Enemy;
using GamePlay.Entities.Mines;
using GamePlay.Entities.Turrets;
using GamePlay.Level;
using GamePlay.Level.ScriptableObjects;
using UnityEngine;
using Zenject;

namespace GamePlay.Character
{
    public class Character : MonoBehaviour
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
        [SerializeField] private Transform _shootingSkillPos;
        private readonly InputController _inputController = new();
        private ISpawner<Enemy> _enemy;
        private ISpawner<Bullet> _bullet;
        private ISpawner<Mine> _mine;
        private ISpawner<Turret> _turret;

        private const string InteractableKey = "Interactable";

        public GameObject Shield => _shield;
        public GameObject Swords => _swords;
        public GameObject Vortex => _vortex;
        public Transform ShootingSkillPos => _shootingSkillPos;

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
            _skillsManager.SetSkill(InputSkillVariable.Shift, SkillTypes.Teleport, new Teleport());
            _skillsManager.SetSkill(InputSkillVariable.LeftButtonMouse, SkillTypes.Arrow, new Arrow(SkillTypes.Arrow, new StandardBullet()));
            _skillsManager.SetSkill(InputSkillVariable.RightButtonMouse, SkillTypes.Swords, new Swords());
        }
        private void OnShiftSkill() =>
            _skillsManager.Skills[InputSkillVariable.Shift].UseSkill(_characterBody);
        

        private void OnLeftButtonMouseSkill() =>
            _skillsManager.Skills[InputSkillVariable.LeftButtonMouse].UseSkill(_characterBody);
        

        private void OnRightButtonMouseSkill() =>
            _skillsManager.Skills[InputSkillVariable.RightButtonMouse].UseSkill(_characterBody);
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
        [Inject]
        private void Constract(ISpawner<Enemy> enemy, ISpawner<Bullet> bullet, ISpawner<Mine> mine, ISpawner<Turret> turret)
        {
            _enemy = enemy;
            _bullet = bullet;
            _mine = mine;
            _turret = turret;
        }
        
    }
}