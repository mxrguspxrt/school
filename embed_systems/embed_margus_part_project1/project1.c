#include <8051.h>

int button_number_get();
void display_number_set(int number);
void run_program();

int button_number_get(){
  int active = 255 ^ P0;
  int position_values[] = {0, 1, 2, 4, 8, 16, 32, 64};
  int position;
  for(position=0; position < sizeof(position_values); position++){
    if(position_values[position]==active){
      return position;
    }
  }
  return 0;
}

void display_number_set(int number){
  // multiplexed LED display + 8 segment editor to construct numbers
  // 1-00000110-6
  // 2-01011011-91
  // 3-01001111-79
  // 4-01100110-102
  // 5-01101101-109
  // 6-01111101-125
  // 7-00000111-7
  // 8-01111111-127
  // 9-01101111-111
  // .-10000000-128
  int numbers[] = {128,6,91,79,102,109,125,7,127,111};
  P1 = 255 ^ numbers[number];
}

void run_program(){
  while(1){
    display_number_set(button_number_get());
  };
}

void main(){
  run_program();
}
