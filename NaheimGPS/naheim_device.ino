/*
  TRUCKCOY 2021

  DEVICE IOT
*/

// Variables Setup
// Your GPRS credentials (leave empty, if not needed)
const char apn[]      = "bam.entelpcs.cl"; // APN 
const char gprsUser[] = "entelpcs"; // GPRS User
const char gprsPass[] = "entelpcs"; // GPRS Password

// SIM card PIN (leave empty, if not defined)
const char simPIN[]   = ""; // Ex: 1111

// Server details
// The server variable can be just a domain name or it can have a subdomain. It depends on the service you are using
const char server[] = "techcoy.xyz"; // domain name: example.com
const char resource[] = "/truckcoy/includes/naheim_post.php"; // resource path, for example: /naheim_post.php
const int  port = 80;                             // server port number

// Keep this API Key value to be compatible with the PHP code provided in the project page. 
// If you change the apiKeyValue value, the PHP file /post-data.php also needs to have the same key 
String apiKeyValue = "UniversidadDeAysen111";
String deviceID = "111";
// TTGO T-Call pins
#define MODEM_RST            5
#define MODEM_PWKEY          4
#define MODEM_POWER_ON       23
#define MODEM_TX             27
#define MODEM_RX             26
#define I2C_SDA              21
#define I2C_SCL              22
// NEO6M V2 pins
#define RX_PIN               18
#define TX_PIN               19
int GPSBaud = 9600;

// Set serial for debug console (to Serial Monitor, default speed 115200)
#define SerialMon Serial
// Set serial for AT commands (to SIM800 module)

#define SerialAT Serial1
#include <SoftwareSerial.h>
SoftwareSerial gpsSerial(RX_PIN, TX_PIN);

// Configure TinyGSM library
#define TINY_GSM_MODEM_SIM800      // Modem is SIM800
#define TINY_GSM_RX_BUFFER   1024  // Set RX buffer to 1Kb

// Define the serial console for debug prints, if needed
//#define DUMP_AT_COMMANDS

#include <Wire.h>
#include <TinyGsmClient.h>
#include <TinyGPS.h>

#ifdef DUMP_AT_COMMANDS
  #include <StreamDebugger.h>
  StreamDebugger debugger(SerialAT, SerialMon);
  TinyGsm modem(debugger);
#else
  TinyGsm modem(SerialAT);
#endif

// I2C for SIM800 (to keep it running when powered from battery)
TwoWire I2CPower = TwoWire(0);
TwoWire I2CGPS = TwoWire(1);

// TinyGSM Client for Internet connection
TinyGsmClient client(modem);

#define uS_TO_S_FACTOR 1000000     /* Conversion factor for micro seconds to seconds */
#define TIME_TO_SLEEP  30        /* Time ESP32 will go to sleep (in seconds) 3600 seconds = 1 hour */

#define IP5306_ADDR          0x75
#define IP5306_REG_SYS_CTL0  0x00

bool setPowerBoostKeepOn(int en){
  I2CPower.beginTransmission(IP5306_ADDR);
  I2CPower.write(IP5306_REG_SYS_CTL0);
  if (en) {
    I2CPower.write(0x37); // Set bit1: 1 enable 0 disable boost keep on
  } else {
    I2CPower.write(0x35); // 0x37 is default reg value
  }
  return I2CPower.endTransmission() == 0;
}

void setup() {
  // Set serial monitor debugging window baud rate to 115200
  SerialMon.begin(115200);
  // Start the software serial port at the GPS's default baud
  gpsSerial.begin(GPSBaud);
  // Start I2C communication
  I2CPower.begin(I2C_SDA, I2C_SCL, 400000);
  I2CGPS.begin(RX_PIN, TX_PIN, 400000);

  // Keep power when running from battery
  bool isOk = setPowerBoostKeepOn(1);
  SerialMon.println(String("IP5306 KeepOn ") + (isOk ? "Inicio de configuracion: OK" : "Inicio de configuracion: FALLIDO"));

  // Set modem reset, enable, power pins
  pinMode(MODEM_PWKEY, OUTPUT);
  pinMode(MODEM_RST, OUTPUT);
  pinMode(MODEM_POWER_ON, OUTPUT);
  digitalWrite(MODEM_PWKEY, LOW);
  digitalWrite(MODEM_RST, HIGH);
  digitalWrite(MODEM_POWER_ON, HIGH);

  // Set GSM module baud rate and UART pins
  SerialAT.begin(115200, SERIAL_8N1, MODEM_RX, MODEM_TX);
  delay(3000);
  
  // Restart SIM800 module, it takes quite some time
  // To skip it, call init() instead of restart()
  SerialMon.println("Iniciando modem...");
  modem.restart();
  // use modem.init() if you don't need the complete restart

  // Unlock your SIM card with a PIN if needed
  if (strlen(simPIN) && modem.getSimStatus() != 3 ) {
    modem.simUnlock(simPIN);
  }
  
  // Configure the wake up source as timer wake up  

  // Set up Deep Sleep cicle
  esp_sleep_enable_timer_wakeup(TIME_TO_SLEEP * uS_TO_S_FACTOR);
}

void loop() {
  SerialMon.print("Conectando con Access Point Name (APN): ");
  SerialMon.print(apn);
  if (!modem.gprsConnect(apn, gprsUser, gprsPass)) {
    SerialMon.println("Conexion al APN ha fallado, revisa las configuraciones (GprsUser, GprsPass o SimPin)");
  }
  else {
    SerialMon.println(" OK");
    
    SerialMon.print("Conectando con ");
    SerialMon.print(server);
    if (!client.connect(server, port)) {
      SerialMon.println("Conexion fallida, el dispositivo presenta problemas para conectarse con la plataforma.");
    }
    else {
      if (gps.location.isValid()){
        try{
          while(gps.location.isValid()){
          Serial.print("Latitude: ");
          Serial.println(gps.location.lat(), 6);
          Serial.print("Longitude: ");
          Serial.println(gps.location.lng(), 6);
          Serial.print("Altitude: ");
          Serial.println(gps.altitude.meters());
          //START THE POST METHOD
          /*String httpRequestData = "api_key=" + apiKeyValue + "&deviceID=" + String(deviceID) + "&lat=" + String(gps.location.lat(), 6) + "&lon=" + String(gps.location.lng(), 6) + "&alt=" + String(gps.altitude.meters());
          client.print(String("POST ") + resource + " HTTP/1.1\r\n");
          client.print(String("Host: ") + server + "\r\n");
          client.println("Connection: close");
          client.println("Content-Type: application/x-www-form-urlencoded");
          client.print("Content-Length: ");
          client.println(httpRequestData.length());
          client.println();
          client.println(httpRequestData);
          
          unsigned long timeout = millis();
          while (client.connected() && millis() - timeout < 10000L) {
            // Print available data (HTTP response from server)
            while (client.available()) {
              char c = client.read();
              SerialMon.print(c);
              timeout = millis();
            }
          }
          client.stop();
          SerialMon.println(F("Server desconectado"));
          modem.gprsDisconnect();
          SerialMon.println(F("GPRS desconectado"));
          
          esp_deep_sleep_start();
          */
          }
        }
        catch {}
        }
      else{
        Serial.println("Location: Not Available");
       }
    }
  }
  // Displays information when new sentence is available.
  while (gpsSerial.available() > 0)
    Serial.write(gpsSerial.read());
}
