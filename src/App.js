import './App.css';
import placeholder from './GamePlaceholder.jpg';

function App() {
  return (
    <div className="App">
      <head>
        <title>IT Chess</title>

      </head>

      <header className="header">
        
        <div className="navLeft"></div>

        <div className="navMiddle">
          <h1>InFoMaChess</h1>
        </div>

        <div className="navRight">
          <button>Login</button>
          <button>Sign Up</button>
        </div>
        
      </header>

      <div className='flexContainer'>
        <aside className="aside">
          <h1>Aside</h1>
        </aside>

        <section className="body">
          <img src={placeholder} alt={"unity game goes here"}></img>
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
