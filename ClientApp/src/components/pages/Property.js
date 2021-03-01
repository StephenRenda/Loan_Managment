import React, { useState, useEffect } from "react";
import Box from '@material-ui/core/Box';
import Button from "@material-ui/core/Button";
import Grid from "@material-ui/core/Grid";
import Paper from "@material-ui/core/Paper";
import { withStyles } from "@material-ui/core/styles";
import Table from "@material-ui/core/Table";
import TableBody from "@material-ui/core/TableBody";
import TableCell from "@material-ui/core/TableCell";
import TableContainer from "@material-ui/core/TableContainer";
import TableHead from "@material-ui/core/TableHead";
import TableRow from "@material-ui/core/TableRow";
import TextField from "@material-ui/core/TextField";
import Typography from "@material-ui/core/Typography";
import Checkbox from '@material-ui/core/Checkbox';
import Pagination from "@material-ui/lab/Pagination";
import PaginationItem from "@material-ui/lab/PaginationItem";
import { DataGrid } from "@material-ui/data-grid";
import { editLoans, editProperty } from "../../utils/api-loan.js";


const Property = (props) => {
  const { classes } = props;
  const [spacing, setSpacing] = React.useState(2);
  const [property, setProperty] = useState();
  const [rows, setRows] = useState([]);

  useEffect(() => {
    if (!(props.loan === null || props.loan === "empty" || !props.loan.property)) {
      setProperty(props.loan.property)
    }
  }, [props.loan]);

  const handlesubmit = (() => {
    let temp = JSON.parse(JSON.stringify(props.loan));
    const propertyMod = {
      id: property.id,
      subject: property.subject,
      unincorporatedArea: property.unincorporatedArea,
      apn: property.apn,
      constructionType: property.constructionType,
      constructionDescription: property.constructionDescription,
      legalDescription: property.legalDescription,
      fireInsurancePolicyAmt: property.fireInsurancePolicyAmt,
      annualInsurancePremiumAmt: property.annualInsurancePremiumAmt,
      lossPayableClause: property.lossPayableClause,
      address: property.address,
      fireInsuranceAddress: property.fireInsuranceAddress,
    };
    console.log("Property edited")
    console.log(propertyMod)
    editProperty({
      id: property.id,
      loan: propertyMod,
    })
      .then((data) => {
        if (data.error) {
          console.log(data.error)
        } else {
          console.log("Successfully updated db.")
        }
      })
    temp.property = property;
    props.handleLoanChange(temp);
  })

  useEffect(() => {
    if (property != null) {
      let row = [];
      row = [{
        id: 1,
        prop: 0,
        address: property.address.address1,
        city: property.address.city,
        state: property.address.state,
        zip: property.address.zip,
        subject: property.subject
      },]
      setRows(row)
    }
  }, [property]);

  const columns = [
    { field: 'prop', headerName: 'Prop #', width: 90 },
    { field: 'address', headerName: 'Street Address', width: 90 },
    { field: 'city', headerName: 'City', width: 90 },
    { field: 'state', headerName: 'State', width: 90 },
    { field: 'zip', headerName: 'Zip', width: 90 },
    { field: 'subject', headerName: 'Subject', width: 90 },
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
      <Button variant="contained" color="secondary" className={classes.submit} onClick={handlesubmit}>
        SUBMIT
      </Button>
      <Grid
        container
        justify="center"
        spacing={spacing}
        style={{ width: "100%" }}
      >

        <Grid
          item
          justify="center"
          spacing={spacing}
          style={{ width: "60%" }}>
          <div style={{ height: 400, width: "100%" }}>
          <DataGrid
            rows={rows ? rows : null}
            columns={columns}
            pageSize={1}
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
          <Paper
            className={classes.largePaper}
            justifyContent="center"
            align="center">
            <Typography
              type="headline"
              component="h2"
              className={classes.title}
              justifyContent="center"
            >
              Property Details
            </Typography>
            <Grid
              container
              justify="center"
              spacing={spacing}
              style={{ width: "100%", height:"100%" }}>

              <Grid
                container
                justify="space-between"
                spacing={spacing}
                style={{ width: "70%", height: "60%" }}
                direction="row">
                <Box
                  display="flex"
                  flexDirection="row">
                  <Box
                    flexDirection="column"
                    display="flex"
                    alignItems="flex-start"
                    justifyContent="center">
                    <Box>   
                      <TextField
                        id="outlined-basic"
                        label="Address"
                        defaultValue=""
                        value={property ? property.address.address1 : ""}
                        onChange={(e) => setProperty({
                          ...property,
                          address: { ...property.address, address1: e.target.value }
                        })}
                       />
                    </Box>
                    <Box>
                      <TextField
                        id="outlined-basic"
                        label="City"
                        defaultValue=""
                        value={property ? property.address.city : ""}
                        onChange={(e) => setProperty({
                          ...property,
                          address: { ...property.address, city: e.target.value }
                        })}
                      />
                    </Box>
                    <Box>
                      <TextField
                        id="outlined-basic"
                        label="State"
                        defaultValue=""
                        value={property ? property.address.state : ""}
                        onChange={(e) => setProperty({
                          ...property,
                          address: { ...property.address, state: e.target.value }
                        })}
                      />
                    </Box>
                    <Box>
                      <TextField
                        id="outlined-basic"
                        label="Zip"
                        defaultValue=""
                        value={property ? property.address.zip : ""}
                        onChange={(e) => setProperty({
                          ...property,
                          address: { ...property.address, zip: e.target.value }
                        })}
                      />
                    </Box>
                    <Box>
                      <TextField
                        id="outlined-basic"
                        label="APN"
                        defaultValue=""
                        value={property ? property.APN : ""}
                        onChange={(e) => setProperty({
                          ...property,
                          address: { ...property.address, apn: e.target.value }
                        })}
                      />
                    </Box>
                  </Box>
                  <Box px={1} py={1}>
                    <Box px={1}>
                      <Box display="flex" flexDirection="row">
                        <Box pt={1}>
                          <Typography>
                            Print Trust Deed or Assignment
                          </Typography>
                        </Box>
                        <Box>
                          <Checkbox inputProps={{ 'aria-label': 'uncontrolled-checkbox' }} />
                        </Box>
                      </Box>
                    </Box>
                    <Box px={1} alignContent="left">
                      <Typography>
                        Property Income
                      </Typography>
                      <TextField id="standard-basic" label="Gross"/>
                      <TextField id="standard-basic" label="Net" />
                    </Box>
                  </Box>
                </Box>
                <Grid
                  container
                  justify="space-between"
                  spacing={spacing-2}
                  style={{ width: "70%", height: "40%" }}
                  direction="column">
                  <Box>
                  <TextField
                    id="consttype"
                      label="Construction Type"
                      defaultValue=""
                      value={property ? property.constructionType : ""}
                      onChange={(e) => setProperty({
                        ...property,
                        constructionType: e.target.value
                      })}
                  />
                  <TextField
                    id="constdesc"
                      label="Description"
                      defaultValue=""
                      value={property ? property.constructionDescription : ""}
                      onChange={(e) => setProperty({
                        ...property,
                        constructionDescription: e.target.value
                      })}
                  />
                  </Box>
                </Grid>
              </Grid>
              <Grid
                container
                justify="center"
                spacing={spacing}
                style={{ width: "30%", height: "100%"}}>
                <Grid
                  item>
                  <Typography>
                    Commands
                  </Typography>
                  <Button variant="contained" className={classes.button}>
                    Add Property
                  </Button>
                  <Button variant="contained" className={classes.button}>
                    Delete Property
                  </Button>
                  <Button variant="contained" className={classes.button}>
                    Legal Description
                  </Button>
                  <Button variant="contained" className={classes.button}>
                    Fire Insurance
                  </Button>
                  <Button variant="contained" className={classes.button}>
                    LPD Information
                  </Button>
                  <Button variant="contained" className={classes.button}>
                    Security Declaration
                  </Button>
                  <Button variant="contained" className={classes.button}>
                    Shr. App. Mortgages
                  </Button>
                </Grid>
              </Grid>

            </Grid>
          </Paper>
        </Grid>

      </Grid>
    </div>
  );
};

const defaultProps = {
  bgcolor: 'background.paper',
  m: 1,
  style: { width: '5rem', height: '5rem' },
  borderColor: 'text.primary',
  borderStyle: 'solid'
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
  groupPaper: {
    height: 50,
    width: 80,
  },
  smallPaper: {
    height: 60,
    width: 815,
  },
  fillPaper: {
    height: "100%",
    width: "100%",
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
  submit: {
    margin: theme.spacing(1),
    width: "10ch",
    position: "fixed",
    bottom: 10,
    zIndex: 500,
  },
  button: {
    margin: theme.spacing(1),
    width: "28ch",
    height: 30,
  },
  title: {
    padding: `${theme.spacing(1)}px ${theme.spacing(2.5)}px ${theme.spacing() *
      1}px`,
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
export default withStyles(styles)(Property);
