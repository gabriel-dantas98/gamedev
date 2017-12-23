# script: ship

extends Area2D

var armor = 4 setget set_armor
const scn_laser = preload("res://scenes/boladeneve.tscn")
const scn_explosion = preload("res://scenes/explosion.tscn")

signal armor_changed

func _ready():
	Input.set_mouse_mode(Input.MOUSE_MODE_HIDDEN)
	get_node("anim").play("walk")
	set_process_input(true)
	set_process(true)
	add_to_group("santa")
	pass

func _input(event):
	if(event.is_action_pressed("shoot")):
		shoot()
	pass

func _process(delta):
	# tracking mouse
	var motion = (utils.mouse_pos.x - get_pos().x) * 0.02
	translate(Vector2(motion, 0))
	
	# clamping to view
	var pos = get_pos()
	pos.x   = clamp(pos.x, 0+16, utils.view_size.width-16)
	set_pos(pos)
	pass

func shoot():
	var pos_bazooka  = get_node("bazooka/bazooka_boca" ).get_global_pos()
	create_laser(pos_bazooka)
	pass
	
func set_armor(new_value):
	if new_value > 4: return
	
	if new_value < armor:
		audio_player.play("hit")
	
	armor = new_value
	emit_signal("armor_changed", armor)
	if armor <= 0:
		Input.set_mouse_mode(Input.MOUSE_MODE_VISIBLE)
		create_explosion()
		queue_free()
	pass

func create_laser(pos):
	var laser = scn_laser.instance()
	laser.set_pos(pos)
	utils.main_node.add_child(laser)
	pass
	
func create_explosion():
	var explosion = scn_explosion.instance()
	explosion.set_pos(get_pos())
	utils.main_node.add_child(explosion)
	pass

