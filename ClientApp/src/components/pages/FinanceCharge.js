import React, { useState } from "react";
import clsx from 'clsx';
import { makeStyles } from '@material-ui/core/styles';
import { withStyles } from "@material-ui/core/styles";
import TextField from '@material-ui/core/TextField';
import Grid from "@material-ui/core/Grid";
import Typography from "@material-ui/core/Typography";
import Box from '@material-ui/core/Box';
import Checkbox from '@material-ui/core/Checkbox';
import Paper from "@material-ui/core/Paper";

const FinanceCharge = (props) => {
  const { classes } = props;
  const [spacing, setSpacing] = React.useState(2);

    const [values, setValues] = React.useState({
      name: '',
      respaNum: '',
      description: '',
    });
    const [amounts, setAmounts] = React.useState({
      lenderAmount: '',
      brokerAmount: '',
      origBrokerAmount: '',
    });
    //const runningTotal = amounts.reduce( (accumulator, currentValue)=> accumulator + currentValue);
    const [total, setTotal] = React.useState({
      runningTotal: '',
    });

    const handleChange = (prop) => (event) => {
    setValues({ ...values, [prop]: event.target.value })
    setAmounts({ ...amounts, [prop]: event.target.value })
    //setTotal({ ...total, runningTotal: + event.target.value })

  };

  return (
    <div style={{ paddingLeft: "155px", width: "99%" }}>
      <Grid container className={classes.root} spacing={2}>
        <Grid item xs={12}>
          <Grid
            container
            justify="left"
            spacing={spacing}
            style={{ width: "100%" }}
          >
            <Grid item>
              <Paper className={classes.largePaper}>
                <Typography
                  type="headline"
                  component="h2"
                  className={classes.title}
                >  
                Finance Charge 
                </Typography>
                <Typography type="body1" component="p">
                  <form className={classes.root} noValidate autoComplete="off">
                    {
                      //---------------ROW 1----------------
                    }
                    <div>
                      <TextField
                      id="title"
                      label="Lender Allocation"
                      disabled="true"
                      className={clsx(classes.margin, classes.textFieldSmall)}
                      />
                      <TextField
                      id="title"
                      label="RESPA #"
                      className={clsx(classes.margin, classes.respaField)}
                      />
                      <TextField
                      id="title"
                      label="Description"
                      className={clsx(classes.margin, classes.textField)}
                      />
                      <TextField
                      id="title"
                      label="Amount"
                      id="standard-adornment-amount"
                      value={amounts.lenderAmount}
                      onChange={handleChange('lenderAmount')}
                      className={clsx(classes.margin, classes.amountField)}
                      />
                    </div>
                    {
                      //---------------ROW 2----------------
                    }
                    <div>
                      <TextField
                      id="title"
                      label="                 "
                      disabled="true"
                      className={clsx(classes.margin, classes.textFieldSmall)}
                      />
                      <TextField
                      id="title"
                      label="802"
                      disabled="true"
                      className={clsx(classes.margin, classes.respaField)}
                      />
                      <TextField
                      id="title"
                      label="Lender Loan Discount Fee"
                      disabled="true"
                      className={clsx(classes.margin, classes.textField)}
                      />
                      <TextField
                      id="title"
                      label="          "
                      disabled="true"
                      className={clsx(classes.margin, classes.amountField)}
                      />
                    </div>
                    {
                      //---------------ROW 3----------------
                    }
                    <div>
                      <TextField
                      id="title"
                      label="Broker Allocation"
                      disabled="true"
                      className={clsx(classes.margin, classes.textFieldSmall)}
                      />
                      <TextField
                      id="title"
                      label="RESPA #"
                      className={clsx(classes.margin, classes.respaField)}
                      />
                      <TextField
                      id="title"
                      label="Description"
                      className={clsx(classes.margin, classes.textField)}
                      />
                      <TextField
                      id="title"
                      label="Amount"
                      id="standard-adornment-amount"
                      value={amounts.brokerAmount}
                      onChange={handleChange('brokerAmount')}
                      className={clsx(classes.margin, classes.amountField)}
                      />
                    </div>
                    {
                      //---------------ROW 4----------------
                    }
                    <div>
                      <TextField
                      id="title"
                      label="Originating Broker Fee"
                      disabled="true"
                      className={clsx(classes.margin, classes.textFieldSmall)}
                      />
                      <TextField
                      id="title"
                      label="RESPA #"
                      className={clsx(classes.margin, classes.respaField)}
                      />
                      <TextField
                      id="title"
                      label="Description"
                      className={clsx(classes.margin, classes.textField)}
                      />
                      <TextField
                      id="title"
                      label="Amount"
                      id="standard-adornment-amount"
                      value={amounts.origBrokerAmount}
                      onChange={handleChange('origBrokerAmount')}
                      className={clsx(classes.margin, classes.amountField)}
                      />
                    </div>
                    {
                      //---------------ROW 5----------------
                    }
                    <div>
                      <TextField
                      id="title"
                      label="Gross Points"
                      disabled="true"
                      className={clsx(classes.margin, classes.textFieldSmall)}
                      />
                      <TextField
                      id="title"
                      label="RESPA #"
                      className={clsx(classes.margin, classes.respaField)}
                      />
                      <TextField
                      id="title"
                      label="Description"
                      className={clsx(classes.margin, classes.textField)}
                      />
                      <TextField
                      id="title"
                      label="Total"
                      disabled="true"
                      id="standard-adornment-amount"
                      value={amounts.brokerAmount}
                      className={clsx(classes.margin, classes.amountField)}
                      />
                  </div>
                  </form>
                  <Grid item>
                    <Paper className={classes.largePaper}>
                      <Typography
                        type="headline"
                        component="h2"
                        className={classes.title}
                      >   
                      </Typography>
                      <Typography type="body1" component="p">
                        <form className={classes.root} noValidate autoComplete="off">
                          <div>
                          <Box
                            display="flex"
                            alignItems="flex-end"
                            flexWrap="nowrap"
                            justifyContent="left"
                            m={2}>
                            <Box px={1}>
                              <Typography>
                                Any amount paid by lender not deducted from loan proceeds?
                                <Checkbox inputProps={{ 'aria-label': 'uncontrolled-checkbox' }} />
                              </Typography>
                            </Box>
                          </Box> 
                        </div>
                        <div>
                          <TextField
                          id="title"
                          label="Yield Spread Premium, Service Release Premium or Other Rebate Received from Lender"
                          disabled="true"
                          className={clsx(classes.margin, classes.textFieldBig)}
                          />
                          <TextField
                          id="title"
                          label="Amount"
                          className={clsx(classes.margin, classes.amountField)}
                          />
                        </div>
                        <div>
                          <TextField
                          id="title"
                          label="Yield Spread Premium, Service Release Premium or Other Rebate Credited to Borrower"
                          disabled="true"
                          className={clsx(classes.margin, classes.textFieldBig)}
                          />
                          <TextField
                          id="title"
                          label="Amount"
                          className={clsx(classes.margin, classes.amountField)}
                          />
                        </div>
                        <div>
                          <TextField
                          id="title"
                          label="Total Amount of Compensation Retained by Broker"
                          disabled="true"
                          className={clsx(classes.margin, classes.textFieldBig)}
                          />
                          <TextField
                          id="title"
                          label="Amount"
                          className={clsx(classes.margin, classes.amountField)}
                          />
                        </div>
                        <div>
                          <TextField
                          id="title"
                          label="Creditor for Truth in Lending"
                          className={clsx(classes.margin, classes.textFieldBig)}
                          />
                        </div>
                        </form>
                      </Typography>
                    </Paper>
                  </Grid>   
                </Typography>
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
    height: 550,
    width: 415,
  },
  smallPaper: {
    height: 60,
    width: 300,
  },
  largePaper: {
    height: 330,
    width: 820,
  },
  buttonPaper: {
    height: 550,
    width: 300,
    paddingTop: theme.spacing(2),
  },
  control: {
    padding: theme.spacing(2),
  },
  textField: {
    marginLeft: theme.spacing(2),
    marginRight: theme.spacing(2),
    width: 325,
  },
  textFieldSmall: {
    marginLeft: theme.spacing(2),
    marginRight: theme.spacing(2),
    width: 210,
  },
  textFieldBig: {
    marginLeft: theme.spacing(2),
    marginRight: theme.spacing(2),
    width: 670,
  },
  respaField: {
    marginLeft: theme.spacing(2),
    marginRight: theme.spacing(2),
    width: 70,
  },
  amountField: {
    marginLeft: theme.spacing(2),
    marginRight: theme.spacing(2),
    width: 85,
  },
  button: {
    margin: theme.spacing(2),
    width: "25ch",
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
});
export default withStyles(styles)(FinanceCharge);
