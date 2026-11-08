using Godot;

public partial class Camera3d : Camera3D
{
	private bool _enable = false;

	[Export]
	public bool Enable
	{
		get => _enable;
		set
		{
			_enable = value;
			Current = value;
		}
	}

	[Export] public float MaxPitch = 89.0f;
	[Export] public float MinPitch = -89.0f;
	[Export] public float MouseSensitivity = 0.0015f; // Added [Export] so you can adjust in Inspector

	// Track the vertical rotation explicitly to avoid Euler angle corruption
	private float _pitch = 0.0f;

	public override void _Ready()
	{
		Input.MouseMode = Input.MouseModeEnum.Captured;
		
		// Synchronize initial pitch with whatever the camera is set to in the editor
		_pitch = Rotation.X;
	}

	public override void _Input(InputEvent @event)
	{
		if (@event.IsActionPressed("ui_cancel"))
		{
			if (Input.MouseMode == Input.MouseModeEnum.Captured)
			{
				Input.MouseMode = Input.MouseModeEnum.Visible;
			}
			else
			{
				Input.MouseMode = Input.MouseModeEnum.Captured;
			}
		}

		if (@event is InputEventMouseMotion mouseMotionEvent && Input.MouseMode == Input.MouseModeEnum.Captured)
		{
			// 1. Handle horizontal look (yaw) by rotating around the global Y axis directly
			RotateY(-mouseMotionEvent.Relative.X * MouseSensitivity);

			// 2. Handle vertical look (pitch) using our clean math variable
			_pitch -= mouseMotionEvent.Relative.Y * MouseSensitivity;
			_pitch = Mathf.Clamp(_pitch, Mathf.DegToRad(MinPitch), Mathf.DegToRad(MaxPitch));

			// 3. Re-apply the transformations safely to avoid axis contamination
			Vector3 currentRotation = Rotation;
			currentRotation.X = _pitch;
			currentRotation.Z = 0.0f; // Force roll to 0 to prevent tilting sideways
			Rotation = currentRotation;
		}
	}
	public override void _Process(double delta)
	{
		if (Area3d.isPlayerInside == true)
		{
			Current = false;
		}
	}
}
