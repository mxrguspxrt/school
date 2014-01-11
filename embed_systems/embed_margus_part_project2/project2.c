#include <8051.h>

int car_is_entering();
int car_is_leaving();
void display_value_set(int value);
void run();
void sleep(int milliseconds);

void sleep(int milliseconds){
  int i = milliseconds*20;
  for(;0<=i;i--){
  }
}

int car_is_entering(){
  return P0_0 == 0;
}

int car_is_leaving(){  
  return P0_1 == 0;
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
  // 0-00111111-63
  int numbers[] = {63,6,91,79,102,109,125,7,127,111};
  P1 = 255 ^ numbers[number]; // cathode vs anode - should be redone if using anode
}

void display_value_set(int value){
  int column1   = value%10;
  int column10  = (value%100-column1)/10;
  int column100 = (value%1000-value%100)/100;

  P2 = 6;
  display_number_set(column1);
  sleep(3);
  P2 = 7;

  P2 = 5;  
  display_number_set(column10);
  sleep(3);
  P2 = 7;

  P2 = 3; 
  display_number_set(column100);
  sleep(3);
  P2 = 7;
}

void run(){
  // cars_parked - how many cars ar parked at the moment
  // car_is_entering - if it was entering and is entering, do not register it twice
  // car_is_leaving - car is leaving=1 until leaving sensor says that it has left
  int cars_parked = 123;
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
        if(cars_parked>=0){
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
