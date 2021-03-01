import React, { useState, useEffect } from "react";
import { Paper, withStyles, List, ListItem, ListItemAvatar, ListItemText, ListItemSecondaryAction, 
        Avatar, Grid, Button, Typography, Divider } from "@material-ui/core";
import Person from "@material-ui/icons/Person";
import auth from "../auth/auth-helper";
import { findUserProfile } from "../../utils/api-user.js";
import { Link, Redirect } from "react-router-dom";
import DeleteUser from "./DeleteUser";

const Profile = (props) => {
  const [user, setUser] = useState("");
  const [redirectToSignin, setRedirectToSignin] = useState(false);

  const init = (userId) => {
    const jwt = auth.isAuthenticated();
    findUserProfile(
      {
        userId: userId,
      },
      { t: jwt.token }
    ).then((data) => {
      if (data.error) {
        setRedirectToSignin(true);
      } else {
        setUser(data);
        console.log(data);
      }
    });
  };

  useEffect(() => {
    init(props.match.params.userId);
  }, []);

  const { classes } = props;
  if (redirectToSignin) {
    return <Redirect to="/signin" />;
  }
  return (
    <Paper className={classes.root}>
      <Grid  justify={"space-between"}>
        <Typography type="headline" component="h2" className={classes.title}>
          {auth.isAuthenticated() && "Profile"}
          {auth.isAdmin() && 
          <Link to="/signup" className={classes.link}>
            <Button variant="contained" color="secondary" className={classes.button} >
              NEW
            </Button>
          </Link>}
        </Typography>
      </Grid>
      <List dense>
        <ListItem>
          <ListItemAvatar>
            <Avatar>
              <Person />
            </Avatar>
          </ListItemAvatar>
          <ListItemText primary={user.name} secondary={user.username} />{" "}
          {auth.isAuthenticated().user &&
            auth.isAuthenticated().user._id === user._id && (
              <ListItemSecondaryAction>
                          {!auth.isAdmin() && <DeleteUser userId={user._id} />}
              </ListItemSecondaryAction>
            )}
        </ListItem>
        <Divider />
      </List>
    </Paper>
  );
};

const styles = (theme) => ({
  root: theme.mixins.gutters({
    maxWidth: 600,
    margin: "auto",
    padding: theme.spacing(3),
    marginTop: theme.spacing(5),
  }),
  title: {
    margin: `${theme.spacing(1)}px 0 ${theme.spacing(2)}px`,
    color: theme.palette.protectedTitle,
  },
  button: {
    float: "right"
  }
});

export default withStyles(styles)(Profile);
