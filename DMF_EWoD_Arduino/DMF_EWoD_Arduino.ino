
String inputString = "";         // a string to hold incoming data
boolean stringComplete = false;  // whether the string is complete

String set_status;
String read_status;

void set_output(const char pin_id, const int pin_num);
void read_input(const char pin_id, const int pin_num);
void toggle_pin(const int p);

const int pin_count = 8;

const int pin[pin_count] = { 30, 31, 32, 33, 34, 35, 36, 37 };

const char id[pin_count] = { '1', '2', '3', '4', '5', '6', '7', '8' };

// delay between PWM pulses
// 0 indicates constant signal, no PWM
int pin_delay[pin_count] = { 0, 0, 0, 0, 0, 0, 0, 0 };

// start times for each pin
unsigned long start_time[8];

void setup() {
  for (int i=0; i < pin_count; i++) {
  pinMode(pin[i], OUTPUT);
  }
  
  // initialize serial
  Serial.begin(115200);
  // reserve 16 bytes for the inputString:
  inputString.reserve(16);
  set_status = "X:S:X";
  read_status = "X:X";
  Serial.println("Serial Initialized");
}

void loop() {

  // Check to see if any pins are in PWM mode
  // and toggle state accordingly
  for (int i=0; i < pin_count; i++) {
    if (pin_delay[i] > 0) {
      if ( millis() - start_time[i] >= pin_delay[i]) {
        toggle_pin(pin[i]);
        start_time[i] = millis();
      }
    }   
  }
  
  serialEvent(); //call the function
  
  if (stringComplete) {

    for (int i=0; i < pin_count; i++) {
      if (inputString[0] == id[i]) {
        if (inputString[1] == 'P') {
          // these three chars are the pwm period in ms
          pin_delay[i] = (inputString[2] - '0') * 100 + (inputString[3] - '0') * 10 + (inputString[4] - '0');
          start_time[i] = millis();
        }
        else
        set_output(id[i], pin[i]);
      }
      break;
    }
    
    // clear the string:
    inputString = "";
    stringComplete = false;
  }
}

/*
  SerialEvent occurs whenever a new data comes in the
 hardware serial RX.  This routine is run between each
 time loop() runs, so using delay inside loop can delay
 response.  Multiple bytes of data may be available.
 */
void serialEvent() {
  while (Serial.available()) {
    // get the new byte:
    char inChar = (char)Serial.read();
    // add it to the inputString:
    inputString += inChar;
    // if the incoming character is a newline, set a flag
    // so the main loop can do something about it:
    if (inChar == '\n') {
      stringComplete = true;
    }
  }
}

void read_input(const char pin_id, const int pin_num)
{
  int x = digitalRead(pin_num);
  read_status[0] = pin_id;
  if (x)
    read_status[2] = 'H';  
  else
    read_status[2] = 'L';
  Serial.println(read_status);
  read_status[2] = 'X';
}

void set_output(const char pin_id, const int pin_num)
{
  set_status[0] = pin_id;
  if (inputString[1] == 'H') {
    set_status[4] = 'H';
    digitalWrite(pin_num, 1); }
  else if (inputString[1] == 'L') {
    set_status[4] = 'L';
    digitalWrite(pin_num, 0); }
  else {
    read_input(pin_id, pin_num);
    return; }
  Serial.println(set_status);
}

void toggle_pin(const int p)
{
  if (digitalRead(p))
    digitalWrite(p, 0);
  else
    digitalWrite(p, 1);
}

