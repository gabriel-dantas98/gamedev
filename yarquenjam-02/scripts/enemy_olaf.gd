extends "res://scripts/enemy.gd"
const scn_explosion = preload("res://scenes/explosion.tscn")

export var armor = 5 setget set_armor

func _ready():
	get_node("anim").play("walk")
	randomize()
	velocity = Vector2(0, 40)
	set_process(true)
	add_to_group("enemy")
	connect("area_enter", self, "_on_area_enter")
	pass
	
func _process(delta):
	translate(velocity * delta)
	
	if get_pos().y-20 >= get_viewport_rect().size.height:
		queue_free()
	pass
	
func _on_area_enter(other):
	if other.is_in_group("santa"):
		other.armor -= 1
		queue_free()
	pass	
	
func set_armor(new_value):
	armor = new_value
	if armor <= 0 :
		utils.find_node("tex_score").score += 30
		create_explosion()
		queue_free()
	pass	
	
func create_explosion():
	var explosion = scn_explosion.instance()
	explosion.set_pos(get_pos())
	utils.main_node.add_child(explosion)
	pass	
