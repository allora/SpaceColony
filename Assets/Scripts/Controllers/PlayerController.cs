using UnityEngine;

public class PlayerController : MonoBehaviour 
{
	[SerializeField]
	float _rotateAmount = 1.0f;

    [SerializeField]
    float _zoomAmount = 1.0f;

    [SerializeField]
    Camera _camera = null;

	BaseChar _body = null;
	float _desiredHeading = 0f;
	
	void Awake () 
	{
		_body = GetComponent<BaseChar>();
	}

	void Start()
	{
		_desiredHeading = MathUtils.GetHeading2d(transform);
	}
	
	void Update ()
	{
        _camera.transform.LookAt(_body.transform);

        _body.WantsToMoveForward = Input.GetAxis("Forward") > 0f;
		_body.WantsToMoveBackward = Input.GetAxis("Forward") < 0f;

        _body.WantsToMoveRight = Input.GetAxis("Strafe") > 0f;
        _body.WantsToMoveLeft = Input.GetAxis("Strafe") < 0f;

        _body.WantsToBoost = Input.GetButton("Boost");

        if (Input.GetButton("Mod"))
        {
            if (Input.GetButton("Fire1"))
            {
                if (Input.GetAxis("Steer") < 0f)
                    _desiredHeading += _rotateAmount * Time.deltaTime;
                if (Input.GetAxis("Steer") > 0f)
                    _desiredHeading -= _rotateAmount * Time.deltaTime;
            }
        }

        if (Input.GetAxis("Zoom") > 0f)
            _camera.transform.position += _camera.transform.forward * _zoomAmount * Time.deltaTime;
        if (Input.GetAxis("Zoom") < 0f)
            _camera.transform.position -= _camera.transform.forward * _zoomAmount * Time.deltaTime;

        _desiredHeading = MathUtils.ClampAngle360(_desiredHeading);
		_body.SetHeading(_desiredHeading);
	}
}
