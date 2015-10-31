package ee.wave.gameoflife;

public class Frame {
	
	public boolean[][] slots;
	public int width;
	public int height;
	
	public Frame(String[] rows) {
		this.height = rows.length;
		this.width = rows[0].length();
		
		this.slots = new boolean[this.height][this.width]; 
		
		for (int i=0; i<height; i++) {
			char[] row = rows[i].toCharArray();
			for (int j=0; j<width; j++) {
				this.slots[i][j] = row[j] == 'X';
			}
		}
		
	}
	
	public Frame(int width, int height) {
		this.width = width;
		this.height = height;
		this.slots = new boolean[this.height][this.width];
	}
	
	public Frame nextFrame() {
		Frame nextFrame = new Frame(this.width, this.height);
		
		for (int i=0; i<height; i++) {
			for (int j=1; j<width; j++) {
				boolean isCurrentSlotAlive = this.isAlive(j, i);
				int aliveSlotsCountAround = this.aliveSlotsCountAround(j, i);
				boolean nextSlot = nextStatus(isCurrentSlotAlive, aliveSlotsCountAround);
				nextFrame.setSlot(j, i, nextSlot);
			}
		}
		
		return nextFrame;
	}
	
	public void setSlot(int x, int y, boolean nextSlot) {
		this.slots[y][x] = nextSlot;
	}
	
	public boolean nextStatus(boolean isCurrentSlotAlive, int aliveSlotsCountAround) {
		if (isCurrentSlotAlive && (aliveSlotsCountAround<2 || aliveSlotsCountAround>3)) {
			return false;
		}
		
		if (!isCurrentSlotAlive && aliveSlotsCountAround==3) {
			return true;
		}
		
		return isCurrentSlotAlive;
	}
	
	public boolean getSlot(int x, int y) {
		return this.slots[y][x];
	}
	
	public int aliveSlotsCountAround(int x, int y) {
		int alive = 0;
		
		int[][] checks = {
				{x-1, y-1},
				{x, y-1},
				{x+1, y-1},
				{x-1, y},
				{x+1, y},
				{x-1, y+1},
				{x, y+1},
				{x+1, y+1}
		};
		
		for (int[] check : checks) {
			alive += isAlive(check[0], check[1]) ? 1 : 0;
		}
		
		return alive;
	}
	
	public boolean isAlive(int x, int y) {
		if (x >= 0 && y >=0 && x < this.width && y < this.height) {
			return this.getSlot(x, y);
		} else {
			return false;
		}
	}
	
	public String toString() {
		String s = "";
		
		for (int i=0; i<this.height; i++) {
			for (int j=0; j<this.width; j++) {
				s += this.isAlive(j, i) ? "X" : "-";
			}
		}
		
		return s;
	}
	
	public boolean equals(Object otherFrame) {
		return this.toString().equals(otherFrame.toString());
	}

}