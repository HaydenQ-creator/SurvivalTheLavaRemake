extends Area3D

@onready var camera_1 = $"../../Player/Camera3D"
@onready var camera_2 = $"../../Camera3D2"


func _on_body_entered(body : CharacterBody3D):
	if body_entered:
		swap_camera()
	
func swap_camera():
	camera_2.make_current()
