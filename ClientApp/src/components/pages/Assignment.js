import React from "react";
import { withStyles } from "@material-ui/core/styles";

import Typography from "@material-ui/core/Typography";
import Button from "@material-ui/core/Button";
import Grid from "@material-ui/core/Grid";
import TextField from "@material-ui/core/TextField";
import Checkbox from '@material-ui/core/Checkbox';
import clsx from 'clsx';
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

import { useState, useEffect } from "react";
import { editBorrower, editLoans, newBorrower } from "../../utils/api-loan.js";


const Assignment = (props) => {
    const { classes } = props;
    const [spacing, setSpacing] = React.useState(2);
    const [assignment, setAssignment] = useState([]);
    console.log(props.loan);
    console.log(assignment);

    useEffect(() => {
        if (!(props.loan === null || props.loan === "empty" || !props.loan.assignment))
            setAssignment(props.loan.assignment)
    }, [props.loan]);

    const rows = [
        { id: 1, account: 'broker', lender: 'The Money Brokers, Inc.', percentage: 0.0, amount: 3.7,  },
        { id: 2, account: 'broker', lender: 'The Money Brokers, Inc.', percentage: 0.0, amount: 3.7, },
        { id: 3, account: 'broker', lender: 'The Money Brokers, Inc.', percentage: 0.0, amount: 3.7, },
        { id: 4, account: 'broker', lender: 'The Money Brokers, Inc.', percentage: 0.0, amount: 3.7, },
        { id: 5, account: 'broker', lender: 'The Money Brokers, Inc.', percentage: 0.0, amount: 3.7, },
        { id: 6, account: 'broker', lender: 'The Money Brokers, Inc.', percentage: 0.0, amount: 3.7, }
    ];

    const columns = [
        { field: "account", headerName: "Account", width: 150 },
        { field: "lender", headerName: "Lender Name", width: 400 },
        { field: "percentage", headerName: "Percentage", type: "number", width: 110 },
        { field: "amount", headerName: "Amount", type: "number", width: 90 },
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
                Deed of Trust 
                </Typography>
                <Typography type="body1" component="p">
                  <form className={classes.root} noValidate autoComplete="off">
                    <div>
                      <TextField
                      id="title"
                      label="Recording Date:"
                      disabled="true"
                      className={clsx(classes.margin, classes.textFieldSmallest)}
                      />
                      <TextField
                      id="title"
                      label="          "
                      className={clsx(classes.margin, classes.textField)}
                      />
                      <TextField
                      id="title"
                      label="Book:"
                      disabled="true"
                      className={clsx(classes.margin, classes.textFieldSmallest)}
                      />
                      <TextField
                      id="title"
                      label="          "
                      className={clsx(classes.margin, classes.textField)}
                      />
                    </div>
                    {
                      //---------------ROW 2----------------
                    }
                    <div>
                      <TextField
                      id="title"
                      label="Instrument Number:"
                      disabled="true"
                      className={clsx(classes.margin, classes.textFieldSmallest)}
                      />
                      <TextField
                      id="title"
                      label="          "
                      className={clsx(classes.margin, classes.textField)}
                      />
                      <TextField
                      id="title"
                      label="Page:"
                      disabled="true"
                      className={clsx(classes.margin, classes.textFieldSmallest)}
                      />
                      <TextField
                      id="title"
                      label="          "
                      className={clsx(classes.margin, classes.textField)}
                      />
                    </div>
                  </form>
                        </Typography>
                    </Paper>
                </Grid>

                <Grid container>
                    <Grid
                        item
                        justify="center"
                        spacing={spacing}
                        style={{ width: 1000 }}>
                        <div style={{ height: 400, width: "100%" }}>
                            <DataGrid
                                rows={rows}
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
                        <Paper className={classes.buttonPaperSmall}>
                            <Grid
                                container
                                align="center"
                                justifyContent="center">
                                <Grid item xs={12}>
                                    <Button variant="contained" className={classes.button}>
                                        Round/Calc
                                    </Button>
                                    <Button variant="contained" className={classes.button}>
                                        Build TD Vesting
                                    </Button>
                                    <Button variant="contained" className={classes.button}>
                                        Build Assign Vesting
                                    </Button>
                                </Grid>
                            </Grid>
                        </Paper>
                    </Grid>
                </Grid>

                <Grid item>
                    <Paper className={classes.largePaper}>
                        <Paper className={classes.titlePaper}>
                            <div>
                                <Typography
                                    type="headline"
                                    component="h2"
                                    className={classes.title}
                                    justifyContent="center"
                                >
                                    Edit Lender
                                </Typography>
                            </div>
                        </Paper>
                        <Grid container>
                            <TextField
                                id="standard-secondary"
                                className={classes.textField}
                                label="Lender Number"
                                color="secondary"
                            />
                            <Typography>
                                Include in Building Vesting
                                <Checkbox inputProps={{ 'aria-label': 'uncontrolled-checkbox' }} />
                            </Typography>
                            <Grid container>
                                <TextField
                                    id="standard-secondary"
                                    className={classes.textField}
                                    label="Name"
                                    color="secondary"
                                />
                            </Grid>
                            <Grid container>
                                <TextField
                                    id="standard-secondary"
                                    className={classes.textField}
                                    label="Percentage"
                                    color="secondary"
                                />
                            </Grid>
                            <Grid container>
                                <TextField
                                    id="standard-secondary"
                                    className={classes.textField}
                                    label="Amount Invested"
                                    color="secondary"
                                />
                            </Grid>
                        </Grid>
                        <Grid container>
                            <Grid item>
                                <Typography
                                    type="headline"
                                    component="h4"
                                    className={classes.title}
                                    justifyContent="center"
                                >
                                    Tier #1 Servicing Fee
                                </Typography>
                                <Grid container>
                                    <TextField
                                        id="standard-secondary"
                                        className={classes.textField}
                                        label="Servicing Fee %"
                                        color="secondary"
                                    />
                                </Grid>
                                <Grid container>
                                    <TextField
                                        id="standard-secondary"
                                        className={classes.textField}
                                        label="Minimum Fee"
                                        color="secondary"
                                    />
                                </Grid>
                                <Grid container>
                                    <Typography>
                                        Differential
                                        <Checkbox inputProps={{ 'aria-label': 'uncontrolled-checkbox' }} />
                                    </Typography>
                                </Grid>
                            </Grid>
                            <Grid item>
                                <Typography
                                    type="headline"
                                    component="h4"
                                    className={classes.title}
                                    justifyContent="center"
                                >
                                    Tier #2 Servicing Fee
                                </Typography>
                                <Grid container>
                                    <TextField
                                        id="standard-secondary"
                                        className={classes.textField}
                                        label="Servicing Fee %"
                                        color="secondary"
                                    />
                                </Grid>
                                <Grid container>
                                    <TextField
                                        id="standard-secondary"
                                        className={classes.textField}
                                        label="Minimum Fee"
                                        color="secondary"
                                    />
                                </Grid>
                                <Grid container>
                                    <Typography>
                                        Differential
                                        <Checkbox inputProps={{ 'aria-label': 'uncontrolled-checkbox' }} />
                                    </Typography>
                                </Grid>
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
        height: 190,
        width: 990,
    },
    smallPaper: {
        height: 60,
        width: 300,
    },
    titlePaper: {
        height: 60,
        width: 800,
    },
    largePaper: {
        height: 500,
        width: 800,
        justifyContent: "center",
    },
    buttonPaper: {
        height: 400,
        width: 300,
    },
    buttonPaperSmall: {
        height: 205,
        width: 300,
    },
    control: {
        padding: theme.spacing(2),
    },

    textField: {
        marginLeft: theme.spacing(2),
        marginRight: theme.spacing(2),
        width: 200,
    },
    textFieldSmall: {
        marginLeft: theme.spacing(2),
        marginRight: theme.spacing(2),
        width: 150,
    },
    textFieldSmallest: {
        marginLeft: theme.spacing(2),
        marginRight: theme.spacing(2),
        width: 160,
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
export default withStyles(styles)(Assignment);
