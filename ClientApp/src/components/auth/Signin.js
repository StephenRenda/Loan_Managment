import React, { useState } from "react";
import Card from "@material-ui/core/Card";
import CardContent from "@material-ui/core/CardContent";
import CardActions from "@material-ui/core/CardActions";
import Button from "@material-ui/core/Button";
import TextField from "@material-ui/core/TextField";
import Typography from "@material-ui/core/Typography";
import Icon from "@material-ui/core/Icon";
import { withStyles } from "@material-ui/core/styles";
import auth from "./auth-helper";
import { Redirect } from "react-router-dom";
import { signin } from "../../utils/api-auth.js";
import logo from '../../images/scrum.png';

const Signin = (props) => {
  const [form, setState] = useState({
    username: "",
    password: "",
    error: "",
    redirectToReferrer: false,
  });

  const clickSubmit = () => {
    const user = {
      username: form.username || undefined,
      password: form.password || undefined,
    };
    signin(user).then((data) => {
      if (data.error) {
        setState({
          ...form,
          error: data.error,
        });
      } else {
        auth.authenticate(data, () => {
          setState({
            ...form,
            redirectToReferrer: true,
          });
        });
      }
    });
  };

  const handleChange = (name) => (e) => {
    setState({
      ...form,
      [name]: e.target.value,
    });
  };

  const { classes } = props;
  const { from } = props.location.state || {
    from: {
      pathname: "/",
    },
  };
  return form.redirectToReferrer ? (
    <Redirect to={from} />
  ) : (
    <div>
      <img className={classes.image} src={logo} alt="logo"/>
      <Card className={classes.card}>
        <CardContent>
          <Typography type="headline" component="h2" className={classes.title}>
            Sign In
          </Typography>
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
          <TextField
            id="password"
            type="password"
            label="Password"
            className={classes.textField}
            value={form.password}
            onChange={handleChange("password")}
            margin="normal"
          />
          <br />
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
    </div>);
};

const styles = (theme) => ({
  card: {
    maxWidth: 600,
    margin: "auto",
    textAlign: "center",
    marginTop: theme.spacing(20),
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
  image: {
    position: "fixed",
    verticalAlign: "middle",
    right: "44vw",
    left: "auto",
    top: 60,
    maxWidth: "180px",
    width: "50%",
    height: "auto",
  }
});

export default withStyles(styles)(Signin);
