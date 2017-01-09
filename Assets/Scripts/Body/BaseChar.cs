using UnityEngine;

public class BaseChar : BaseBody 
{
	[Header("Mobility")]
	[SerializeField]
	float _maxSpeed = 20f;
    [SerializeField]
    float _boostSpeed = 2f;

    [SerializeField]
	float _smoothTime = 0.5f;
	[SerializeField]
	float _maxRotSpeed = 500f;

	float _curRotation = 0f;
	float _desiredRotation = 0f;
	float _rotVel = 0f;

	Rigidbody _rb = null;

	public bool WantsToMoveForward { get; set; }
	public bool WantsToMoveBackward { get; set; }
    public bool WantsToMoveLeft { get; set; }
    public bool WantsToMoveRight { get; set; }
    public bool WantsToBoost { get; set; }

	void Awake()
	{
		_rb = GetComponent<Rigidbody>();
	}

	void Start()
	{
		_curRotation = Mathf.Atan2(_rb.transform.forward.z, _rb.transform.forward.x) * Mathf.Rad2Deg;
		_desiredRotation = _curRotation;
		_rotVel = 0f;
	}

    // Update is called once per frame
    void Update()
    {
        UpdateMotion();
    }

	public void SetHeading(float heading)
	{
		_desiredRotation = heading;
	}

	void UpdateMotion()
	{
        Vector3 newPos = transform.position;

        float desiredSpeed = _maxSpeed * (WantsToBoost ? _boostSpeed : 1f);

        if (WantsToMoveForward)
        {
            newPos += transform.forward * desiredSpeed * Time.deltaTime;
        }
        else if (WantsToMoveBackward)
        {
            newPos -= transform.forward * desiredSpeed * Time.deltaTime;
        }

        if (WantsToMoveRight)
        {
            newPos += transform.right * desiredSpeed * Time.deltaTime;
        }
        else if (WantsToMoveLeft)
        {
            newPos -= transform.right * desiredSpeed * Time.deltaTime;
        }

        _curRotation = Mathf.SmoothDampAngle(_curRotation, _desiredRotation, ref _rotVel, _smoothTime, _maxRotSpeed);
        _rb.MoveRotation(Quaternion.AngleAxis(_curRotation, Vector3.up));

		_rb.MovePosition(newPos);
	}
}
