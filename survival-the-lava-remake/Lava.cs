using Godot;
using System;

public partial class Lava : StaticBody3D
{
	[Export] public float RiseSpeed = 0.7f;
	

	public override void _Ready()
	{
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector3 motion = Vector3.Up * RiseSpeed * (float)delta;
		Position += motion;
		ConstantLinearVelocity = Vector3.Up * RiseSpeed;
	}
}
