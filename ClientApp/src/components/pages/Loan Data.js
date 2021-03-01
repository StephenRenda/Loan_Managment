import React, { useState, useEffect } from "react";
import { withStyles } from "@material-ui/core/styles";

import Typography from "@material-ui/core/Typography";
import TextField from "@material-ui/core/TextField";
import Button from "@material-ui/core/Button";
import Grid from "@material-ui/core/Grid";

import Paper from "@material-ui/core/Paper";
import Table from "@material-ui/core/Table";
import TableBody from "@material-ui/core/TableBody";
import TableCell from "@material-ui/core/TableCell";
import TableContainer from "@material-ui/core/TableContainer";
import TableHead from "@material-ui/core/TableHead";
import TableRow from "@material-ui/core/TableRow";
import Box from '@material-ui/core/Box';
import Checkbox from '@material-ui/core/Checkbox';
import Select from '@material-ui/core/Select'
import InputLabel from '@material-ui/core/InputLabel';
import MenuItem from '@material-ui/core/MenuItem';
import FormHelperText from '@material-ui/core/FormHelperText';
import FormControl from '@material-ui/core/FormControl';
import { editLoans } from "../../utils/api-loan.js";

const LoanData = (props) => {
  const { classes } = props;
  const [spacing, setSpacing] = React.useState(2);
  const [loan, setLoan] = useState(null);

  useEffect(() => {
    setLoan(props.loan)
  }, [props.loan]);

  const handlesubmit = (() => {
    //Copy of the loan
    let temp = JSON.parse(JSON.stringify(props.loan));
    const loanMod = {
      id: loan.id,
      loanNumber: loan.loanNumber,
      name: loan.name,
      companyName: loan.companyName,
      stage: loan.stage,
      principalAmt: loan.principalAmt,
      intRate: loan.intRate,
      intRateLender: loan.intRateLender,
      paymentsPerPeriod: loan.paymentsPerPeriod,
      totalPaymentsInPeriods: loan.totalPaymentsInPeriods,
      paymentsCollectedInAdvance: loan.paymentsCollectedInAdvance,
      paymentAmortizationPeriod: loan.paymentAmortizationPeriod,
      regPaymentAmt: loan.regPaymentAmt,
      maturityDate: loan.maturityDate,
      loanPoints: loan.loanPoints,
      totalLoanFee: loan.totalLoanFee,
    };
    editLoans({ id: loan.id, loan: loanMod }).then((data) => {
      if (data.error) {
        console.log(data.error)
      } else {
        console.log("Successfully updated db.")
      }
    })
    temp = { ...props.loan, ...loanMod };
    props.handleLoanChange(temp);
  })

  const dateNow = new Date();
  const year = dateNow.getFullYear();
  const monthOffset = dateNow.getUTCMonth() + 1;
  const month = monthOffset.toString().length < 2 ? `0${monthOffset}` : monthOffset;
  const date = dateNow.getUTCDate().toString().length < 2 ? `0${dateNow.getUTCDate()}` : dateNow.getUTCDate();
  const muiDate = `${year}-${month}-${date}`;

  return (
    console.log(loan),
    <div style={{ paddingLeft: "155px", width: "99%" }}>
      <Button variant="contained" color="secondary" className={classes.submit} onClick={handlesubmit}>
        SUBMIT
      </Button>
      <Grid container className={classes.root} spacing={2}>
        <Grid item xs={12}>
          <Grid //Payment and Loan Data
            container
            justify="left"
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
                  Payment and Loan Data
                </Typography>
                <Typography type="body1" component="p">
                  <form className={classes.root} noValidate autoComplete="off">
                    <div>
                      <TextField
                        id="standard-secondary"
                        className={classes.textField}
                        label="Principle amount of loan"
                        value={loan ? loan.principalAmt : ""}
                        color="secondary"
                        onChange={(e) => setLoan({...loan,
                          principalAmt: e.target.value
                        })}
                      />
                    </div>
                  </form>
                  <form className={classes.root} noValidate autoComplete="off">
                    <div>
                      <TextField
                        id="standard-secondary"
                        className={classes.textField}
                        label="Interest Rate"
                        value={loan ? loan.intRate : ""}
                        color="secondary"
                        onChange={(e) => setLoan({
                          ...loan,
                          intRate: e.target.value
                        })}
                      />
                    </div>
                  </form>
                  <form className={classes.root} noValidate autoComplete="off">
                    <div>
                      <TextField
                        id="standard-secondary"
                        className={classes.textField}
                        label="Interest Rate for Lender Purchase Disclosure"
                        value={loan ? loan.intRateLender : ""}
                        color="secondary"
                        onChange={(e) => setLoan({
                          ...loan,
                          intRateLender: e.target.value
                        })}
                      />
                    </div>
                  </form>
                  <form className={classes.root} noValidate autoComplete="off">
                    <div>
                      <TextField
                        id="standard-secondary"
                        className={classes.textField}
                        label="Number of payments per period (e.g. monthly 12)"
                        value={loan ? loan.paymentsPerPeriod : ""}
                        color="secondary"
                        onChange={(e) => setLoan({
                          ...loan,
                          paymentsPerPeriod: e.target.value
                        })}
                      />
                    </div>
                  </form>
                  <form className={classes.root} noValidate autoComplete="off">
                    <div>
                      <TextField
                        id="standard-secondary"
                        className={classes.textField}
                        label="Number of prepaid payments collected in advance"
                        value={loan ? loan.paymentsCollectedInAdvance : ""}
                        color="secondary"
                        onChange={(e) => setLoan({
                          ...loan,
                          paymentsCollectedInAdvance: e.target.value
                        })}
                      />
                    </div>
                  </form>
                  <form className={classes.root} noValidate autoComplete="off">
                    <div>
                      <TextField
                        id="standard-secondary"
                        className={classes.textField}
                        label="Payment amortization period"
                        value={loan ? loan.paymentAmortizationPeriod : ""}
                        color="secondary"
                        onChange={(e) => setLoan({
                          ...loan,
                          paymentAmortizationPeriod: e.target.value
                        })}
                      />
                    </div>
                  </form>
                  <form className={classes.root} noValidate autoComplete="off">
                    <div>
                      <TextField
                        id="standard-secondary"
                        className={classes.textField}
                        label="Amount of regular payment"
                        value={loan ? loan.regPaymentAmt : ""}
                        color="secondary"
                        onChange={(e) => setLoan({
                          ...loan,
                          regPaymentAmt: e.target.value
                        })}
                      />
                    </div>
                  </form>
                  <form className={classes.root} noValidate autoComplete="off">
                    <div>
                      <TextField
                        id="standard-secondary"
                        className={classes.textField}
                        label="Interest Rate lock date"
                        type="date"
                        value={props.loan ? `${(new Date(Date.parse(props.loan.intRateLockDate))).getUTCFullYear()}-${(new Date(Date.parse(props.loan.intRateLockDate))).getUTCMonth()}-${(new Date(Date.parse(props.loan.intRateLockDate))).getUTCDay()}` : "1111-11-11"}
                        color="secondary"
                        onChange={(e) => setLoan({
                          ...loan,
                          intRateLockDate: new Date(e.target.value).toISOString().slice(0, 19).replace('T', ' ')
                        })}
                      />
                    </div>
                  </form>
                  <form className={classes.root} noValidate autoComplete="off">
                    <div>
                      <TextField
                        id="standard-secondary"
                        className={classes.textField}
                        label="Default Rate"
                        value={loan ? loan.principalAmt : ""}
                        color="secondary"
                        onChange={(e) => setLoan({
                          ...loan,
                          principalAmt: e.target.value
                        })}
                      />
                    </div>
                  </form>
                </Typography>
              </Paper>
            </Grid>
            <Grid item>
              <Paper className={classes.largePaper}>
                <Typography
                  type="headline"
                  component="h2"
                  className={classes.title}
                >
                  Loan Fee and Date Information
                </Typography>

                <Box
                  display="flex"
                  alignItems="flex-end"
                  flexWrap="nowrap"
                  justifyContent="center"
                  m={2}>
                  <Box px={1}>
                    <TextField
                      id="standard-number"
                      label="Number of loan points"
                      value={loan ? loan.loanPoints : ""}
                      onChange={(e) => setLoan({
                        ...loan,
                        loanPoints: e.target.value
                      })}
                    />
                  </Box>
                  <Box px={1}>
                    <Typography variant="body1">
                      +
                    </Typography>
                  </Box>
                  <Box px={1}>
                    <TextField
                      id="standard-number"
                      label="Other points fees"
                      value={loan ? loan.totalLoanFee - loan.loanPoints : ""}
                    />
                  </Box>
                  <Box px={1}>
                    <Typography variant="body1">
                      =
                    </Typography>
                  </Box>
                  <Box px={1}>
                    <TextField
                      id="standard-number"
                      label="Total loan fee"
                      value={loan ? loan.totalLoanFee : ""}
                    />
                  </Box>
                </Box>

                <Box
                  display="flex"
                  alignItems="flex-end"
                  flexWrap="nowrap"
                  justifyContent="center"
                  m={2}>
                  <Box px={1}>
                    <TextField
                      id="date"
                      label="Estimated Funding Date"
                      type="date"
                      defaultValue={muiDate}
                    />
                  </Box>
                  <Box px={1}>
                    <TextField
                      id="date"
                      label="First Payment Date"
                      type="date"
                      defaultValue={muiDate}
                    />
                  </Box>
                  <Box px={1}>
                    <TextField
                      id="date"
                      label="Document Date"
                      type="date"
                      defaultValue={muiDate}
                    />
                  </Box>
                </Box>

                <Box
                  display="flex"
                  alignItems="flex-end"
                  flexWrap="nowrap"
                  justifyContent="center"
                  m={2}>
                  <Box px={1}>
                    <Typography>
                      Calculate on a 365 day year
                    </Typography>
                  </Box>
                  <Box px={1}>
                    <Checkbox inputProps={{ 'aria-label': 'uncontrolled-checkbox' }} />
                  </Box>
                  <Box px={1}>
                    <InputLabel id="clause">Exclusive right clause</InputLabel>
                    <Select>
                      <MenuItem value={120}>120</MenuItem>
                      <MenuItem value={180}>180</MenuItem>
                    </Select>
                  </Box>
                </Box>

                <Box
                  display="flex"
                  alignItems="center"
                  flexWrap="nowrap"
                  justifyContent="center"
                  m={2}>
                  <Box px={1}>
                    <TextField
                      id="maturity_date"
                      className={classes.textFieldSmall}
                      label="Maturity Date"
                      type="date"
                      defaultValue={muiDate}
                      color="secondary"
                      onChange={(e) => setLoan({
                        ...loan,
                        maturityDate: new Date(e.target.value).toISOString().slice(0, 19).replace('T', ' ')
                      })}
                    />
                  </Box>
                  <Box px={1}>
                    <Typography>
                      <u>Prorated Interest</u>
                    </Typography>
                    <Typography>
                      X Days of interest
                    </Typography>
                    <Typography>
                      $0.00 per day
                    </Typography>
                    <Typography>
                      $0.00 due
                    </Typography>
                  </Box>
                </Box>

              </Paper>
            </Grid>
          </Grid>
        </Grid>
      </Grid>
    </div>
  );
};

function ConvertDate(date) {
  Date.parse(date)
}

const styles = (theme) => ({
  root: {
    flexGrow: 1,
    margin: "auto",
    justify: "center",
  },
  paper: {
    height: 550,
    width: 415,
  },
  largePaper: {
    height: 550,
    width: 850,
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
    width: 375,
  },
  textFieldSmall: {
    marginLeft: theme.spacing(2),
    marginRight: theme.spacing(2),
    width: 150,
  },
  button: {
    margin: theme.spacing(2),
    width: "15ch",
  },
  title: {
    padding: `${theme.spacing(3)}px ${theme.spacing(2.5)}px ${theme.spacing() *
      0.5}px`,
    color: theme.palette.text.secondary,
    fontSize: 24,
    textAlign: "center",
  },
  submit: {
    margin: theme.spacing(1),
    width: "10ch",
    position: "fixed",
    bottom: 10,
    zIndex: 500,
  },
  table: {
    maxHeight: 400,
  },
});
export default withStyles(styles)(LoanData);
