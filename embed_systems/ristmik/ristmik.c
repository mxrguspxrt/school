#include <8051.h>

#define GREEN 2
#define YELLOW 1
#define RED 0


void main(){
  run();
}

int car_timers[] = {60, 10, 60*20}; // red, yellow, green
char minimum_car_green_time = 1;
char car_status = RED; // 0 - red, 1 - yellow, 2 - green
char car_next_status = GREEN; 
char walkers_button_pressed = 0; // 0 - false, 1 - true
int cars_current_status_time = 0; // how many seconds current state has been on


void run(){
  while(1){

    handle_states();

    if(is_cars_green()){
      show_walkers_red();
      show_cars_green();
    }

    if(is_cars_yellow()){
      show_walkers_red();
      show_cars_yellow();
    }

    if(is_cars_red()){
      show_cars_red();
      show_walkers_green();
    }
  
  } 
}

void handle_states(){
  wait_a_second();
  cars_current_status_time = cars_current_status_time+1;
  
  if(is_cars_green() && is_walkers_button_down()){
    walkers_button_pressed=1;
  }

  if(walkers_button_pressed && 
    is_cars_green() && 
    (minimum_car_green_time<=cars_current_status_time)){
    walkers_button_pressed=0;
    car_status = YELLOW;
    car_next_status = RED;
    cars_current_status_time = 0;
  }

  if(is_cars_yellow() && car_timers[YELLOW]<=cars_current_status_time){
    car_status = RED;
    car_next_status = GREEN; 
    cars_current_status_time = 0;
  }
  
  if(is_cars_red() && car_timers[RED]<=cars_current_status_time){
    car_status = GREEN;
    car_next_status = YELLOW; 
    cars_current_status_time = 0;
  }
  
  if(is_cars_green() && car_timers[GREEN]<=cars_current_status_time){
    car_status = YELLOW;
    car_next_status = RED; 
    cars_current_status_time = 0;
  }

  
}

char is_button_active(int position){
  int active = 255 ^ P1;
  int position_values[] = {1, 2, 4, 8, 16, 32, 64};
  return (position_values[position] & active) == position_values[position];
}

char is_walkers_button_down(){
  return is_button_active(0); 
}

char is_cars_red(){
  return car_status == RED;
}

char is_cars_yellow(){
  return car_status == YELLOW;
}

char is_cars_green(){
  return car_status == GREEN;
}

char is_walkers_red(){
  return is_cars_yellow() || is_cars_green();
}

char is_walkers_green(){
  return is_cars_red();
}

void show_walkers_red(){
  P0_3=0;
  P0_4=1;
}

void show_walkers_green(){
  P0_3=1;
  P0_4=0;
}

void show_cars_red(){
  P0_0=0;
  P0_1=1;
  P0_2=1;
}

void show_cars_yellow(){
  P0_0=1;
  P0_1=!P0_1;
  P0_2=1;
}

void show_cars_green(){
  P0_0=1;
  P0_1=1;
  P0_2=0;
}

void wait_a_second(){
  while(!is_new_second()){}
}

char new_second_toggle = 0;
char last_new_second_toggle = 0;
char is_new_second(){
  if(new_second_toggle==last_new_second_toggle){
    return 0;
  }else{
    last_new_second_toggle = new_second_toggle;
    return 1;
  }
}

void init_timer(){
  ET0=0;
  EA=1;
  TMOD=0x01;
  TL0=220;
  TH0=11;
  TR0=1;
}

void timer_1ms(void) __interrupt 1 {
  unsigned char static repeats_counter;
  TL0=220;
  TH0=11;
  if(++repeats_counter==16){
    new_second_toggle = !new_second_toggle;
    repeats_counter = 0;
  }
}
