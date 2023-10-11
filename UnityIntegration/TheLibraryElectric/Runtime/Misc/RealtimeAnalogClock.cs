using UnityEngine;
using System;

namespace TheLibraryElectric.Misc
{
	[AddComponentMenu("The Library Electric/Misc/Realtime Analog Clock")]
    public class RealtimeAnalogClock : ElectricBehaviour
    {
        public enum RotationEnum
        {
            XAxis, YAxis, ZAxis
        };
        [Header("Rotation")] 
        [Tooltip("Flip the rotation of the clock hands in case they are reversed.")]
        public bool flip;
        [Tooltip("The axis of rotation for the clock hands.")]
        public RotationEnum rotationAxis;
        [Header("Hand Transforms")]
        [Tooltip("The transform of the hours hand.")]
        public Transform hoursHand;
        [Tooltip("The transform of the minutes hand.")]
        public Transform minutesHand;
        [Tooltip("The transform of the seconds hand.")]
        public Transform secondsHand;
        private const float HoursToDegrees = 360f / 12f;
        private const float MinutesToDegrees = 360f / 60f;
        private const float SecondsToDegrees = 360f / 60f;
        private int _hours;
        private int _minutes;
        private int _seconds;
        
        private void Update()
        {
            _hours = DateTime.Now.Hour;
            _minutes = DateTime.Now.Minute;
            _seconds = DateTime.Now.Second;
            if (!flip)
            {
                switch (rotationAxis)
                {
                    case RotationEnum.XAxis:
                        hoursHand.localRotation = Quaternion.Euler(HoursToDegrees * _hours, 0f, 0f);
                        minutesHand.localRotation = Quaternion.Euler(MinutesToDegrees * _minutes, 0f, 0f);
                        secondsHand.localRotation = Quaternion.Euler(SecondsToDegrees * _seconds, 0f, 0f);
                        break;
                    case RotationEnum.YAxis:
                        hoursHand.localRotation = Quaternion.Euler(0f, HoursToDegrees * _hours, 0f);
                        minutesHand.localRotation = Quaternion.Euler(0f, MinutesToDegrees * _minutes, 0f);
                        secondsHand.localRotation = Quaternion.Euler(0f, SecondsToDegrees * _seconds, 0f);
                        break;
                    case RotationEnum.ZAxis:
                        hoursHand.localRotation = Quaternion.Euler(0f, 0f, HoursToDegrees * _hours);
                        minutesHand.localRotation = Quaternion.Euler(0f, 0f, MinutesToDegrees * _minutes);
                        secondsHand.localRotation = Quaternion.Euler(0f, 0f, SecondsToDegrees * _seconds);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            else
            {
                switch (rotationAxis)
                {
                    case RotationEnum.XAxis:
                        hoursHand.localRotation = Quaternion.Euler(-HoursToDegrees * _hours, 0f, 0f);
                        minutesHand.localRotation = Quaternion.Euler(-MinutesToDegrees * _minutes, 0f, 0f);
                        secondsHand.localRotation = Quaternion.Euler(-SecondsToDegrees * _seconds, 0f, 0f);
                        break;
                    case RotationEnum.YAxis:
                        hoursHand.localRotation = Quaternion.Euler(0f, -HoursToDegrees * _hours, 0f);
                        minutesHand.localRotation = Quaternion.Euler(0f, -MinutesToDegrees * _minutes, 0f);
                        secondsHand.localRotation = Quaternion.Euler(0f, -SecondsToDegrees * _seconds, 0f);
                        break;
                    case RotationEnum.ZAxis:
                        hoursHand.localRotation = Quaternion.Euler(0f, 0f, -HoursToDegrees * _hours);
                        minutesHand.localRotation = Quaternion.Euler(0f, 0f, -MinutesToDegrees * _minutes);
                        secondsHand.localRotation = Quaternion.Euler(0f, 0f, -SecondsToDegrees * _seconds);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}