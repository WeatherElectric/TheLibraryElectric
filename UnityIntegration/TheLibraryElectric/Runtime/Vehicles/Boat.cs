using UnityEngine;
using SLZ.SFX;
using SLZ.Vehicle;
using SLZ.Rig;
using static System.Math;
using TheLibraryElectric.Water;

namespace TheLibraryElectric.Vehicles
{
    public class Boat : ElectricBehaviour
    {
        [Header("SFX")]
        public MotorSFX motorSFX;
        [Tooltip("Particle systems that will emit splashes")]
        public ParticleSystem[] Particles;
        [Tooltip("Particles per emission")]
        public int ParticleCount = 5;
        [Tooltip("Delay between emissions in seconds")]
        public float DelayBetweenParticles = 0.1f;
        [Tooltip("Random delay that gets added to the delay with max as this variable and min has the negative of this var")]
        public float RandomVariance = 0.05f;
        [Tooltip("Every how many seconds the boat checks if it's in water. More checks are laggier")]
        public float WaterCheckDelay = 1f;
        [Tooltip("List of bodies the boat should check to know if it's in water. More checks are laggier. WIll use body to accelerate if length is 0")]
        public Rigidbody[] Bodiestocheck;

        [Header("Controls")]
        public Seat DriverSeat;
        [Tooltip("This should rotate on the Y axis")]
        public Transform SteeringWheel;
        [Tooltip("The minimum and maximum angle of rotation of the steering wheel")]
        public Vector2 WheelMinMaxAngle;
        [Tooltip("If the boat can reverse or not")]
        public bool CanReverse;

        [Header("Parts")]
        [Tooltip("These should rotate on the Y axis")]
        public Transform[] Rudders;
        [Tooltip("The minimum and maximum angle of rotation of the rudders")]
        public Vector2 RudderMinMaxAngle;
        [Tooltip("This will accelerate on the Z axis")]
        public Rigidbody BodyToAccelerate;
        [Tooltip("These will rotate on the Y axis")]
        public Rigidbody[] Propellers;
        [Tooltip("Force that propellers use to spin, in Newtons")]
        public float PropellerForce;
        [Tooltip("The speedometer's pointer, at position 0")]
        public Transform Speedometer;
        [Tooltip("Y rotation for the speedometer to reach its max. set to 0 to disable it and ignore previous paramater")]
        public float MaxSpeedometerRotation;

        [Header("Physics")]
        [Tooltip("Speed of the accelerated body, in Newtons")]
        public float Speed = 100;
        [Tooltip("Max forward boat speed")]
        public float MaxSpeed = 15;
        [Tooltip("Max force turn per second, in Newtons")]
        public float MaxTurn = 100;
        [Tooltip("What percent of strength gets added to the motor per second to match the stick")]
        public float MotorAccel = 15;
        [Tooltip("How fast the motor decelerates compared to accelerate")]
        public float DecelMultiplier = 2;
        [Tooltip("How fast the boat reverse compared to going forward")]
        public float ReverseMultiplier = 0.5f;

        public override string Comment => "Tweak values as you please! These starting values are most likely not right for you! Hover on most values to see their tooltip. None of the sfx stuff is needed. None of the parts are needed as long as you have a rigidbody on this object. Controls are all needed. Physics values should all be set";

        private BaseController _Controller;
        private bool _IsPlayerIn = false;
        private float _JoystickY;
        private float _SteeringY;
        private float _SteeringRudderRatio = 1;
        private float _MotorStrength;
        private float _TimeCounter;
        private bool _IsInWater;
        private float _TimerChecks;
        private float _CurrentDelay = 0;
        private float _LastSpeed;

        void Start()
        {
            DriverSeat.RegisteredEvent += SeatEnter;
            DriverSeat.DeRegisteredEvent += SeatExit;
            _CurrentDelay = DelayBetweenParticles + Random.Range(-RandomVariance, RandomVariance);
            Debug.Log("Getting absolute of should-be-positive-values");
            ReverseMultiplier = Abs(ReverseMultiplier);
            DecelMultiplier = Abs(DecelMultiplier);
            MotorAccel = Abs(MotorAccel);
            MaxSpeed = Abs(MaxSpeed);
            WaterCheckDelay = Abs(WaterCheckDelay);
            ParticleCount = Abs(ParticleCount);
            if(DriverSeat == null)
            {
                Debug.LogError("Driver seat is null. Can't fix!");
            }
            if(motorSFX == null)
            {
                Debug.LogError("Motor SFX is null! Fixing...");
                motorSFX = gameObject.AddComponent<MotorSFX>();
            }
            if(Speedometer == null)
            {
                Debug.LogError("Speedometer is null! Disabling...");
                MaxSpeedometerRotation = 0;
            }
            if(SteeringWheel == null)
            {
                Debug.LogError("Steering wheel is null! Expect errors, fixing anyway...");
                SteeringWheel = new GameObject().transform;
                SteeringWheel.parent = transform;
            }
            if(BodyToAccelerate == null)
            {
                Debug.LogError("Body to accelerate is null! Trying to grab from this object...");
                Rigidbody foundBody = gameObject.GetComponent<Rigidbody>();
                if (foundBody == null)
                {
                    Debug.LogError("Couldn't find Rigidbody, adding one with some basic values...");
                    BodyToAccelerate = gameObject.AddComponent<Rigidbody>();
                    BodyToAccelerate.mass = Speed;
                }
                else
                {
                    BodyToAccelerate = foundBody;
                }
            }
        }

