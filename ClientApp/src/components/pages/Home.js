import React, { useState, useEffect } from "react";
import { Button, Typography, Grid, Paper, withStyles } from '@material-ui/core';
import { DataGrid } from "@material-ui/data-grid";
import SearchBar from "material-ui-search-bar";
import Pagination from "@material-ui/lab/Pagination";
import PaginationItem from "@material-ui/lab/PaginationItem";
import { Redirect } from "react-router-dom";
import auth from "../auth/auth-helper";
import { newLoan, findLoan, findRecentLoan } from "../../utils/api-loan.js";

const Home = (props) => {
  const { classes } = props;
  const [loans, setLoans] = useState([]);
  const [loan, setLoan] = useState(null);
  const [rows, setRows] = useState([])
  
  const columns = [    
    { field: "loanNumber", headerName: "#", width: 100 },
    { field: "company", headerName: "Co.", width: 150 },
    { field: "firstName", headerName: "First name", width: 130 },
    { field: "lastName", headerName: "Last name", width: 130 },
    {
      field: "ssn",
      headerName: "SSN",
      width: 130,
    },
    {
      field: "lastChanged",
      headerName: "Date Changed",
      width: 130,
    },
  ];

  const searchLoan = (searchType, keyword) => {
    const jwt = auth.isAuthenticated();
    findLoan(
      {
        type: searchType,
        key: keyword,
      },
      { t: jwt.token }
    ).then((data) => {
      if (data.error) {
        console.log(data.error);
      } else {
        setLoans(data);
      }
    });
  };

  const searchRecentLoan = (n) => {
    const jwt = auth.isAuthenticated();
    findRecentLoan(
      {
        numRecords: n,
      },
      { t: jwt.token }
    ).then((data) => {
      if (data.error) {
        console.log(data.error);
      } else {
        setLoans(data);
        // console.log(data)
        let temp = data,row = []
        {temp.map((loan) => (
          row = [...row,{
               id:  loan.loanNumber,  
                loanNumber: loan.loanNumber, 
                company: loan.borrower  ? loan.borrower.companyName : null, 
                firstName: loan.borrower ? loan.borrower.fname : null, 
                lastName: loan.borrower ? loan.borrower.lname : null, 
                ssn: loan.borrower ? loan.borrower.ssn : null ,
                lastChanged: loan.lastChangedOn.substring(0,10)}]
        ))}
        setRows(row)
      }
    });
  };

  const setBorrowerLoan = (borrower) => {
    let selectedLoan = [];
    {loans.map((loan) => (
      loan.loanNumber === borrower.loanNumber ? selectedLoan = loan: ""
    ))}
    // console.log(borrower)
    props.handleLoanChange(selectedLoan)
  };
  const newLoanCreate =() =>{
    const pad =(n, width, z) =>{
      z = z || '0';
      n = n + '';
      return n.length >= width ? n : new Array(width - n.length + 1).join(z) + n;
    }
    let blank = {
      loanNumber: `N${pad(loans.length,4)+auth.isAuthenticated().user.fName[0]+auth.isAuthenticated().user.lName[0]}`
    }
    // console.log(blank)
    newLoan({
      loan: blank,
    })
    .then((data) => {
      if (data.error){
        console.log(data.error)
      }else{
        console.log("Successfully created blank loan.")
        console.log(data)
        searchRecentLoan(10);
      }
    })
  }

  useEffect(() => {
    if(loans.length > 0) {

      let row = [];
      setLoan(loans[0])
      {loans.map((loanie) => (
        row = [...row,{
             id:  loanie.loanNumber,  
              loanNumber: loanie.loanNumber, 
              company: loanie.borrower ? loanie.borrower.companyName : null,
              firstName: loanie.borrower ? loanie.borrower.fname : null,
              lastName: loanie.borrower ? loanie.borrower.lname : null,
              ssn: loanie.borrower ? loanie.borrower.ssn : null,
              lastChanged: loanie.lastChangedOn.substring(0,10)},
          ]
      ))}
      setRows(row)
    }
    else {

    }
  }, [loans]);

  useEffect(() => { 
    searchRecentLoan(10);
    console.log(loans)
  }, []);

  function CustomPagination(props) {
    const { paginationProps } = props;

    return (
      <Pagination
        color="primary"
        variant="outlined"
        shape="rounded"
        page={paginationProps.page}
        count={paginationProps.pageCount}
        renderItem={(props2) => <PaginationItem {...props2} disableRipple />}
        onChange={(event, value) => paginationProps.setPage(value)}
      />
    );
  }

  return (
    <div style={auth.isAuthenticated()?{ paddingLeft: "155px" }:{}}>
      {!auth.isAuthenticated() && (
        <Redirect to={"/signin"} />
      )}

      {auth.isAuthenticated() && (
        <Paper className={classes.paper}>
        <Button  onClick={() =>props.handleLoanChange(loans)}/>
        <Typography type="headline" component="h2" className={classes.title}>
            Welcome {auth.isAuthenticated().user.fName}.
        </Typography>
        <Typography type="body1" component="p" className={classes.body}>
          This is a demo application that uses NodeJS, React, and Material UI
          for the frontend, and ASP.NET Core 3.2, SQL for the backend.
        </Typography>
        <Grid >
          <Typography type="headline" component="h2" className={classes.title}>
            {auth.isAuthenticated() && "All Loans"}
           <Button variant="contained" color="secondary" className={classes.button} onClick={newLoanCreate}>
                NEW
          </Button>
          </Typography>

        </Grid>

        {auth.isAuthenticated() && (<SearchBar onChange={(e) => 
          searchLoan("BorrowerName", e)}
          onRequestSearch={() => loan != null ? props.handleLoanChange(loan): console.log("No loan selected")}
          style={{
            margin: '0 auto',
            maxWidth: 800
          }}
        />)}
        {auth.isAuthenticated() && (
          
          <div style={{ height: 400, width: "100%" }}>
            
            <DataGrid
              rows={rows}
              columns={columns}
              pageSize={5}
              // checkboxSelection
              className={classes.root}
              components={{
                pagination: CustomPagination,
              }}
              onRowClick={(e) => setBorrowerLoan(e.data)}
              //props.handleLoanChange(e.data)
            />
          </div>
        )}
      </Paper>
      )}
    </div>
  );
};
const styles = (theme) => ({
  root: {
    ...customCheckbox(theme),
  },
  paper: {
    maxWidth: "800px",
    minWidth: "500px",
    margin: "auto",
    marginTop: theme.spacing(1),
  },    
  title: {
    padding: `${theme.spacing(3)}px ${theme.spacing(2.5)}px ${theme.spacing() *
      2}px`,
    color: theme.palette.text.secondary,
    fontSize: 24,
  },
  body: {
    padding: `${theme.spacing(0)}px ${theme.spacing(2.5)}px ${theme.spacing() *
      2}px`,
  },
  button: {
    float: "right"
  }
});
export default withStyles(styles)(Home);

