extends Node3D

@export var enable := false:
	set(value):
		enable = value 
		if not Engine.is_editor_hint():
			%Camera3D.current = value

@onready var camera1 = $Camera3D
@onready var camera2 = $Camera3D2
