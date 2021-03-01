import React, {useState, useEffect} from "react";
import { Button, Typography, TextField, Grid, Paper, withStyles } from '@material-ui/core';
import { editBorrower, editLoans, newBorrower } from "../../utils/api-loan.js";

const Borrower = (props) => {
  const { classes } = props;
  const [spacing, setSpacing] = React.useState(2);
  const [borrower, setBorrower] = useState([]);
  console.log(props.loan);
  console.log(borrower);
  useEffect(() => {
    if (!(props.loan === null|| props.loan === "empty" || !props.loan.borrower))
      setBorrower(props.loan.borrower)
  }, [props.loan]);

  const handlesubmit =(() => {
    // Copy of the loan
    let temp =JSON.parse(JSON.stringify(props.loan));
    // Check to see if this is a new loan
    if(!borrower.id) {
      console.log("New loan, creating new borrower.")
      newBorrower({
              borrower: borrower,
            })
            .then((data) => {
              if (data.error){
                console.log(data.error)
              }else{
                const loanMod = {
                  id: props.loan.id,
                  loanNumber: props.loan.loanNumber,
                  name: props.loan.name,
                  companyName: props.loan.companyName,
                  stage: props.loan.stage,
                  principalAmt: props.loan.principalAmt,
                  intRate: props.loan.intRate,
                  intRateLender: props.loan.intRateLender,
                  paymentsPerPeriod: props.loan.paymentsPerPeriod,
                  totalPaymentsInPeriods: props.loan.totalPaymentsInPeriods,
                  paymentsCollectedInAdvance: props.loan.paymentsCollectedInAdvance,
                  paymentAmortizationPeriod: props.loan.paymentAmortizationPeriod,
                  regPaymentAmt: props.loan.regPaymentAmt,
                  maturityDate: props.loan.maturityDate,
                  loanPoints: props.loan.loanPoints,
                  totalLoanFee: props.loan.totalLoanFee,
                  createdOn: props.loan.createdOn,
                  lastChangedOn: props.loan.lastChangedOn,
                  borrower: {
                    companyIsBorrower: data.companyIsBorrower,
                    companyName: data.companyName,
                    dob: data.dob,
                    fname: data.fname,
                    id: data.id,
                    lname: data.lname,
                    ssn: data.snn,
                    title: data.title,
                    address: data.address
                  }
                }; // Copy new borrower to the corresponding loan.
                editLoans({
                  id: props.loan.id,
                  loan: loanMod,
                }).then((data) => {
                  if (data.error){
                    console.log(data.error)
                  }else{
                    console.log(data)
                  }
                })
                temp.borrower = borrower;
                props.handleLoanChange(temp);
              }
            })
    }
    // Send the changes to root loan state Routes and to localStorage. 
    // Submit changes to db
    else {
      temp.borrower = borrower;
      props.handleLoanChange(temp);
      submitBorrower(borrower.id)
    }
  })

  const submitBorrower = ((id) => {
    const borrowerMod = {
      companyIsBorrower: borrower.companyIsBorrower,
      companyName: borrower.companyName || undefined,
      dob: borrower.dob || undefined,
      fname: borrower.fname,
      id: borrower.id,
      lname: borrower.lname,
      ssn: borrower.ssn,
      title: borrower.title,
      address:{
        ...borrower.address,
        address1: borrower.address ? borrower.address.address1 : undefined,
        address2: borrower.address ? borrower.address.address2 : undefined,
        city: borrower.address ? borrower.address.city : undefined,
        state: borrower.address ? borrower.address.state : undefined,
        zip: borrower.address ? borrower.address.zip : undefined,
      },
    };
    console.log("Borrower edited")
    editBorrower({
          id: id,
          loan: borrowerMod,
        })
        .then((data) => { 
      if (data.error){
        console.log(data.error)
      }else{
        console.log("Successfully updated db.")     
      }
    })
  });

  return (
    <div style={{ paddingLeft: "155px", width: "99%" }}>
      <Button variant="contained" color="secondary" className={classes.submit} onClick={handlesubmit}>
         SUBMIT
      </Button>
      <Grid container className={classes.root} spacing={2}>
        <Grid item xs={12}>
          <Grid
            container
            spacing={spacing}
            style={{ width: "100%" }}
          >
            <Grid item>
              <Paper className={classes.paper}>
                <Typography
                  type="headline"
                  component="h2"
                  className={classes.title}
                >
                  Borrower Information
                </Typography>
                  <form className={classes.root} noValidate autoComplete="off">
                    <div>
                      <TextField
                        id="company"
                        className={classes.textField}
                        label= "Company"
                        color="secondary"
                        value={borrower ? borrower.companyName: ""}
                        onChange={(e) => setBorrower({...borrower,
                          companyName: e.target.value
                        })}
                      />
                    </div>
                    <div>
                    <TextField
                        id="firstName"
                        className={classes.textFieldSmall}
                        label= "First name"
                        color="secondary"
                        value={borrower ? borrower.fname: ""}
                        onChange={(e) => setBorrower({...borrower,
                          fname: e.target.value
                        })}
                      />                      
                    <TextField
                      id="lastName"
                      className={classes.textFieldSmall}
                      label= "Last name"
                      color="secondary"
                        value={borrower ? borrower.lname: ""}
                      onChange={(e) => setBorrower({...borrower,
                        lname: e.target.value
                      })}
                    />
                    </div>
                    <div>
                      <TextField
                        id="title"
                        className={classes.textField}
                        label= "Title"
                        color="secondary"
                        value={borrower ? borrower.title: ""}
                        onChange={(e) => setBorrower({...borrower,
                          title: e.target.value
                        })}
                      />
                    </div>
                    <div>
                      <TextField
                        id="address"
                        className={classes.textField}
                        label="Address"
                        color="secondary"
                        value={borrower? (borrower.address? borrower.address.address1:"") :""}
                        onChange={(e) => setBorrower({...borrower,
                          address: {
                            ...borrower.address,
                            address1: e.target.value
                          }
                        })}
                      />
                    </div>
                    <div>
                      <TextField
                        id="city"
                        className={classes.textField}
                        label="City"
                        color="secondary"
                        value={borrower? (borrower.address? borrower.address.city:"") :""}
                        onChange={(e) => setBorrower({...borrower,
                          address: {
                            ...borrower.address,
                            city: e.target.value
                          }                        })}
                      />
                    </div>
                    <div>
                      <TextField
                        id="state"
                        className={classes.textFieldSmall}
                        label="State"
                        color="secondary"
                        value={borrower? (borrower.address? borrower.address.state:"") :""}
                        onChange={(e) => setBorrower({...borrower,
                          address: {
                            ...borrower.address,
                            state: e.target.value
                          }  
                        })}
                      />
                      <TextField
                        id="zip"
                        className={classes.textFieldSmall}
                        label="Zip"
                        color="secondary"
                        value={borrower? (borrower.address? borrower.address.zip:"") :""}
                        onChange={(e) => setBorrower({...borrower,
                          address: {
                            ...borrower.address,
                            zip: e.target.value
                          }  
                        })}
                      />
                    </div>

                    <div>
                      <TextField
                        id="phone"
                        className={classes.textField}
                        label="Phone"
                        color="secondary"
                      />
                    </div>
                    <div>
                      <TextField
                        id="email"
                        className={classes.textField}
                        label="Email"
                        color="secondary"
                      />
                    </div>
                  </form>
              </Paper>
            </Grid>
            <Grid item>
              <Paper className={classes.paper}>
                <Typography
                  type="headline"
                  component="h2"
                  className={classes.title}
                >
                  Vitals
                </Typography>
                  <form className={classes.root} noValidate autoComplete="off">
                    <div>
                      <TextField
                        id="dob"
                        className={classes.textFieldSmall}
                        label="DOB"
                        color="secondary"
                        value={borrower.dob ? borrower.dob.substring(0,10) :""}
                        onChange={(e) => setBorrower({...borrower,
                          dob: e.target.value
                        })}
                      />
                    </div>
                    <div>
                      <TextField
                        id="age"
                        className={classes.textFieldSmall}
                        label="Age"
                        color="secondary"
                      />
                    </div>
                    <div>
                      <TextField
                        id="ssn"
                        className={classes.textFieldSmall}
                        label="SSN"
                        color="secondary"
                        value={borrower.ssn ? borrower.ssn :""}
                        onChange={(e) => setBorrower({...borrower,
                          ssn: e.target.value
                        })}
                      />
                    </div>
                  </form>
                  <div className={classes.pad}>
                    <Typography
                      type="headline"
                      component="h2"
                      className={classes.title}
                    >
                      Borrower Commands
                    </Typography>
                    <Grid container style={{ justifyContent: "center" }}>
                      <Button variant="contained" className={classes.button} disabled>
                        Add
                      </Button>
                      <Button variant="contained" className={classes.button} disabled>
                        Next
                      </Button>
                      <Button variant="contained" className={classes.button} disabled>
                        Previous
                      </Button>
                      <Button variant="contained" className={classes.button} disabled>
                        Delete
                      </Button>
                    </Grid>
                  </div>
              </Paper>
            </Grid>
          </Grid>
        </Grid>
      </Grid>
    </div>
  );
};
const styles = (theme) => ({
  root: {
    flexGrow: 1,
    margin: "auto",
    justify: "center",
  },
  paper: {
    height: 500,
    width: 400,
  },
  smallPaper: {
    height: 300,
    width: 400,
  },
  largePaper: {
    height: 500,
    width: 815,
    justifyContent: "center",
  },
  buttonPaper: {
    height: 240,
    width: 100,
    paddingTop: theme.spacing(2),
  },
  control: {
    padding: theme.spacing(2),
  },
  textField: {
    marginLeft: theme.spacing(2),
    marginRight: theme.spacing(2),
    width: 300,
  },
  textFieldSmall: {
    marginLeft: theme.spacing(2),
    marginRight: theme.spacing(2),
    width: 150,
  },
  button: {
    margin: theme.spacing(1),
    width: "10ch",
  },
  title: {
    padding: `${theme.spacing(3)}px ${theme.spacing(2.5)}px ${theme.spacing() *
      0.5}px`,
    color: theme.palette.text.secondary,
    fontSize: 24,
    textAlign: "center",
  },
  table: {
    maxHeight: 400,
  },
  tableCell: {
    padding: "1ch",
  },
  submit: {
    margin: theme.spacing(1),
    width: "10ch",
    position: "fixed",
    bottom: 10,
    zIndex: 500,
  },
  pad: {
    paddingTop: "150px"
  }
});

export default withStyles(styles)(Borrower);
