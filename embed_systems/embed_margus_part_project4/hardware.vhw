# MCU 8051 IDE: Virtual HW configuration file
# Project: Project4AlarmClock

MultiplexedLedDisplay {{0 1 1 1 2 1 3 1 4 1 T0 2 5 1 T1 2 6 1 T2 2 7 1 T3 2} {0 7 1 6 2 5 3 4 4 3 T0 7 5 2 T1 6 6 1 T2 5 7 0 T3 4} 430x225+18+447 {} red 20 0 0}
LedPanel {{4 3 0 3 5 3 1 3 6 3 2 3 7 3 3 3} {4 3 0 7 5 2 1 6 6 1 2 5 7 0 3 4} 380x130+7+280 {1 Alarm on or off, 1 On if alarm, TurnBlinkers} red 0}
SimpleKeyPad {{4 0 0 0 5 0 1 0 6 0 2 0 7 0 3 0} {4 3 0 7 5 2 1 6 6 1 2 5 7 0 3 4} 265x125+7+114 {A-Clock, B-Alarm, C-Hour, D-Minute, E-Alarm is on} {4 0 0 0 5 0 1 0 6 0 2 0 7 0 3 0} 0 0}
