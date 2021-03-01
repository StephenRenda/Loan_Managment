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

const Escrow = (props) => {
  const { classes } = props;
  const [spacing, setSpacing] = React.useState(2);
  const [escrow, setEscrow] = useState();

  useEffect(() => {
    setEscrow(props.loan.escrow)
  }, [props.loan]);

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
              <Paper className={classes.paper}>
                <Typography
                  type="headline"
                  component="h2"
                  className={classes.title}
                >
                  Escrow Company Information
                </Typography>
                <Typography type="body1" component="p">
                  <form className={classes.root} noValidate autoComplete="off">
                    <div>
                      <TextField
                        id="company-code"
                        className={classes.textField}
                        label="Company Code"
                        color="secondary"
                        value={escrow ? escrow.companyCode : ""}
                      />
                    </div>
                  </form>
                  <form className={classes.root} noValidate autoComplete="off">
                    <div>
                      <TextField
                        id="name"
                        className={classes.textField}
                        label="Escrow Company"
                        color="secondary"
                        value={escrow ? escrow.escrowCompany : ""}
                      />
                    </div>
                  </form>
                  <form className={classes.root} noValidate autoComplete="off">
                    <div>
                      <TextField
                        id="address"
                        className={classes.textField}
                        label="Address"
                        color="secondary"
                        value={escrow ? escrow.address : ""}
                      />
                    </div>
                  </form>
                  <form className={classes.root} noValidate autoComplete="off">
                    <div>
                      <TextField
                        id="city"
                        className={classes.textField}
                        label="City"
                        color="secondary"
                        value={escrow ? escrow.city : ""}
                      />
                    </div>
                  </form>
                  <form className={classes.root} noValidate autoComplete="off">
                    <div>
                      <TextField
                        id="state"
                        className={classes.textField}
                        label="State"
                        color="secondary"
                        value={escrow ? escrow.state : ""}
                      />
                    </div>
                  </form>
                  <form className={classes.root} noValidate autoComplete="off">
                    <div>
                      <TextField
                        id="zip"
                        className={classes.textField}
                        label="Zip"
                        color="secondary"
                        value={escrow ? escrow.zipCode : ""}
                      />
                    </div>
                  </form>
                  <form className={classes.root} noValidate autoComplete="off">
                    <div>
                      <TextField
                        id="phone"
                        className={classes.textField}
                        label="Phone"
                        color="secondary"
                        value={escrow ? escrow.phone : ""}
                      />
                    </div>
                  </form>
                  <form className={classes.root} noValidate autoComplete="off">
                    <div>
                      <TextField
                        id="fax"
                        className={classes.textField}
                        label="Fax"
                        color="secondary"
                        value={escrow ? escrow.fax : ""}
                      />
                    </div>
                  </form>
                </Typography>
              </Paper>
            </Grid>
            <Grid item>
              <Paper className={classes.paper}>
                <Typography
                  type="headline"
                  component="h2"
                  className={classes.title}
                >
                  Title Insurance Requirements
                </Typography>
                <Typography type="body1" component="p">
                  <form className={classes.root} noValidate autoComplete="off">
                    <div>
                      <TextField
                        className={classes.textField}
                        id="policy"
                        label="Policy Type"
                        value={escrow ? escrow.policyType : ""}
                        />
                    </div>
                  </form>
                  <form className={classes.root} noValidate autoComplete="off">
                    <div>
                      <TextField
                        className={classes.textField}
                        id="amount"
                        label="Amount"
                        value={escrow ? escrow.policyAmount : ""}
                      />
                    </div>
                  </form>
                  <form className={classes.root} noValidate autoComplete="off">
                    <div>
                      <TextField
                        className={classes.textField}
                        id="loanperc"
                        label="Loan %"
                        value={escrow ? escrow.percentLoan : ""}
                      />
                    </div>
                  </form>
                  <form className={classes.root} noValidate autoComplete="off">
                    <div>
                      <TextField
                        className={classes.textField}
                        id="specendors"
                        label="Special Endorsments"
                        value={escrow ? escrow.specialEndorsments : ""}
                      />
                    </div>
                  </form>
                  <form className={classes.root} noValidate autoComplete="off">
                    <div>
                      <TextField
                        className={classes.textField}
                        id="titledate"
                        label="Title Report Date"
                        type="date"
                      />
                    </div>
                  </form>
                  <form className={classes.root} noValidate autoComplete="off">
                    <div>
                      <TextField
                        multiline
                        className={classes.textField}
                        id="titleexc"
                        label="Title Report Exceptions"
                        value={escrow ? escrow.exceptions : ""}
                      />
                    </div>
                  </form>
                  <form className={classes.root} noValidate autoComplete="off">
                    <div>
                      <TextField
                        multiline
                        className={classes.textField}
                        id="titleelim"
                        label="Title Report Item Elimination"
                        value={escrow ? escrow.itemElimination : ""}
                      />
                    </div>
                  </form>
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
    height: 500,
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
  table: {
    maxHeight: 400,
  },
});
export default withStyles(styles)(Escrow);
