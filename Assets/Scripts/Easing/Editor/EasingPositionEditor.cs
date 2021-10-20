using UnityEditor;
using UnityEngine;

namespace EasingTC
{
    [CustomEditor(typeof(EasingPosition))]
    public class EasingPositionEditor : Editor
    {
        EasingPosition _target;

        Vector3 prevPos;
        bool prevPosFlag;

        private void OnEnable()
        {
            _target = (EasingPosition)target;

            if (_target.useLocalPosition)
                prevPos = _target.transform.localPosition;
            else
                prevPos = _target.transform.position;
        }

        public override void OnInspectorGUI()
        {

            EditorGUILayout.LabelField("ANIMATION CHOICE", EditorStyles.boldLabel);

            _target.animationType = (AnimationType)EditorGUILayout.EnumPopup(new GUIContent("Animation Type", "Ease In : Start slow.\nEase Out : End slow.\nEase In Out : Start and end slow.\nMirror : Go back and forth.\nSpecial Ease : Bounce or back effect."), _target.animationType);

            switch (_target.animationType)
            {
                case AnimationType.EaseIn:
                    _target.easeInType = (EaseIn)EditorGUILayout.EnumPopup(new GUIContent("Ease In Type", "Quad : Slow slope.\nCirc : Hard slope."), _target.easeInType);
                    break;

                case AnimationType.EaseOut:
                    _target.easeOutType = (EaseOut)EditorGUILayout.EnumPopup(new GUIContent("Ease Out Type", "Quad : Slow slope.\nCirc : Hard slope."), _target.easeOutType);
                    break;

                case AnimationType.EaseInOut:
                    _target.easeInOutType = (EaseInOut)EditorGUILayout.EnumPopup(new GUIContent("Ease In Out Type", "Quad : Slow slope.\nCirc : Hard slope."), _target.easeInOutType);
                    break;

                case AnimationType.Mirror:
                    _target.mirorType = (MirorType)EditorGUILayout.EnumPopup(new GUIContent("Mirror Type", "Quad : Slow slope.\nCirc : Hard slope."), _target.mirorType);
                    break;

                case AnimationType.SpecialEase:
                    _target.specialEaseType = (SpecialEase)EditorGUILayout.EnumPopup(new GUIContent("Special Ease Type", "Back In : Back effect at start and go to end value.\nBack Out : Go to end value and back effect.\nBounce Out : Go to end value and bounce effect."), _target.specialEaseType);
                    break;
            }

            EditorGUILayout.Space();
            EditorGUILayout.LabelField("ANIMATION INFOS", EditorStyles.boldLabel);

            _target.playOnAwake = EditorGUILayout.Toggle(new GUIContent("Play On Awake", "Select if the animation should automatically start when the game start."), _target.playOnAwake);
            
            _target.loop = EditorGUILayout.Toggle(new GUIContent("Loop", "Select if the animation should automatically loop."), _target.loop);
            if (_target.loop)
                _target.loopType = (LoopType)EditorGUILayout.EnumPopup(new GUIContent("Loop Type", "Simple : Loop the animation.\nMirror : Loop the animation back and forth. (can't work with Mirror animation type"), _target.loopType);

            EditorGUILayout.Space();
            _target.useLocalPosition = EditorGUILayout.Toggle(new GUIContent("Use Local Position", "Select if you want to use local position.\nUnselect if you want to use world position."), _target.useLocalPosition);
            _target.useAnotherStartValue = EditorGUILayout.Toggle(new GUIContent("Use Another Start Position", "Select if you want to use a different start value.\nUnselect if you want to use the current value of the object as the start value."), _target.useAnotherStartValue);
            _target.addPosition = EditorGUILayout.Toggle(new GUIContent("Add Position", "Select if you want to add this value to the start value.\nUnselect if you want the object to go to this end value."), _target.addPosition);

            EditorGUILayout.Space();
            EditorGUILayout.LabelField("ANIMATION VALUES", EditorStyles.boldLabel);

            if (_target.useAnotherStartValue)
                _target.startPos = EditorGUILayout.Vector3Field(new GUIContent("Start Position", "Set the value for the start of the animation."), _target.startPos);

            if (_target.addPosition)
                _target.addPos = EditorGUILayout.Vector3Field(new GUIContent("Add Position", "Set the value that will be add to the start value."), _target.addPos);
            else
                _target.endPos = EditorGUILayout.Vector3Field(new GUIContent("End Position", "Set the value that the object will reach."), _target.endPos);

            _target.duration = EditorGUILayout.Slider(new GUIContent("Duration", "Set the duration of the animation. (in s)"), _target.duration, 0.01f, 20f);

            EditorGUILayout.Space();

            EditorGUILayout.LabelField("OPTIONS", EditorStyles.boldLabel);
            _target.followEndValue = EditorGUILayout.Toggle(new GUIContent("Follow End Value", "Select to see the end value you set."), _target.followEndValue);

            if (_target.followEndValue)
            {
                if (!prevPosFlag)
                {
                    if (_target.useLocalPosition)
                        prevPos = _target.transform.localPosition;
                    else
                        prevPos = _target.transform.position;
                }
                prevPosFlag = true;

                if (_target.addPosition)
                {
                    if (_target.useLocalPosition)
                        _target.transform.localPosition = prevPos + _target.addPos;
                    else
                        _target.transform.position = prevPos + _target.addPos;
                }
                else
                {
                    if (_target.useLocalPosition)
                        _target.transform.localPosition = _target.endPos;
                    else
                        _target.transform.position = _target.endPos;
                }
            }
            else
            {
                if (prevPosFlag)
                {
                    if (_target.useLocalPosition)
                        _target.transform.localPosition = prevPos;
                    else
                        _target.transform.position = prevPos;
                }
                prevPosFlag = false;

                if (_target.useLocalPosition)
                    prevPos = _target.transform.localPosition;
                else
                    prevPos = _target.transform.position;
            }
        }
    }
}