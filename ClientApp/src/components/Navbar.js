import React, { useState, useEffect } from "react";
import { makeStyles } from "@material-ui/core/styles";
import Drawer from "@material-ui/core/Drawer";
import AppBar from "@material-ui/core/AppBar";
import CssBaseline from "@material-ui/core/CssBaseline";
import Toolbar from "@material-ui/core/Toolbar";
import Typography from "@material-ui/core/Typography";
import List from "@material-ui/core/List";
import ListItem from "@material-ui/core/ListItem";
import IconButton from "@material-ui/core/IconButton";
import Grid from "@material-ui/core/Grid";
import Home from "@material-ui/icons/Home";
import Button from "@material-ui/core/Button";
import auth from "./auth/auth-helper";
import { Link, withRouter } from "react-router-dom";
import { Divider } from "@material-ui/core";
import { removeUndefinedProps } from "@material-ui/data-grid";
import logo from '../images/scrum.png';

const drawerWidth = "140";

const Navbar = withRouter(({ history,loan }) => {
  const classes = useStyles();
  const [open] = useState(true);
  const [loanNumber, setLoanNumber] = useState(loan);
  useEffect(() => {
    setLoanNumber(loan)
  }, [loan]);
  return (
    <div className={classes.root}>
      <img className={classes.image} src={logo} alt="logo"/>
      <CssBaseline />
      <AppBar position="fixed" className={classes.appBar}>
        <Toolbar className={classes.toolbar}>
          <Grid container spacing={0} direction="row" alignItems="center">
            <Grid item xs={3} sm={2} md={1} lg={1}>
              <Link to="/" className={classes.link}>
                <IconButton aria-label="Home" style={isActive(history, "/")}>
                  <Home />
                </IconButton>
              </Link>
            </Grid>
            <Grid item xs={3} sm={6} md={8} lg={9}>
            {auth.isAuthenticated() && (
              <Typography noWrap type="title" color="inherit">
                Loan Number: {(loanNumber!==null ) ? loanNumber.loanNumber : "Please select a loan. "} 
              </Typography>
            )}
            </Grid>
            <Grid item xs={6} sm={4} md={3} lg={2} align="center">
              {!auth.isAuthenticated() && (
                <span>
                  {/* <Link to="/signup" className={classes.link}>
                    <Button style={isActive(history, "/signup")}>
                      Sign up
                    </Button>
                  </Link> */}
                  <Link to="/signin" className={classes.link}>
                    <Button style={isActive(history, "/signin")}>
                      Sign In
                    </Button>
                  </Link>
                </span>
              )}
              {auth.isAuthenticated() && (
                <span>
                  <Link
                    to={"/user/" + auth.isAuthenticated().user._id}
                    className={classes.link}
                  >
                    <Button
                      style={isActive(
                        history,
                        "/user/" + auth.isAuthenticated().user._id
                      )}
                    >
                      {auth.isAuthenticated().user.username}
                    </Button>
                  </Link>
                  <Link to={"/"} className={classes.link}>
                    <Button
                      style={isActive(
                        history,
                        "/" + auth.isAuthenticated().user._id
                      )}
                      color="inherit"
                      onClick={() => {
                        auth.signout(() => history.push("/"));
                      }}
                    >
                      Sign out
                    </Button>
                  </Link>
                </span>
              )}
            </Grid>
          </Grid>
        </Toolbar>
      </AppBar>
      {auth.isAuthenticated() &&
        open && (
          <Drawer
            className={classes.drawer}
            variant="permanent"
            classes={{
              paper: classes.drawerPaper,
            }}
          >
            <List style={{ paddingTop: "50px" }}>
              <Divider />
              <Link to="/borrower" className={classes.link}>
                <ListItem button style={isActive(history, "/borrower")}>
                  Borrower
                </ListItem>
              </Link>
              <Divider />
              <Link to="/loan_data" className={classes.link}>
                <ListItem button style={isActive(history, "/loan_data")}>
                  Loan Data
                </ListItem>
              </Link>
              <Divider />
              <Link to="/note" className={classes.link}>
                <ListItem button style={isActive(history, "/note")}>
                  Note
                </ListItem>
              </Link>
              <Divider />
              <Link to="/trustee_mailing" className={classes.link}>
                <ListItem button style={isActive(history, "/trustee_mailing")}>
                  Trustee/Mailing
                </ListItem>
              </Link>
              <Divider />
              <Link to="/cost_expense" className={classes.link}>
                <ListItem button style={isActive(history, "/cost_expense")}>
                  Cost/Expense
                </ListItem>
              </Link>
              <Divider />
              <Link to="/property" className={classes.link}>
                <ListItem button style={isActive(history, "/property")}>
                  Property
                </ListItem>
              </Link>
              <Divider />
              <Link to="/assignment" className={classes.link}>
                <ListItem button style={isActive(history, "/assignment")}>
                  Assignment
                </ListItem>
              </Link>
              <Divider />
              <Link to="/escrow" className={classes.link}>
                <ListItem button style={isActive(history, "/escrow")}>
                  Escrow
                </ListItem>
              </Link>
              <Divider />
              <Link to="/finance_charge" className={classes.link}>
                <ListItem button style={isActive(history, "/finance_charge")}>
                  Finance Charge
                </ListItem>
              </Link>
              <Divider />
              {/* <Link to="/broker_servicing" className={classes.link}> */}
                <ListItem button style={isActive(history, "/broker_servicing")} disabled>
                  Broker/Servicing
                </ListItem>
              {/* </Link> */}
              <Divider />
              {/* <Link to="/add_servicing" className={classes.link}> */}
                <ListItem button style={isActive(history, "/add_servicing")} disabled>
                  Additional Servicing
                </ListItem>
              {/* </Link> */}
              <Divider />
              {/* <Link to="/documents" className={classes.link}> */}
                <ListItem button style={isActive(history, "/documents")} disabled>
                  Documents
                </ListItem>
              {/* </Link> */}
              <Divider />
            </List>
          </Drawer>
        )}
      <main className={classes.content}>
        <Toolbar />
      </main>
    </div>
  );
});

const isActive = (history, path) => {
  if (history.location.pathname === path)
    return {
      color: "#2c7ac9",
    };
  else
    return {
      color: "#ffffff",
    };
};
const useStyles = makeStyles((theme) => ({
  root: {
    display: "flex",
  },
  appBar: {
    zIndex: theme.zIndex.drawer + 1,
  },
  drawer: {
    width: drawerWidth,
    flexShrink: 0,
  },
  drawerPaper: {
    width: drawerWidth,
    maxWidth: 142,
  },
  drawerContainer: {
    overflow: "auto",
  },
  content: {
    flexGrow: 1,
    // padding: theme.spacing(3),
  },
  toolbar: {
    minHeight: 5,
    padding: 0,
  },
  link: {
    textDecoration: "none",
    color: "#ffffff",
  },
  icon: {
    paddingLeft: 15,
  },
  image: {
    position: "fixed",
    right: "0",
    left: "auto",
    bottom: 10,
    maxWidth: "100px",
    width: "20%",
    height: "auto",
  }
}));

export default Navbar;
