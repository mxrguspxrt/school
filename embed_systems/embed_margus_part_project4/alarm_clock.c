#include <8051.h>

// Author mxrguspxrt 20140130

void run();
unsigned long increase_time(unsigned long time, unsigned long seconds);
int buttons_active();
int is_button_active(int position);
char is_alarm_on();
char is_setting_alarm();
char is_setting_clock();
char is_increasing_hour();
char is_increasing_minute();
void run_alarm(char running);
void display_time(unsigned long time);
void display_number_set(int column, int number);
void display_alarm_status(char status);
void init_timer();
char sleep_to_a_full_second();

void main(){
  init_timer();
  run();
}

void run(){
  char alarm_is_on = 0; // 0 - no, 1 - yes
  char setting_alarm = 0; // 0 - no, 1 - yes
  char setting_clock = 0; // 0 - no, 1 - yes
  char increasing_hour = 0; // 0 - no, 1 - yes
  char increasing_minute = 0; // 0 - no, 1 - yes
  unsigned long alarm_time = 0; // 0 - 60*60*24
  unsigned long clock_time = 86400-3; // 0 - 60*60*24

  while(1){
    alarm_is_on = is_alarm_on();
    setting_alarm = is_setting_alarm();
    setting_clock = is_setting_clock();
    increasing_hour = is_increasing_hour();
    increasing_minute = is_increasing_minute();

    if(is_new_second()){
      clock_time = increase_time(clock_time, 1);
    
      if(setting_alarm){
        if(increasing_hour){
          alarm_time = increase_time(alarm_time, 60*60);
        }
        if(increasing_minute){
          alarm_time = increase_time(alarm_time, 60);
        }
      }
    
      if(setting_clock){
        if(increasing_hour){
          clock_time = increase_time(clock_time, 60*60);
        }
        if(increasing_minute){
          clock_time = increase_time(clock_time, 60);
        }
      }
    }

    if(alarm_is_on && alarm_time==clock_time){
      run_alarm(1);
    }
    if(!alarm_is_on){
      run_alarm(0);
    }

    display_alarm_status(alarm_is_on);

    if(setting_alarm){
      display_time(alarm_time);
    }else{
      display_time(clock_time);
    } 

  }
}

unsigned long increase_time(unsigned long time, unsigned long seconds){
  time = time + seconds;
  if(time>=86400){
    time = time-86400;
  }
  return time;
}

int is_button_active(int position){
  int active = 255 ^ P0;
  int position_values[] = {1, 2, 4, 8, 16, 32, 64};
  return (position_values[position] & active) == position_values[position];
}

char is_alarm_on(){
  return is_button_active(4);
}
char is_setting_alarm(){
  return is_button_active(1);
}
char is_setting_clock(){
  return is_button_active(0);
}
char is_increasing_hour(){
  return is_button_active(2);
}
char is_increasing_minute(){
  return is_button_active(3);
}

void run_alarm(char running){
  P3_1 = !running;
}

void display_alarm_status(char status){
   P3_0 = !status;
}

void display_time(unsigned long time){
  int minutes = (time%(60*60))/60;
  int hours = (time/60)/60;
  int hours0 = hours / 10;
  int hours1 = hours - (hours0*10);
  int minutes0 = minutes / 10;
  int minutes1 = minutes - (minutes0*10);
  display_number_set(0, minutes1);
  display_number_set(1, minutes0);
  display_number_set(2, hours1);
  display_number_set(3, hours0);
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
