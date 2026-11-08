using Godot;
using System;

public partial class DeathCamera : Camera3D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (Area3d.isPlayerInside == true)
		{
			Current = true;
		}
		if (Input.IsActionJustPressed("r"))
		{
			GetTree().ReloadCurrentScene();
		}
		if (Input.IsActionJustPressed("esc"))
		{
			GetTree().Quit();
		}
	}
}
