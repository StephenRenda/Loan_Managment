import React, { useState, useEffect } from "react";
import Box from '@material-ui/core/Box';
import Checkbox from '@material-ui/core/Checkbox';
import { Button, Typography, TextField, Grid, Paper, withStyles } from '@material-ui/core';

const NoteRef = (props) => {
    const { classes } = props;
    const [spacing, setSpacing] = React.useState(2);
    const [noteRef, setNote] = useState([]);
    console.log(props.loan);
    useEffect(() => {
        if (!(props.noteRef === null || props.noteRef === "empty" || !props.loan.noteRef))
            setNote(props.loan.noteRef)
    }, [props.loan]);

    return (
        <div style={{ paddingLeft: "155px", width: "99%" }}>
        <Grid container className={classes.root} spacing={2}>
            <Grid item xs={12}>
                <Grid
                    container
                    spacing={spacing}
                    style={{ width: "100%" }}
                >
                  <Grid item>
                      <Paper className={classes.paper}>
                          <Typography type="headline" component="h2" className={classes.title}>
                                    Late Charge Provisions
                          </Typography>
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
                                                Will you be charging a late fee?
                                <Checkbox inputProps={{ 'aria-label': 'uncontrolled-checkbox' }} />
                                            </Typography>
                                        </Box>
                                    </Box>
                                </div>
                            <div>
                                <TextField
                                    id="lateChargeDays"
                                    className={classes.textFieldSmall}
                                    label="Late Charge Days"
                                    color="secondary"
                                    value={noteRef ? (noteRef.lateChargeDays ? noteRef.lateChargeDays : "") : ""}
                                    onChange={(e) => setNote({ ...noteRef,
                                        lateChargeDays: e.target.value
                                    })}
                                />
                            </div>
                            <div>
                                <TextField
                                    id="lateChargeMinimum"
                                    className={classes.textFieldSmall}
                                    label="Late Charge Minimum"
                                    color="secondary"
                                            value={noteRef ? (noteRef.lateChargeMinimum ? noteRef.lateChargeMinimum : "") : ""}
                                    onChange={(e) => setNote({
                                        ...noteRef,
                                        lateChargeMinimum: e.target.value
                                    })}
                                />
                                <TextField
                                    id="lateChargePercentage"
                                    className={classes.textFieldSmall}
                                    label="Late Charge Percentage"
                                    color="secondary"
                                            value={noteRef ? (noteRef.lateChargePercentage ? noteRef.lateChargePercentage : "") : ""}
                                    onChange={(e) => setNote({
                                        ...noteRef,
                                        lateChargePercentage: e.target.value
                                    })}
                                />
                            </div>
                        </form>
                    </Paper>
                            <br />
                            <Paper className={classes.paper}>
                                <Typography type="headline" component="h2" className={classes.title}>
                                    Minimum Interest Earned Option
                        </Typography>
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
                                                    In lieu of prepay, is loan subject to a minimum charge?
                                                <Checkbox inputProps={{ 'aria-label': 'uncontrolled-checkbox' }} />
                                                </Typography>
                                            </Box>
                                        </Box>
                                    </div>
                                    <div>
                                        <TextField
                                            id="minCharge"
                                            className={classes.textField}
                                            label="If yes, what is the minium charge?"
                                            color="secondary"
                                            value={noteRef ? (noteRef.minCharge ? noteRef.minCharge : "") : ""}
                                            onChange={(e) => setNote({
                                                ...noteRef,
                                                minCharge: e.target.value
                                            })}
                                        />
                                    </div>
                                </form>
                            </Paper>
                        </Grid>
                        <Grid item>
                            <Paper className={classes.smallPaper}>
                                <Typography type="headline" component="h2" className={classes.title}>
                                    Return Check Provisions
                        </Typography>
                                <form className={classes.root} noValidate autoComplete="off">
                                    <div>
                                        <TextField
                                            id="returnCheckPercentage"
                                            className={classes.textFieldSmall}
                                            label="Return Check: Percentage"
                                            color="secondary"
                                            value={noteRef ? (noteRef.returnCheckPercentage ? noteRef.returnCheckPercentage : "0") : "0"}
                                            onChange={(e) => setNote({
                                                ...noteRef,
                                                returnCheckPercentage: e.target.value
                                            })}
                                        />
                                    </div>
                                    <div>
                                        <TextField
                                            id="returnCheckMinFee"
                                            className={classes.textFieldSmall}
                                            label="Return Check: Minimum Fee"
                                            color="secondary"
                                            value={noteRef ? (noteRef.returnCheckMinFee ? noteRef.returnCheckMinFee : "") : ""}
                                            onChange={(e) => setNote({
                                                ...noteRef,
                                                returnCheckMinFee: e.target.value
                                            })}
                                        />
                                        <TextField
                                            id="returnCheckMaxFee"
                                            className={classes.textFieldSmall}
                                            label="Return Check: Maximum Fee"
                                            color="secondary"
                                            value={noteRef ? (noteRef.returnCheckMaxFee ? noteRef.returnCheckMaxFee : "") : ""}
                                            onChange={(e) => setNote({
                                                ...noteRef,
                                                returnCheckMaxFee: e.target.value
                                            })}
                                        />
                                    </div>
                                </form>
                            </Paper>
                            <br />
                            <Paper className={classes.xtraSmallPaper}>
                                <Typography type="headline" component="h2" className={classes.title}>
                                    Prepayment Penalty Options
                            </Typography>
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
                                                    Does loan contain a prepayment penalty?
                                                <Checkbox inputProps={{ 'aria-label': 'uncontrolled-checkbox' }} />
                                                </Typography>
                                            </Box>
                                        </Box>
                                    </div>
                                </form>
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
        height: 300,
        width: 400,
    },
    smallPaper: {
        height: 200,
        width: 400,
    },
    xtraSmallPaper: {
        height: 150,
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
export default withStyles(styles)(NoteRef);

