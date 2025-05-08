//www.elegoo.com
//2016.12.8

// Leds
//
#define ResetLed 13
#define Player1Led 12
#define Player2Led 11
#define Player3Led 10
#define Player4Led 9

// BOTONES
//
#define ResetBtn 2
#define Player1Btn 3
#define Player2Btn 4
#define Player3Btn 5
#define Player4Btn 6


void setup()
{
  Serial.begin(9600);
  //Leds
  pinMode(Player1Led, OUTPUT);
  pinMode(Player2Led, OUTPUT);
  pinMode(Player3Led, OUTPUT);
  pinMode(Player4Led, OUTPUT);
  pinMode(ResetLed, OUTPUT);

  // APAGAR leds de los BOTONES
  digitalWrite(Player1Led, LOW);
  digitalWrite(Player2Led, LOW);
  digitalWrite(Player3Led, LOW);
  digitalWrite(Player4Led, LOW);
  digitalWrite(ResetLed, LOW);

  // Configurar BOTONES
  pinMode(Player1Btn, INPUT_PULLUP);
  pinMode(Player2Btn, INPUT_PULLUP);
  pinMode(Player3Btn, INPUT_PULLUP);
  pinMode(Player4Btn, INPUT_PULLUP);
  pinMode(ResetBtn, INPUT_PULLUP);
  Serial.println("Init");
}

// define variables
int lastbutton1State = LOW;
int lastbutton2State = LOW;
int lastbutton3State = LOW;
int lastbutton4State = LOW;
int lastResetState = LOW;

int button1State = 0;
int button2State = 0;
int button3State = 0;
int button4State = 0;

int resetButtonState = 0;
boolean pollingForPresses = 0;

// main loop
void loop()
{

  int reading1 = digitalRead(Player1Btn);
  int reading2 = digitalRead(Player2Btn);
  int reading3 = digitalRead(Player3Btn);
  int reading4 = digitalRead(Player4Btn);
  int readingReset = digitalRead(ResetBtn);

  if (pollingForPresses == 1) {
    //Button 1
    if (reading1 != button1State && reading1 != lastbutton1State) {
      button1State = reading1;
      button1State = digitalRead(Player1Btn);

      if (button1State == HIGH) {      
        BlinkWinner(1);
        pollingForPresses = 0;
      }
      button1State = 0;
    }

    //Button 2
    if (reading2 != button2State && reading2 != lastbutton2State) {
      button2State = reading2;
      button2State = digitalRead(Player2Btn);

      if (button2State == HIGH) {        
        BlinkWinner(2);
        pollingForPresses = 0;
      }
      button2State = 0;
    }

 //Button 3
    if (reading3 != button3State && reading3 != lastbutton3State) {
      button3State = reading3;
      button3State = digitalRead(Player3Btn);

      if (button3State == HIGH) {       
        BlinkWinner(3);
        pollingForPresses = 0;
      }
      button3State = 0;
    }

     //Button 4
    if (reading4 != button4State && reading4 != lastbutton4State) {
      button4State = reading4;
      button4State = digitalRead(Player4Btn);

      if (button4State == HIGH) {        
        BlinkWinner(4);
        pollingForPresses = 0;
      }
      button4State = 0;
    }
    
  }

  if (pollingForPresses == 0) {

    if (readingReset != resetButtonState && readingReset != lastResetState) {
      resetButtonState = digitalRead(ResetBtn);

      if (resetButtonState == HIGH) {        
        resetButtons();
       }

      resetButtonState = 0;
    }
  }

  lastResetState = readingReset;
  lastbutton1State = reading1;
  lastbutton2State = reading2;
  lastbutton3State = reading3;
  lastbutton4State = reading4;

}

void BlinkWinner(int winner)
{
  int winnerled;
  // Disable loser light
 
  switch (winner) {
  case 1:
    //do something when var equals 1
    winnerled = Player1Led;
    digitalWrite(Player2Led, LOW);
    digitalWrite(Player3Led, LOW);
    digitalWrite(Player4Led, LOW);
  
    break;
  case 2:
    //do something when var equals 2
    winnerled = Player2Led;
    digitalWrite(Player1Led, LOW);
    digitalWrite(Player3Led, LOW);
    digitalWrite(Player4Led, LOW);
    break;
  case 3:
    //do something when var equals 3
     winnerled = Player3Led;
    digitalWrite(Player2Led, LOW);
    digitalWrite(Player1Led, LOW);
    digitalWrite(Player4Led, LOW);
    break;
  case 4:
    //do something when var equals 4
    winnerled = Player4Led;
    digitalWrite(Player2Led, LOW);
    digitalWrite(Player3Led, LOW);
    digitalWrite(Player1Led, LOW);
    break;
    
  default:
    // if nothing else matches, do the default
    // default is optional
    break;
}
  Serial.println("Player " + String(winner) );
  // blink winner
  int delayms = 100;
  for (int i = 0; i < 15; i++) {
    digitalWrite(winnerled, LOW);
    delay(delayms);
    digitalWrite(winnerled, HIGH);
    delay(delayms);
  }
  // enable reset btn light
  digitalWrite(ResetLed, HIGH);
}

void resetButtons() {

  lastbutton1State = 0;
  lastbutton2State = 0;
  lastbutton3State = 0;
  lastbutton4State = 0;
  resetButtonState = 0;
  lastResetState = 0;

  button1State = 0;
  button2State = 0;
  button3State = 0;
  button4State = 0;

 Serial.println("Reset");

  digitalWrite(Player1Led, HIGH);
  digitalWrite(Player2Led, HIGH);
  digitalWrite(Player3Led, HIGH);
  digitalWrite(Player4Led, HIGH);
  digitalWrite(ResetLed, LOW);

  pollingForPresses = 1;
}
