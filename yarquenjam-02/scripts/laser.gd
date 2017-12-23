# script: laser

extends Area2D

export var velocity = Vector2()
const scn_flare_enemy = preload("res://scenes/flare_enemy.tscn")
const scn_flare = preload("res://scenes/flare.tscn")

func _ready():
	set_process(true)
	create_flare()
	
	yield(get_node("vis_notifier"), "exit_screen")
	queue_free()
	pass

func _process(delta):
	translate(velocity * delta)
	pass

func create_flare():
	var flare = scn_flare.instance()
	flare.set_pos(get_pos())
	utils.main_node.add_child(flare)
	pass
	
func create_flare_enemy():
	var flare_enemy = scn_flare_enemy.instance()
	flare_enemy.set_pos(get_pos())
	utils.main_node.add_child(flare_enemy)
	pass

