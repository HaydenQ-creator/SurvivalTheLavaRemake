extends CharacterBody3D
class_name Player

@onready var camera_1 = $CameraPivot/Camera3D
@onready var camera_2 = $CameraPivot/Camera3D2


var SPEED = 10
var JUMP_VELOCITY = 9

# 1. Get a reference to your camera
@onready var camera: Camera3D = $Camera3D 

func _on_body_entered(body : CollisionShape3D):
	if body.is_in_group("Player"):
		swap_camera()
		
func swap_camera():
	camera_1.currnet = false
	camera_2.current = true

func _physics_process(delta: float) -> void:
	# Add the gravity.
	if not is_on_floor():
		velocity += get_gravity() * delta

	# Handle jump.
	if Input.is_action_just_pressed("ui_accept") and is_on_floor():
		velocity.y = JUMP_VELOCITY
	
	if Input.is_action_just_pressed("run"):
		SPEED = 15
	elif Input.is_action_just_released("run"):
		SPEED = 10
		
	var input_dir := Input.get_vector("a", "d", "w", "s")
	

	var look_direction := camera.global_transform.basis
	var direction := (look_direction * Vector3(input_dir.x, 0, input_dir.y)).normalized()

		
	
	direction.y = 0
	direction = direction.normalized()

	if direction != Vector3.ZERO:
		velocity.x = direction.x * SPEED
		velocity.z = direction.z * SPEED
	else:
		velocity.x = move_toward(velocity.x, 0, SPEED)
		velocity.z = move_toward(velocity.z, 0, SPEED)

	move_and_slide()
