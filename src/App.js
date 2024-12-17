import './App.css';
import placeholder from './GamePlaceholder.jpg';

function App() {
  return (
    <div className="App">
      <head>
        <title>IT Chess</title>
      </head>

      <header className="header">
        <h1>InFoMaChess</h1>

      </header>

      <div className='flexContainer'>
        <aside className="aside">
          <h1>Aside</h1>
        </aside>

        <section className="body">
          <img src={placeholder}></img>
        </section>
      </div>

      <footer className="footer">
        <h5>by Ivan, Ferdinand, and Mateo</h5>
        <a href='https://github.com/mateomramos/ITSeniorProject'>GitHub</a>
      </footer>
    </div>
  );
}

export default App;
