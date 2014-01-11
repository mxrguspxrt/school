#include <8051.h>

// Author mxrguspxrt 20140111

int car_is_entering();
int car_is_leaving();
void display_value_set(int value);
void run();

int car_is_entering(){
  return P0_0 == 0;
}

int car_is_leaving(){  
  return P0_1 == 0;
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
  int numbers[] = {63,6,91,79,102,109,125,7,127,111};
  int columns[] = {1, 2, 4};
  P2 = columns[column];
  P1 = numbers[number]; // cathode vs anode - should be redone if using anode 255 ^ 
}

void display_value_set(int value){
  int column1   = value%10;
  int column10  = (value%100-column1)/10;
  int column100 = (value%1000-column10)/100;


  display_number_set(0, column1);
  display_number_set(1, column10);
  display_number_set(2, column100);
}

void run(){
  // cars_parked - how many cars ar parked at the moment
  // car_is_entering - if it was entering and is entering, do not register it twice
  // car_is_leaving - car is leaving=1 until leaving sensor says that it has left
  int cars_parked = 0;
  int car_was_entering = 0; 
  int car_was_leaving = 0;
  while(1){
    if(car_is_entering()){
      if(!car_was_entering){
        car_was_entering = 1;
        cars_parked++;
      }
    }else{
      car_was_entering = 0;
    }
    if(car_is_leaving()){
      if(!car_was_leaving){
        car_was_leaving = 1;
        if(cars_parked>0){
          cars_parked--;
        }
      }
    }else{
      car_was_leaving = 0;
    }
    display_value_set(cars_parked);
  }
}

void main(){
  run();
}
