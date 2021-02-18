import React, { useEffect, useState } from "react";
import "../styles/Home.css";
import Learn from "../img/HomeReadBook.png";
import Talk from "../img/Talk.png";
import Survey from "../img/Survey.png";
import { getDatas } from "../App";
const libraryPoints = [
  {
    id: 0,
    iconUrl: Learn,
    attribute: "Learn by reading",
    description:
      "Our mission is to make people readily read our available books and make them feel happy thanks to us.",
  },
  {
    id: 1,
    iconUrl: Talk,
    attribute: "Talk",
    description:
      "We are very open to talking to clients on any topic, we are happy to advise and answer questions",
  },
  {
    id: 2,
    iconUrl: Survey,
    attribute: "Openess",
    description:
      "We are open to a proposal to extend the offer of our library with new titles, we listen to clients and we have surveys which then we evaluate what titles our clients want",
  },
];

let getBooks = [];

function Home() {
  const [searchFlag, setSearchFlag] = useState(false);
  const [search, setSearch] = useState("");
  const [searchResults, setSearchResults] = useState([]);
  useEffect(() => {
    getDatas(setSearchResults);
    setSearchFlag(false);
  }, []);

  function handleClick() {
    getBooks = searchResults.filter((value) => {
        return value.bookName.toLowerCase().includes(search.toLowerCase()); 
      });
    setSearchFlag(true);
  }

  return (
    <React.Fragment>
      <div className="homeImage">
        <div className="searchBox">
          <input
            className="searchText"
            type="text"
            name=""
            placeholder="Click to search book..."
            value={search}
            onChange={(e) => {
              setSearch(e.target.value)
              setSearchFlag(false);
            }}
          />
          <button onClick={handleClick} className="searchClick">
            <ion-icon name="search"></ion-icon>
          </button>
        </div>
        {searchFlag ? (
          <div className="searchList">
            <h5>Search submit</h5>
            {getBooks.length > 0 ? (
              <ul>
                {getBooks.map((val) => (
                  <li key={val.bookId} style={{ marginLeft: "4px" }}>
                    <span style={{ fontSize: "18px", fontWeight: "bold" }}>
                      {val.authorName}
                    </span>{" "}
                    : {val.bookName}
                  </li>
                ))}
              </ul>
            ) : (
              <h1>There are no books!!!</h1>
            )}
            <button
              onClick={() => {
                setSearchFlag(false);
              }}
              className="searchExit"
            >
              <ion-icon name="close"></ion-icon>
            </button>
          </div>
        ) : (
          ""
        )}
      </div>
      <div className="libraryPoints">
        <ul>
          {libraryPoints.map((lib) => (
            <li key={lib.id}>
              <img className="iconSize" src={lib.iconUrl} alt={lib.attribute} />
              <h5>{lib.attribute}</h5>
              <p className="desc">{lib.description}</p>
            </li>
          ))}
        </ul>
      </div>
    </React.Fragment>
  );
}

export default Home;
