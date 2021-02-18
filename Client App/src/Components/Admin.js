import React, { useState, useEffect } from "react";
import "../styles/Admin.css";
import { getDatas } from "../App";
function Admin(props) {
  const [add, setAdd] = useState(false);
  const [remove, setRemove] = useState(false);
  const [bookNameRequest, setBookNameRequest] = useState("");
  const [authorNameRequest, setAuthorNameRequest] = useState("");
  const [imageUrlRequest, setImageUrlRequest] = useState("");
  const [releaseDateRequest, setReleaseDateRequest] = useState("");
  const [availableBooksRequest, setAvailableBooksRequest] = useState("");
  const [id, setId] = useState(null);
  const [isLogOn, setIsLogOn] = useState(false);
  const [log, setLog] = useState("");
  const [pass, setPass] = useState("");
  const [adminDatas, setAdminDatas] = useState([]);
  useEffect(() => {
    getDatas(setAdminDatas);
  }, []);

  function addBook(e) {
    let bookRequest = {
      bookName: bookNameRequest,
      authorName: authorNameRequest,
      imageUrl: imageUrlRequest,
      releaseDate: releaseDateRequest,
      availableBooks: parseInt(availableBooksRequest, 10),
    };
    fetch("https://localhost:44383/api/Libary", {
      method: "POST",
      headers: {
        Accept: "application/json",
        "Content-Type": "application/json",
      },
      body: JSON.stringify(bookRequest),
    }).then((res) =>
      res.json().then((res) => {
        console.log(res);
        if (res) {
          alert("You add a new Book!");
        }
      })
    );
  }
  function removeBook() {
    console.log(id);
    fetch(`https://localhost:44383/api/Libary/${id}`, {
      method: "DELETE",
    })
      .then(() => alert(`Item of the id nr: ${id} was deleted`))
      .catch((err) => {
        alert("Error! : Element was not deleted!");
      });
  }

  function LogOnSubmit(e) {
    e.preventDefault();
    fetch("https://localhost:44383/api/Logins")
      .then((res) => res.json())
      .then((res) => {
        const checkLog = Array.from(res).find((element) => {
          console.log(element.login === log && element.password === pass);
          return element.login === log && element.password === pass;
        });
        if (checkLog !== undefined) {
          setIsLogOn(true);
        }
      })
      .catch((err) => console.log(err));
  }

  return (
    <React.Fragment>
      {isLogOn ? (
        ""
      ) : (
        <div className="logInForm">
          <h4>Log In to go to Admin!</h4>
          <form onSubmit={LogOnSubmit}>
            Log In:
            <input
              type="text"
              name="log"
              value={log}
              onChange={(e) => setLog(e.target.value)}
            />
            <br />
            Password:
            <input
              type="text"
              name="pass"
              value={pass}
              onChange={(e) => setPass(e.target.value)}
            />
            <br />
            <input type="submit" value="Log In!" />
          </form>
        </div>
      )}
      <div
        style={isLogOn ? { display: "block" } : { display: "none" }}
        className="adminContain"
      >
        <button
          onClick={() => {
            setAdd(true);
            setRemove(false);
          }}
        >
          Add book
        </button>
        <button
          onClick={() => {
            setRemove(true);
            setAdd(false);
          }}
        >
          Remove book
        </button>

        {add ? (
          <div className="editBlock">
            <form onSubmit={addBook} className="formAddStyle">
              <div className="addInputs">
                <div>
                  <p>
                    <label className="labelStyle">
                      <span>Book Name : </span>{" "}
                      <input
                        type="text"
                        value={bookNameRequest}
                        onChange={(e) => setBookNameRequest(e.target.value)}
                      />
                    </label>
                  </p>
                  <p>
                    <label className="labelStyle">
                      <span>Author Name :</span>{" "}
                      <input
                        type="text"
                        value={authorNameRequest}
                        onChange={(e) => setAuthorNameRequest(e.target.value)}
                      />
                    </label>
                  </p>
                  <p>
                    <label className="labelStyle">
                      <span>Image URL address :</span>{" "}
                      <input
                        type="text"
                        value={imageUrlRequest}
                        onChange={(e) => setImageUrlRequest(e.target.value)}
                      />
                    </label>
                  </p>
                  <p>
                    <label className="labelStyle">
                      <span>Date of Release :</span>{" "}
                      <input
                        type="text"
                        value={releaseDateRequest}
                        onChange={(e) => setReleaseDateRequest(e.target.value)}
                      />
                    </label>
                  </p>
                  <p>
                    <label className="labelStyle">
                      <span>Available Books :</span>{" "}
                      <input
                        type="text"
                        value={availableBooksRequest}
                        onChange={(e) =>
                          setAvailableBooksRequest(e.target.value)
                        }
                      />
                    </label>
                  </p>
                </div>
              </div>
              <input type="submit" value="Add!" />
            </form>
          </div>
        ) : (
          ""
        )}
        {remove ? (
          <div className="editBlock">
            <form onSubmit={removeBook} className="formRemoveStyle">
              <label className="labelRemoveStyle">
                Select book: <br />
                <select value={id} onChange={(e) => setId(e.target.value)}>
                  {adminDatas.map((data) => (
                    <option value={data.bookId}>
                      {data.authorName} : {data.bookName}
                    </option>
                  ))}
                </select>
                <br />
              </label>
              <input type="submit" value="Delete!" />
            </form>
          </div>
        ) : (
          ""
        )}
      </div>
    </React.Fragment>
  );
}

export default Admin;
