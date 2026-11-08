#Main camera
extends Camera3D

@export var enable := false:
	set(value):
		enable = value
		current = value

var mouse_sensitivity = 0.0015 

func _ready():
	Input.mouse_mode = Input.MOUSE_MODE_CAPTURED
	
	
func _input(event):
	if event.is_action_pressed("ui_cancel"):
		if Input.mouse_mode == Input.MOUSE_MODE_CAPTURED:
			Input.mouse_mode = Input.MOUSE_MODE_VISIBLE
		else:
			Input.mouse_mode = Input.MOUSE_MODE_CAPTURED
			
	if event is InputEventMouseMotion and Input.mouse_mode == Input.MOUSE_MODE_CAPTURED:
		rotate_y(-event.relative.x * mouse_sensitivity)
		rotate_object_local(Vector3(1,0,0), -event.relative.y * mouse_sensitivity)
		rotation.x = clamp(rotation.x, deg_to_rad(-89), deg_to_rad(89))
		rotation.z = 0
