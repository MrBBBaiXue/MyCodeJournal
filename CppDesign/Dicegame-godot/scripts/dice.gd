extends Sprite
#export variables
export var point = 0

# Called when the node enters the scene tree for the first time.
func _ready():
	_redraw()
	pass

func _redraw():
	var tex = ImageTexture.new()
	var img = Image.new()
	var throw1 = rand_seed(OS.get_system_time_secs())
	randomize()
	point = randi() % 6 + 1
	var path = "res://assets/dice/Dice-%d.png" % (point)
	img.load(path)
	print("Load Dice Texture : %s" % (path))
	tex.create_from_image(img)
	texture = tex
	pass
