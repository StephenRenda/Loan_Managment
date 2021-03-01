import React, { useState, useEffect } from "react";
import { withStyles } from "@material-ui/core/styles";

import Typography from "@material-ui/core/Typography";
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
import { DataGrid } from "@material-ui/data-grid";
import Pagination from "@material-ui/lab/Pagination";
import PaginationItem from "@material-ui/lab/PaginationItem";
import auth from "../auth/auth-helper";
import Checkbox from '@material-ui/core/Checkbox';
import { findLoanDeductions } from "../../utils/api-loan.js";

const CostExpense = (props) => {
  const { classes } = props;
  const [spacing, setSpacing] = React.useState(2);
  const [loan, setLoan] = React.useState();
  const [deduction, setDeduction] = React.useState([]);
  const [rows, setRows] = React.useState([])

  useEffect(() => {
    if (!(props.loan === null || props.loan === "empty" || !props.loan.costRef)) {
      setDeduction(props.loan.costRef)
      setLoan(props.loan)
    }
  }, [props.loan]);

  const getDummyRows = () => {
    let initialrows = [{
      id: props.loan.loanNumber,
      description: "",
      respa: 0,
      amount: 0,
      ppf: false,
      est: false,
      poe: false,
      net: false,
      sec: false,
      re882: false,
    },];
  }

  useEffect(() => {
    if (loan != null) {

      let rows = [];
      rows = [ {
        id: 1,
        description: deduction.brokerDeductions1.desc,
        respa: deduction.brokerDeductions1.rESPA,
        amount: deduction.brokerDeductions1.amount,
        ppf: deduction.brokerDeductions1.PPF,
        est: deduction.brokerDeductions1.EST,
        poe: deduction.brokerDeductions1.POE,
        net: deduction.brokerDeductions1.nET,
        sec: deduction.brokerDeductions1.sEC,
        re882: deduction.brokerDeductions1.sE882M,
        },
        {
          id: 2,
          description: deduction.brokerDeductions2.desc,
          respa: deduction.brokerDeductions2.rESPA,
          amount: deduction.brokerDeductions2.amount,
          ppf: deduction.brokerDeductions2.pPF,
          est: deduction.brokerDeductions2.eST,
          poe: deduction.brokerDeductions2.pOE,
          net: deduction.brokerDeductions2.nET,
          sec: deduction.brokerDeductions2.sEC,
          re882: deduction.brokerDeductions2.rE882M,
        }, ]
      setRows(rows)
    }
  }, [loan]);

  const columns = [
    { field: "description", headerName: "Description", width: 400 },
    { field: "respa", headerName: "Respa#", type: "number", width: 90 },
    { field: "amount", headerName: "Amount", type: "number", width: 90 },
    { field: "ppf", headerName: "PPF", type: "number", width: 90, renderCell: rowData => <Checkbox checked={rowData ? true : false}/> },
    { field: "est", headerName: "EST", type: "number", width: 90, renderCell: rowData => <Checkbox checked={rowData ? true : false} />},
    { field: "poe", headerName: "POE", type: "number", width: 90, renderCell: rowData => <Checkbox checked={rowData ? true : false} />},
    { field: "net", headerName: "NET", type: "number", width: 90, renderCell: rowData => <Checkbox checked={rowData ? true : false} />},
    { field: "sec", headerName: "SEC32", type: "number", width: 90, renderCell: rowData => <Checkbox checked={rowData ? true : false} />},
    { field: "re882", headerName: "RE882/M", type: "number", width: 100, },
  ];

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
    <div style={{ paddingLeft: "155px", width: "99%" }} className={classes.root}>
      <Grid
        container
        justify="center"
        spacing={spacing}
        style={{ width: "100%" }}
      >
        <Grid item>
          <Paper className={classes.paper}>
            <Paper className={classes.titlePaper}>
              <div>
                <Typography
                  type="headline"
                  component="h2"
                  className={classes.title}
                  justifyContent="center"
                >
                    Deductions to broker
                </Typography>
              </div>
            </Paper>
            <Typography
              type="body"
              component="p"
              align="center"
            >
              <Box p={1}>
                Deduction to broker: $0.00
              </Box>
              <Box p={1}>
                Section 32 Amount: $0.00
              </Box>
            </Typography>
          </Paper>
        </Grid>

        <Grid
          item
          justify="center"
          spacing={spacing}
          style={{ width: "100%" }}>
          <div style={{ height: 400, width: "100%" }}>
            <DataGrid
              rows={rows ? rows : getDummyRows()}
              columns={columns}
              pageSize={5}
              checkboxSelection
              className={classes.root}
              components={{
                pagination: CustomPagination,
              }}
            />
          </div>
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
                  Filters
                </Typography>
              </div>
            </Paper>
            <Grid
              container
              align="center"
              justifyContent="center">
              <Grid item xs={12}>
                <Button variant="contained" className={classes.button}>
                  Other Deductions
                </Button>
                <Button variant="contained" className={classes.button}>
                  Broker Payments
                </Button>
                <Button variant="contained" className={classes.button}>
                  Other Payments
                </Button>
              </Grid>
            </Grid>
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
                  Payment options
                </Typography>
              </div>
            </Paper>
            <Grid
              container
              align="center"
              justifyContent="center">
              <Grid item xs={12}>
                <Button variant="contained" className={classes.button}>
                  Add Payment
                </Button>
                <Button variant="contained" className={classes.button}>
                  Edit Payment
                </Button>
                <Button variant="contained" className={classes.button}>
                  Delete Payment
                </Button>
              </Grid>
            </Grid>
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
                  Forms
                </Typography>
              </div>
            </Paper>
            <Grid
              container
              align="center"
              justifyContent="center">
              <Grid item xs={12}>
                <Button variant="contained" className={classes.button}>
                    FC4970/CAL32/HPML
                </Button>
              </Grid>
              <Grid item xs={12}>
                <Button variant="contained" className={classes.button}>
                    Section 32 Analysis
                </Button>
              </Grid>
              <Grid item xs={12}>
                <Button variant="contained" className={classes.button}>
                  HPML Test
                </Button>
              </Grid>
              <Grid item xs={12}>
                <Button variant="contained" className={classes.button}>
                  Good Fath Estimate
                </Button>
              </Grid>
              <Grid item xs={12}>
                <Button variant="contained" className={classes.button}>
                  Update GFE
                </Button>
              </Grid>
              <Grid item xs={12}>
                <Button variant="contained" className={classes.button}>
                  HUD1A
                </Button>
              </Grid>
            </Grid>
          </Paper>
        </Grid>
      </Grid>
    </div>
  );
};

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

const styles = (theme) => ({
  root: {
    flexGrow: 1,
    margin: "auto",
    justify: "center",
  },
  paper: {
    height: 150,
    width: 400,
  },
  smallPaper: {
    height: 60,
    width: 300,
  },
  titlePaper: {
    height: 60,
    width: 400,
  },
  largePaper: {
    height: 500,
    width: 815,
    justifyContent: "center",
  },
  buttonPaper: {
    height: 450,
    width: 300,
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
    width: "19ch",
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
});
export default withStyles(styles)(CostExpense);
