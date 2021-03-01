import React, { useEffect, useState } from "react";
import { withStyles } from "@material-ui/core/styles";
import Card from "@material-ui/core/Card";
import CardContent from "@material-ui/core/CardContent";
import TextField from "@material-ui/core/TextField";
import auth from "./auth/auth-helper";
import { withRouter } from "react-router-dom";
import Switch from "@material-ui/core/Switch";

const Notes = withRouter((props) => {
  const { classes } = props;
  const [open, setOpen] = useState(false);
  const [loan, setLoan] = useState([]);

  useEffect(() => {
    setLoan(props.loan)
  }, [props.loan]);  
  
  // useEffect(() => {
  //   // localStorage.setItem("loan", JSON.stringify(loan))
  //   console.log(loan)
  //   props.handleLoanChange(loan)
  // }, []);
  useEffect(() => {
    props.handleLoanChange(loan)
  }, [loan ===null? "never": loan.note]);
  // console.log(loan)
  return (
    <div className={classes.root} style={{ marginLeft: "15vw" }}>
      {auth.isAuthenticated() && loan !==null && (
        <div >
          <div className={classes.label}>{open ? "" : "Notes"}</div>
          <Switch onChange={() => setOpen(!open)} className={classes.switch} />
          {open && (
            <Card>
              <CardContent className={classes.cardContent}>
                <TextField
                  id="filled-multiline-static"
                  label="Loan Notes"
                  multiline
                  fullWidth
                  rows={30}
                  value= {loan.textNotes ? loan.textNotes.noteText : ""}
                  variant="filled"
                  InputProps={{ disableUnderline: true }}
                  onChange={(e) => 
                    setLoan({...loan,
                      textNotes: {
                        noteText: e.target.value
                      }
                  })
                }
                />
              </CardContent>
            </Card>
          )}
        </div>
      )}
    </div>
  );
});
const styles = (theme) => ({
  root: {
    display: "flex",
    position: "fixed",
    right: 0,
    left: "auto",
    zIndex: 999,
    top: "100px",
  },
  cardContent: {
    width: "calc(50vw - 150px)",
    minWidth: "200px",
    maxWidth: "400px",
    padding: 0,
    "&:last-child": {
      paddingBottom: 0,
    },
  },
  switch: {
    position: "fixed",
    right: 0,
    left: "auto",
    top: "60px",
  },
  label: {
    position: "fixed",
    right: 60,
    left: "auto",
    top: "70px",
  },
});
export default withStyles(styles)(Notes);
