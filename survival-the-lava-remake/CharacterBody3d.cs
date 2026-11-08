using Godot;

public partial class CharacterBody3d : CharacterBody3D
{
	[Export] public float Speed = 7.0f;
	[Export] public float SprintSpeed = 12.0f;
	[Export] public float Acceleration = 10.0f; // Controls how fast you reach max speed
	[Export] public float Deceleration = 12.0f; // Controls how fast you slide to a stop
	[Export] public float Jump = 8.0f; 

	private Camera3D _camera;

	public override void _Ready()
	{
		_camera = GetNode<Camera3D>("Camera3D");
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector3 velocity = Velocity;

		// Apply gravity if airborne
		if (!IsOnFloor())
		{
			velocity += GetGravity() * (float)delta;
		}
		if (Input.IsActionJustPressed("jump") && IsOnFloor())
		{
			velocity.Y += Jump;
		}
		if (Input.IsActionJustPressed("shift"))
		{
			Speed = SprintSpeed;
		}
		if (Input.IsActionJustReleased("shift"))
		{
			Speed = 7.0f;
		}

		// Get input vector (WASD configuration)
		Vector2 inputDir = Input.GetVector("a", "d", "w", "s");

		// Calculate direction based on camera orientation
		Basis camBasis = _camera.GlobalTransform.Basis;
		Vector3 forward = new Vector3(camBasis.Z.X, 0.0f, camBasis.Z.Z).Normalized();
		Vector3 right = new Vector3(camBasis.X.X, 0.0f, camBasis.X.Z).Normalized();

		Vector3 direction = (forward * inputDir.Y + right * inputDir.X).Normalized();

		// Smoothly interpolate the horizontal velocity
		if (direction != Vector3.Zero)
		{
			// Accelerate toward target direction
			velocity.X = Mathf.Lerp(velocity.X, direction.X * Speed, (float)delta * Acceleration);
			velocity.Z = Mathf.Lerp(velocity.Z, direction.Z * Speed, (float)delta * Acceleration);
		}
		else
		{
			// Decelerate smoothly to a stop
			velocity.X = Mathf.Lerp(velocity.X, 0.0f, (float)delta * Deceleration);
			velocity.Z = Mathf.Lerp(velocity.Z, 0.0f, (float)delta * Deceleration);
		}

		Velocity = velocity;
		MoveAndSlide();
	}
}
