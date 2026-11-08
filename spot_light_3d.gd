extends Node3D

# Using @onready ensures the node is loaded before the script tries to find it.
@onready var light: SpotLight3D = $player/SpotLight3D

func _input(event):
	# Make sure "flashlight" is defined in Project > Project Settings > Input Map
	if Input.is_action_just_pressed("flashlight"):
		# Use the 'visible' property to turn it on or off
		light.visible = !light.visible
