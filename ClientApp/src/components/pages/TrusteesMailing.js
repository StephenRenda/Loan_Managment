import React from "react";
import { render } from 'react-dom';
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

const LoanData = (props) => {
  const { classes } = props;
  const [spacing, setSpacing] = React.useState(2);

  const dateNow = new Date();
  const year = dateNow.getFullYear();
  const monthOffset = dateNow.getUTCMonth() + 1;
  const month = monthOffset.toString().length < 2 ? `0${monthOffset}` : monthOffset;
  const date = dateNow.getUTCDate().toString().length < 2 ? `0${dateNow.getUTCDate()}` : dateNow.getUTCDate();
  const muiDate = `${year}-${month}-${date}`;

  return (
    <div style={{ paddingLeft: "155px", width: "99%" }}>
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
                  Mortgage/Trustee
                </Typography>
                <Typography type="body1" component="p">
                  <form className={classes.root} noValidate autoComplete="off">
                    <div>
                      <TextField
                        id="standard-secondary"
                        className={classes.textField}
                        label="Mortgage/Trustee"
                        color="secondary"
                      />
                    </div>
                  </form>
                  <form className={classes.root} noValidate autoComplete="off">
                    <div>
                      <TextField
                        id="standard-secondary"
                        className={classes.textField}
                        label="Mail To"
                        color="secondary"
                      />
                    </div>
                  </form>
                  <form className={classes.root} noValidate autoComplete="off">
                    <div>
                      <TextField
                        id="standard-secondary"
                        className={classes.textField}
                        label="Address"
                        color="secondary"
                      />
                    </div>
                  </form>
                  <form className={classes.root} noValidate autoComplete="off">
                    <div>
                      <TextField
                        id="standard-secondary"
                        className={classes.textField}
                        label="City"
                        color="secondary"
                      />
                    </div>
                  </form>
                  <form className={classes.root} noValidate autoComplete="off">
                    <div>
                      <TextField
                        id="standard-secondary"
                        className={classes.textField}
                        label="State"
                        color="secondary"
                      />
                    </div>
                  </form>
                  <form className={classes.root} noValidate autoComplete="off">
                    <div>
                      <TextField
                        id="standard-secondary"
                        className={classes.textField}
                        label="Zip Code"
                        color="secondary"
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
                  Source of Borrower Information
                </Typography>
                <Box
                  display="flex"
                  alignItems="flex-end"
                  flexWrap="nowrap"
                  justifyContent="center"
                  m={2}>
                </Box>
                <Box
                  display="flex"
                  alignItems="flex-end"
                  flexWrap="nowrap"
                  justifyContent="left"
                  m={2}>
                  <Box px={1}>
                    <Typography>
                      Borrower
                      <Checkbox inputProps={{ 'aria-label': 'uncontrolled-checkbox' }} />
                    </Typography>
                  </Box>
                </Box>
                <Box
                  display="flex"
                  alignItems="flex-end"
                  flexWrap="nowrap"
                  justifyContent="left"
                  m={2}>
                  <Box px={1}>
                    <Typography>
                      Broker Inquiry
                    <Checkbox inputProps={{ 'aria-label': 'uncontrolled-checkbox' }} />
                    </Typography> 
                  </Box>
                </Box>
                <Box
                  display="flex"
                  alignItems="flex-end"
                  flexWrap="nowrap"
                  justifyContent="left"
                  m={2}>
                  <Box px={1}>
                    <Typography>
                      Other
                    <Checkbox inputProps={{ 'aria-label': 'uncontrolled-checkbox' }} />
                    <TextField
                        id="standard-secondary"
                        className={classes.textFieldSmall}
                        label="Please specify"
                        color="secondary"
                      />
                    </Typography> 
                  </Box>
                </Box>
              </Paper>
            </Grid>
            <Grid item>
              <Paper className={classes.paper}>
                <Typography
                  type="headline"
                  component="h2"
                  className={classes.title}
                >
                  Source of Encumbrance Information
                </Typography>
                <Box
                  display="flex"
                  alignItems="flex-end"
                  flexWrap="nowrap"
                  justifyContent="center"
                  m={2}>
                </Box>
                <Box
                  display="flex"
                  alignItems="flex-end"
                  flexWrap="nowrap"
                  justifyContent="left"
                  m={2}>
                  <Box px={1}>
                    <Typography>
                      Borrower
                      <Checkbox inputProps={{ 'aria-label': 'uncontrolled-checkbox' }} />
                    </Typography>
                  </Box>
                </Box>
                <Box
                  display="flex"
                  alignItems="flex-end"
                  flexWrap="nowrap"
                  justifyContent="left"
                  m={2}>
                  <Box px={1}>
                    <Typography>
                      Broker Inquiry
                    <Checkbox inputProps={{ 'aria-label': 'uncontrolled-checkbox' }} />
                    </Typography> 
                  </Box>
                </Box>
                <Box
                  display="flex"
                  alignItems="flex-end"
                  flexWrap="nowrap"
                  justifyContent="left"
                  m={2}>
                  <Box px={1}>
                    <Typography>
                      Other
                    <Checkbox inputProps={{ 'aria-label': 'uncontrolled-checkbox' }} />
                    <TextField
                        id="standard-secondary"
                        className={classes.textFieldSmall}
                        label="Please specify"
                        color="secondary"
                      />
                    </Typography> 
                  </Box>
                </Box>
              </Paper>
            </Grid>
            <Grid
          item>
          <Paper className={classes.buttonPaper}>
            <Paper className={classes.smallPaper}>
              <div>
                <Typography
                  type="headline"
                  component="h2"
                  className={classes.title}
                  justifyContent="center"
                >
                </Typography>
              </div>
            </Paper>
            <Grid
              container
              align="center"
              justifyContent="center">
              <Grid item xs={12}>
                <Button variant="contained" className={classes.button}>
                    Exhibit 'A'
                </Button>
              </Grid>
              <Grid item xs={12}>
                <Button variant="contained" className={classes.button}>
                    Exhibit 'B'
                </Button>
              </Grid>
              <Grid item xs={12}>
                <Button variant="contained" className={classes.button}>
                  Rider/Addendum 1
                </Button>
              </Grid>
              <Grid item xs={12}>
                <Button variant="contained" className={classes.button}>
                  Rider/Addendum 1
                </Button>
              </Grid>
              <Grid item xs={12}>
                <Button variant="contained" className={classes.button}>
                  Trustor Vesting
                </Button>
              </Grid>
              <Grid item xs={12}>
                <Button variant="contained" className={classes.button}>
                  Adverse Action
                </Button>
              </Grid>
              </Grid>
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
    width: 375,
  },
  textFieldSmall: {
    marginLeft: theme.spacing(2),
    marginRight: theme.spacing(2),
    width: 250,
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
export default withStyles(styles)(LoanData);
