import React, { useState } from "react";
import clsx from 'clsx';
import IconButton from '@material-ui/core/IconButton';
import FormControl from '@material-ui/core/FormControl';
import InputLabel from '@material-ui/core/InputLabel';
import InputAdornment from '@material-ui/core/InputAdornment';
import Input from '@material-ui/core/Input';
import Card from "@material-ui/core/Card";
import CardContent from "@material-ui/core/CardContent";
import CardActions from "@material-ui/core/CardActions";
import Button from "@material-ui/core/Button";
import TextField from "@material-ui/core/TextField";
import Typography from "@material-ui/core/Typography";
import Icon from "@material-ui/core/Icon";
import { withStyles } from "@material-ui/core/styles";
import DialogTitle from "@material-ui/core/DialogTitle";
import DialogActions from "@material-ui/core/DialogActions";
import DialogContentText from "@material-ui/core/DialogContentText";
import DialogContent from "@material-ui/core/DialogContent";
import Dialog from "@material-ui/core/Dialog";
import { Link } from "react-router-dom";
import Visibility from '@material-ui/icons/Visibility';
import VisibilityOff from '@material-ui/icons/VisibilityOff';

import { registerUser } from "../../utils/api-user.js";

const Signup = (props) => {
  const [form, setState] = useState({
    fname: "",
    lname: "",
    username: "",
    password: "",
    open: false,
    error: "",
  });

  const handleChange = (name) => (e) => {
    setState({
      ...form,
      [name]: e.target.value,
    });
  };

  const handleClickShowPassword = () => {
    setState({ ...form, showPassword: !form.showPassword });
  };

  const handleMouseDownPassword = (event) => {
    event.preventDefault();
  };

  const clickSubmit = () => {
    const user = {
      fname: form.fname || undefined,
      lname: form.lname || undefined,
      username: form.username || undefined,
      password: form.password || undefined,
    };
    registerUser(user).then((data) => {
      if (data.error) {
        setState({
          ...form,
          error: data.error,
        });
      } else {
        setState({
          ...form,
          error: "",
          open: true,
        });
      }
    });
  };

  const { classes } = props;
  return (
    <div>
      <Card className={classes.card}>
        <CardContent>
          <Typography type="headline" component="h2" className={classes.title}>
            Sign Up
          </Typography>
          <TextField
            id="fname"
            label="First Name"
            className={classes.textField}
            value={form.fname}
            onChange={handleChange("fname")}
            margin="normal"
          />
          <br />          
          <TextField
            id="lname"
            label="Last Name"
            className={classes.textField}
            value={form.lname}
            onChange={handleChange("lname")}
            margin="normal"
          />
          <br />
          <TextField
            id="username"
            type="username"
            label="Username"
            className={classes.textField}
            value={form.username}
            onChange={handleChange("username")}
            margin="normal"
          />
          <br />
          <FormControl className={clsx(classes.margin, classes.textField)}>
          <InputLabel htmlFor="standard-adornment-password">Password</InputLabel>
          <Input
            id="standard-adornment-password"
            type={form.showPassword ? 'text' : 'password'}
            value={form.password}
            onChange={handleChange('password')}
            endAdornment={
              <InputAdornment position="end">
                <IconButton
                  aria-label="toggle password visibility"
                  onClick={handleClickShowPassword}
                  onMouseDown={handleMouseDownPassword}
                >
                  {form.showPassword ? <Visibility /> : <VisibilityOff />}
                </IconButton>
              </InputAdornment>
            }
          />
        </FormControl>
          <br />{" "}
          {form.error && (
            <Typography component="p" color="error">
              <Icon color="error" className={classes.error} />
              {form.error}
            </Typography>
          )}
        </CardContent>
        <CardActions>
          <Button
            color="primary"
            variant="contained"
            onClick={clickSubmit}
            className={classes.submit}
          >
            Submit
          </Button>
        </CardActions>
      </Card>
      <Dialog open={form.open} disableBackdropClick={true}>
        <DialogTitle>New Account</DialogTitle>
        <DialogContent>
          <DialogContentText>
            New account successfully created.
          </DialogContentText>
        </DialogContent>
        <DialogActions>
          <Link to="/signin">
            <Button color="primary" autoFocus="autoFocus" variant="contained">
              Sign In
            </Button>
          </Link>
        </DialogActions>
      </Dialog>
    </div>
  );
};

const styles = (theme) => ({
  card: {
    maxWidth: 600,
    margin: "auto",
    textAlign: "center",
    marginTop: theme.spacing(5),
    paddingBottom: theme.spacing(2),
  },
  error: {
    verticalAlign: "middle",
  },
  title: {
    marginTop: theme.spacing(2),
    color: theme.palette.openTitle,
  },
  textField: {
    marginLeft: theme.spacing(),
    marginRight: theme.spacing(),
    width: 300,
  },
  submit: {
    margin: "auto",
    marginBottom: theme.spacing(2),
  },
});
export default withStyles(styles)(Signup);
