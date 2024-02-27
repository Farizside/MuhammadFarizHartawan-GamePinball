using UnityEngine;

public class PaddleController : MonoBehaviour
{
	public KeyCode input;
	public float springPower;

	private HingeJoint _hinge;
    private float _targetPressed;
    private float _targetRelease;

	private void Start()
  {
    _hinge = GetComponent<HingeJoint>();
    _targetPressed = _hinge.limits.max;
    _targetRelease = _hinge.limits.min;
  }

	private void Update()
  {
    ReadInput();
  }

  private void ReadInput()
  {
    JointSpring jointSpring = _hinge.spring;

    if (Input.GetKey(input))
    {
        jointSpring.targetPosition = _targetPressed;
    }
    else
    {
        jointSpring.targetPosition = _targetRelease;
    }

    _hinge.spring = jointSpring;
  }
}