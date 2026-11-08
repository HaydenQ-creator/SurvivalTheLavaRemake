using Godot;
using System;

public partial class Area3d : Area3D
{
	public static bool isPlayerInside = false;

	public override void _Ready()
	{
		isPlayerInside = false;
		BodyEntered += OnBodyEntered;
	}

	private void OnBodyEntered(Node3D body)
	{
		if (body is CharacterBody3D && body.Name == "Player") 
		{
			isPlayerInside = true;
			GD.Print("Player Died!");
		}
	}
}
