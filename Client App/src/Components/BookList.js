import React, { useEffect, useState } from "react";

import "../styles/BookList.css";

import { getDatas } from '../App';

import LoanForm from "./LoanForm";

function getLoans(val) {
  fetch("https://localhost:44383/api/Loans")
    .then((res) => res.json())
    .then((res) => {
      val(Array.from(res));
    });
}

function BookList(props) {
  const [selectedBook, setSelectedBook] = useState("");
  const [activeLoan, setActiveLoan] = useState(false);
  const [activeReturn, setActiveReturn] = useState(false);
  const [name, setName] = useState("");
  const [surname, setSurname] = useState("");
  const [loans, setLoans] = useState({});
  const [activeLoanId, setActiveLoanId] = useState(0);
  const [bookDatas, setBookDatas] = useState([]);

  useEffect(() => {
    getDatas(setBookDatas);

    fetch("https://localhost:44383/api/Loans")
      .then((res) => res.json())
      .then((res) => {
        setLoans(Array.from(res));
      });
  }, []);

  function handleClick(i) {
    setSelectedBook(i);
  }
  function resetInputs() {
    setSelectedBook("");
    setActiveLoan(false);
    setActiveReturn(false);
    setName("");
    setSurname("");
    setActiveLoanId(null);
  }
  function loanBook(e) {
    e.preventDefault();

    let loanRequest = {
      bookId: selectedBook.bookId,
      clientId: 0,
      clientName: name,
      clientSurname: surname,
      loanDate: new Date().toLocaleDateString(),
    };

    let book = selectedBook;
    selectedBook.availableBooks--;

    fetch("https://localhost:44383/api/Loans", {
      method: "POST",
      headers: {
        Accept: "application/json",
        "Content-Type": "application/json",
      },
      body: JSON.stringify(loanRequest),
    }).then((res) =>
      res.json().then((res) => {
        console.log(res);
      })
    );

    fetch(`https://localhost:44383/api/Libary/${selectedBook.bookId}`, {
      method: "PUT",
      headers: {
        Accept: "application/json",
        "Content-Type": "application/json",
      },
      body: JSON.stringify(book),
    })
      .then((res) => res.json());

    alert("Loan Added");
    resetInputs();
    getLoans(setLoans);
  }

  function returnBook(e) {
    e.preventDefault();
    fetch(`https://localhost:44383/api/Loans/${activeLoanId}`, {
      method: "DELETE",
    });

    let book = selectedBook;
    selectedBook.availableBooks++;

    fetch(`https://localhost:44383/api/Libary/${selectedBook.bookId}`, {
      method: "PUT",
      headers: {
        Accept: "application/json",
        "Content-Type": "application/json",
      },
      body: JSON.stringify(book),
    })
      .then((res) => res.json());
    alert("Book returned!");

    resetInputs();
    getLoans(setLoans);
  }

  function checkBook() {
    if (loans.length > 0) {
      const filterLoans = loans.filter(
        (loan) => loan.bookId === selectedBook.bookId
      );
      if (filterLoans.length > 0) {
        return filterLoans;
      } else {
        return false;
      }
    }
  }
  const bookList = bookDatas.map((book) => (
    <li key={book.bookId}>
      <div
        onClick={() => {
          handleClick(book);
        }}
        className="list"
      >
        <h1 className="authorName">{book.authorName}</h1>
        <h3 className="bookName">{book.bookName}</h3>
        <img className = "imgBook" src={book.imageUrl} alt={book.bookName} />
      </div>
    </li>
  ));
  return (
    <React.Fragment>
      <div className={typeof selectedBook === "object" ? "blurDiv" : ""}>
      <h2>Below is our current list of books</h2>
      <div className="bookList">
        <ul>{bookList}</ul>
      </div>
      </div>
      {typeof selectedBook === "object" ? (
        <div className="selectedItem">
          <button
            onClick={() => {
              resetInputs();
            }}
            className="searchExit"
          >
            <ion-icon name="close"></ion-icon>
          </button>
          <h4 style={{textAlign:"center"}}><span className = "selected"><span style = {{fontWeight:"bold", fontSize:"20px"}}>You select</span> : {selectedBook.bookName}</span></h4>
          <button
          className = "loanAction"
            onClick={() => {
              setActiveLoan(true);
              setActiveReturn(false);
            }}
          >
            Loan book
          </button><br />
          <button
          className = "loanAction"
            onClick={() => {
              try {
                setActiveReturn(true);
              } catch (e) {
                alert("There's no active loans");
                setActiveReturn(false);
              }
              setActiveLoan(false);
            }}
          >
            Return the book
          </button>
          <div className = "changeBlock">
          {activeLoan ? (
            <LoanForm
              type="LOAN"
              submitLoan={loanBook}
              name={name}
              surname={surname}
              changeName={setName}
              changeSurname={setSurname}
            />
          ) : (
            ""
          )}
          {activeReturn ? (
            <LoanForm
              check={checkBook()}
              type="RETURN"
              submitReturn={returnBook}
              value={activeLoanId}
              loanValue={setActiveLoanId}
            />
          ) : (
            ""
          )}
          </div>
        </div>
      ) : (
        ""
      )}
      
    </React.Fragment>
  );
}

export default BookList;
