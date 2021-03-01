import React, { useState, useEffect } from "react";
import { Route, Switch } from "react-router-dom";
import Navbar from "./components/Navbar";
import Home from "./components/pages/Home";
import PrivateRoutes from "./components/auth/PrivateRoutes";
import Signin from "./components/auth/Signin";
import Profile from "./components/user/Profile";
import Signup from "./components/user/Signup";
import Borrower from "./components/pages/Borrower";
import LoanData from "./components/pages/Loan Data";
import Note from "./components/pages/Note";
import Notes from "./components/Notes";
import Property from "./components/pages/Property";
import TrusteesMailing from "./components/pages/TrusteesMailing";
import CostExpense from "./components/pages/CostExpense";
import Escrow from "./components/pages/Escrow";
import FinanceCharge from "./components/pages/FinanceCharge";
import Assignment from "./components/pages/Assignment";
const Routes = () => {

  const [loan, setLoan] = useState("empty");

  const handleLoanChange = (l) => { setLoan(l); }

  useEffect(() => {
    const parsedLoan = JSON.parse(localStorage.getItem('loan'));
    setLoan(parsedLoan)
  }, [])

  useEffect(() => {
    localStorage.setItem("loan", JSON.stringify(loan))
    console.log(`Root loan: ${loan ? loan.loanNumber : "empty"}`)
     console.log(loan)
  }, [loan]);

  return (
    <div>
      <Navbar loan={loan} handleLoanChange ={handleLoanChange} />
      <Notes loan={loan} handleLoanChange ={handleLoanChange} />
      <Switch>
        <PrivateRoutes path="/user/edit/:userId" />
        <Route
          path="/user/:userId"
          component={(props) => <Profile {...props} />}
        />
        <Route path="/signup" component={(props) => <Signup {...props} />} />
        <Route path="/signin" component={(props) => <Signin {...props} />} />
        {/* Pages */}
        <Route exact path="/" component={(props) => <Home {...props} loan={loan} handleLoanChange ={handleLoanChange} />} />
        <Route
          path="/borrower"
          component={(props) => <Borrower {...props} loan={loan} handleLoanChange ={handleLoanChange}/>}
        />{" "}
        <Route
          path="/loan_data"
          component={(props) => <LoanData {...props} loan={loan} handleLoanChange={handleLoanChange}/>}
        />{" "}
        <Route
          path="/cost_expense"
          component={(props) => <CostExpense {...props} loan={loan} handleLoanChange={handleLoanChange}/>}
        />{" "}
        <Route
          path="/finance_charge"
          component={(props) => <FinanceCharge {...props} />}
        />{" "}
        <Route
          path="/property"
          component={(props) => <Property {...props} loan={loan} handleLoanChange={handleLoanChange}/>}
        />{" "}
        <Route
          path="/trustee_mailing"
          component={(props) => <TrusteesMailing {...props} />}
        />{" "}
        <Route
          path="/escrow"
          component={(props) => <Escrow {...props} loan={loan} handleLoanChange={handleLoanChange}/>}
        />{" "}
        <Route
            path="/assignment"
            component={(props) => <Assignment {...props} loan={loan} />}
        />{" "}
        <Route
            path="/note"
            component={(props) => <Note {...props} loan={loan} />} />
      </Switch>
    </div>
  );
};

export default Routes;
