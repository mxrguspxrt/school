#include <8051.h>

// Author mxrguspxrt 20140112

// A on C, B on F, * on -, C on clear

int f_to_c(int temp);
int c_to_f(int temp);
int keypad_value_read();
void display_number_set(int column, int number);
void display_value_set(int value);
void run();

int f_to_c(int temp){
  return ((temp-32)*5)/9;
}

int c_to_f(int temp){
  return (temp*9)/5+32;
}

int keypad_value_read(){
  int rows[] = {1,2,4,8};
  int columns[] = {16,32,64,128};
  int values[][] = {{1,2,3,11},{4,5,6,12},{7,8,9,13},{10,0,11,14}};

  int i, j, read_mask, value;
  for(i=0; i<4; ++i){
    read_mask = 255^rows[i];
    P0 = read_mask;
    value = read_mask^P0;
    for(j=0; j<4; ++j){
      if(value==columns[j]) return values[i][j];
    }
  }
  return -1;
}

void display_number_set(int column, int number){
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
  // 0-00111111-63
  // 10-01000000-64 negative sign (-)
  // 11-10000000-128 dot (.)
  int numbers[] = {63,6,91,79,102,109,125,7,127,111,64,128};
  int columns[] = {1, 2, 4, 8};
  P2 = columns[column];
  P1 = numbers[number]; // cathode vs anode - should be redone if using anode 255 ^ 
}

void display_value_set(int value){
  int part = 0;
  int displayed = 0;
  int multiplier = value<0 ? -1 : 1;
  int part_value;
  while(1){
    part_value = (value % (10*multiplier)) - displayed; // 6, 60, 600 etc
    displayed = displayed + part_value;
    display_number_set(part, part_value/multiplier);

    part++;
    multiplier*=10;
    if(displayed==value) break;
  }
  if(value<0){
    display_number_set(part, 10);
  }
}

void run(){
  int temp=0;
  int is_celsus=0;
  int last_keypad_value=-1;
  while(1){
    int keypad_value = keypad_value_read();
    
    if(last_keypad_value!=keypad_value){
      last_keypad_value=keypad_value;
      if(keypad_value>=0 && keypad_value<=9){
        int is_negative = temp < 0;
        temp = temp*10 + keypad_value*(is_negative?-1:1);
      }
      if(keypad_value==10){
        temp = temp * (-1);
      }
      if(keypad_value==11){
        temp = c_to_f(temp);
      }
      if(keypad_value==12){
        temp = f_to_c(temp);
      }
      if(keypad_value==13){
        temp = 0;
      }
    }
    
    display_value_set(temp);
    //display_value_set(keypad_value);
  }
}

void main(){
  run();
}
