using Sirenix.OdinInspector;
using System;
using UnityEngine;

namespace DragonDogStudios.UnitySoFunctional.Utilities
{
    public class AnimationTriggerSetter : SerializedMonoBehaviour
    {

        [SerializeField]
        private Func<string> ValueGetter;

        [SerializeField]
        private Animator _animator;

        private string _currentState;

        private void Start()
        {
            _currentState = ValueGetter();
            if (_animator != null)
            {
                _animator.SetTrigger(Animator.StringToHash(_currentState));
            }
        }

        private void Update()
        {
            var newState = ValueGetter();
            if (newState != _currentState && !_animator.GetBool(Animator.StringToHash(newState)))
            {
                _animator.ResetTrigger(Animator.StringToHash(_currentState));
                _animator.SetTrigger(Animator.StringToHash(newState));
                _currentState = newState;
            }
        }
    }
}