function customCheckbox(theme) {
  return {
    "& .MuiCheckbox-root svg": {
      width: 16,
      height: 16,
      backgroundColor: "white",
      border: `1px solid ${
        theme.palette.type === "light" ? "#d9d9d9" : "rgb(67, 67, 67)"
      }`,
      borderRadius: 2,
    },
    "& .MuiCheckbox-root svg path": {
      display: "none",
    },
    "& .MuiCheckbox-root.Mui-checked:not(.MuiCheckbox-indeterminate) svg": {
      backgroundColor: "#1890ff",
      borderColor: "#1890ff",
    },
    "& .MuiCheckbox-root.Mui-checked .MuiIconButton-label:after": {
      position: "absolute",
      display: "table",
      border: "2px solid #fff",
      borderTop: 0,
      borderLeft: 0,
      transform: "rotate(45deg) translate(-50%,-50%)",
      opacity: 1,
      transition: "all .2s cubic-bezier(.12,.4,.29,1.46) .1s",
      content: '""',
      top: "50%",
      left: "39%",
      width: 5.71428571,
      height: 9.14285714,
    },
    "& .MuiCheckbox-root.MuiCheckbox-indeterminate .MuiIconButton-label:after": {
      width: 8,
      height: 8,
      backgroundColor: "#1890ff",
      transform: "none",
      top: "39%",
      border: 0,
    },
  };
}
