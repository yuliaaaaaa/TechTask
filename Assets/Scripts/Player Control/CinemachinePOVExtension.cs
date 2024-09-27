using Cinemachine;
using UnityEngine;

public class CinemachinePOVExtension : CinemachineExtension // Extension or Cinemachine
{
   [SerializeField] private float horizontalSpeed = 10f;
   [SerializeField] private float verticalSpeed = 10f;
   [SerializeField] private float clampAngle = 80f;
   
   private InputManager _inputManager;
   private Vector3 _startingRotation;

   protected override void Awake()
   {
      _inputManager = InputManager.Instance;
      base.Awake();
   }

   protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage,
      ref CameraState state, float deltaTime)
   {
      if (vcam.Follow)
      {
         if (stage == CinemachineCore.Stage.Aim)
         {
            if (_startingRotation == null) _startingRotation = transform.localRotation.eulerAngles;
            Vector2 deltaInput = _inputManager.GetMouseDelta();
            _startingRotation.x += deltaInput.x * verticalSpeed * Time.deltaTime;
            _startingRotation.y += deltaInput.y * horizontalSpeed * Time.deltaTime;
            _startingRotation.y = Mathf.Clamp(_startingRotation.y, -clampAngle, clampAngle);
            state.RawOrientation = Quaternion.Euler(-_startingRotation.y, _startingRotation.x, 0f);
         }
      }
   }
}
