extends CharacterBody3D
@onready var nav = $NavigationAgen3D

var SPEED = 5.0

func target_position(target):
	nav.target_position = target
	
