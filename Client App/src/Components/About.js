import React from "react";
import "../styles/About.css";
import Image from "../img/AboutPhoto.jpg";
function About() {
  return (
    <React.Fragment>
      <div className="aboutContainer">
        <h1>About us</h1>
        <hr/>
        <p>
          Welcome to a modern library in Lublin, a place of culture and
          resources of a unique book database.
        </p>

        <img className="aboutPhoto" src = {Image} alt = "About" />

        <h1>Main mission</h1>
        <hr/>
        <p>
          We have been operating for a short time, our experts will allow you to
          combine many volumes and files of various books. Our main mission is
          to make people readily read, we are open, we conduct surveys in which
          you can describe what book is missing or what is the dream book, which
          allows us to search and develop our database of books.
        </p>
      </div>
    </React.Fragment>
  );
}

export default About;