        void Update()
        {
            if (_IsPlayerIn)
            {
                _JoystickY = _Controller.GetThumbStickAxis().y;
            }
            else
            {
                _JoystickY = 0f;
            }
            if (_JoystickY * 100 > _MotorStrength)
            {
                _JoystickY -= MotorAccel * DecelMultiplier * Time.deltaTime;
            }
            if (_JoystickY * 100 < _MotorStrength)
            {
                _JoystickY += MotorAccel * Time.deltaTime;
            }
            if (CanReverse)
            {
                Mathf.Clamp(_MotorStrength, -100, 100);
            }
            Mathf.Clamp(_MotorStrength, 0, 100);
            _SteeringY = SteeringWheel.rotation.y;
            _SteeringRudderRatio = (RudderMinMaxAngle.y - RudderMinMaxAngle.x) / (WheelMinMaxAngle.y - WheelMinMaxAngle.x);
            if (Rudders.Length > 0)
            {
                foreach (Transform rudder in Rudders)
                {
                    rudder.Rotate(0f, -rudder.rotation.eulerAngles.y, 0f);
                    rudder.Rotate(0f, _SteeringY * _SteeringRudderRatio, 0f);
                }
            }
            if (MaxSpeedometerRotation != 0)
            {
                Speedometer.Rotate(0, -Speedometer.rotation.eulerAngles.y, 0);
                Speedometer.Rotate(0, MaxSpeedometerRotation / 100 * (MaxSpeed / Vector3.Dot(BodyToAccelerate.transform.forward, BodyToAccelerate.velocity) * 100), 0);
            }
            if (_TimeCounter > _CurrentDelay)
            {
                _TimeCounter = 0;
                _CurrentDelay = DelayBetweenParticles + UnityEngine.Random.Range(-RandomVariance, RandomVariance);
                if (_IsInWater && (Particles.Length > 0))
                {
                    foreach (ParticleSystem system in Particles)
                    {
                        system.Emit(ParticleCount);
                    }
                }
            }
            else
            {
                _TimeCounter += Time.deltaTime;
            }

        }
        
        private void FixedUpdate()
        {
            if (Sign(_MotorStrength) == -1)
            {
                BodyToAccelerate.AddRelativeForce(new Vector3(0f, 0f, _MotorStrength * Speed * DecelMultiplier));
            }
            BodyToAccelerate.AddRelativeForce(new Vector3(0f, 0f, _MotorStrength * Speed));
            BodyToAccelerate.velocity = new Vector3(Mathf.Clamp(BodyToAccelerate.velocity.x, float.MinValue, MaxSpeed), BodyToAccelerate.velocity.y, Mathf.Clamp(BodyToAccelerate.velocity.z, float.MinValue, MaxSpeed));
            if (!(-10 < _SteeringY && _SteeringY < 10))
            {
                BodyToAccelerate.AddRelativeTorque(new Vector3(0f, (MaxTurn / 100) * _SteeringY / (WheelMinMaxAngle.y - WheelMinMaxAngle.x) / 100, 0f));
            }
            if (Propellers.Length > 0)
            {
                foreach (Rigidbody propeller in Propellers)
                {
                    propeller.AddRelativeForce(new Vector3(0, PropellerForce * _MotorStrength, 0));
                }
            }
            if (_TimerChecks > WaterCheckDelay)
            {
                _TimerChecks = 0;
                if (Bodiestocheck.Length > 0)
                {
                    int wetbodies = 0;
                    foreach (Rigidbody body in Bodiestocheck)
                    {
                        RbBuoyancyManager wetness = body.gameObject.GetComponent<RbBuoyancyManager>();
                        if (wetness)
                        {
                            wetbodies += 1;
                        }
                    }
                    if (wetbodies > 0)
                    {
                        _IsInWater = true;
                    }
                    else
                    {
                        _IsInWater = false;
                    }
                }
                else if(BodyToAccelerate.gameObject.GetComponent<RbBuoyancyManager>() != null)
                {
                    _IsInWater = true;
                }
                else
                {
                    _IsInWater = false;
                }
            }
            else
            {
                _TimerChecks += Time.fixedDeltaTime;
            }

            float velocity = Vector3.Dot(BodyToAccelerate.transform.forward, BodyToAccelerate.velocity);
            motorSFX.UpdateMotor(velocity, (velocity - _LastSpeed)/Time.fixedDeltaTime , Abs(_MotorStrength));
            _LastSpeed = velocity;
        }

        private void OnDisable()
        {
            _IsPlayerIn = false;
        }

        private void SeatEnter()
        {
            motorSFX.StartMotor();
            _IsPlayerIn = true;
            if (DriverSeat.rigManager.ControllerRig.isRightHanded)
            {
                _Controller = DriverSeat.rigManager.ControllerRig.rightController;
            }
            else
            {
                _Controller = DriverSeat.rigManager.ControllerRig.leftController;
            }

        }

        private void SeatExit()
        {
            motorSFX.StopMotor();
            _Controller = null;
            _IsPlayerIn = false;
            _JoystickY = 0f;
        }
    }
}