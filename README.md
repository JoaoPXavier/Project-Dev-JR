# Programming Challenges and Node-RED

This repository gathers three projects developed for technical assessments and logic programming practice. The projects include logic challenges, an object-oriented Tic-Tac-Toe game in C#, and a complete Node-RED application integrated with the BrazilAPI, SQLite, and MQTT.


## Project 1: Node-RED Challenge (Main)

### Description

This project was developed as part of a technical challenge involving building an application using Node-RED to consume and display data from the [BrazilAPI](https://brasilapi.com.br).

### Features:

* Broker catalog ([https://brasilapi.com.br/docs#tag/Corretoras](https://brasilapi.com.br/docs#tag/Corretoras))
* Zip Code Search (via input field and URL route) ([https://brasilapi.com.br/docs#tag/CEP-V2](https://brasilapi.com.br/docs#tag/CEP-V2))
* MQTT integration to show real-time searches
* Search history stored using SQLite
* Responsive layout using Node-RED Dashboard

### Technologies Used

* Node-RED
* MQTT (Mosquitto)
* SQLite
* HTML/CSS (via Node-RED Dashboard)
* JavaScript (Function nodes)
* BrazilAPI

### Requirements

* Node.js (v14 or higher)
* Node-RED
* npm (Node.js Package Manager)

### Local Installation & Execution

1. Install Node-RED:

```bash
npm install -g --unsafe-perm node-red
```

2. Run Node-RED:

```bash
node-red
```

3. Open the dashboard in your browser:

```
http://localhost:1880
```

### Optional (for extra features)

* **SQLite** (to persist search history)

```bash
npm install sqlite3
```

* **Mosquitto (MQTT Broker)**

```bash
sudo apt install mosquitto mosquitto-clients
```

* **Run SQLite database manually:**

```bash
sqlite3 buscas.db
```

### Importing the Project into Node-RED

1. In the top-right menu > Import > Import from file
2. Import the 3 flow files:

   * `zip-code-search.json`
   * `broker-catalog.json`
   * `integration-logic.json`
3. Click "Deploy"

### API Endpoints

* **GET /zip\_form**

  * Opens a form to input and search for a zip code
  * Example: `http://127.0.0.1:1880/zip_form`

* **GET /zip\_searcher/\:zip**

  * Returns details of a zip code (CEP) using the BrazilAPI
  * Example: `http://127.0.0.1:1880/zip_searcher/30130-010`

* **GET /catalogo-corretoras**

  * Lists CVM broker data in the format "\${Name} - \${City} / \${CNPJ}"
  * Example: `http://localhost:1880/catalogo-corretoras`

* **MQTT Dashboard Panel**

  * UI showing the last searched zip code in real time via MQTT
  * Example: `http://localhost:1880/ui`

### Screenshots & Flows

All JSON flow files and images are in the `node-red-project/` folder.

---

## Project 2: Logic Programming Test

### Exercises:

1. Calculate age in days (given years, months, and days)
2. Evaluate logical expressions (True/False)
3. Determine triangle type based on side lengths
4. Count values within and outside the range \[1,100]

### Language Used

* C# (Console application)

Source code is organized under `/logica/`

---

## Project 3: Tic-Tac-Toe Game (C# with OOP)

### Description

An implementation of the classic Tic-Tac-Toe game with support for:

* Player vs Player
* Player vs Computer
* Computer vs Computer

### Game Rules Implemented

* 3x3 board
* Detects win conditions (rows, columns, diagonals)
* Prevents duplicate moves
* Declares draw if the board is full

## Code Structure

* Classes: `Tabuleiro.cs`, `Jogador.cs`, `Program.cs`
* Object-oriented logic
* Console-based interface

Files are located under `/jogo-da-velha/`


## Author

João Victor Pereira


