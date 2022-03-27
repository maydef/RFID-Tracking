#include <LiquidCrystal_I2C.h>
#include <EEPROM.h>
#include <SPI.h>
#include <MFRC522.h>
#define SS_PIN 10
#define RST_PIN 9

LiquidCrystal_I2C lcd(0x27 ,16, 2);
MFRC522 mfrc522(SS_PIN, RST_PIN);
MFRC522::StatusCode status;

byte buffer[18];
byte size = sizeof(buffer);
uint8_t pageAddr = 0x06; 
char data[16];
String uidTag="";
char c;
int tahan;
int g=7;
String myData;
char buff[10];
String gg;
void setup() {
  // put your setup code here, to run once:
Serial.begin(9600);
lcd.init();
lcd.backlight();
lcd.clear();
lcd.setCursor(4,0);
lcd.print("Baristand");
lcd.setCursor(4,1);
lcd.print("Surabaya");
SPI.begin();       // Init SPI bus
mfrc522.PCD_Init();
}
void loop() {
  // put your main code here, to run repeatedly:
while (Serial.available()>0){
  delay(10);
   c = Serial.read();
  myData+=c;
}

if ( ! mfrc522.PICC_IsNewCardPresent())
    return;

if ( ! mfrc522.PICC_ReadCardSerial())
    return;
uidTag="";
           for (byte i = 0; i < mfrc522.uid.size; i++) {
           char teks[3];
           sprintf(teks,"%02X", mfrc522.uid.uidByte[i]);
           uidTag+=teks;
           }
Serial.println(uidTag);
if(tahan==0)
{
lcd.clear();
lcd.setCursor(4,0);
lcd.print("Baristand");
lcd.setCursor(4,1);
lcd.print("Surabaya");
delay(300);
}
if(uidTag!="")
{tahan=1;}
else{tahan=0;}

if(tahan==1)
{
  lcd.clear();
  lcd.setCursor(0,0);
  lcd.print("UID:");
  lcd.setCursor(6,0);
  lcd.print(uidTag);
  delay(1000);
  }

if (myData.length()>0){
  lcd.clear();
  lcd.setCursor(0,0);
  lcd.print("KODE :");
  lcd.setCursor(7,0);
  lcd.print(myData);
  lcd.setCursor(0,1);
  lcd.print("DATA TERSIMPAN");
  delay(2000);
 
  myData.toCharArray(buff, 10);
  //Serial.println(buff);
  EEPROM.put(0,buff);
  myData="";
  }

String hasil = EEPROM.get(0,buff);
for(int i=0;i<16;i++)
{data[i]=hasil[i];}
memcpy(buffer,data,5);
           for (int i=0; i < 4; i++) {
              status = (MFRC522::StatusCode) mfrc522.MIFARE_Ultralight_Write(pageAddr+i, &buffer[i*4], 4);
           if (status != MFRC522::STATUS_OK) {
              Serial.println(F("DEKATKAN CARD : "));
              lcd.clear();
              lcd.setCursor(4,0);
              lcd.print("Baristand");
              lcd.setCursor(4,1);
              lcd.print("Surabaya");
              delay(300);
              Serial.println(mfrc522.GetStatusCodeName(status));
              return;}
              else if (buff [0]=="")
           {
              lcd.clear();
              lcd.setCursor(0,0);
              lcd.print("UID:");
              lcd.setCursor(6,0);
              lcd.print(uidTag);
              lcd.setCursor(0,1);
              lcd.print("Masukan Data");
           }
           else 
           {
              lcd.clear();
              lcd.setCursor(0,0);
              lcd.print("UID:");
              lcd.setCursor(6,0);
              lcd.print(uidTag);
              lcd.setCursor(0,1);
              lcd.print("KODE :");
              for (byte i = 0; i< 5;i++)
              {
              lcd.write(buffer[i]);
              }
              delay (1000);
             
            }
           }
mfrc522.PICC_HaltA();          
}
