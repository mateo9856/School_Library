import React from "react";
import "../styles/LoanForm.css";
function LoanForm(props) {
  switch (props.type) {
    case "LOAN":
      return (
        <form onSubmit={props.submitLoan}>
          <label>
            Name:
            <input
              type="text"
              value={props.name}
              onChange={(e) => props.changeName(e.target.value)}
            />
            <br />
            Surname:
            <input
              type="text"
              value={props.surname}
              onChange={(e) => props.changeSurname(e.target.value)}
            />
          </label>
          <br />
          <input className="submitLoanBook" type="submit" value="Loan!" />
        </form>
      );
    case "RETURN":
      const listLoans = props.check;

      if (props.check) {
        props.loanValue(listLoans[0].loanId);
        return (
          <form onSubmit={props.submitReturn}>
            <select
              className="selectLoanStyle"
              value={props.value}
              onChange={(e) => props.loanValue(parseInt(e.target.value, 10))}
            >
              {listLoans.map((val) => (
                <option value={val.loanId}>
                  {val.clientName} : {val.clientSurname}
                </option>
              ))}
            </select>
            <br />
            <input className="submitLoanBook" type="submit" value="Return!" />
          </form>
        );
      } else {
        return <h1>There's no active loans!</h1>;
      }
    default:
      break;
  }
}
export default LoanForm;
