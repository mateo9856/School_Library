import React, { useState, useEffect } from "react";
import { BrowserRouter as Router, Link, Route, Switch } from "react-router-dom";
import "./App.css";
import About from "./Components/About";
import Contact from "./Components/Contact";
import BookList from "./Components/BookList";
import AppLogo from "./img/SchoolLibraryLogo.png";
import Error from "./Error";
import Admin from "./Components/Admin";
import Home from "./Components/Home";

export function getDatas(value) {
  fetch("https://localhost:44383/api/Libary")
    .then((res) => res.json())
    .then((data) => value(Array.from(data)))
    .catch(function () {
      throw new Error("API not called");
    });
}

function App() {
  const [datas, setDatas] = useState([]);
  useEffect(() => {
    getDatas(setDatas);
  }, []);

  return (
    <Router>
      <div className="App">
        <img className="AppLogo" src={AppLogo} alt="logo" />
        <header>
          <div className = "header">
          <label className = "mLabel" for = "toggle">&#9776;</label>
          <input type = "checkbox" id= "toggle"/>
          <ul className="navbarList">
            <li>
              <Link to={"/contact"} className="headerClick">
                Contact
              </Link>
            </li>
            <li>
              <Link to={"/booklist"} className="headerClick">
                Book List
              </Link>
            </li>
            <li>
              <Link to={"/about"} className="headerClick">
                About Library
              </Link>
            </li>
            <li>
              <Link to={"/"} className="headerClick">
                Home
              </Link>
            </li>
          </ul>
          </div>
        </header>


        <div className="container">
          {datas.length > 0 ? (
            <Switch>
              <Route exact path="/" component={Home} />
              <Route path="/about" component={About} />
              <Route path="/booklist" component={BookList} />
              <Route path="/contact" component={Contact} />
              <Route path="/admin" component={Admin} />
            </Switch>
          ) : (
            <Error />
          )}
        </div>
      </div>
    </Router>
  );
}

export default App;
